using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values.MemberShip;

namespace One.Views.Course.Category
{
    public partial class Create1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = User as CustomPrincipal;
                Create.SchoolId = user.SchoolId;
                var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    Create.ReturnUrl = HttpUtility.UrlDecode(returnUrl);

                    //RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
                }
            }
        }
    }
}