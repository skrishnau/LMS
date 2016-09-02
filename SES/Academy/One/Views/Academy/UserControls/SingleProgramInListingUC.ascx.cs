using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Academy.UserControls
{
    public partial class SingleProgramInListingUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetName(string structureName, string curretlyIn)
        {
            lnkProgram.Text = structureName;
            lblCurrentlyIn.Text = curretlyIn;
        }
    }
}