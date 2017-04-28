using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TreeViewTest.TreeViewWorking.MY
{
    public class MyTreeNode:TreeNode
    {
        string NodeText = "";
        string NodeUrl = "";
        private string _chkBoxId = "";
        public event EventHandler<EventArgs> CheckChanged;


        public MyTreeNode()
        {}

        public MyTreeNode(string aText)
        {
            NodeText = aText;
        }

        public MyTreeNode(string aText, string aNavigationUrl, bool isFavourite)
        {
            NodeText = aText;
            NodeUrl = aNavigationUrl;
            if (isFavourite)
            {
                this.ImageUrl = "no.png";
                ImageToolTip = "remove favourite";
            }
            else
            {
                this.ImageUrl = "AddIconSmall.gif";
                ImageToolTip = "Add Favourite";
            }
            this.Text = "";
            this.Value = aNavigationUrl;
            this.SelectAction=TreeNodeSelectAction.Select;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void CheckedChanged(object sender, EventArgs e)
        {
            if (CheckChanged != null)
            {
                CheckChanged(this,new EventArgs());
            }
        }
        CheckBox chkBox = new CheckBox();
        protected override void RenderPreText(HtmlTextWriter writer)
        {
            bool showLink = (!string.IsNullOrEmpty(NodeText)) && (!string.IsNullOrEmpty(NodeUrl));
            //if (NodeText != null && NodeUrl != null)
            //{
            //    showLink = true;
            //}
            //start span
            
            writer.AddAttribute("class","FavouriteURL");
            writer.RenderBeginTag(HtmlTextWriterTag.Span);

            //checkbox
            _chkBoxId = NodeText + "_chk";
            writer.AddAttribute("Id",NodeText+"_chk");
            writer.AddAttribute("type", "checkbox");
            writer.AddAttribute("onclick", "javascript:setTimeout('__doPostBack(\\'CheckBox1\\',\\'\\')', 0)");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);

            if (showLink)
            {
                //start link
                writer.AddAttribute("href",NodeUrl);
                writer.AddAttribute("title","go to page");
                writer.RenderBeginTag(HtmlTextWriterTag.A);
            }
            //writer text
            writer.Write(NodeText);
            if (showLink)
            {
                //finishlink--a tag
                writer.RenderEndTag();
            }
            writer.RenderEndTag();
            base.RenderPreText(writer);
        }

        protected override object SaveViewState()
        {
            object[] arrState = new object[3];
            arrState[0] = base.SaveViewState();
            arrState[1] = this.NodeText;
            arrState[2]=this.NodeUrl;
            return arrState;
        }

        protected override void LoadViewState(object state)
        {
            if (state != null)
            {
                object[] arrState = state as object[];

                this.NodeText = (string)arrState[1];
                this.NodeUrl = (string) arrState[2];
                base.LoadViewState(arrState[0]);

            }
        }

        public string CheckBoxId{get { return _chkBoxId; }}
    }
}