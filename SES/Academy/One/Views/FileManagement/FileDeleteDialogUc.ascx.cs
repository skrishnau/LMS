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
    public partial class FileDeleteDialogUc : System.Web.UI.UserControl
    {
        #region Events Declaration

        public event EventHandler<IdAndNameEventArgs> ItemClick;

        public event EventHandler<IdAndNameEventArgs> SaveClick;
        public event EventHandler<IdAndNameEventArgs> OkClick;
        public event EventHandler<EventArgs> CancelClick;

        public event EventHandler<MessageEventArgs> FolderSavedEvent;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //FolderAddUc1.SaveEvent += FolderAddUc1_SaveEvent;
            //if (!IsPostBack)
            //{
            //    var lst = new List<IdAndName>()
            //    {
            //        new IdAndName() {Id = 0, Name = "Activity completion"},
            //        new IdAndName() {Id = 1, Name = "Date"},
            //        new IdAndName() {Id = 2, Name = "Grade"},
            //        new IdAndName() {Id = 3, Name = "Group"},
            //        new IdAndName() {Id = 4, Name = "User profile"},
            //        new IdAndName() {Id = 5, Name = "Restriction set"},
            //    };
            //    dataList.DataSource = lst;
            //    dataList.DataBind();
            //}
        }

        void FolderAddUc1_SaveEvent(object sender, Academic.DbHelper.MessageEventArgs e)
        {
            if (FolderSavedEvent != null)
            {
                FolderSavedEvent(sender, e);
            }
        }

        #region Dimensions

        public int Height_Y
        {
            set { dialogdiv.Style.Add("height", value.ToString() + "px"); }
            get
            {
                var height = dialogdiv.Style["height"].Replace("px", "");
                var he = 0;
                var success = Int32.TryParse(height, out he);
                return he;
            }
        }
        public int Width_X
        {
            set { dialogdiv.Style.Add("width", value.ToString() + "px"); }
            get
            {
                var width = dialogdiv.Style["width"].Replace("px", "");
                var we = 0;
                var success = Int32.TryParse(width, out we);
                return we;
            }
        }

        #endregion

        #region Public Functions

        public void AddControl(UserControl control)
        {
            pnlItemsControl.Controls.Add(control);
        }

        public void ClearControls()
        {
            pnlItemsControl.Controls.Clear();
        }

        public int ParentFolderId
        {
            get { return Convert.ToInt32(hidParentFolderId.Value); }
            set { hidParentFolderId.Value = value.ToString(); }
        }

        public int FileId
        {
            get { return Convert.ToInt32(hidFileId.Value); }
            set { hidFileId.Value = value.ToString(); }
        }

        public string FileName
        {
            get { return lblFileName.Text; }
            set { lblFileName.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">title of the dialog</param>
        /// <param name="items">datasource to display</param>
        /// <param name="itemClickMode"></param>
        /// <param name="buttons">"save", "ok", "cancel"</param>
        public void SetValues(string title)//, List<IdAndName> items, string itemClickMode, params string[] buttons
        {
            lblHeading.Text = title;
            //hidItemClickMode.Value = itemClickMode;

            //dataList.DataSource = items;
            //dataList.DataBind();

            //if (buttons != null)
            //    if (buttons.Any())
            //    {
            //        foreach (var b in buttons)
            //        {
            //            switch (b.ToLower())
            //            {
            //                case "save":
            //                    btnDialogSave.Visible = true;
            //                    break;
            //                case "ok":
            //                    btnDialogOk.Visible = true;
            //                    break;
            //                case "cancel":
            //                    btnDialogCancel.Visible = true;
            //                    break;
            //            }

            //        }
            //    }
            //    else buttonsDiv.Visible = false;
            //else buttonsDiv.Visible = false;
        }

        public void OpenDialog()
        {
            dialogdiv.Visible = true;
        }

        public bool IsOpen()
        {
            return dialogdiv.Visible;
        }

        public void CloseDialog()
        {
            dialogdiv.Visible = false;
        }
        public string GetClickMode()
        {
            return hidItemClickMode.Value;
        }
        #endregion

        #region Events Callback

        protected void btnDialogClose_Click(object sender, EventArgs e)
        {
            dialogdiv.Visible = false;
        }

        protected void dataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            var arg = e.CommandArgument;
            if (arg != null)
            {
                if (ItemClick != null)
                {
                    var split = arg.ToString().Split(new char[] { ',' });
                    if (split.Count() == 2)
                    {

                        ItemClick(this, new IdAndNameEventArgs()
                        {
                            Id = Convert.ToInt32(split[0])
                            ,
                            Name = split[1]
                            ,
                            //RefIdString = RestrictionId
                        });
                    }

                }
            }
        }

        protected void btnDialogOk_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.WorkingWithFiles())
            {
                var saved = helper.DeleteFile(FileId);
                dialogdiv.Visible = false;
                if (OkClick != null)
                {
                    OkClick(sender, new IdAndNameEventArgs());
                }
            }

        }

        protected void btnDialogCancel_Click(object sender, EventArgs e)
        {
            dialogdiv.Visible = false;
            if (CancelClick != null)
            {
                CancelClick(sender, e);
            }
        }


        #endregion

    }
}