using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities;
using Academic.DbEntities.Subjects;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.FileManagement
{
    public partial class FileListingUc : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> RenameClicked;
        public event EventHandler<IdAndNameEventArgs> DeleteClicked;

        public event EventHandler<IdAndNameEventArgs> FileSelected;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (!IsPostBack)
                //{
                //    //PopulateData();
                //    var folderId = Convert.ToInt32(Request.QueryString["folId"] ?? "0");
                //    //LoadFileResource(folderId);
                //    FolderId = folderId;
                //}
                LoadFileResource(FolderId);
            }
            catch (Exception exe)
            {
                Response.Redirect("~/");
            }
        }

        /// <summary>
        /// Files of this folder are listed
        /// </summary>
        public int FolderId
        {
            get { return Convert.ToInt32(hidFolderId.Value); }
            set { hidFolderId.Value = value.ToString(); }
        }

        /// <summary>
        /// either private or server files
        /// </summary>
        public string FilesFrom
        {
            get { return hidFilesFrom.Value; }
            set { hidFilesFrom.Value = value; }
        }


        private void LoadFileResource(int folderId)
        {
            var type = (IsServerFile ? "server" : "private");
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                var isServerFile = IsServerFile;
                using (var helper = new DbHelper.WorkingWithFiles())
                {
                    List<UserFile> fileR;

                    #region Sitemap and fileR value assign

                    var sitemap = new List<IdAndName>()
                        {
                            new IdAndName()
                            {
                                Id=0 ,Name= (isServerFile?"Server":"Private") + " files",Void = true
                                ,Value = "~/Views/FileManagement/?folId=0&type="+type
                            }
                        };

                    if (folderId == 0)
                    {
                        fileR = helper.ListUserFiles(user.Id, folderId, isServerFile, user.SchoolId);
                    }
                    else
                    {
                        var parent = helper.GetFolderOfFilesList(user.Id, folderId, isServerFile, user.SchoolId);
                        if (parent == null)
                        {
                            Response.Redirect("~/Views/FileManagement/?folId=0&type=" + type, false);
                            return;
                        }
                        else
                        {
                            fileR = parent.FilesInThisFolder.Where(x => x.IsServerFile == isServerFile)
                                .OrderBy(x => x.DisplayName)
                                .ToList();
                            UserFile temp = parent;

                            var tempSiteMap = new List<IdAndName>();
                            do
                            {

                                tempSiteMap.Add(new IdAndName()
                                {
                                    Id = temp.Id,
                                    Name = temp.DisplayName,
                                    Void = true
                                    ,
                                    Value = "~/Views/FileManagement/?folId=" + (temp.Id) + "&type=" + type
                                });
                                temp = temp.Folder;
                            } while (temp != null);

                            tempSiteMap.Reverse();
                            sitemap.AddRange(tempSiteMap);
                        }
                    }
                    sitemap[sitemap.Count - 1].Void = false;
                    sitemap[sitemap.Count - 1].Value = "";
                    SiteMapUc.SetData(sitemap);

                    #endregion

                    if (fileR != null)
                    {
                        var i = 1;

                        #region Folders

                        var folders = fileR.Where(x => x.IsFolder).ToList();
                        if (folders.Any())
                        {
                            foreach (var f in folders)
                            {
                                var file = new FileResourceEventArgs()
                                {
                                    Id = f.Id,
                                    Visible = true,
                                    FileType = f.FileType,
                                    IconPath = (f.IsConstantAndNotEditable ?? false) ? DbHelper.StaticValues.FolderIconLockedDirectory : DbHelper.StaticValues.FolderIconDirectory,
                                    FilePath = f.FileDirectory + "/" + f.FileName,
                                    FileDisplayName = f.DisplayName,
                                    FileSizeInBytes = f.FileSizeInBytes,
                                    LocalId = i.ToString(),
                                    IsConstantAndNotEditable = f.IsConstantAndNotEditable ?? false
                                };
                                PopulateSingleData(file, true);
                                i++;
                            }
                        }
                        else
                        {
                            //hide folder panel
                            pnlFoldersPanel.Visible = false;
                        }

                        #endregion

                        #region Files

                        var files = fileR.Where(x => !x.IsFolder).ToList();
                        if (files.Any())
                        {
                            foreach (var f in files)
                            {
                                var file = new FileResourceEventArgs()
                                {
                                    Id = f.Id,
                                    Visible = true,
                                    FileType = f.FileType,
                                    IconPath = string.IsNullOrEmpty(f.IconPath) ? f.FileDirectory + "/" + f.FileName : f.IconPath,
                                    FilePath = f.FileDirectory + "/" + f.FileName,
                                    FileDisplayName = f.DisplayName,
                                    FileSizeInBytes = f.FileSizeInBytes,
                                    LocalId = i.ToString(),
                                    IsConstantAndNotEditable = f.IsConstantAndNotEditable ?? false
                                };
                                PopulateSingleData(file, false);
                                i++;
                            }
                        }
                        else
                        {
                            //hide folder panel
                            pnlFilesPanel.Visible = false;
                        }
                        #endregion
                    }
                }
            }
        }


        public bool IsServerFile
        {
            get { return Convert.ToBoolean(hidIsServerFile.Value); }
            set
            {
                hidIsServerFile.Value = value.ToString();
            }
        }



        private void PopulateSingleData(FileResourceEventArgs file, bool isFolder)
        {
            var fileUc = (EachFile)
                                Page.LoadControl("~/Views/FileManagement/EachFile.ascx");
            fileUc.Visible = file.Visible;
            fileUc.ID = "file_" + file.LocalId;
            var fileName = file.FileDisplayName;
            var wrapedName = "";
            var lengthToCheck = file.FileType.ToLower().Equals("folder") ? 12 : 9;

            if (fileName.Length > lengthToCheck)
            {
                wrapedName = fileName.Substring(0, lengthToCheck) + "...";
            }
            else
            {
                wrapedName = fileName;
            }


            fileUc.SetData(file.IconPath, wrapedName, file.Id, file.LocalId, file.FilePath
                , fileName, isFolder, true, file.IsConstantAndNotEditable, file.FileType);
            fileUc.FileClicked += fileUc_FileClicked;
            fileUc.RenameClicked += fileUc_RenameClicked;
            fileUc.DeleteClicked += fileUc_DeleteClicked;

            if (isFolder)
                pnlFolderListing.Controls.Add(fileUc);
            else
                pnlFilesListing.Controls.Add(fileUc);
        }

        void fileUc_DeleteClicked(object sender, IdAndNameEventArgs e)
        {
            if (DeleteClicked != null)
            {
                DeleteClicked(sender, e);
            }
        }

        void fileUc_RenameClicked(object sender, IdAndNameEventArgs e)
        {
            if (RenameClicked != null)
            {
                RenameClicked(sender, e);
            }
        }

        /// <summary>
        /// True: Postback , False: Redirect
        /// </summary>
        public bool FolderSelectionType
        {
            get { return Convert.ToBoolean(hidFolderSelectionType.Value); }
            set { hidFolderSelectionType.Value = value.ToString(); }
        }

        void fileUc_FileClicked(object sender, IdAndNameEventArgs e)
        {
            //if (Convert.ToBoolean(e.RefIdString))
            //{
            //    Response.Redirect("~/Views/FileManagement/Default.aspx?folId=" + e.Id, true);
            //    //pnlFilesListing.Controls.Clear();
            //    //pnlFolderListing.Controls.Clear();
            //    //LoadFileResource(FolderId);
            //    FolderId = e.Id;
            //    ResetView();
            //}

            if (FolderSelectionType)
            {
                //Postback
                if (e.Check)//check has IsFolder value
                {
                    FolderId = e.Id;
                    ResetView();
                }
                else
                {
                    //file is selected 
                    if (FileSelected != null)
                    {
                        FileSelected(sender, e);
                    }
                }
            }
            else
            {
                //redirect
                if (e.Check)//check has IsFolder value
                    Response.Redirect("~/Views/FileManagement/?folId=" + e.Id + "&type=" + (IsServerFile ? "server" : "private"), true);
            }


        }

        List<FileResourceEventArgs> GetData()
        {

            var lst = new List<FileResourceEventArgs>()
            {
                new FileResourceEventArgs()
                {
                    FileDisplayName= "08_chapter 3.pdf"
                    ,FilePath= "~/Content/Images/AssignmentSubmission/3eed4cab-6551-484a-b4e1-ca07a22dee7b.pdf"
                    ,FileSizeInBytes= 29983
                    ,FileType= "application/pdf"
                    ,IconPath= "~/Content/Icons/File/pdf_icon.png"
                    ,Id= 0
                    ,LocalId= "1"
                    ,Visible= true
                }
                ,
                new FileResourceEventArgs()
                {
                    FileDisplayName= "BE_Computer_6th.pdf"
                    ,FilePath= "~/Content/Images/AssignmentSubmission/3c811ffd-1454-4f31-af87-21eaa4fa90a1.pdf"
                    ,FileSizeInBytes= 61188
                    ,FileType= "application/pdf"
                    ,IconPath= "~/Content/Icons/File/pdf_icon.png"
                    ,Id= 0
                    ,LocalId= "2"
                    ,Visible= true
                }
                ,
            };
            return lst;
        }

        public bool ShowEditControls
        {
            get { return Convert.ToBoolean(hidShowEditControls.Value); }
            set { hidShowEditControls.Value = value.ToString(); }
        }

        public void ResetView()
        {
            pnlFilesListing.Controls.Clear();
            pnlFolderListing.Controls.Clear();
            pnlFilesPanel.Visible = true;
            pnlFoldersPanel.Visible = true;
            LoadFileResource(FolderId);
        }
    }
}