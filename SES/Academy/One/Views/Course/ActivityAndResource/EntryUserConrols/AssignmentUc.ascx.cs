using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Course.ActivityAndResource.EntryUserConrols
{
    public partial class AssignmentUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtErrorMsg.Visible = false;
            if (!IsPostBack)
            {
                var grdType = Values.StaticValues.GradeTypeList;
                ddlGradeType.DataSource = grdType;
                ddlGradeType.DataBind();

                var submissionType = Values.StaticValues.SubmissionTypeList;
                ddlSubmissionType.DataSource = submissionType;
                ddlSubmissionType.DataBind();
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
            return;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(ddlSubmissionType.SelectedValue))
                submissionListVali.IsValid = false;
            if (string.IsNullOrEmpty(ddlGradeType.SelectedValue))
                gradeListVali.IsValid = false;

            if (Page.IsValid)
            {
                using (var helper = new DbHelper.ActAndRes())
                {
                    var user = Page.User as CustomPrincipal;
                    if (user == null)
                    {
                        return;
                    }
                    if (user.Id <= 0)
                        return;

                    if (user.IsInRole("teacher") || user.IsInRole("manager") ||
                        user.IsInRole(One.Values.StaticValues.Roles.CourseEditor))
                    {
                        if (SectionId > 0)
                        {
                            var assg = new Academic.DbEntities.ActivityAndResource.Assignment()
                            {
                                Id = AssignmentId
                                ,
                                CreatedDate = DateTime.Now
                                ,
                                Description = txtDesc.Text
                                ,
                                GradeToPass = txtGradeToPass.Text
                                ,
                                DispalyDescriptionOnPage = chkDisplayDesc.Checked
                                ,
                                GradeType = ddlGradeType.SelectedItem.Text
                                ,
                                Name = txtName.Text
                                ,
                                MaximumGrade = txtMaxGradde.Text

                                ,
                                //SectionId = SectionId
                                //,


                                //SubmissionType = ddlSubmissionType.SelectedItem.Text
                                //,
                            };

                            if (ddlSubmissionType.SelectedValue == "Online")
                            {
                                assg.WordLimit = Convert.ToInt32(txtWordLimit.Text);
                            }
                            else
                            {
                                assg.MaximumNoOfUploadedFiles = Convert.ToInt32(txtMaxFiles.Text);
                                assg.MaximumSubmissionSize = Convert.ToInt32(txtMaxSize.Text);
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
                            var saved = helper.AddOrUpdateAssignment(assg);
                            if (saved != null)
                            {
                                return;
                            }
                            else
                            {
                                txtErrorMsg.Visible = true;
                            }
                        }
                    }
                }
            }
        }

    }
}