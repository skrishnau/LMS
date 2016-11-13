using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Students;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Student.Batch.StudentEntries
{
    public partial class StudentEntr : System.Web.UI.UserControl
    {
        //public event EventHandler<StudentEntryEventArgs> DoneClicked;
        public event EventHandler<MessageEventArgs> CloseClicked;
        protected void Page_Load(object sender, EventArgs e)
        {
            //DbHelper.ComboLoader.LoadStudentGroup(ref cmbGroup, Values.Session.GetSchool(Session), true, GroupId);
            if (!IsPostBack)
            {
                //Page.ClientScript.RegisterForEventValidation(new PostBackOptions(btnClose));
            }
            StudentCreateUc.CloseClicked += StudentCreateUc_CloseClicked;
        }



        #region Properties

        //public List<Academic.DbEntities.AcacemicPlacements.StudentClass> StudentClasses { get; set; }
        public int RunningClassId { get; set; }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYear.Value); }
            set { this.hidAcademicYear.Value = value.ToString(); }
        }

        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { this.hidSessionId.Value = value.ToString(); }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { this.hidSchoolId.Value = value.ToString(); }
        }

        public int YearId
        {
            get { return Convert.ToInt32(hidYearId.Value); }
            set { this.hidYearId.Value = value.ToString(); }
        }

        public int SubYearId
        {
            get { return Convert.ToInt32(hidSubYearId.Value); }
            set { this.hidSubYearId.Value = value.ToString(); }
        }

        #endregion


        #region Events

        /*    protected void btnAsg_Click(object sender, EventArgs e)
        {
            var item = lstUnAsg.SelectedItem;

            //var asgTotalItems = lstAsg.Items.Count;
            var unasgTotalItems = lstUnAsg.Items.Count;

            int asgSelectedIndex = lstAsg.SelectedIndex;
            int unasgSelectedIndex = lstUnAsg.SelectedIndex;

            lstUnAsg.ClearSelection();
            lstAsg.ClearSelection();
            if (item != null)
            {
                lstAsg.Items.Insert(asgSelectedIndex + 1, new ListItem(item.Text, item.Value, true));
                StudentClasses.Insert(asgSelectedIndex + 1, new Academic.DbEntities.AcacemicPlacements.StudentClass()
                {
                    //RunningClass = 
                    StudentId = Convert.ToInt32(item.Value)
                    ,
                    RunningClassId = RunningClassId

                });
                lstUnAsg.Items.RemoveAt(unasgSelectedIndex);
                var selectionNew = (unasgSelectedIndex > 0) ? (unasgSelectedIndex - 1) : ((unasgTotalItems > 1) ? 0 : -1);

                if (selectionNew != -1)
                    lstUnAsg.SelectedIndex = unasgSelectedIndex - 1;
                lstAsg.SelectedIndex = asgSelectedIndex + 1;

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
                lstAsg.Items.RemoveAt(asgSelectedIndex);
                StudentClasses.RemoveAt(asgSelectedIndex);
                lstUnAsg.Items.Insert(unasgSelectedIndex + 1, new ListItem(item.Text, item.Value));

                var selectionNew = (asgSelectedIndex > 0) ? (asgSelectedIndex - 1) : ((asgTotalItems > 1) ? 0 : -1);
                if (selectionNew != -1)
                    lstAsg.SelectedIndex = asgSelectedIndex - 1;
                lstUnAsg.SelectedIndex = unasgSelectedIndex + 1;
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.Student())
            {
                List<int> assIds = new List<int>();
                foreach (ListItem item in lstAsg.Items)
                {
                    assIds.Add(Convert.ToInt32(item.Value));
                }
                lstUnAsg.ClearSelection();
                lstUnAsg.Items.Clear();
                var stds = helper.GetStudentList(Values.Session.GetSchool(Session), txtNameSearch.Text,
                    txtRollSearch.Text);//, DateChooser1.SelectedDate);
                stds.RemoveAll(x => assIds.Contains(x.Id));
                stds.ForEach(x =>
                {
                    var crn = "";
                    if (!string.IsNullOrEmpty(x.CRN))
                    {
                        crn = "(" + x.CRN + ") ";
                    }
                    lstUnAsg.Items.Add(
                        new ListItem(crn + x.User.FullName, x.Id.ToString()));
                });
                //DateChooser1.CalendarVisible = false;
            }
        }

        protected void btnAsg_Click1(object sender, ImageClickEventArgs e)
        {
            btnAsg_Click(sender, new EventArgs());
        }

        protected void btnRemove_Click1(object sender, ImageClickEventArgs e)
        {
            btnRemove_Click(sender, new EventArgs());
        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            btnLoad_Click(sender, new EventArgs());
        }
         
*/
        #endregion




        protected void btnsave_Click(object sender, ImageClickEventArgs e)
        {
            //if (DoneClicked != null)
            //{
            //    var arg = new StudentEntryEventArgs()
            //    {
            //        StudentClasses = StudentClasses
            //    };
            //    DoneClicked(sender, arg);
            //}
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            if (CloseClicked != null)
            {
                CloseClicked(this, DbHelper.StaticValues.CancelClickedMessageEventArgs);
            }
        }

        protected void btnGroup_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnSingle_Click(object sender, ImageClickEventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        public void LoadStudentBatch(RunningClassEventArgs e)
        {
            YearId = e.YearId;
            SubYearId = e.SubYearId;

        }

        /*
                public void LoadStudentGroup(Values.RunningClassEventArgs e)
                {

                    YearId = e.YearId;
                    SubYearId = e.SubYearId;
                    List<Academic.DbEntities.AcacemicPlacements.StudentClass> stdClsLst =
                        (List<Academic.DbEntities.AcacemicPlacements.StudentClass>)ViewState["StudentClassList"];



                    using (var helper = new DbHelper.AcademicPlacement())
                    using (var acahelper = new DbHelper.AcademicYear())
                    using (var stdHelper = new DbHelper.Student())
                    {
                        List<Academic.DbEntities.Students.StudentGroup> stdOtherGrps;// = new List<StudentGroup>();
                        List<Academic.DbEntities.Students.StudentGroup> stdGrpInYr;// = new List<StudentGroup>();
                        List<Academic.DbEntities.Students.StudentGroup> stdNewGrps;// = new List<StudentGroup>();

                        Academic.DbEntities.Session prevSession;
                        Academic.DbEntities.AcademicYear prevAcaYear;

                        if (e.Type == "year")
                        {
                            //get student studying in one year less in previous academic year
                            prevAcaYear = acahelper.GetPreviousAcademicYear(AcademicYearId);
                            if (prevAcaYear != null)
                            {
                                stdOtherGrps = helper.GetStudentGroupListStudying(prevAcaYear.Id);
                                lstOthergroups.DataSource = stdOtherGrps;
                                lstOthergroups.DataValueField = "Id";
                                lstOthergroups.DataTextField = "Name";

                                stdGrpInYr = helper.GetStudentGroupStudyingInYearOrSubYearInAcademicYear(prevAcaYear.Id,
                                    e.YearId);
                                lstEarlier.DataSource = stdGrpInYr;
                                lstEarlier.DataValueField = "Id";
                                lstEarlier.DataTextField = "Name";
                            }
                        }
                        else if (e.Type == "subyear")
                        {
                            //get student studying in one subyear less in previous session
                            prevSession = acahelper.GetPreviousSession(AcademicYearId, SessionId);
                            if (prevSession != null)
                            {
                                var acaYear = prevSession.AcademicYear;

                                stdOtherGrps = helper.GetStudentGroupListStudying(prevSession.AcademicYearId, prevSession.Id);
                                lstOthergroups.DataSource = stdOtherGrps;
                                lstOthergroups.DataValueField = "Id";
                                lstOthergroups.DataTextField = "Name";

                                stdGrpInYr = helper.GetStudentGroupStudyingInYearOrSubYearInAcademicYear(acaYear.Id
                                , e.YearId, sessionId: prevSession.Id, subYearId: e.SubYearId);
                                lstEarlier.DataSource = stdGrpInYr;
                                lstEarlier.DataValueField = "Id";
                                lstEarlier.DataTextField = "Name";
                            }
                        }
                        stdNewGrps = stdHelper.GetNewStudentGroups(Values.Session.GetSchool(Session));
                        lstNewGroups.DataSource = stdNewGrps;
                        lstNewGroups.DataValueField = "Id";
                        lstNewGroups.DataTextField = "Name";
                    }
                }



                protected void lstNewGroups_SelectedIndexChanged(object sender, EventArgs e)
                {
                    lstOthergroups.ClearSelection();
                    lstEarlier.ClearSelection();
                }

                protected void lstEarlier_SelectedIndexChanged(object sender, EventArgs e)
                {
                    lstOthergroups.ClearSelection();
                    lstNewGroups.ClearSelection();
                }

                protected void lstOthergroups_SelectedIndexChanged(object sender, EventArgs e)
                {
                    lstNewGroups.ClearSelection();
                    lstEarlier.ClearSelection();
                }
                */
        protected void btnDone_Click(object sender, EventArgs e)
        {
            /*
            if (DoneClicked != null)
            {
                List<Academic.DbEntities.AcacemicPlacements.StudentClass> stdClsLst =
                            (List<Academic.DbEntities.AcacemicPlacements.StudentClass>)ViewState["StudentClassList"];

                if (stdClsLst != null)
                {
                    //next version we should be able to select list of students.
                    var lst = new List<Academic.DbEntities.AcacemicPlacements.StudentClass>();
                    //-----------should be inside for-loop of selection list--------------------
                    var stdCls = new Academic.DbEntities.AcacemicPlacements.StudentClass()
                    {
                        RunningClass = new Academic.DbEntities.AcacemicPlacements.RunningClass()
                        {
                            YearId = YearId
                           ,IsActive = true
                        }
                    };
                    if (SubYearId > 0)
                    {
                        stdCls.RunningClass.SubYearId = SubYearId;
                    }

                    if (!String.IsNullOrEmpty(lstEarlier.SelectedValue))
                    {
                        stdCls.StudentGroupId = Convert.ToInt32(lstEarlier.SelectedValue);
                    }
                    else if (string.IsNullOrEmpty(lstNewGroups.SelectedValue))
                    {
                        stdCls.StudentGroupId = Convert.ToInt32(lstNewGroups.SelectedValue);
                    }
                    else if (string.IsNullOrEmpty(lstOthergroups.SelectedValue))
                    {
                        stdCls.StudentGroupId = Convert.ToInt32(lstOthergroups.SelectedValue);
                    }
                    lst.Add(stdCls);
                    //-----------------------------------
                    ViewState["StudentClassList"] = stdClsLst;
                    DoneClicked(this, new StudentEntryEventArgs()
                                    {
                                        StudentClasses = lst
                                    });
                }
            
            }*/
        }

        protected void btnCloseDialog_Click(object sender, ImageClickEventArgs e)
        {
            btnClose.Visible = !btnClose.Visible;
        }
        void StudentCreateUc_CloseClicked(object sender, MessageEventArgs e)
        {
            if (CloseClicked != null)
            {
                CloseClicked(sender, e);
            }
        }
    }
}