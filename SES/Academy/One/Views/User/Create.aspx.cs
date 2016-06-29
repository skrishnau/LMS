using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.User
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Values.Session.GetSchool(Session) != 0)
                {
                    UserCreateUC.SchoolId = Values.Session.GetSchool(Session);
                }
            }
        }
    }
}