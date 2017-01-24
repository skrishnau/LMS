using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;
using WebGrease.Css.Extensions;

namespace One.Views.Search
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (!IsPostBack)
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
                                Name = SiteMap.CurrentNode.Title
                                //,Value = SiteMap.CurrentNode.ParentNode.Url
                                //,Void=true
                            }
                        };
                        SiteMapUc.SetData(list);
                    }

                    //search process
                    var searchText = Request.QueryString["input"];
                    //var full = "";
                    var words = searchText.Split(new char[] { ' ' });
                    var newWords = words.Where(x => !(string.IsNullOrEmpty(x))).ToArray();
                    if (!newWords.Any())
                    {
                        return;
                    }
                    lblHeading.Text = searchText;
                    using (var helper = new DbHelper.Search())
                    {
                        var searchedList = helper.SearchCourse(newWords, user.SchoolId);
                        foreach (var item in searchedList)
                        {
                            var uc =
                                (All_Resusable_Codes.ListDisplay.ItemUc)
                                    Page.LoadControl("~/Views/All_Resusable_Codes/ListDisplay/ItemUc.ascx");
                            uc.SetValues(item.IdInString, item.Name, item.Value);
                            pnlSearchResult.Controls.Add(uc);
                        }
                        if (searchedList.Any())
                        {
                            lblEmptyData.Visible = false;
                        }
                    }
                }
        }
    }
}