using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Class
{
    public partial class CourseSessionCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var courseId = Request.QueryString["cId"];
                if (courseId != null)
                {
                    //hidCourseId.Value = courseId;
                    try
                    {
                        
                        CourseSessionCreateUC1.SetCourseId(courseId);
                    }
                    catch { Response.Redirect("~/Views/Course/List.aspx"); }
                }
                else
                {
                    Response.Redirect("~/Views/Course/List.aspx");
                }
                //load course detail
                using (var helper = new DbHelper.Subject())
                {
                    try
                    {
                        var cId = Convert.ToInt32(courseId);
                        var sub = helper.GetCourse(cId);

                        //if (sub != null)
                        //{
                        //    lblFullName.Text = sub.Name;
                        //    lblCategory.Text = sub.SubjectCategory.Name;
                        //    lblShortName.Text = sub.ShortName;
                        //}

                    }
                    catch { }
                }
            }
        }
    }
}