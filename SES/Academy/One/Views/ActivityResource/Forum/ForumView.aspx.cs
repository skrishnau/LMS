using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Forum
{
    public partial class ForumView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //SubId=19&arId=2&secId=2&edit=0
                try
                {
                    var subId = Request.QueryString["SubId"];
                    var secId = Request.QueryString["secId"];
                    var forumId = Request.QueryString["arId"];
                    //var edit = Request.QueryString["edit"];

                    if (subId != null && secId != null && forumId != null)
                    {
                        SubjectId = Convert.ToInt32(subId);
                        SectionId = Convert.ToInt32(secId);
                        ForumId = Convert.ToInt32(forumId);
                        using (var helper = new DbHelper.ActAndRes())
                        {
                            var forum = helper.GetForumActivity(ForumId);

                            if (forum != null)
                            {
                                lblForumName.Text = forum.Name;
                                lblDescription.Text = forum.Description;
                                var discussionList = helper.ListParentDiscussionsOfForum(ForumId);
                                listViewDiscussions.DataSource = discussionList;
                                listViewDiscussions.DataBind();
                            }


                        }
                    }

                }
                catch { }
            }
        }

        public int ForumId
        {
            get { return Convert.ToInt32(hidForumId.Value); }
            set { hidForumId.Value = value.ToString(); }
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


        public string PageKey
        {
            get { return hidPageKey.Value; }
        }

        protected void btnAddNewDiscussionTopic_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ActivityResource/Forum/DiscussionCreate.aspx?disId=0"
                + "&prntId=0&mainDisId=0" + "&fId=" + ForumId + "&SubId=" + SubjectId + "&secId=" + SectionId);

        }

        public string GetUser(object user)
        {
            var us = user as Academic.DbEntities.User.Users;
            return us == null ? "" : us.FullName;
        }
    }
}