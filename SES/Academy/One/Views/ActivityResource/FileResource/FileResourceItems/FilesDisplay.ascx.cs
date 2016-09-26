using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                //IdandNameEventArgs--> Icon path is the path of the image... Name is the file path
                Session["FilesList" + PageKey] = new List<IdAndNameEventArgs>();
                //Session["LatestFile"]=new IdAndNameEventArgs();
                FilePickerDialog1.SetValues("File picker", null, "", "");
            }
            else
            {
                var files = Session["FilesList" + PageKey] as List<IdAndNameEventArgs>;
                if (files != null)
                {
                    foreach (var iname in files)
                    {
                        var image = new ImageButton()
                        {
                            ImageUrl = iname.IconPath
                            ,
                            CausesValidation = false,
                            Height = 50,
                            Width = 50,
                            ImageAlign = ImageAlign.Left
                        };
                        pnlFiles.Controls.Add(image);
                    }
                }
            }
            //FilePickerDialog1.FileChoosen += FilePickerDialog1_FileChoosen;
            FilePickerDialog1.UploadClicked += FilePickerDialog1_UploadClicked;
        }

        void FilePickerDialog1_UploadClicked(object sender, IdAndNameEventArgs e)
        {
            var image = new ImageButton()
            {
                ImageUrl = e.IconPath,
                CausesValidation = false,
                Height = 50,
                Width = 50,
                ImageAlign = ImageAlign.Left
            };

            pnlFiles.Controls.Add(image);

            var files = Session["FilesList" + PageKey] as List<IdAndNameEventArgs>;
            if (files != null)
            {
                files.Add(e);
            }
            FilePickerDialog1.CloseDialog();
        }

        public void FilePickerDialog1_FileChoosen(object sender, IdAndNameEventArgs e)
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
                hidPageKey.Value = value;
                FilePickerDialog1.PageKey = value;
            }
        }
    }
}