using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Course.Section.Master
{
    public partial class ListOfSectionsInCourseUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string parameter = Request["__EVENTARGUMENT"]; // parameter
                // Request["__EVENTTARGET"]; // btnSave
                if (parameter != null)
                {
                    var split = parameter.Split(new char[] { '_' });
                    if (split.Count() >= 3)
                    {
                        Session["SubjectId"] = Convert.ToInt32(split[1]);
                        Session["SectionId"] = Convert.ToInt32(split[2]);
                        //ActResChooseUc.SetIds(, , "", "");
                    }
                }
            }
            catch { }

            LoadCourseDetail();

            //CreateSectionUc1.OnCloseClick += CreateSectionUc1_OnCloseClick;
            //CreateSectionUc1.OnSaveEvent += CreateSectionUc1_OnSaveEvent;
            ////LoadSections();

        }

       


        #region Properties

        /// <summary>
        /// Course id that this uc displayes
        /// </summary>
        public int CourseId
        {

            get { return Convert.ToInt32(hidId.Value); }
            set
            {
                //CreateSectionUc1.SubjectId = value;
                hidId.Value = value.ToString();
            }
        }
       

        public bool AddNewButtonVisibility
        {
            get { return lnkAddSection1.Visible; }
            set { lnkAddSection1.Visible = value; }
        }

        public bool EditEnabled
        {
            get { return Convert.ToBoolean(hidEditEnabled.Value); }
            set
            {
                hidEditEnabled.Value = value.ToString();
                lnkAddSection1.Visible = value;
            }
        }



        #endregion


        #region Functions load, events etc

        private void LoadCourseDetail()
        {
            var courseId = CourseId;
            using (var helper = new DbHelper.Subject())
            {
                lnkAddSection1.NavigateUrl = "~/Views/Course/Section/CreateSection.aspx?SubId=" + courseId;
                var course = helper.Find(courseId);
                //lblTitle.Text = course.Name;
                //lblSummary.Text = course.Summary;
                if (course != null)
                {
                    var sections = course.SubjectSections;
                    if (sections != null)
                    {
                        var user = Page.User as CustomPrincipal;
                        var elligible = false;
                        if (user != null)
                            using (var chelper = new DbHelper.Classes())
                            {
                                var roles = user.GetRoles();
                                //Context.UserClass.Any(x=>x.subje)
                                // var roles = user.GetRoles().Select(x => x.Role.RoleName).ToList();
                                if (roles.Contains(DbHelper.StaticValues.Roles.CourseEditor.ToString())
                                    || roles.Contains(DbHelper.StaticValues.Roles.Manager.ToString())
                                    || roles.Contains(DbHelper.StaticValues.Roles.Admin)
                                    ||roles.Contains("teacher"))
                                {
                                    elligible = true;

                                }
                                //else
                                //{
                                //    //teacher
                                //    elligible = (chelper.IsUserElligibleToViewSubjectSection(SubjectId, UserId));
                                //}

                                var unVoidedSections = sections.Where(x => !(x.Void ?? false));

                                using (var ahelper = new DbHelper.ActAndRes())
                                    foreach (var subjectSection in unVoidedSections)
                                    {
                                        var canView = elligible;
                                        if (!canView)
                                            canView = ahelper.EvaluateRestriction(null, subjectSection.Restriction, user.Id);
                                        if (canView) //
                                        {
                                            SectionUc sectionuc =
                                                (SectionUc)Page.LoadControl("~/Views/Course/Section/SectionUc.ascx");
                                            sectionuc.AddActResClicked += sectionuc_AddActResClicked;

                                            //sectionuc.EditEnabled = EditEnabled;
                                            //sectionuc.SummaryVisible = subjectSection.ShowSummary ?? false;
                                            //sectionuc.SubjectId = subjectSection.SubjectId;
                                            //sectionuc.SectionId = subjectSection.Id;
                                            //sectionuc.SectionName = subjectSection.Name;

                                            sectionuc.SetData(EditEnabled, subjectSection.ShowSummary ?? false
                                                , subjectSection.SubjectId, subjectSection.Id
                                                , subjectSection.Name, UserId, elligible);

                                            var sectionlbl = new Literal()
                                            {
                                                Text = "<a  name='section_" + subjectSection.Id + "'></a>"
                                            };
                                            pnlSections.Controls.Add(sectionlbl);
                                            pnlSections.Controls.Add(sectionuc);
                                        }
                                    }
                            }
                    }
                }
            }
            //CreateSectionUc uc = (CreateSectionUc)Page.LoadControl("~/Views/Course/Section/CreateSectionUc.ascx");

            //uc.ID = "createSection";
            //uc.Visible = false;
            //uc.SubjectId = CourseId;
            //uc.OnSaveEvent += uc_OnSaveEvent;
            //pnlSections.Controls.Add(uc);
        }

        void sectionuc_AddActResClicked(object sender, SubjectSectionEventArgs e)
        {
            //ActResChooseUc.SetIds(e.SubjectId, e.SectionId, e.SubjectName, e.SectionName);
        }

        #endregion


        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }
       
    }
}