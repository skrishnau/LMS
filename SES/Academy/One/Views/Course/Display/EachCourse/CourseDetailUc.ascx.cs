using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Views.Course.Section;

namespace One.Views.Course.Display.EachCourse
{
    public partial class CourseDetailUc : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCourseDetail();
            CreateSectionUc1.OnCloseClick += CreateSectionUc1_OnCloseClick;
            CreateSectionUc1.OnSaveEvent += CreateSectionUc1_OnSaveEvent;
            //LoadSections();
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
                        var unVoidedSections = sections.Where(x => !(x.Void ?? false));

                        foreach (var subjectSection in unVoidedSections)
                        {
                            SectionUc sectionuc = (SectionUc)Page.LoadControl("~/Views/Course/Section/SectionUc.ascx");
                            sectionuc.SummaryVisible = subjectSection.ShowSummary ?? false;
                            sectionuc.SubjectId = subjectSection.SubjectId;
                            sectionuc.SectionId = subjectSection.Id;
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

        #endregion

        protected void imgAddSection_Click(object sender, ImageClickEventArgs e)
        {

        }

        void uc_OnSaveEvent(object sender, MessageEventArgs e)
        {
            if (e.TrueFalse)
            {
                //saved
                pnlSections.Controls.Clear();
                LoadCourseDetail();
            }
            else
            {
                //not saved
            }

            CreateSectionUc uc = (CreateSectionUc)sender;
            pnlSections.Controls.Remove(uc);
        }



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
    }
}