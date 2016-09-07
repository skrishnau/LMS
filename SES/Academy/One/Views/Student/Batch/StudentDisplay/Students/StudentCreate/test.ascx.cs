using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Student.Batch.StudentDisplay.Students.StudentCreate
{
    public partial class test : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var has = FileUpload1.HasFile;
        }
    }
}