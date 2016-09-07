using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.InitialValues;
using Academic.ViewModel;

namespace One.Views.Exam
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSchool();
            }
        }

        private void LoadSchool()
        {
            cmbSchool.DataTextField = "Name";
            cmbSchool.DataValueField = "Id";
            using (var helper = new DbHelper.Office())
            {
                var schools = helper.GetSchoolForCombo(InitialValues.CustomSession["InstitutionId"]);
                if(schools.Count>0)
                    schools.Insert(0, new IdAndName() { Id = 0, Name = "--Select One--" });
                cmbSchool.DataSource = schools;
                cmbSchool.DataBind();
            }
        }
        private void LoadCoordinator()
        {
            cmbCoordinator.DataTextField = "Name";
            cmbCoordinator.DataValueField = "Id";
            using (var helper = new DbHelper.Staff())
            {
                var co = helper.GetEmployeesOfExamDivisionForCombo(Values.Session.GetSchool(Session));
                if(co.Count>0)
                co.Insert(0, new Academic.DbEntities.User.Users() { Id = 0, FirstName = "--Select One--" });
                cmbCoordinator.DataSource = co;
                cmbCoordinator.DataBind();
            }
        }

        private void LoadExamType()
        {
            cmbExamType.DataTextField = "Name";
            cmbExamType.DataValueField = "Id";
            using (var helper = new DbHelper.Exam())
            {
                var ex = helper.GetExamTypeForCombo(Values.Session.GetSchool(Session));
                ex.Insert(0, new Academic.DbEntities.Exams.ExamType() { Id = 0, Name = "--Select One--" });
                cmbExamType.DataSource = ex;
                cmbExamType.DataBind();
            }
        }
        private void LoadLevel()
        {
            cmbLevel.DataTextField = "Name";
            cmbLevel.DataValueField = "Id";
            using (var helper = new DbHelper.Structure())
            {
                var lev = helper.GetLevels(InitialValues.CustomSession["SchoolId"]);
                if(lev.Count>0)
                lev.Insert(0, new IdAndName() { Id = 0, Name = "--All--" });
                cmbLevel.DataSource = lev;
                cmbLevel.DataBind();
            }
        }
        private void LoadFaculty()
        {
            cmbFaculty.DataTextField = "Name";
            cmbFaculty.DataValueField = "Id";
            int levelId = Convert.ToInt32((
                cmbLevel.SelectedValue.ToString()=="")?"0":cmbLevel.SelectedValue.ToString());
            using (var helper = new DbHelper.Structure())
            {
                var fac = helper.GetFaculties(levelId);
                if(fac.Count>0)
                fac.Insert(0, new IdAndName() { Id = 0, Name = "--All--" });
                cmbFaculty.DataSource = fac;
                cmbFaculty.DataBind();
            }
        }
        private void LoadProgram()
        {
            cmbProgram.DataTextField = "Name";
            cmbProgram.DataValueField = "Id";
            int facId = Convert.ToInt32((
                cmbFaculty.SelectedValue.ToString() == "") ? "0" : cmbFaculty.SelectedValue.ToString());
            using (var helper = new DbHelper.Structure())
            {
                var fac = helper.GetPrograms(facId);
                if(fac.Count>0)
                fac.Insert(0, new IdAndName() { Id = 0, Name = "--All--" });
                cmbProgram.DataSource = fac;
                cmbProgram.DataBind();
            }
        }
        private void LoadYear()
        {
            cmbYear.DataTextField = "Name";
            cmbYear.DataValueField = "Id";
            int proId = Convert.ToInt32((
                cmbProgram.SelectedValue.ToString() == "") ? "0" : cmbProgram.SelectedValue.ToString());
            using (var helper = new DbHelper.Structure())
            {
                var yea = helper.GetYears(proId);
                if(yea.Count>0)
                yea.Insert(0, new IdAndName() { Id = 0, Name = "--All--" });
                cmbYear.DataSource = yea;
                cmbYear.DataBind();
            }
        }

        public string ShowCalendarButtonText
        {
            //get { return this.btnSave.Text; }
            set { this.btnSave.Text = value; }
        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (btnSave.Text.StartsWith("S"))
        //    {
        //        //hide
        //        btnSave.Text = "Hide Date Chooser";
        //        //ShowCalendarButtonText = "Hide Date Chooser";
        //        //this.Calendar1.Visible = true;
        //    }
        //    else
        //    {
        //        //show
        //        btnSave.Text = "Show Date Chooser";
        //        //ShowCalendarButtonText = "Hide Date Chooser";
        //        //this.Calendar1.Visible = false;
        //    }
        //}

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlChkLst.Visible = false;
            chkList.DataTextField = "Name";
            chkList.DataValueField = "Id";
            using (var helper = new DbHelper.Subject())
            {
                var subjects = helper.ListSubjectsOfYearForCombo(Convert.ToInt32(cmbYear.SelectedValue));
                if(subjects.Count>0)
                    pnlChkLst.Visible = true;
                chkList.DataSource = subjects;
                chkList.DataBind();
            }
            //chkList.DataSource = new List<string>() { "  C", "  DSA", "  MSI", "  OOSE" };
            //chkList.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDate1.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var schoolId = Convert.ToInt32(cmbSchool.SelectedValue);
            var coordinatorId = Convert.ToInt32(cmbCoordinator.SelectedValue);
            var examType = Convert.ToInt32(cmbExamType.SelectedValue);
            var dateofExam = Convert.ToDateTime(txtDate1.Text);
            var Level = Convert.ToInt32(cmbLevel.Text);
            var Faculty = Convert.ToInt32(cmbFaculty.Text);
            var program = Convert.ToInt32(cmbProgram.Text);
            var year = Convert.ToInt32(cmbYear.Text);

            //var subjects = chkList.
        }

        protected void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlChkLst.Visible = false;
            chkSelectAll.Checked = false;
            //next version
            //alert message
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('The List of subjects will be reset.')", true);
            //if (GridView1.Rows.Count > 0)
            //{
            //    return;
            //}
            
            LoadCoordinator();
            LoadExamType();
            LoadLevel();
            LoadFaculty();
            LoadProgram();
            LoadYear();
        }

        protected void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlChkLst.Visible = false;
            chkSelectAll.Checked = false;
            cmbProgram.DataSource = null;
            cmbYear.DataSource = null;
            LoadFaculty();
            LoadProgram();
            LoadYear();
        }

        protected void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlChkLst.Visible = false;
            chkSelectAll.Checked = false;
            cmbYear.DataSource = null;
            LoadProgram();
            LoadYear();
        }

        protected void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlChkLst.Visible = false;
            chkSelectAll.Checked = false;
            LoadYear();
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                foreach (ListItem item in chkList.Items)
                {
                    item.Selected = true;
                }
            }
            else
            {
                foreach (ListItem item in chkList.Items)
                {
                    item.Selected = false;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddToList_Click(object sender, EventArgs e)
        {
            //add the subjects to list
            if (cmbYear.SelectedValue != null || cmbYear.SelectedValue != "" || cmbYear.SelectedValue != "0")
            {
                //select all selected subjects
                foreach(var sub in chkList.Items)
                {
                    
                }
            }
            else
            {
                
            }
        }

        protected void btnSaveExam_Click(object sender, EventArgs e)
        {
            valiCoor.Visible = false;
            valiSchool.Visible = false;
            valiType.Visible = false;

            if (Page.IsValid)
            {
                var cor = cmbCoordinator.SelectedValue;
                if (cor == "")
                {
                    valiCoor.Visible = true;
                    valiCoor.Text = "Coordinator is required.";
                    return;
                }
                var sch = cmbSchool.SelectedValue;
                if (sch == "")
                {
                    valiSchool.Visible = false;
                    valiSchool.Text = "School is required.";
                    return;
                }
                var typ = cmbExamType.SelectedValue;
                if (typ == "")
                {
                    valiType.Visible = false;
                    valiType.Text = "Type is required";
                    return;
                }
                var exam = new Academic.DbEntities.Exams.Exam()
                {
                    AcademicYearId = InitialValues.CustomSession["AcademicYearId"]
                    ,ExamCoordinatorId = Convert.ToInt32(cor)
                    ,
                    StartDate = Convert.ToDateTime(txtDate1.Text)
                    ,ExamTypeId =  Convert.ToInt32(typ)
                    ,Name = txtName.Text
                    ,Weight = (float)Convert.ToDecimal( txtWeight.Text)
                };
                using (var helper = new DbHelper.Exam())
                {
                    var saved = helper.AddOrUpdateExam(exam);
                    if (saved!=null)
                    {
                        pnlExam.Enabled = false;
                    }
                }
            }
        }

    }
}