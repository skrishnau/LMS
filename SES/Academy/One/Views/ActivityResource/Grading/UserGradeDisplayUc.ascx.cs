using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Grading
{
    public partial class UserGradeDisplayUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This UC is used and this function is called by only activity.
        /// </summary>
        /// <param name="clsUser">UserClass</param>
        /// <param name="actResId">ActivityResource table id</param>
        /// <param name="actOrResId">ids of assignment, forum, choice etc</param>
        /// <param name="actOrResType">type of activity, 1=assignment, 2=....</param>
        public void SetData(Academic.DbEntities.Class.UserClass clsUser, int actResId, int actOrResId, byte actOrResType)
        {
            var name = "";
            name += string.IsNullOrEmpty(clsUser.User.FirstName) ? "" : clsUser.User.FirstName + " ";
            name += string.IsNullOrEmpty(clsUser.User.MiddleName) ? "" : clsUser.User.MiddleName + " ";
            name += string.IsNullOrEmpty(clsUser.User.LastName) ? "" : clsUser.User.LastName;
            lblName.Text = name;
            lblUserName.Text = clsUser.User.UserName;
            lblEmail.Text = clsUser.User.Email;
            imgImage.ImageUrl = clsUser.User.UserImage == null ? "" : string.IsNullOrEmpty(clsUser.User.UserImage.IconPath) ? "" : clsUser.User.UserImage.IconPath;
            if ((clsUser.Suspended ?? false))
            {
                lblGrade.Text = " - ";
                lblSubmissionStatus.Text = "Suspended";
            }
            else
            {
                switch (actOrResType)
                {
                    case (byte)Enums.Activities.Assignment + 1:
                        var submission = clsUser.AssignmentSubmissions.FirstOrDefault(x => x.AssignmentId == actOrResId);
                        if (submission != null)
                        {

                            lblSubmissionStatus.Text = submission.ModifiedDate == null
                                ? submission.SubmittedDate.ToString("g")
                                : submission.ModifiedDate.Value.ToString("g");
                            chkSubmitted.Checked = true;
                            chkSubmitted.Visible = true;
                            //lnkSubmission.NavigateUrl =
                            //    "~/Views/ActivityResource/Assignments/AssignmentCheckCreate.aspx";

                            var grade = clsUser.ActivityGradings.FirstOrDefault(x =>
                                                                x.ActivityResource.ActivityResourceId == actOrResId
                                                                 &&
                                                                 x.ActivityResource.ActivityResourceType == actOrResType);
                            var gradeLink = "~/Views/ActivityResource/Assignments/AssignmentCheckCreate.aspx";
                            //var assGrade = submission.Assignment.GradeType;

                            if (grade != null)
                            {
                                if (submission.Assignment.GradeType.RangeOrValue)//value
                                {
                                    if (grade.ObtainedGradeId != null)
                                    {
                                        lblGrade.Text = grade.ObtainedGrade.Value;
                                        try
                                        {
                                            var obtgrd = (float)Convert.ToDecimal(grade.ObtainedGrade.EquivalentPercentOrPostition ?? 0);
                                            var grdtopass =
                                                submission.Assignment.GradeType.GradeValues.FirstOrDefault(x =>
                                                    x.Id == Convert.ToInt32(submission.Assignment.GradeToPass));

                                            if (grdtopass != null)
                                            {
                                                var gtp = (float)Convert.ToDecimal(grdtopass.EquivalentPercentOrPostition);
                                                if (obtgrd.CompareTo(gtp) < 0)
                                                {
                                                    //orange color
                                                    lblGrade.Text += " (F)";
                                                    lblGrade.ForeColor = Color.Red;
                                                }
                                            }

                                        }
                                        catch { }
                                        //if (submission.Assignment.GradeType.GradeValueIsInPercentOrPostition ?? false)
                                        //{
                                        //    //percent
                                        //    //lblGrade.Text += " %";

                                        //}
                                        //else
                                        //{
                                        //    //position
                                        //    try
                                        //    {
                                        //        var obtgrd = Convert.ToInt32(grade.ObtainedGrade.EquivalentPercentOrPostition??0);
                                        //        var gradetopass = submission.Assignment.GradeType.GradeValues.FirstOrDefault(x =>
                                        //                x.Id == Convert.ToInt32(submission.Assignment.GradeToPass));
                                        //        if (gradetopass != null)
                                        //        {
                                        //            var gtp = Convert.ToInt32(gradetopass.Value);
                                        //            if (obtgrd < gtp)
                                        //            {
                                        //                //orange color
                                        //                lblGrade.Text += " (F)";
                                        //            }
                                        //        }
                                        //    }catch{}
                                        //}
                                    }
                                }
                                else//range
                                {
                                    lblGrade.Text = (grade.ObtainedGradeMarks ?? 0).ToString("F");
                                    var obtgrd = grade.ObtainedGradeMarks ?? 0;
                                    var gtp = (float)Convert.ToDecimal(submission.Assignment.GradeToPass);
                                    if (obtgrd.CompareTo(gtp) < 0)
                                    {
                                        //orange color
                                        lblGrade.Text += " (F)";
                                        lblGrade.ForeColor = Color.Red;
                                    }
                                }

                            }
                            else
                            {
                                lblGrade.Text = "Click to grade";
                            }
                            lnkGrade.NavigateUrl = gradeLink + "?actId=" + submission.Assignment.Id
                             + "&ucId=" + clsUser.Id + "&actResId=" + actResId + "&SubId=" + SubjectId
                             + "&secId=" + SectionId + "&actGrdId=" + (grade == null ? "0" : grade.Id.ToString());
                            lnkSubmission.NavigateUrl = lnkGrade.NavigateUrl;
                        }
                        else
                        {
                            lblSubmissionStatus.Text = " - ";

                            //lblGrade.Text = "Click to grade";
                        }

                        break;
                }

            }
        }



        //public int ActivityId
        //{
        //    get { return Convert.ToInt32(hidActivityId.Value); }
        //    set { hidActivityId.Value = value.ToString(); }
        //}

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
        //public int UserClassId
        //{
        //    get { return Convert.ToInt32(hidUserClassId.Value); }
        //    set { hidUserClassId.Value = value.ToString(); }
        //}
        //public int ActivityResourceId
        //{
        //    get { return Convert.ToInt32(hidActivityResourceId.Value); }
        //    set { hidActivityResourceId.Value = value.ToString(); }
        //}
    }
}