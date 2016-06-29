using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.ListingMain.CoursesOfGroup
{
    public partial class CoursesOfGroupListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                {
                    var sgId = Request.QueryString["Id"];
                    if (sgId != null)
                    {
                        int sId;
                        var success = int.TryParse(sgId, out sId);
                        if (success)
                        {
                            ListUc.SubjectGroupId = sId;
                            ListUc.SchoolId = Values.Session.GetSchool(Session);
                        }
                    }
                }
                {
                    var sgId = Request.QueryString["IdY"];
                    if (sgId != null)
                    {
                        int sId;
                        var success = int.TryParse(sgId, out sId);
                        if (success)
                        {
                            ListUc.SubjectGroupId = sId;
                            ListUc.SchoolId = Values.Session.GetSchool(Session);
                        }
                    }
                }

            }
        }
    }
}