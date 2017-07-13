using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Course
{
    public partial class CategoryCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Create1.SaveClicked += CreateUC_SaveClicked;
            //Create1.CancelClicked += CreateUC_SaveClicked;
            if (!IsPostBack)
            {
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
                                        ,Void=true
                                    },
                            new IdAndName(){
                                Name = SiteMap.CurrentNode.ParentNode.Title
                                ,Value = SiteMap.CurrentNode.ParentNode.Url
                                ,Void=true
                            },
                            new IdAndName()
                            {
                                Name = "Category edit"
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    Create1.SchoolId = user.SchoolId;
                    var catId = Request.QueryString["catId"];
                    if (catId != null)
                    {
                        Create1.ParentCategoryId = Convert.ToInt32(catId);
                        
                    }
                }
            }
        }

        //void CreateUC_SaveClicked(object sender, Academic.DbHelper.MessageEventArgs e)
        //{
        //    Response.Redirect("~/Views/Course/?catId=" + ((e.SaveSuccess) ? e.SavedId : Create1.ParentCategoryId));
        //}
    }
}