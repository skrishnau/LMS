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
    public partial class DiscussionCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if(user!=null)
                try
                {
                    var discussionId = Request.QueryString["disId"];
                    var parentDiscussionId = Request.QueryString["prntId"];
                    var forumId = Request.QueryString["fId"];
                    //var returl = Request.QueryString["returl"];
                    var subId = Request.QueryString["SubId"];
                    var secId = Request.QueryString["secId"];
                    var mainDisId = Request.QueryString["mainDisId"];

                    if (mainDisId == null) return;
                    MainDiscussionId = Convert.ToInt32(mainDisId);

                    if (forumId != null && subId != null && secId != null)
                    {
                        SubjectId = Convert.ToInt32(subId);
                        SectionId = Convert.ToInt32(secId);
                        ForumId = Convert.ToInt32(forumId);

                        PopulateEditValues(discussionId, parentDiscussionId,user.Id);
                        //if (discussionId != null)
                        //{
                        //}
                        //if (parentDiscussionId != null)
                    }
                    else Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }
                catch
                {
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }
            }
        }

        private void PopulateEditValues(object discussionId, object parentDiscussionId,int userId)
        {
            var discId = Convert.ToInt32(discussionId ?? "0");
            var parentDiscId = Convert.ToInt32(parentDiscussionId ?? "0");
            ParentDiscussionId = parentDiscId;

            using (var helper = new DbHelper.ActAndRes())
            {

                if (discId > 0)
                {
                    var disc = helper.GetForumDiscussion(discId);

                    if (disc != null && disc.PostedById== userId)
                    {
                        DiscussionId = discId;
                        txtSubject.Text = disc.Subject;
                        txtMessage.Text = disc.Message;
                        chkPinned.Checked = disc.Pinned;
                        chkSubscribeToDiscussion.Checked = disc.SubscribeToDiscussion;


                    }
                }
                else if (parentDiscId > 0)
                {
                    var prntdisc = helper.GetForumDiscussion(parentDiscId);

                    if (prntdisc != null)
                    {
                        txtSubject.Text = "Re:"+prntdisc.Subject;
                    }
                }
            }
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
        public int MainDiscussionId
        {
            get { return Convert.ToInt32(hidMainDiscussionId.Value); }
            set { hidMainDiscussionId.Value = value.ToString(); }
        }

        public string PageKey
        {
            get { return hidPageKey.Value; }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                var subject = txtSubject.Text.Replace("Re:", "").Trim();

                var disc = new Academic.DbEntities.ActivityAndResource.ForumItems.ForumDiscussion()
                {
                    Id = DiscussionId
                    ,
                    ForumActivityId = ForumId
                    ,
                    Subject = subject
                    ,
                    Message = txtMessage.Text
                    ,
                    PostedById = user.Id
                    ,

                    PostedDate = DateTime.Now
                        //,Closed =
                    ,
                    LastPostById = user.Id
                    ,
                    LastPostDate = DateTime.Now
                    ,
                    Pinned = chkPinned.Checked
                    ,
                    SubscribeToDiscussion = chkSubscribeToDiscussion.Checked
                };
                if (ParentDiscussionId > 0)
                    disc.ParentDiscussionId = ParentDiscussionId;

                using (var helper = new DbHelper.ActAndRes())
                {
                    var saved = helper.AddOrUpdateDiscussion(user.Id, disc);
                    if (saved != null)
                    {
                        if ((ParentDiscussionId > 0 || DiscussionId>0)&&MainDiscussionId>0)// then this is child discussion of ParentDiscussionId
                        {
                            Response.Redirect("~/Views/ActivityResource/Forum/DiscussionView.aspx?fId="
                                + ForumId + "&disId=" + MainDiscussionId 
                                +"&SubId=" + SubjectId +
                                "&fId=" + ForumId + "&secId=" + SectionId
                                + "#section_" + saved.Id);
                        }
                        else// this is parent discussion
                        {//SubId=19&arId=2&secId=2&edit=0
                            Response.Redirect("~/Views/ActivityResource/Forum/ForumView.aspx?SubId=" + SubjectId +
                                "&arId=" + ForumId + "&secId=" + SectionId + "#section_" + saved.Id);
                        }

                        Response.Redirect("");
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}