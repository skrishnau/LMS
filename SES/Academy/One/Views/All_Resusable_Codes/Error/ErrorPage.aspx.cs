using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.All_Resusable_Codes.Error
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var retUrl = Request.QueryString["returl"];
            var error = Request.QueryString["error"];
            if (retUrl == null)
            {
                btnTryGoingToSamePage.Visible = false;
            }
            //error code descrimination
            if (error != null)
            {
                lblError.Text = DbHelper.StaticValues.Decode(error);
            }

        }

        protected void btnTryGoingToSamePage_OnClick(object sender, EventArgs e)
        {
            var retUrl = Request.QueryString["returl"];
            if (retUrl != null)
            {
                var qs = Request.QueryString.ToString().Replace("returl=", "");

                var queries = qs.Split(new char[] { '&' });
                var i = 0;
                foreach (var q in queries)
                {
                    if (i > 0)
                        retUrl += "&" + q;
                    i++;
                }

                Response.Redirect(retUrl);
            }
        }

        protected void btnGoToDashBoard_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}