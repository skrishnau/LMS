using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Exam.Exam.ExamList
{
    public partial class ListUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAcademicYear();
                LoadSession();
            }
            LoadExams();
        }



        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }


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
            }
        }


        #endregion

        #region Functions

        private void LoadAcademicYear()
        {
            //DbHelper.ComboLoader.LoadAcademicYear(ref cmbAcademicYear, Values.Session.GetSchool(Session), AcademicYearId);
            if (AcademicYearId > 0)
            {
                cmbAcademicYear.Enabled = false;
                LoadSession();
            }
        }
        private void LoadSession()
        {
            DbHelper.ComboLoader.LoadSession(ref cmbSession, Convert.ToInt32(cmbAcademicYear.SelectedValue == "" ? "0" : cmbAcademicYear.SelectedValue), SessionId
                , true, true, false);
            //LoadExams();
        }


        private void LoadExams()
        {
            using (var helper = new DbHelper.Exam())
            {
                var acaId = Convert.ToInt32(cmbAcademicYear.SelectedValue == "" ? "0" : cmbAcademicYear.SelectedValue);
                var sessId = Convert.ToInt32(cmbSession.SelectedValue == "" ? "0" : cmbSession.SelectedValue);
                var exams = helper.GetExamList(SchoolId, acaId, sessId);
                foreach (var exam in exams)
                {
                    ItemsOfListUc item =
                        (ItemsOfListUc)Page.LoadControl("~/Views/Exam/Exam/ExamList/ItemsOfListUc.ascx");
                    item.SetFields(exam.Id, exam.Name, exam.ExamType.Name, exam.ResultDate, exam.UpdatedDate
                        , exam.Weight ?? 0, exam.NoticeContent);
                    pnlExamList.Controls.Add(item);
                }
            }
        }

        #endregion

        #region Events


        protected void cmbAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidAcademicYear.Value = cmbAcademicYear.SelectedValue;
            LoadSession();
            //LoadExams();
            //LoadTree();
        }

        protected void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            hidSessionId.Value = cmbSession.SelectedValue;
            //LoadExams();
            //LoadTree();
        }

        #endregion
    }
}