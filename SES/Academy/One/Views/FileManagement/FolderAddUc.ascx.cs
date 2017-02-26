using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.FileManagement
{
    public partial class FolderAddUc : System.Web.UI.UserControl
    {

        public event EventHandler<MessageEventArgs> SaveEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var text = txtNewFolder.Text;
                if (!string.IsNullOrEmpty(text))
                {
                    btnOkay_OnClick(btnOkay, new EventArgs());
                    txtNewFolder.Text = "";
                }
            }
        }

        public bool IsServerFile
        {
            get { return Convert.ToBoolean(hidIsServerFile.Value); }
            set { hidIsServerFile.Value = value.ToString(); }
        }

        protected void btnOkay_OnClick(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                if (string.IsNullOrEmpty(txtNewFolder.Text))
                    return;
                using (var helper = new DbHelper.WorkingWithFiles())
                {
                    var folder = new Academic.DbEntities.UserFile()
                    {
                        Id = FolderId
                        ,
                        DisplayName = txtNewFolder.Text
                        ,
                        FileType = "Folder"
                        ,
                        CreatedBy = user.Id
                        ,
                        CreatedDate = DateTime.Now
                        ,
                        IsFolder = true
                        ,
                        FileSizeInBytes = 0
                        ,
                        IsServerFile = IsServerFile
                    };
                    if (ParentFolderId > 0)
                        folder.FolderId = ParentFolderId;

                    var saved = helper.AddOrUpdateFolder(folder);
                    txtNewFolder.Text = "";
                    if (SaveEvent != null)
                    {
                        if (saved != null)
                            SaveEvent(this, new MessageEventArgs() { SaveSuccess = true, SavedId = saved.Id, SavedName = saved.DisplayName });
                        else
                            SaveEvent(this, new MessageEventArgs() { SaveSuccess = false });
                    }
                }
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            if (SaveEvent != null)
                SaveEvent(this, new MessageEventArgs() { SaveSuccess = false });
        }

        public int ParentFolderId
        {
            get { return Convert.ToInt32(hidParentFolderId.Value); }
            set { hidParentFolderId.Value = value.ToString(); }
        }

        public int FolderId
        {
            get { return Convert.ToInt32(hidFolderId.Value); }
            set { hidFolderId.Value = value.ToString(); }
        }


        public string FolderName
        {
            get { return txtNewFolder.Text; }
            set { txtNewFolder.Text = value; }
        }
    }
}