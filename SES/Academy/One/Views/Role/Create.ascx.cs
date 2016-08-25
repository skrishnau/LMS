using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Role
{
    public partial class Create : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.User())
            {
                var role = new Academic.DbEntities.User.Role()
                {
                    RoleName = txtName.Text
                    , Description = txtDescription.Text
                    //,IsActive = chkActive.Checked
                    
                };
                if (Values.Session.GetSchool(Session) > 0)
                {
                    role.SchoolId = Values.Session.GetSchool(Session);
                }
                var s = helper.AddOrUpdateRole(role);
                if (s)
                {
                    Page.Response.Write("Save successful");
                }
                else
                    Page.Response.Write("Error while saving.");
            }
        }
    }
}