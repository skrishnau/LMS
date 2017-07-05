using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Forum
{
    public partial class ForumCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlMaximumAttachmentSize.DataSource = GetMaximumAttachmentSizeList();
                ddlMaximumAttachmentSize.DataBind();

                ddlMaximumNoOfAttachments.DataSource = GetMaximumNumberOfAttachmentsList();
                ddlMaximumNoOfAttachments.DataBind();

                ddlTimeForBlocking.DataSource = GetTimeForBlockingList();
                ddlTimeForBlocking.DataBind();


                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                var fId = Request.QueryString["fId"];
                var edit = Request.QueryString["edit"];
                try
                {
                    if (subId != null && secId != null)
                    {
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = Convert.ToInt32(subId);
                    }
                    if (fId != null && edit != null)
                    {
                        if (edit == "1")
                            SetForumValues(Convert.ToInt32(fId));
                    }
                }
                catch
                {
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }

                var guid = Guid.NewGuid();
                hidPageKey.Value = guid.ToString();


            }
        }

        private void SetForumValues(int formumId)
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var forum = helper.GetForumActivity(formumId);
                if (forum != null)
                {
                    hidForumId.Value = forum.Id.ToString();
                    txtName.Text = forum.Name;
                    txtDescription.Text = forum.Description;
                    chkDisplayDescription.Checked = forum.DisplayDescriptionOnCoursePage;

                    ddlDisplayWordCount.SelectedIndex = forum.DisplayWordCount ? 1 : 0;
                    ddlForumType.SelectedIndex = forum.ForumType;
                    ddlMaximumAttachmentSize.SelectedValue = forum.MaximumAttachmentSize.ToString();

                    ddlMaximumNoOfAttachments.SelectedIndex = forum.MaximumNoOfAttachments;
                    ddlDisplayWordCount.SelectedIndex = forum.DisplayWordCount ? 1 : 0;
                    ddlReadTracking.SelectedIndex = forum.ReadTracking ? 0 : 1;
                    ddlSubscriptionMode.SelectedIndex = forum.SubscriptionMode;
                    ddlTimeForBlocking.SelectedIndex = forum.TimePeriodForBlocking;

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

        public string PageKey
        {
            get { return hidPageKey.Value; }
        }
        public int ForumActivityId
        {
            get { return Convert.ToInt32(hidForumId.Value); }
            set { hidForumId.Value = value.ToString(); }
        }

        private List<IdAndName> GetTimeForBlockingList()
        {
            var list = new List<IdAndName>()
            {
                new IdAndName(){Id = 0,Name = "Don't block"}
            };
            for (int i = 1; i < 7; i++)
            {
                list.Add(new IdAndName() { Id = i, Name = i + ((i == 1) ? "day" : "days") });
            }
            list.Add(new IdAndName() { Id = 7, Name = "1 week" });
            return list;
        }


        private List<IdAndName> GetMaximumNumberOfAttachmentsList()
        {
            var list = new List<IdAndName>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new IdAndName() { Id = i, Name = i.ToString() });
            }
            return list;
        }

        private List<IdAndName> GetMaximumAttachmentSizeList()
        {
            var list = new List<IdAndName>()
            {
                new IdAndName(){Id = 10000,Name = "10MB"},
                new IdAndName(){Id = 5000,Name = "5MB"},
                new IdAndName(){Id = 2000,Name = "2MB"},
                new IdAndName(){Id = 1000,Name = "1MB"},
                new IdAndName(){Id = 500,Name = "500KB"},
                new IdAndName(){Id = 100,Name = "100KB"},
                new IdAndName(){Id = 50,Name = "50KB"},
                new IdAndName(){Id = 10,Name = "10KB"},
                new IdAndName(){Id = 0,Name = "Upload are not allowed"},

            };
            return list;
        }

        private IdAndName GetMaximumAttachmentSize(int sizeInKB)
        {
            return GetMaximumAttachmentSizeList().Find(i => i.Id == sizeInKB);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var forum = new Academic.DbEntities.ActivityAndResource.ForumActivity()
                {
                    Id =  ForumActivityId
                    ,Name = txtName.Text
                    ,Description = txtDescription.Text
                    ,DisplayDescriptionOnCoursePage = chkDisplayDescription.Checked
                    ,DisplayWordCount = ddlDisplayWordCount.SelectedIndex==1
                    ,ForumType = (byte)ddlForumType.SelectedIndex
                    ,MaximumAttachmentSize = Convert.ToInt32(ddlMaximumAttachmentSize.SelectedValue)
                    ,MaximumNoOfAttachments = Convert.ToInt32(ddlMaximumNoOfAttachments.SelectedValue)
                    ,ReadTracking = ddlReadTracking.SelectedIndex==0
                    ,SubscriptionMode = (byte)ddlSubscriptionMode.SelectedIndex
                   ,TimePeriodForBlocking = Convert.ToByte(ddlTimeForBlocking.SelectedValue)
                   ,
                };
                if (ddlTimeForBlocking.SelectedIndex != 0)
                {
                    forum.PostThresholdForBlocking = Convert.ToInt32(txtPostThresholdForBlocking.Text);
                    forum.PostThresholdForWarning = Convert.ToInt32(txtPostThresholdForWarning.Text);
                }
                else
                {
                    forum.PostThresholdForBlocking = 0;
                    forum.PostThresholdForWarning = 0;
                }
                var restriction = new Academic.DbEntities.AccessPermission.Restriction()
                {

                };
                using (var helper = new DbHelper.ActAndRes())
                {
                    var saved = helper.AddOrUpdateForumActivity(forum,SectionId,restriction);
                    if(saved!=null)
                        Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId, SectionId));
                    //Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
                }

            }
        }
    }
}