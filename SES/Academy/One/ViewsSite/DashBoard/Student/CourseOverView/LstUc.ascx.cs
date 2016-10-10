using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Account;
using Academic.DbHelper;
using One.Values.MemberShip;
using One.ViewsSite.DashBoard.Student.UnJoinedCourses;

namespace One.ViewsSite.DashBoard.Student.CourseOverView
{
    public partial class LstUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CourseUc course = (CourseUc) Page.LoadControl("CourseUc.ascx");
                //phCourseList.
            }
            //lnkJoin_Click(new object(), new EventArgs());
            //LoadCourses();
            LoadCourses();
            //if (UserType == "student")
            //{
            //    LoadUnjoinedCourses();
            //}
            //else
            //{
            //    lnkJoin.Visible = false;
            //}
        }

        //public void LoadControls(List<> controls)
        //{

        //} 

        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYear.Value); }
            set { hidAcademicYear.Value = value.ToString(); }
        }

        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { hidSessionId.Value = value.ToString(); }
        }

        public int UserId
        {
            get { return Convert.ToInt32(hidStudentId.Value); }
            set { hidStudentId.Value = value.ToString(); }
        }

        public string UserType
        {
            get { return hidUserType.Value; }
            set { hidUserType.Value = value; }
        }
        //public int YearId { get; set; }
        //public int SubYearId { get; set; }

        //public int RunningClassId { get; set; }

        //public Academic.DbEntities.AcacemicPlacements.RunningClass RunningClass { get; set; }

        public List<Academic.ViewModel.AcademicPlacement.StudentSubjectModel> UserSubjectModels { get; set; }

        #endregion

        //void LoadCoursesFromDatabase()
        //{
        //    using (var acaplcHelper = new DbHelper.AcademicPlacement())
        //    {
        //        UserSubjectModels = acaplcHelper.GetClassesOfUser(SchoolId, AcademicYearId, SessionId,
        //            UserId, UserType);
        //       // ViewState["StudentSubjects"] = StudentSubjectModels;
        //    }
        //}

        //public void LoadCoursesFromViewState()
        //{
        //    var subjects = (List<Academic.ViewModel.AcademicPlacement.StudentSubjectModel>)ViewState["StudentSubjects"];
        //    if (UserSubjectModels == null)
        //    {
        //        if (subjects == null)
        //        {
        //            using (var acaplcHelper = new DbHelper.AcademicPlacement())
        //            {
        //                UserSubjectModels = acaplcHelper.GetClassesOfUser(SchoolId, AcademicYearId, SessionId,
        //                    UserId,UserType);
        //                ViewState["StudentSubjects"] = UserSubjectModels;
        //            }
        //        }
        //        else
        //        {
        //            UserSubjectModels = subjects;
        //        }
        //    }
        //    else
        //    {
        //        if (subjects == null)
        //        {
        //            ViewState["StudentSubjects"] = UserSubjectModels;
        //        }
        //    }
        //}

        public void LoadCourses()
        {
            //using(var acaHelper =new DbHelper.AcademicYear())
            //using (var acaplcHelper = new DbHelper.AcademicPlacement())
            //using (var helper = new DbHelper.Subject())
            //{

            //var clsOfStd = acaplcHelper.GetClassesOfStudent(SchoolId, AcademicYearId, SessionId, StudentId);

            using (var helper = new DbHelper.Subject())
            {
                try
                {
                    var loadType = 0;
                    if (hidLoadType.Value == "earlier")
                    {
                        loadType = 1;
                    }
                    else if (hidLoadType.Value != "current" && hidLoadType.Value != "")
                    {
                        Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                    }


                    var user = Page.User as CustomPrincipal;
                    if (user != null)
                    {
                        //var subjects = helper.GetCurrentRegularSubjectsOfUser(user.Id);
                        var subjectsArray = helper.ListCurrentAndEarlierCoursesOfUser(user.Id);
                        //foreach (var c in subjects[loadType])
                        foreach (var c in subjectsArray[loadType])
                        {
                            CourseUc uc =
                                (CourseUc)Page.LoadControl("~/ViewsSite/DashBoard/Student/CourseOverView/CourseUc.ascx");
                            uc.TitleNavigationTarget = "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" 
                                + c.Id;
                            uc.WithdrawVisible = false;

                            //the below 4 lines were previously uncommented ;
                            // now these replaced by adjacent 2 lines
                            //may be ViewModel should be used.. working on it.

                            //uc.Title = c.SubjectName;
                            //uc.Id = c.SubjectId.ToString();
                            //uc.SubjectSubscriptionId = c.SubjectSubscriptionId;
                            //uc.StudentSubjectModel = c;
                            uc.Title = c.Name;
                            //Messages
                            //foreach messages add message controls to uc
                            {
                                //Messages list
                            }

                            this.pnlCourseList.Controls.Add(uc);
                        }
                    }

                }
                catch (Exception e) { }
            }

            /*

            LoadCoursesFromDatabase();

            if (UserType == "student")
            {
                foreach (
                    var c in
                        UserSubjectModels.Where(
                            x => !(x.Void) && x.Permitted && x.Active && x.Subscribed && !(x.Suspended)))
                {
                    CourseUc uc =
                        (CourseUc) Page.LoadControl("~/ViewsSite/DashBoard/Student/CourseOverView/CourseUc.ascx");
                    uc.Title = c.SubjectName;
                    uc.Id = c.SubjectId.ToString();
                    uc.SubjectSubscriptionId = c.SubjectSubscriptionId;
                    uc.StudentSubjectModel = c;
                    //Messages
                    //foreach messages add message controls to uc
                    {
                        //Messages list
                    }

                    this.pnlJoinedCourseList.Controls.Add(uc);
                }
            }
            else if (UserType == "teacher")
            {
                //lnkJoin.Visible = true;
                foreach (
                   var c in
                       UserSubjectModels.Where(
                           x => !(x.Void) && x.Permitted && x.Active && x.Subscribed && !(x.Suspended)))
                {
                    CourseUc uc =
                        (CourseUc)Page.LoadControl("~/ViewsSite/DashBoard/Student/CourseOverView/CourseUc.ascx");
                    uc.Title = c.SubjectName;

                    //uc.SubjectSubscriptionId = c.SubjectSubscriptionId;//not for teacher
                    uc.StudentSubjectModel = c;
                    //Messages
                    //foreach messages add message controls to uc
                    {
                        //Messages list
                    }

                    this.pnlJoinedCourseList.Controls.Add(uc);
                }
            }
            //var myCourses = helper.SubectsForStudents(SchoolId,StudentId,AcademicYearId);
            */

        }

        //public void LoadUnjoinedCourses()
        //{
        //    LoadCoursesFromDatabase();
        //    foreach (var c in UserSubjectModels.Where(x => !(x.Void) && (!x.Active || !x.Subscribed) && !(x.Suspended)))
        //    {
        //        UnjoinedCoursesUc uc = (UnjoinedCoursesUc)Page.LoadControl("~/ViewsSite/DashBoard/Student/UnJoinedCourses/UnjoinedCoursesUc.ascx");
        //        //uc.OnSubjectSubscribed += uc_OnSubjectSubscribed;
        //        uc.Id = c.SubjectId.ToString();
        //        uc.StudentClassId = c.UserClassId;
        //        uc.SubjectClassId = c.SubjectClassId;
        //        uc.Title = c.SubjectName;
        //        uc.StudentSubjectModel = c;
        //        //Messages
        //        //foreach messages add message controls to uc
        //        {
        //            //Messages list
        //        }

        //        this.pnlUnJoinedCourseList.Controls.Add(uc);
        //    }
        //}

        //void uc_OnSubjectSubscribed(object sender, EventArgs e)
        //{
        //    UnjoinedCoursesUc uc = (UnjoinedCoursesUc)sender;
        //    if (uc != null)
        //    {
        //        uc.
        //    }
        //}


        //protected void lnkJoin_Click(object sender, EventArgs e)
        //{
        //    if (lnkJoin.Text == "Regular Courses")
        //    {
        //        lnkJoin.Text = "Extra Courses";
        //        pnlJoinedCourseList.Visible = true;
        //        pnlUnJoinedCourseList.Visible = false;
        //        //LoadJoinedCourses();
        //    }
        //    else
        //    {
        //        lnkJoin.Text = "Regular Courses";
        //        pnlJoinedCourseList.Visible = false;
        //        pnlUnJoinedCourseList.Visible = true;
        //        //LoadUnjoinedCourses();
        //    }
        //}

        /// <summary>
        /// Type that are valid: 'current'-->for current, 'earlier'-->for earlier
        /// </summary>
        public string LoadType
        {
            set { hidLoadType.Value = value ?? ""; }
        }

    }
}