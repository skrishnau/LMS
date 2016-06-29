using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values.MemberShip;
using One.ViewsSite.User.ModulesUc;

namespace One.ViewsSite.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    CoursesUc.UserId = user.Id;
                    if (user.IsInRole("manager"))
                    {
                        SettingsUc settings = (SettingsUc)Page.LoadControl("~/ViewsSite/User/ModulesUc/SettingsUc.ascx");
                        settings.UserId = user.Id;
                        pnlSettings.Controls.Add(settings);
                    }
                }

            }
        }
    }
}