using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Course.CourseGroup
{
    public partial class GroupUc : System.Web.UI.UserControl
    {
        //events
        public event EventHandler<MessageEventArgs> SaveClicked;
        public event EventHandler<MessageEventArgs> CancelClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        public int SubjectGroupId
        {
            get { return Convert.ToInt32(hidSubjectGroupId.Value); }
            set { hidSubjectGroupId.Value = value.ToString(); }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }
        public int LevelId
        {
            get { return Convert.ToInt32(hidLevelId.Value); }
            set { hidLevelId.Value = value.ToString(); }
        }

        public int FacultyId
        {
            get { return Convert.ToInt32(hidFacultyId.Value); }
            set { hidFacultyId.Value = value.ToString(); }
        }

        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgramId.Value); }
            set { hidProgramId.Value = value.ToString(); }
        }

        public int YearId
        {
            get { return Convert.ToInt32(cmbYear.SelectedValue); }
            //set { cmbYear.SelectedValue = value.ToString(); }
        }
        public int SubYearId { get; set; }

        #endregion


        #region Events

        protected void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFaculty();
        }

        protected void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProgram();

        }

        protected void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadYear();
        }

        protected void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubYear();
            txtName.Text = cmbProgram.SelectedItem.Text + "-" + cmbYear.SelectedItem.Text;
        }
        protected void cmbSubYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = cmbProgram.SelectedItem.Text + "-" + cmbYear.SelectedItem.Text+"/"+cmbSubYear.SelectedItem.Text;            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            if (CancelClicked != null)
            {
                CancelClicked(this, StaticValues.CancelClickedMessageEventArgs);
            }
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            ResetControls();
            if (CancelClicked != null)
            {
                CancelClicked(this, StaticValues.CancelClickedMessageEventArgs);
            }
        }


        #endregion


        #region Load Functions

        private void LoadLevel()
        {
            DbHelper.ComboLoader.LoadLevelWithFirstElementSelected(ref cmbLevel
                , Values.Session.GetSchool(Session), LevelId);
            //LoadFaculty();
        }

        private void LoadFaculty()
        {
            DbHelper.ComboLoader.LoadFacultyWithFirstElementSelected(ref cmbFaculty
                , Convert.ToInt32(cmbLevel.SelectedValue), FacultyId);
            //LoadProgram();
        }

        private void LoadProgram()
        {
            DbHelper.ComboLoader.LoadProgramWithEmptyAsFirstElement(ref cmbProgram,
                Convert.ToInt32(cmbFaculty.SelectedValue), ProgramId);
            LoadYear();
        }

        private void LoadYear()
        {
            DbHelper.ComboLoader.LoadYear(ref cmbYear, Convert.ToInt32(cmbProgram.SelectedValue), true);
            LoadSubYear();
        }

        private void LoadSubYear()
        {
            DbHelper.ComboLoader.LoadSubYear(ref cmbSubYear, Convert.ToInt32(cmbYear.SelectedValue), true);
        }

        public void LoadData(int programId)
        {
            using (var helper = new DbHelper.Structure())
            {
                var prog = helper.GetProgram(programId);
                if (prog != null)
                {
                    cmbLevel.Enabled = false;
                    cmbFaculty.Enabled = false;
                    cmbProgram.Enabled = false;
                    SchoolId = prog.Faculty.Level.SchoolId;
                    LevelId = prog.Faculty.LevelId;
                    LoadLevel();

                    FacultyId = prog.FacultyId;
                    LoadFaculty();

                    ProgramId = prog.Id;
                    LoadProgram();
                    
                    
                    //var levelindex = cmbLevel.Items.IndexOf(cmbLevel.Items.FindByValue(prog.Faculty.Level.Id.ToString()) ?? new ListItem("", "0"));
                    //if (levelindex >= 0)
                    //{
                    //    cmbLevel.SelectedIndex = levelindex;
                    //}
                    //var facultyIndex = cmbFaculty.Items.IndexOf(cmbFaculty.Items.FindByValue(prog.Faculty.Id.ToString()) ?? new ListItem("", "0"));
                    //if (facultyIndex >= 0)
                    //{
                    //    cmbFaculty.SelectedIndex = facultyIndex;
                    //}

                }
            }
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbYear.SelectedValue) || cmbYear.SelectedValue == "0")
            {
                valiCmbYear.IsValid = false;
            }
            if (Page.IsValid)
            {

                using (var helper = new DbHelper.Subject())
                {
                    var subGrp = new Academic.DbEntities.Subjects.SubjectGroup()
                    {
                        Id=SubjectGroupId
                        ,
                        Name = txtName.Text
                        ,
                        Desctiption = txtDescription.Text
                        ,
                        CreatedDate = DateTime.Now
                        ,
                        ProgramId = ProgramId
                        ,
                        YearId = Convert.ToInt32(cmbYear.SelectedValue)
                    };
                    if (!string.IsNullOrEmpty(cmbSubYear.SelectedValue) && cmbSubYear.SelectedValue != "0")
                        subGrp.SubYearId = Convert.ToInt32(cmbSubYear.SelectedValue);
                    else
                        subGrp.SubYearId = null;

                    var saved = helper.AddOrUpdateSubjectGroup(subGrp);
                    if (saved != null)
                    {
                        //var s = Page.PreviousPage.Request.QueryString["Id"];
                        //Response.Redirect("~/Views/Course/ListingMain/CourseMain/ListSubjectGroup.aspx");
                        if (SaveClicked != null)
                        {
                            SaveClicked(this, StaticValues.SuccessSaveMessageEventArgs);
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Couldn'tSave";
                    }
                }
            }
        }

        public void ResetControls()
        {
            txtName.Text = "";
            txtDescription.Text = "";
        }

     

        

        
    }
}