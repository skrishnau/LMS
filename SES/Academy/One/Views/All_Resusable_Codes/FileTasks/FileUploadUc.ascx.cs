using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.All_Resusable_Codes.FileTasks
{
    public partial class FileUploadUc : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> FileChoosen;

        protected void Page_Load(object sender, EventArgs e)
        {

            //Page.Form.Attributes.Add("enctype", "multipart/form-data");
            //// store the FileUpload object in Session. 
            //// "FileUpload1" is the ID of your FileUpload control
            //// This condition occurs for first time you upload a file
            //if (Session["FileUpload1"+PageKey] == null && FileUpload1.HasFile)
            //{
            //    Session["FileUpload1" + PageKey] = FileUpload1;
            //    Label1.Text = FileUpload1.FileName; // get the name 
            //}
            //// This condition will occur on next postbacks        
            //else if (Session["FileUpload1" + PageKey] != null && (!FileUpload1.HasFile))
            //{
            //    FileUpload1 = (FileUpload)Session["FileUpload1" + PageKey];
            //    Label1.Text = FileUpload1.FileName;
            //}
            ////  when Session will have File but user want to change the file 
            //// i.e. wants to upload a new file using same FileUpload control
            //// so update the session to have the newly uploaded file
            //else if (FileUpload1.HasFile)
            //{
            //    Session["FileUpload1" + PageKey] = FileUpload1;
            //    Label1.Text = FileUpload1.FileName;
            //}
        }

        public string PageKey
        {
            get { return hidPageKey.Value; }
            set { hidPageKey.Value = value; }
        }



        protected void file_upload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (!file_upload.HasFile)
                return;

            var fileName = Path.GetFileName(e.FileName);
            if (fileName != null)
            {
                var fileUploadPath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file_upload.SaveAs(fileUploadPath);

                var url = "~/Content/Images/CourseFileResource/" + fileName;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "fileName",
                      "top.$get(\"" + hdnFileFolder.ClientID + "\").value = '" + url + "';", true);


                if (FileChoosen != null)
                {
                    FileChoosen(this,
                        new IdAndNameEventArgs()
                        {
                            Name = "~/Content/Images/CourseFileResource/"
                                + fileName
                        });
                }
            }
            
        }
        //protected void btnAsyncUpload_Click(object sender, EventArgs e)
        //{
        //    bool hasfile = (FileUpload1.HasFile);

        //}

        //protected void btnUpload_Click(object sender, EventArgs e)
        //{
        //    bool hasfile = (FileUpload1.HasFile);

        //}

        //protected void btnUpload_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload1.HasFile)
        //    {
        //        //upload file and get the path
        //        FileUpload1.PostedFile.SaveAs("~/Content/Images/CourseFileResource/" + FileUpload1.FileName);
        //        if (FileChoosen != null)
        //        {
        //            FileChoosen(this,
        //                new IdAndNameEventArgs() { Name = "~/Content/Images/CourseFileResource/" + FileUpload1.FileName });
        //        }
        //    }
        //}
    }
}