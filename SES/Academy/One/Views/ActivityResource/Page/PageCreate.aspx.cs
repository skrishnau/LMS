using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.ActivityResource.Page
{
    public partial class PageCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                var pId = Request.QueryString["arId"];
                var edit = Request.QueryString["edit"];
                try
                {
                    if (subId != null && secId != null)
                    {
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = Convert.ToInt32(subId);
                    }
                    if (pId != null && edit != null)
                    {
                        if (edit == "1")
                            SetPageValues(Convert.ToInt32(pId));
                    }
                }
                catch
                {
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }

                var guid = Guid.NewGuid();
                hidPageKey.Value = guid.ToString();

                //FilesDisplay1.PageKey = guid.ToString();
            }
        }

        private void SetPageValues(int pageId)
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var page = helper.GetPageResource(pageId);
                if (page != null)
                {
                    hidUrlId.Value = page.Id.ToString();
                    txtName.Text = page.Name;
                    txtDescription.Text = page.Description;
                    txtContent.Text = page.PageContent;
                    chkDisplayDescription.Checked = page.DisplayDescriptionOnPage;

                    chkDisplayPageDescription.Checked = page.DisplayDescriptionOnPage;
                    chkDisplayPageName.Checked = page.DisplayPageName;
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
        public int UrlResourceId
        {
            get { return Convert.ToInt32(hidUrlId.Value); }
            set { hidUrlId.Value = value.ToString(); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var page = new Academic.DbEntities.ActivityAndResource.PageResource()
            {
                Id = UrlResourceId,
                Name = txtName.Text
                ,
                Description = txtDescription.Text
                ,
                DisplayDescriptionOnPage = chkDisplayDescription.Checked
                ,
                DisplayPageName = chkDisplayPageName.Checked
                ,
                DisplayPageDescription = chkDisplayPageDescription.Checked
                ,
                PageContent = txtContent.Text
            };

            var restriction = new Academic.DbEntities.AccessPermission.Restriction()
            {

            };
            using (var helper = new DbHelper.ActAndRes())
            {
                var saved = helper.AddOrUpdatePageResource(page, SectionId,restriction);
                if (saved != null)
                {
                    Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId, SectionId));
                    //Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
                }
            }
        }


        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId, SectionId));
        }
    }
}