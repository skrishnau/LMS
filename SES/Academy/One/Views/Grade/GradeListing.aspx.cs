using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Grade
{
    public partial class GradeListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;

            if (user != null)
            {
                if (!IsPostBack)
                {

                    if (user.IsInRole("manager") || user.IsInRole("grader") || user.IsInRole("course-editor"))
                    {
                        lnkAddGrade.Visible = true;
                    }
                    else
                    {
                        lnkAddGrade.Visible = false;                        
                    }

                    using (var helper = new DbHelper.Grade())
                    {
                        DataList1.DataSource = helper.ListGrades(user.SchoolId);
                        DataList1.DataBind();
                    }
                }
            }
            else Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
        }
    }
}