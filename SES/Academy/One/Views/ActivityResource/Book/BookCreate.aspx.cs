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
            lblError.Visible = false;
            if (!IsPostBack)
            {
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                var arId = Request.QueryString["arId"];
                try
                {
                    if (subId != null && secId != null)
                    {
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = Convert.ToInt32(subId);
                    }
                    if (arId != null)
                    {
                        BookId = Convert.ToInt32(arId);
                        LoadBook();
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
            set { hidBookId.Value = value.ToString(); }
        }

        public void LoadBook()
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var book = helper.GetBook(BookId);
                if (book != null)
                {
                    txtName.Text = book.Name;
                    CKEditor1.Text = book.Description;
                    chkDisplayDescription.Checked = book.DisplayDescriptionOnCourePage;
                    ddlChapterFormatting.SelectedIndex = book.ChapterFormatting;
                    ddlStyleOfNavigation.SelectedIndex = book.StyleOfNavigation;
                    //lblHeading.Text = "Edit '" + book.Name+"'";

                    RestrictionUC.SetActivityResource(false, ((int) Enums.Resources.Book) + 1, book.Id);

                    //RestrictionUC.ActivityOrResource = false;
                    //RestrictionUC.ActivityOrResourceId = book.Id;
                    //RestrictionUC.ActivityOrResourceType = ((int) Enums.Resources.Book) + 1;

                    //RestrictionUC.RestricionId = book.
                    //book.ActivityResource.Restriction.re
                    //RestrictionUC.GetRestriction()
                }
            }
        }

        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set
            {
                hidSectionId.Value = value.ToString();
                
            }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set
            {
                hidSubjectId.Value = value.ToString();
                RestrictionUC.SubjectId = value;
            }
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
                ,
            };

            var restriction = RestrictionUC.GetRestriction();
            if (!RestrictionUC.IsValid)
            {
                lblError.Visible = true;
                return;
            }
            using (var helper = new DbHelper.ActAndRes())
            {

                var saved = helper.AddOrUpdateBook(book, SectionId, restriction);
                if (saved != null)
                {
                    if (saved.Chapters.Any())
                    {
                        Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId, SectionId));
                    }
                    else
                    {
                        Response.Redirect("~/Views/ActivityResource/Book/ChapterCreate.aspx?bId=" + saved.Id +
                                          "&pcId=0&SubId=" + SubjectId
                                          + "&secId=" + SectionId);
                    }
                }
                //Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId, SectionId));
                //Response.Redirect("~/Views/Course/Section/?SubId="
                //        + SubjectId + "#section_" + SectionId);//
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId,SectionId));
        }
    }
}