using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Class
{
    public partial class DueClasses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                using (var helper = new DbHelper.Notifications())
                {
                    var noTeacher = helper.GetDueClassesNotification(user.SchoolId);
                    DataList1.DataSource = noTeacher;
                    DataList1.DataBind();
                }
            }
            SetSitemap();
        }

        private void SetSitemap()
        {
            var list = new List<IdAndName>();
            list.Add(new IdAndName()
            {
                Name = "Home",
                Value = "~/",
                Void = true,
            });
            list.Add(new IdAndName()
            {
                Name = "Due Classes"
            });
            SiteMapUc.SetData(list);
        }
    }
}