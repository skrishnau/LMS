using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.User
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    UserCreateUC.SchoolId = user.SchoolId; //Values.Session.GetSchool(Session);
                    LoadSitemap();

                    var uId = Request.QueryString["uId"];
                    if (uId != null)
                    {
                        var userId = Convert.ToInt32(uId);
                        UserCreateUC.UserId = userId;

                    }

                }
            }
            AsyncFileUpload1.Style.Add("visibility", " hidden");
        }

        void LoadSitemap()
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
                                Name = SiteMap.CurrentNode.ParentNode.Title
                                ,Value = SiteMap.CurrentNode.ParentNode.Url
                                ,Void=true
                            },
                            new IdAndName()
                            {
                                Name = SiteMap.CurrentNode.Title
                            }
                        };
                SiteMapUc.SetData(list);
            }
        }
    }
}