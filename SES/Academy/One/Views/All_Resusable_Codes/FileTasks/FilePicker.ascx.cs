using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;
using System.IO;
using Academic.DbHelper;
using One.Values;

namespace One.Views.All_Resusable_Codes.FileTasks
{
    public partial class FilePicker : System.Web.UI.UserControl
    {
        //public event EventHandler<FileResourceEventArgs> FileChoosen;
        public event EventHandler<FileResourceEventArgs> UploadClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lnkUploadFile.BackColor = Color.LightBlue;
            }
        }
        public string PageKey
        {
            get { return hidPageKey.Value; }
            set
            {
                hidPageKey.Value = value;
                //FileUploadUc.PageKey = value;
            }
        }

        protected void options_Click(object sender, EventArgs e)
        {
            var send = sender as LinkButton;
            if (send != null)
            {
                switch (send.ID)
                {
                    case "lnkServerFiles":

                        break;
                    case "lnkUploadFile":
                        //FileUploadUc.Visible = true;
                        break;
                    case "lnkPrivateFiles":
                        break;
                }
            }
        }

        protected void file_upload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (!file_upload.HasFile)
                return;

            var fileName = Path.GetFileName(e.FileName);
            if (fileName == null) return;

            //var extension = Path.GetExtension(fileName);
            //using (var helper = new Academic.DbHelper.DbHelper.WorkingWithFiles())
            {
                var extension = Path.GetExtension(fileName);
                var s = Guid.NewGuid().ToString() + extension;
                count = 0;
                string guidName = GetNewFileName( s);
                count = 0;
                if (guidName == "")
                {
                    file_upload.BackColor = Color.Red;
                    //throw ;
                    return;

                }
                var fileUploadPath = Path.Combine(Server.MapPath(DbHelper.StaticValues.CourseFilesLocation), guidName);
                file_upload.SaveAs(fileUploadPath);

                //copied from another file so keep it.
                //var url = "~/Content/Images/CourseFileResource/" + fileName;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "fileName",
                //      "top.$get(\"" + hdnFileFolder.ClientID + "\").value = '" + url + "';", true);

                var iconPath = GetIconForFile(guidName);
                var valuetoSave = new FileResourceEventArgs()
                                    {
                                        FileDisplayName = fileName,
                                        FilePath = DbHelper.StaticValues.CourseFilesLocation
                                            + guidName
                                        ,
                                        IconPath = iconPath
                                        ,FileSizeInBytes = file_upload.PostedFile.ContentLength
                                        ,FileType = file_upload.PostedFile.ContentType
                                    };
                Session["LatestFile" + PageKey] = valuetoSave;
            }
        }

        private string GetNewFileName( string fileName)
        {
            if (count < DbHelper.StaticValues.MaximimNumberOfTimesToCheckForSameFileName)
            {
                count++;
                if (File.Exists(Path.Combine(Server.MapPath(DbHelper.StaticValues.CourseFilesLocation), fileName)))
                {
                    var extension = Path.GetExtension(fileName);
                    var s = Guid.NewGuid().ToString() + extension;
                    return GetNewFileName( fileName);
                }
                else
                {

                    return fileName;
                }
            }
            return "";
        }

        private int count = 0;
        /*
        /// <summary>
        /// Gets New File Name. Before calling this initialize "count" to 0;
        /// </summary>
        /// <param name="fhelper">to redeuce initializaiton of dbhelper every time.</param>
        /// <param name="fileName">filename along with extension e.g. "myfile.png"</param>
        /// <returns></returns>
        private string GetNewFileName(Academic.DbHelper.DbHelper.WorkingWithFiles fhelper, string fileName)
        {
            if (count < StaticValues.MaximimNumberOfTimesToCheckForSameFileName)
            {
                count++;
                if (fhelper.DoesFileExists(fileName))
                {
                    var extension = Path.GetExtension(fileName);
                    var s = Guid.NewGuid().ToString() + extension;
                    return GetNewFileName(fhelper, s);
                }
                else
                {

                    return fileName;
                }
            }
            return "";
        }*/

        private string GetIconForFile(string path)
        {
            var iconLocation = DbHelper.StaticValues.IconsOfFilesLocation;//file_icon.png
            var fileLocation = DbHelper.StaticValues.CourseFilesLocation;
            var extension = Path.GetExtension(path);
            var fileName = Path.GetFileName(path);
            if (extension != null)
            {
                extension = extension.TrimStart(new char[] { '.' });
                if (DbHelper.StaticValues.TextFormat == extension)
                {
                    return iconLocation + "text_file_icon.png";
                }
                if (DbHelper.StaticValues.PdfFormat == extension)
                {
                    return iconLocation + "pdf_icon.ico";
                }
                if (DbHelper.StaticValues.ImageFormatList.Contains(extension))
                {
                    return fileLocation + fileName;
                }
                if (DbHelper.StaticValues.VidoFormatList.Contains(extension))
                {
                    return iconLocation + "video_icon.png";
                }
                if (DbHelper.StaticValues.WordFormatList.Contains(extension))
                {
                    return iconLocation + "word_2013_icon.png";
                }
                if (DbHelper.StaticValues.ExcelFormatList.Contains(extension))
                {
                    return iconLocation + "excell_icon.png";
                }
                if (DbHelper.StaticValues.PowerPointFormatList.Contains(extension))
                {
                    return iconLocation + "ppt_icon.png";
                }
            }
            return iconLocation + "file_icon.png";
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var latest = Session["LatestFile" + PageKey] as FileResourceEventArgs;
            if (latest != null)
            {
                if (UploadClicked != null)
                {
                    UploadClicked(this, latest);
                }
            }
            Session["LatestFile" + PageKey] = null;
        }



    }
}