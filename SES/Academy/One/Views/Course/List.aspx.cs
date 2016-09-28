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

            //earlier
            //LoadCategories(user.SchoolId);

            LoadCategoriesAndSubCategories(user.SchoolId);
        }



        public int SelectedCategory
        {
            get { return Convert.ToInt32(hidSelectedCategory.Value); }
            set { this.hidSelectedCategory.Value = value.ToString(); }
        }

        void courseCreate_SaveClicked(object sender, MessageEventArgs e)
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

        void categoryCreate_SaveClicked(object sender, MessageEventArgs e)
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
                var list = new List<int>();
                
                foreach (var cat in categories)
                {
                    var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                    catUc.Deselect();
                    if (i == 0 && categories.Count > 1)
                    {
                        list.Add(3);
                    }
                    else if (i == categories.Count - 1)
                    {
                        list.Add(2);
                    }
                    else
                    {
                        list.Add(1);
                    }

                    catUc.SetNameAndIdOfCategory(cat.Id, cat.Name,list);
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
                    list.RemoveAt(list.Count - 1);
                    i++;
                }
            }
        }

        // Note :: ├ ==>1 ,    └ ==> 2 .   ┌ ==> 3 ,   │ ==> 4 ,  empty ==> 0
        void LoadCategoriesAndSubCategories(int schoolId)
        {
            using (var helper = new DbHelper.Subject())
            {
                var cats = helper.ListAllCategories(schoolId);
                var list = new List<int>();
                for (var c = 0; c < cats.Count; c++)
                {
                    var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                    catUc.Deselect();

                    if (c == 0 && cats.Count > 1)
                    {
                        list.Add(3);
                    }
                    else if (c == cats.Count - 1)
                    {
                        list.Add(2);
                    }
                    else
                    {
                        list.Add(1);
                    }
                    catUc.SetNameAndIdOfCategory(cats[c].Id, cats[c].Name,list);
                    catUc.NameClicked += catUc_NameClicked;
                    pnlCategories.Controls.Add(catUc);

                    GetSubCats(catUc, helper, schoolId, cats[c].Id, list);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }


        // Note :: ├ ==>1 ,    └ ==> 2 .   ┌ ==> 3 ,   │ ==> 4 ,  empty ==> 0
        void GetSubCats(Category.ListUC parentUc, DbHelper.Subject helper, int schoolId, int categoryId, List<int> parentPaddingList)
        {
            var subcats = helper.ListSubCategories(schoolId, categoryId);
            var list = new List<int>();
            if (subcats.Count > 0)
            {
                foreach (var i in parentPaddingList)
                {
                    if (i == 1 || i == 3 || i == 4)
                    {
                        list.Add(4);
                    }
                    else
                    {
                        list.Add(0);
                    }
                }
            }
            for (var s = 0; s < subcats.Count; s++)
            {
                var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                catUc.Deselect();



                if (s == subcats.Count - 1)
                {
                    list.Add(2);
                }
                else
                {
                    list.Add(1);
                }

                catUc.SetNameAndIdOfCategory(subcats[s].Id, subcats[s].Name,list);
                catUc.NameClicked += catUc_NameClicked;
                //parentUc.AddSubCategories(catUc);
                pnlCategories.Controls.Add(catUc);

                GetSubCats(catUc, helper, schoolId, subcats[s].Id, list);
                list.RemoveAt(list.Count - 1);
            }
        }


        void GetSubCategory(Category.ListUC parentUc, DbHelper.Subject helper, int schoolId, int categoryId
            , List<int> parentPaddingList = null )
        {
            var subCategories = helper.ListSubCategories(schoolId, categoryId);

            //--------------------start
            var list = new List<int>();
            if (parentPaddingList != null)
            {
                if (subCategories.Count > 0)
                {
                    foreach (var i in parentPaddingList)
                    {
                        if (i == 1 || i == 3 || i == 4)
                        {
                            list.Add(4);
                        }
                        else
                        {
                            list.Add(0);
                        }
                    }
                }
            }
            //------------------------End
            var s = 0;
            foreach (var subcat in subCategories)
            {
                var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                catUc.Deselect();

                //-----------start
                if (s == subCategories.Count - 1)
                {
                    list.Add(2);
                }
                else
                {
                    list.Add(1);
                }
                //--------------end

                catUc.SetNameAndIdOfCategory(subcat.Id, subcat.Name,list);
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
                GetSubCategory(catUc, helper, schoolId, subcat.Id, list);
                list.RemoveAt(list.Count - 1);
                //catUc.AddSubCategories(GetSubCategory(catUc, helper,schoolId,subcat.Id));
                s++;
            }
            //return ;
        }

        //========================= END of Category Listing ====================================//



        void catUc_NameClicked(object sender,DataEventArgs e)
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