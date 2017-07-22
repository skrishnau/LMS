using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user == null)
                {
                    loginDiv.Visible = true;
                }
                else
                {
                    SiteMapUc.SetData(new List<IdAndName>()
                    {
                        new IdAndName(){Name = "About"}
                    });
                }
            }
        }
    }
}