using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Structure.All.Master
{
    public partial class CoursesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var year = Request.QueryString["yId"];
                var subyear = Request.QueryString["sId"];

                if (year != null && subyear != null)
                {
                    Response.Redirect("~/Views/Structure/CourseListing.aspx?yId="+year+"&sId="+subyear);
                    //try
                    //{
                    //    var y = Convert.ToInt32(year.ToString());
                    //    var s = Convert.ToInt32(subyear.ToString());
                    //    using (var helper = new DbHelper.Structure())
                    //    {
                    //        var dir = helper.GetSructureDirectory(y, s);
                    //        CourseListUC.SetProgramDirectory(dir);
                    //    }
                    //    CourseListUC.LoadCourseList(y, s);
                    //}
                    //catch { Response.Redirect("List.aspx"); }

                }
                else
                {
                    Response.Redirect("List.aspx");
                }

                /*var yearId = ViewState["yearId"];
                var subyearId = ViewState["subYearId"];

                //viewsta
                if (yearId == null || subyearId == null)
                {
                    Response.Redirect("List.aspx");
                }
                else
                {
                    var y = Convert.ToInt32(yearId.ToString());
                    var s = Convert.ToInt32(subyearId.ToString());
                    using (var helper = new DbHelper.Structure())
                    {
                        var dir = helper.GetSructureDirectory(y, s);
                        CourseListUC.SetProgramDirectory(dir);
                    }
                    CourseListUC.LoadCourseList(y, s);
                }*/
            }
        }

    }
}