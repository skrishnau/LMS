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
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                try
                {
                    if (subId != null && secId != null)
                    {
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = Convert.ToInt32(subId);
                    }
                }
                catch
                {
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }

                var guid = Guid.NewGuid();
                hidPageKey.Value = guid.ToString();
                FilesDisplay1.PageKey = guid.ToString();
            }
            AsyncFileUpload1.Style.Add("visibility", " hidden");
        }


        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }

        public string PageKey
        {
            get { return hidPageKey.Value; }
        }

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
                        };
                        list.Add(fi);
                    }
                    
                }


                using (var helper = new DbHelper.ActAndRes())
                {
                    var saved = helper.AddOrUpdateFileResource(file,list,SectionId);
                    if (saved != null)
                    {
                        Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId="+SubjectId+"&edit=1#section_"+SectionId);
                    }
                }
            }

        }

    }
}