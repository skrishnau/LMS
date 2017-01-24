using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class CoursesMenuUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var thisUrl = Request.Url.AbsolutePath;
                if (thisUrl.Contains("/Views/Courses/"))
                {
                    var query = Request.QueryString["type"];
                    var q = query ?? "current";
                    if (q.Equals("current"))
                        lnkCurrent.CssClass = "list-unmargined-selected-item";
                    else
                        lnkEarlier.CssClass = "list-unmargined-selected-item";
                }
                //else if (thisUrl.Contains("/Views/Courses/?type=earlier"))
            }
        }
    }
}