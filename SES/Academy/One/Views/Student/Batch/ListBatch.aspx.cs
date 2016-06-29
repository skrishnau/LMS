using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Student.Batch
{
    public partial class ListBatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listUc.SchoolId = Values.Session.GetSchool(Session);
        }
    }
}