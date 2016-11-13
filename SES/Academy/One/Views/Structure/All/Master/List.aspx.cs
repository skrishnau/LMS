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
            var edit = Request.QueryString["edit"];
            if (edit != null)
            {
                Response.Redirect("~/Views/Structure/?edit=" + edit);
            }
            else
            {
                Response.Redirect("~/Views/Structure/");
            }
            //var user = User as CustomPrincipal;

            //if (!IsPostBack)
            //{
            //    var edit = Request.QueryString["edit"];
            //    if (edit != null)
            //    {
            //        Edit = edit;
            //        if (edit == "1")
            //        {
            //            lnkEdit.NavigateUrl =
            //                "~/Views/Structure/All/Master/List.aspx?edit=0";
            //            lblEdit.Text = "Exit Edit";
            //        }
            //        else
            //        {
            //            lnkEdit.NavigateUrl =
            //                "~/Views/Structure/All/Master/List.aspx?edit=1";
            //            lblEdit.Text = "Edit";
            //        }
            //    }
            //    else
            //    {
            //        lnkEdit.NavigateUrl = "~/Views/Structure/All/Master/List.aspx?edit=1";
            //        lblEdit.Text = "Edit";
            //    }
            //}

            //if (user != null)
            //    LoadStructure(user.SchoolId);


        }

        //public string Edit
        //{
        //    get { return hidEdit.Value; }
        //    set { hidEdit.Value = value; }
        //}

        //private void LoadStructure(int schoolId)
        //{
        //    var edit = Edit == "1";
        //    using (var helper = new DbHelper.Structure())
        //    {
        //        var levels = helper.GetLevels(schoolId);
        //        if (!levels.Any())
        //        {
        //            Response.Redirect("~/Views/Structure/Level/Create.aspx", true);
        //        }

        //        levels.ForEach(l =>
        //        {
        //            var luc = (ListLevelUC)Page
        //                .LoadControl("~/Views/Structure/All/UserControls/ListLevelUC.ascx");

        //            luc.SetName(l.Id, l.Name, "~/Views/Structure/StructureCreate.aspx?strId=" + l.Id + "&strTyp=lev"
        //                , edit
        //                , "~/Views/Structure/StructureCreate.aspx?pId=" + l.Id + "&strTyp=fac", "Add Faculty"
        //                );
        //            pnlListing.Controls.Add(luc);

        //            var faculties = helper.GetFaculties(l.Id);

        //            if (!faculties.Any())
        //            {
        //                var fuc = (ListUC)Page
        //                       .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx");
        //                luc.AddControl(fuc);
        //            }
        //            else
        //            {
        //                faculties.ForEach(f =>
        //                {
        //                    var fuc = (ListUC)Page
        //                        .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx");
        //                    fuc.SetName(f.Id, "●" + f.Name
        //                        , "~/Views/Structure/StructureCreate.aspx?strId=" + f.Id + "&strTyp=fac"
        //                        , edit
        //                        , "~/Views/Structure/StructureCreate.aspx?pId=" + f.Id + "&strTyp=pro","Add Program");
        //                    luc.AddControl(fuc);

        //                    helper.GetPrograms(f.Id).ForEach(p =>
        //                    {
        //                        var puc = (ListUC)Page
        //                            .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx")
        //                              ;
        //                        puc.SetName(p.Id, "♦" + p.Name
        //                            , "~/Views/Structure/StructureCreate.aspx?strId=" + p.Id + "&strTyp=pro"
        //                            , edit
        //                             , "~/Views/Structure/StructureCreate.aspx?pId=" + p.Id + "&strTyp=yr", "Add Year"
        //                            );
        //                        fuc.AddControl(puc);

        //                        helper.GetYears(p.Id).ForEach(y =>
        //                        {
        //                            var subyears = helper.GetSubYears(y.Id, true);

        //                            if (!subyears.Any())
        //                            {
        //                                //display course info in this year since no subyear
        //                                //course info is only in subyearUC
        //                                var yuc = (ListSubYearUC)Page
        //                                        .LoadControl("~/Views/Structure/All/UserControls/ListSubYearUC.ascx");
        //                                //yuc.CourseClicked+=subYear_CourseClicked;
        //                                yuc.SetName(y.Id, 0, "●" + y.Name
        //                                    , "~/Views/Structure/StructureCreate.aspx?strId=" + y.Id + "&strTyp=yr"
        //                                    , edit
        //                                     , "~/Views/Structure/StructureCreate.aspx?pId=" + y.Id + "&strTyp=syr", "Add Sub-Year"
        //                                    );
        //                                puc.AddControl(yuc);
        //                            }
        //                            else
        //                            {
        //                                var yuc = (ListYearUC)Page
        //                                           .LoadControl("~/Views/Structure/All/UserControls/ListYearUC.ascx");
        //                                yuc.SetName(y.Id, "●" + y.Name
        //                                    , "~/Views/Structure/StructureCreate.aspx?strId=" + y.Id + "&strTyp=yr"
        //                                    , edit
        //                                     , "~/Views/Structure/StructureCreate.aspx?pId=" + y.Id + "&strTyp=syr", "Add Sub-Year"
        //                                    );
        //                                puc.AddControl(yuc);
        //                                //get subyears
        //                                subyears.ForEach(s =>
        //                                {
        //                                    var suc = (ListSubYearUC)Page
        //                                        .LoadControl("~/Views/Structure/All/UserControls/ListSubYearUC.ascx");
        //                                    //suc.CourseClicked += subYear_CourseClicked;
        //                                    suc.SetName(y.Id, s.Id, "♦" + s.Name
        //                                        , "~/Views/Structure/StructureCreate.aspx?strId=" + s.Id + "&strTyp=syr"
        //                                        , edit);
        //                                    yuc.AddControl(suc);
        //                                });
        //                                //add subyear
        //                                //var hyper = new HyperLink() { NavigateUrl = "~/Views/Structure/StructureCreate.aspx?pId=" + y.Id + "&strTyp=syr" };
        //                                //hyper.Controls.Add(new Label(){Text = "Add Sub-year"});
        //                                //hyper.Controls.Add(new Image() { ImageUrl = "~/Content/Icons/Add/Add-icon.png" });
        //                                //yuc.AddControl(hyper);
        //                            }
        //                        });
        //                    });
        //                });
        //            }

        //        });
        //    }
        //}

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