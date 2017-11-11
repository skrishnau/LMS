using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.NoticeBoard
{
    public partial class NoticeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;
            if (!IsPostBack)
            {

                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    IdAndName noticeName = null;
                    var nId = Request.QueryString["nId"];
                    if (nId != null)
                    {
                        NoticeId = Convert.ToInt32(nId);
                        using (var helper = new DbHelper.Notice())
                        {
                            var notice = helper.GetNotice(NoticeId);
                            if (notice != null)
                            {
                                noticeName = new IdAndName() { Name = notice.Title, Value = "~/Views/NoticeBoard/NoticeDetail.aspx?nId=" + notice.Id, Void = true };
                                txtHeading.Text = notice.Title;
                                CKEditor1.Text = notice.Content;
                                chkPublish.Checked = notice.PublishNoticeToNoticeBoard;
                                ddlPublishTo.SelectedIndex = (notice.NoticePublishTo ?? false) ? 0 : 1;

                                ddlPublishTo.Visible = notice.PublishNoticeToNoticeBoard;

                                lblPageitle.Text = "Notice Edit";

                                //var updaetd = helper.AddOrUpdateNoticeNotification(Convert.ToInt32(nId), user.Id);
                            }
                        }
                    }

                    if (SiteMap.CurrentNode != null)
                    {
                        var list = new List<IdAndName>()
                            {
                               new IdAndName(){
                                            Name=SiteMap.RootNode.Title
                                            ,Value =  SiteMap.RootNode.Url
                                            ,Void=true
                                        },
                                        new IdAndName()
                                        {
                                            Name = SiteMap.CurrentNode.ParentNode.Title
                                            ,Value = SiteMap.CurrentNode.ParentNode.Url
                                            ,Void = true
                                        }
                                        ,
                                       
                            };
                        if (noticeName != null)
                        {
                            list.Add(noticeName);
                            //list.Add(new IdAndName(){});
                            list.Add(new IdAndName()
                            {
                                Name = "Edit"
                                //,Value = SiteMap.CurrentNode.Url
                                //,Void=true
                            });
                        }
                        else
                        {
                             list.Add(new IdAndName()
                            {
                                Name = SiteMap.CurrentNode.Title
                                //,Value = SiteMap.CurrentNode.Url
                                //,Void=true
                            });
                        }
                       
                        SiteMapUc.SetData(list);
                    }
                }

            }
        }

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }
        public int NoticeId
        {
            get { return Convert.ToInt32(hidNoticeId.Value); }
            set { hidNoticeId.Value = value.ToString(); }
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


        protected void btnAddSave_Click(object sender, EventArgs e)
        {
            if (CKEditor1.Text.Length == 0)
            {
                lblErrorMsg.Text = "Required field is/are empty";
                lblErrorMsg.Visible = true;
                return;
            }
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                var notice = new Academic.DbEntities.Notices.Notice()
                {
                    Id = NoticeId,

                    Content = CKEditor1.Text
                    ,
                    Title = txtHeading.Text
                    ,
                    PublishNoticeToNoticeBoard = chkPublish.Checked
                    ,
                    SchoolId = user.SchoolId
                };

                if (chkPublish.Checked)
                {
                    notice.NoticePublishTo = ddlPublishTo.SelectedIndex == 0;
                    notice.PublishedDate = DateTime.Now;

                }

                if (NoticeId > 0)
                {
                    notice.UpdatedBy = user.Id;
                    notice.UpdatedDate = DateTime.Now;

                }
                else
                {
                    notice.CreatedBy = user.Id;
                    notice.CreatedDate = DateTime.Now;
                }
                using (var helper = new DbHelper.Notice())
                {
                    var success = helper.AddOrUpdateNotices(notice);
                    if (success)
                    {
                        Response.Redirect("~/Views/NoticeBoard/NoticeListing.aspx");

                    }
                    else
                    {
                        lblErrorMsg.Visible = true;
                    }
                }

            }
        }

        protected void chkPublish_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPublish.Checked)
                ddlPublishTo.Visible = true;
            else ddlPublishTo.Visible = false;
        }



        /*   data list uses case
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
                        Title = heading.Text
                        ,
                        Content = description.Text
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
                            if (errorMsg != null)
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
                 protected void btnNew_Click(object sender, EventArgs e)
                {
                    pblNew.Visible = true;
                    pnlDataList.Visible = false;
                }*/


        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/NoticeBoard/NoticeListing.aspx");
        }
    }
}