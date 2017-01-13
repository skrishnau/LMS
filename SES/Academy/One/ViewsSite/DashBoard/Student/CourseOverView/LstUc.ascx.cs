using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Account;
using Academic.DbHelper;
using One.Values.MemberShip;
//using One.ViewsSite.DashBoard.Student.UnJoinedCourses;

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
                LoadCourses();
            }

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

        public List<Academic.ViewModel.AcademicPlacement.StudentSubjectModel> UserSubjectModels { get; set; }

        #endregion



        public void LoadCourses()
        {
            var date = DateTime.Now;

            using (var aHelper = new DbHelper.ActAndRes())
            using (var helper = new DbHelper.Subject())
            using (var clsHelper = new DbHelper.Classes())
            {
                try
                {
                    //aHelper.ListActivitiesAndResourcesOfSection()


                    var user = Page.User as CustomPrincipal;
                    if (user != null)
                    {
                        //var subjects = helper.GetCurrentRegularSubjectsOfUser(user.Id);
                        //var subjectsArray = helper.ListCurrentAndEarlierCoursesOfUser(user.Id);
                        List<Academic.DbEntities.Subjects.Subject> subjectsArray;
                        if (hidLoadType.Value == "earlier")
                        {
                            subjectsArray = helper.ListEarlierSubjectClasses(user.Id)
                                .Select(x => (x.IsRegular) ? x.SubjectStructure.Subject : x.Subject).ToList();
                        }
                        else
                        {
                            subjectsArray = helper.ListCurrentSubjectClasses(user.Id)
                                .Select(x => (x.IsRegular) ? x.SubjectStructure.Subject : x.Subject).ToList();
                        }
                        //foreach (var c in subjects[loadType])
                        //foreach (var c in subjectsArray[loadType])
                        foreach (var c in subjectsArray.Distinct())
                        {
                            CourseUc uc =
                                (CourseUc)Page.LoadControl("~/ViewsSite/DashBoard/Student/CourseOverView/CourseUc.ascx");
                            var navigationUrl = "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId="
                                + c.Id;

                            uc.TitleNavigationTarget = navigationUrl;

                            uc.Id = c.FullName + "_" + c.Id;
                            uc.Title = c.FullName;

                            //classes calculation

                            var userclasses = clsHelper.GetCurrentUserClassesOfUser(c.Id, user.Id);

                            //var clsIds = classes.Select(x => x.SubjectClass.Id).ToList();

                            var roles = user.GetRoles();
                            var elligible = false;
                            //Context.UserClass.Any(x=>x.subje)
                            // var roles = user.GetRoles().Select(x => x.Role.RoleName).ToList();

                            //if ()
                            {
                                elligible = roles.Contains(DbHelper.StaticValues.Roles.CourseEditor.ToString())
                                                            || roles.Contains(DbHelper.StaticValues.Roles.Manager.ToString())
                                                            || roles.Contains(DbHelper.StaticValues.Roles.Admin.ToString())
                                                            || roles.Contains("teacher");

                            }
                            //Messages
                            //Restriction calculation is not done yet
                            foreach (var sec in c.SubjectSections.AsEnumerable().Where(x => !(x.Void ?? false)))
                            {

                                var canView = elligible;
                                if (!canView)
                                    canView = aHelper.EvaluateRestriction(null, sec.Restriction, user.Id);
                                if (canView) //
                                {
                                    foreach (var act in sec.ActivityResources.AsEnumerable()
                                                    .Where(x => x.ActivityOrResource && !(x.Void ?? false)))//only activity
                                    {
                                        if (!elligible)
                                            canView = aHelper.EvaluateRestriction(null, act.Restriction, user.Id);
                                        if (canView) //
                                        {
                                            foreach (var ac in act.ActivityClasses)
                                            {
                                                //ac.ActivityResourceViews.Where(x=>x.)
                                                var usrCls = userclasses.FirstOrDefault(x => x.SubjectClassId == ac.SubjectClassId);
                                                if (usrCls != null)
                                                {
                                                    //check for activity view
                                                    var viewed = ac.ActivityResourceViews.FirstOrDefault(a => a.UserClassId == usrCls.Id);
                                                    //!cls.ActivityResourceViews.ToList().Exists(x => x.UserClassId == classMatch.Id)
                                                    if (viewed != null)
                                                    {
                                                        if ((date - viewed.ViewedDate).TotalDays < 1)
                                                        {
                                                            var cuc = (CourseMessageUC)
                                                           Page.LoadControl("~/ViewsSite/DashBoard/Student/CourseOverView/CourseMessageUC.ascx");
                                                            var thisIcon = ActivityResourceValues.RetriveMethod(actOrRes: true, actResType: (byte)(act.ActivityResourceType));
                                                            if (thisIcon != null)
                                                            {
                                                                cuc.ImageLink = thisIcon.IconPath;
                                                                cuc.Text = "You have new " + (thisIcon.Name);
                                                                cuc.NavigateUrl = navigationUrl + "#section_" + sec.Id;
                                                                cuc.ToolTip = act.Name;
                                                                uc.AddMessages(cuc);
                                                            }
                                                            break;
                                                        }
                                                    }
                                                    else //(!ac.ActivityResourceViews.ToList().Exists(x => x.UserClassId == usrCls.Id))// && x.ActivityClassId == ac.Id)
                                                    {
                                                        //then don't display
                                                        var cuc = (CourseMessageUC)
                                                            Page.LoadControl("~/ViewsSite/DashBoard/Student/CourseOverView/CourseMessageUC.ascx");
                                                        //var thisType = Enum.GetNames(typeof(Enums.Activities))[act.ActivityResourceType-1];
                                                        var thisIcon = ActivityResourceValues.RetriveMethod(actOrRes: true, actResType: (byte)(act.ActivityResourceType));
                                                        if (thisIcon != null)
                                                        {
                                                            cuc.ImageLink = thisIcon.IconPath;
                                                            cuc.Text = "You have new " + (thisIcon.Name);
                                                            //cuc.NavigateUrl = thisIcon.ViewUrl
                                                            //                    + "?SubId=" + c.Id +
                                                            //                    "&arId=" + act.ActivityResourceId +
                                                            //                    "&secId=" + sec.Id +
                                                            //                    "&edit=0";
                                                            cuc.NavigateUrl = navigationUrl + "#section_" + sec.Id;
                                                            cuc.ToolTip = act.Name;
                                                            uc.AddMessages(cuc);
                                                        }
                                                        break;
                                                    }


                                                    #region Submission

                                                    //var actres = ahelper.GetActivityResource(true
                                                    //    , (byte)(Enums.Activities.Assignment + 1), AssignmentId);
                                                    if (usrCls.Role.RoleName == "teacher" || usrCls.Role.RoleName == "manager")
                                                    {
                                                        if (act.ActivityOrResource
                                                              &&
                                                              act.ActivityResourceType == (byte)(Enums.Activities.Assignment + 1)
                                                              && !(act.Void ?? false))
                                                        {
                                                            //then its assignment .. check for new submission
                                                            var ass = aHelper.GetAssignment(act.ActivityResourceId);
                                                            if (ass != null)
                                                            {
                                                                //its definitely assignment
                                                                var users = ass.Submissions.Count;//.OrderByDescending(x => x.SubmittedDate).Select(x => x.UserClassId).ToList();
                                                                var gradings = act.ActivityGradings.Count;//.Select(x=>x.UserClassId).ToList();
                                                                //var anyUnGraded = act.ActivityGradings.Any(x =>
                                                                //    !users.Contains(x.UserClassId));
                                                                if (users > gradings)
                                                                {
                                                                    var cuc = (CourseMessageUC)Page.LoadControl
                                                                        ("~/ViewsSite/DashBoard/Student/CourseOverView/CourseMessageUC.ascx");
                                                                    var thisIcon = ActivityResourceValues.AssignmentActivity();
                                                                    //ActivityResourceValues.RetriveMethod(actOrRes: true, actResType: (byte)(act.ActivityResourceType));
                                                                    if (thisIcon != null)
                                                                    {
                                                                        cuc.ImageLink = "~/Content/Icons/ActivityResource/Assignment/document_submit_icon.png";//thisIcon.IconPath;
                                                                        cuc.Text = "You have new Submission";//+ (thisIcon.Name);
                                                                        cuc.NavigateUrl = navigationUrl + "#section_" + sec.Id;
                                                                        cuc.ToolTip = act.Name;
                                                                        uc.AddMessages(cuc);
                                                                    }
                                                                    break;
                                                                }

                                                            }

                                                        }
                                                    }

                                                    #endregion
                                                }
                                            }
                                        }


                                    }
                                }

                                //Messages list
                            }

                            this.pnlCourseList.Controls.Add(uc);
                        }
                    }

                }
                catch (Exception e) { }
            }



        }



        /// <summary>
        /// Type that are valid: 'current'-->for current, 'earlier'-->for earlier
        /// </summary>
        public string LoadType
        {
            set { hidLoadType.Value = value ?? ""; }
        }

    }
}