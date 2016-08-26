using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Class.Enrollment
{
    public partial class Enrollment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var classId = Request.QueryString["ccId"];
                if (classId != null)
                {
                    try
                    {
                        hidCourseClassId.Value = classId;
                        using (var helper = new DbHelper.Classes())
                        {
                            UserEnrollUC_ListDisplay1.SubjectSessionId = Convert.ToInt32(classId);

                        }
                    }
                    catch
                    {
                        Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                    }
                }
            }
        }

        public int CourseClassId
        {
            get { return Convert.ToInt32(hidCourseClassId.Value); }
            set { hidCourseClassId.Value = value.ToString(); }
        }
    }
}