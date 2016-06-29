using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Login
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                authPanel.Visible = true;
                anonymPanel.Visible = false;
                Label1.Text+= HttpContext.Current.User.Identity.Name;
            }
            else
            {
                authPanel.Visible = false;
                anonymPanel.Visible = true;
            }
        }
    }
}