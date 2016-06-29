using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.UserControls.TreeTest.ThreButtonColorful
{
    public partial class NodeUc : System.Web.UI.UserControl
    {
        private DropDownTreeView dropDownTreeView1;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void AddNode(NodeUc uc)
        {
            //NodeUC innerUc =
            //        (NodeUC)Page.LoadControl("~/Views/Academy/CurrentAcademicYear/NodeUC.ascx");
            //innerUc.Text.Text =  text;
            uc.Parent = this;
            this.phNodes.Controls.Add(uc);
        }

        public NodeUc Parent { get; set; }

        public int Level
        {
            get { return Convert.ToInt32(hidLevel.Value); }
            set { hidLevel.Value = value.ToString(); }
        }

        public string LabelText
        {
            get { return txtTitle.Text; }
            set { this.txtTitle.Text = value; }
        }
    }
}