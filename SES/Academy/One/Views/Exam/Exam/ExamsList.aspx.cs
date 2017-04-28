using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Exam.Exam
{
    public partial class ExamsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var aId = Request.QueryString["aId"];
                    var sId = Request.QueryString["sId"];



                    var user = Page.User as CustomPrincipal;
                    if (user != null)
                    {
                        if (user.IsInRole("manager") || user.IsInRole("exam-head"))
                            Manager = true;
                        else if (user.IsInRole("teacher"))
                            Teacher = true;
                        //else

                        using (var acahelper = new DbHelper.AcademicYear())
                        //using (var helper = new DbHelper.Exam())
                        {
                            var acasesList = new List<Academic.ViewModel.AcademicAndSessionCombinedViewModel>();
                            acasesList = acahelper.ListAcademicAndSessionAsViewModel(user.SchoolId, Manager, Teacher);
                            var first = acasesList.FirstOrDefault() ?? new AcademicAndSessionCombinedViewModel();
                            if (aId != null && sId != null)
                            {
                                var a = Convert.ToInt32(aId);
                                var s = Convert.ToInt32(sId);
                                first = acasesList.FirstOrDefault(x =>
                                   x.AcademicYearId == a && (x.SessionId) == s) ??
                                   new AcademicAndSessionCombinedViewModel()
                                   {
                                       //Id = 0
                                       //,SessionId = 0
                                       //, AcademicYearId = 0
                                       //,Name = ""
                                       //,BothNameCombined = ""
                                       //, Completed = false
                                       //,Check = false
                                   };
                            }


                            dlistAcademic.DataSource = acasesList;
                            dlistAcademic.DataBind();

                            var index = acasesList.IndexOf(first);
                            dlistAcademic.SelectedIndex = (index == -1) ? 0 : index;
                            SetExams(user.SchoolId
                                , first.AcademicYearId
                                , first.SessionId
                                , first.BothNameCombined
                                , first.Completed);
                        }
                    }
                }
                catch { }

            }
        }

        public bool Manager
        {
            get { return Convert.ToBoolean(hidManager.Value); }
            set { hidManager.Value = value.ToString(); }
        }
        public bool Teacher
        {
            get { return Convert.ToBoolean(hidTeacher.Value); }
            set { hidTeacher.Value = value.ToString(); }
        }

        public bool GetPaddingVisibility(object sessionId)
        {
            if (sessionId != null)
            {
                if (sessionId.ToString() == "0")
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public string GetClass(object sessionId)
        {
            if (sessionId != null)
            {
                if (sessionId.ToString() == "0")
                {
                    return "aca";
                }
                return "ses";
            }
            return "aca";
        }
        public string GetIndent(object sessionId)
        {
            if (sessionId != null)
            {
                if (sessionId.ToString() == "0")
                {
                    return "● ";
                }
                return "♦ ";
            }
            return "● ";
        }

        protected void dlistAcademic_ItemCommand(object source, DataListCommandEventArgs e)
        {
            try
            {
                //display exam list as per the selected aca/ses
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    var acaSes = e.CommandArgument.ToString().Split(new char[] { ',' });
                    var aca = Convert.ToInt32(acaSes[0]);
                    var ses = Convert.ToInt32(acaSes[1]);
                    var completed = Convert.ToBoolean(acaSes[3]);
                    SetExams(user.SchoolId, aca, ses, acaSes[2], completed);
                }
            }
            catch { }
        }

        public void SetExams(int schoolId, int acaId, int sesId, string combinedName, bool completed)
        {
            if (completed )
            {
                btnNewExam.Visible = false;
            }
            else if(Manager)
            {
                btnNewExam.Visible = true;
                btnNewExam.NavigateUrl = "~/Views/Exam/Exam/CreateExam.aspx?aId=" + acaId + "&sId=" + sesId;
            }
            using (var helper = new DbHelper.Exam())
            {
                var exams = helper.GetExamList(schoolId, acaId, sesId);
                dlistExam.DataSource = exams;
                dlistExam.DataBind();
            }

            //both name combined
            lblAcaSesName.Text = combinedName;
        }
    }
}