using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.ActivityResource.Forum
{
    public partial class EachDiscussionUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string GetUser(object user)
        {
            var us = user as Academic.DbEntities.User.Users;
            return us == null ? "" : us.FullName;
        }

        public string GetDateTime(object dateTime)
        {
            try
            {
                var dt = Convert.ToDateTime(dateTime.ToString());
                return dt.ToShortDateString() + "  " + dt.ToShortTimeString();
            }
            catch
            {
                return "";
            }

        }
        public bool EditVisible
        {
            set
            {
                lblEditAfter.Visible = value;
                lnkEdit.Visible = value;
            }
        }

        public bool DeleteVisible
        {
            set
            {
                lblDeleteAfter.Visible = value;
                lnkDelete.Visible = value;
            }
        }

        public void SetValues(int userId, Academic.DbEntities.ActivityAndResource.ForumItems.ForumDiscussion discussion, int subjectId, int sectionId, int mainDisId)
        {
            if (discussion.PostedById == userId)
            {
                EditVisible = true;
                DeleteVisible = true;
            }
            else
            {
                EditVisible = false;
                DeleteVisible = false;
            }

            var date = string.Format("{0:f}", discussion.PostedDate);
            //var time = string.Format("{0:t}", discussion.PostedDate);
            lblDateTime.Text = date;
            //discussion.PostedDate.ToShortDateString() 
            //+"  "
            //+ discussion.PostedDate.ToShortTimeString();

            lblMessage.Text = discussion.Message;
            lblPostedBy.Text = discussion.PostedBy.FullName;
            lblSubject.Text = discussion.Subject;
            lnkEdit.NavigateUrl = ("~/Views/ActivityResource/Forum/DiscussionCreate.aspx?disId="
                    + discussion.Id
                    + "&mainDisId=" + mainDisId
                    + "&prntId=" + (discussion.ParentDiscussionId ?? 0) + "&fId=" + discussion.ForumActivityId
                    + "&SubId=" + subjectId + "&secId=" + sectionId);
            lnkReply.NavigateUrl = ("~/Views/ActivityResource/Forum/DiscussionCreate.aspx?disId=0"
                   + "&mainDisId=" + mainDisId
                + "&prntId=" + (discussion.Id) + "&fId=" + discussion.ForumActivityId
                    + "&SubId=" + subjectId + "&secId=" + sectionId + "#section_m"); ;
            lnkDelete.NavigateUrl = "";
            try
            {
                imgImage.ImageUrl = discussion.PostedBy.UserImage.FileDirectory + discussion.PostedBy.UserImage.FileName;
            }
            catch { }

            foreach (var disc in discussion.Replies)
            {
                //var discs = helper.GetForumDiscussions(DiscussionId);
                var uc = (EachDiscussionUc)
                    Page.LoadControl("~/Views/ActivityResource/Forum/EachDiscussionUc.ascx");
                uc.SetValues(userId,disc, subjectId, sectionId, mainDisId);
                pnlReplies.Controls.Add(uc);
            }

        }
    }
}