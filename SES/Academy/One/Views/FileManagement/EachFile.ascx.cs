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


        public void SetData(string iconImageUrl, string displayName,string fileName, int fileId, string localId, string fileUrl,
            string fullFileNameForToolTip, bool isFolder, bool enableFileImageClick, bool isConstantAndNotEditable, string fileType)
        {
            IsFolder = isFolder;
            IsConstantAndNotEditable = isConstantAndNotEditable;

            hidFileId.Value = fileId.ToString();
            hidLocalId.Value = localId;
            hidFileUrl.Value = fileUrl;

            if (isFolder)
            {
                //css
                pnlTooltipBody.CssClass = "tooltip-folderlisting";
                pnlToolTipText.CssClass = "tooltiptext-folderlisting";

                lnkDownload.Visible = false;
                lnkFolder.Visible = true;

                imgFolder.ImageUrl = iconImageUrl;

                //here
                lblDisplayNameFolder.Text = displayName;
                lblDisplayNameFolder.ToolTip = fullFileNameForToolTip;

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
                //css
                pnlTooltipBody.CssClass = "tooltip-filelisting";
                pnlToolTipText.CssClass = "tooltiptext-filelisting";

                hidFileType.Value = fileType;
                hidFileName.Value = fileName;

                if (fileType.ToLower().Contains("image"))
                {
                    imgPictureIndication.Visible = true;
                    spanPictureIndication.Visible = true;

                }
                //here
                lnkFile.Visible = true;
                imgFile.ImageUrl = iconImageUrl;
                lblDisplayName.Text = displayName;

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
                        Id = FileId,
                        Name = lblDisplayName.ToolTip.Split(new char[] { '.' })[0],
                        Check = IsFolder
                    });
                }
                catch
                {
                    RenameClicked(this, new IdAndNameEventArgs()
                    {
                        Id = FileId,
                        Name = lblDisplayName.ToolTip,
                        Check = IsFolder,
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
                    Name = lnkFile.Visible ? lblDisplayName.ToolTip : lblDisplayNameFolder.ToolTip,
                    Id = FileId,
                    RefIdString = (IsFolder ? "folder" : "file"),

                });
            }
        }

        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("FileDownload.aspx?fId="+hidFileId.Value);

            //if (hidFileType.Value != "")
            //{
            //    Response.ContentType = hidFileType.Value; //"application/octet-stream";
            //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + hidFileName.Value);
            //    //, "attachment; filename=logfile.txt");
            //    Response.TransmitFile(Server.MapPath(hidFileUrl.Value)); //"~/logfile.txt"));
            //    Response.End();
            //}
        }
    }
}