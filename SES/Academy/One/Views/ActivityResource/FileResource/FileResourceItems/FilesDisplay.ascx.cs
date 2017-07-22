using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.ActivityResource.FileResource.FileResourceItems
{
    /// <summary>
    /// Need to set PageKey property to new Guid. 
    /// </summary>
    public partial class FilesDisplay : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> FileUploaded;

        protected void Page_Load(object sender, EventArgs e)
        {

            lblFileNumberError.Visible = false;

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(PageKey))
                {
                    var guid = Guid.NewGuid().ToString();
                    hidPageKey.Value = guid;
                    PageKey = guid;
                    lblNoOfFiles.Text = "Files : 0" + " / " + hidNumberOfFilesToUpload.Value;

                }
                //FileResourceEventArgs--> Icon path is the path of the image... FileName is the file path
                FilePickerDialog1.SetValues("File picker", null, "", "");
            }
            else
            {
                var files = Session["FilesList" + PageKey] as List<FileResourceEventArgs>;
                if (files != null)
                {
                    PopuateImage(files);
                }
            }
            //FilePickerDialog1.FileChoosen += FilePickerDialog1_FileChoosen;
            FilePickerDialog1.UploadClicked += FilePickerDialog1_UploadClicked;
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

        void FilePickerDialog1_UploadClicked(object sender, FileResourceEventArgs e)
        {
            var files = Session["FilesList" + PageKey] as List<FileResourceEventArgs>;

            if (files != null && e != null)
            {
                var enabled = Enabled;
                if (FileAcquireMode == Enums.FileAcquireMode.Basic)
                {
                    //if (files.Count >= 1)
                    lblFileName.Text = e.FileDisplayName;//files[files.Count - 1].FileDisplayName;
                    if (this.FileUploaded != null)
                    {
                        FileUploaded(this, new IdAndNameEventArgs()
                        {
                            Name = e.FileDisplayName,
                            RefIdString = e.FilePath
                        });
                    }
                    files.Add(e);
                    FilePickerDialog1.CloseDialog();
                }
                else
                {
                    if (FileAcquireMode == Enums.FileAcquireMode.Single)
                    {
                        if (files.Count >= 1)
                            files[files.Count - 1].Visible = false;
                    }
                    var file = (EachFile)
                        Page.LoadControl("~/Views/ActivityResource/FileResource/FileResourceItems/EachFile.ascx");
                    file.Visible = e.Visible;
                    file.ID = "file_" + e.LocalId;
                    file.SetData(e.IconPath, e.FileDisplayName, 0, e.LocalId, enabled, e.FilePath);
                    file.RemoveClicked += file_RemoveClicked;

                    pnlFiles.Controls.Add(file);
                    FilePickerDialog1.CloseDialog();

                    //problem is here
                    files.Add(e);
                    lblNoOfFiles.Text = "Files : " + files.Count(x => x.Visible) + " / " + hidNumberOfFilesToUpload.Value;

                    if (FileAcquireMode == Enums.FileAcquireMode.Single)
                    {
                        if (this.FileUploaded != null)
                        {
                            FileUploaded(this, new IdAndNameEventArgs()
                            {
                                Name = e.FileDisplayName,
                                RefIdString = e.FilePath
                            });
                        }
                    }
                }
            }
            FilePickerDialog1.CloseDialog();

        }



        public void FilePickerDialog1_FileChoosen(object sender, FileResourceEventArgs e)
        {

        }

        protected void lnkAddFile_Click(object sender, EventArgs e)
        {
            var files = Session["FilesList" + PageKey] as List<FileResourceEventArgs>;
            if (files != null)
            {
                if (files.Count >= NumberOfFilesToUpload)
                {
                    lblFileNumberError.Visible = true;
                    lblFileNumberError.Text = "Only " + NumberOfFilesToUpload + " allowed.";
                    return;
                }
                else
                {
                    FilePickerDialog1.OpenDialog();
                }
            }
        }

        protected void lnkAddFolder_Click(object sender, EventArgs e)
        {

        }

        public string PageKey
        {
            get { return hidPageKey.Value; }
            set
            {
                Session["FilesList" + value] = new List<FileResourceEventArgs>();
                hidPageKey.Value = value;
                FilePickerDialog1.PageKey = value;
            }
        }

        public string FileSaveDirectory
        {
            get { return hidFileSaveDirectory.Value; }
            set
            {
                FilePickerDialog1.FileSaveDirectory = value;
                hidFileSaveDirectory.Value = value;
            }
        }
        public Enums.FileAcquireMode FileAcquireMode
        {
            get { return Enums.ParseEnum<Enums.FileAcquireMode>(hidFileAcquireMode.Value); }
            set
            {
                FilePickerDialog1.FileAcquireMode = (value == Enums.FileAcquireMode.Basic)
                                                        ? Enums.FileAcquireMode.Single : value;
                hidFileAcquireMode.Value = value.ToString();
                if (value == Enums.FileAcquireMode.Single)
                {
                    divMain.Style.Add("border", "1px solid grey");
                    MultiView1.ActiveViewIndex = 1;
                }
                else if (value == Enums.FileAcquireMode.Basic)
                {
                    mainMultiview.ActiveViewIndex = 1;
                }else if (value == Enums.FileAcquireMode.Multiple)
                {
                    divMain.Style.Add("border", "1px solid grey");                    
                }
            }
        }

        public string FileType
        {
            set { FilePickerDialog1.FileType = value; }
        }
        /// <summary>
        /// preceeded by '.'
        /// </summary>
        //public string FileExtension = "All";

        public string FileExtension
        {
            set { FilePickerDialog1.FileExtension = value; }
        }


        public List<FileResourceEventArgs> GetFiles()
        {
            //var list = new List<Academic.DbEntities.UserFile>();
            var files = Session["FilesList" + PageKey] as List<FileResourceEventArgs>;
            if ((FileAcquireMode == Enums.FileAcquireMode.Single || FileAcquireMode == Enums.FileAcquireMode.Basic)
                && files != null)
            {
                if (files.Count >= 1)
                {
                    files[files.Count - 1].Id = files[0].Id;
                    return new List<FileResourceEventArgs>() { files[files.Count - 1] };
                }
            }
            return files;
        }

        private void PopuateImage(List<FileResourceEventArgs> list)
        {
            lblNoOfFiles.Text = "Files : " + list.Count(x => x.Visible) +
                               " / " + hidNumberOfFilesToUpload.Value;
            var enabled = Enabled;
            foreach (var iname in list)
            {
                var file = (EachFile)
                   Page.LoadControl("~/Views/ActivityResource/FileResource/FileResourceItems/EachFile.ascx");
                file.Visible = iname.Visible;
                //file.Enabled = 
                file.ID = "file_" + iname.LocalId;

                var fileName = iname.FileDisplayName;
                var wrapedName = fileName;
                if (fileName.Length > 7)
                {
                    wrapedName = fileName.Substring(0, 7) + "...";
                }
                file.SetData(iname.IconPath, wrapedName, iname.Id, iname.LocalId, enabled, iname.FilePath);
                file.RemoveClicked += file_RemoveClicked;

                pnlFiles.Controls.Add(file);
                FilePickerDialog1.LocalId = Convert.ToInt32(iname.LocalId);
            }
        }
        void file_RemoveClicked(object sender, IdAndNameEventArgs e)
        {
            var file = sender as EachFile;
            if (file != null)
            {
                var files = Session["FilesList" + PageKey] as List<FileResourceEventArgs>;
                if (files != null)
                {
                    var lFound = files.Find(x => x.LocalId == e.RefIdString);
                    if (lFound != null)
                    {
                        file.Visible = false;
                        lFound.Visible = false;
                    }
                }
            }
        }
        public void SetInitialValues(List<FileResourceEventArgs> list)
        {
            var guid = Guid.NewGuid().ToString();
            hidPageKey.Value = guid;
            PageKey = guid;
            Session["FilesList" + PageKey] = list;
            PopuateImage(list);
        }

        public int NumberOfFilesToUpload
        {
            get { return Convert.ToInt32(hidNumberOfFilesToUpload.Value); }
            set { hidNumberOfFilesToUpload.Value = value.ToString(); }
        }

        public bool Enabled
        {
            set
            {
                //pnlFiles.Enabled = value;
                //lnkAddFile.Enabled = value;
                //lnkAddFolder.Enabled = value;

                lnkAddFile.Visible = value;
                lnkAddFolder.Visible = value;
                MultiView1.Visible = value;
            }
            get { return lnkAddFile.Visible; }
        }
    }
}