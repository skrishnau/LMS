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
            string fullFileNameForToolTip, bool isFolder, bool enableFileImageClick, bool isConstantAndNotEditable, string fileType)
        {
            IsFolder = isFolder;
            IsConstantAndNotEditable = isConstantAndNotEditable;

            if (isFolder)
            {
                lnkDownload.Visible = false;
                lnkFolder.Visible = true;

                imgFolder.ImageUrl = iconImageUrl;
                lblDisplayNameFolder.Text = displayName;
                lblDisplayNameFolder.ToolTip = fullFileNameForToolTip;
                hidFileId.Value = fileId.ToString();
                hidLocalId.Value = localId;
                hidFileUrl.Value = fileUrl;
                lnkFolder.Enabled = enableFileImageClick;

                lblFileNotEditableDisplay.Visible = isConstantAndNotEditable;
                if (isConstantAndNotEditable)
                {
                    lnkDelete.Visible = false;
                    lnkRename.Visible = false;
                    lnkCopy.Visible = false;
                    lnkMove.Visible = false;
                }
            }
            else
            {
                if (fileType.ToLower().Contains("image"))
                {
                    imgPictureIndication.Visible = true;
                    spanPictureIndication.Visible = true;
                }
                lnkFile.Visible = true;
                imgFile.ImageUrl = iconImageUrl;
                lblDisplayName.Text = displayName;
                hidFileId.Value = fileId.ToString();
                hidLocalId.Value = localId;
                hidFileUrl.Value = fileUrl;
                lblDisplayName.ToolTip = fullFileNameForToolTip;
                lnkFile.Enabled = enableFileImageClick;

                lblFileNotEditableDisplay.Visible = isConstantAndNotEditable;
                if (isConstantAndNotEditable)
                {
                    lnkDelete.Visible = false;
                    lnkRename.Visible = false;
                    lnkCopy.Visible = false;
                    lnkMove.Visible = false;
                }
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
        public bool IsConstantAndNotEditable
        {
            get { return Convert.ToBoolean(hidIsConstantAndNotEditable.Value); }
            set { hidIsConstantAndNotEditable.Value = value.ToString(); }
        }

        protected void lnkFile_OnClick(object sender, EventArgs e)
        {
            if (FileClicked != null)
            {
                FileClicked(this, new IdAndNameEventArgs()
                {
                    Id = FileId,
                    Name = lblDisplayName.ToolTip,
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
                    Name = lnkFile.Visible?lblDisplayName.ToolTip:lblDisplayNameFolder.ToolTip
                    ,
                    Id = FileId
                    ,
                    RefIdString = (IsFolder ? "folder" : "file")
                });
            }
        }
    }
}