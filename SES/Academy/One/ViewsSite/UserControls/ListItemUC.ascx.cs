using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.ViewsSite.UserControls
{
    public partial class ListItemUC : System.Web.UI.UserControl
    {
        public TextAndLink TextAndLink { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.HyperLink1.Text = TextAndLink.Text;
        }

        public ListItemUC()
        {
            //this.TextAndLink = tl;
            //var page = GetParentPage();
            //InitializeAsUserControl(Page);
        }

        public HyperLink _HyperLikLink
        {
            get { return this.HyperLink1; }
            set
            {
                value.Visible = true;
                value.Width = 150;
                
                this.HyperLink1 = value;
            }
        }

        protected Page GetParentPage(Control control)
        {
            if (this.Parent is Page)
                return (Page)this.Parent;

            return GetParentPage(this.Parent);
        }
        public void SetNavigationUrl(string text)
        {
            HyperLink1.NavigateUrl = text;
        }

        public string GetNavigationUrl()
        {
            return HyperLink1.NavigateUrl;
        }

        public void SetDisplayText(string text)
        {

            HyperLink1.Text = text;

        }

        public string GetDisplayText()
        {
           return HyperLink1.Text;
        }
    }
}