using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class NoticeItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetData(string url, string name, string postedOn,bool isNew)
        {
            lnkNotice.NavigateUrl = url;
            lblName.Text = name;
            lblPostedOn.Text = postedOn;
            imgNewIndicator.Visible = isNew;
        }
    }
}