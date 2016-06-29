using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.UserControls.Structure.TreeViewOverriden
{
    public partial class TreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TreeViewUc.SchoolId = Values.Session.GetSchool(Session);
            }
        }
    }
}