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
                            if(user.IsInRole("manager"))
                            {
                                divPublished.Visible = true;
                            }else
                            {
                                divPublished.Visible = false;
                            }
                            lnkEdit.NavigateUrl = "~/Views/NoticeBoard/NoticeCreate.aspx?nId=" + noticeId;
                            using (var helper = new DbHelper.Notice())
                            {
                                var notice = helper.GetNotice(noticeId);
                                if (notice != null)
                                {
                                    lblNoticeName.Text = notice.Title;
                                    chkPublished.Checked = notice.PublishNoticeToNoticeBoard;

                                    lblNoticeContent.Text = notice.Content;
                                    var text = "";
                                    text = notice.PublishedDate == null
                                        ? ""
                                        : "<br/> Posted on: &nbsp;&nbsp;" 
                                        + notice.PublishedDate.Value.ToShortDateString();
                                    text += "<br/> Viewers: &nbsp;&nbsp;" + 
                                        ((notice.NoticePublishTo ?? false) ? "Everyone" : "Only Users");

                                    

                                    lblPostedOn.Text = text;

                                    var updaetd = helper.AddOrUpdateNoticeNotification(Convert.ToInt32(nId), user.Id);

                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }
    }
}