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
                var edit = Request.QueryString["edit"];

                //var secId = Request.QueryString["SecId"];
                try
                {
                    if (bookId != null)
                    {
                        BookId = Convert.ToInt32(bookId);
                    }
                    if (parentChapterId != null)
                    {
                        if (edit != null)
                        {
                            if (edit.ToString() == "1")
                            {
                                ChapterId = Convert.ToInt32(parentChapterId);
                                using (var helper = new DbHelper.ActAndRes())
                                {
                                    var chapter = helper.GetChapter(ChapterId);
                                    if (chapter != null)
                                    {
                                        txtName.Text = chapter.Title;
                                        CKEditor1.Text = chapter.Content;
                                        chkSubChapter.Checked = chapter.ParentChapterId != null;
                                        chkSubChapter.Enabled = false;
                                        ParentChapterId = chapter.ParentChapterId ?? 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            ParentChapterId = Convert.ToInt32(parentChapterId);
                            if (ParentChapterId > 0 && ChapterId <= 0)
                            {
                                chkSubChapter.Enabled = true;
                                chkSubChapter.Checked = true;
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
        public int ChapterId
        {
            get { return Convert.ToInt32(hidChapterId.Value); }
            set { hidChapterId.Value = value.ToString(); }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            var saved = new Academic.DbEntities.ActivityAndResource.BookItems.BookChapter();
            using (var helper = new DbHelper.ActAndRes())
            {
                var chapter = new Academic.DbEntities.ActivityAndResource.BookItems.BookChapter()
                {
                    Id = ChapterId,
                    BookId = BookId
                    ,
                    Content = CKEditor1.Text
                    ,
                    Title = txtName.Text
                    ,
                };
                if (chkSubChapter.Checked)
                {
                    if (ParentChapterId > 0)
                    {
                        chapter.ParentChapterId = ParentChapterId;
                    }

                }
                else
                {
                    // here we need to assign th parent id of the parentchapterId
                  
                    var parent = helper.GetChapter(ParentChapterId);
                    if (parent != null)
                    {
                        chapter.ParentChapterId = parent.ParentChapterId;
                        chapter.Position = parent.Position;
                    }
                    
                }


                 saved = helper.AddOrUpdateBookChapter(chapter);
               

            }
            using (var helper = new DbHelper.ActAndRes())
            {
                if (saved != null)
                {
                    helper.UpdateBelowChapters(saved.BookId, saved.Id, saved.ParentChapterId ?? 0, saved.Position);
                    Response.Redirect("~/Views/ActivityResource/Book/BookView.aspx?arId=" + BookId);
                }
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