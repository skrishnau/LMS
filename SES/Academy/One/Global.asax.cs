using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using Academic.DbHelper;
using One;
using One.Values.MemberShip;

namespace One
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if ( cookie != null)
                {
                    try
                    {
                        //let us take out the username now                
                        string username = FormsAuthentication.Decrypt(cookie.Value).Name;

                        //let us extract the roles from our own custom cookie
                        List<string> roles;
                        using (var helper = new DbHelper.CustomAccount())
                        {
                            roles = helper.GetUserRoles(username);                            
                        }
                        
                        //Let us set the Pricipal with our user specific details
                        e.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(username, "Forms"), roles.ToArray());
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                try
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (authTicket != null)
                    {
                        JavaScriptSerializer serializer = new JavaScriptSerializer();

                        CustomPrincipalSerializeModel serializeModel =
                            serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

                        List<string> roles;
                        using (var helper = new DbHelper.CustomAccount())
                        {
                            roles = helper.GetUserRoles(authTicket.Name);
                        }
                        CustomPrincipal newUser = new CustomPrincipal(authTicket.Name,roles.ToArray());
                        if (serializeModel != null)
                        {
                            newUser.Id = serializeModel.Id;
                            newUser.FirstName = serializeModel.FirstName;
                            newUser.LastName = serializeModel.LastName;
                            newUser.UserName = serializeModel.UserName;
                            newUser.SchoolId = serializeModel.SchoolId;
                        }
                        HttpContext.Current.User = newUser;
                        
                    }
                }
                catch (Exception exe)
                {
                    
                }
            }
        }
    }
}
