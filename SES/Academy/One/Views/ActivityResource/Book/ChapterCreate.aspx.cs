using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Book
{
    public partial class ChapterCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var bookId = Request.QueryString["bId"];
                var parentChapterId = Request.QueryString["pcId"];
                //var secId = Request.QueryString["SecId"];
                try
                {
                    if (bookId != null && parentChapterId!=null)
                    {
                        BookId = Convert.ToInt32(bookId);
                        ParentChapterId = Convert.ToInt32(parentChapterId);
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

        public int ParentChapterId
        {
            get { return Convert.ToInt32(hidParentChapterId.Value); }
            set { hidParentChapterId.Value = value.ToString(); }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            var chapter = new Academic.DbEntities.ActivityAndResource.BookItems.BookChapter()
            {
                BookId = BookId
                ,Content = CKEditor1.Text
                ,Title = txtName.Text
                ,ParentChapterId = ParentChapterId
                ,
            };
            using (var helper = new DbHelper.ActAndRes())
            {
                var saved = helper.AddOrUpdateBookChapter(chapter);
                if(saved!=null)
                    Response.Redirect("~/Views/ActivityResource/Book/BookView.aspx?bId="+BookId);

            }
        }






        //public int SectionId
        //{
        //    get { return Convert.ToInt32(hidSectionId.Value); }
        //    set { hidSectionId.Value = value.ToString(); }
        //}

        //public int SubjectId
        //{
        //    get { return Convert.ToInt32(hidSubjectId.Value); }
        //    set { hidSubjectId.Value = value.ToString(); }
        //}
    }
}