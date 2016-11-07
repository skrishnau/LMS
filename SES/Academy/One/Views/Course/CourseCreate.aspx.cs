using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Course
{
    public partial class CourseCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateUC.SaveClicked += CreateUC_SaveClicked;
            CreateUC.CancelClicked += CreateUC_SaveClicked;
            if (!IsPostBack)
            {
                try
                {
                    var catId = Request.QueryString["catId"];
                    if (catId != null)
                    {
                        var user = Page.User as CustomPrincipal;
                        if (user != null)
                        {
                            var categoryId = Convert.ToInt32(catId);
                            CreateUC.CategoryId = categoryId;
                            CategoryId = categoryId;
                            using (var helper = new DbHelper.Subject())
                            {
                                var category = helper.GetCategory(categoryId);

                                if (category != null)
                                {
                                    if (category.SchoolId == user.SchoolId)
                                        lblCategoryName.Text = category.Name;
                                }
                                else
                                    Response.Redirect("~/Views/Course/List.aspx");
                            }
                        }
                    }
                    else
                        Response.Redirect("~/Views/Course/List.aspx");
                }
                catch
                {
                    Response.Redirect("~/Views/Course/List.aspx");
                }
            }
        }
        public int CategoryId
        {
            get { return Convert.ToInt32(hidCategoryId.Value); }
            set { hidCategoryId.Value = value.ToString(); }
        }
        void CreateUC_SaveClicked(object sender, Academic.DbHelper.MessageEventArgs e)
        {
            Response.Redirect("~/Views/Course/List.aspx?catId=" + CreateUC.CategoryId);
        }


    }
}