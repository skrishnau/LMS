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
            var user = User as CustomPrincipal;
            txtErrorMsg.Visible = false;
            if (!IsPostBack)
            {
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                try
                {
                    if (subId != null && secId != null)
                    {
                        var sId = Convert.ToInt32(subId);
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = sId;

                        //ClassesInActivityChoose1.SubjectId = sId;
                        RestrictionUC.SubjectId = sId;

                    }
                }
                catch
                {
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }
                //var grdType = Values.StaticValues.GradeTypeList;
                //ddlGradeType.DataSource = grdType;
                //ddlGradeType.DataBind();

                //var submissionType = Values.StaticValues.SubmissionTypeList;
                //ddlSubmissionType.DataSource = submissionType;
                //ddlSubmissionType.DataBind();
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

            if (Page.IsValid)
            {
                using (var helper = new DbHelper.ActAndRes())
                {
                    var user = Page.User as CustomPrincipal;

                    if (user.IsInRole("teacher") || user.IsInRole("manager") ||
                        user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor))
                    {
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


                                };

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

                                var restriction = RestrictionUC.GetRestriction();

                                var saved = helper.AddOrUpdateAssignmentActivity(assg, SectionId,restriction);
                                if (saved != null)
                                {
                                    Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
                                }
                                else
                                {
                                    txtErrorMsg.Visible = true;
                                }
                            }
                            catch { }
                        }
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