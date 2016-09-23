using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Book
{
    public partial class BookView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var arId = Request.QueryString["arId"];
                    if (arId != null)
                    {
                        BookId = (Convert.ToInt32(arId.ToString())); using (var helper = new DbHelper.ActAndRes())
                        {
                            var book = helper.GetBook(BookId);
                            lblBookName.Text = book.Name;
                            lblBookDescription.Text = book.Description;
                        }
                    }
                }
                catch { }

            }
            LoadTOC();
        }

        public int BookId
        {
            get { return Convert.ToInt32(hidBookId.Value); }
            set { hidBookId.Value = value.ToString(); }
        }

        //private void LoadBook()
        //{
        //    using (var helper = new DbHelper.ActAndRes())
        //    {
        //        var book = helper.GetBook(BookId);



        //        var toc = helper.GetTocOfBook(BookId);

        //        //var content = helper.GetContentOfBook(toc);
        //    }
        //}

        private void LoadTOC()
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var toc = helper.GetTocOfBook(BookId);
                //var content = helper.GetContentOfBook(toc);
            }
        }

        private void LoadContent()
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                //var content = helper.GetContentOfBook(toc);
            }
        }

    }
}