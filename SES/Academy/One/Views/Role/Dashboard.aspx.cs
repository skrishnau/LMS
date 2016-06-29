using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Role
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Create uc = (Create)Page.LoadControl("Create.ascx");
                //PlaceHolder1.Controls.Add(uc);
               
                //var create = new Role.Create();
                //create.InitializeAsUserControl(this);
                //pnlCreate.Controls.Add(create);
            }
        }

        public List<Academic.DbEntities.User.Role> GetRoles()
        {
            using (var helper = new DbHelper.User())
            {
                return helper.GetRole(Values.Session.GetSchool(Session));
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assign.aspx");

        }
    }
}