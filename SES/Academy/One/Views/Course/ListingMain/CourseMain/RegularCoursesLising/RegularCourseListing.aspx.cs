using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.ListingMain.CourseMain.RegularCoursesLising
{
    public partial class RegularCourseListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListUc.SchoolId = Values.Session.GetSchool(Session);
                var Idy = Request.QueryString["IdY"];
                if (Idy != null)
                {
                    int yId;
                    var success = int.TryParse(Idy, out yId);
                    if (success)
                    {
                        ListUc.YearId = yId;
                    }
                }
                var Ids = Request.QueryString["IdS"];
                if (Ids != null)
                {
                    int sId;
                    var success = int.TryParse(Ids, out sId);
                    if (success)
                        ListUc.SubYearId = sId;
                }
            }
        }
    }
}