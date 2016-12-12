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
            {
                var user = Page.User as CustomPrincipal;
                var loginUrl = "ViewsSite/Account/Login.aspx";
                if (user != null)
                {
                    EarlierUc.EmptyData += EarlierUc_EmptyData;
                    //check for school
                    UserId = user.Id;
                    SchoolId = user.SchoolId;
                    if (!IsPostBack)
                    {
                        //using(var fileHelper = new DbHelper.WorkingWithFiles())
                        CoursesUc.UserId = user.Id;
                        EarlierUc.UserId = user.Id;

                        NoticeBoardUc.UserId = user.Id;
                        EventsUc.UserId = user.Id;
                        using (var helper = new DbHelper.Office())
                        {
                            var school = helper.GetSchoolOfUser(user.Id);
                            if (school != null)
                            {
                                NoticeBoardUc.SchoolId = school.Id;
                                EventsUc.SchoolId = school.Id;
                                OnlineUsersUc.UserId = user.Id;
                                OnlineUsersUc.SchoolId = school.Id;
                                //imgSchool.ImageUrl = "~/Content/Images/"
                                lblSchoolName.Text = school.Name;
                                SchoolId = user.SchoolId;
                                var f = helper.GetSchoolImage(school.ImageId);
                                if (f != null)
                                    imgSchool.ImageUrl = f.FileDirectory + f.FileName;
                            }
                        }
                        if (Request.Url.AbsolutePath.Contains("BookView")
                            ||Request.Url.AbsolutePath.Contains("Create"))
                        {
                            right_panel.Visible = false;
                        }
                    }

                    UpdateLoginTime(user.Id);

                    
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
                        //settings.UserId = user.Id;
                        pnlSettings.Controls.Add(settings);
                    }
                    else if (user.IsInRole("teacher"))
                    {
                        SettingsTeacher teachersettings =
                           (SettingsTeacher)Page.LoadControl("~/ViewsSite/User/ModulesUc/SettingsTeacher.ascx");
                        //settings.UserId = user.Id;
                        pnlSettings.Controls.Add(teachersettings);
                    }
                }
                else if (!Request.Url.AbsolutePath.Contains(loginUrl))
                {
                 //+"?ReturnUrl="+Page.Request.Url.PathAndQuery   
                    Response.Redirect("~/" + loginUrl + "?ReturnUrl=" + Page.Request.Url.PathAndQuery);
                }

            }
        }

        void EarlierUc_EmptyData(object sender, EventArgs e)
        {
            EarlierUc.Visible = false;
        }

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
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