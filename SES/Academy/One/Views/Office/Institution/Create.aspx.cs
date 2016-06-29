using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.InitialValues;

namespace One.Views.Office.Institution
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMsg.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            if(!Page.IsValid)
                return;
            int id = Convert.ToInt32(txtId.Value);
            var entity = new Academic.DbEntities.Office.Institution()
             {
                 Id = id
                 ,
                 Name = txtName.Text
                 ,
                 Country = txtCountry.Text
                 ,
                 City = txtCity.Text
                 ,
                 Street = txtStreet.Text
                 ,
                 Email = txtEmail.Text
                 ,
                 Website = txtWebsite.Text
                 ,
                 PanNo = txtPanNo.Text
                 ,
                 PostalCode = txtPostal.Text
                 ,
                 Category = txtCategory.Text
                 ,
                 Moto = txtMoto.Text
                 ,
                 UserId = InitialValues.CustomSession["UserId"]

             };

            string msg = "Successful";

            using (var helper = new DbHelper.Office())
            using (var filehelper = new DbHelper.WorkingWithFiles())
            {

                HttpPostedFile file = null;

                if (FileUpload1.HasFile)
                {
                    file = FileUpload1.PostedFile;
                }
                var added = helper.AddOrUpdateInstitution(entity, file);
                if (added != null)
                {
                    if (id == 0)
                    {
                        msg = "Save " + msg;
                    }
                    else
                    {
                        msg = "Update " + msg;
                    }
                }
                else
                {
                    msg = "Sorry! Save Error.";
                }
                lblMsg.Visible = true; 
                lblMsg.Text = msg;
                //Server.Transfer("~/Views/Office/School/Create.aspx", true);
                Session["InstId"] = (added==null)?0:added.Id;
                Response.Redirect("~/Views/Office/School/Create.aspx");
            }
          
        }
    }
}