using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.ActivityResource.Assignments
{
    public partial class AssignmentCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblValiMaxFile.Visible = false;
            lblValiWordLimit.Visible = false;
            lblValiSubmissionSize.Visible = false;

            valiDue.Visible = false;
            valiFrom.Visible = false;
            valiCutOff.Visible = false;

            var user = User as CustomPrincipal;

            lblError.Visible = false;
            if (user != null)
            {
                if (user.IsInRole("teacher") || user.IsInRole("manager") ||
                   user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor))
                {
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
                                GradeInActivityUc1.LoadInitial(user);
                                LoadAssignment();
                            }
                            else
                            {
                                GradeInActivityUc1.LoadInitial(user);
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

                    }
                }
                else
                    Response.Redirect("~/");
            }
            else
            {
                Response.Redirect("~/");
            }
        }

       

       


       

        private void LoadAssignment()
        {
            using (var helper = new DbHelper.ActAndRes())
            {

                var ass = helper.GetAssignment(AssignmentId);
                if (ass != null)
                {
                    RestrictionUC.SetActivityResource(true, ((int)Enums.Activities.Assignment) + 1, ass.Id);
                    var actRes = helper.GetActivityResource(true, ((int)Enums.Activities.Assignment) + 1, ass.Id);
                    if (actRes != null)
                    {
                        var classes = new List<IdAndName>();
                        foreach (var cls in actRes.ActivityClasses.AsEnumerable())
                        {
                            classes.Add(new IdAndName()
                            {
                                Id = cls.SubjectClassId
                                ,
                                Name = cls.SubjectClass.IsRegular ? cls.SubjectClass.GetName : cls.SubjectClass.Name
                                ,
                                Void = false
                            });
                        }

                        txtName.Text = ass.Name;
                        CKEditor1.Text = ass.Description;
                        chkDisplayDesc.Checked = ass.DispalyDescriptionOnPage ?? false;

                        ClassesInActivityChoose1.PopulateClassPanel(classes);

                        GradeInActivityUc1.SetGradeValues(actRes,ass);


                        #region File and online submission

                        if (ass.FileSubmission)
                        {
                            chkFileSubmission.Checked = true;
                            txtMaxFiles.Text = (ass.MaximumNoOfUploadedFiles ?? 0).ToString();
                            txtMaxSize.Text = (ass.MaximumSubmissionSize ?? 0).ToString();
                            txtMaxFiles.Enabled = true;
                            txtMaxSize.Enabled = true;
                        }
                        else
                        {
                            chkFileSubmission.Checked = false;
                            txtMaxFiles.Enabled = false;
                            txtMaxSize.Enabled = false;
                        }

                        if (ass.OnlineText)
                        {

                            chkOnlineSubmission.Checked = true;
                            txtWordLimit.Text = ass.WordLimit.ToString();
                            txtWordLimit.Enabled = true;
                        }
                        else
                        {
                            chkOnlineSubmission.Checked = false;
                            txtWordLimit.Enabled = false;
                        }

                        #endregion


                        #region Date

                        if (ass.CutOffDate != null)
                        {
                            chkCutOff.Checked = true;
                            txtCutOff.Text = ass.CutOffDate.Value.ToShortDateString();

                        }
                        else
                        {
                            chkCutOff.Checked = false;
                            txtCutOff.Enabled = false;
                        }

                        if (ass.DueDate != null)
                        {
                            chkDue.Checked = true;
                            txtDue.Text = ass.DueDate.Value.ToShortDateString();
                            txtDue.Enabled = true;
                        }
                        else
                        {
                            chkDue.Checked = false;
                            txtDue.Enabled = false;
                        }

                        if (ass.SubmissionFrom != null)
                        {
                            chkFrom.Checked = true;
                            txtFrom.Text = ass.SubmissionFrom == null
                                ? ""
                                : ass.SubmissionFrom.Value.ToShortDateString();
                            txtFrom.Enabled = true;

                        }
                        else
                        {
                            chkFrom.Checked = false;
                            txtFrom.Enabled = false;
                        }

                        #endregion

                        //here
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
            set
            {
                hidSubjectId.Value = value.ToString();
                RestrictionUC.SubjectId = value;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId, SectionId));
            //Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(ddlSubmissionType.SelectedValue))
            //    submissionListVali.IsValid = false;
            var isValid = true;

            var grade = GradeInActivityUc1.GetGrade();

            if (grade == null)
                return;
            //if (string.IsNullOrEmpty(ddlGradeType.SelectedValue))
            //    gradeListVali.IsValid = false;


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
                        isValid = false;
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
                                DispalyDescriptionOnPage = chkDisplayDesc.Checked
                                ,
                                Name = txtName.Text
                                ,
                                FileSubmission = chkFileSubmission.Checked
                                ,
                                OnlineText = chkOnlineSubmission.Checked
                            };

                            if (grade.GradeTypeId > 0)
                            {
                                assg.GradeTypeId = grade.GradeTypeId;
                                assg.MaximumGrade = grade.MaximumGradeInString;//ddlMaximumGrade.SelectedValue;
                                assg.GradeToPass = grade.GradeToPassInString;//ddlGradeToPass.SelectedValue;
                            }
                            
                            //if (ddlGradeType.SelectedValue != "0")
                            //{
                            //    assg.GradeTypeId = Convert.ToInt32(ddlGradeType.SelectedValue);
                            //    if (ddlMaximumGrade.Visible && ddlGradeToPass.Visible)
                            //    {
                            //        assg.MaximumGrade = ddlMaximumGrade.SelectedValue;
                            //        assg.GradeToPass = ddlGradeToPass.SelectedValue;
                            //    }
                            //    else if (txtMaxGradde.Visible && txtGradeToPass.Visible)
                            //    {
                            //        assg.MaximumGrade = txtMaxGradde.Text;
                            //        assg.GradeToPass = txtGradeToPass.Text;
                            //    }
                            //}



                            #region File and online submission

                            if (chkFileSubmission.Checked)
                            {
                                try
                                {
                                    assg.MaximumNoOfUploadedFiles = Convert.ToInt32(txtMaxFiles.Text);
                                }
                                catch (Exception)
                                {
                                    lblValiMaxFile.Visible = true;
                                    isValid = false;
                                }
                                try
                                {
                                    assg.MaximumSubmissionSize = Convert.ToInt32(txtMaxSize.Text);
                                }
                                catch
                                {
                                    lblValiSubmissionSize.Visible = true;
                                    isValid = false;
                                }
                            }
                            else
                            {
                                assg.MaximumNoOfUploadedFiles = null;
                                assg.MaximumSubmissionSize = null;
                            }

                            if (chkOnlineSubmission.Checked)
                            {
                                try
                                {
                                    assg.WordLimit = Convert.ToInt32(txtWordLimit.Text);

                                }
                                catch
                                {
                                    lblValiWordLimit.Visible = true;
                                    isValid = false;
                                }
                            }
                            else
                            {
                                assg.WordLimit = null;
                            }


                            #endregion


                            #region Dates

                            if (chkFrom.Checked)
                            {
                                try
                                {
                                    assg.SubmissionFrom = Convert.ToDateTime(txtFrom.Text);

                                }
                                catch (Exception)
                                {
                                    valiFrom.Visible = true;
                                    isValid = false;
                                }
                            }
                            else assg.SubmissionFrom = null;

                            if (chkDue.Checked)
                            {
                                try
                                {
                                    assg.DueDate = Convert.ToDateTime(txtDue.Text);
                                }
                                catch
                                {
                                    valiDue.Visible = true;
                                    isValid = false;
                                }
                            }
                            else assg.DueDate = null;


                            if (chkCutOff.Checked)
                            {
                                try
                                {
                                    assg.CutOffDate = Convert.ToDateTime(txtCutOff.Text);
                                }
                                catch
                                {
                                    valiCutOff.Visible = true;
                                    isValid = false;
                                }
                            }
                            else assg.CutOffDate = null;
                            #endregion

                            #region Classes

                            var cls = ClassesInActivityChoose1.GetClasses();


                            #endregion

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
                            
                            //var weight = (float)0.0;
                            var weight = grade.WeightInGradeSheetInFloat ?? 0;
                            assg.ShowGradeToStudents = grade.ShowGradeToStudents;
                            //try
                            //{
                            //    if (!string.IsNullOrEmpty(txtWeightInGradeSheet.Text))
                            //    {
                            //        weight = (float)Convert.ToDecimal(txtWeightInGradeSheet.Text);
                            //        if (weight < 0 || weight > 100)
                            //        {
                            //            valiWeightInGradeSheet.Visible = true;
                            //            return;
                            //        }
                            //    }
                            //}
                            //catch
                            //{
                            //    valiWeightInGradeSheet.Visible = true;
                            //    return;
                            //}
                            if (isValid && Page.IsValid)
                            {
                                var saved = helper.AddOrUpdateAssignmentActivity(assg, SectionId, restriction, cls, weight);
                                if (saved != null)
                                {
                                    Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId, SectionId));
                                    //Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" +
                                    //                  SubjectId + "&edit=1#section_" + SectionId);
                                }
                                else
                                {
                                    lblError.Visible = true;
                                }
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


    }
}