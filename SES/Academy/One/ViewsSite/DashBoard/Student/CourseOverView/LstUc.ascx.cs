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
            using(var aHelper = new DbHelper.ActAndRes())
            using (var helper = new DbHelper.Subject())
            {
                try
                {
                   //aHelper.ListActivitiesAndResourcesOfSection()


                    var user = Page.User as CustomPrincipal;
                    if (user != null)
                    {
                        
                        //var subjects = helper.GetCurrentRegularSubjectsOfUser(user.Id);
                        //var subjectsArray = helper.ListCurrentAndEarlierCoursesOfUser(user.Id);
                        List<Academic.DbEntities.Subjects.Subject> subjectsArray ;
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
                            uc.TitleNavigationTarget = "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" 
                                + c.Id;
                            
                            uc.Id = c.FullName + "_" + c.Id;
                            
                            uc.Title = c.FullName;
                            //Messages
                            //foreach messages add message controls to uc
                            //var seee = c.SubjectSections;
                            //var sections = c.SubjectSections.Where(x => !(x.Void) ?? false);
                            //var sections  = c.SubjectSections.AsEnumerable().Where(x => !(x.Void) ?? false).ToList();
                            foreach(var sec in c.SubjectSections.AsEnumerable().Where(x=>!(x.Void??false)))
                            {
                                foreach (var act in sec.ActivityResources.AsEnumerable()
                                    .Where(x=>x.ActivityOrResource && !(x.Void??false)) )
                                {
                                    if (act.ActivityResourceViews.Any(x => x.UserId == user.Id))
                                    {

                                    }
                                    else
                                    {
                                        var cuc =
                                            (CourseMessageUC)
                                                Page.LoadControl(
                                                    "~/ViewsSite/DashBoard/Student/CourseOverView/CourseMessageUC.ascx");
                                        //var thisType = Enum.GetNames(typeof(Enums.Activities))[act.ActivityResourceType-1];
                                        var thisIcon = ActivityResourceValues.RetriveMethod(actOrRes:true, actResType:(byte)(act.ActivityResourceType));
                                        if (thisIcon != null)
                                        {
                                            cuc.ImageLink = thisIcon.IconPath;
                                            cuc.Text = "You have new " + (thisIcon.Name);
                                            cuc.NavigateUrl = thisIcon.ViewUrl;
                                            uc.AddMessages(cuc);
                                        }
                                        //cuc.ImageLink= DbHelper.StaticValues.
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