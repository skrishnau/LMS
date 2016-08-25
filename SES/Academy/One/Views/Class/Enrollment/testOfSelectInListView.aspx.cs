using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Class.Enrollment
{
    public partial class testOfSelectInListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.User())
            {
                var user = User as CustomPrincipal;
                if (user != null)
                {
                    var cats = helper.ListAllUsers();
                    ListView1.DataSource = cats;
                    ListView1.DataBind();
                }
            }
        }
    }
}