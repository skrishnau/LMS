using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values.MemberShip;

namespace One.Views.Structure.All
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var user = User as CustomPrincipal;
                if (user != null)
                {
                    if (user.SchoolId > 0)
                    {
                        CreateUC.SchoolId = user.SchoolId;
                        //Values.Session.GetSchool(Session);
                    }
                }
            }
        }
    }
}