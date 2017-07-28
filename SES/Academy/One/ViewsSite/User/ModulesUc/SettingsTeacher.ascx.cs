using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class SettingsTeacher : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var thisUrl = Request.Url.AbsolutePath;
                //if (thisUrl.Contains("/Views/Student/"))
                //    lnkBatch.CssClass = "list-unmargined-selected-item";
                //if (thisUrl.Contains("/Views/Academy/"))
                //    lnkAcademicSession.CssClass = "list-unmargined-selected-item course-menu-selected-item";
                //else 
                    if (thisUrl.Contains("/Views/Course/"))
                    lnkCourses.CssClass = "list-unmargined-selected-item course-menu-selected-item";
                else if (thisUrl.Contains("/Views/Structure"))
                    lnkPrograms.CssClass = "list-unmargined-selected-item course-menu-selected-item";
                //else if (thisUrl.Contains("/Views/User/") || thisUrl.Contains("/Views/Role"))
                //    lnkUsers.CssClass = "list-unmargined-selected-item course-menu-selected-item";


            }
        }
    }
}