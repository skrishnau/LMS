using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Account;
using One.Values.MemberShip;

namespace One.Views.NoticeBoard
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = User as CustomPrincipal;
            if(user!=null)
            CreateUc.UserId = (user).Id;
        }
    }
}