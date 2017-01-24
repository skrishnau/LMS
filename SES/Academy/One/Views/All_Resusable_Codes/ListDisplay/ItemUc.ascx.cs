using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.All_Resusable_Codes.ListDisplay
{
    public partial class ItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// item.IdInString,item.Name,item.Value
        /// </summary>
        /// <param name="url">IdInString</param>
        /// <param name="heading">Name</param>
        /// <param name="description">Value</param>
        public void SetValues(string url, string heading, string description)
        {
            lnk.NavigateUrl = url;
            lblHeading.Text = heading;
            lblDescription.Text = description;
            lblUrl.Text = ConvertRelativeUrlToAbsoluteUrl(url);
        }
        public string ConvertRelativeUrlToAbsoluteUrl(string relativeUrl)
        {
            return string.Format("http{0}://{1}{2}",
                (Request.IsSecureConnection) ? "s" : "",
                Request.Url.Host,
                Page.ResolveUrl(relativeUrl)
            );
        }
    }
}