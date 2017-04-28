using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TreeViewTest.TreeViewTest
{
    public partial class treeviewWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TreeView1.TreeNodeCheckChanged+=TreeView1_TreeNodeCheckChanged;
            }
        }

        protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
        {
           
        }

        private void CheckChildNodes(TreeNode node)
        {
            foreach (TreeNode childNode in node.ChildNodes)
            {
                childNode.Checked = node.Checked;
                CheckChildNodes(childNode);
            }
        }

        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            CheckChildNodes(e.Node);
        }
    }
}