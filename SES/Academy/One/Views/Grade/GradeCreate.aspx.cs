using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Grades;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Grade
{
    public partial class GradeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "Error while saving.";
            lblError.Visible = false;
            if (!IsPostBack)
            {
                //divValues.Visible = false;
                //var key = Guid.NewGuid().ToString();
                //hidPageKey.Value = key;

                //ViewState["values"] = new List<int>();
            }


        }

        public void btnSave_OnClick(object sender, EventArgs args)
        {
            try
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                    using (var helper = new DbHelper.Grade())
                    {
                        var selectedType = GradeTypeUc1.SelectedType;
                        var grade = new Academic.DbEntities.Grades.Grade()
                        {
                            Description = txtDescription.Text
                            ,
                            Name = txtName.Text
                            ,
                            Type = (selectedType == 0) ? "Range" : "Values"
                            ,
                            SchoolId = user.SchoolId
                        };
                        if (selectedType == 0)//Range
                        {
                            grade.TotalMaxValue = GradeTypeUc1.TotalMaxValue;
                            grade.TotalMinValue = GradeTypeUc1.TotalMinValue;
                            grade.MinimumPassValue = GradeTypeUc1.MinimumPassValue;
                            var saved = helper.AddOrUpdateGrade(grade, null);
                            if (saved != null)
                            {
                                Response.Redirect("~/Views/Grade/GradeListing.aspx");
                            }
                            else
                            {
                                lblError.Visible = true;
                            }
                        }
                        else//Values
                        {
                            var listOfValues = GradeTypeUc1.GetGradeValues();
                            if (listOfValues == null)
                            {
                                lblError.Text = "Input Error.";
                                lblError.Visible = true;
                                return;
                            }
                            grade.GradeValueIsInPercentOrPostition = GradeTypeUc1.GradeValueIsInPercentOrPostition;
                            var saved = helper.AddOrUpdateGrade(grade, listOfValues);
                            if (saved != null)
                            {
                                Response.Redirect("~/Views/Grade/GradeListing.aspx");
                            }
                            else
                            {
                                lblError.Visible = true;
                            }
                        }
                    }
            }
            catch { }
        }
        public int GradeId
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }



    }
}