using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel.Subject;

namespace One.Views.Structure.All.UserControls.CourseLinkage
{
    public partial class CourseListUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddCourses1.CancelClicked += AddCourses_ReturnClicked;
            AddCourses1.SaveClicked += AddCourses_ReturnClicked;

            if (!IsPostBack)
            {
                using (var helper = new DbHelper.Subject())
                {
                    var courses = helper.ListCoursesOfStructure(YearId, SubYearId);
                    dlistCourses.DataSource = courses;
                    dlistCourses.DataBind();
                    //courses.ForEach(x =>
                    //{
                    //    savedCourses.Add(new Subject()
                    //    {
                    //        Id = x.Id
                    //        ,
                    //        Name = x.Name
                    //        ,
                    //        CategoryId = x.SubjectCategoryId
                    //        ,
                    //        Checked = false
                    //    });
                    //});
                    //ViewState["SavedCourses"] = savedCourses;
                }
            }
        }

        void AddCourses_ReturnClicked(object sender, Values.MessageEventArgs e)
        {
            //using (var helper = new DbHelper.Subject())
            //{
            //    var courses = helper.ListCoursesOfStructure(YearId, SubYearId);
            //    dlistCourses.DataSource = courses;
            //    dlistCourses.DataBind();
            //}
            MultiView1.ActiveViewIndex = 0;
        }

        public int YearId
        {
            get { return Convert.ToInt32(hidYearId.Value); }
            set { hidYearId.Value = value.ToString(); }
        }

        public int SubYearId
        {
            get { return Convert.ToInt32(hidSubYearId.Value); }
            set { hidSubYearId.Value = value.ToString(); }
        }

        public void SetProgramDirectory(string dir)
        {
            lblProgramDirectory.Text = dir;
        }

        public void LoadCourseList(int yearId, int subYearId = 0)
        {

            hidYearId.Value = yearId.ToString();
            hidSubYearId.Value = subYearId.ToString();
            AddCourses1.YearId = yearId;
            AddCourses1.SubYearId = subYearId;


            using (var helper = new DbHelper.Subject())
            {
                var courseList = helper.ListCoursesOfStructure(yearId, subYearId);
                dlistCourses.DataSource = courseList;
                dlistCourses.DataBind();
            }
        }

        protected void btnManageSubject_Click(object sender, EventArgs e)
        {
            AddCourses1.AddDataToSavedViewState();
            MultiView1.ActiveViewIndex = 1;

            //Response.Redirect("~/Views/Structure/All/Master/AddCourses.aspx?yId="+YearId+"&sId="+SubYearId);
        }

    }
}