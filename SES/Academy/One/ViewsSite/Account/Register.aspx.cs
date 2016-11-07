using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.User;
using One.Values.MemberShip;

namespace One.ViewsSite.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CreateUserWizard1.
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    MultiView1.ActiveViewIndex = 1;
                }
                ddlSecurityQuestion.DataSource = DbHelper.StaticValues.SecurityQuestion();
                ddlSecurityQuestion.DataBind();
            }
            lblPasswordError.Visible = false;
        }

        protected void btnCreate_Clicked(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblPasswordError.Text = "Paasword and Confirm Password must match";
                lblPasswordError.Visible = true;
                return;
            }
            if (Page.IsValid)
            {
                var user = new Academic.DbEntities.User.Users()
                {
                    UserName = txtUserName.Text
                    ,
                    Password = txtPassword.Text
                    ,
                    Email = txtEmail.Text
                    ,
                    SecurityAnswer = txtSecurityAnswer.Text
                    ,
                    SecurityQuestion = ddlSecurityQuestion.Text
                };
                using (var helper = new DbHelper.CustomAccount())
                {
                    var success = helper.Register(user);
                    if (success == "success")
                    {
                        UserLogin(user);
                        MultiView1.ActiveViewIndex = 3;
                    }
                    else
                    {
                        lblPasswordError.Visible = true;
                        lblPasswordError.Text = success;
                    }
                }
            }


        }

        //protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        //{

        //    var username = CreateUserWizard1.UserName;
        //    var password = CreateUserWizard1.Password;
        //    var email = CreateUserWizard1.Email;
        //    var que = CreateUserWizard1.Question;
        //    var ans = CreateUserWizard1.Answer;
        //    var user = new Academic.DbEntities.User.Users()
        //    {
        //        UserName = CreateUserWizard1.UserName
        //        ,
        //        Password = CreateUserWizard1.Password
        //        ,
        //        Email = CreateUserWizard1.Email
        //        ,
        //        SecurityQuestion = CreateUserWizard1.Question
        //        ,
        //        SecurityAnswer = CreateUserWizard1.Answer

        //    };

        //    using (var helper = new DbHelper.CustomAccount())
        //    {
        //        var success = helper.Register(user);
        //        if (success)
        //            UserLogin(user);
        //    }
        //}

        public void UserLogin(Users viewModel)
        {
            using (var acchelper = new DbHelper.CustomAccount())
            {
                //if (Membership.ValidateUser(viewModel.UserName, viewModel.Password))
                if (acchelper.CheckUser(viewModel.UserName, viewModel.Password))
                {
                    using (var acaHelper = new DbHelper.AcademicYear())
                    using (var helper = new DbHelper.User())
                    {
                        var user = helper.Users.First(u => u.UserName == viewModel.UserName);

                        CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                        serializeModel.Id = user.Id;
                        serializeModel.FirstName = user.FirstName;
                        serializeModel.LastName = user.LastName;

                        serializeModel.SchoolId = user.SchoolId ?? 0;
                        var acaId = acaHelper.GetCurrentAcademicYear(user.SchoolId ?? 0);
                        if (acaId != null)
                        {
                            serializeModel.AcademicYearId = acaId.Id;
                            var sess = acaHelper.GetCurrentSession(acaId.Id);
                            if (sess != null)
                            {
                                serializeModel.SessionId = sess.Id;
                            }
                            //else
                            //{
                            //    serializeModel.SessionId = 0;
                            //}
                        }

                        JavaScriptSerializer serializer = new JavaScriptSerializer();

                        string userData = serializer.Serialize(serializeModel);

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                            //viewModel.Email,
                            viewModel.UserName,
                            DateTime.Now,

                            DateTime.Now.AddMinutes(15),
                            false,
                            userData);

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);

                        //FormsAuthentication.set
                        //return RedirectToAction("Index", "Home");
                        string returnUrl = Request.QueryString["ReturnUrl"] as string;
                        if (returnUrl != null)
                        {
                            //if (returnUrl.Contains("DashBoard%2fStudent") && roles.Contains("student"))
                            //{

                            //}
                            Response.Redirect(returnUrl);
                        }
                        else
                        {
                            //Response.Redirect("~/ViewsSite/Default.aspx");
                            Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");

                        }
                    }
                }
            }
        }
    }
}