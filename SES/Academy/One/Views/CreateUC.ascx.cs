using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Views.CreatedUser;

namespace One.Views
{
    public partial class CreateUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var selection = ListBox1.SelectedValue;
            //switch (selection)
            //{
            //    case"Teacher":
            //        CreatedUser.Create create = new CreatedUser.Create();
                    
            //        Response.Redirect("~/Views/CreatedUser/Create.aspx");
            //        break;
            //    case "Staff":
            //        break;
            //    case "Student":
            //        break;
            //    case "Subject":
            //        break;

            //    case "Academic Year":
            //        Response.Redirect("~/Views/Academy/AcademicYear/Create.aspx");
            //        break;
            //}
        }
    }
}