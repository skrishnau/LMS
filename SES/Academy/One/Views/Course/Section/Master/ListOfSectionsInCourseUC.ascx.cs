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

            CreateSectionUc1.OnCloseClick += CreateSectionUc1_OnCloseClick;
            CreateSectionUc1.OnSaveEvent += CreateSectionUc1_OnSaveEvent;
            ////LoadSections();

        }

        void CreateSectionUc1_OnSaveEvent(object sender, MessageEventArgs e)
        {
            pnlCreateSection.Visible = false;
            AddNewButtonVisibility = true;
            ContentEnabled = true;
            pnlSections.Controls.Clear();
            LoadCourseDetail();
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
                CreateSectionUc1.SubjectId = value;
                hidId.Value = value.ToString();
            }
        }
        //public TYPE Type { get; set; }

        public bool ContentEnabled
        {
            get { return pnlContent.Enabled; }
            set { pnlContent.Enabled = value; }
        }

        public bool AddNewButtonVisibility
        {
            get { return lnkAddSection.Visible; }
            set { lnkAddSection.Visible = value; }
        }

        public bool EditEnabled
        {
            get { return Convert.ToBoolean(hidEditEnabled.Value); }
            set
            {
                hidEditEnabled.Value = value.ToString();
                lnkAddSection.Visible = value;
            }
        }



        #endregion


        #region Functions load, events etc

        private void LoadCourseDetail()
        {
            using (var helper = new DbHelper.Subject())
            {
                var course = helper.Find(CourseId);
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
                                || roles.Contains(DbHelper.StaticValues.Roles.Admin))
                            {
                                elligible = true;
                            }
                            //else
                            //{
                            //    //teacher
                            //    elligible = (chelper.IsUserElligibleToViewSubjectSection(SubjectId, UserId));
                            //}
                        }

                        var unVoidedSections = sections.Where(x => !(x.Void ?? false));

                        foreach (var subjectSection in unVoidedSections)
                        {
                            SectionUc sectionuc = (SectionUc)Page.LoadControl("~/Views/Course/Section/SectionUc.ascx");
                            sectionuc.AddActResClicked += sectionuc_AddActResClicked;

                            //sectionuc.EditEnabled = EditEnabled;
                            //sectionuc.SummaryVisible = subjectSection.ShowSummary ?? false;
                            //sectionuc.SubjectId = subjectSection.SubjectId;
                            //sectionuc.SectionId = subjectSection.Id;
                            //sectionuc.SectionName = subjectSection.Name;

                            sectionuc.SetData(EditEnabled,subjectSection.ShowSummary??false
                                ,subjectSection.SubjectId,subjectSection.Id
                                ,subjectSection.Name,UserId, elligible);

                            var sectionlbl = new Literal() { Text = "<a  name='section_" + subjectSection.Id + "'></a>" };
                            pnlSections.Controls.Add(sectionlbl);
                            pnlSections.Controls.Add(sectionuc);
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

        //void uc_OnSaveEvent(object sender, Values.MessageEventArgs e)
        //{
        //    if (e.TrueFalse)
        //    {
        //        //saved
        //        pnlSections.Controls.Clear();
        //        LoadCourseDetail();
        //    }
        //    else
        //    {
        //        //not saved
        //    }

        //    CreateSectionUc uc = (CreateSectionUc)sender;
        //    pnlSections.Controls.Remove(uc);
        //}



        protected void lnkAddSection_Click(object sender, EventArgs e)
        {
            pnlCreateSection.Visible = true;
            ContentEnabled = false;
            AddNewButtonVisibility = false;
            //pnlContent.Enabled = false;
            //var control = pnlSections.Controls[pnlSections.Controls.Count - 1];
            //control.Visible = !control.Visible;
        }


        void CreateSectionUc1_OnCloseClick(object sender, MessageEventArgs e)
        {
            pnlCreateSection.Visible = false;
            AddNewButtonVisibility = true;
            ContentEnabled = true;
            //pnlContent.Enabled = true;
        }

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }
        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }
    }
}