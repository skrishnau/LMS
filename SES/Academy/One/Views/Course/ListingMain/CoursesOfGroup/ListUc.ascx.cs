using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.ListingMain.CoursesOfGroup
{
    public partial class ListUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoryCreate.SaveClicked += CategoryCreate_SaveClicked;
            CategoryCreate.CancelClicked += CategoryCreate_CancelClicked;

            CourseCreateUc.NewCategoryButtonClicked += CourseCreateUc_NewCategoryButtonClicked;
            CourseCreateUc.SaveClicked += CourseCreateUc_SaveClicked;
            CourseCreateUc.CancelClicked += CourseCreateUc_CancelClicked;
        }

        void CourseCreateUc_CancelClicked(object sender, Values.MessageEventArgs e)
        {
            cmbNewSubject.ClearSelection();
            MultiView1.ActiveViewIndex = 0;
        }

        void CourseCreateUc_SaveClicked(object sender, Values.MessageEventArgs e)
        {
            if (e.SaveSuccess)
            {
                MultiView1.ActiveViewIndex = 0;
               //reload course list display
            }
        }

        void CourseCreateUc_NewCategoryButtonClicked(object sender, Values.MessageEventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
        }

        void CategoryCreate_CancelClicked(object sender, Values.MessageEventArgs e)
        {
            cmbNewSubject.SelectedIndex = 1;
            MultiView1.ActiveViewIndex = 1;
        }

        void CategoryCreate_SaveClicked(object sender, Values.MessageEventArgs e)
        {
            if (e.SaveSuccess)
            {
                CourseCreateUc.SelectCategory(e.SavedId, e.SavedName);
                
                MultiView1.ActiveViewIndex = 1;
            }
            //else
            //{
            //    MultiView1.ActiveViewIndex = 1;                
            //}
        }

        public int SubjectGroupId
        {
            get { return Convert.ToInt32(hidSubjectGroupId.Value); }
            set
            {
                CourseCreateUc.SubjectGroupId = value;
                hidSubjectGroupId.Value = value.ToString();
            }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set
            {
                CategoryCreate.SchoolId = value;
                hidSchoolId.Value = value.ToString();
            }
        }

        protected void cmbNewSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cmbNewSubject.SelectedValue;
            switch (selected)
            {
                    //list
                case "0":
                    MultiView1.ActiveViewIndex = 0;
                    break;
                    //New subject
                case "1":
                    //Response.Redirect("~/Views/Course/CourseEntryForm.aspx");
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "2":
                    MultiView1.ActiveViewIndex = 2;
                    break;
                case "3":
                    break;
                    //category
                case "4":
                    break;
            }
        }

        protected void btnNewGroup_Click(object sender, EventArgs e)
        {

        }
    }
}