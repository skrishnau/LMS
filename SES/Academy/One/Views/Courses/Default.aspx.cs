using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Courses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var loadType = Request.QueryString["type"];
                var curNode = new IdAndName() { Name = "Current courses" };
                LstUc1.LoadType = loadType;

                if (loadType == "earlier")
                {
                    lblHeading.Text = "Earlier courses";
                    lblTitle.Text = "Earlier courses";
                    curNode.Name = "Earlier courses";
                    lnkGoto.Text = "Go to current courses";
                    lnkGoto.NavigateUrl = "~/Views/Courses/?type=current";
                }
                else
                {
                    lblHeading.Text = "Current courses";
                    lblTitle.Text = "Current courses";
                    lnkGoto.Text = "Go to earlier courses";
                    lnkGoto.NavigateUrl = "~/Views/Courses/?type=earlier";
                }
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    if (SiteMap.CurrentNode != null)
                    {
                        var list = new List<IdAndName>()
                        {
                           new IdAndName(){
                                        Name=SiteMap.RootNode.Title
                                        ,Value =  SiteMap.RootNode.Url
                                        ,Void = true
                                    },
                                    curNode
                        };
                        SiteMapUc.SetData(list);
                    }
                    //LstUc1.SchoolId = user.SchoolId;//Values.Session.GetSchool(Session);
                    LstUc1.UserId = user.Id;//Values.Session.GetUser(Session);
                    LstUc1.AcademicYearId = user.AcademicYearId;//Values.Session.GetAcademicYear(Session);
                    LstUc1.SessionId = user.SessionId;//Values.Session.GetSession(Session);
                    LstUc1.UserType = "student";
                }
                else
                {
                    //logout the user

                }


            }
        }
    }
}