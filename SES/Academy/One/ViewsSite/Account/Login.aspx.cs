using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.User;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.ViewsSite.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //need to  work out... 
            //when the user is logged-in but going to unauthorized page redirects to the dashboard page
            //same page forever...need to work out 
            //if (!IsPostBack)
            //{
            //    if (User.Identity.IsAuthenticated)
            //    {
            //        var role = User.Identity.
            //        string returnUrl = Request.QueryString["ReturnUrl"] as string;
            //        if (returnUrl != null)
            //        {
            //            if (returnUrl.Contains("DashBoard%2fStudent") && roles.Contains("student"))
            //            {

            //            }
            //        }
            //    }
            //}
            //for test only
            //SqlMembershipProvider provider = new SqlMembershipProvider();
            //HttpContext.Current.User.

            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = User as CustomPrincipal;
                    if (user != null)
                    {
                        //var reurl = FormsAuthentication.GetRedirectUrl(user.UserName, true);
                        //if (!string.IsNullOrEmpty(reurl))
                        //{
                        //    UpdateLoginTime(user.Id);
                        //    //FormsAuthentication.RedirectFromLoginPage(user.UserName,true);
                        //    Response.Redirect(reurl);
                        //}
                        //else
                        {
                            string returnUrl = Request.QueryString["ReturnUrl"] as string;
                            if (returnUrl != null)
                            {
                                UpdateLoginTime(user.Id);
                                var qs = Request.QueryString.ToString().Replace("ReturnUrl=", "");

                                var queries = qs.Split(new char[] { '&' });
                                var i = 0;
                                foreach (var q in queries)
                                {
                                    if (i > 0)
                                        returnUrl += "&" + q;
                                    i++;
                                }
                                Response.Redirect(returnUrl);
                            }
                            else
                            {
                                Response.Redirect("~/");
                            }
                        }
                    }
                    //can't use redirect here.. because every time a page is requested it is called so we can't 
                    //go to any other page.
                }
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            var viewmodel = new Users()
            {
                UserName = Login1.UserName.Trim()
                ,
                Password = Login1.Password
            };
            UserLogin(viewmodel);
            /*{
                List<string> roles;
                string username = Login1.UserName.Trim();

                using (var helper = new DbHelper.CustomAccount())
                {
                    var authenticate = helper.CheckUser(username, Login1.Password.Trim());
                    if (authenticate)
                    {
                        Session["User"] = username;
                        roles = helper.GetUserRoles(username);
                        Session["Roles"] = roles;

                        //set the authentication cookie so that we can use that later.
                        FormsAuthentication.SetAuthCookie(username, true);

                        //Login successful lets put him to requested page
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
                            Response.Redirect("~/ViewsSite/Default.aspx");
                        }
                    }
                    else
                    {

                    }
                }
            }*/
        }

        public void UserLogin(Users viewModel)
        {
            using (var acchelper = new DbHelper.CustomAccount())
            {
                //if (Membership.ValidateUser(viewModel.UserName, viewModel.Password))
                var user = acchelper.GetUser(viewModel.UserName, viewModel.Password);
                if (user != null)
                {
                    using (var acaHelper = new DbHelper.AcademicYear())
                    using (var helper = new DbHelper.User())
                    {
                        //var user = foundUser;//helper.Users.First(u => u.UserName == viewModel.UserName);

                        CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                        serializeModel.Id = user.Id;
                        serializeModel.UserName = user.UserName;
                        serializeModel.FirstName = user.FirstName;
                        serializeModel.LastName = user.LastName;
                        serializeModel.SchoolId = user.SchoolId ?? 0;
                        serializeModel.TestString = "kkkkk";

                        var sess = acaHelper.GetCurrentSession();
                        if (sess != null)
                        {
                            serializeModel.AcademicYearId = sess.AcademicYearId;
                            serializeModel.SessionId = sess.Id;
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

                        //var reurl = FormsAuthentication.GetRedirectUrl(viewModel.UserName, true);
                        //if (!string.IsNullOrEmpty(reurl))
                        //{
                        //    UpdateLoginTime(user.Id);
                        //    //FormsAuthentication.RedirectFromLoginPage(user.UserName, true);
                        //    Response.Redirect(reurl);
                        //}
                        //else
                        {

                            //FormsAuthentication.set
                            //return RedirectToAction("Index", "Home");
                            string returnUrl = Request.QueryString["ReturnUrl"] as string;



                            if (returnUrl != null)
                            {
                                //if (returnUrl.Contains("DashBoard%2fStudent") && roles.Contains("student"))
                                //{
                                //}

                                UpdateLoginTime(user.Id);

                                var qs = Request.QueryString.ToString().Replace("ReturnUrl=", "");
                                var queries = qs.Split(new char[] { '&' });
                                var i = 0;
                                foreach (var q in queries)
                                {
                                    if (i > 0)
                                        returnUrl += "&" + q;
                                    i++;
                                }

                                Response.Redirect(returnUrl);
                            }
                            else
                            {
                                //Response.Redirect("~/ViewsSite/Default.aspx");
                                UpdateLoginTime(user.Id);
                                Response.Redirect("~/");
                            }
                        }
                    }
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