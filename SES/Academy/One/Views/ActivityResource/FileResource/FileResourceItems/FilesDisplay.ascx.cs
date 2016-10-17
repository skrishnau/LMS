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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FileResourceEventArgs--> Icon path is the path of the image... FileName is the file path
                //Session["LatestFile"]=new FileResourceEventArgs();
                FilePickerDialog1.SetValues("File picker", null, "", "");

            }
            else
            {
                var files = Session["FilesList" + PageKey] as List<FileResourceEventArgs>;
                if (files != null)
                {
                    foreach (var iname in files)
                    {
                        //if (iname.Visible)
                        {
                            var image = new ImageButton()
                            {
                                ImageUrl = iname.IconPath
                                ,
                                CausesValidation = false,
                                Height = 50,
                                Width = 50,
                                ImageAlign = ImageAlign.Left
                                ,
                                Visible = iname.Visible
                            };
                            pnlFiles.Controls.Add(image);
                        }

                    }
                }
            }
            //FilePickerDialog1.FileChoosen += FilePickerDialog1_FileChoosen;
            FilePickerDialog1.UploadClicked += FilePickerDialog1_UploadClicked;
        }

        void FilePickerDialog1_UploadClicked(object sender, FileResourceEventArgs e)
        {
            var files = Session["FilesList" + PageKey] as List<FileResourceEventArgs>;

            if (files != null)
            {
                if (FileAcquireMode == Enums.FileAcquireMode.Single)
                {
                    if (files.Count >= 1)
                        files[files.Count - 1].Visible = false;
                }
                files.Add(e);
                var image = new ImageButton()
                {
                    ImageUrl = e.IconPath,
                    CausesValidation = false,
                    Height = 50,
                    Width = 50,
                    ImageAlign = ImageAlign.Left
                    ,
                    Visible = e.Visible
                };
                pnlFiles.Controls.Clear();
                pnlFiles.Controls.Add(image);
            }
            FilePickerDialog1.CloseDialog();
        }

        public void FilePickerDialog1_FileChoosen(object sender, FileResourceEventArgs e)
        {

        }

        protected void lnkAddFile_Click(object sender, EventArgs e)
        {
            FilePickerDialog1.OpenDialog();
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
                FilePickerDialog1.FileAcquireMode = value;
                hidFileAcquireMode.Value = value.ToString();
                if (value == Enums.FileAcquireMode.Single)
                    MultiView1.ActiveViewIndex = 1;
            }
        }

        public List<FileResourceEventArgs> GetFiles()
        {
            var list = new List<Academic.DbEntities.UserFile>();
            var files = Session["FilesList" + PageKey] as List<FileResourceEventArgs>;
            if (FileAcquireMode == Enums.FileAcquireMode.Single && files != null)
            {
                if (files.Count >= 1)
                {
                    files[files.Count - 1].Id = files[0].Id;
                    return new List<FileResourceEventArgs>() {files[files.Count - 1]};
                }
            }
            return files;

            //if (files != null)
            //{
            //    foreach (var f in files)
            //    {

            //        var file = new Academic.DbEntities.UserFile()
            //        {
            //            //CreatedBy = 
            //            CreatedDate = DateTime.Now
            //        };

            //        var image = new ImageButton()
            //        {
            //            ImageUrl = f.IconPath
            //            ,
            //            CausesValidation = false,
            //            Height = 50,
            //            Width = 50,
            //            ImageAlign = ImageAlign.Left
            //        };
            //        pnlFiles.Controls.Add(image);
            //    }
            //}
        }

        public void SetInitialValues(List<FileResourceEventArgs> list)
        {
            Session["FilesList" + PageKey] = list;
            foreach (var iname in list)
            {
                //if (iname.Visible)
                {
                    var image = new ImageButton()
                    {
                        ImageUrl = iname.IconPath
                        ,
                        CausesValidation = false,
                        Height = 50,
                        Width = 50,
                        ImageAlign = ImageAlign.Left
                        ,
                        Visible = iname.Visible
                    };
                    pnlFiles.Controls.Add(image);
                }

            }
        }
    }
}