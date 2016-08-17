using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;
using One.Values.MemberShip;
using One.Views.Structure.All.UserControls;

namespace One.Views.Structure.All.Master
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = User as CustomPrincipal;
            //if (!IsPostBack)
            //{
            //    if (user != null)
            //    {
            //        if (user.SchoolId > 0)
            //        {
            //            using (var helper = new DbHelper.Structure())
            //            {
            //                var node = helper.ListStructure(user.SchoolId);
            //                foreach (var n in node)
            //                {
            //                    TreeView1.Nodes.Add(n);
            //                }
            //            }
            //        }
            //    }
            //}


            LoadStructure(user.SchoolId);
            

        }


        private void LoadStructure(int schoolId)
        {
            using (var helper = new DbHelper.Structure())
            {
                helper.GetLevels(schoolId).ForEach(l =>
                {
                    var luc = (ListLevelUC)Page
                        .LoadControl("~/Views/Structure/All/UserControls/ListLevelUC.ascx");

                    luc.SetName(l.Id, l.Name, "");
                    pnlListing.Controls.Add(luc);

                    var faculties = helper.GetFaculties(l.Id);

                    if (!faculties.Any())
                    {
                        var fuc = (ListUC)Page
                               .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx");
                        luc.AddControl(fuc);
                    }
                    else
                    {
                        faculties.ForEach(f =>
                        {
                            var fuc = (ListUC)Page
                                .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx");
                            fuc.SetName(f.Id, f.Name, "");
                            luc.AddControl(fuc);

                            helper.GetPrograms(f.Id).ForEach(p =>
                            {
                                var puc = (ListUC)Page
                                    .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx")
                                      ;
                                puc.SetName(p.Id, p.Name, "");
                                fuc.AddControl(puc);

                                helper.GetYears(p.Id).ForEach(y =>
                                {
                                    var subyears = helper.GetSubYears(y.Id, true);

                                    if (!subyears.Any())
                                    {
                                        //display course info in this year since no subyear
                                        //course info is only in subyearUC
                                        var yuc = (ListSubYearUC)Page
                                                .LoadControl("~/Views/Structure/All/UserControls/ListSubYearUC.ascx");
                                        //yuc.CourseClicked+=subYear_CourseClicked;
                                        yuc.SetName(y.Id,0, y.Name, "");
                                        puc.AddControl(yuc);
                                    }
                                    else
                                    {
                                        var yuc = (ListYearUC)Page
                                                   .LoadControl("~/Views/Structure/All/UserControls/ListYearUC.ascx");
                                        yuc.SetName(y.Id, y.Name, "");
                                        puc.AddControl(yuc);
                                        //get subyears
                                        subyears.ForEach(s =>
                                        {
                                            var suc = (ListSubYearUC)Page
                                                .LoadControl("~/Views/Structure/All/UserControls/ListSubYearUC.ascx");
                                            //suc.CourseClicked += subYear_CourseClicked;
                                            suc.SetName(y.Id, s.Id, s.Name, "");
                                            yuc.AddControl(suc);
                                        });
                                    }
                                });
                            });
                        });
                    }

                });
            }
        }

        private void subYear_CourseClicked(object sender, StructureEventArgs e)
        {
            using (var helper = new DbHelper.Structure())
            {
                string dir = helper.GetSructureDirectory(e.YearId, e.SubYearId);
                CourseListUC.SetProgramDirectory(dir);
            }
            CourseListUC.LoadCourseList(e.YearId,e.SubYearId);
            MultiView1.ActiveViewIndex = 1;
        }
    }
}