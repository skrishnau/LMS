using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.ViewsSite
{
    public partial class UserSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if logged in 
            if (!IsPostBack)
            {
                //check for user role and display accordingly now its only admin

                //leftSideBarUC.TextAndLinks = Values.Session.GetAdminSideBarItemsAndLinks();

                //need to uncomment
                leftSideBarUC.PopulateList(Values.Session.GetAdminSideBarItemsAndLinks());


            }
            lblBodyMessage.Text = "";
        }
    }
}