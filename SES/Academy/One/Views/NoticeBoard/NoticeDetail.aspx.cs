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
    public partial class NoticeDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                try
                {
                    var user = Page.User as CustomPrincipal;
                    if (user != null)
                    {
                        var nId = Request.QueryString["nId"];
                        var noticeId = Convert.ToInt32(nId);
                        if (nId != null)
                        {

                            using (var helper = new DbHelper.Notice())
                            {
                                var notice = helper.GetNotice(noticeId);
                                if (notice != null)
                                {
                                    //string n = notice.Title.Take(20).ToString();
                                    lblTitle.Text = notice.Title;
                                    if (SiteMap.CurrentNode != null)
                                    {
                                        var list = new List<IdAndName>()
                                        {
                                           new IdAndName(){
                                                        Name=SiteMap.RootNode.Title
                                                        ,Value =  SiteMap.RootNode.Url
                                                        ,Void=true
                                                    },
                                            new IdAndName(){
                                                Name = SiteMap.CurrentNode.ParentNode.Title
                                                ,Value = SiteMap.CurrentNode.ParentNode.Url
                                                ,Void=true
                                            },
                                            new IdAndName(){Name = notice.Title}
                                        };
                                        SiteMapUc.SetData(list);
                                    }
                                    //if (SiteMap.CurrentNode != null)
                                    //{
                                    //    SiteMap.CurrentNode.ReadOnly = false;
                                    //    var tempnode = SiteMap.CurrentNode;
                                    //    tempnode.Title = notice.Title;
                                    //}
                                    var edit = (Session["editMode"] as string) =="1";
                                    if ((user.IsInRole("manager") || user.IsInRole("notifier")) )
                                    {
                                        if (edit)
                                        {
                                            lnkEdit.NavigateUrl = "~/Views/NoticeBoard/NoticeCreate.aspx?nId=" +
                                                                  noticeId;
                                            lnkDelete.NavigateUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx"
                                                                    + "?task=" + DbHelper.StaticValues.Encode("notice")
                                                                    + "&nId=" + notice.Id;
                                            menuEditDelete.Visible = true;
                                        }
                                        else
                                        {
                                            menuEditDelete.Visible = false;
                                        }
                                        divPublished.Visible = true;
                                        //lnkEdit.Visible = true;
                                        //lnkDelete.Visible = true;
                                    }
                                    else
                                    {
                                        menuEditDelete.Visible = false;
                                        //lnkEdit.Visible = false;
                                        //lnkDelete.Visible = false;
                                        divPublished.Visible = false;
                                    }

                                    lblNoticeName.Text = notice.Title;
                                    chkPublished.Checked = notice.PublishNoticeToNoticeBoard;

                                    if (notice.Content.Length > 0)
                                    {
                                        lblNoticeContent.Text = notice.Content;
                                        divNotice.Visible = true;
                                    }

                                    var text = "";
                                    lblPstdOn.Text = notice.PublishedDate == null
                                        ? ""
                                        : notice.PublishedDate.Value.ToShortDateString();
                                    lblViewers.Text +=
                                        ((notice.NoticePublishTo ?? false) ? "Everyone" : "Only Users");

                                    //lblPostedOn.Text = text;
                                    helper.AddOrUpdateNoticeNotification(Convert.ToInt32(nId), user.Id);
                                }
                                else
                                {
                                    Response.Redirect("~/Views/NoticeBoard/NoticeListing.aspx");
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("~/Views/NoticeBoard/NoticeListing.aspx");
                        }
                    }
                }
                catch { }
            }
        }
    }
}