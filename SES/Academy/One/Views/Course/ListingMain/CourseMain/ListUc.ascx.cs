using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Course.ListingMain.CourseMain
{
    public partial class ListUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLevel();
            }
            //GroupUc.SaveClicked += GroupUc_SaveClicked;
            //GroupUc.CancelClicked += GroupUc_CancelClicked;
            //LoadProgram();
            LoadSubjectGroups();
        }

        //works but not needed
        //void GroupUc_CancelClicked(object sender, Values.MessageEventArgs e)
        //{
        //    LoadSubjectGroups();
        //    MultiView1.ActiveViewIndex = 0;
        //}

        //void GroupUc_SaveClicked(object sender, Values.MessageEventArgs e)
        //{
        //    if (e.SaveSuccess)
        //    {
        //        LoadSubjectGroups();
        //        MultiView1.ActiveViewIndex = 0;
        //    }
        //}


        #region Events

        protected void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFaculty();
            pnlSubjectGroups.Controls.Clear();
        }

        protected void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //false stmt...//this call makes "call to LoadProgram() twice" since this is called from page_load
            LoadProgram();
            pnlSubjectGroups.Controls.Clear();

        }

        protected void cmbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadSubjectGroups();
        }

        protected void btnNewGroup_Click(object sender, EventArgs e)
        {
            //Context.Items.Add("ProgramId",cmbProgram.SelectedValue);
            MultiView1.ActiveViewIndex = 1;
            //Response.Redirect("~/Views/Course/ListingMain/CourseMain/NewGroup.aspx" + "?Id=" + cmbProgram.SelectedValue);
        }

        #endregion


        #region Load Functions

        private void LoadLevel()
        {
            //cmbLevel.ClearSelection();
            DbHelper.ComboLoader.LoadLevelWithFirstElementSelected(ref cmbLevel, Values.Session.GetSchool(Session));
            LoadFaculty();
        }

        private void LoadFaculty()
        {
            //cmbFaculty.ClearSelection();
            DbHelper.ComboLoader.LoadFacultyWithFirstElementSelected(ref cmbFaculty, Convert.ToInt32(cmbLevel.SelectedValue));
            LoadProgram();
        }

        private void LoadProgram()
        {
            //cmbProgram.ClearSelection();
            DbHelper.ComboLoader.LoadProgramWithEmptyAsFirstElement(ref cmbProgram,
                Convert.ToInt32(cmbFaculty.SelectedValue));
            
        }

        private void LoadSubjectGroups()
        {
            //pnlSubjectGroups.Controls.Clear();
            //GroupUc.LoadData(Convert.ToInt32(cmbProgram.SelectedValue == "" ? "0" : cmbProgram.SelectedValue));
            if (String.IsNullOrEmpty(cmbProgram.SelectedValue) || cmbProgram.SelectedValue == "0")
            {
                //btnNewGroup.Visible = true;
                MultiView1.ActiveViewIndex = 0;
            }
            //else
            //{
            //    btnNewGroup.Visible = false;
               
            //}
            using (var helper = new DbHelper.Subject())
            {
                var grps = helper.GetRegularSubjectGroups(Convert.ToInt32(cmbProgram.SelectedValue == "" ? "0" : cmbProgram.SelectedValue));//GetSubjectGroups
                foreach (var sg in grps)
                {
                    ListItemUc item =
                        (ListItemUc)Page.LoadControl("~/Views/Course/ListingMain/CourseMain/ListItemUc.ascx");
                    
                    var count = 0;//sg.SubjectGroupSubjects.Count(x => !(x.Void ?? false) && !(x.Subject.Void ?? false));
                    item.LoadData(sg.Id,sg.YearId??0,sg.SubYearId??0, sg.Name, sg.Desctiption, count);
                    pnlSubjectGroups.Controls.Add(item);
                }
                //}
            }
        }

        #endregion




    }
}