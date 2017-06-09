using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;
using One.Views.Structure.All.UserControls;

namespace One.Views.Structure
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = User as CustomPrincipal;

            if (!IsPostBack)
            {
                var edit = Session["editMode"] as string;//Request.QueryString["edit"];
                if (edit != null)
                {
                    Edit = edit;
                }
            }

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
                                Name = SiteMap.CurrentNode.Title
                                //,Value = SiteMap.CurrentNode.Url
                                //,Void=true
                            }
                        };
                    SiteMapUc.SetData(list);
                }
                if (!user.IsInRole("manager"))
                {
                    Edit = "0";
                    //lnkEdit.Visible = false;
                    lnkAdd.Visible = false;
                }
                else if (Edit == "1")
                {
                    //lnkEdit.Visible = true;
                    lnkAdd.Visible = true;
                    lnkAdd.NavigateUrl = "~/Views/Structure/StructureCreate.aspx?pId=" + user.SchoolId + "&strTyp=pro";
                    lblAddText.Text = "Add Program";
                }
                LoadStructure(user.SchoolId);
            }
        }

        public string Edit
        {
            get { return hidEdit.Value; }
            set { hidEdit.Value = value; }
        }

        private void LoadStructure(int schoolId)
        {
            var pId = Request.QueryString["pId"];

            var edit = Edit == "1";
            using (var helper = new DbHelper.Structure())
            {
                helper.ListPrograms(schoolId).ForEach(p =>
                {
                    #region Program data populate code 

                    var expand = p.Id.ToString() == pId;
                    var puc = (ListUC)Page
                        .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx")
                          ;
                    puc.SetName(p.Id, p.Name
                        , "~/Views/Structure/StructureCreate.aspx?strId=" + p.Id + "&progId=" + p.Id + "&strTyp=pro"
                        , edit
                         , "~/Views/Structure/StructureCreate.aspx?pId=" + p.Id + "&progId=" + p.Id + "&strTyp=yr", "Add Year"
                         , expand
                        );
                    pnlListing.Controls.Add(puc);


                    #endregion
                    
                    p.Year.Where(x => !(x.Void ?? false))
                        .OrderBy(x => x.Position)
                        .ToList()
                        //helper.GetYears(p.Id)
                        .ForEach(y =>
                        {
                            var subyears = y.SubYears.Where(x => !(x.Void ?? false) && (x.ParentId??0)==0)
                                .OrderBy(or => or.Position)
                                .ToList();
                            #region Unused code

                            //helper.GetSubYears(y.Id, true);

                            //if (!subyears.Any())
                            //{
                            //    //display course info in this year since no subyear
                            //    //course info is only in subyearUC
                            //    var yuc = (ListSubYearUC)Page
                            //            .LoadControl("~/Views/Structure/All/UserControls/ListSubYearUC.ascx");
                            //    //yuc.CourseClicked+=subYear_CourseClicked;
                            //    var pbname = "";
                            //    int pbId = 0;
                            //    var pb =
                            //        y.RunningClasses.FirstOrDefault(x => (x.SubYearId ?? 0) == 0 && (x.IsActive ?? true)
                            //                                                && x.AcademicYear.IsActive
                            //                                                && !(x.Completed ?? false));
                            //    if (pb != null)
                            //    {
                            //        if (pb.ProgramBatchId != null)
                            //        {
                            //            pbname = pb.ProgramBatch.NameFromBatch;
                            //            pbId = pb.ProgramBatchId ?? 0;
                            //        }
                            //    }
                            //    yuc.SetName(y.Id, 0, y.Name
                            //        , "~/Views/Structure/StructureCreate.aspx?strId=" + y.Id + "&strTyp=yr"
                            //        , y.SubjectStructures.Count(x => !(x.Void ?? false) && (x.SubYearId ?? 0) == 0)
                            //        , pbname, pbId
                            //        , edit
                            //         , "~/Views/Structure/StructureCreate.aspx?pId=" + y.Id + "&strTyp=syr", "Add Sub-Year"
                            //        );
                            //    puc.AddControl(yuc);
                            //}
                            //else

                            #endregion

                            #region Year code

                            var yuc = (ListYearUC)Page
                                           .LoadControl("~/Views/Structure/All/UserControls/ListYearUC.ascx");
                            yuc.SetName(y.Id, y.Name
                                , "~/Views/Structure/StructureCreate.aspx?strId=" + y.Id + "&progId=" + p.Id + "&strTyp=yr"
                                , edit
                                 , "~/Views/Structure/StructureCreate.aspx?pId=" + y.Id + "&progId=" + p.Id + "&strTyp=syr", "Add Sub-Year"
                                );
                            puc.AddControl(yuc);

                            #endregion
                                
                                //get subyears
                                subyears.ForEach(s =>
                                {

                                    #region SubYears populate code

                                    var pbname = "";
                                    int pbId = 0;
                                    var pb =
                                        s.RunningClasses.FirstOrDefault(x => (x.IsActive ?? true) && x.Session.IsActive
                                                                                    && !(x.Completed ?? false))
                                        ;
                                    if (pb != null)
                                    {
                                        if (pb.ProgramBatchId != null)
                                        {
                                            pbname = pb.ProgramBatch.NameFromBatch;
                                            pbId = pb.ProgramBatchId ?? 0;
                                        }
                                    }

                                    var suc = (ListSubYearUC)Page
                                        .LoadControl("~/Views/Structure/All/UserControls/ListSubYearUC.ascx");
                                    //suc.CourseClicked += subYear_CourseClicked;
                                    suc.SetName(y.Id, s.Id, s.Name
                                        , "~/Views/Structure/StructureCreate.aspx?strId=" + s.Id + "&progId=" + p.Id + "&strTyp=syr"
                                        , s.SubjectStructures.Count(x => !(x.Void ?? false))
                                        , pbname, pbId
                                        , edit);
                                    yuc.AddControl(suc);

                                    #endregion
                                    
                                });
                              
                        });
                });


                #region unused code (Level code previous)

                //levels.ForEach(l =>
                //{
                //    var luc = (ListLevelUC)Page
                //        .LoadControl("~/Views/Structure/All/UserControls/ListLevelUC.ascx");

                //    luc.SetName(l.Id, l.Name, "~/Views/Structure/StructureCreate.aspx?strId=" + l.Id + "&strTyp=lev"
                //        , edit
                //        , "~/Views/Structure/StructureCreate.aspx?pId=" + l.Id + "&strTyp=fac", "Add Faculty"
                //        );
                //    pnlListing.Controls.Add(luc);

                //    var faculties = helper.GetFaculties(l.Id);

                //    if (!faculties.Any())
                //    {
                //        var fuc = (ListUC)Page
                //               .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx");
                //        luc.AddControl(fuc);
                //    }
                //    else
                //    {
                //        faculties.ForEach(f =>
                //        {
                //            var fuc = (ListUC)Page
                //                .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx");
                //            fuc.SetName(f.Id, "●" + f.Name
                //                , "~/Views/Structure/StructureCreate.aspx?strId=" + f.Id + "&strTyp=fac"
                //                , edit
                //                , "~/Views/Structure/StructureCreate.aspx?pId=" + f.Id + "&strTyp=pro", "Add Program");
                //            luc.AddControl(fuc);


                //        });
                //    }

                //});

                #endregion
                
            }
        }

        //private void subYear_CourseClicked(object sender, StructureEventArgs e)
        //{
        //    using (var helper = new DbHelper.Structure())
        //    {
        //        string dir = helper.GetSructureDirectory(e.YearId, e.SubYearId);
        //        CourseListUC.SetProgramDirectory(dir);
        //    }
        //    CourseListUC.LoadCourseList(e.YearId, e.SubYearId);
        //    MultiView1.ActiveViewIndex = 1;
        //}
    }
}