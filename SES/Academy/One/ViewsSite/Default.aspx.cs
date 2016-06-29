using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.IsInRole("student"))
                {
                    Response.Redirect("~/ViewsSite/DashBoard/Student/Dashboard.aspx");
                }
                else
                {
                    //Response.Redirect("");
                }
            }
        }
    }
}