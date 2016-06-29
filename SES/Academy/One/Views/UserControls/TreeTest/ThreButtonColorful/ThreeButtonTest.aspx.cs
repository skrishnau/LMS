using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.UserControls.TreeTest.ThreButtonColorful
{
    public partial class ThreeButtonTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NodeUC1.LabelText = "Root";
            NodeUC1.Level = 0;
            for (int i = 0; i < 2; i++)
            {
                NodeUc uc =
                    (NodeUc)Page.LoadControl("~/Views/UserControls/TreeTest/ThreButtonColorful/NodeUc.ascx");

                uc.LabelText = "i=" + i.ToString();
                uc.Level = 1;
                for (int j = 0; j < 3; j++)
                {
                    NodeUc innerUc =
                    (NodeUc)Page.LoadControl("~/Views/UserControls/TreeTest/ThreButtonColorful/NodeUc.ascx");
                    innerUc.LabelText = "j=" + j.ToString();
                    innerUc.Level = 2;
                    uc.AddNode(innerUc);

                }
                NodeUC1.AddNode(uc);
                //Nodes.Controls.Add(uc);
            }
        }


        public int AcademicYearId { get; set; }
        public int SchoolId { get; set; }
    }
}