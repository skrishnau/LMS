using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Structure.All.Master
{
    public partial class AddCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var year = Request.QueryString["yId"];
                var subyear = Request.QueryString["sId"];

                if (year != null && subyear != null)
                {
                    try
                    {
                        var y = Convert.ToInt32(year.ToString());
                        var s = Convert.ToInt32(subyear.ToString());
                        //AddCourses1.YearId = y;
                        //AddCourses1.SubYearId = s;
                       
                    }
                    catch
                    {
                        Response.Redirect("List.aspx");
                    }

                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }
        }
    }
}