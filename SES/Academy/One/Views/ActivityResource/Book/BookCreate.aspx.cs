using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Book
{
    public partial class BookCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                try
                {
                    if (subId != null && secId != null)
                    {
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = Convert.ToInt32(subId);
                    }
                }
                catch
                {
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }
            }
        }

        public int BookId
        {
            get { return Convert.ToInt32(hidBookId.Value); }
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var book = new Academic.DbEntities.ActivityAndResource.BookResource()
            {
                Id = BookId,
                Name = txtName.Text
                ,
                Description = CKEditor1.Text
                ,
                ChapterFormatting = (byte)ddlChapterFormatting.SelectedIndex
                ,
                CustomTitles = false
                ,
                StyleOfNavigation = (byte)ddlStyleOfNavigation.SelectedIndex
                ,
                DisplayDescriptionOnCourePage = chkDisplayDescription.Checked

            };
            var restriction = new Academic.DbEntities.AccessPermission.Restriction()
            {

            };
            using (var helper = new DbHelper.ActAndRes())
            {

                var saved = helper.AddOrUpdateBook(book, SectionId,restriction);
                if (saved != null)
                    Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId="
                        + SubjectId + "&edit=1" + "#section_" + SectionId);//
            }
        }
    }
}