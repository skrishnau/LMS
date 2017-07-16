using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.User
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {

                using (var helper = new DbHelper.User())
                {
                    var uId = Request.QueryString["uId"];
                    var userId = Convert.ToInt32(uId);
                    var us = helper.GetUser(userId);
                    if (us == null)
                    {
                        ReturnToHomePage();
                        return;
                    }

                    lblHeading.Text = us.FullName;
                    lblPageTitle.Text = "User Detail";
                    lblCity.Text = us.City;
                    lblCountry.Text = us.Country;
                    lblDOB.Text = us.DOB.HasValue ? us.DOB.ToString() : "";
                    lblEmail.Text = us.Email;
                    lblFirstName.Text = us.FirstName;
                    lblGender.Text = us.Gender != null ? us.Gender.Name : "";
                    lblLastName.Text = us.LastName;
                    lblMidName.Text = us.MiddleName;
                    lblPhone.Text = us.Phone;
                    lblUserName.Text = us.UserName;
                    //lblStreet.Text = us.;
                    var role = us.UserRoles.Select(x => x.Role.DisplayName).ToList();
                    var rl = "";
                    foreach (var r in role)
                    {
                        rl += r + ", ";
                    }
                    rl = rl.TrimEnd(new char[] { ',', ' ' });
                    rl = rl.TrimEnd(new char[] { ',', ' ' });
                    lblRole.Text = rl;

                    lnkImage.NavigateUrl = us.UserImage != null
                        ? us.UserImage.FileDirectory + us.UserImage.FileName
                        : "";
                    imgPhoto.ImageUrl = lnkImage.NavigateUrl!=""?lnkImage.NavigateUrl:
                        "~/Content/Icons/Users/user-male-52px.png";
                    imgPhoto.AlternateText = "Image not found";

                    var manager = user.IsInRole(DbHelper.StaticValues.Roles.Manager);
                    var edit = (Session["editMode"] as string) == "1";

                    if (manager && edit)
                    {
                        lnkEdit.Visible = true;
                        lnkDeelete.Visible = true;

                        lnkEdit.NavigateUrl = "~/Views/User/Create.aspx?uId=" + us.Id;
                        lnkDeelete.NavigateUrl = "";
                    }
                    else
                    {
                        lnkEdit.Visible = false;
                        lnkDeelete.Visible = false;
                    }




                }

            }
        }

        private void ReturnToHomePage()
        {
            Response.Redirect("~/");
        }

    }
}