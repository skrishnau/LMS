using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Office
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = User as CustomPrincipal;// Master.UserId;
            //var schoolId = Master as UserMaster;//
            //if(schoolId!=null)
            if (user != null)
            {
                if (user.SchoolId <= 0)
                {
                    Response.Redirect("Create.aspx");
                }
                else
                {
                    //display school info
                    DisplaySchoolInfo(user.Id);
                    if (user.IsInRole(DbHelper.StaticValues.Roles.Manager))
                    {
                        var link = new HyperLink()
                        {
                            Text = "Edit"
                            ,
                            NavigateUrl = "~/Views/Office/School/Create.aspx"

                        };
                        divMenu.Controls.Add(link);
                    }
                }
            }
        }

        private void DisplaySchoolInfo(int userId)
        {
            using (var helper = new DbHelper.Office())
            {
                var school = helper.GetSchoolOfUser(userId);
                if (school != null)
                {
                    if (SiteMap.CurrentNode != null)
                    {
                        var list = new List<IdAndName>()
                        {
                           new IdAndName(){
                                        Name=SiteMap.RootNode.Title
                                        ,Value =  SiteMap.RootNode.Url
                                        ,Void=true
                                    },
                            new IdAndName(){
                                Name = school.Name
                                //,Value = SiteMap.CurrentNode.ParentNode.Url
                                //,Void=true
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    lblName.Text = school.Name;
                    //lblSchoolName.Text = school.Name;
                    //lblSchoolType.Text = school.SchoolType == null ? "" : school.SchoolType.Name;
                    //lblCity.Text = string.IsNullOrEmpty(school.City)?"N/A":school.City;
                    lblCountry.Text = string.IsNullOrEmpty(school.Address)?"N/A":school.Address;
                    lblEmail.Text = string.IsNullOrEmpty(school.EmailGeneral)?"N/A":school.EmailGeneral;
                    lblWebsite.Text = string.IsNullOrEmpty(school.Website)?"N/A":school.Website;
                    lblPhoneNo.Text = string.IsNullOrEmpty(school.PhoneMain)?"N/A":school.PhoneMain;
                }
            }
        }
    }
}