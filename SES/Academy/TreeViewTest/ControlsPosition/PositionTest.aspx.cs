using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TreeViewTest.ControlsPosition
{
    public partial class PositionTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //int panelX = Int32.Parse(Request.Form["TextBox1"]);
                //int panelY = Int32.Parse(Request.Form["hidYTextBox2"]);
                //int panY = Int32.Parse(.Value);
            }
            var data = Request.Form[""];
        }
    }
}