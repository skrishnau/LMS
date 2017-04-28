using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Exam.Exam
{
    public partial class CreateExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!IsPostBack)
            {
                //Page.ValidateRequestMode = ValidateRequestMode.Disabled;

                var aId = Request.QueryString["aId"];
                var sId = Request.QueryString["sId"];
                var eId = Request.QueryString["eId"];

                try
                {
                    if (aId != null)
                    {
                        if (sId != null)
                        {
                            SessionId = Convert.ToInt32(sId.ToString());
                        }
                        AcademicYearId = Convert.ToInt32(aId.ToString());
                    }
                    if (eId != null)
                    {
                        //edit 
                        ExamTypeId = Convert.ToInt32(eId.ToString());
                    }
                }
                catch
                {
                    Response.Redirect("~/Views/Exam/Exam/ExamsList.aspx");
                }


                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    hidSchoolId.Value = user.SchoolId.ToString();
                    using (var helper = new DbHelper.Exam())
                    {
                        var et = helper.ListExamTypes(user.SchoolId);

                        et.Insert(0, new Academic.DbEntities.Exams.ExamType()
                        {
                            Id = 0
                            ,
                            Name = "Custom..."
                        });
                        cmbExamType.DataSource = et;
                        cmbExamType.DataBind();
                    }
                }

            }

            LoadPrograms();
            //string parameter = Request["__EVENTARGUMENT"];
            //if (parameter == "visible")
            //{
            //    //pnlCoordinator.Visible = true;
            //}
            //else if (parameter == "invisible")
            //{
            //    pnlCoordinator.Visible = false;                

            //}
        }

        private void LoadPrograms()
        {
            using (var helper = new DbHelper.AcademicPlacement())
            {
                var rList = helper.ListRunningRunningClasses(AcademicYearId, SessionId);
                //uncomment this
                //ProgramSelection1.LoadStructure(rList, AcademicYearId, SessionId, ExamId);
            }
        }


        #region Properties

        public int ExamId
        {
            get { return Convert.ToInt32(hidExamId.Value); }
            set { hidExamId.Value = value.ToString(); }
        }

        public int ExamTypeId
        {
            get { return Convert.ToInt32(cmbExamType.SelectedValue); }
            set { cmbExamType.SelectedValue = value.ToString(); }
        }
        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYearId.Value); }
            set { this.hidAcademicYearId.Value = value.ToString(); }
        }
        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { this.hidSessionId.Value = value.ToString(); }
        }

        #endregion


        protected void txtUser_TextChanged(object sender, EventArgs e)
        {
            //using (var helper = new DbHelper.User())
            //{
            //    var users = helper.ListUsersWithNameStartingFrom(txtCoOrdinator.Text);
            //    dlistCorinator.DataSource = users;
            //    dlistCorinator.DataBind();

            //    pnlCoordinator.Visible = true;
            //}
        }

        protected void cmbExamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbExamType.SelectedValue == "" || cmbExamType.SelectedValue == "0"))
            {

                pnlEntry.BackColor = Color.LightGoldenrodYellow;
                pnlEntry.Enabled = true;
            }
            else
            {
                //update the controls
                SetNames();
                pnlEntry.BackColor = Color.LightGray;
                pnlEntry.Enabled = false;
            }
        }

        public void SetNames()
        {
            using (var helper = new DbHelper.Exam())
            {
                var type = helper.GetExamType(Convert.ToInt32(cmbExamType.SelectedValue));
                if (type != null)
                {
                    txtName.Text = type.Name;
                    txtWeight.Text = type.Weight == null ? "" : type.Weight.ToString();
                    ddlWeight.SelectedIndex = (type.IsPercent) ? 0 : 1;
                    CKEditor1.Text = type.Notice;
                }
            }
        }

        protected void btnSaveExam_Click(object sender, EventArgs e)
        {
            var user = User as CustomPrincipal;
            //var text = txtNotice.Text;
            //if (text.Contains("script"))
            //{
            //    return;
            //}

            if (Page.IsValid && user!=null)
            {
                var exam = new Academic.DbEntities.Exams.Exam();
                if (cmbExamType.SelectedValue == "0")
                {
                    //then exam will be custom

                    exam.Id = ExamId;
                    exam.AcademicYearId = AcademicYearId;
                    //exam.ExamCoordinatorId = Convert.ToInt32(cor)
                    exam.Name = txtName.Text;
                    exam.Weight = (float)Convert.ToDecimal(txtWeight.Text == "" ? "0" : txtWeight.Text);
                    exam.CreatedDate = DateTime.Now;
                    exam.NoticeContent = CKEditor1.Text;
                    exam.SchoolId = user.SchoolId;
                    exam.CreatedBy = user.Id;
                    exam.IsPercent = (ddlWeight.SelectedIndex == 0) ? true : false;
                    exam.PublishNoticeToNoticeBoard = chkPublish.Checked;

                    if (!String.IsNullOrEmpty(txtStartDate.Text))
                        exam.StartDate = Convert.ToDateTime(txtStartDate.Text);
                    if (!String.IsNullOrEmpty(txtResultDate.Text))
                        exam.ResultDate = Convert.ToDateTime(txtResultDate.Text);

                    if (SessionId > 0)
                        exam.SessionId = SessionId;
                    //not needed to insert examTypeId since its now custom
                    if (ExamTypeId == 0)
                        exam.ExamTypeId = null;
                    //if (ExamTypeId > 0)
                    //    exam.ExamTypeId = ExamTypeId;
                    if (ExamId > 0)
                    {
                        exam.Id = ExamId;
                    }
                }
                else
                {
                    //then exam will be refrencing examType
                    exam.Id = ExamId;
                    exam.AcademicYearId = AcademicYearId;
                    //exam.ExamCoordinatorId = Convert.ToInt32(cor)
                    //exam.Name = txtName.Text
                    //exam.Weight = (float)Convert.ToDecimal(txtWeight.Text == "" ? "0" : txtWeight.Text)
                    exam.CreatedDate = DateTime.Now;
                    exam.NoticeContent = CKEditor1.Text;
                    exam.SchoolId = user.SchoolId;
                    exam.CreatedBy = user.Id;
                    exam.PublishNoticeToNoticeBoard = chkPublish.Checked;

                    //IsPercent = (ddlWeight.SelectedIndex == 0) ? true : false
                    //,


                    if (!String.IsNullOrEmpty(txtStartDate.Text))
                        exam.StartDate = Convert.ToDateTime(txtStartDate.Text);
                    if (!String.IsNullOrEmpty(txtResultDate.Text))
                        exam.ResultDate = Convert.ToDateTime(txtResultDate.Text);

                    if (SessionId > 0)
                        exam.SessionId = SessionId;
                    if (ExamTypeId > 0)
                        exam.ExamTypeId = ExamTypeId;
                    if (ExamId > 0)
                    {
                        exam.Id = ExamId;
                    }
                }
                using (var helper = new DbHelper.Exam())
                {
                    //uncomment this
                    //var saved = helper.AddOrUpdateExam(exam, user.Id, ProgramSelection1.GetData(),txtTitleOfNotice.Text);
                    //if (saved != null)
                    //{
                    //    Response.Redirect("~/Views/Exam/Exam/ExamsList.aspx?aId=" + saved.AcademicYearId + "&sId=" +
                    //                      (saved.SessionId ?? 0));
                    //}
                    //else
                    //{
                    //    lblError.Visible = true;
                    //}
                }
            }
        }

        protected void chkPublish_CheckedChanged(object sender, EventArgs e)
        {
            pnlNoticeTitle.Visible = chkPublish.Checked;
            txtTitleOfNotice.Text = txtName.Text;
        }




    }
}