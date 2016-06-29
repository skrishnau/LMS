using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.ViewsSite.UserControls
{
    public partial class LeftSideBar : System.Web.UI.UserControl
    {
        public List<TextAndLink> TextAndLinks { get; set; }
        public List<TreeNode> TreeNodes { get; set; } 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (var tl in TextAndLinks)
                {
                    //var listItem = new ListItemUC();
                    //listItem.TextAndLink = tl;
                    //listItem._HyperLikLink = new HyperLink();
                    //listItem.Visible = true;
                    //listItem.SetDisplayText(tl.Text);
                    //listItem.SetNavigationUrl(tl.Link);
                    HyperLink hlink = new HyperLink();
                    hlink.Visible = true;
                    hlink.NavigateUrl = tl.Link;
                    hlink.Text = tl.Text;
                    //hlink.Target = tl.Link;
                    hlink.Width = 140;
                    PlaceHolder1.Controls.Add(hlink);

                }
                var owner = new TreeNode("Administration");
                Values.Session.GetAdminTreeNodes(ref owner);

                TreeView1.Nodes.Add(owner);
            }
        }

        public void PopulateList(List<TextAndLink> textAndLinks)
        {
            TextAndLinks = textAndLinks;
            ////PlaceHolder1.Controls.Clear();
            ////foreach (var tl in textAndLinks)
            ////{
            ////    var listItem = new ListItemUC();
            ////    listItem._HyperLikLink = new HyperLink();
            ////    listItem.Visible = true;
            ////    listItem.SetDisplayText(tl.Text);
            ////    listItem.SetNavigationUrl(tl.Link);
            ////    PlaceHolder1.Controls.Add(listItem);
            ////}
            //foreach (var tl in textAndLinks)
            //{
            //    HyperLink hlink = new HyperLink();
            //    hlink.Visible = true;
            //    hlink.NavigateUrl = tl.Link;
            //    hlink.Text = tl.Text;
            //    hlink.Target = tl.Link;
            //    hlink.Width = 140;
            //    PlaceHolder1.Controls.Add(hlink);
            //}
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            
            //var node = (TreeView)sender;
            //if (node != null)
            {

               TreeView1.SelectedNode.Expanded = true;
                if(!string.IsNullOrEmpty(TreeView1.SelectedNode.Value))
                    Response.Redirect(TreeView1.SelectedNode.Value);
            }
        }

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            //TreeNode node = e.Node;
            
            //if (node != null)
            //{
            //    node.Expanded = true;
            //    if (!string.IsNullOrEmpty(node.Value))
            //        Response.Redirect(node.Value);
            //}
        }
    }
}