using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values.MemberShip;

namespace One.Views.Setting
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    if (!user.IsInRole("manager"))
                    {
                        Response.Redirect("~/");                        
                    }
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
        }
    }
}