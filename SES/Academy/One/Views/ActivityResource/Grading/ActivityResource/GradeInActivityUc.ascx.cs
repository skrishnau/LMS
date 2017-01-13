using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.ActivityResource.Grading.ActivityResource
{
    public partial class GradeInActivityUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            valiWeightInGradeSheet.Visible = false;

        }
        public void LoadInitial(CustomPrincipal user)
        {
            if (user != null)
                using (var gradeHelper = new DbHelper.Grade())
                {
                    var gradelist = gradeHelper.ListGrades(user.SchoolId);
                    ddlGradeType.DataSource = gradelist;
                    ddlGradeType.DataBind();

                    if (AssignmentId <= 0)
                        if (gradelist.Any())
                        {
                            var grade = gradelist[0]; //gradeHelper.GetGrade(Convert.ToInt32(ddlGradeType.SelectedValue));
                            RangeOrValue = grade.RangeOrValue;
                            SetGradeValuesDataSource(grade);
                        }
                }
        }

        public void SetGradeValuesDataSource(Academic.DbEntities.Grades.Grade grade)
        {
            if (grade.RangeOrValue) //value
            {
                var gradeValues = grade.GradeValues
                    .OrderByDescending(x => x.EquivalentPercentOrPostition).ToList();

                ddlMaximumGrade.DataSource = gradeValues;
                ddlMaximumGrade.DataBind();

                ddlGradeToPass.DataSource = gradeValues;
                ddlGradeToPass.DataBind();
            }
            else//range
            {
                ddlGradeToPass.DataSource = null;
                ddlGradeToPass.DataBind();
                ddlMaximumGrade.DataSource = null;
                ddlMaximumGrade.DataBind();
            }
        }
        public int AssignmentId
        {
            get { return Convert.ToInt32(hidAssignmentId.Value); }
            set { hidAssignmentId.Value = value.ToString(); }
        }
        public bool RangeOrValue
        {
            set
            {
                if (!value)//range
                {
                    ddlMaximumGrade.Visible = false;
                    ddlGradeToPass.Visible = false;

                    txtGradeToPass.Visible = true;
                    txtMaxGradde.Visible = true;
                }
                else//values
                {
                    ddlMaximumGrade.Visible = true;
                    ddlGradeToPass.Visible = true;

                    txtGradeToPass.Visible = false;
                    txtMaxGradde.Visible = false;
                }
            }
        }

        protected void ddlGradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.Grade())
            {
                var grade = helper.GetGrade(Convert.ToInt32(ddlGradeType.SelectedValue));
                //if (txtMaxGradde != null)
                //{
                if (grade != null)
                {
                    RangeOrValue = grade.RangeOrValue;
                    SetGradeValuesDataSource(grade);
                }

                //if (!grade.RangeOrValue)//range
                //{
                //    ddlMaximumGrade.Visible = false;
                //    ddlGradeToPass.Visible = false;

                //    txtGradeToPass.Visible = true;
                //    txtMaxGradde.Visible = true;
                //}
                //else//values
                //{
                //    ddlMaximumGrade.Visible = true;
                //    ddlGradeToPass.Visible = true;

                //    txtGradeToPass.Visible = false;
                //    txtMaxGradde.Visible = false;

                //    var gradeValues = helper.ListGradeValues(grade.Id);
                //    ddlMaximumGrade.DataSource = gradeValues;
                //    ddlGradeToPass.DataSource = gradeValues;
                //    ddlMaximumGrade.DataBind();
                //    ddlGradeToPass.DataBind();
                //}
                //}

            }
        }


        public void SetGradeValues(Academic.DbEntities.ActivityAndResource.ActivityResource actRes
            , Academic.DbEntities.ActivityAndResource.Assignment ass)
        {
            ddlGradeType.SelectedValue = ass.GradeTypeId.ToString();
            RangeOrValue = ass.GradeType.RangeOrValue;
            txtWeightInGradeSheet.Text = (actRes.WeightInGradeSheet ?? 0).ToString("F");
            ddlShowGradeToStudents.SelectedIndex = ass.ShowGradeToStudents ? 1 : 0;

            if (!ass.GradeType.RangeOrValue) //== "Range"
            {
                txtGradeToPass.Text = ass.GradeToPass;
                txtMaxGradde.Text = ass.MaximumGrade;
            }
            else
            {
                //first populate initial 
                SetGradeValuesDataSource(ass.GradeType);

                ddlMaximumGrade.SelectedValue = ass.MaximumGrade;
                ddlGradeToPass.SelectedValue = ass.GradeToPass;
            }
        }

        public GradeInActResViewModel GetGrade()
        {

            if (string.IsNullOrEmpty(ddlGradeType.SelectedValue))
            {
                gradeListVali.IsValid = false;
                return null;
            }
            else if (ddlGradeType.SelectedValue != "0")
            {
                var grade = new GradeInActResViewModel()
                {
                    GradeTypeId = Convert.ToInt32(ddlGradeType.SelectedValue)
                    ,
                };

                //assg.GradeTypeId = Convert.ToInt32(ddlGradeType.SelectedValue);
                if (ddlMaximumGrade.Visible && ddlGradeToPass.Visible)
                {
                    grade.MaximumGradeInString = ddlMaximumGrade.SelectedValue;
                    grade.GradeToPassInString = ddlGradeToPass.SelectedValue;

                    //assg.MaximumGrade = ddlMaximumGrade.SelectedValue;
                    //assg.GradeToPass = ddlGradeToPass.SelectedValue;
                }
                else if (txtMaxGradde.Visible && txtGradeToPass.Visible)
                {
                    grade.MaximumGradeInString = txtMaxGradde.Text;
                    grade.GradeToPassInString = txtGradeToPass.Text;
                    //assg.MaximumGrade = txtMaxGradde.Text;
                    //assg.GradeToPass = txtGradeToPass.Text;
                }

                //weight;
                try
                {
                    if (!string.IsNullOrEmpty(txtWeightInGradeSheet.Text))
                    {
                        var weight = (float)0.0;
                        weight = (float)Convert.ToDecimal(txtWeightInGradeSheet.Text);
                        if (weight < 0 || weight > 100)
                        {
                            valiWeightInGradeSheet.Visible = true;
                            return null;
                        }
                        grade.WeightInGradeSheetInFloat = weight;
                    }
                }
                catch
                {
                    valiWeightInGradeSheet.Visible = true;
                    return null;
                }
                grade.ShowGradeToStudents = ddlShowGradeToStudents.SelectedIndex == 1;

                return grade;
            }
            return new GradeInActResViewModel();
        }
    }
}