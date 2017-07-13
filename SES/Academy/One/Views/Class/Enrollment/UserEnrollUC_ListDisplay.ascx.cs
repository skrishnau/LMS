using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Class;
using Academic.DbEntities.User;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Class.Enrollment
{
    public partial class UserEnrollUC_ListDisplay : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                ViewState["enrolledList"] = new List<UserClassViewModel>();
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    UserId = user.Id;
                    //============================ populate data in dropdownlist ===========//


                    var enrollmentDuration = new List<IdAndName>();
                    enrollmentDuration.Add(new IdAndName() { Id = 0, Name = "Unlimited" });
                    enrollmentDuration.Add(new IdAndName() { Id = 1, Name = "1 day" });

                    for (int i = 2; i <= 365; i++)
                    {
                        enrollmentDuration.Add(new IdAndName() { Id = i, Name = i + " days" });
                    }

                    ddlEnrollmentDuration.DataSource = enrollmentDuration;
                    ddlEnrollmentDuration.DataBind();

                    //=================== End of Data population =======================//



                    using (var helper = new DbHelper.Classes())
                    {
                        ddlEnrollmentDuration.Enabled = false;
                        //var subsession = helper.GetSubjectSession()
                        var session = helper.GetSubjectSession(SubjectSessionId);

                        if (session == null)
                        {
                            Response.Redirect("~/Views/Course/");
                            return;
                        }

                        var role = GetRole(session, user);

                        if (role == "")
                        {
                            Response.Redirect("~/Views/Class/CourseClassDetail.aspx?ccId=" + session.Id);
                            return;
                        }


                        DbHelper.ComboLoader.LoadRoleForUserEnroll(ref ddlAssignRole, user.SchoolId, role);

                        hidSessionStartDate.Value = ((session.StartDate == null)
                            ? DateTime.Now.ToShortDateString()
                            : session.StartDate.Value.ToShortDateString());
                        var startingFrom = new List<IdAndName>()
                            {
                                new IdAndName(){Id=0,Name="Class Start Day ("+((session.StartDate==null)?"not set":session.StartDate.Value.ToShortDateString())+")"}
                                ,new IdAndName(){Id=1,Name="Today "+DateTime.Now.ToShortDateString()}
                            };
                        ddlStartingFrom.DataSource = startingFrom;
                        ddlStartingFrom.DataBind();


                        var asglist = helper.ListUsersOfSubjectSession(SubjectSessionId);
                        lstAsg.DataSource = asglist;
                        lstAsg.DataBind();

                        ViewState["enrolledList"] = helper.ListSessionUsers(SubjectSessionId);

                        var notasgList = helper.ListUsersNotInSubjectSession(
                            SubjectSessionId
                            , asglist.Select(x => x.Id).ToList()
                            , user.SchoolId
                            , EnrollType);
                        lstUnAsg.DataSource = notasgList;
                        lstUnAsg.DataSource = notasgList;
                        lstUnAsg.DataBind();

                        //AutoCompleteExtender1.ServiceMethod = "GetUnassignedUsersList";

                        //group populate
                        if (session.HasGrouping)
                        {
                            pnlGroup.Visible = true;
                            ddlGroup.DataSource = session.SubjectClassGrouping.ToList();
                            ddlGroup.DataBind();
                        }
                        else
                        {
                            pnlGroup.Visible = false;
                        }

                    }
                    //DbHelper.ComboLoader.LoadStudentGroup(ref cmbGroup,
                    //    user.SchoolId, true, GroupId);
                    //SchoolId = user.SchoolId;
                    //lstUnAsg.DataSource = 
                }
            }
            else
            {

            }
            //DateChooser1.Validate = false;
        }

        private string GetRole(Academic.DbEntities.Class.SubjectClass subjCls, CustomPrincipal user)
        {
            //if enrollment method =0 (automatic) thne we can't add students
            switch (EnrollRole)
            {
                case "teacher":
                    if (user.IsInRole("manager"))
                    {
                        EnrollType = true;
                        return "teacher";
                    }
                    break;
                case "student":
                    if (user.IsInRole("manager") || user.IsInRole("teacher"))
                    {
                        EnrollType = false;
                        if (subjCls.EnrollmentMethod != 0)
                            return "student";
                    }
                    break;

            }
            return "";
        }

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }

        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static string[] GetCountries(string prefixText, int count)
        {
            var cnt = new string[]
            {
                "Nepal", "Us","UK","Pakistan","Afganistan"
            ,"america","bhutan","India","Bangladesh","syria","Myanmar","Vatican city"
            };
            return cnt.Where(x => x.StartsWith(prefixText)).ToArray();
        }

        public string[] GetUnassignedUsersList(string prefixText, int count)
        {
            using (var helper = new DbHelper.Classes())
            {
                //var user = UserId;
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {

                    var asglist = (ViewState["enrolledList"] as List<Academic.ViewModel.UserClassViewModel>)
                        ?? new List<UserClassViewModel>();
                    //if (asglist == null)
                    //    asglist = 
                    return helper.ListUsersNotInSubjectSession(
                        SubjectSessionId
                        , asglist.Select(x => x.Id).ToList()
                        , user.SchoolId
                        , EnrollType
                        ).Select(x => x.FirstName
                                                     + (string.IsNullOrEmpty(x.MiddleName) ? "" : " " + x.MiddleName)
                                                     + (string.IsNullOrEmpty(x.LastName) ? "" : " " + x.LastName))
                                                     .Where(x => x.StartsWith(prefixText))
                                                     .ToArray();
                    //+ x.LastName);

                }
                return new string[] { };//List<string>();
            }
        }


        public int SubjectSessionId
        {
            get { return Convert.ToInt32(hidSubjectSessionId.Value); }
            set { hidSubjectSessionId.Value = value.ToString(); }
        }


        //public bool GroupComboEnabled
        //{
        //    get { return cmbGroup.Enabled; }
        //    set { cmbGroup.Enabled = value; }
        //}

        //public int GroupId
        //{
        //    get { return Convert.ToInt32((txtGroupId.Text == "") ? "0" : txtGroupId.Text); }
        //    set
        //    {
        //        DbHelper.ComboLoader.LoadStudentGroup(ref cmbGroup, Values.ViewState.GetSchool(ViewState), true, GroupId);
        //        cmbGroup.Enabled = false;
        //        this.txtGroupId.Text = value.ToString();
        //    }
        //}

        protected void btnAsg_Click(object sender, EventArgs e)
        {
            var item = lstUnAsg.SelectedItem;

            ////var asgTotalItems = lstAsg.Items.Count;
            var unasgTotalItems = lstUnAsg.Items.Count;

            int asgSelectedIndex = lstAsg.SelectedIndex;
            int unasgSelectedIndex = lstUnAsg.SelectedIndex;

            lstUnAsg.ClearSelection();
            lstAsg.ClearSelection();
            if (item != null)
            {
                if (AddToEnrolledList(Convert.ToInt32(item.Value)))
                {
                    lstAsg.Items.Insert(asgSelectedIndex + 1, new ListItem(item.Text, item.Value, true));

                    lstUnAsg.Items.RemoveAt(unasgSelectedIndex);
                    var selectionNew = (unasgSelectedIndex > 0) ? (unasgSelectedIndex - 1) : ((unasgTotalItems > 1) ? 0 : -1);

                    if (selectionNew != -1)
                        lstUnAsg.SelectedIndex = unasgSelectedIndex - 1;
                    lstAsg.SelectedIndex = asgSelectedIndex + 1;
                    lstUnAsg.ClearSelection();
                    lstAsg.ClearSelection();
                }
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var item = lstAsg.SelectedItem;

            var asgTotalItems = lstAsg.Items.Count;
            var unasgTotalItems = lstUnAsg.Items.Count;

            int asgSelectedIndex = lstAsg.SelectedIndex;
            int unasgSelectedIndex = lstUnAsg.SelectedIndex;

            lstUnAsg.ClearSelection();
            lstAsg.ClearSelection();

            if (item != null)
            {
                if (RemoveFromEnrolledList(Convert.ToInt32(item.Value)))
                {
                    lstAsg.Items.RemoveAt(asgSelectedIndex);
                    lstUnAsg.Items.Insert(unasgSelectedIndex + 1, new ListItem(item.Text, item.Value));

                    var selectionNew = (asgSelectedIndex > 0) ? (asgSelectedIndex - 1) : ((asgTotalItems > 1) ? 0 : -1);
                    if (selectionNew != -1)
                        lstAsg.SelectedIndex = asgSelectedIndex - 1;
                    lstUnAsg.SelectedIndex = unasgSelectedIndex + 1;
                    lstUnAsg.ClearSelection();
                    lstAsg.ClearSelection();
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (cmbGroup.SelectedValue == "" || cmbGroup.SelectedValue == "0")
            //{
            //    RequiredFieldValidator1.IsValid = false;
            //}

            //if (lstAsg.Items.Count <= 0)
            //{
            //    RequiredFieldValidator2.IsValid = false;
            //}
            //save

            if (Page.IsValid)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    //List<int> stdList = new List<int>();
                    //foreach (ListItem item in lstAsg.Items)
                    //{
                    //    stdList.Add(Convert.ToInt32(item.Value));
                    //}
                    //if (stdList.Count > 0)
                    //{
                    using (var helper = new DbHelper.Classes())
                    {
                        //var s = helper.AssignStudentToGroup(stdList, grpId, Values.ViewState.GetUser(ViewState));
                        //if (s)
                        //{
                        //    Response.Redirect("~/Views/Student/StudentGroup/List.aspx");
                        //}
                        var savesuccess = helper.AddOrUpdateUsersList(GetSubjectSessionUsersList());
                        Response.Redirect("~/Views/Class/CourseClassDetail.aspx?ccId=" + SubjectSessionId);
                    }
                    //}
                }
            }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            //using (var helper = new DbHelper.Student())
            //{
            //    List<int> assIds = new List<int>();
            //    foreach (ListItem item in lstAsg.Items)
            //    {
            //        assIds.Add(Convert.ToInt32(item.Value));
            //    }
            //    lstUnAsg.ClearSelection();
            //    lstUnAsg.Items.Clear();
            //    var stds = helper.GetUnAssignedStudents(SchoolId, txtNameSearch.Text,
            //        txtRollSearch.Text, DateChooser1.SelectedDate);
            //    stds.RemoveAll(x => assIds.Contains(x.Id));
            //    stds.ForEach(x =>
            //    {
            //        var crn = "";
            //        if (!string.IsNullOrEmpty(x.CRN))
            //        {
            //            crn = "(" + x.CRN + ") ";
            //        }
            //        lstUnAsg.Items.Add(
            //            new ListItem(crn + x.User.FullName, x.Id.ToString()));
            //    });
            //    DateChooser1.CalendarVisible = false;
            //}
        }

        protected void lstUnAsg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }


        private List<Academic.DbEntities.Class.UserClass> GetSubjectSessionUsersList()
        {
            var enrolledList = ViewState["enrolledList"] as List<UserClassViewModel>;
            if (enrolledList != null)
            {
                var list = new List<Academic.DbEntities.Class.UserClass>();
                foreach (var uvm in enrolledList)
                {
                    list.Add(new UserClass()
                    {
                        Id = uvm.Id,
                        CreatedDate = uvm.CreatedDate
                        ,
                        EndDate = uvm.EndDate
                        ,
                        EnrollmentDuration = uvm.EnrollmentDuration
                        ,
                        RoleId = uvm.RoleId
                        ,
                        StartDate = uvm.StartDate
                        ,
                        SubjectClassId = uvm.SubjectClassId
                        ,
                        Suspended = uvm.Suspended
                        ,
                        UserId = uvm.UserId
                        ,
                        Void = uvm.Void
                        ,
                    });
                }
                return list;
            }
            return new List<UserClass>();
        }

        //private List<int> GetEnrolledList()
        //{
        //    var enrolledList = ViewState["enrolledList"] as List<Academic.DbEntities.Class.SubjectSessionUser>;
        //    if (enrolledList != null)
        //    {
        //        return enrolledList.Where(x => !(x.Void ?? false)).Select(x => x.Id).ToList();
        //    }
        //    return new List<int>();
        //}

        private bool AddToEnrolledList(int userId)
        {
            var enrolledList = ViewState["enrolledList"] as List<UserClassViewModel>;
            if (enrolledList != null)
            {

                var found = enrolledList.Find(x => x.UserId == userId);
                if (found != null)
                {
                    found.Void = false;
                    found.StartDate = (ddlStartingFrom.SelectedValue == "0") ?
                   Convert.ToDateTime(hidSessionStartDate.Value) : DateTime.Now.Date;
                    if (ddlAssignRole.SelectedValue != "0")
                    {
                        found.RoleId = Convert.ToInt32(ddlAssignRole.SelectedValue);
                    }
                    else found.RoleId = null;

                    found.EnrollmentDuration = Convert.ToInt32(ddlEnrollmentDuration.SelectedValue);
                }
                else
                {
                    var ssu = new UserClassViewModel()
                    {
                        UserId = userId
                        ,

                        Void = false
                        ,
                        SubjectClassId = SubjectSessionId
                        ,
                        CreatedDate = DateTime.Now
                    };
                    if (ddlAssignRole.SelectedValue != "0")
                    {
                        ssu.RoleId = Convert.ToInt32(ddlAssignRole.SelectedValue);
                    }
                    ssu.StartDate = (ddlStartingFrom.SelectedValue == "0") ?
                    Convert.ToDateTime(hidSessionStartDate.Value) : DateTime.Now.Date;

                    if (ddlAssignRole.SelectedValue != "0")
                    {
                        ssu.RoleId = Convert.ToInt32(ddlAssignRole.SelectedValue);
                    }
                    else ssu.RoleId = null;

                    ssu.EnrollmentDuration = Convert.ToInt32(ddlEnrollmentDuration.SelectedValue);
                    enrolledList.Add(ssu);


                }
                return true;
            }
            return false;
        }

        bool RemoveFromEnrolledList(int userId)
        {
            //var enrolledList = ViewState["enrolledList"] as List<Academic.DbEntities.Class.SubjectSessionUser>;
            var enrolledList = ViewState["enrolledList"] as List<UserClassViewModel>;
            if (enrolledList != null)
            {
                var found = enrolledList.Find(x => x.UserId == userId);
                if (found != null)
                {
                    if (found.Id > 0)
                    {
                        found.Void = true;
                    }
                    else
                    {
                        enrolledList.Remove(found);
                    }
                }
                return true;
            }
            return false;
        }

        protected void tstSearchNotEnroll_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void btnRemove_Click(object sender, EventArgs e)
        //{

        //}

        /// <summary>
        /// True: teacher , False : Student
        /// </summary>
        public bool EnrollType
        {
            get { return Convert.ToBoolean(hidTeacherOnly.Value); }
            set { hidTeacherOnly.Value = value.ToString(); }
        }

        public string EnrollRole
        {
            get { return (hidEnrollType.Value); }
            set { hidEnrollType.Value = value; }
        }
    }
}