using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //show notice in between
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                  if (SiteMap.CurrentNode != null)
                  {
                      var list = new List<IdAndName>()
                        {
                           new IdAndName(){
                                        Name=SiteMap.RootNode.Title
                                       // ,Value =  SiteMap.RootNode.Url
                                    },
                        };
                      SiteMapUc.SetData(list);
                  }
                var noticeBoardUc = (ViewsSite.User.ModulesUc.NoticeBoardUc)
                                          Page.LoadControl("~/ViewsSite/User/ModulesUc/NoticeBoardUc.ascx");
                noticeBoardUc.UserId = user.Id;
                noticeBoardUc.SchoolId = user.SchoolId;
                pnlBody.Controls.Add(noticeBoardUc);
            }



            //earlier code
            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/ViewsSite/Account/Login.aspx");
            //}
            //if (!IsPostBack)
            //{
            //    var loadType = Request.QueryString["type"];

            //    LstUc1.LoadType = loadType;

            //    var user = Page.User as CustomPrincipal;
            //    if (user != null)
            //    {
            //        if (SiteMap.CurrentNode != null)
            //        {
            //            var list = new List<IdAndName>()
            //            {
            //               new IdAndName(){
            //                            Name=SiteMap.RootNode.Title
            //                           // ,Value =  SiteMap.RootNode.Url
            //                        },
            //            };
            //            SiteMapUc.SetData(list);
            //        }
            //        //LstUc1.SchoolId = user.SchoolId;//Values.Session.GetSchool(Session);
            //        LstUc1.UserId = user.Id;//Values.Session.GetUser(Session);
            //        LstUc1.AcademicYearId = user.AcademicYearId;//Values.Session.GetAcademicYear(Session);
            //        LstUc1.SessionId = user.SessionId;//Values.Session.GetSession(Session);
            //        LstUc1.UserType = "student";
            //    }
            //    else
            //    {
            //        //logout the user

            //    }


            //}
        }
    }
}