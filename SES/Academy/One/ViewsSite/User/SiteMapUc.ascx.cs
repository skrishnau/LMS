using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.ViewsSite.User
{
    public partial class SiteMapUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// value= link (url), Name = display name
        /// </summary>
        /// <param name="sites"></param>
        public void SetData(List<IdAndName> sites)
        {
            //sites.Insert(0,new IdAndName()
            //{
            //    Name=SiteMap.RootNode.Title
            //    ,Value =  SiteMap.RootNode.Url
            //    ,Void=true
            //});
            ListView1.DataSource = sites;
            ListView1.DataBind();
        }
    }
}