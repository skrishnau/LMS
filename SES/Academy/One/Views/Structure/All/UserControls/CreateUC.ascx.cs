using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Structure.All.UserControls
{
    public partial class CreateUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLevel();
                //DbHelper.ComboLoader.LoadLevel(ref cmbLevels, SchoolId, true);//Values.Session.GetSchool(Session)
                //pnlLevelCreate.Visible = false;
                //LevelCreate.SchoolId = SchoolId; //Values.Session.GetSchool(Session);
            }
            //Create uc = (Create)Page.LoadControl("Create.ascx");
            //uc.ID = "LevelCreate";
            //PlaceHolder1.Controls.Add(uc);

            //var create = new Role.Create();
            //create.InitializeAsUserControl(this);
            //pnlCreate.Controls.Add(create);
            LevelCreate.SaveClickedEvent += LevelCreate_SaveClicked;
            FacultyCreateUC.OnSaveClicked += FacultyCreateUC_OnSaveClicked;
            ProgramCreateUC.OnSaveClicked+=ProgramCreateUC_OnSaveClicked;
            YearCreateUC.OnSaveClicked+=YearCreateUC_OnSaveClicked;
            SubYearCreateUC.OnSaveClicked += SubYearCreateUC_OnSaveClicked;
        }


        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(this.hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        //public TYPE Type { get; set; }

        #endregion


        #region Save events of userControls

        void LevelCreate_SaveClicked(object sender, MessageEventArgs e)
        {
            if (e.TrueFalse)
            {
                pnlLevelCreate.Visible = false;
                LoadLevel();
            }
            lblMessage.Text = e.Message;
        }

       

        void FacultyCreateUC_OnSaveClicked(object sender, MessageEventArgs e)
        {
            if (e.TrueFalse)
            {
                pnlFacultyCreate.Visible = false;
                LoadFaculties();
            }
            lblMessage.Text = e.Message;
        }
        
        private void ProgramCreateUC_OnSaveClicked(object sender, MessageEventArgs e)
        {
            if (e.TrueFalse)
            {
                pnlProgramCreate.Visible = false;
                LoadPrograms();
            }
            lblMessage.Text = e.Message;
        }
        
        private void YearCreateUC_OnSaveClicked(object sender, MessageEventArgs e)
        {
            if (e.TrueFalse)
            {
                pnlYearCreate.Visible = false;
                LoadYears();
            }
            lblMessage.Text = e.Message;

        }
        
        private void SubYearCreateUC_OnSaveClicked(object sender, MessageEventArgs e)
        {
            if (e.TrueFalse)
            {
                pnlSubYearCreate.Visible = false;
                LoadSubYears();
            }
            lblMessage.Text = e.Message;
        }

        #endregion

       

        #region Combo Index Changed Functions

        protected void cmbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLevels.SelectedValue != "" && cmbLevels.SelectedValue != "0")
            {
                LevelBelowHierarchyAllInvisible(null, false, true);
                LoadFaculties();
            }
            else
            {
                LevelBelowHierarchyAllInvisible(true);
            }
        }

        protected void cmbFaculties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFaculties.SelectedValue != "" && cmbFaculties.SelectedValue != "0")
            {
                FacultyAndBelowHierarchyAllInvisible(null, false, true);
                LoadPrograms();
            }
            else
            {
                FacultyAndBelowHierarchyAllInvisible(true);
            }
        }

        protected void cmbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPrograms.SelectedValue != "" && cmbPrograms.SelectedValue != "0")
            {
                ProgramAndBelowHierarchyAllInvisible(null, false, true);
                LoadYears();
            }
            else
            {
                ProgramAndBelowHierarchyAllInvisible(true);
            }

        }

        protected void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.SelectedValue != "" && cmbYear.SelectedValue != "0")
            {
                YearAndBelowHierarchyAllInvisible(null, false, true);
                //pnlSubYearAll.Visible = true;
                LoadSubYears();
            }
            else
            {
                YearAndBelowHierarchyAllInvisible(true);
            }
        }


        #endregion


        #region Load Functions

        private void LoadLevel()
        {
            DbHelper.ComboLoader.LoadLevel(ref cmbLevels, SchoolId, true);//Values.Session.GetSchool(Session)
            pnlLevelCreate.Visible = false;
            LevelCreate.SchoolId = SchoolId; 
        }

        private void LoadFaculties()
        {
            DbHelper.ComboLoader.LoadFaculty(ref cmbFaculties
                , Convert.ToInt32(cmbLevels.SelectedValue)
                ,true);
            FacultyCreateUC.SchoolId = SchoolId;
            FacultyCreateUC.LevelId = Convert.ToInt32(cmbLevels.SelectedValue);
        }

        private void LoadPrograms()
        {
            DbHelper.ComboLoader.LoadProgram(ref cmbPrograms
                , Convert.ToInt32(cmbFaculties.SelectedValue)
                ,true);
            //DbHelper.ComboLoader.LoadFaculty(ref cmbFaculties, Convert.ToInt32(cmbLevels.SelectedValue));
            ProgramCreateUC.SchoolId = SchoolId;
            ProgramCreateUC.LevelId = Convert.ToInt32(cmbLevels.SelectedValue);
            ProgramCreateUC.FacultyId = Convert.ToInt32(cmbFaculties.SelectedValue);
        }

        private void LoadYears()
        {
            DbHelper.ComboLoader.LoadYear(ref cmbYear
                , Convert.ToInt32(cmbFaculties.SelectedValue)
                ,true);
            //DbHelper.ComboLoader.LoadFaculty(ref cmbFaculties, Convert.ToInt32(cmbLevels.SelectedValue));
            YearCreateUC.SchoolId = SchoolId;
            YearCreateUC.LevelId = Convert.ToInt32(cmbLevels.SelectedValue);
            YearCreateUC.FacultyId = Convert.ToInt32(cmbFaculties.SelectedValue);
            YearCreateUC.ProgramId = Convert.ToInt32(cmbPrograms.SelectedValue);
        }

        private void LoadSubYears()
        {
            DbHelper.ComboLoader.LoadSubYear(ref cmbSubYear
                , Convert.ToInt32(cmbYear.SelectedValue)
                ,true);
            SubYearCreateUC.SchoolId = SchoolId;
            SubYearCreateUC.LevelId = Convert.ToInt32(cmbLevels.SelectedValue);
            SubYearCreateUC.FacultyId = Convert.ToInt32(cmbFaculties.SelectedValue);
            SubYearCreateUC.ProgramId = Convert.ToInt32(cmbPrograms.SelectedValue);
            SubYearCreateUC.YearId = Convert.ToInt32(cmbYear.SelectedValue);
        }

        #endregion

        //=======================
        #region MyRegion

        public void MakeAllInvisible()
        {

        }

        #endregion
        //============================

        #region Visiblity Functions

        void LevelBelowHierarchyAllInvisible(bool? currentVisible = false, bool? currentCreateVisible = null
            , bool? belowVisible = false)
        {
            if (currentVisible != null)
                pnlLevels.Visible = currentVisible ?? false;

            if (currentCreateVisible != null)
                pnlLevelCreate.Visible = currentCreateVisible ?? false;


            FacultyAndBelowHierarchyAllInvisible(belowVisible, false);

            //ProgramAndBelowHierarchyAllInvisible();
            //YearAndBelowHierarchyAllInvisible();
        }

        void FacultyAndBelowHierarchyAllInvisible(bool? currentVisible = false, bool? currentCreateVisible = null
            , bool? belowVisible = false)
        {
            if (currentVisible != null)
                pnlFacultyAll.Visible = currentVisible ?? false;

            if (currentCreateVisible != null)
                pnlFacultyCreate.Visible = currentCreateVisible ?? false;

            ProgramAndBelowHierarchyAllInvisible(belowVisible, false);
            //YearAndBelowHierarchyAllInvisible();
        }

        void ProgramAndBelowHierarchyAllInvisible(bool? currentVisible = false, bool? currentCreateVisible = null
            , bool? belowVisible = false)
        {
            if (currentVisible != null)
                pnlProgramAll.Visible = currentVisible ?? false;
            if (currentCreateVisible != null)
                pnlProgramCreate.Visible = currentCreateVisible ?? false;

            YearAndBelowHierarchyAllInvisible(belowVisible, false);
        }

        void YearAndBelowHierarchyAllInvisible(bool? currentVisible = false, bool? currentCreateVisible = null
            , bool? belowVisible = false)
        {
            if (currentVisible != null)
                pnlYearAll.Visible = currentVisible ?? false;
            if (currentCreateVisible != null)
                pnlYearCreate.Visible = currentCreateVisible ?? false;

            SubYearAndBelowHierarchyAllInvisible(belowVisible, false);
        }

        void SubYearAndBelowHierarchyAllInvisible(bool? currentVisible = false, bool? currentCreateVisible = null)
        {
            if (currentVisible != null)
                pnlSubYearAll.Visible = currentVisible ?? false;
            if (currentCreateVisible != null)
                pnlSubYearCreate.Visible = currentCreateVisible ?? false;
        }

        #endregion

        #region Image Button Click

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            pnlLevelCreate.Visible = true;
            //LevelCreate uc = (LevelCreate)Page.LoadControl("Create.ascx");
            //uc.ID = "LevelCreate";
            //pnlLevelCreate.Controls.Add(uc);
        }

        protected void imgLevel_Click(object sender, ImageClickEventArgs e)
        {
            pnlLevelCreate.Visible = !pnlLevelCreate.Visible;

            //pnlFacultyAll.Visible = false;
            //pnlProgramAll.Visible = false;
            //pnlYearAll.Visible = false;
            //pnlSubYearAll.Visible = false;
            if (cmbLevels.SelectedIndex > 0)
            {
                cmbLevels.SelectedIndex = 0;
                cmbLevels_SelectedIndexChanged(new object(), new EventArgs());
            }
        }

        protected void imgFac_Click(object sender, ImageClickEventArgs e)
        {

            pnlFacultyCreate.Visible = !pnlFacultyCreate.Visible;

            //pnlProgramAll.Visible = false;
            //pnlYearAll.Visible = false;
            //pnlSubYearAll.Visible = false;
            if (cmbFaculties.Items.Count > 0)
            {
                cmbFaculties.SelectedIndex = 0;
                cmbFaculties_SelectedIndexChanged(new object(), new EventArgs());
            }

        }

        protected void imgProg_Click(object sender, ImageClickEventArgs e)
        {
            //pnlLevelCreate.Visible = false;
            //pnlFacultyCreate.Visible = false;

            pnlProgramCreate.Visible =!pnlProgramCreate.Visible;

            //pnlYearAll.Visible = false;
            //pnlSubYearAll.Visible = false;
            if (cmbPrograms.Items.Count > 0)
            {
                cmbPrograms.SelectedIndex = 0;
                cmbPrograms_SelectedIndexChanged(null,null);
            }
        }

        protected void imgYear_Click(object sender, ImageClickEventArgs e)
        {
            //pnlLevelCreate.Visible = false;
            //pnlFacultyCreate.Visible = false;
            //pnlProgramCreate.Visible = false;

            pnlYearCreate.Visible = !pnlYearCreate.Visible;

            //pnlSubYearAll.Visible = false;
            if (cmbYear.Items.Count > 0)
            {
                cmbYear.SelectedIndex = 0;
                cmbYear_SelectedIndexChanged(null,null);                
            }
        }

        protected void imgSubYear_Click(object sender, ImageClickEventArgs e)
        {
            //pnlLevelCreate.Visible = false;
            //pnlFacultyCreate.Visible = false;
            //pnlProgramCreate.Visible = false;
            //pnlYearCreate.Visible = false;

            pnlSubYearCreate.Visible = !pnlSubYearCreate.Visible;

            if (cmbSubYear.Items.Count > 0)
            {
                cmbSubYear.SelectedIndex = 0;
            }
        }


        #endregion




















    }
}