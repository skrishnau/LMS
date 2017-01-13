using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;
using One.Views.ActivityResource.Grading;

namespace One.Views.ActivityResource.Assignments
{
    public partial class AssignmentView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    try
                    {
                        var aId = Request.QueryString["arId"];
                        var subId = Request.QueryString["SubId"];
                        var secId = Request.QueryString["secId"];

                        if (subId != null && secId != null && aId != null)
                        {
                            SubjectId = Convert.ToInt32(subId);
                            SectionId = Convert.ToInt32(secId);

                            var assId = Convert.ToInt32(aId);
                            AssignmentId = assId;

                            PopulateClasses( user);
                        }
                        else { Response.Redirect("~/"); }

                    }
                    catch { }
                }
        }
        //DbHelper.ActAndRes ahelper,
        private void PopulateClasses(CustomPrincipal user)
        {
            using (var ahelper = new DbHelper.ActAndRes())
            {
                var actres = ahelper.GetActivityResource(true, (byte) (Enums.Activities.Assignment + 1), AssignmentId);

                if (actres != null)
                {

                    ahelper.SetActivityResourceView(actres.Id, SubjectId, user.Id);
                    var submitButtonVisiblity = true;
                    var colorChange = false;
                    //Color backColor = Color.White;
                    //Color foreColor = Color.Black;
                    var status = "";
                    var grade = "N/A";
                    var remarks = "";

                    var assignmentId = AssignmentId;

                    #region Restriction and all codes

                    var elligible = false;
                    var roles = user.GetRoles();
                    if (roles.Contains(DbHelper.StaticValues.Roles.CourseEditor.ToString())
                        || roles.Contains(DbHelper.StaticValues.Roles.Manager.ToString())
                        || roles.Contains(DbHelper.StaticValues.Roles.Admin)
                        || roles.Contains("teacher"))
                    {
                        elligible = true;
                    }

                    var canView = elligible;
                    if (!canView)
                        canView = ahelper.EvaluateRestriction(null, actres.Restriction, user.Id);
                    //else
                    //    submitButtonVisiblity = false;

                    if (canView)
                    {
                        #region Assignment Load

                        var date = DateTime.Now;
                        var ass = ahelper.GetAssignment(assignmentId);
                        if (ass != null)
                        {
                            var timeRemaining = "N/A";
                            //actres will be used for restriction n class
                            lblName.Text = ass.Name;
                            lblPageTitle.Text = ass.Name;
                            lblDescription.Text = ass.Description;

                            #region Date and time Calculation

                            if (ass.SubmissionFrom != null)
                            {
                                if (ass.SubmissionFrom > date)
                                {
                                    var rem = (ass.SubmissionFrom.Value - date);
                                    timeRemaining = (rem.Days > 0 ? (rem.Days + " days ") : "")
                                                    + (rem.Hours > 0 ? (rem.Hours + " hours ") : "")
                                                    + (rem.Minutes > 0 ? (rem.Minutes + " minutes ") : "")
                                                    + " for submission start.";
                                    submitButtonVisiblity = false;
                                }

                            }

                            if (ass.DueDate != null)
                            {
                                lblDueDate.Text = ass.DueDate.Value.ToString("f");
                                if (ass.DueDate < date)
                                {
                                    var rem = (date - ass.DueDate.Value);
                                    timeRemaining = (rem.Days > 0 ? (rem.Days + " days ") : "")
                                                    + (rem.Hours > 0 ? (rem.Hours + " hours ") : "")
                                                    + (rem.Minutes > 0 ? (rem.Minutes + " minutes ") : "")
                                                    + " elapsed since due date.";
                                    //timeRemaining = "Due date finished on " + ass.DueDate.Value.ToString("f");
                                    colorChange = true;
                                    //backColor = Color.DeepPink;
                                    //foreColor = Color.White;
                                }
                                else
                                {
                                    var rem = (ass.DueDate.Value - date);
                                    timeRemaining = (rem.Days > 0 ? (rem.Days + " days ") : "")
                                                    + (rem.Hours > 0 ? (rem.Hours + " hours ") : "")
                                                    + (rem.Minutes > 0 ? (rem.Minutes + " minutes ") : "")
                                                    + " for submission end.";
                                }
                            }
                            else
                            {
                                lblDueDate.Text = "N/A";
                            }
                            if (ass.CutOffDate != null && ass.CutOffDate < date)
                            {
                                timeRemaining = "Sumission period end.";
                                submitButtonVisiblity = false;
                            }
                            lblTimeRemaining.Text = timeRemaining;


                            #endregion


                            #endregion

                            foreach (var c in actres.ActivityClasses)
                            {
                                var userclass = c.SubjectClass.ClassUsers.FirstOrDefault(y => y.UserId == user.Id);
                                if (userclass != null)
                                {
                                    #region Each class view initialize

                                    var subCls = c.SubjectClass;
                                    var classUc = (ClassGradeDisplayUc)
                                        Page.LoadControl("~/Views/ActivityResource/Grading/ClassGradeDisplayUc.ascx");
                                    classUc.SetData(subCls.IsRegular ? subCls.GetName : subCls.Name);
                                    if (subCls.SessionComplete ?? false)
                                    {
                                        classUc.Enable = false;
                                    }
                                    pnlGradeList.Controls.Add(classUc);
                                    pnlGradeList.Controls.Add(new Literal() {Text = "<br />"});
                                    pnlGradeList.Controls.Add(new Literal() {Text = "<br />"});

                                    #endregion

                                    if (userclass.Role.RoleName == "student")
                                    {
                                        #region submit view display

                                        classUc.ShowStudentListTableHeading = false;
                                        if (!(subCls.SessionComplete ?? false))
                                        {
                                            //disable the submit button
                                            var stdGradeUc = (StudentGradeDispalyUc)
                                                Page.LoadControl(
                                                    "~/Views/ActivityResource/Grading/StudentGradeDispalyUc.ascx");

                                            //stdGradeUc.RedirectUrl = "~/Views/ActivityResource/Grading/?actResId=" + actres.Id +
                                            //                                "&SubId=" + SubjectId +
                                            //                                "&secId=" + SectionId;

                                            stdGradeUc.RedirectUrl = "~/Views/ActivityResource/Assignments/SubmitAssignmentCreate.aspx?arId="
                                                                     + AssignmentId + "&SubId=" + SubjectId + "&secId=" +
                                                                     SectionId + "&ucId=" + userclass.Id;

                                            stdGradeUc.SubmitButtonVisible = ass.FileSubmission || ass.OnlineText;

                                            #region Submissions

                                            var subm = ass.Submissions.FirstOrDefault(x => x.UserClass.UserId == user.Id);
                                            var submissionEnabled = true;
                                            if (subm != null)
                                            {
                                                status = "Submitted on : "
                                                         +
                                                         ((subm.ModifiedDate == null)
                                                             ? subm.SubmittedDate.ToString("f")
                                                             : subm.ModifiedDate.Value.ToString("f"));
                                                stdGradeUc.SubmitButtonText = "Edit Submission";
                                                var obtgrade = actres.ActivityGradings.FirstOrDefault(
                                                                   x => x.UserClassId == subm.UserClassId);
                                                if (obtgrade != null)
                                                {
                                                    if (obtgrade.ObtainedGradeId != null)
                                                    {
                                                        grade = obtgrade.ObtainedGrade.Value;
                                                    }
                                                    else
                                                    {
                                                        grade = (obtgrade.ObtainedGradeMarks ?? 0).ToString("F");
                                                    }
                                                    submissionEnabled = false;//since already graded
                                                    remarks = obtgrade.Remarks;
                                                }
                                            }
                                            else
                                            {
                                                status = "Not submitted yet";
                                            }

                                           


                                            #endregion

                                            classUc.AddControlsOusideOfTable(stdGradeUc);
                                            stdGradeUc.SubmitButtonVisible = submitButtonVisiblity;
                                            if (colorChange)
                                            {
                                                stdGradeUc.SubmitDueIndicator = true;

                                                lblTimeRemaining.ForeColor = Color.Red;

                                                //lblTimeRemaining.ForeColor = foreColor;

                                                //stdGradeUc.SubmitButtonBackColor = backColor;
                                                //stdGradeUc.SubmitButtonForeColor = foreColor;
                                            }
                                            stdGradeUc.SetData(status, grade, remarks, submissionEnabled,ass.ShowGradeToStudents);
                                        }


                                        #endregion

                                        //ucStdRole.Add(userclass);
                                    }
                                    else if (userclass.Role.RoleName == "teacher"
                                        || userclass.Role.RoleName == "manager")
                                    {
                                        //grade uc display for that class

                                        #region Grading view display , start of teacher role

                                        classUc.ShowStudentListTableHeading = true;
                                        var any = false;
                                        foreach (var clsUser in subCls.ClassUsers.Where(x=>!(x.Void??false)))
                                        {
                                            //initialize each user uc
                                            if (clsUser.Role.RoleName == "student" && !(clsUser.Void ?? false))
                                            {
                                                var userUc = (UserGradeDisplayUc)
                                                    Page.LoadControl(
                                                        "~/Views/ActivityResource/Grading/UserGradeDisplayUc.ascx");
                                                userUc.SectionId = SectionId;
                                                userUc.SubjectId = SubjectId;
                                                userUc.SetData(clsUser, actres.Id, ass.Id, actres.ActivityResourceType);
                                                classUc.AddControls(userUc);
                                                any = true;

                                            }
                                           
                                        }

                                        if (!any)
                                        {
                                            classUc.AddControlsInsideTable(new Literal()
                                            {
                                                Text = "<tr>" +
                                                       "<td>" +
                                                       "No students found." +
                                                       "</td>" +
                                                       "</tr>"
                                            }, false);
                                        }

                                        #endregion of teacher role

                                    }

                                }
                            } //foreach end
                        }
                        else
                        {
                            Response.Redirect("~/");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/");
                    }

                    #endregion

                }
                else
                {
                    Response.Redirect("~/");
                }
            }
        }


        //public int UserClassId
        //{
        //    get { return Convert.ToInt32(hidUserClassId.Value); }
        //    set { hidUserClassId.Value = value.ToString(); }
        //}

        //private bool LoadUserClass(int userId)
        //{
        //    using (var helper = new DbHelper.Classes())
        //    {
        //        var cls = helper.GetUserClassOfUser(SubjectId, userId);

        //        if (cls != null)
        //        {
        //            UserClassId = cls.Id;
        //            if (cls.Role.RoleName == "teacher" || cls.Role.RoleName == "manager")
        //            {
        //                MultiView1.ActiveViewIndex = 1;
        //                return true;
        //            }
        //            else if (cls.Role.RoleName == "student")
        //            {
        //                MultiView1.ActiveViewIndex = 0;
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            btnSubmit.Visible = false;
        //            return false;
        //        }
        //        return false;
        //    }
        //}

        void LoadActivity(int assignmentId)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                using (var helper = new DbHelper.ActAndRes())
                {

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

        //protected void btnSubmit_OnClick(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/ActivityResource/Assignments/SubmitAssignmentCreate.aspx?arId="
        //        + AssignmentId + "&SubId=" + SubjectId + "&secId=" + SectionId + "&ucId=" + UserClassId);
        //}

        //protected void btnGrade_OnClick(object sender, EventArgs e)
        //{
        //    using (var helper = new DbHelper.ActAndRes())
        //    {
        //        var actres = helper.GetActivityResource(true, (byte)(Enums.Activities.Assignment + 1), AssignmentId);
        //        if (actres != null)
        //        {
        //            Response.Redirect("~/Views/ActivityResource/Grading/?actResId=" + actres.Id + "&SubId=" + SubjectId + "&secId=" + SectionId);
        //        }
        //    }
        //}
    }
}