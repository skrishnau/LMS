using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values.MemberShip;
using One.ViewsSite.User;

namespace One.Views.Office.School
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/About.aspx");
            //var user = User as CustomPrincipal;// Master.UserId;
            ////var schoolId = Master as UserMaster;//
            ////if(schoolId!=null)
            //if (user != null)
            //{
            //    if (user.SchoolId <= 0)
            //    {
            //        Response.Redirect("Create.aspx");
            //    }
            //}
        }
    }
}