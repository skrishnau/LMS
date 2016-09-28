using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Subjects;
using Academic.DbHelper;
using Academic.ViewModel.Subject;
using One.Values;
using One.Values.MemberShip;
using Subject = Academic.ViewModel.Subject.Subject;

namespace One.Views.Structure.All.UserControls.CourseLinkage
{
    public partial class AddCourses : System.Web.UI.UserControl
    {

        public event EventHandler<MessageEventArgs> SaveClicked;
        public event EventHandler<MessageEventArgs> CancelClicked;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    hidSchoolId.Value = user.SchoolId.ToString();
                    ViewState["SelectedCourses"] = new List<Academic.ViewModel.Subject.Subject>();
                    ViewState["SavedCourses"] = new List<Academic.ViewModel.Subject.Subject>();
                    //ViewState["PreviousSelectedCategory"] = new One.Views.Course.Category.ListUC();

                    AddDataToSavedViewState();

                }

            }
            LoadCategories(SchoolId);
            InitialLoadOfCheckedCourses();
            InitialLoadOfSavedCourses();

            //LoadCheckedCourses();


            //InitialUpdateOfCourses();
            //LoadCourses(SelectedCategoryId);
        }

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
            get { return Convert.ToInt32(hidSelectedCategory.Value); }
            set { hidSelectedCategory.Value = value.ToString(); }
        }

        bool selectedAlready = false;


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
                    var catUc = (One.Views.Course.Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                    catUc.ID = "category" + cat.Id.ToString() + cat.Name;
                    catUc.Deselect();
                    catUc.SetNameAndIdOfCategory(cat.Id, cat.Name);
                    if (i == 0)
                    {
                        if (hidSelectedCategory.Value == "0")
                        {
                            //catUc.Select();
                            hidSelectedCategory.Value = cat.Id.ToString();
                            //catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
                            InitialUpdateOfCourses(cat.Id, cat.Name);
                            //LoadCourses(cat.Id);
                            //ViewState["selectedCategory"] = catUc;
                            selectedAlready = true;
                        }
                        else if (hidSelectedCategory.Value == cat.Id.ToString())
                        {

                            //catUc.Select();
                            //catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
                            //hidSelectedCategory.Value = cat.Id.ToString();
                            InitialUpdateOfCourses(cat.Id, cat.Name);
                            selectedAlready = true;
                        }
                    }
                    else if (!selectedAlready)
                    {
                        if (hidSelectedCategory.Value == cat.Id.ToString())
                        {

                            //catUc.Select();
                            //catUc_NameClicked(null, new DataEventArgs() { Id = cat.Id, Name = cat.Name });
                            InitialUpdateOfCourses(cat.Id, cat.Name);
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

        void GetSubCategory(One.Views.Course.Category.ListUC parentUc, DbHelper.Subject helper, int schoolId, int categoryId)
        {
            var subCategories = helper.ListSubCategories(schoolId, categoryId);
            foreach (var subcat in subCategories)
            {
                var catUc = (One.Views.Course.Category.ListUC)Page.LoadControl("~/Views/Course/Category/ListUC.ascx");
                catUc.ID = "category" + subcat.Id.ToString() + subcat.Name;

                catUc.Deselect();
                catUc.SetNameAndIdOfCategory(subcat.Id, subcat.Name);
                if (!selectedAlready)
                {
                    if (hidSelectedCategory.Value == subcat.Id.ToString())
                    {
                        //catUc.Select();
                        //catUc_NameClicked(null, new DataEventArgs() { Id = subcat.Id, Name = subcat.Name });
                        InitialUpdateOfCourses(subcat.Id, subcat.Name);
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

        void InitialUpdateOfCourses(int id, string name)
        {
            lblCoursesTitle.Text = name;
            hidSelectedCategory.Value = id.ToString();
            hidSelectedCategoryName.Value = name;

            LoadCourses(id);
        }

        void catUc_NameClicked(object sender, DataEventArgs e)
        {
            //load courses in this category

            //var uc = pnlCategories.FindControl("category" + hidSelectedCategory.Value + hidSelectedCategoryName.Value)
            //    as One.Views.Course.Category.ListUC;

            //var ucsender = sender as One.Views.Course.Category.ListUC;
            //var previousSelectedCat = ViewState["PreviousSelectedCategory"];
            //if (previousSelectedCat != null)
            //{
            //    var prev = previousSelectedCat as One.Views.Course.Category.ListUC;
            //    if (prev != null)
            //        prev.Deselect();
            //}
            //if (ucsender != null)
                //ViewState["PreviousSelectedCategory"] = ucsender;


            //if (uc != null)
            //{
            //    uc.Deselect();
            //}

            lblCoursesTitle.Text = e.Name;
            hidSelectedCategory.Value = e.Id.ToString();
            hidSelectedCategoryName.Value = e.Name;
            pnlCourseList.Controls.Clear();

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
            var selectedlist = (List<Academic.ViewModel.Subject.Subject>)ViewState["SelectedCourses"];
            var savedlist = (List<Academic.ViewModel.Subject.Subject>)ViewState["SavedCourses"];
            if (selectedlist != null && savedlist != null)
            {
                using (var helper = new DbHelper.Subject())
                {
                    //dlistCourses.DataSource = helper.ListCourses(categoryId);
                    //dlistCourses.DataBind();
                    var courses = helper.ListCourses(categoryId);


                    //pnlCourseList.Controls.Clear();
                    foreach (var subject in courses)
                    {

                        CourseListItemUC uc = (CourseListItemUC)
                            Page.LoadControl("~/Views/Structure/All/UserControls/CourseLinkage/CourseListItemUC.ascx");
                        uc.ID = "courseListing" + subject.Id + subject.Name.Replace(" ", "_");
                        //var name = "courseListing" + subject.Id + subject.Name.Replace(" ", "_");
                        uc.SetCheckBoxId("chkbox" + subject.Id + subject.Name.Replace(" ", "_"));

                        //==================== determine saved or selected courses ==========================//
                        var selected = selectedlist.Find(x => x.Id == subject.Id);
                        var saved = savedlist.Find(x => x.Id == subject.Id);

                        uc.SetCourse(subject.Id
                            , subject.Name
                            , subject.Code
                            , selected != null
                            , saved != null);


                        //if (selected != null)
                        //{
                        //    uc.SetChecked = true;
                        //}
                        //else
                        //{
                        //    uc.SetChecked = false;
                        //}

                        //if (saved != null)
                        //{
                        //    uc.SetChecked = true;
                        //    uc.SetSaved = true;
                        //}
                        //else
                        //{
                        //    uc.SetChecked = false;
                        //    uc.SetSaved = false;
                        //}
                        //========================= End =================================================//

                        uc.CourseChecked += uc_CourseChecked;
                        pnlCourseList.Controls.Add(uc);



                    }

                    //foreach (var subject in courses)
                    //{
                    //    var contrl = pnlCourseList.FindControl("courseListing" + subject.Id + subject.Name.Replace(" ", "_"));
                    //}
                }
            }
        }

        void InitialLoadOfCheckedCourses()
        {
            var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SelectedCourses"];
            if (list != null)
            {
                foreach (var subject in list)
                {
                    EachSelectedCourseUC each = (EachSelectedCourseUC)
                   Page.LoadControl("~/Views/Structure/All/UserControls/CourseLinkage/EachSelectedCourseUC.ascx");
                    each.ID = "each" + subject.Id + subject.Name;
                    each.SetName(subject.Id, subject.Name);
                    each.RemoveClicked += each_RemoveClicked;
                    pnlSelectedCourses.Controls.Add(each);
                }
            }
        }

        public void AddDataToSavedViewState()
        {
            //var savedCourses = new List<Academic.ViewModel.Subject.Subject>();
            using (var helper = new DbHelper.Subject())
            {
                ViewState["SavedCourses"] = helper.ListCoursesOfStructure(YearId, SubYearId);
            }
        }
        void InitialLoadOfSavedCourses()
        {
            var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SavedCourses"];
            if (list != null)
            {
                foreach (var subject in list)
                {
                    EachSelectedCourseUC each = (EachSelectedCourseUC)
                   Page.LoadControl("~/Views/Structure/All/UserControls/CourseLinkage/EachSelectedCourseUC.ascx");
                    each.ID = "saved" + subject.Id + subject.Name;
                    each.SetName(subject.Id, subject.Name, subject.SubjectStructureId);
                    each.RemoveClicked += saved_RemoveClicked;
                    each.UndoRemoveClicked += undo_RemoveClicked;
                    pnlSavedCourses.Controls.Add(each);
                }
            }

        }


        void AddCheckedCoursesToList(Academic.ViewModel.Subject.Subject sub = null)
        {
            var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SelectedCourses"];
            if (list != null)
            {
                if (sub != null)
                {
                    if (sub.Checked)
                    {
                        list.Add(sub);
                        EachSelectedCourseUC each = (EachSelectedCourseUC)
                            Page.LoadControl(
                                "~/Views/Structure/All/UserControls/CourseLinkage/EachSelectedCourseUC.ascx");
                        each.ID = "each" + sub.Id + sub.Name;
                        each.SetName(sub.Id, sub.Name);
                        each.RemoveClicked += each_RemoveClicked;
                        pnlSelectedCourses.Controls.Add(each);
                    }
                    else
                    {
                        sub.Checked = true;
                        var found = list.Find(x => x.Id == sub.Id);
                        list.Remove(found);
                        var removeEachCourse = pnlSelectedCourses.FindControl("each" + sub.Id + sub.Name);
                        if (removeEachCourse != null)
                            pnlSelectedCourses.Controls.Remove(removeEachCourse);
                    }
                }
            }
        }

        void uc_CourseChecked(object sender, SubjectEventArgs e)
        {

            //not need now ; working code
            //if (e.Checked)
            //{
            //    EachSelectedCourseUC each = (EachSelectedCourseUC)
            //        Page.LoadControl("~/Views/Structure/All/UserControls/CourseLinkage/EachSelectedCourseUC.ascx");
            //    each.SetName(e.Id, e.Name);
            //    each.RemoveClicked += each_RemoveClicked;
            //    pnlSelectedCourses.Controls.Add(each);
            //}

            AddCheckedCoursesToList(new Academic.ViewModel.Subject.Subject() { Id = e.Id, Name = e.Name, Checked = e.Checked });

        }

        void undo_RemoveClicked(object sender, SubjectEventArgs e)
        {
            try
            {
                var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SavedCourses"];
                if (list != null)
                {
                    var found = list.Find(x => x.Id == e.Id);
                    if (found != null)
                    {
                        found.Checked = false;
                    }
                }
            }
            catch { }
        }

        //saved list
        void saved_RemoveClicked(object sender, SubjectEventArgs e)
        {
            try
            {
                var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SavedCourses"];
                if (list != null)
                {
                    var found = list.Find(x => x.Id == e.Id);
                    if (found != null)
                    {
                        found.Checked = true;
                        //ViewState["SavedCourses"] = list;
                    }
                }
            }
            catch { }
        }


        //selected list
        void each_RemoveClicked(object sender, SubjectEventArgs e)
        {
            try
            {
                var list = (List<Academic.ViewModel.Subject.Subject>)ViewState["SelectedCourses"];
                if (list != null)
                {
                    //sub.Checked = true;
                    var found = list.Find(x => x.Id == e.Id);
                    var removed = list.Remove(found);
                    if (removed)
                    {
                        var cntrlToRemove = sender as EachSelectedCourseUC;
                        if (cntrlToRemove != null)
                            pnlSelectedCourses.Controls.Remove(cntrlToRemove);

                        //works

                        //var name = "courseListing" + e.Id + e.Name.Replace(" ", "_");
                        //var ffff = pnlCourseList.FindControl("courseListing" + e.Id + e.Name.Replace(" ", "_"));
                        //var pme = pnlCourseList.FindControl("courseListing3one");
                        //change checked state
                        var chkboxPanel = pnlCourseList.FindControl(
                            "courseListing" + e.Id + e.Name.Replace(" ", "_"));
                        var cbPanel = pnlCourseList.FindControl(
                           "chkbox" + e.Id + e.Name.Replace(" ", "_"));
                        var controlList = pnlCourseList.Controls;

                        //pnlCourseList.

                        if (chkboxPanel != null)
                        {
                            var ckbox = chkboxPanel.FindControl("chkbox" + e.Id + e.Name.Replace(" ", "_"));
                            if (ckbox != null)
                            {
                                var chkbox = (ckbox as CheckBox);//.Checked = false;
                                if (chkbox != null)
                                {
                                    chkbox.Checked = false;
                                }
                            }
                        }

                        //not used 
                        //var checkedCourse = pnlCourseList.FindControl("chkbox" + e.Id + e.Name);
                        //if (checkedCourse != null)
                        //{
                        //    var chkbox = (checkedCourse as CheckBox);//.Checked = false;
                        //    if (chkbox != null)
                        //    {
                        //        chkbox.Checked = false;
                        //    }
                        //}
                    }
                }

            }
            catch
            {

            }
        }

        protected void btnSaveAndContinueAdding_Click(object sender, EventArgs e)
        {
            //save to database and clear selection list of Viewstate
            //and then reload all
            Save();
            AddDataToSavedViewState();
            ViewState["SelectedCourses"] = new List<Academic.ViewModel.Subject.Subject>();
            pnlCourseList.Controls.Clear();
            pnlSavedCourses.Controls.Clear();
            pnlCategories.Controls.Clear();
            pnlSelectedCourses.Controls.Clear();
            LoadCategories(SchoolId);
            InitialLoadOfCheckedCourses();
            InitialLoadOfSavedCourses();
            //LoadCourses(SelectedCategoryId);
        }

        protected void btnSaveAndReturn_Click(object sender, EventArgs e)
        {
            //save and return to course list 
            if (Save())
            {
                if (SaveClicked != null)
                {
                    SaveClicked(this, DbHelper.StaticValues.SuccessSaveMessageEventArgs);
                }
                AddDataToSavedViewState();
                ViewState["SelectedCourses"] = new List<Academic.ViewModel.Subject.Subject>();
                pnlCourseList.Controls.Clear();
                pnlSavedCourses.Controls.Clear();
                pnlCategories.Controls.Clear();
                LoadCategories(SchoolId);
                InitialLoadOfCheckedCourses();
                InitialLoadOfSavedCourses();
                //Response.Redirect("~/Views/Structure/All/Master/CoursesList.aspx?yId=" + YearId + "&sId=" + SubYearId);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //clear selection viewstate as well as
            //saved viewstate
            //saved viewstate is cleared to restore any deleted courses
            //works in case of multiview 

            if (CancelClicked != null)
            {
                CancelClicked(this, DbHelper.StaticValues.CancelClickedMessageEventArgs);
            }
            AddDataToSavedViewState();
            ViewState["SelectedCourses"] = new List<Academic.ViewModel.Subject.Subject>();
            pnlCourseList.Controls.Clear();
            pnlSavedCourses.Controls.Clear();
            pnlCategories.Controls.Clear();
            //pnlSelectedCourses.Controls.Clear();
            LoadCategories(SchoolId);
            InitialLoadOfCheckedCourses();
            InitialLoadOfSavedCourses();
            //LoadCourses(SelectedCategoryId);

            //Response.Redirect("~/Views/Structure/All/Master/CoursesList.aspx?yId=" + YearId + "&sId=" + SubYearId);

        }

        private bool Save()
        {
            var selectedList = ViewState["SelectedCourses"] as List<Academic.ViewModel.Subject.Subject>;
            var savedList = ViewState["SavedCourses"] as List<Academic.ViewModel.Subject.Subject>;
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                if (selectedList != null && savedList != null)
                {
                    var subStructureList = new List<Academic.DbEntities.Subjects.SubjectStructure>();
                    selectedList.ForEach(x =>
                    {
                        var item = new SubjectStructure()
                            {
                                SubjectId = x.Id
                                ,
                                CreatedBy = user.Id
                                ,
                                CreatedDate = DateTime.Now
                                ,
                                YearId = YearId
                            };
                        if (hidSubYearId.Value != "" && hidSubYearId.Value != "0")
                        {
                            item.SubYearId = SubYearId;
                        }
                        subStructureList.Add(item);
                    });
                    var savedSubStructureList = new List<Academic.DbEntities.Subjects.SubjectStructure>();
                    savedList.ForEach(x =>
                    {
                        var item = new SubjectStructure()
                        {
                            Id = x.SubjectStructureId
                            ,
                            Void = x.Checked

                        };
                        if (x.Checked)
                        {
                            item.VoidBy = user.Id;
                            item.VoidDate = DateTime.Now;
                        }
                        savedSubStructureList.Add(item);
                    });

                    //savedList.ForEach(x =>
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
                    using (var helper = new DbHelper.Subject())
                    {
                        bool saved = helper.AddOrUpdateStructureCourse(savedSubStructureList, subStructureList);
                        return saved;
                    }
                }
            }
            return false;
        }

    }
}