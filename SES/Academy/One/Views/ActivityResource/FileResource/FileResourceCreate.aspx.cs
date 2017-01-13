using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values;
using One.Values.MemberShip;

namespace One.Views.ActivityResource.FileResource
{
    public partial class FileResourceCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //FilesDisplay1.FileChoosen += FilesDisplay1_FileChoosen;
            if (!IsPostBack)
            {
                FilesDisplay1.NumberOfFilesToUpload = 5;
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                var arId = Request.QueryString["arId"];
                try
                {
                    if (subId != null && secId != null)
                    {
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = Convert.ToInt32(subId);

                    }
                    if (arId != null)
                    {
                        FileResourceId = Convert.ToInt32(arId);
                        LoadFileResource();
                    }
                }
                catch
                {

                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }

                
                FilesDisplay1.FileSaveDirectory = DbHelper.StaticValues.CourseFilesLocation;
                FilesDisplay1.FileAcquireMode = Enums.FileAcquireMode.Multiple;
            }
            AsyncFileUpload1.Style.Add("visibility", " hidden");
        }

        private void LoadFileResource()
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var files = new List<FileResourceEventArgs>();
                var fileR = helper.GetFileResource(FileResourceId);
                if (fileR!=null)
                {
                    txtName.Text = fileR.Name;
                    CKEditor1.Text = fileR.Description;
                    chkDisplayDescription.Checked = fileR.ShowDescriptionOnCoursePage;
                    chkShowSize.Checked = fileR.ShowSize;
                    chkShowType.Checked = fileR.ShowType;
                    chkShowUploadModifiedDate.Checked = fileR.ShowUploadModifiedDate;
                    ddlDisplay.SelectedIndex = fileR.Display;
                    var i = 1;
                    foreach (var f in fileR.FileResourceFiles)
                    {
                        files.Add(new FileResourceEventArgs()
                        {
                            Id = f.SubFileId,
                            Visible = true,
                            FileType = f.SubFile.FileType,
                            IconPath = f.SubFile.IconPath,
                            FilePath = f.SubFile.FileDirectory+"/"+f.SubFile.FileName,
                            FileDisplayName = f.SubFile.DisplayName,
                            FileSizeInBytes = f.SubFile.FileSizeInBytes
                            ,LocalId = i.ToString()
                        });
                        i++;
                    }
                    FilesDisplay1.SetInitialValues(files);
                    RestrictionUC.SetActivityResource(false, ((int)Enums.Resources.File) + 1, fileR.Id);
                }
            }
        }


        #region Properties

        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set
            {
                hidSubjectId.Value = value.ToString();
                RestrictionUC.SubjectId = value;
            }
        }

        public string PageKey
        {
            get { return hidPageKey.Value; }
        }

        public int FileResourceId
        {
            get { return Convert.ToInt32(hidFileId.Value); }
            set { hidFileId.Value = value.ToString(); }
        }



        #endregion
       

       

        //keep it for now
        protected void file_upload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                var file = new Academic.DbEntities.ActivityAndResource.FileResource()
                {
                    Id= FileResourceId,
                    Name = txtName.Text
                    ,
                    Description = CKEditor1.Text
                    ,
                    Display = (byte)ddlDisplay.SelectedIndex
                    ,
                    ShowSize = chkShowSize.Checked
                    ,
                    ShowType = chkShowType.Checked
                    ,
                    ShowUploadModifiedDate = chkShowUploadModifiedDate.Checked
                    ,
                    ShowDescriptionOnCoursePage = chkDisplayDescription.Checked
                    ,
                };

                //files
                var list = new List<Academic.DbEntities.Subjects.SubjectFile>();
                var files = FilesDisplay1.GetFiles();
                if (files != null)
                {
                    foreach (var f in files)
                    {
                        var fileName = Path.GetFileName(f.FilePath);
                        var fi = new Academic.DbEntities.Subjects.SubjectFile()
                        {
                            Id=f.Id,
                            CreatedBy = user.Id
                            ,
                            CreatedDate = DateTime.Now
                            ,
                            DisplayName = f.FileDisplayName //Path.GetFileName(imageFile.FileName)
                            ,
                            FileDirectory = DbHelper.StaticValues.CourseFilesLocation //StaticValue.UserImageDirectory
                            ,
                            FileName = fileName
                                //Guid.NewGuid().ToString() + GetExtension(imageFile.FileName, imageFile.ContentType)
                            ,
                            FileSizeInBytes = f.FileSizeInBytes //imageFile.ContentLength
                            ,
                            FileType = f.FileType //imageFile.ContentType
                            ,
                            IconPath = f.IconPath
                            ,
                            SubjectId = SubjectId
                            ,Void = !f.Visible
                        };
                        list.Add(fi);
                    }

                }
                var restriction = RestrictionUC.GetRestriction();

                if (!RestrictionUC.IsValid)
                    return;
                using (var helper = new DbHelper.ActAndRes())
                {
                    var saved = helper.AddOrUpdateFileResource(file, list, SectionId, restriction);
                    if (saved != null)
                    {
                        Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
                    }
                }
            }

        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
        }
    }
}