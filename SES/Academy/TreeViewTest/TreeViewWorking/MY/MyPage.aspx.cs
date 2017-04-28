using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TreeViewTest.TreeViewWorking.MY
{
    public partial class MyPage : System.Web.UI.Page
    {
        Hashtable htFav = new Hashtable();
        List<string> list = new List<string>()
            {
                "One","Two","Three","Four","Five","Six"
            };
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var s in list)
            {
                htFav.Add(s,true);
            }
            if (!IsPostBack)
            {
                FillTree();
            }
        }

        protected void Node_Selected(object sender, EventArgs e)
        {
            MyTreeView tv = (MyTreeView) sender;
            string sSelectedUrl = tv.SelectedNode.Value;
            if (htFav[sSelectedUrl] != null)
            {
                
            }

        }

        private void FillTree()
        {
            myTreeView1.Nodes.Clear();

            foreach (var s in htFav.Keys)
            {
                var node = new MyTreeNode(s.ToString(),"www.google.com",(bool)htFav[s]);
                node.CheckChanged += node_CheckChanged;
                myTreeView1.Nodes.Add(node);

            }

            myTreeView1.ExpandAll();
        }

        void node_CheckChanged(object sender, EventArgs e)
        {
            MyTreeNode node = (MyTreeNode) sender;
            
           Response.Write("Node: "+node.CheckBoxId+"  "+node.Checked.ToString());
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("Outer check changed"+CheckBox1.Checked.ToString());
        }

        protected void btnInvoke_Click(object sender, EventArgs e)
        {
            var nodes = myTreeView1.Nodes;
           var enu = nodes.GetEnumerator();
            while (enu.MoveNext())
            {
                var s  = (MyTreeNode) enu.Current;
                Response.Write(s.Text+" --> "+s.Checked);
            }
        }


    }
}