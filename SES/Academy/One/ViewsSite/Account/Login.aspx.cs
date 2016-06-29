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
                    //can't use redirect here.. because every time a page is requested it is called so we can't 
                    //go to any other page.
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");//"~/ViewsSite/Default.aspx");                    
                }
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            var viewmodel = new Users()
            {
                UserName = Login1.UserName.Trim()
                ,
                Password = Login1.Password.Trim()
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
                if(acchelper.CheckUser(viewModel.UserName,viewModel.Password))
                {
                    using(var acaHelper = new DbHelper.AcademicYear())
                    using (var helper = new DbHelper.User())
                    {
                        var user = helper.Users.First(u => u.UserName == viewModel.UserName);

                        CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                        serializeModel.Id = user.Id;
                        serializeModel.FirstName = user.FirstName;
                        serializeModel.LastName = user.LastName;
                        
                        serializeModel.SchoolId = user.SchoolId;
                        var  acaId = acaHelper.GetCurrentAcademicYear(user.SchoolId);
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
                            Response.Redirect("~/ViewsSite/Default.aspx");
                        }
                    }
                }
            }
        }
    }
}