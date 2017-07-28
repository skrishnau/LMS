using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Page
{
    public partial class PageView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var helper = new DbHelper.ActAndRes())
                {
                    var pageId = Request.QueryString["arId"];
                    var page = helper.GetPageResource(Convert.ToInt32(pageId));
                    if (page != null)
                    {
                        lblHeading.Text = page.Name;
                        lblTitle.Text = page.Name;
                        lblContent.Text = page.PageContent;
                       
                    }
                }
            }
        }
    }
}