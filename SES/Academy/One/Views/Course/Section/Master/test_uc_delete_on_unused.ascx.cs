using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.Section.Master
{
    public partial class test_uc_delete_on_unused : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write("hello");
            }
        }

        public string S { get; set; }
        public string S1 { get { return hidId.Value; } set { hidId.Value = value; } }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //string url = "~/Views/Course/Section/CreateSection.aspx";
            string url = "~/Views/Course/List.aspx";
            Server.Transfer(url);
        }
    }
}