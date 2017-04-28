using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;
using One.Views.RestrictionAccess.Custom;

namespace One.Views.FileManagement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
            if (!IsPostBack)
            {
                //PopulateData();

                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    FileListingUc1.FolderSelectionType = false;
                    FileDeleteDialogUc1.SetValues("Delete");
                    var folderId = Convert.ToInt32(Request.QueryString["folId"] ?? "0");
                    FolderId = folderId;

                    var isServerFile = ((Request.QueryString["type"] ?? "private") == "server"
                        && user.IsInRole("manager"));
                    IsServerFile = isServerFile;

                    FilePickerDialog1.SetValues("File upload", null, "", "");
                    FilePickerDialog1.OnlyUploadAvailable = true;
                    var guid = Guid.NewGuid().ToString();
                    FilePickerDialog1.PageKey = guid;
                    FilePickerDialog1.FileSaveDirectory = DbHelper.StaticValues.PrivateFiesLocation;
                    FilePickerDialog1.FileAcquireMode = Enums.FileAcquireMode.Single;
                    FilePickerDialog1.FolderId = folderId;
                }
                else Response.Redirect("~/");

            }
        }

        private void Initialize()
        {
            Page.Title = "File management";
            FileListingUc1.RenameClicked += FileListingUc1_RenameClicked;
            FileListingUc1.DeleteClicked += FileListingUc1_DeleteClicked;
            FileDeleteDialogUc1.OkClick += FileDeleteDialogUc1_OkClick;
            FilePickerDialog1.UploadClicked += FilePickerDialog1_UploadClicked;
            file_upload.Style.Add("visibility", " hidden");
            SetFolderAddDialog();
            FolderAddDialogUc1.FolderSavedEvent += FolderAddDialogUc1_FolderSavedEvent;
        }

        public bool IsServerFile
        {
            get { return Convert.ToBoolean(hidIsServerFile.Value); }
            set
            {
                hidIsServerFile.Value = value.ToString();
                FileListingUc1.IsServerFile = value;
                FolderAddDialogUc1.IsServerFile = value;
            }
        }


        void FilePickerDialog1_UploadClicked(object sender, Academic.ViewModel.FileResourceEventArgs e)
        {
            //save file information to database
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                using (var helper = new DbHelper.WorkingWithFiles())
                {
                    var fileName = Path.GetFileName(e.FilePath);
                    var fi = new Academic.DbEntities.UserFile()
                    {
                        Id = e.Id,
                        CreatedBy = user.Id
                        ,
                        CreatedDate = DateTime.Now
                        ,
                        DisplayName = e.FileDisplayName //Path.GetFileName(imageFile.FileName)
                        ,
                        FileDirectory = DbHelper.StaticValues.PrivateFiesLocation//CourseFilesLocation //StaticValue.UserImageDirectory
                        ,
                        FileName = fileName
                            //Guid.NewGuid().ToString() + GetExtension(imageFile.FileName, imageFile.ContentType)
                        ,
                        FileSizeInBytes = e.FileSizeInBytes //imageFile.ContentLength
                        ,
                        FileType = e.FileType //imageFile.ContentType
                        ,
                        IconPath = e.IconPath
                        ,
                        IsFolder = false
                        ,
                        IsServerFile = IsServerFile
                        ,SchoolId = user.SchoolId
                        //SubjectId = SubjectId
                        //,
                        //Void = !f.Visible
                    };
                    var folderId = FolderId;
                    if (folderId > 0)
                    {
                        fi.FolderId = folderId;
                    }
                    var saved = helper.AddOrUpdateFile(fi);
                    if (saved != null)
                    {
                        //Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
                        FilePickerDialog1.CloseDialog();
                        FileListingUc1.ResetView();
                    }
                }
            }
        }





        void FileDeleteDialogUc1_OkClick(object sender, Academic.ViewModel.IdAndNameEventArgs e)
        {
            FileDeleteDialogUc1.CloseDialog();
            FileListingUc1.ResetView();
        }

        void FileListingUc1_DeleteClicked(object sender, Academic.ViewModel.IdAndNameEventArgs e)
        {
            FileDeleteDialogUc1.FileName = e.Name;
            FileDeleteDialogUc1.FileId = e.Id;
            //FileDeleteDialogUc1.ParentFolderId
            FileDeleteDialogUc1.SetValues("Delete " + e.RefIdString);
            FileDeleteDialogUc1.OpenDialog();
        }





        void SetFolderAddDialog()
        {
            FolderAddDialogUc1.SetValues("New folder");//, null, ""
            FolderAddDialogUc1.ParentFolderId = FolderId;
        }

        /// <summary>
        /// Files of this folder are listed
        /// </summary>
        public int FolderId
        {
            get { return Convert.ToInt32(hidFolderId.Value); }
            set
            {
                hidFolderId.Value = value.ToString();
                FileListingUc1.FolderId = value;
            }
        }



        protected void lnkAddFolder_OnClick(object sender, EventArgs e)
        {
            FolderAddDialogUc1.OpenDialog();
        }

        protected void lnkAddFile_OnClick(object sender, EventArgs e)
        {

            FilePickerDialog1.OpenDialog();
        }

        void FileListingUc1_RenameClicked(object sender, Academic.ViewModel.IdAndNameEventArgs e)
        {
            FolderAddDialogUc1.FolderId = e.Id;
            FolderAddDialogUc1.FolderName = e.Name;
            FolderAddDialogUc1.SetValues("Folder rename");
            FolderAddDialogUc1.OpenDialog();
        }

        void FolderAddDialogUc1_FolderSavedEvent(object sender, Academic.DbHelper.MessageEventArgs e)
        {
            FolderAddDialogUc1.CloseDialog();
            if (e.SaveSuccess)
            {
                //reload the list
                FileListingUc1.ResetView();
            }
        }


    }
}