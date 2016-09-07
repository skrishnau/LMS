using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.InitialValues;

namespace One.Views.Exam.Exam.Create
{
    public partial class CreateExamUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAcademicYear();
                LoadSession();
                LoadExamType();
                LoadCoorinator();
                TreeViewUC1.SchoolId = Values.Session.GetSchool(Session);

            }
        }




        #region Properties

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYear.Value); }
            set
            {
                this.hidAcademicYear.Value = value.ToString();
                LoadAcademicYear();
            }
        }
        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set
            {
                this.hidSessionId.Value = value.ToString();
                LoadSession();
            }
        }

        public int ExamId
        {
            get { return Convert.ToInt32(hidExamId.Value); }
            set
            {
                this.hidExamId.Value = value.ToString();
                Academic.DbEntities.Exams.Exam exam;
                using (var helper = new DbHelper.Exam())
                {
                    exam = helper.FindExam(value);
                    if (AcademicYearId <= 0)
                    {
                        if (exam != null)
                        {
                            hidAcademicYear.Value = exam.AcademicYearId.ToString();
                            if (exam.SessionId != null)
                            {
                                hidSessionId.Value = exam.SessionId.ToString();
                            }
                            LoadAcademicYear();

                            txtName.Text = exam.Name;
                            txtNotice.Text = exam.Notice;
                            txtResultDate.Text = exam.ResultDate.HasValue
                                ? exam.ResultDate.Value.ToShortDateString()
                                : "";
                            txtStartDate.Text = exam.StartDate.HasValue
                                ? exam.StartDate.Value.ToShortDateString()
                                : "";
                            txtWeight.Text = exam.Weight.ToString();

                            hidExamTypeId.Value = exam.ExamTypeId.ToString();
                            LoadExamType();

                            hidCoordinatorId.Value = exam.ExamCoordinatorId.ToString();
                            LoadCoorinator();

                        }
                    }
                }



                cmbSession.Enabled = false;
                cmbAcademicYear.Enabled = false;

                TreeViewUC1.AcademicYearId = AcademicYearId;
                TreeViewUC1.SessionId = SessionId;
                TreeViewUC1.ExamId = value;

            }
        }

        public int ExamTypeId
        {
            get { return Convert.ToInt32(hidExamTypeId.Value); }
            set { hidExamTypeId.Value = value.ToString(); }
        }
        public int CoordinatorId
        {
            get { return Convert.ToInt32(hidCoordinatorId.Value); }
            set { hidCoordinatorId.Value = value.ToString(); }
        }

        public TextBox DateBox
        {
            get { return (TextBox)ViewState["DateBox"]; }
            set { ViewState["DateBox"] = value; }
        }



        #endregion

        #region Load Functions

        private void LoadAcademicYear()
        {

            DbHelper.ComboLoader.LoadAcademicYear(ref cmbAcademicYear, Values.Session.GetSchool(Session), AcademicYearId);
            if (AcademicYearId > 0)
            {
                cmbAcademicYear.Enabled = false;
                LoadSession();
            }
        }
        private void LoadSession()
        {
            DbHelper.ComboLoader.LoadSession(ref cmbSession, Convert.ToInt32(cmbAcademicYear.SelectedValue), SessionId
                , true, true, false);
        }

        private void LoadExamType()
        {
            DbHelper.ComboLoader.LoadExamType(ref cmbExamType, Values.Session.GetSchool(Session), ExamTypeId);
        }


        private void LoadCoorinator()
        {
            DbHelper.ComboLoader.LoadCoordinator(ref cmbCoordinator, Values.Session.GetSchool(Session), CoordinatorId);
        }

        //private void LoadTree()
        //{

        //    string root = "";
        //    List<Academic.DbEntities.AcacemicPlacements.RunningClass> classes = null;

        //    using (var helper = new DbHelper.AcademicPlacement())
        //    {
        //        if (cmbSession.SelectedValue != "" && cmbSession.SelectedValue != "0")
        //        {
        //            root = cmbSession.SelectedItem.Text;
        //            classes = helper.GetClassesOfAcademicYear(AcademicYearId, Convert.ToInt32(cmbSession.SelectedValue ?? "0"));
        //        }
        //        else if (cmbAcademicYear.SelectedValue != "" && cmbAcademicYear.SelectedValue != "0")
        //        {
        //            root = cmbAcademicYear.SelectedItem.Text;
        //            classes = helper.GetClassesOfAcademicYear(Convert.ToInt32(cmbAcademicYear.SelectedValue ?? "0"));
        //        }
        //    }
        //    if (classes != null)
        //    {
        //        if (classes.Count > 0)
        //        {

        //            Root.LabelText = root;
        //            Root.Level = 0;
        //            var levels = classes.Select(y => y.Year.Program.Faculty.Level).Distinct().ToList();
        //            string s = "";
        //            //string s = "0,";
        //            for (var lev = 0; lev < levels.Count(); lev++)//in levels
        //            {
        //                var faculties = classes.Select(y => y.Year.Program.Faculty).Where(x => x.LevelId == levels[lev].Id).Distinct().ToList();
        //                ListDisplay.NodeUC leveluc =
        //                    (ListDisplay.NodeUC)
        //                        Page.LoadControl("~/Views/AcademicPlacement/RunningClass/ListDisplay/NodeUC.ascx");

        //                leveluc.LabelText = levels.ElementAt(lev).Name; //"i=" + i.ToString();
        //                leveluc.Level = 1;
        //                //if (lev < levels.Count() - 1)
        //                //    s += "1,";
        //                //else s += "0,";
        //                leveluc.NoOfVertBars = s;
        //                Root.AddNode(leveluc);
        //                for (int fac = 0; fac < faculties.Count(); fac++)
        //                {
        //                    var programs = classes.Select(y => y.Year.Program)
        //                        .Where(x => x.FacultyId == faculties[fac].Id).Distinct().ToList();
        //                    ListDisplay.NodeUC facuc =
        //                        (ListDisplay.NodeUC)Page
        //                            .LoadControl("~/Views/AcademicPlacement/RunningClass/ListDisplay/NodeUC.ascx");

        //                    facuc.LabelText = faculties[fac].Name; //"i=" + i.ToString();
        //                    facuc.Level = 2;
        //                    //if level has more elements display else don't

        //                    if (lev < levels.Count() - 1)
        //                        s += "1,";
        //                    else s += "0,";
        //                    facuc.NoOfVertBars = s;
        //                    leveluc.AddNode(facuc);
        //                    for (var pro = 0; pro < programs.Count(); pro++)
        //                    {
        //                        var years = classes.Select(y => y.Year)
        //                            .Where(x => x.ProgramId == programs[pro].Id).Distinct().ToList();
        //                        ListDisplay.NodeUC proguc =
        //                            (ListDisplay.NodeUC)Page
        //                                .LoadControl("~/Views/AcademicPlacement/RunningClass/ListDisplay/NodeUC.ascx");

        //                        proguc.LabelText = programs[pro].Name; //"i=" + i.ToString();
        //                        proguc.Level = 3;

        //                        if (fac < faculties.Count() - 1)
        //                            s += "1,";
        //                        else s += "0,";
        //                        proguc.NoOfVertBars = s;

        //                        facuc.AddNode(proguc);
        //                        for (var ye = 0; ye < years.Count; ye++)
        //                        {
        //                            // var subyears = classes.Select(y => y.SubYear).Where(x => x.YearId == year.Id).Distinct();
        //                            ListDisplay.NodeUC yearuc =
        //                                (ListDisplay.NodeUC)Page
        //                                    .LoadControl("~/Views/AcademicPlacement/RunningClass/ListDisplay/NodeUC.ascx");

        //                            yearuc.LabelText = years[ye].Name; //"i=" + i.ToString();
        //                            yearuc.Level = 4;

        //                            if (pro < programs.Count - 1)
        //                                s += "1,";
        //                            else s += "0,";
        //                            yearuc.NoOfVertBars = s;

        //                            proguc.AddNode(yearuc);
        //                            //if (subyears != null)
        //                            //{
        //                            //    if (subyears.Count() > 0)
        //                            //    {
        //                            //        foreach (var subyear in subyears)
        //                            //        {
        //                            //            CurrentAcademicYear.ListDisplay.NodeUC subuc =
        //                            //                (CurrentAcademicYear.ListDisplay.NodeUC)Page
        //                            //                    .LoadControl(
        //                            //                        "~/Views/AcademicPlacement/RunningClass/ListDisplay/NodeUC.ascx");

        //                            //            subuc.LabelText = subyear.Name; //"i=" + i.ToString();
        //                            //            subuc.Level = 5;

        //                            s = s.Substring(0, s.Length - 2); //(s.Length-3<0?2:3));
        //                            //            yearuc.AddNode(subuc);
        //                            //        }
        //                            //    }
        //                            //}


        //                        }
        //                        s = s.Substring(0, s.Length - 2); //(s.Length - 3 < 0 ? 2 : 3));
        //                    }
        //                    s = s.Substring(0, s.Length - 2);//(s.Length - 3 < 0 ? 2 : 3));
        //                }
        //                //s = s.Substring(0, s.Length - 2); // (s.Length - 3 < 0 ? 2 : 3));
        //                //Root.AddNode(leveluc);
        //            }
        //        }
        //    }


        //}


        #endregion

        #region  Events

        protected void cmbAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidAcademicYear.Value = cmbAcademicYear.SelectedValue;
            LoadSession();
            //LoadTree();
        }

        protected void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidSessionId.Value = cmbSession.SelectedValue;
            //LoadTree();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox box = DateBox;
            if (DateBox != null)
            {
                box.Text = Calendar1.SelectedDate.ToShortDateString();
            }
            Calendar1.Visible = false;
        }

        protected void imgBtnStartDate_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;

            }
            else
            {
                Calendar1.Visible = true;
            }
            DateBox = txtStartDate;
        }

        protected void imgBtnResultDate_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;

            }
            else
            {
                Calendar1.Visible = true;
            }
            DateBox = txtResultDate;
        }

        #endregion

        #region Save

        protected void btnSaveExam_Click(object sender, EventArgs e)
        {
            var cor = cmbCoordinator.SelectedValue;
            var typ = cmbExamType.SelectedValue;
            var acaId = cmbAcademicYear.SelectedValue;
            if (String.IsNullOrEmpty(cor) || cor == "0")
            {
                valiCoor.IsValid = false;
            }
            if (string.IsNullOrEmpty(typ) || typ == "0")
            {
                valiType.IsValid = false;
            }
            if (string.IsNullOrEmpty(acaId))
            {
                valiAcademicYear.IsValid = false;
            }

            if (Page.IsValid)
            {
                var exam = new Academic.DbEntities.Exams.Exam()
                {
                    Id = ExamId
                    ,
                    AcademicYearId = AcademicYearId
                    ,
                    ExamCoordinatorId = Convert.ToInt32(cor)
                    ,
                    ExamTypeId = Convert.ToInt32(typ)
                    ,
                    Name = txtName.Text
                    ,
                    Weight = (float)Convert.ToDecimal(txtWeight.Text)
                    ,
                    CreatedDate = DateTime.Now
                    ,
                    Notice = txtNotice.Text
                    ,
                    SchoolId = Values.Session.GetSchool(Session)
                };
                if (!String.IsNullOrEmpty(txtStartDate.Text))
                {
                    exam.StartDate = Convert.ToDateTime(txtStartDate.Text);

                }
                if (!String.IsNullOrEmpty(txtResultDate.Text))
                {
                    exam.ResultDate = Convert.ToDateTime(txtResultDate.Text);
                }
                if (!(String.IsNullOrEmpty(cmbSession.SelectedValue) || cmbSession.SelectedValue == "0"))
                    exam.SessionId = Convert.ToInt32(cmbSession.SelectedValue);
                using (var helper = new DbHelper.Exam())
                {
                    var saved = helper.AddOrUpdateExam(exam);
                    if (saved != null)
                    {
                        pnlExam.Enabled = false;
                        pnlExamDetails.Visible = true;
                        TreeViewUC1.AcademicYearId = AcademicYearId;
                        TreeViewUC1.SessionId = SessionId;
                        TreeViewUC1.ExamId = saved.Id;
                    }
                }
            }
        }

        #endregion

        protected void CompareValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var value = Convert.ToInt32(txtWeight.Text);
            if (value > 100 || value < 0)
            {
                CompareValidator1.IsValid = false;
            }
        }


    }
}