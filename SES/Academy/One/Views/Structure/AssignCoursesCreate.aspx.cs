using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Subjects;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;
using One.Views.Structure.All.UserControls.CourseLinkage;

namespace One.Views.Structure
{
    public partial class AssignCoursesCreate : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            CategoryDropDownList1.CategorySelected += CategoryDropDownList1_CategorySelected;
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                if (!IsPostBack)
                {
                    var year = Request.QueryString["yId"];
                    var subyear = Request.QueryString["sId"];

                    if (year != null && subyear != null)
                    {
                        try
                        {
                            var y = Convert.ToInt32(year);
                            var s = Convert.ToInt32(subyear);
                            YearId = y;
                            SubYearId = s;
                            using (var helper = new DbHelper.Structure())
                            {
                                //var dir = helper.GetSructureDirectory(y, s);
                                var sub = helper.GetSubYear(s);
                                var dir = sub.Year.Program.Name + " / "
                                         + sub.Year.Name + " / "
                                         + sub.Name;
                                ProgramId = sub.Year.ProgramId;

                                lblHeading.Text = "Assgin Courses to : " + (dir);

                                LoadSiteMap(dir, year, subyear);
                            }
                        }
                        catch { Response.Redirect("~/Views/Structure/"); }
                    }
                    else
                    {
                        Response.Redirect("~/Views/Structure/");
                    }

                    hidSchoolId.Value = user.SchoolId.ToString();
                    //ViewState["SelectedCourses"] = new List<Academic.ViewModel.Subject.Subject>();
                    //ViewState["SavedCourses"] = new List<Academic.ViewModel.Subject.Subject>();

                    LoadAssignedList();

                }
            }
        }

        private void LoadAssignedList()
        {
            using (var helper = new DbHelper.Subject())
            {
                var assignedCourses = helper.ListCoursesOfStructure(YearId, SubYearId);
                //ViewState["SavedCourses"] = assignedCourses;

                foreach (var subject in assignedCourses)
                {
                    lstAssignedCourses.Items.Add(new ListItem()
                    {
                        Value = subject.Id + "_" + subject.CategoryId + "_" + subject.Credit + "_" + subject.IsElective.ToString(),
                        Text = subject.Name
                    });
                }
            }
        }

        protected void lstUnAssignedCourses_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lstUnAssignedCourses.SelectedItem;
            if (selected != null)
            {
                //value has two fields -- '0'=courseId, '1'=categoryId, '2'- earlier credit,
                //'3'-elective , '4'-currently assigned credit
                txtCredit.Text = selected.Value.Split(new char[] { '_' })[2];
            }
        }

        void LoadSiteMap(string dir, string year, string subyear)
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
                                            Name = SiteMap.CurrentNode.ParentNode.ParentNode.Title
                                            ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url
                                            ,Void=true
                                        },
                                        new IdAndName(){
                                            Name = dir
                                            ,Value = SiteMap.CurrentNode.ParentNode.Url+"?yId="+year+"&sId="+subyear
                                            ,Void=true
                                        },
                                        new IdAndName(){Name = "Assign courses"}
                                    };
                SiteMapUc.SetData(list);
            }
        }

        void CategoryDropDownList1_CategorySelected(object sender, IdAndNameEventArgs e)
        {
            hidSelectedCategoryId.Value = e.Id.ToString();
            hidSelectedCategoryName.Value = e.Name;

            lstUnAssignedCourses.Items.Clear();
            LoadCourses(e.Id);

        }


        void LoadCourses(int categoryId)
        {
            var catId = categoryId.ToString();
            var selected = new List<int>();
            foreach (ListItem i in lstAssignedCourses.Items)
            {
                //value has two fields -- '0'=courseId, '1'=categoryId, '2'- earlier credit,
                //'3'-elective , '4'-currently assigned credit
                var cat = i.Value.Split(new char[] { '_' });
                //only select those which are in same category
                if (catId == cat[1])
                {
                    selected.Add(Convert.ToInt32(cat[0]));
                }
            }
            using (var helper = new DbHelper.Subject())
            {
                var unAssignedCourses = helper.ListCourses(ProgramId, categoryId, selected);

                foreach (var subject in unAssignedCourses)
                {
                    lstUnAssignedCourses.Items.Add(new ListItem()
                    {
                        Value = subject.Id + "_" + subject.SubjectCategoryId + "_" + subject.Credit //+(false).ToString(),
                        ,
                        Text = subject.FullName
                    });
                }
            }
        }


        protected void btnRemove_OnClick(object sender, EventArgs e)
        {
            var selected = lstAssignedCourses.SelectedItem;
            if (selected != null)
            {
                //lstAssignedCourses.Items.Remove(selected);
                var index = lstAssignedCourses.SelectedIndex;
                lstAssignedCourses.Items.RemoveAt(index);
                //add to the unassigned list if category is same
                var ids = selected.Value.Split(new char[] { '_' });

                //value has two fields -- '0'=courseId, '1'=categoryId, '2'- earlier credit,
                //'3'-elective , '4'-currently assigned credit
                if (hidSelectedCategoryId.Value == ids[1])
                {
                    lstUnAssignedCourses.ClearSelection();
                    var item = new ListItem()
                    {
                        Value = ids[0] + "_" + ids[1] + "_" + ids[2],//selected.Value + "_" + chkElective.Checked + "_" + txtCredit.Text
                        Text = selected.Text,
                        Selected = true
                    };
                    lstUnAssignedCourses.Items.Add(item);
                    txtCredit.Text = ids[2];
                }
            }
        }

        protected void btnAssign_OnClick(object sender, EventArgs e)
        {
            var selected = lstUnAssignedCourses.SelectedItem;
            if (selected != null)
            {
                var index = lstUnAssignedCourses.SelectedIndex;
                lstUnAssignedCourses.Items.RemoveAt(index);
                //lstUnAssignedCourses.Items.Remove(selected);

                var ids = selected.Value.Split(new char[] { '_' });
                lstAssignedCourses.ClearSelection();
                //value has two fields -- '0'=courseId, '1'=categoryId, '2'-  credit assigned (same assigned credit is used while removing),
                //'3'-elective 
                var item = new ListItem()
                {
                    Value = ids[0] + "_" + ids[1] + "_" + txtCredit.Text + "_" + chkElective.Checked
                    ,
                    Text = selected.Text
                    ,
                    Selected = true
                };
                lstAssignedCourses.Items.Add(item);
                txtCredit.Text = "";
            }
        }

        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
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

        public int SelectedCategoryId
        {
            get { return Convert.ToInt32(hidSelectedCategoryId.Value); }
            set { hidSelectedCategoryId.Value = value.ToString(); }
        }


        #endregion

        //bool selectedAlready = false;

        #region Earlier working category loading and populating code, now commented--not needed

        //private void LoadCategories(int schoolId)
        //{


        //    using (var helper = new DbHelper.Subject())
        //    {
        //        var categories = helper.ListAllCategories(schoolId);
        //        //ddlCategories.DataValueField = "Id";
        //        //ddlCategories.DataTextField = "Name";

        //        //ddlCategories.DataSource = categories;
        //        //ddlCategories.DataBind();



        //        var i = 0;

        //        var list = new List<int>();
        //        foreach (var cat in categories)
        //        {
        //            list.Add(1);
        //            var catUc = (One.Views.Course.Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
        //            catUc.ID = "category" + cat.Id.ToString() + cat.Name;
        //            catUc.Deselect();
        //            catUc.SetNameAndIdOfCategory(cat.Id, cat.Name, list, false);
        //            if (i == 0)
        //            {
        //                if (hidSelectedCategory.Value == "0")
        //                {
        //                    catUc.Select();
        //                    hidSelectedCategory.Value = cat.Id.ToString();
        //                    hidSelectedCategoryName.Value = cat.Name;
        //                    //catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
        //                    InitialUpdateOfCourses(cat.Id, cat.Name);
        //                    //LoadCourses(cat.Id);
        //                    //ViewState["selectedCategory"] = catUc;
        //                    selectedAlready = true;

        //                }
        //                else if (hidSelectedCategory.Value == cat.Id.ToString())
        //                {

        //                    //catUc.Select();
        //                    //catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
        //                    //hidSelectedCategory.Value = cat.Id.ToString();
        //                    InitialUpdateOfCourses(cat.Id, cat.Name);
        //                    selectedAlready = true;
        //                }
        //            }
        //            else if (!selectedAlready)
        //            {
        //                if (hidSelectedCategory.Value == cat.Id.ToString())
        //                {

        //                    //catUc.Select();
        //                    //catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
        //                    InitialUpdateOfCourses(cat.Id, cat.Name);
        //                    //hidSelectedCategory.Value = cat.Id.ToString();
        //                    selectedAlready = true;
        //                }
        //            }
        //            catUc.NameClicked += catUc_NameClicked;
        //            //category earlier
        //            //pnlCategories.Controls.Add(catUc);
        //            GetSubCategory(helper, schoolId, cat.Id, list);
        //            //catUc.AddSubCategories(GetSubCategory(helper,schoolId, cat.Id));
        //            list.RemoveAt(list.Count - 1);

        //            //var spaces = "";
        //            //for (int j = 0; j < list.Count * 4; j++)
        //            //{
        //            //    spaces += " ";
        //            //}
        //            //var litem = new ListItem() { Text = cat.Name };
        //            //litem.Attributes.Add("style", "background-color:#41f111");//"padding-left:"+(list.Count*4)+"px");
        //            //ddlCategories.Items.Add(litem);

        //            i++;
        //        }
        //    }
        //}

        //void GetSubCategory(DbHelper.Subject helper, int schoolId, int categoryId
        //   , List<int> prntlist)
        //{
        //    var subCategories = helper.ListSubCategories(schoolId, categoryId);
        //    var list = new List<int>();
        //    if (subCategories.Count > 0)
        //    {
        //        foreach (var i in prntlist)
        //        {
        //            list.Add(0);
        //        }
        //    }


        //    foreach (var subcat in subCategories)
        //    {

        //        var spaces = " ";
        //        for (int j = 0; j < list.Count * 4; j++)
        //        {
        //            spaces += " ";
        //        }
        //        var litem = new ListItem() { Text = spaces + subcat.Name };
        //        litem.Attributes.Add("style", "padding-left:" + (list.Count * 4) + "px");
        //        //ddlCategories.Items.Add(litem);



        //        var catUc = (One.Views.Course.Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
        //        catUc.ID = "category" + subcat.Id.ToString() + subcat.Name;
        //        list.Add((list[list.Count - 1] == 1) ? 2 : 1);

        //        //        catUc.SetNameAndIdOfCategory(subcats[s].Id, subcats[s].Name, list, false);
        //        catUc.Deselect();
        //        catUc.SetNameAndIdOfCategory(subcat.Id, subcat.Name, list, false);

        //        //if (hidSelectedCategory.Value == cat.Id.ToString())
        //        //     {

        //        //         //catUc.Select();
        //        //         //catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
        //        //         //hidSelectedCategory.Value = cat.Id.ToString();
        //        //         InitialUpdateOfCourses(cat.Id, cat.Name);
        //        //         selectedAlready = true;
        //        //     }

        //        //if (!selectedAlready)
        //        {
        //            if (hidSelectedCategory.Value == subcat.Id.ToString())
        //            {
        //                //catUc.Select();
        //                //catUc_NameClicked(null, new DataEventArgs() { Id = subcat.Id, Name = subcat.Name });
        //                InitialUpdateOfCourses(subcat.Id, subcat.Name);
        //                selectedAlready = true;
        //            }
        //        }
        //        catUc.NameClicked += catUc_NameClicked;

        //        //category earlier
        //        //pnlCategories.Controls.Add(catUc);
        //        //parentUc.AddSubCategories(catUc);
        //        GetSubCategory(helper, schoolId, subcat.Id, list);
        //        //catUc.AddSubCategories(GetSubCategory(catUc, helper,schoolId,subcat.Id));
        //        list.RemoveAt(list.Count - 1);
        //    }
        //    //return ;
        //}

        //void catUc_NameClicked(object sender, DataEventArgs e)
        //{
        //    //load courses in this category
        //    var sent = sender as Views.Course.Category.ListUC;
        //    if (sent != null)
        //    {
        //        //category earlier --all lines below
        //        //var earlier = pnlCategories.FindControl("category" + hidSelectedCategory.Value + hidSelectedCategoryName.Value);
        //        //if (earlier != null)
        //        //{
        //        //    var es = earlier as Course.Category.ListUC;
        //        //    if (es != null)
        //        //    {
        //        //        es.Deselect();
        //        //    }
        //        //}
        //        //cateogry earlier code
        //        //lblCoursesTitle.Text = e.Name;
        //        hidSelectedCategory.Value = e.Id.ToString();
        //        hidSelectedCategoryName.Value = e.Name;

        //        //cateogry earlier code
        //        //pnlCourseList.Controls.Clear();

        //        LoadCourses(e.Id);
        //    }


        //}

        //void LoadCourses(int categoryId)
        //{
        //    var selectedlist = (List<Academic.ViewModel.Subject.Subject>)ViewState["SelectedCourses"];
        //    var savedlist = (List<Academic.ViewModel.Subject.Subject>)ViewState["SavedCourses"];
        //    if (selectedlist != null && savedlist != null)
        //    {
        //        using (var helper = new DbHelper.Subject())
        //        {
        //            //dlistCourses.DataSource = helper.ListCourses(categoryId);
        //            //dlistCourses.DataBind();
        //            var courses = helper.ListCourses(categoryId);


        //            //pnlCourseList.Controls.Clear();
        //            foreach (var subject in courses)
        //            {

        //                CourseListItemUC uc = (CourseListItemUC)
        //                    Page.LoadControl("~/Views/Structure/All/UserControls/CourseLinkage/CourseListItemUC.ascx");
        //                uc.ID = "courseListing" + subject.Id + subject.FullName.Replace(" ", "_");
        //                //var name = "courseListing" + subject.Id + subject.Name.Replace(" ", "_");
        //                uc.SetCheckBoxId("chkbox" + subject.Id + subject.FullName.Replace(" ", "_"));

        //                //==================== determine saved or selected courses ==========================//
        //                var selected = selectedlist.Find(x => x.Id == subject.Id);
        //                var saved = savedlist.Find(x => x.Id == subject.Id);

        //                uc.SetCourse(subject.Id
        //                    , subject.FullName
        //                    , subject.Code
        //                    , selected != null
        //                    , saved != null);


        //                //if (selected != null)
        //                //{
        //                //    uc.SetChecked = true;
        //                //}
        //                //else
        //                //{
        //                //    uc.SetChecked = false;
        //                //}

        //                //if (saved != null)
        //                //{
        //                //    uc.SetChecked = true;
        //                //    uc.SetSaved = true;
        //                //}
        //                //else
        //                //{
        //                //    uc.SetChecked = false;
        //                //    uc.SetSaved = false;
        //                //}
        //                //========================= End =================================================//

        //                uc.CourseChecked += uc_CourseChecked;
        //        //cateogry earlier code
        //                //pnlCourseList.Controls.Add(uc);



        //            }

        //            //foreach (var subject in courses)
        //            //{
        //            //    var contrl = pnlCourseList.FindControl("courseListing" + subject.Id + subject.Name.Replace(" ", "_"));
        //            //}
        //        }
        //    }
        //}

        //void InitialUpdateOfCourses(int id, string name)
        //{
        //    //category earlier code
        //    //lblCoursesTitle.Text = name;
        //    hidSelectedCategory.Value = id.ToString();
        //    hidSelectedCategoryName.Value = name;

        //    LoadCourses(id);
        //}

        //void InitialLoadOfCheckedCourses()
        //{
        //    var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SelectedCourses"];
        //    if (list != null)
        //    {
        //        foreach (var subject in list)
        //        {
        //           // EachSelectedCourseUC each = (EachSelectedCourseUC)
        //           //Page.LoadControl("~/Views/Structure/All/UserControls/CourseLinkage/EachSelectedCourseUC.ascx");
        //           // each.ID = "each" + subject.Id + subject.Name;
        //           // each.SetName(subject.Id, subject.Name);
        //           // each.RemoveClicked += each_RemoveClicked;

        //            lstAssignedCourses.Items.Add(new ListItem(){Value = subject.Id.ToString(), Text = subject.Name});
        //            //pnlSelectedCourses.Controls.Add(each);
        //        }
        //    }
        //}

        //public void AddDataToSavedViewState()
        //{
        //    //var savedCourses = new List<Academic.ViewModel.Subject.Subject>();

        //    using (var helper = new DbHelper.Subject())
        //    {
        //        ViewState["SavedCourses"] = helper.ListCoursesOfStructure(YearId, SubYearId);
        //    }
        //}

        //void InitialLoadOfSavedCourses()
        //{
        //    var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SavedCourses"];
        //    if (list != null)
        //    {
        //        foreach (var subject in list)
        //        {
        //            // EachSelectedCourseUC each = (EachSelectedCourseUC)
        //            //Page.LoadControl("~/Views/Structure/All/UserControls/CourseLinkage/EachSelectedCourseUC.ascx");
        //            // each.ID = "saved" + subject.Id + subject.Name;
        //            // each.SetName(subject.Id, subject.Name, subject.SubjectStructureId);
        //            // each.RemoveClicked += saved_RemoveClicked;
        //            // each.UndoRemoveClicked += undo_RemoveClicked;
        //            //pnlSavedCourses.Controls.Add(each);
        //            lstAssignedCourses.Items.Add(new ListItem() { Value = subject.Id.ToString(), Text = subject.Name });
        //            //pnlSelectedCourses.Controls.Add(each);
        //        }
        //    }

        //}

        //void AddCheckedCoursesToList(Academic.ViewModel.Subject.Subject sub = null)
        //{
        //    var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SelectedCourses"];
        //    if (list != null)
        //    {
        //        if (sub != null)
        //        {
        //            if (sub.Checked)
        //            {
        //                list.Add(sub);
        //                //EachSelectedCourseUC each = (EachSelectedCourseUC)
        //                //    Page.LoadControl(
        //                //        "~/Views/Structure/All/UserControls/CourseLinkage/EachSelectedCourseUC.ascx");
        //                //each.ID = "each" + sub.Id + sub.Name;
        //                //each.SetName(sub.Id, sub.Name);
        //                //each.RemoveClicked += each_RemoveClicked;

        //                lstAssignedCourses.Items.Add(new ListItem() { Value = sub.Id.ToString(), Text = sub.Name });

        //                //pnlSelectedCourses.Controls.Add(each);
        //            }
        //            else
        //            {
        //                sub.Checked = true;
        //                var found = list.Find(x => x.Id == sub.Id);
        //                list.Remove(found);

        //                var foundItem = lstAssignedCourses.Items.FindByValue(sub.Id.ToString());
        //                if (foundItem != null)
        //                    lstAssignedCourses.Items.Remove(foundItem);

        //                //var removeEachCourse = pnlSelectedCourses.FindControl("each" + sub.Id + sub.Name);
        //                //if (removeEachCourse != null)
        //                //    pnlSelectedCourses.Controls.Remove(removeEachCourse);
        //            }
        //        }
        //    }
        //}

        //void uc_CourseChecked(object sender, SubjectEventArgs e)
        //{

        //    //not need now ; working code
        //    //if (e.Checked)
        //    //{
        //    //    EachSelectedCourseUC each = (EachSelectedCourseUC)
        //    //        Page.LoadControl("~/Views/Structure/All/UserControls/CourseLinkage/EachSelectedCourseUC.ascx");
        //    //    each.SetName(e.Id, e.Name);
        //    //    each.RemoveClicked += each_RemoveClicked;
        //    //    pnlSelectedCourses.Controls.Add(each);
        //    //}

        //    AddCheckedCoursesToList(new Academic.ViewModel.Subject.Subject() { Id = e.Id, Name = e.Name, Checked = e.Checked });

        //}

        //void undo_RemoveClicked(object sender, SubjectEventArgs e)
        //{
        //    try
        //    {
        //        var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SavedCourses"];
        //        if (list != null)
        //        {
        //            var found = list.Find(x => x.Id == e.Id);
        //            if (found != null)
        //            {
        //                found.Checked = false;
        //            }
        //        }
        //    }
        //    catch { }
        //}

        //saved list

        //void saved_RemoveClicked(object sender, SubjectEventArgs e)
        //{
        //    try
        //    {
        //        var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SavedCourses"];
        //        if (list != null)
        //        {
        //            var found = list.Find(x => x.Id == e.Id);
        //            if (found != null)
        //            {
        //                found.Checked = true;
        //                //ViewState["SavedCourses"] = list;
        //            }
        //        }
        //    }
        //    catch { }
        //}


        //selected list

        //void each_RemoveClicked(object sender, SubjectEventArgs e)
        //{
        //    try
        //    {
        //        var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SelectedCourses"];
        //        if (list != null)
        //        {
        //            //sub.Checked = true;
        //            var found = list.Find(x => x.Id == e.Id);
        //            var removed = list.Remove(found);
        //            if (removed)
        //            {
        //                var cntrlToRemove = sender as EachSelectedCourseUC;
        //                //if (cntrlToRemove != null)
        //                //    pnlSelectedCourses.Controls.Remove(cntrlToRemove);

        //                //works

        //                //var name = "courseListing" + e.Id + e.Name.Replace(" ", "_");
        //                //var ffff = pnlCourseList.FindControl("courseListing" + e.Id + e.Name.Replace(" ", "_"));
        //                //var pme = pnlCourseList.FindControl("courseListing3one");
        //                //change checked state

        //                //category earlier code
        //                /*
        //                var chkboxPanel = pnlCourseList.FindControl(
        //                    "courseListing" + e.Id + e.Name.Replace(" ", "_"));
        //                var cbPanel = pnlCourseList.FindControl(
        //                   "chkbox" + e.Id + e.Name.Replace(" ", "_"));
        //                var controlList = pnlCourseList.Controls;

        //                //pnlCourseList.

        //                if (chkboxPanel != null)
        //                {
        //                    var ckbox = chkboxPanel.FindControl("chkbox" + e.Id + e.Name.Replace(" ", "_"));
        //                    if (ckbox != null)
        //                    {
        //                        var chkbox = (ckbox as CheckBox);//.Checked = false;
        //                        if (chkbox != null)
        //                        {
        //                            chkbox.Checked = false;
        //                        }
        //                    }
        //                }
        //                */
        //                //not used 
        //                //var checkedCourse = pnlCourseList.FindControl("chkbox" + e.Id + e.Name);
        //                //if (checkedCourse != null)
        //                //{
        //                //    var chkbox = (checkedCourse as CheckBox);//.Checked = false;
        //                //    if (chkbox != null)
        //                //    {
        //                //        chkbox.Checked = false;
        //                //    }
        //                //}
        //            }
        //        }

        //    }
        //    catch
        //    {

        //    }
        //}


        #endregion


        #region Load Categories -- indentation only...i.e. diamond shape or circle shape

        //void LoadCategoriesAndSubCategories(int schoolId)
        //{
        //    var selectedCat = SelectedCategory;
        //    using (var helper = new DbHelper.Subject())
        //    {
        //        var cats = helper.ListAllCategories(schoolId);
        //        var list = new List<int>();
        //        for (var c = 0; c < cats.Count; c++)
        //        {
        //            var catUc = (Course.Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
        //            catUc.Deselect();

        //            list.Add(1);

        //            catUc.SetNameAndIdOfCategory(cats[c].Id, cats[c].Name, list, false);
        //            catUc.NameClicked += catUc_NameClicked;
        //            catUc.ID = "category_" + cats[c].Id;
        //            pnlCategories.Controls.Add(catUc);

        //            if ((selectedCat == cats[c].Id))//&& !IsPostBack) || selectedCat == 0
        //            {
        //                //catUc_NameClicked(catUc, new DataEventArgs()
        //                //{
        //                //    Id = cats[c].Id,
        //                //    Name = cats[c].Name
        //                //});


        //                var earlier = pnlCategories.FindControl("category_" + hidSelectedCategory.Value);
        //                if (earlier != null)
        //                {
        //                    var es = earlier as Course.Category.ListUC;
        //                    if (es != null)
        //                    {
        //                        es.Deselect();
        //                    }
        //                }
        //                lblCoursesTitle.Text = cats[c].Name;
        //                hidSelectedCategory.Value = cats[c].Id.ToString();
        //                hidSelectedCategoryName.Value = cats[c].Name;

        //                catUc.Select();
        //                selectedCat = cats[c].Id;
        //            }

        //            GetSubCats(catUc, helper, schoolId, cats[c].Id, list);
        //            list.RemoveAt(list.Count - 1);
        //        }
        //    }
        //}

        //// Note :: ├ ==>1 ,    └ ==> 2 .   ┌ ==> 3 ,   │ ==> 4 ,  empty ==> 0
        //void GetSubCats(Course.Category.ListUC parentUc, DbHelper.Subject helper, int schoolId, int categoryId
        //, List<int> parentPaddingList)
        //{
        //    var subcats = helper.ListSubCategories(schoolId, categoryId);
        //    var list = new List<int>();
        //    if (subcats.Count > 0)
        //    {
        //        foreach (var i in parentPaddingList)
        //        {
        //            list.Add(0);
        //        }
        //    }
        //    var selectedCat = SelectedCategory;
        //    for (var s = 0; s < subcats.Count; s++)
        //    {
        //        var catUc = (Course.Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
        //        catUc.Deselect();

        //        list.Add((parentPaddingList[parentPaddingList.Count - 1] == 1) ? 2 : 1);

        //        catUc.SetNameAndIdOfCategory(subcats[s].Id, subcats[s].Name, list, false);
        //        catUc.NameClicked += catUc_NameClicked;
        //        catUc.ID = "category_" + subcats[s].Id;
        //        //parentUc.AddSubCategories(catUc);
        //        pnlCategories.Controls.Add(catUc);


        //        if ((selectedCat == subcats[s].Id))// && !IsPostBack) || selectedCat == 0
        //        {
        //            //catUc_NameClicked(catUc, new DataEventArgs()
        //            //{
        //            //    Id = subcats[s].Id,
        //            //    Name = subcats[s].Name
        //            //});

        //            var earlier = pnlCategories.FindControl("category_" + hidSelectedCategory.Value);
        //            if (earlier != null)
        //            {
        //                var es = earlier as Course.Category.ListUC;
        //                if (es != null)
        //                {
        //                    es.Deselect();
        //                }
        //            }
        //            lblCoursesTitle.Text = subcats[s].Name;
        //            hidSelectedCategory.Value = subcats[s].Id.ToString();
        //            hidSelectedCategoryName.Value = subcats[s].Name;

        //            catUc.Select();
        //            selectedCat = subcats[s].Id;


        //            //catUc.Select();
        //            //selectedCat = subcats[s].Id;
        //        }


        //        GetSubCats(catUc, helper, schoolId, subcats[s].Id, list);
        //        list.RemoveAt(list.Count - 1);
        //    }
        //}

        //private void catUc_NameClicked(object sender, DataEventArgs e)
        //{
        //    //load courses in this category
        //    var sent = sender as Views.Course.Category.ListUC;
        //    if (sent != null)
        //    {
        //        var earlier = pnlCategories.FindControl("category_" + hidSelectedCategory.Value);
        //        if (earlier != null)
        //        {
        //            var es = earlier as Course.Category.ListUC;
        //            if (es != null)
        //            {
        //                es.Deselect();
        //            }
        //        }
        //        lblCoursesTitle.Text = e.Name;
        //        hidSelectedCategory.Value = e.Id.ToString();
        //        hidSelectedCategoryName.Value = e.Name;

        //        LoadCourses(e.Id);
        //    }
        //}


        #endregion






        protected void btnSaveAndContinueAdding_Click(object sender, EventArgs e)
        {
            //save to database and clear selection list of Viewstate
            //and then reload all
            Save();
            //AddDataToSavedViewState();
            ViewState["SelectedCourses"] = new List<Academic.ViewModel.Subject.Subject>();

            //lstUnAssignedCourses.Items.Clear();
            //lstAssignedCourses.Items.Clear();

            //pnlCourseList.Controls.Clear();
            //pnlSavedCourses.Controls.Clear();
            //pnlSelectedCourses.Controls.Clear();

            //category earlier
            //pnlCategories.Controls.Clear();
            //pnlSelectedCourses.Controls.Clear();


            //LoadCategories(SchoolId);
            //InitialLoadOfCheckedCourses();
            //InitialLoadOfSavedCourses();
            //LoadCourses(SelectedCategoryId);
        }

        protected void btnSaveAndReturn_Click(object sender, EventArgs e)
        {
            //save and return to course list 
            if (Save())
            {
                //if (SaveClicked != null)
                //{
                //    SaveClicked(this, DbHelper.StaticValues.SuccessSaveMessageEventArgs);
                //}
                //AddDataToSavedViewState();
                ViewState["SelectedCourses"] = new List<Academic.ViewModel.Subject.Subject>();
                lstUnAssignedCourses.Items.Clear();
                //pnlCourseList.Controls.Clear();
                //pnlSelectedCourses.Controls.Clear();
                //pnlSavedCourses.Controls.Clear();

                //category earlier
                //pnlCategories.Controls.Clear();
                //LoadCategories(SchoolId);
                //InitialLoadOfCheckedCourses();
                //InitialLoadOfSavedCourses();
                Response.Redirect("~/Views/Structure/CourseListing.aspx?yId=" + YearId + "&sId=" + SubYearId);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Structure/CourseListing.aspx?yId=" + YearId + "&sId=" + SubYearId);

        }

        private bool Save()
        {
            //var selectedList = ViewState["SelectedCourses"] as List<Academic.ViewModel.Subject.Subject>;
            //var savedList = ViewState["SavedCourses"] as List<Academic.ViewModel.Subject.Subject>;
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                var yearId = YearId;
                var subYearId = SubYearId;
                //if (selectedList != null && savedList != null)
                {
                    var subStructureList = new List<Academic.DbEntities.Subjects.SubjectStructure>();

                    foreach (ListItem itm in lstAssignedCourses.Items)
                    {
                        var split = itm.Value.Split(new char[] { '_' });
                        var item = new SubjectStructure()
                        {
                            SubjectId = Convert.ToInt32(split[0])
                            ,
                            YearId = yearId
                            ,
                            IsElective = Convert.ToBoolean(split[3])
                            ,
                            Credit = Convert.ToInt32(split[2])
                        };
                        if (hidSubYearId.Value != "" && hidSubYearId.Value != "0")
                        {
                            item.SubYearId = subYearId;
                        }
                        subStructureList.Add(item);
                    }
                    //YearId subyearid
                    using (var helper = new DbHelper.Subject())
                    {
                        bool saved = helper.AddOrUpdateStructureCourse(subStructureList, yearId, subYearId, user.Id);
                        return saved;
                    }

                    //selectedList.ForEach(x =>
                    //{
                    //    var item = new SubjectStructure()
                    //    {
                    //        SubjectId = x.Id
                    //        ,
                    //        CreatedBy = user.Id
                    //        ,
                    //        CreatedDate = DateTime.Now
                    //        ,
                    //        YearId = YearId
                    //    };
                    //    if (hidSubYearId.Value != "" && hidSubYearId.Value != "0")
                    //    {
                    //        item.SubYearId = SubYearId;
                    //    }
                    //    subStructureList.Add(item);
                    //});
                    //var savedSubStructureList = new List<Academic.DbEntities.Subjects.SubjectStructure>();
                    //savedList.ForEach(x =>
                    //{
                    //    var item = new SubjectStructure()
                    //    {
                    //        Id = x.SubjectStructureId
                    //        ,
                    //        Void = x.Checked

                    //    };
                    //    if (x.Checked)
                    //    {
                    //        item.VoidBy = user.Id;
                    //        item.VoidDate = DateTime.Now;
                    //    }
                    //    savedSubStructureList.Add(item);
                    //});


                    //using (var helper = new DbHelper.Subject())
                    //{
                    //    bool saved = helper.AddOrUpdateStructureCourse(savedSubStructureList, subStructureList);
                    //    return saved;
                    //}
                }
            }
            return false;
        }




        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgramId.Value); }
            set { hidProgramId.Value = value.ToString(); }
        }
    }
}