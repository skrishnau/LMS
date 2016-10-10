using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.ActivityResource.Forum
{
    public partial class DiscussionView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    var discId = Request.QueryString["disId"];
                    try
                    {
                        PopulateQueryValues();
                        if (discId != null)
                        {
                            var discussionId = Convert.ToInt32(discId.ToString());
                            DiscussionId = discussionId;
                            using (var helper = new DbHelper.ActAndRes())
                            {
                                var disc = helper.GetForumDiscussion(discussionId);
                                if (disc != null)
                                {
                                    lblForumName.Text = disc.ForumActivity.Name;
                                    lblDiscussionSubject.Text = disc.Subject;


                                    var uc = (EachDiscussionUc)
                                                Page.LoadControl("~/Views/ActivityResource/Forum/EachDiscussionUc.ascx");
                                    uc.SetValues(user.Id, disc, SubjectId, SectionId, discussionId);
                                    pnlReplies.Controls.Add(uc);
                                }
                            }
                        }
                    }
                    catch
                    {
                        Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                    }
                }

            }
        }

        private void PopulateQueryValues()
        {
            var subId = Request.QueryString["SubId"];
            var secId = Request.QueryString["secId"];

            if (subId != null && secId != null)
            {
                SubjectId = Convert.ToInt32(subId);
                SectionId = Convert.ToInt32(secId);
            }
            else Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
        }

        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }
        public int ForumId
        {
            get { return Convert.ToInt32(hidForumId.Value); }
            set { hidForumId.Value = value.ToString(); }
        }
        public int ParentDiscussionId
        {
            get { return Convert.ToInt32(hidParentDiscussionId.Value); }
            set { hidParentDiscussionId.Value = value.ToString(); }
        }
        public int DiscussionId
        {
            get { return Convert.ToInt32(hidDiscussionId.Value); }
            set { hidDiscussionId.Value = value.ToString(); }
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
    }
}