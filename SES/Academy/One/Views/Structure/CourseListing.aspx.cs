using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.Structure
{
    public partial class CourseListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var year = Request.QueryString["yId"];
                var subyear = Request.QueryString["sId"];

                if (year != null && subyear != null)
                {
                    try
                    {
                        var y = Convert.ToInt32(year.ToString());
                        var s = Convert.ToInt32(subyear.ToString());
                        using (var helper = new DbHelper.Structure())
                        {

                            var dir = helper.GetSructureDirectory(y, s);
                            CourseListUC.SetProgramDirectory(dir);
                            var editQuery = Request.QueryString["edit"];
                            var edit = (editQuery ?? "0").ToString();
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
                                        ,Value = SiteMap.CurrentNode.ParentNode.Url+"?edit="+edit
                                        ,Void=true
                                    },
                                    new IdAndName(){Name = dir}
                                };
                                SiteMapUc.SetData(list);
                            }
                            CourseListUC.LoadCourseList(edit, y, s);
                        }
                    }
                    catch { Response.Redirect("~/Views/Structure/All/Master/List.aspx"); }

                }
                else
                {
                    Response.Redirect("~/Views/Structure/All/Master/List.aspx");
                }

                /*var yearId = ViewState["yearId"];
                var subyearId = ViewState["subYearId"];

                //viewsta
                if (yearId == null || subyearId == null)
                {
                    Response.Redirect("List.aspx");
                }
                else
                {
                    var y = Convert.ToInt32(yearId.ToString());
                    var s = Convert.ToInt32(subyearId.ToString());
                    using (var helper = new DbHelper.Structure())
                    {
                        var dir = helper.GetSructureDirectory(y, s);
                        CourseListUC.SetProgramDirectory(dir);
                    }
                    CourseListUC.LoadCourseList(y, s);
                }*/
            }
        }

    }
}