using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TreeViewTest.TreeViewWorking.MY
{
    public class MyTreeView:TreeView
    {
        protected override TreeNode CreateNode()
        {
            return new MyTreeNode();
        }
    }
}