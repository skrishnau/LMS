using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.NoticeBoard
{
    public partial class CreateUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;
            //lblUpdateErrorMsg.Visible = false;
        }

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }

        public string GetUsersName(object user)
        {
            var u = user as Academic.DbEntities.User.Users;
            if (u != null)
            {
                return u.FullName;
            }
            return " ";
        }

        protected void lblEdit_OnClick(object sender, EventArgs e)
        {

        }

        protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = e.Item.ItemIndex;
            DataList1.DataBind();

        }

        protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
        {
            DataList1.EditItemIndex = -1;
            DataList1.SelectedIndex = -1;
            DataList1.DataBind();

        }

        protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
        {
            //var notice = e.Item.DataItem as Academic.DbEntities.Notices.Notice;
            HiddenField id = (HiddenField)e.Item.FindControl("hidId");
            TextBox heading = (TextBox)e.Item.FindControl("txtHeading");
            TextBox description = (TextBox)e.Item.FindControl("txtDescription");

            if (String.IsNullOrEmpty(heading.Text) || String.IsNullOrEmpty(id.Value))
            {
                return;
            }
            //if (notice != null)
            var notice = new Academic.DbEntities.Notices.Notice()
            {
                Id = Convert.ToInt32(id.Value)
                ,
                Headiing = heading.Text
                ,
                Description = description.Text
            };
            using (var helper = new DbHelper.Notice())
            {
                var success = helper.AddOrUpdateNotices(notice);
                if (success)
                {
                    DataList1.EditItemIndex = -1;
                    DataList1.SelectedIndex = -1;
                    DataList1.DataBind();
                }
                else
                {
                    Label errorMsg = (Label)e.Item.FindControl("lblUpdateErrorMsg");
                    if(errorMsg!=null)
                        errorMsg.Visible = true;
                }
            }

        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            //var notice = e.Item.DataItem;// as Academic.DbEntities.Notices.Notice;
            var noticeId = DataList1.DataKeys[e.Item.ItemIndex].ToString();
            //if (noticeId != null)
            {
                int id;
                var parsed = int.TryParse(noticeId, out id);
                if (parsed)
                {
                    using (var helper = new DbHelper.Notice())
                    {
                        var success = helper.DeleteNotices(id);
                    }
                }
            }
            DataList1.EditItemIndex = -1;
            DataList1.SelectedIndex = -1;
            DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //if (e.CommandName == "select")
            {
                DataList1.SelectedIndex = e.Item.ItemIndex;
                DataList1.DataBind();
            }
        }

        protected void btnAddSave_Click(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                var notice = new Academic.DbEntities.Notices.Notice()
                {
                    CreatedById = user.Id
                    ,
                    CreatedDate = DateTime.Now
                    ,
                    Description = txtDescription.Text
                    ,
                    Headiing = txtHeading.Text
                };
                using (var helper = new DbHelper.Notice())
                {
                    var success = helper.AddOrUpdateNotices(notice);
                    if (success)
                    {
                        txtDescription.Text = "";
                        txtHeading.Text = "";
                        DataList1.EditItemIndex = -1;
                        DataList1.SelectedIndex = -1;
                        DataList1.DataBind();
                        pnlDataList.Visible = true;
                        pblNew.Visible = false;
                    }
                    else
                    {
                        lblErrorMsg.Visible = true;
                    }
                }

            }
        }

        protected void btnAddCancel_Click(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtHeading.Text = "";
            pnlDataList.Visible = true;
            pblNew.Visible = false;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            pblNew.Visible = true;
            pnlDataList.Visible = false;
        }

    }
}