using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Class
{
    public partial class MyClasses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                try
                {
                    var subId = Request.QueryString["subId"];
                    if (subId != null)
                    {
                        var subjectId = Convert.ToInt32(subId);
                        using (var helper = new DbHelper.Classes())
                        {
                            var subject = helper.GetSubject(subjectId);
                            if (subject != null)
                            {
                                lblSubjectName.Text = subject.FullName;
                                var cls = helper.ListAllClassesOfUserOfSubject(user.Id, subjectId);
                                DataList1.DataSource = cls;
                                DataList1.DataBind();
                            }
                            else
                            {
                                Response.Redirect("~/");
                            }
                            LoadSitemap(subject);
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/");
                }
            }
        }

        void LoadSitemap(Academic.DbEntities.Subjects.Subject sub)
        {
            if (SiteMap.CurrentNode != null)
            {
                var list = new List<IdAndName>()
                                {
                                   new IdAndName(){
                                                Name=SiteMap.RootNode.Title,
                                                Value =  SiteMap.RootNode.Url,
                                                Void=true
                                            },
                                };

                var from = Request.QueryString["from"];
                if (from == "detail")
                {
                    //courses
                    list.Add(new IdAndName()
                    {
                        Name = SiteMap.CurrentNode.ParentNode.ParentNode.Title,
                        Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url,
                        Void = true
                    });
                    //courseName -- detail view
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName,
                        Value = SiteMap.CurrentNode.ParentNode.Url + "?cId=" + (sub.Id),
                        Void = true
                    });
                    //View
                    list.Add(new IdAndName()
                    {
                        Name = "View",//sub.FullName,
                        Value = "~/Views/Course/Section/?SubId="+sub.Id+"&from=detail",
                        //SiteMap.CurrentNode.ParentNode.Url + "?cId=" + (sub.Id),
                        Void = true
                    });
                }
                else if (from == "view")
                {
                    //courseName
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName,
                        Value = "~/Views/Course/Section/?SubId="+sub.Id,
                        //SiteMap.CurrentNode.ParentNode.Url + "?cId=" + (sub.Id),
                        Void = true
                    });

                }

                list.Add(new IdAndName()
                {
                    Name = "My Classes"//sub.GetName
                });

                SiteMapUc.SetData(list);
            }
        }
    }
}