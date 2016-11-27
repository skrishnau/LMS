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
            var catId = Request.QueryString["catId"];
            if (catId != null)
            {
                Response.Redirect("~/Views/Course/?catId="+catId);
            }
            else
            {
                Response.Redirect("~/Views/Course/");                
            }
            //var user = User as CustomPrincipal;
            //if (!IsPostBack)
            //{
            //    if (user != null)
            //    {
            //        SchoolId = user.SchoolId;
            //        //categoryCreate.SchoolId = user.SchoolId;
            //    }
            //    var catId = Request.QueryString["catId"];
            //    if (catId != null)
            //    {
            //        SelectedCategory = Convert.ToInt32(catId);
            //    }
            //}


            //LoadCategoriesAndSubCategories(user.SchoolId);
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { this.hidSchoolId.Value = value.ToString(); }
        }

        public int SelectedCategory
        {
            get { return Convert.ToInt32(hidSelectedCategory.Value); }
            set { this.hidSelectedCategory.Value = value.ToString(); }
        }

        void courseCreate_SaveClicked(object sender, MessageEventArgs e)
        {
            //var user = User as CustomPrincipal;
            if (SchoolId > 0)
                LoadCourses(SelectedCategory);
            //MultiView1.ActiveViewIndex = 0;
            lblHeading.Text = "Course and Category Management";
        }

        private void courseCreate_CancelClicked(object sender, MessageEventArgs e)
        {
            //MultiView1.ActiveViewIndex = 0;
            lblHeading.Text = "Course and Category Management";
        }

        void categoryCreate_SaveClicked(object sender, MessageEventArgs e)
        {
            //var user = User as CustomPrincipal;
            //if (user != null)
            //{
            //pnlCategories.Controls.Clear();
            SelectedCategory = e.SavedId;
            //LoadCategories(SchoolId);
            //}
            //MultiView1.ActiveViewIndex = 0;
            lblHeading.Text = "Course and Category Management";
        }

        private void categoryCreate_CancelClicked(object sender, MessageEventArgs e)
        {
            //MultiView1.ActiveViewIndex = 0;
            lblHeading.Text = "Course and Category Management";
        }

        bool selectedAlready = false;


        //Category Listing
        //======================= Category listing ================================//


        #region Load Categories --dispaly tree like structure.. i.e. bars in front of category names.

        // Note :: ├ ==>1 ,    └ ==> 2 .   ┌ ==> 3 ,   │ ==> 4 ,  empty ==> 0

        //void LoadCategoriesAndSubCategories(int schoolId)
        //{
        //    using (var helper = new DbHelper.Subject())
        //    {
        //        var cats = helper.ListAllCategories(schoolId);
        //        var list = new List<int>();
        //        for (var c = 0; c < cats.Count; c++)
        //        {
        //            var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
        //            catUc.Deselect();

        //            if (c == 0 && cats.Count > 1)
        //            {
        //                list.Add(3);
        //            }
        //            else if (c == cats.Count - 1)
        //            {
        //                list.Add(2);
        //            }
        //            else
        //            {
        //                list.Add(1);
        //            }
        //            catUc.SetNameAndIdOfCategory(cats[c].Id, cats[c].Name, list);
        //            catUc.NameClicked += catUc_NameClicked;
        //            catUc.ID = "category_" + cats[c].Id;
        //            pnlCategories.Controls.Add(catUc);

        //            GetSubCats(catUc, helper, schoolId, cats[c].Id, list);
        //            list.RemoveAt(list.Count - 1);
        //        }
        //    }
        //}


        //// Note :: ├ ==>1 ,    └ ==> 2 .   ┌ ==> 3 ,   │ ==> 4 ,  empty ==> 0
        //void GetSubCats(Category.ListUC parentUc, DbHelper.Subject helper, int schoolId, int categoryId, List<int> parentPaddingList)
        //{
        //    var subcats = helper.ListSubCategories(schoolId, categoryId);
        //    var list = new List<int>();
        //    if (subcats.Count > 0)
        //    {
        //        foreach (var i in parentPaddingList)
        //        {
        //            if (i == 1 || i == 3 || i == 4)
        //            {
        //                list.Add(4);
        //            }
        //            else
        //            {
        //                list.Add(0);
        //            }
        //        }
        //    }
        //    for (var s = 0; s < subcats.Count; s++)
        //    {
        //        var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
        //        catUc.Deselect();


        //        if (s == subcats.Count - 1)
        //        {
        //            list.Add(2);
        //        }
        //        else
        //        {
        //            list.Add(1);
        //        }

        //        catUc.SetNameAndIdOfCategory(subcats[s].Id, subcats[s].Name, list);
        //        catUc.NameClicked += catUc_NameClicked;
        //        catUc.ID = "category_" + subcats[s].Id;
        //        //parentUc.AddSubCategories(catUc);
        //        pnlCategories.Controls.Add(catUc);

        //        GetSubCats(catUc, helper, schoolId, subcats[s].Id, list);
        //        list.RemoveAt(list.Count - 1);
        //    }
        //}

        #endregion


        #region Load Categories -- indentation only...i.e. diamond shape or circle shape

        void LoadCategoriesAndSubCategories(int schoolId)
        {
            var selectedCat = SelectedCategory;
            using (var helper = new DbHelper.Subject())
            {
                var cats = helper.ListAllCategories(schoolId);
                var list = new List<int>();
                for (var c = 0; c < cats.Count; c++)
                {
                    var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                    catUc.Deselect();

                    list.Add(1);

                    catUc.SetNameAndIdOfCategory(cats[c].Id, cats[c].Name, list, false);
                    catUc.NameClicked += catUc_NameClicked;
                    catUc.ID = "category_" + cats[c].Id;
                    pnlCategories.Controls.Add(catUc);

                    if ((selectedCat == cats[c].Id  && !IsPostBack) || selectedCat == 0)
                    {
                        catUc_NameClicked(catUc, new DataEventArgs()
                        {
                            Id = cats[c].Id,
                            Name = cats[c].Name
                        });
                        catUc.Select();
                        selectedCat = cats[c].Id;
                    }

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
                    list.Add(0);
                }
            }
            var selectedCat = SelectedCategory;
            for (var s = 0; s < subcats.Count; s++)
            {
                var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                catUc.Deselect();

                list.Add((parentPaddingList[parentPaddingList.Count - 1] == 1) ? 2 : 1);

                catUc.SetNameAndIdOfCategory(subcats[s].Id, subcats[s].Name, list, false);
                catUc.NameClicked += catUc_NameClicked;
                catUc.ID = "category_" + subcats[s].Id;
                //parentUc.AddSubCategories(catUc);
                pnlCategories.Controls.Add(catUc);


                if ((selectedCat == subcats[s].Id && !IsPostBack ) || selectedCat == 0)
                {
                    catUc_NameClicked(catUc, new DataEventArgs()
                    {
                        Id = subcats[s].Id,
                        Name = subcats[s].Name
                    });
                    catUc.Select();
                    selectedCat = subcats[s].Id;
                }


                GetSubCats(catUc, helper, schoolId, subcats[s].Id, list);
                list.RemoveAt(list.Count - 1);
            }
        }

        #endregion


        //========================= END of Category Listing ====================================//

        private void catUc_NameClicked(object sender, DataEventArgs e)
        {
            //load courses in this category

            var sent = sender as Views.Course.Category.ListUC;
            if (sent != null)
            {


                var earlier = pnlCategories.FindControl("category_" + hidSelectedCategory.Value);
                if (earlier != null)
                {
                    var es = earlier as Category.ListUC;
                    if (es != null)
                    {
                        es.Deselect();
                    }
                }
                lnkCoursCreate.Visible = true;

                lblCoursesTitle.Text = e.Name;
                hidSelectedCategory.Value = e.Id.ToString();
                hidSelectedCategoryName.Value = e.Name;

                LoadCourses(e.Id);
            }
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
            Response.Redirect("~/Views/Course/CategoryCreate.aspx?catId=" + hidSelectedCategory.Value);
            //MultiView1.ActiveViewIndex = 1;
            //lblHeading.Text = "Category Create";
        }

        protected void lnkCoursCreate_Click(object sender, EventArgs e)
        {
            if (hidSelectedCategory.Value != "0")
            {
                Response.Redirect("~/Views/Course/CourseCreate.aspx?catId=" + hidSelectedCategory.Value);
            }

            //if (hidSelectedCategory.Value != "0")
            //{
            //    lblHeading.Text = "Course Create";
            //    //courseCreate.CategoryId = Convert.ToInt32(hidSelectedCategory.Value);
            //    courseCreate.SetCategoryIdAndName(hidSelectedCategory.Value, hidSelectedCategoryName.Value);
            //    MultiView1.ActiveViewIndex = 2;
            //}

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