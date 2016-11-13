using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;
using One.Views.Academy.ProgramSelection;

namespace One.Views.Academy.ClassAssign
{
    public partial class ClassAssignCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = "Error while saving.";
            var aId = Request.QueryString["aId"];
            var sId = Request.QueryString["sId"];
            if (aId != null)
            {
                try
                {
                    AcademicYearId = Convert.ToInt32(aId);
                    if (sId != null)
                    {
                        // then its for session, so display only those years whose subyears are present
                        SessionId = Convert.ToInt32(sId);
                    }
                    var user = Page.User as CustomPrincipal;
                    if (user != null)
                    {
                        LoadData(user.SchoolId);
                        if (!IsPostBack)
                            LoadAcademicInfo();
                    }
                }
                catch
                {
                    //Response.Redirect("../List.aspx");
                }
            }
            //else
            //{
            //    Response.Redirect("../List.aspx");
            //}

            //LoadStructure(user.SchoolId);
        }

        private void LoadAcademicInfo()
        {
            using (var helper = new DbHelper.AcademicYear())
            {
                var aca = helper.GetAcademicYear(AcademicYearId);
                if (aca != null)
                {
                    if (!(aca.Void ?? false))
                    {
                        lblAcademicInfo.Text = "Classes assign in 'Academic year' : <strong>" + aca.Name + "</strong>";
                        var ses = helper.GetSession(SessionId);
                        if (ses != null)
                        {
                            if (aca.Sessions.Select(x => x.Id).Contains(ses.Id))
                            {
                                lblAcademicInfo.Text += " and 'Session' : " + ses.Name;
                            }
                            else
                            {
                                Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + AcademicYearId);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/Academy/List.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Academy/List.aspx");
                }
            }
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYearId.Value); }
            set { hidAcademicYearId.Value = value.ToString(); }
        }
        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { hidSessionId.Value = value.ToString(); }
        }

        private void LoadData(int schoolId)
        {
            var acaId = AcademicYearId;
            var sesId = SessionId;
            using (var pbHelper = new DbHelper.AcademicPlacement())
            using (var helper = new DbHelper.Structure())
            {
                int sessionId = SessionId;
                int academicYearId = AcademicYearId;
                helper.ListLevels(schoolId).ForEach(l =>
                {
                    var faculties = l.Faculty.Where(x => !(x.Void ?? false)).ToList();
                    faculties.ForEach(f =>
                    {
                        #region FACULTY UC INIT

                        var facUc = (UserControls.FacultyItemUc)
                                                     Page.LoadControl("~/Views/Academy/ClassAssign/UserControls/FacultyItemUc.ascx");
                        facUc.SetData(f.Id, f.Name, acaId, sesId);
                        facUc.ID = "facultyUc_" + f.Id;

                        #endregion

                        var programs = f.Programs.Where(x => !(x.Void ?? false)).ToList();

                        if (programs.Count > 0)
                        {
                            pnlProgramListing.Controls.Add(facUc);
                            facUc.SetPrograms(programs);
                        }

                    });

                });//------end of level
            }
        }

        //private void LoadStructure(int schoolId)
        //{
        //    // key: program, Value: list of programBatch
        //    var alreadySelected = Session["AlreadySelectedProgramBatches"] as Dictionary<int, List<int>>;

        //    //if (alreadySelected != null)
        //    using (var pbHelper = new DbHelper.AcademicPlacement())
        //    using (var helper = new DbHelper.Structure())
        //    {
        //        int sessionId = SessionId;
        //        int academicYearId = AcademicYearId;
        //        helper.GetLevels(schoolId).ForEach(l =>
        //        {
        //            var luc = (ListLevelUC)Page
        //                .LoadControl("~/Views/Academy/ProgramSelection/ListLevelUC.ascx");
        //            luc.SetName(l.Id, l.Name, "");

        //            luc.ID = "levelControl" + l.Id;
        //            luc.ClientIDMode = ClientIDMode.Static;

        //            var faculties = helper.GetFaculties(l.Id);
        //            var anyFaculty = false;
        //            if (faculties.Any())
        //            {
        //                anyFaculty = true;
        //                faculties.ForEach(f =>
        //                {
        //                    var anyPrograms = false;
        //                    var anyYears = false;

        //                    var programs = helper.GetPrograms(f.Id);
        //                    var fuc = (ListFacultyUC)Page
        //                       .LoadControl("~/Views/Academy/ProgramSelection/ListFacultyUC.ascx");

        //                    fuc.ID = "facultyControl" + f.Id;
        //                    fuc.ClientIDMode = ClientIDMode.Static;

        //                    if (programs.Any())
        //                    {
        //                        anyPrograms = true;
        //                    }

        //                    programs.ForEach(p =>
        //                    {
        //                        //var puc = (ListUC)Page
        //                        //    .LoadControl("~/Views/Structure/All/UserControls/ListUC.ascx")
        //                        //      ;
        //                        var years = helper.GetYears(p.Id);
        //                        var puc = (ProgramCheckBoxAndLabel)
        //                                        Page.LoadControl("~/Views/Academy/ProgramSelection/ProgramCheckBoxAndLabel.ascx");

        //                        if (years.Any())
        //                        {
        //                            puc.SetName(p.Id, p.Name, "");
        //                            puc.ID = "programControl" + p.Id;
        //                            puc.ClientIDMode = ClientIDMode.Static;
        //                            fuc.AddControl(puc);

        //                            //add these programs to the dictionary key values
        //                            if (!IsPostBack)
        //                            {
        //                                var key = alreadySelected.Keys.FirstOrDefault(q => q == p.Id);
        //                                //if (alreadySelected[p.Id] == null)
        //                                if (key <= 0)
        //                                {
        //                                    alreadySelected[p.Id] = new List<int>();
        //                                }
        //                            }
        //                        }


        //                        years.ForEach(y =>
        //                        {
        //                            var subyears = helper.GetSubYears(y.Id, true);

        //                            if (!subyears.Any())
        //                            {
        //                                #region No subYears

        //                                if (sessionId <= 0)
        //                                {
        //                                    var yuc = (YearCheckBoxAndLabel)
        //                                            Page.LoadControl(
        //                                            "~/Views/Academy/ProgramSelection/YearCheckBoxAndLabel.ascx");

        //                                    //yuc.CourseClicked+=subYear_CourseClicked;
        //                                    yuc.SetIds(l.Id, f.Id, p.Id, y.Id, 0);
        //                                    yuc.SetName(p.Name, y.Name, "");//y.Id, y.Name, p.Id, "");

        //                                    yuc.ClientIDMode = ClientIDMode.Static;
        //                                    yuc.ID = "yearControl" + y.Id;

        //                                    puc.AddControl(yuc);
        //                                    anyYears = true;

        //                                    yuc.SetImageUrl();
        //                                    yuc.ImageVisibility = true;


        //                                    ////yuc.BatchSelectClicked += yuc_BatchSelectClicked;

        //                                    //work remain:
        //                                    //get programbatchId for this year and then add it to the 
        //                                    // alreadySelected session list
        //                                    //    also populate the selected batch for this year
        //                                    //        this task is to be done for subyears too

        //                                    //Get ProgramBatchId for this year
        //                                    var rcls = pbHelper.GetRunningClassInAcademicYear(academicYearId,
        //                                        y.Id, sessionId, 0);
        //                                    if (rcls != null)
        //                                    {
        //                                        if (!(rcls.Void ?? false))
        //                                        {
        //                                            if (!alreadySelected[p.Id].Contains(rcls.ProgramBatchId ?? 0)
        //                                                                                                    && !IsPostBack)
        //                                            {
        //                                                alreadySelected[p.Id].Add(rcls.ProgramBatchId ?? 0);
        //                                            }
        //                                            //Now display 
        //                                            yuc.SetSelectedBatch(rcls.ProgramBatchId ?? 0,
        //                                                rcls.ProgramBatch.NameFromBatch, rcls.Id);
        //                                            yuc.Checked = true;
        //                                        }
        //                                        else
        //                                        {
        //                                            //this is done to unvoid the previously voided data..
        //                                            // so that no duplicate data(one with void and next with no-void)
        //                                            //is made in running class
        //                                            yuc.SetSelectedBatch(0, "", rcls.Id);
        //                                        }

        //                                    }

        //                                }

        //                                #endregion

        //                                //display course info in this year since no subyear
        //                                //course info is only in subyearUC
        //                                //var yuc = (ListSubYearUC)Page
        //                                //        .LoadControl("~/Views/Structure/All/UserControls/ListSubYearUC.ascx");
        //                                //var yuc = (YearCheckBoxAndLabel)
        //                                //            Page.LoadControl(
        //                                //            "~/Views/Academy/ProgramSelection/YearCheckBoxAndLabel.ascx");

        //                            }
        //                            else
        //                            {
        //                                if (sessionId > 0)
        //                                {
        //                                    #region There are subYears

        //                                    anyYears = true;
        //                                    var yuc = (YearCheckBoxAndLabel)
        //                                                 Page.LoadControl(
        //                                                 "~/Views/Academy/ProgramSelection/YearCheckBoxAndLabel.ascx");

        //                                    yuc.ClientIDMode = ClientIDMode.Static;
        //                                    yuc.ID = "yearControl" + y.Id;

        //                                    yuc.SetIds(l.Id, f.Id, p.Id, y.Id, 0);
        //                                    yuc.SetName(p.Name, y.Name, "");
        //                                    yuc.ImageVisibility = false;

        //                                    ////yuc.BatchSelectClicked += yuc_BatchSelectClicked;
        //                                    /// 
        //                                    puc.AddControl(yuc);


        //                                    //Get ProgramBatchId for this year
        //                                    //var pbatch = pbHelper.GetProgramBatchInAcademicYear(academicYearId,
        //                                    //    y.Id, sessionId, 0);
        //                                    //if (pbatch != null)
        //                                    //{
        //                                    //    alreadySelected[p.Id].Add(pbatch.Id);
        //                                    //    //Now display 
        //                                    //    yuc.SetSelectedBatch(pbatch.Id, pbatch.NameFromBatch);
        //                                    //}


        //                                    //get subyears
        //                                    subyears.ForEach(s =>
        //                                    {
        //                                        //rdList.Items.Add(new ListItem(s.Name, s.Id.ToString()));

        //                                        var suc = (ListSubYearUC)Page
        //                                            .LoadControl("~/Views/Academy/ProgramSelection/ListSubYearUC.ascx");
        //                                        //suc.CourseClicked += subYear_CourseClicked;

        //                                        suc.ClientIDMode = ClientIDMode.Static;
        //                                        suc.ID = "subyearControl" + s.Id;
        //                                        suc.SetIds(l.Id, f.Id, p.Id, y.Id, s.Id);
        //                                        suc.SetName(p.Name, y.Name, s.Name);
        //                                        //suc.SetName(y.Id, s.Id, s.Name, p.Id);

        //                                        ////suc.BatchSelectClicked += suc_BatchSelectClicked;
        //                                        /// 
        //                                        yuc.AddControl(suc);


        //                                        //Get ProgramBatchId for this subyear
        //                                        var rcls = pbHelper.GetRunningClassInAcademicYear(academicYearId,
        //                                                       y.Id, sessionId, s.Id);
        //                                        if (rcls != null)
        //                                        {
        //                                            if (!(rcls.Void ?? false))
        //                                            {
        //                                                if (!alreadySelected[p.Id].Contains(rcls.ProgramBatchId ?? 0)
        //                                                                                                            && !IsPostBack)
        //                                                {
        //                                                    alreadySelected[p.Id].Add(rcls.ProgramBatchId ?? 0);
        //                                                }
        //                                                //Now display 

        //                                                suc.SetSelectedBatch(rcls.ProgramBatchId ?? 0, rcls.ProgramBatch == null ? "" : rcls.ProgramBatch.NameFromBatch, rcls.Id);
        //                                                suc.Checked = true;
        //                                                yuc.Checked = true;
        //                                            }
        //                                            else
        //                                            {
        //                                                //runnning class is void
        //                                                //this is done to unvoid the previously voided data..
        //                                                // so that no duplicate data(one with void and next with no-void)
        //                                                //is made in running class
        //                                                suc.SetSelectedBatch(0, "", rcls.Id);
        //                                            }

        //                                        }


        //                                    });

        //                                    #endregion

        //                                    //yuc.AddControl(rdList);
        //                                }

        //                            }
        //                        });
        //                    });
        //                    if (anyPrograms && anyYears)
        //                    {
        //                        //years xa bhane matra faculty print garne
        //                        fuc.SetName(f.Id, f.Name, "");
        //                        luc.AddControl(fuc);
        //                        pnlProgramListing.Controls.Add(fuc);
        //                    }
        //                    //pnlProgramListing.Controls.Add(fuc);
        //                });
        //            }
        //            if (anyFaculty)
        //            {
        //                pnlProgramListing.Controls.Add(luc);
        //            }
        //        });
        //    }
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //get all
            var rcs = GetRunningClasses();
            if (rcs == null)
            {
                lblError.Visible = true;
                lblError.Text = "Wrong input.";
                return;
            }
            using (var helper = new DbHelper.AcademicPlacement())
            {
                var saved = helper.AddOrUpdateRunningClass(rcs);
                if (saved)
                {
                    Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId="+AcademicYearId
                        +(SessionId>0?("&sId="+SessionId):""));
                }
                else
                {
                    lblError.Visible = true;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }


        public List<Academic.DbEntities.AcacemicPlacements.RunningClass> GetRunningClasses()
        {
            var lst = new List<Academic.DbEntities.AcacemicPlacements.RunningClass>();
            foreach (var cnt in pnlProgramListing.Controls)
            {
                var yuc = cnt as UserControls.FacultyItemUc;
                if (yuc != null)
                {
                    var rc = yuc.GetRunningClasses();
                    if (rc == null)
                    {
                        return null;
                    }
                    lst.AddRange(rc);
                }
            }
            return lst;
        }
    }
}