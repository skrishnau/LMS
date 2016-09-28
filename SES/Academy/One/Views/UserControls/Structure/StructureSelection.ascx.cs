using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.UserControls.Structure
{
    public partial class StructureSelection : System.Web.UI.UserControl
    {
        public event EventHandler<MessageEventArgs> OnSaveClicked;
        private int subyearMax = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMsg.Visible = false;
            valiPostion.ErrorMessage = "Required";
            if (!IsPostBack)
            {
                using (var helper = new DbHelper.Structure())
                {
                    int subyearSchool = helper.GetMaximumNoOfSubyears(SchoolId: SchoolId);
                    hidMaxSubYear.Value = subyearSchool.ToString();
                }
                if (AcademicYearId > 0)
                {
                    cmbAcademicYear.Enabled = false;
                }
                LoadLevel();
                LoadAcademicYear();
            }
        }



        #region Properties of this usercontrol

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { this.hidSchoolId.Value = value.ToString(); }
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcaId.Value); }
            set
            {
                LoadAcademicYear();
                this.hidAcaId.Value = value.ToString();
            }
        }

        #endregion


        #region Combo Index Changed Functions

        protected void cmbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLevel.SelectedValue != "" && cmbLevel.SelectedValue != "0")
            {
                using (var helper = new DbHelper.Structure())
                {
                    subyearMax = helper.GetMaximumNoOfSubyears(levelId: Convert.ToInt32(cmbLevel.SelectedValue));
                    //hidMaxSubYear.Value = subyearMax.ToString();
                    //if (subyearMax == 0)
                    //{
                    //    pnlSubYearPosition.Enabled = false;
                    //    valiPostion.Enabled = false;
                    //    txtSubYearPosition.Text = "";
                    //}
                    //else
                    //{
                    //    pnlSubYearPosition.Enabled = true;
                    //    valiPostion.Enabled = true;
                    //}
                }
                LevelsBelowHierarchyAllEnabled(true);
                LoadFaculties();
            }
            else
            {
                using (var helper = new DbHelper.Structure())
                {
                    subyearMax = helper.GetMaximumNoOfSubyears(SchoolId: Convert.ToInt32(SchoolId));
                }
                LevelsBelowHierarchyAllEnabled();
            }
        }

        protected void cmbFaculties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFac.SelectedValue != "" && cmbFac.SelectedValue != "0")
            {
                using (var helper = new DbHelper.Structure())
                {
                    subyearMax = helper.GetMaximumNoOfSubyears(facultyId: Convert.ToInt32(cmbFac.SelectedValue));
                    //hidMaxSubYear.Value = subyearMax.ToString();
                    //if (subyearMax == 0)
                    //{
                    //    pnlSubYearPosition.Enabled = false;
                    //    valiPostion.Enabled = false;
                    //    txtSubYearPosition.Text = "";
                    //}
                    //else
                    //{
                    //    pnlSubYearPosition.Enabled = true;
                    //    valiPostion.Enabled = true;
                    //}
                }
                FacultyBelowHierarchyAllEnable(true);
                LoadPrograms();
            }
            else
            {
                using (var helper = new DbHelper.Structure())
                {
                    subyearMax = helper.GetMaximumNoOfSubyears(levelId: Convert.ToInt32(cmbLevel.SelectedValue));
                }
                FacultyBelowHierarchyAllEnable(false);
            }
        }

        protected void cmbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProgram.SelectedValue != "" && cmbProgram.SelectedValue != "0")
            {
                using (var helper = new DbHelper.Structure())
                {

                    subyearMax = helper.GetMaximumNoOfSubyears(programId: Convert.ToInt32(cmbProgram.SelectedValue));
                    //hidMaxSubYear.Value = subyearMax.ToString();
                    //if (subyearMax == 0)
                    //{
                    //    pnlSubYearPosition.Enabled = false;
                    //    valiPostion.Enabled = false;
                    //    txtSubYearPosition.Text = "";
                    //}
                    //else
                    //{
                    //    pnlSubYearPosition.Enabled = true;
                    //    valiPostion.Enabled = true;
                    //}
                }
                ProgramBelowHierarchyAllEnable(true);
                LoadYears();
            }
            else
            {
                using (var helper = new DbHelper.Structure())
                {
                    subyearMax = helper.GetMaximumNoOfSubyears(facultyId: Convert.ToInt32(cmbFac.SelectedValue));
                }
                ProgramBelowHierarchyAllEnable();
            }

        }

        protected void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (cmbYear.SelectedValue != "" && cmbYear.SelectedValue != "0")
            {
                using (var helper = new DbHelper.Structure())
                {

                    subyearMax = helper.GetMaximumNoOfSubyears(yearId: Convert.ToInt32(cmbYear.SelectedValue));

                    //hidMaxSubYear.Value = subyearMax.ToString();
                    //if (subyearMax == 0)
                    //{
                    //    pnlSubYearPosition.Enabled = false;
                    //    valiPostion.Enabled = false;
                    //    txtSubYearPosition.Text = "";
                    //}
                    //else
                    //{
                    //    pnlSubYearPosition.Enabled = true;
                    //    valiPostion.Enabled = true;
                    //}
                }
                YearBelowHierarchyAllEnable(true);
                //pnlSubYearAll.Visible = true;
                LoadSubYears();
                cmbSubYear_SelectedIndexChanged1(sender, e);
            }
            else
            {
                using (var helper = new DbHelper.Structure())
                {
                    subyearMax = helper.GetMaximumNoOfSubyears(programId: Convert.ToInt32(cmbProgram.SelectedValue));
                }
                YearBelowHierarchyAllEnable();
                cmbSubYear_SelectedIndexChanged1(sender, e);
            }
        }

        protected void cmbSubYear_SelectedIndexChanged1(object sender, EventArgs e)
        {
            cmbSubYear_SelectedIndexChanged(sender, e);
        }

        protected void cmbSubYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subyearMax == 0)
            {
                pnlSubYearPosition.Enabled = false;
                valiPostion.Enabled = false;
                txtSubYearPosition.Text = "";
            }
            else
            {
                pnlSubYearPosition.Enabled = true;
                valiPostion.Enabled = true;
            }
            //if ((cmbSubYear.SelectedValue != "" && cmbSubYear.SelectedValue != "0"))
            //{
            //    //SubYearBelowHierarchyAllEnable(true);
            //    //pnlSubYearAll.Visible = true;
            //    //LoadPhase();

            //    pnlSubYearPosition.Enabled = false;
            //    valiPostion.Enabled = false;
            //    txtSubYearPosition.Text = "";
            //}
            //else
            //{
            //    if (cmbSubYear.SelectedItem != null)
            //    {
            //        //pnlSubYearPosition.Enabled = true;
            //        if (cmbSubYear.SelectedItem.Text == "None")
            //        {
            //            pnlSubYearPosition.Enabled = false;
            //            valiPostion.Enabled = false;
            //            txtSubYearPosition.Text = "";
            //        }
            //    }
            //    else
            //    {
            //        pnlSubYearPosition.Enabled = true;
            //        valiPostion.Enabled = true;
            //    }
            //    //if ((cmbSubYear.SelectedItem ?? new ListItem("None", "")).Text == "None")
            //    //{

            //    //}
            //    //else
            //    //{
            //    //    pnlSubYearPosition.Enabled = true;
            //    //}
            //    //SubYearBelowHierarchyAllEnable();
            //}
        }

        protected void cmbAcademicYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSession();
        }

        #endregion


        #region Load Functions

        private void LoadAcademicYear()
        {
            DbHelper.ComboLoader.LoadAcademicYear(ref cmbAcademicYear, SchoolId, AcademicYearId);
            if (AcademicYearId > 0)
            {
                cmbAcademicYear.Enabled = false;
                LoadSession();
            }
        }

        private void LoadSession()
        {
            DbHelper.ComboLoader.LoadSession(ref cmbSession, Convert.ToInt32(cmbAcademicYear.SelectedValue), false, true);
        }

        private void LoadLevel()
        {
            DbHelper.ComboLoader.LoadLevel(ref cmbLevel, SchoolId, 0, true);//Values.Session.GetSchool(Session)
            //pnlLevelCreate.Visible = false;
            //LevelCreate.SchoolId = SchoolId;
        }

        private void LoadFaculties()
        {
            DbHelper.ComboLoader.LoadFaculty(ref cmbFac
                , Convert.ToInt32(cmbLevel.SelectedValue)
                , false);
            //FacultyCreateUC.SchoolId = SchoolId;
            //FacultyCreateUC.LevelId = Convert.ToInt32(cmbLevels.SelectedValue);
        }

        private void LoadPrograms()
        {
            DbHelper.ComboLoader.LoadProgram(ref cmbProgram
                , Convert.ToInt32(cmbFac.SelectedValue)
                , false);
            //DbHelper.ComboLoader.LoadFaculty(ref cmbFaculties, Convert.ToInt32(cmbLevels.SelectedValue));
            //ProgramCreateUC.SchoolId = SchoolId;
            //ProgramCreateUC.LevelId = Convert.ToInt32(cmbLevels.SelectedValue);
            //ProgramCreateUC.FacultyId = Convert.ToInt32(cmbFaculties.SelectedValue);
        }

        private void LoadYears()
        {
            DbHelper.ComboLoader.LoadYear(ref cmbYear
                , Convert.ToInt32(cmbFac.SelectedValue)
                , false);
            //DbHelper.ComboLoader.LoadFaculty(ref cmbFaculties, Convert.ToInt32(cmbLevels.SelectedValue));
            //YearCreateUC.SchoolId = SchoolId;
            //YearCreateUC.LevelId = Convert.ToInt32(cmbLevels.SelectedValue);
            //YearCreateUC.FacultyId = Convert.ToInt32(cmbFaculties.SelectedValue);
            //YearCreateUC.ProgramId = Convert.ToInt32(cmbPrograms.SelectedValue);
        }

        private void LoadSubYears()
        {
            DbHelper.ComboLoader.LoadSubYear(ref cmbSubYear
                , Convert.ToInt32(cmbYear.SelectedValue), 0);
            //SubYearCreateUC.SchoolId = SchoolId;
            //SubYearCreateUC.LevelId = Convert.ToInt32(cmbLevels.SelectedValue);
            //SubYearCreateUC.FacultyId = Convert.ToInt32(cmbFaculties.SelectedValue);
            //SubYearCreateUC.ProgramId = Convert.ToInt32(cmbPrograms.SelectedValue);
            //SubYearCreateUC.YearId = Convert.ToInt32(cmbYear.SelectedValue);
        }

        private void LoadPhase()
        {
            DbHelper.ComboLoader.LoadPhase(ref cmbSubYear
               , Convert.ToInt32(cmbSubYear.SelectedValue)
               , true);
        }
        #endregion


        #region Visiblity Functions

        void LevelsBelowHierarchyAllEnabled(bool enable = false)
        {
            cmbFac.Enabled = enable;
            if (!enable)
            {
                cmbFac.Items.Clear();
            }
            FacultyBelowHierarchyAllEnable();
        }

        void FacultyBelowHierarchyAllEnable(bool enable = false)
        {
            cmbProgram.Enabled = enable;

            if (!enable)
            {
                //cmbProgram.DataSource = null;
                cmbProgram.Items.Clear();
            }
            ProgramBelowHierarchyAllEnable();
        }

        void ProgramBelowHierarchyAllEnable(bool enable = false)
        {
            cmbYear.Enabled = enable;

            if (!enable)
            {
                cmbYear.Items.Clear();
            }
            YearBelowHierarchyAllEnable();
        }

        void YearBelowHierarchyAllEnable(bool enable = false)
        {
            cmbSubYear.Enabled = enable;

            if (!enable)
            {
                //cmbSubYear.DataSource = null;
                cmbSubYear.Items.Clear();
            }
            SubYearBelowHierarchyAllEnable();
        }

        void SubYearBelowHierarchyAllEnable(bool enable = false)
        {
            cmbSubYear_SelectedIndexChanged(new object(), new EventArgs());
            //cmbPhase.Enabled = enable;
            //if (!enable)
            //{
            //    cmbPhase.DataSource = null;
            //}
        }

        #endregion



        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbAcademicYear.SelectedValue == "0" || cmbAcademicYear.SelectedValue == "")
            {
                valiAca.IsValid = false;
            }
            int sessionId = 0;
            int subyearPosition = -1;

            if (!string.IsNullOrEmpty(txtSubYearPosition.Text))
                subyearPosition = Convert.ToInt32(txtSubYearPosition.Text);

            if (cmbSession.SelectedValue != "0" && cmbSession.SelectedValue != "")
            {
                sessionId = Convert.ToInt32(cmbSession.SelectedValue);
                //valiSession.IsValid = false;
            }

            if (Page.IsValid)
            {
                var academicYearId = Convert.ToInt32(cmbAcademicYear.SelectedValue);
                //var sessionId = Convert.ToInt32(cmbSession.SelectedValue);

                List<Academic.DbEntities.AcacemicPlacements.RunningClass>
                    classes = new List<Academic.DbEntities.AcacemicPlacements.RunningClass>();
                // List<Academic.DbEntities.Session> sessions;
                using (var helper = new DbHelper.AcademicYear())
                {
                    //sessions = //new List<Academic.DbEntities.Session>();
                    //   helper.GetTopSessionListForAcademicYear(academicYearId);
                }
                using (var helper = new DbHelper.Structure())
                {
                    if (cmbLevel.SelectedValue != "0" && cmbLevel.SelectedValue != "")
                    {
                        var levelId = Convert.ToInt32(cmbLevel.SelectedValue);

                        if (cmbFac.SelectedValue != "0" && cmbFac.SelectedValue != "")
                        {
                            var facultyId = Convert.ToInt32(cmbFac.SelectedValue);

                            if (cmbProgram.SelectedValue != "0" && cmbProgram.SelectedValue != "")
                            {
                                var programId = Convert.ToInt32(cmbProgram.SelectedValue);
                                if (cmbYear.SelectedValue != "0" && cmbYear.SelectedValue != "")
                                {
                                    var yearId = Convert.ToInt32(cmbYear.SelectedValue);



                                    if (cmbSubYear.SelectedValue != "0" && cmbSubYear.SelectedValue != "")
                                    {
                                        //equivalent found so save it 
                                        if (cmbSession.SelectedValue == "0" || cmbSession.SelectedValue == "")
                                        {
                                            valiSession.IsValid = false;
                                            return;
                                        }
                                        var ent = new Academic.DbEntities.AcacemicPlacements.RunningClass()
                                        {
                                            AcademicYearId = Convert.ToInt32(cmbAcademicYear.SelectedValue)
                                            ,
                                            SessionId = Convert.ToInt32(cmbSession.SelectedValue)
                                            ,
                                            YearId = yearId
                                            ,
                                            SubYearId = Convert.ToInt32(cmbSubYear.SelectedValue)

                                        };
                                        classes.Add(ent);
                                    }
                                    else if (cmbSubYear.SelectedValue == "0")
                                    {
                                        //all sub year of the selected year


                                        var subyears = helper.ListSubYears(yearId);
                                        if (subyears.Count > 0 && sessionId == 0) //!= sessions.Count)
                                        {
                                            //return with error// since semester can't be matched with fall or spring session
                                            //i.e. either no session then we need to add year only
                                            lblMsg.Visible = true;
                                            lblMsg.Text = "SubYear and Sessions count don't match: in" +
                                                          cmbYear.SelectedItem.Text + " year.";
                                            return;
                                        }
                                        GetClasses(academicYearId, yearId
                                            , subyears, sessionId
                                            , ref classes, subyearPosition);
                                        //for (var i=0;i<subyears.Count;i++)
                                        //{
                                        //    var ent = new Academic.DbEntities.Activities.ActiveClassesInAcademicYear()
                                        //    {
                                        //        AcademicYearId = academicYearId
                                        //        ,
                                        //        SessionId = sessions[i].Id
                                        //        ,
                                        //        YearId = yearId
                                        //        ,
                                        //        SubYearId = subyears[i].Id

                                        //    };
                                        //    classes.Add(ent);
                                        //}
                                    }
                                }
                                else if (cmbYear.SelectedValue == "0")
                                {
                                    //all year of the selected program
                                    var years = helper.GetYears(programId);
                                    //var subyears = helper.ListSubYears(yearId);
                                    foreach (var year in years)
                                    {
                                        var subyears = helper.ListSubYears(year.Id);
                                        //session hudaina Arts ko only Year so below is true for these.
                                        if (subyears.Count > 0 && sessionId == 0)//!= sessions.Count)
                                        {
                                            //return with error// since semester can't be matched with fall or spring session
                                            //i.e. either no session then we need to add year only
                                            lblMsg.Visible = true;
                                            lblMsg.Text = "SubYear and Sessions count don't match: in" +
                                                          cmbYear.SelectedItem.Text + " year" + " of " +
                                                          cmbProgram.SelectedItem.Text + " program.";
                                            return;
                                        }
                                        GetClasses(academicYearId, year.Id, subyears
                                            , sessionId, ref classes, subyearPosition);
                                        //for (var i = 0; i < subyears.Count; i++)
                                        //{
                                        //    var ent = new Academic.DbEntities.Activities.ActiveClassesInAcademicYear()
                                        //    {
                                        //        AcademicYearId = academicYearId
                                        //        ,
                                        //        SessionId = sessions[i].Id
                                        //        ,
                                        //        YearId = year.Id
                                        //        ,
                                        //        SubYearId = subyears[i].Id

                                        //    };
                                        //    classes.Add(ent);
                                        //}
                                    }
                                }
                            }
                            else if (cmbProgram.SelectedValue == "0")
                            {
                                //all program of the selected Faculty
                                var programs = helper.GetPrograms(facultyId);
                                foreach (var program in programs)
                                {
                                    var years = helper.GetYears(program.Id);
                                    //var subyears = helper.ListSubYears(yearId);
                                    foreach (var year in years)
                                    {
                                        var subyears = helper.ListSubYears(year.Id);
                                        if (subyears.Count > 0 && sessionId == 0)//!= sessions.Count)
                                        {
                                            //return with error// since semester can't be matched with fall or spring session
                                            //i.e. either no session then we need to add year only
                                            lblMsg.Visible = true;
                                            lblMsg.Text = "SubYear and Sessions count don't match: in" + " some year" + " of " +
                                                          cmbProgram.SelectedItem.Text + " program of "
                                                          + cmbFac.SelectedItem.Text + " faculty.";

                                            return;
                                        }
                                        GetClasses(academicYearId, year.Id, subyears
                                            , sessionId, ref classes, subyearPosition);
                                        //for (var i = 0; i < subyears.Count; i++)
                                        //{
                                        //    var ent = new Academic.DbEntities.Activities.ActiveClassesInAcademicYear()
                                        //    {
                                        //        AcademicYearId = academicYearId
                                        //        ,
                                        //        SessionId = sessions[i].Id
                                        //        ,
                                        //        YearId = year.Id
                                        //        ,
                                        //        SubYearId = subyears[i].Id

                                        //    };
                                        //    classes.Add(ent);
                                        //}
                                    }

                                }
                            }
                        }
                        else if (cmbFac.SelectedValue == "0")
                        {
                            //all faculty of the selected Levvel
                            var faculties = helper.GetFaculties(levelId);
                            foreach (var faculty in faculties)
                            {
                                //all program of the selected Faculty
                                var programs = helper.GetPrograms(faculty.Id);
                                foreach (var program in programs)
                                {
                                    var years = helper.GetYears(program.Id);
                                    //var subyears = helper.ListSubYears(yearId);
                                    foreach (var year in years)
                                    {
                                        var subyears = helper.ListSubYears(year.Id);
                                        if (subyears.Count > 0 && sessionId == 0)// != sessions.Count)
                                        {
                                            //return with error// since semester can't be matched with fall or spring session
                                            //i.e. either no session then we need to add year only
                                            lblMsg.Visible = true;
                                            lblMsg.Text = "SubYear and Sessions count don't match: in" +
                                                         " some year" + " of " +
                                                           " some program of "
                                                          + cmbFac.SelectedItem.Text + " faculty of "
                                                          + cmbLevel.SelectedItem.Text + " level.";
                                            return;
                                        }
                                        GetClasses(academicYearId, year.Id, subyears, sessionId, ref classes
                                            , subyearPosition);
                                        //for (var i = 0; i < subyears.Count; i++)
                                        //{
                                        //    var ent = new Academic.DbEntities.Activities.ActiveClassesInAcademicYear()
                                        //    {
                                        //        AcademicYearId = academicYearId
                                        //        ,
                                        //        SessionId = sessions[i].Id
                                        //        ,
                                        //        YearId = year.Id
                                        //        ,
                                        //        SubYearId = subyears[i].Id

                                        //    };
                                        //    classes.Add(ent);
                                        //}
                                    }

                                }
                            }
                        }
                    }
                    else if (cmbLevel.SelectedValue == "0")
                    {
                        //all level of the school
                        var levels = helper.GetLevels(SchoolId);
                        foreach (var level in levels)
                        {
                            var faculties = helper.GetFaculties(level.Id);
                            foreach (var faculty in faculties)
                            {
                                //all program of the selected Faculty
                                var programs = helper.GetPrograms(faculty.Id);
                                foreach (var program in programs)
                                {
                                    var years = helper.GetYears(program.Id);
                                    //var subyears = helper.ListSubYears(yearId);
                                    foreach (var year in years)
                                    {
                                        var subyears = helper.ListSubYears(year.Id);
                                        if (subyears.Count > 0 && sessionId == 0)// != sessions.Count)
                                        {
                                            //return with error// since semester can't be matched with fall or spring session
                                            //i.e. either no session then we need to add year only
                                            return;
                                        }
                                        GetClasses(academicYearId, year.Id, subyears
                                            , sessionId, ref classes, subyearPosition);
                                        //for (var i = 0; i < subyears.Count; i++)
                                        //{
                                        //    var ent = new Academic.DbEntities.Activities.ActiveClassesInAcademicYear()
                                        //    {
                                        //        AcademicYearId = academicYearId
                                        //        ,
                                        //        SessionId = sessions[i].Id
                                        //        ,
                                        //        YearId = year.Id
                                        //        ,
                                        //        SubYearId = subyears[i].Id

                                        //    };
                                        //    classes.Add(ent);
                                        //}
                                    }

                                }
                            }
                        }
                    }
                }

                //add all the classes for this academic year to the database 
                using (var helper = new DbHelper.AcademicPlacement())
                {
                    bool saved = helper.AddOrUpdateRunningClass(classes);
                    if (saved)
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, DbHelper.StaticValues.SuccessSaveMessageEventArgs);
                        }
                        else
                        {
                            OnSaveClicked(this, DbHelper.StaticValues.ErrorSaveMessageEventArgs);
                        }
                    }
                }
            }
        }

        //function to populate classes in list
        public void GetClasses(int academicYearId, int yearId
            , List<Academic.DbEntities.Structure.SubYear> subyears
            , int sessionId
             , ref List<Academic.DbEntities.AcacemicPlacements.RunningClass> classes
            , int subyearPosition)
        {
            //for (var i = 0; i < subyears.Count; i++)
            {
                var ent = new Academic.DbEntities.AcacemicPlacements.RunningClass()
                {
                    AcademicYearId = academicYearId

                    ,
                    YearId = yearId


                };
                if (sessionId > 0)
                {
                    ent.SessionId = sessionId;
                }
                if (subyears.Count > 0)
                {
                    ent.SubYearId = subyears[subyearPosition - 1].Id;
                }
                //if (subyearId > 0)
                //{
                //    ent.SubYearId = subyearId;
                //}
                classes.Add(ent);
            }
        }

        protected void txtSubYearPosition_TextChanged(object sender, EventArgs e)
        {
            var max = Convert.ToInt32(hidMaxSubYear.Value);
            Page.Validate();
            if (Page.IsValid)
            {
                if (!string.IsNullOrEmpty(txtSubYearPosition.Text))
                {
                    var val = Convert.ToInt32(txtSubYearPosition.Text);
                    if (val > max)
                    {
                        valiPostion.ErrorMessage = "There are no years with " + val.ToString() + " sub-years.";
                        valiPostion.IsValid = false;
                    }
                }
            }
            else
            {
                valiPostion.ErrorMessage = "Please fill other data first.";
                valiPostion.IsValid = false;
                txtSubYearPosition.Text = "";
            }
        }



    }
}