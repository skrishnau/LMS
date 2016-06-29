using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Exam.Exam.Master
{
    public partial class ListExams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListUc1.SchoolId = Values.Session.GetSchool(Session);
            }
        }
    }
}