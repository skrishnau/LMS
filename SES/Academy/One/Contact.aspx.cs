using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user == null)
                {
                    loginDiv.Visible = true;
                }
                else
                {
                    SiteMapUc.SetData(new List<IdAndName>()
                    {
                        new IdAndName(){Name = "Contact"}
                    });
                }
                using (var helper = new DbHelper.Office())
                {
                    var school = helper.GetSchoolOfUser(user == null ? 0 : user.SchoolId);
                    lblAddress.Text = school.Address;
                    lblPhoneAfterHours.Text = school.PhoneAfterHours;
                    lblPhoneMain.Text = school.PhoneMain;
                    lnkEmailGeneral.Text = school.EmailGeneral;
                    lnkEmailGeneral.NavigateUrl = "mailto:" + school.EmailGeneral;

                    lnkEmailMarketing.Text = school.EmailMarketing;
                    lnkEmailMarketing.NavigateUrl = "mailto:" + school.EmailMarketing;

                    lnkEmailSupport.Text = school.EmailSupport;
                    lnkEmailSupport.NavigateUrl = "mailto:" + school.EmailSupport;
                }
            }
        }
    }
}