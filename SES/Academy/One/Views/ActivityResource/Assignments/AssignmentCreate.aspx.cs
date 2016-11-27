using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.ActivityResource.Assignments
{
    public partial class AssignmentCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblValiMaxFile.Visible = false;
            lblValiWordLimit.Visible = false;

            var user = User as CustomPrincipal;

            lblError.Visible = false;
            if (user != null)
                if (!IsPostBack)
                {
                    var aId = Request.QueryString["arId"];
                    var subId = Request.QueryString["SubId"];
                    var secId = Request.QueryString["SecId"];
                    try
                    {
                        if (subId != null && secId != null)
                        {
                            var sId = Convert.ToInt32(subId);
                            SectionId = Convert.ToInt32(secId);
                            SubjectId = sId;

                            ClassesInActivityChoose1.SubjectId = sId;
                            RestrictionUC.SubjectId = sId;

                        }
                        if (aId != null)
                        {
                            AssignmentId = Convert.ToInt32(aId);
                            LoadAssignment();
                        }
                    }
                    catch
                    {
                        Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                    }
                    LoadInitial(user);
                    //var grdType = Values.StaticValues.GradeTypeList;
                    //ddlGradeType.DataSource = grdType;
                    //ddlGradeType.DataBind();

                    //var submissionType = Values.StaticValues.SubmissionTypeList;
                    //ddlSubmissionType.DataSource = submissionType;
                    //ddlSubmissionType.DataBind();

                }
        }

        private void LoadInitial(CustomPrincipal user)
        {
            if (user != null)
                using (var gradeHelper = new DbHelper.Grade())
                {
                    var gradelist = gradeHelper.ListGrades(user.SchoolId);
                    ddlGradeType.DataSource = gradelist;
                    ddlGradeType.DataBind();

                    if (gradelist.Any())
                    {
                        var grade = gradelist[0]; //gradeHelper.GetGrade(Convert.ToInt32(ddlGradeType.SelectedValue));
                        if (txtMaxGradde != null)
                        {
                            if (grade.Type == "range")
                            {
                                ddlMaximumGrade.Visible = false;
                                ddlGradeToPass.Visible = false;

                                txtGradeToPass.Visible = true;
                                txtMaxGradde.Visible = true;
                            }
                            else
                            {
                                ddlMaximumGrade.Visible = true;
                                ddlGradeToPass.Visible = true;

                                txtGradeToPass.Visible = false;
                                txtMaxGradde.Visible = false;

                                var gradeValues = gradeHelper.ListGradeValues(grade.Id);
                                ddlMaximumGrade.DataSource = gradeValues;
                                ddlGradeToPass.DataSource = gradeValues;
                                ddlMaximumGrade.DataBind();
                                ddlGradeToPass.DataBind();
                            }
                        }
                    }
                }
        }




        private void LoadAssignment()
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var ass = helper.GetAssignment(AssignmentId);
                if (ass != null)
                {
                    txtName.Text = ass.Name;
                    txtGradeToPass.Text = ass.GradeToPass;
                    txtMaxGradde.Text = ass.MaximumGrade;
                    txtMaxFiles.Text = (ass.MaximumNoOfUploadedFiles ?? 0).ToString();
                    txtWordLimit.Text = ass.WordLimit.ToString();

                    CKEditor1.Text = ass.Description;



                    chkFrom.Checked = ass.SubmissionFrom != null;
                    chkFileSubmission.Checked = ass.FileSubmission;
                    chkDue.Checked = ass.DueDate != null;
                    chkCutOff.Checked = ass.CutOffDate != null;
                    chkOnlineSubmission.Checked = ass.OnlineText;
                    chkDisplayDesc.Checked = ass.DispalyDescriptionOnPage ?? false;


                    txtCutOff.Text = ass.CutOffDate == null ? "" : ass.CutOffDate.Value.ToShortDateString();
                    txtDue.Text = ass.DueDate == null ? "" : ass.DueDate.Value.ToShortDateString();
                    txtFrom.Text = ass.SubmissionFrom == null ? "" : ass.SubmissionFrom.Value.ToShortDateString();
                }
            }
        }

        public int AssignmentId
        {
            get { return Convert.ToInt32(hidAssignmentId.Value); }
            set { hidAssignmentId.Value = value.ToString(); }
        }

        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(ddlSubmissionType.SelectedValue))
            //    submissionListVali.IsValid = false;

            if (string.IsNullOrEmpty(ddlGradeType.SelectedValue))
                gradeListVali.IsValid = false;

            if (!Page.IsValid)
                return;

            using (var helper = new DbHelper.ActAndRes())
            {
                var user = Page.User as CustomPrincipal;

                if (user.IsInRole("teacher") || user.IsInRole("manager") ||
                    user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor))
                {
                    var restriction = RestrictionUC.GetRestriction();
                    if (!RestrictionUC.IsValid)
                    {
                        lblError.Visible = true;
                        return;
                    }

                    if (SectionId > 0)
                    {
                        try
                        {
                            var assg = new Academic.DbEntities.ActivityAndResource.Assignment()
                            {
                                Id = AssignmentId
                                ,
                                CreatedDate = DateTime.Now
                                ,
                                Description = CKEditor1.Text
                                ,
                                GradeToPass = txtGradeToPass.Text
                                ,
                                DispalyDescriptionOnPage = chkDisplayDesc.Checked
                                ,
                                GradeTypeId = Convert.ToInt32(ddlGradeType.SelectedValue)
                                ,
                                Name = txtName.Text
                                ,
                                FileSubmission = chkFileSubmission.Checked
                                ,
                                OnlineText = chkOnlineSubmission.Checked


                            };
                            if (chkFileSubmission.Checked)
                            {
                                if (string.IsNullOrEmpty(txtMaxFiles.Text))
                                {
                                    lblValiMaxFile.Visible = true;
                                    return;
                                }
                            }
                            if (chkOnlineSubmission.Checked)
                            {
                                if (string.IsNullOrEmpty(txtWordLimit.Text))
                                {
                                    lblValiWordLimit.Visible = true;
                                    return;
                                }
                            }

                            //if (ddlSubmissionType.SelectedValue == "Online")
                            //{
                            //    assg.WordLimit = Convert.ToInt32(txtWordLimit.Text);
                            //}
                            //else
                            if (ddlMaximumGrade.Visible && ddlGradeToPass.Visible)
                            {
                                assg.MaximumGrade = ddlMaximumGrade.SelectedValue;
                                assg.GradeToPass = ddlGradeToPass.SelectedValue;
                            }
                            else if (txtMaxGradde.Visible && txtGradeToPass.Visible)
                            {
                                assg.MaximumGrade = txtMaxGradde.Text;
                                assg.GradeToPass = txtGradeToPass.Text;
                            }

                            if (chkFileSubmission.Checked)
                            {
                                assg.MaximumNoOfUploadedFiles = Convert.ToInt32(txtMaxFiles.Text);
                                assg.MaximumSubmissionSize = Convert.ToInt32(txtMaxSize.Text);
                            }
                            if (chkOnlineSubmission.Checked)
                            {
                                assg.WordLimit = Convert.ToInt32(txtWordLimit.Text);
                            }

                            if (!String.IsNullOrEmpty(txtFrom.Text))
                            {
                                assg.SubmissionFrom = Convert.ToDateTime(txtFrom.Text);
                            }
                            if (!String.IsNullOrEmpty(txtDue.Text))
                            {
                                assg.DueDate = Convert.ToDateTime(txtDue.Text);
                            }
                            if (!String.IsNullOrEmpty(txtCutOff.Text))
                            {
                                assg.CutOffDate = Convert.ToDateTime(txtCutOff.Text);
                            }


                            if (AssignmentId > 0)
                            {
                                assg.ModifiedDate = DateTime.Now;
                                assg.ModifiedBy = user.Id;
                            }
                            else
                            {
                                assg.CreatedDate = DateTime.Now;
                                assg.CreatedBy = user.Id;
                            }


                            var saved = helper.AddOrUpdateAssignmentActivity(assg, SectionId, restriction);
                            if (saved != null)
                            {
                                Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
                            }
                            else
                            {
                                lblError.Visible = true;
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            var sen = sender as CheckBox;
            if (sen != null)
            {
                var checkedval = sen.Checked;
                switch (sen.ID)
                {
                    case "chkFrom":
                        txtFrom.Enabled = checkedval;
                        break;
                    case "chkDue":
                        txtDue.Enabled = checkedval;
                        break;
                    case "chkCutOff":
                        txtCutOff.Enabled = checkedval;
                        break;
                    case "chkOnlineSubmission":
                        txtWordLimit.Enabled = checkedval;
                        break;
                    case "chkFileSubmission":
                        txtMaxFiles.Enabled = checkedval;
                        txtMaxSize.Enabled = checkedval;
                        break;

                }
            }
        }

        protected void ddlGradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.Grade())
            {
                var grade = helper.GetGrade(Convert.ToInt32(ddlGradeType.SelectedValue));
                if (txtMaxGradde != null)
                {
                    if (grade.Type == "Range")
                    {
                        ddlMaximumGrade.Visible = false;
                        ddlGradeToPass.Visible = false;

                        txtGradeToPass.Visible = true;
                        txtMaxGradde.Visible = true;
                    }
                    else
                    {
                        ddlMaximumGrade.Visible = true;
                        ddlGradeToPass.Visible = true;

                        txtGradeToPass.Visible = false;
                        txtMaxGradde.Visible = false;

                        var gradeValues = helper.ListGradeValues(grade.Id);
                        ddlMaximumGrade.DataSource = gradeValues;
                        ddlGradeToPass.DataSource = gradeValues;
                        ddlMaximumGrade.DataBind();
                        ddlGradeToPass.DataBind();
                    }
                }

            }
        }

    }
}