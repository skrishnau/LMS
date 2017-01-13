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
            lblMessage.Visible = false;
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

        public int LocalId
        {
            get { return Convert.ToInt32(hidLocalId.Value); }
            set { hidLocalId.Value = value.ToString(); }
        }

        protected void file_upload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            Upload(e);

        }

        private void Upload(AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (string.IsNullOrEmpty(FileSaveDirectory))
                lblMessage.Visible = true;
            if (!file_upload.HasFile)
                return;
            //if(FileAcquireMode== DbHelper.StaticValues.FileAcquireMode.Single)

            var fileName = Path.GetFileName(e.FileName);
            if (fileName == null) return;

            //var extension = Path.GetExtension(fileName);
            //using (var helper = new Academic.DbHelper.DbHelper.WorkingWithFiles())
            {
                var extension = Path.GetExtension(fileName);
                var s = Guid.NewGuid().ToString() + extension;
                count = 0;
                string guidName = GetNewFileName(s);
                count = 0;
                if (guidName == "")
                {
                    file_upload.BackColor = Color.Red;
                    //throw ;
                    return;

                }
                var fileUploadPath = Path.Combine(Server.MapPath(FileSaveDirectory), guidName);
                file_upload.SaveAs(fileUploadPath);

                //copied from another file so keep it.
                //var url = "~/Content/Images/CourseFileResource/" + fileName;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "fileName",
                //      "top.$get(\"" + hdnFileFolder.ClientID + "\").value = '" + url + "';", true);
                var iconPath = GetIconForFile(guidName);
                var wrappedName = fileName;

                if (fileName.Length > 7)
                {
                    wrappedName = fileName.Substring(0, 7)+"...";
                }

                //for (var i=0;i<fileName.Length;i++)// f in fileName)
                //{
                //    if (i%4 == 0 && i != 0)
                //    {
                //        wrappedName += "<wbr/>" + fileName[i];
                //    }
                //    else wrappedName += fileName[i];
                //}
                var valuetoSave = new FileResourceEventArgs()
                {
                    FileDisplayName = wrappedName,
                    FilePath = FileSaveDirectory + guidName,
                    IconPath = iconPath
                    ,
                    FileSizeInBytes = file_upload.PostedFile.ContentLength
                    ,
                    FileType = file_upload.PostedFile.ContentType
                    ,Visible = true
                };
                var files = Session["FilesList" + PageKey] as List<FileResourceEventArgs>;
                var localId = (files==null?0:files.Count)+1;
                LocalId = localId;
                valuetoSave.LocalId = localId.ToString();
                //LocalId++;
                //if (FileAcquireMode == Enums.FileAcquireMode.Single)
                //{
                //    //here delete the previous uploaded file                    
                //    DeletePreviousUploadedFile();
                //    Session["JustUploaded" + PageKey] = valuetoSave;
                //}

                Session["LatestFile" + PageKey] = valuetoSave;
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadClick();
            //if (UploadClicked != null)
            //{
            //    UploadClicked(this, null);
            //}
        }

        private void UploadClick()
        {
            var latest = Session["LatestFile" + PageKey] as FileResourceEventArgs;
            if (latest != null)
            {
                if (UploadClicked != null)
                {
                    if (FileAcquireMode == Enums.FileAcquireMode.Single)
                    {
                        //here delete the previous uploaded file                    
                        DeletePreviousUploadedFile();
                        Session["JustUploaded" + PageKey] = latest;

                    }

                    UploadClicked(this, latest);
                    //if (UploadClicked != null)
                    //{
                    //    UploadClicked(this, null);
                    //}
                }
            }
            else if (UploadClicked != null)
            {
                UploadClicked(this, null);
            }
            Session["LatestFile" + PageKey] = null;
        }

        private void DeletePreviousUploadedFile()
        {
            var latest = Session["JustUploaded" + PageKey] as FileResourceEventArgs;
            if (latest != null)
            {
                System.IO.File.Delete(Server.MapPath(latest.FilePath));
            }
        }

        private string GetNewFileName(string fileName)
        {
            if (count < DbHelper.StaticValues.MaximimNumberOfTimesToCheckForSameFileName)
            {
                count++;
                if (File.Exists(Path.Combine(Server.MapPath(DbHelper.StaticValues.CourseFilesLocation), fileName)))
                {
                    var extension = Path.GetExtension(fileName);
                    var s = Guid.NewGuid().ToString() + extension;
                    return GetNewFileName(fileName);
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
            var fileLocation = FileSaveDirectory;
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
                    return iconLocation + "pdf_icon.png";
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
                    return iconLocation + "word_icon.png";
                }
                if (DbHelper.StaticValues.ExcelFormatList.Contains(extension))
                {
                    return iconLocation + "excel_icon.png";
                }
                if (DbHelper.StaticValues.PowerPointFormatList.Contains(extension))
                {
                    return iconLocation + "ppt_icon.png";
                }
            }
            return iconLocation + "file_icon.png";
        }






        public string FileSaveDirectory
        {
            get { return hidFileSaveDirectory.Value; }
            set
            {
                //fi.FileSaveDirectory = value;
                hidFileSaveDirectory.Value = value;
            }
        }

        public Enums.FileAcquireMode FileAcquireMode
        {
            get { return Enums.ParseEnum<Enums.FileAcquireMode>(hidFileAcquireMode.Value); }
            set { hidFileAcquireMode.Value = value.ToString(); }
        }


    }
}