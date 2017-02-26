using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.FileManagement
{
    public partial class EachFile : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> FileClicked;
        public event EventHandler<IdAndNameEventArgs> RenameClicked;
        public event EventHandler<IdAndNameEventArgs> DeleteClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void SetData(string iconImageUrl, string displayName, int fileId, string localId, string fileUrl,
            string fullFileNameForToolTip, bool isFolder, bool enableFileImageClick)
        {
            imgFile.ImageUrl = iconImageUrl;
            lblDisplayName.Text = displayName;
            hidFileId.Value = fileId.ToString();
            hidLocalId.Value = localId;
            hidFileUrl.Value = fileUrl;
            lblDisplayName.ToolTip = fullFileNameForToolTip;
            lnkFile.Enabled = enableFileImageClick;
            IsFolder = isFolder;
            if (isFolder)
            {
                lnkDownload.Visible = false;

            }
        }

        public int FileId
        {
            get { return Convert.ToInt32(hidFileId.Value); }
            set { hidFileId.Value = value.ToString(); }
        }

        public bool IsFolder
        {
            get { return Convert.ToBoolean(hidIsFolder.Value); }
            set { hidIsFolder.Value = value.ToString(); }
        }

        protected void lnkFile_OnClick(object sender, EventArgs e)
        {
            if (FileClicked != null)
            {
                FileClicked(this, new IdAndNameEventArgs()
                {
                    Id = FileId,
                    Name=lblDisplayName.ToolTip,
                    Check = IsFolder
                    //RefIdString = hidIsFolder.Value
                });
            }
        }

        protected void lnkRename_OnClick(object sender, EventArgs e)
        {
            //lblDisplayName.Visible = false;

            if (RenameClicked != null)
            {
                try
                {
                    RenameClicked(this, new IdAndNameEventArgs()
                    {
                        Id = FileId
                        ,
                        Name = lblDisplayName.ToolTip.Split(new char[] { '.' })[0]
                    });
                }
                catch
                {
                    RenameClicked(this, new IdAndNameEventArgs()
                    {
                        Id = FileId
                        ,
                        Name = lblDisplayName.ToolTip
                    });
                }
            }
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            if (DeleteClicked != null)
            {
                DeleteClicked(this, new IdAndNameEventArgs()
                {
                    Name = lblDisplayName.ToolTip
                    ,
                    Id = FileId
                    ,
                    RefIdString = (IsFolder ? "folder" : "file")
                });
            }
        }
    }
}