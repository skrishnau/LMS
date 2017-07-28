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
    public partial class About : Page
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
                    lnkEdit.Visible = (Session["editMode"] as string) == "1";
                    SiteMapUc.SetData(new List<IdAndName>()
                    {
                        new IdAndName(){Name = "About"}
                    });
                    
                }
                using (var helper = new DbHelper.Office())
                {
                    var school = helper.GetSchoolOfUser(user==null?0:user.SchoolId);
                    lblDescription.Text = school.Description;
                }


            }
        }
    }
}