using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Url
{
    public partial class UrlView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var helper = new DbHelper.ActAndRes())
                {
                    var urlId = Request.QueryString["arId"];
                    var url = helper.GetUrlResource(Convert.ToInt32(urlId));
                    if (url != null)
                    {
                        //lblHeading.Text = page.Name;
                        //lblTitle.Text = page.Name;
                        //lblContent.Text = page.PageContent;

                        switch (url.Display)
                        {
                            case 0:
                            case 1:
                                iframe.Attributes.Add("src", url.Url);
                                lblHeading.Text = url.Name;
                                lnkUrl.Text = url.Url;
                                lnkUrl.NavigateUrl = url.Url;
                                break;
                            case 2:
                                Response.Redirect(url.Url);
                                break;
                            case 3:
                                var subId = Request.QueryString["SubId"];
                                var secId = Request.QueryString["secId"];
                                if (subId != null && secId != null)
                                {
                                    var suId = Convert.ToInt32(subId);
                                    var seId = Convert.ToInt32(secId);
                                    Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(suId,
                                        seId));
                                }
                                else
                                {
                                    lnkUrl.Text = "Insufficient parameters";
                                }
                                break;
                        }
                    }
                }
            }
        }


    }
}