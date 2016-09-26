using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Test
{
    public partial class FileUploadCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void btnAsyncUpload_Click(object sender, EventArgs e)
        {
            bool hasfile = (FileUpload1.HasFile);

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            bool hasfile = (FileUpload1.HasFile);

        }
    }
}