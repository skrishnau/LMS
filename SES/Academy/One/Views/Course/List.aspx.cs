using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;
using One.Values.MemberShip;

namespace One.Views.Course
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = User as CustomPrincipal;
            if (!IsPostBack)
            {
                if (user != null)
                    categoryCreate.SchoolId = user.SchoolId;
            }

            //pnlCategories.EnableViewState = false;
            //pnlCategories.ViewStateMode=ViewStateMode.Disabled;

            categoryCreate.SaveClicked += categoryCreate_SaveClicked;
            categoryCreate.CancelClicked += categoryCreate_CancelClicked;

            courseCreate.SaveClicked += courseCreate_SaveClicked;
            courseCreate.CancelClicked += courseCreate_CancelClicked;
            //if (hidSelectedCategory.Value == "0")
            //{
            //    lnkCourseCreate.Enabled = false;
            //    imgCourseCreate.Visible = false;
            //    lnkCourseCreate.Text = "Select Category to add Courses.";
            //}
            //else
            //{
            //    lnkCourseCreate.Enabled = true;
            //    imgCourseCreate.Visible = true;
            //    lnkCourseCreate.Text = "Add Courses";
            //}
            LoadCategories(user.SchoolId);
        }



        public int SelectedCategory
        {
            get { return Convert.ToInt32(hidSelectedCategory.Value); }
            set { this.hidSelectedCategory.Value = value.ToString(); }
        }

        void courseCreate_SaveClicked(object sender, Values.MessageEventArgs e)
        {
            var user = User as CustomPrincipal;
            if (user != null)
                LoadCourses(SelectedCategory);
            MultiView1.ActiveViewIndex = 0;
        }

        private void courseCreate_CancelClicked(object sender, MessageEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        void categoryCreate_SaveClicked(object sender, Values.MessageEventArgs e)
        {
            var user = User as CustomPrincipal;
            if (user != null)
            {
                //pnlCategories.Controls.Clear();
                SelectedCategory = e.SavedId;
                //LoadCategories(user.SchoolId);
            }
            MultiView1.ActiveViewIndex = 0;
        }

        private void categoryCreate_CancelClicked(object sender, MessageEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        bool selectedAlready = false;


        //Category Listing
        //======================= Category listing ================================//
        private void LoadCategories(int schoolId)
        {
            using (var helper = new DbHelper.Subject())
            {
                var categories = helper.ListAllCategories(schoolId);
                var i = 0;
                //if (hidSelectedCategory.Value == "0")
                //    selectedValue = 0
                //{
                //    catUc.Select();
                //}
                foreach (var cat in categories)
                {
                    var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                    catUc.Deselect();
                    catUc.SetNameAndIdOfCategory(cat.Id, cat.Name);
                    if (i == 0)
                    {
                        if (hidSelectedCategory.Value == "0")
                        {
                            //catUc.Select();
                            hidSelectedCategory.Value = cat.Id.ToString();
                            catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
                            //LoadCourses(cat.Id);
                            //ViewState["selectedCategory"] = catUc;
                            selectedAlready = true;
                        }
                        else if (hidSelectedCategory.Value == cat.Id.ToString())
                        {

                            //catUc.Select();
                            //catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
                            //hidSelectedCategory.Value = cat.Id.ToString();
                            selectedAlready = true;
                        }
                    }
                    else if (!selectedAlready)
                    {
                        if (hidSelectedCategory.Value == cat.Id.ToString())
                        {

                            //catUc.Select();
                            //catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
                            //hidSelectedCategory.Value = cat.Id.ToString();
                            selectedAlready = true;
                        }
                    }
                    catUc.NameClicked += catUc_NameClicked;
                    pnlCategories.Controls.Add(catUc);
                    GetSubCategory(catUc, helper, schoolId, cat.Id);
                    //catUc.AddSubCategories(GetSubCategory(helper,schoolId, cat.Id));
                    i++;
                }
            }
        }

        void GetSubCategory(Category.ListUC parentUc, DbHelper.Subject helper, int schoolId, int categoryId)
        {
            var subCategories = helper.ListSubCategories(schoolId, categoryId);
            foreach (var subcat in subCategories)
            {
                var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                catUc.Deselect();
                catUc.SetNameAndIdOfCategory(subcat.Id, subcat.Name);
                if (!selectedAlready)
                {
                    if (hidSelectedCategory.Value == subcat.Id.ToString())
                    {
                        //catUc.Select();
                        //catUc_NameClicked(null, new DataEventArgs() { Id = subcat.Id, Name = subcat.Name });
                        selectedAlready = true;
                    }
                }
                catUc.NameClicked += catUc_NameClicked;

                parentUc.AddSubCategories(catUc);
                GetSubCategory(catUc, helper, schoolId, subcat.Id);
                //catUc.AddSubCategories(GetSubCategory(catUc, helper,schoolId,subcat.Id));
            }
            //return ;
        }

        //========================= END of Category Listing ====================================//



        void catUc_NameClicked(object sender, Values.DataEventArgs e)
        {
            //load courses in this category

            lblCoursesTitle.Text = e.Name;
            hidSelectedCategory.Value = e.Id.ToString();
            hidSelectedCategoryName.Value = e.Name;


            //var user = User as CustomPrincipal;
            //if (user != null)
            //    LoadCategories(user.SchoolId);

            LoadCourses(e.Id);
            //using (var helper = new DbHelper.Subject())
            //{
            //    //dlistCourses.DataSource = null;
            //    dlistCourses.DataSource = helper.ListCourses(e.Id);
            //    dlistCourses.DataBind();
            //}

            //var previousSelectedCategory = ViewState["selectedCategory"];
            //if (previousSelectedCategory != null)
            //{
            //    try
            //    {
            //        (previousSelectedCategory as Category.ListUC).Deselect();
            //    }
            //    catch { }
            //}
        }

        void LoadCourses(int categoryId)
        {
            using (var helper = new DbHelper.Subject())
            {
                //dlistCourses.DataSource = null;
                dlistCourses.DataSource = helper.ListCourses(categoryId);
                dlistCourses.DataBind();
            }
        }

        protected void lnkCatCreate_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lnkCoursCreate_Click(object sender, EventArgs e)
        {
            if (hidSelectedCategory.Value != "0")
            {
                //courseCreate.CategoryId = Convert.ToInt32(hidSelectedCategory.Value);
                courseCreate.SetCategoryIdAndName(hidSelectedCategory.Value, hidSelectedCategoryName.Value);
                MultiView1.ActiveViewIndex = 2;
            }
        }
        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/Course/Category/Create.aspx");
        //}

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/Course/CourseEntryForm.aspx");
        //}
    }
}