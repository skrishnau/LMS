using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;
using One.ViewsSite.User.ModulesUc;

namespace One.ViewsSite.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            {

                var user = Page.User as CustomPrincipal;
                var loginUrl = "ViewsSite/Account/Login.aspx";
                if (user != null)
                {
                    //check for school
                    if (!IsPostBack)
                    {
                        //using(var fileHelper = new DbHelper.WorkingWithFiles())
                        using (var helper = new DbHelper.Office())
                        {
                            var school = helper.GetSchoolOfUser(user.Id);
                            if (school != null)
                            {
                                //imgSchool.ImageUrl = "~/Content/Images/"
                                //imgSchool.ImageUrl = fileHelper.
                                lblSchoolName.Text = school.Name;
                            }
                        }
                    }

                    UpdateLoginTime(user.Id);

                    CoursesUc.UserId = user.Id;
                    EarlierUc.UserId = user.Id;
                    if (user.IsInRole("manager"))
                    {
                        var schoolCreateUrl = "Views/Office/School/Create.aspx";
                        var isSchoolUrl = Request.Url.AbsolutePath.Contains(schoolCreateUrl);
                        if (user.SchoolId <= 0 && !isSchoolUrl)
                        {
                            Response.Redirect("~/" + schoolCreateUrl);
                        }

                        SettingsUc settings =
                            (SettingsUc)Page.LoadControl("~/ViewsSite/User/ModulesUc/SettingsUc.ascx");
                        settings.UserId = user.Id;
                        pnlSettings.Controls.Add(settings);
                    }
                }
                else if (!Request.Url.AbsolutePath.Contains(loginUrl))
                {
                    Response.Redirect("~/" + loginUrl);
                }

            }
        }
        void UpdateLoginTime(int userId)
        {
            using (var helper = new DbHelper.User())
            {
                helper.UpadateUsersLoginTime(userId);
            }
        }
    }
}