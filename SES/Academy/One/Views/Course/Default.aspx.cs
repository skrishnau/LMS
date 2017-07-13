using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Course
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = User as CustomPrincipal;
            if (user != null)
            {
                if (!IsPostBack)
                {
                    if (SiteMap.CurrentNode != null)
                    {
                        var list = new List<IdAndName>()
                        {
                           new IdAndName(){
                                        Name=SiteMap.RootNode.Title
                                        ,Value =  SiteMap.RootNode.Url
                                        ,Void=true
                                    },
                            new IdAndName(){
                                Name = SiteMap.CurrentNode.Title
                                //,Value = SiteMap.CurrentNode.ParentNode.Url
                                //,Void=true
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    if (user.IsInRole("manager") || user.IsInRole("course-editor"))
                    {
                        var edit = ((Session["editMode"] as string) ?? "0") == "1";
                        lnkCoursCreate.Visible = edit;
                        lnkCatCreate.Visible = edit;
                        Manager = edit;

                    }
                    else
                    {
                        lnkCoursCreate.Visible = false;
                        lnkCatCreate.Visible = false;
                        Manager = false;
                    }
                    SchoolId = user.SchoolId;
                    //categoryCreate.SchoolId = user.SchoolId;

                    var catId = Request.QueryString["catId"];
                    if (catId != null)
                    {
                        SelectedCategory = Convert.ToInt32(catId);
                    }
                }
                //LoadCategoriesAndSubCategories(user.SchoolId);
                LoadCategories(user.SchoolId);
            }
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
        public bool Manager
        {
            get { return Convert.ToBoolean(hidManager.Value); }
            set { this.hidManager.Value = value.ToString(); }
        }


        #region Load Categories -- indentation only...i.e. diamond shape or circle shape

        void LoadCategories(int schoolId)
        {
            var selectedCat = SelectedCategory;
            using (var helper = new DbHelper.Subject())
            {
                var cats = helper.ListAllCategories(schoolId);
                var list = new List<int>();
                if (!cats.Any())
                {
                    lnkCoursCreate.Visible = false;
                }
                var edit = Manager;
                for (var c = 0; c < cats.Count; c++)
                {
                    var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                    catUc.Deselect();

                    list.Add(1);

                    catUc.SetNameAndIdOfCategory(cats[c].Id, cats[c].Name, 0, edit);//list
                    catUc.NameClicked += catUc_NameClicked;
                    catUc.ID = "category_" + cats[c].Id;
                    pnlCategories.Controls.Add(catUc);

                    if ((selectedCat == cats[c].Id && !IsPostBack) || selectedCat == 0)
                    {
                        catUc_NameClicked(catUc, new DataEventArgs()
                        {
                            Id = cats[c].Id,
                            Name = cats[c].Name
                        });
                        catUc.Select();
                        selectedCat = cats[c].Id;
                    }

                    //GetSubCats(catUc, helper, schoolId, cats[c].Id, list);
                    GetSubCats(catUc, helper, schoolId, cats[c].Id, 1);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }
        void GetSubCats(Category.ListUC parentUc, DbHelper.Subject helper, int schoolId, int categoryId, int paddingCount)
        {

            #region Function all

            var edit = Manager;
            var subcats = helper.ListSubCategories(schoolId, categoryId);
            var selectedCat = SelectedCategory;
            for (var s = 0; s < subcats.Count; s++)
            {
                var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                catUc.Deselect();

                catUc.SetNameAndIdOfCategory(subcats[s].Id, subcats[s].Name, paddingCount,edit);//list
                paddingCount += 1;
                catUc.NameClicked += catUc_NameClicked;
                catUc.ID = "category_" + subcats[s].Id;
                //parentUc.AddSubCategories(catUc);
                pnlCategories.Controls.Add(catUc);
                if ((selectedCat == subcats[s].Id && !IsPostBack) || selectedCat == 0)
                {
                    catUc_NameClicked(catUc, new DataEventArgs()
                    {
                        Id = subcats[s].Id,
                        Name = subcats[s].Name
                    });
                    catUc.Select();
                    selectedCat = subcats[s].Id;
                }
                GetSubCats(catUc, helper, schoolId, subcats[s].Id, paddingCount);
            }

            #endregion

        }



        void LoadCategoriesAndSubCategories(int schoolId)
        {
            var selectedCat = SelectedCategory;
            using (var helper = new DbHelper.Subject())
            {
                var cats = helper.ListAllCategories(schoolId);
                var list = new List<int>();
                if (!cats.Any())
                {
                    lnkCoursCreate.Visible = false;
                }
                for (var c = 0; c < cats.Count; c++)
                {
                    var catUc = (Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                    catUc.Deselect();

                    list.Add(1);

                    catUc.SetNameAndIdOfCategory(cats[c].Id, cats[c].Name, list, false);//list
                    catUc.NameClicked += catUc_NameClicked;
                    catUc.ID = "category_" + cats[c].Id;
                    pnlCategories.Controls.Add(catUc);

                    if ((selectedCat == cats[c].Id && !IsPostBack) || selectedCat == 0)
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
                    //GetSubCats(catUc, helper, schoolId, cats[c].Id, 20);
                    list.RemoveAt(list.Count - 1);
                }
            }
        }


        //earlier code:::: works
        // Note :: ├ ==>1 ,    └ ==> 2 .   ┌ ==> 3 ,   │ ==> 4 ,  empty ==> 0
        void GetSubCats(Category.ListUC parentUc, DbHelper.Subject helper, int schoolId, int categoryId, List<int> parentPaddingList)
        {
            #region Function all

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

                catUc.SetNameAndIdOfCategory(subcats[s].Id, subcats[s].Name, list, false);//list

                catUc.NameClicked += catUc_NameClicked;
                catUc.ID = "category_" + subcats[s].Id;
                //parentUc.AddSubCategories(catUc);
                pnlCategories.Controls.Add(catUc);



                if ((selectedCat == subcats[s].Id && !IsPostBack) || selectedCat == 0)
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

            #endregion

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
                if (Manager)
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
            Response.Redirect("~/Views/Course/CategoryCreate.aspx?selectedCatId=" + hidSelectedCategory.Value);
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

        public string GetCode(object code)
        {
            if (code != null)
            {
                var c = code.ToString();
                return String.IsNullOrEmpty(c) ? "" : "&nbsp;(" + c + ")";//"&nbsp;(" + code + ")";

            }
            return "";
        }

    }
}