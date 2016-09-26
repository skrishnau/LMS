using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Test.AsyncFileUploadCheck
{
    public partial class webform1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Loaduc();
        }

        private void Loaduc()
        {

            //var uc = (uc1)Page.LoadControl("~/Views/Test/AsyncFileUploadCheck/uc1.ascx");
            //Panel1.Controls.Add(uc);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = !Panel1.Visible;
            //Button1.Text = Panel1.Visible ? "Hide upload" : "Show upload";
        }
    }
}