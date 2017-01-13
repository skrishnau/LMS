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
            var user = Page.User as CustomPrincipal;
            if (user != null && (user.IsInRole("manager")
                                  || user.IsInRole(DbHelper.StaticValues.Roles.Grader)
                                  || user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor)))
            {
                if (!IsPostBack)
                {
                    GradeTypeUc1.SetValues(new List<GradeViewModel>());
                    GradeTypeUc1.ValuesPanelVisibility = true;
                    var gradeId = Request.QueryString["gId"];
                    if (gradeId != null)
                    {
                        using (var helper = new DbHelper.Grade())
                            try
                            {
                                var gId = Convert.ToInt32(gradeId);
                                GradeId = gId;
                                var grade = helper.GetGrade(gId);
                                if (grade != null)
                                {
                                    if (grade.SchoolId == user.SchoolId)
                                    {
                                        txtName.Text = grade.Name;
                                        txtDescription.Text = grade.Description;
                                        GradeTypeUc1.SelectedType = grade.RangeOrValue ? 1 : 0;
                                        GradeTypeUc1.ValuesPanelVisibility = grade.RangeOrValue;

                                        #region VAlues

                                        GradeTypeUc1.GradeValueIsInPercentOrPostition =
                                                grade.GradeValueIsInPercentOrPostition ?? false;
                                        var lst = new List<GradeViewModel>();
                                        var i = 1;
                                        foreach (var v in grade.GradeValues.Where(x => !(x.Void ?? false)).ToList())
                                        {
                                            lst.Add(new GradeViewModel()
                                            {
                                                Value = v.Value,
                                                Equivalent = (v.EquivalentPercentOrPostition ?? 0)
                                                ,
                                                Fail = v.IsFailGrade ?? false
                                                ,
                                                GradeValueId = v.Id
                                                ,
                                                Void = false
                                                ,
                                                LocalId = i
                                            });
                                            i++;
                                        }
                                        GradeTypeUc1.SetValues(lst);

                                        #endregion

                                        #region Range

                                        GradeTypeUc1.TotalMaxValue = (grade.TotalMaxValue ?? 0);
                                        GradeTypeUc1.TotalMinValue = grade.TotalMinValue ?? 0;
                                        GradeTypeUc1.MinimumPassValue = grade.MinimumPassValue ?? 0;

                                        #endregion

                                        //if (grade.RangeOrValue) //values
                                        //{
                                        //}
                                        //else //range
                                        //{
                                        //    GradeTypeUc1.RangePanelVisibility = true;
                                        //}
                                    }
                                    else Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                                }
                                else Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                            }
                            catch
                            {
                                Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                            }
                    }
                    //else
                    //{
                    //    GradeTypeUc1.SetValues(new List<GradeViewModel>());
                    //}
                    //divValues.Visible = false;
                    //var key = Guid.NewGuid().ToString();
                    //hidPageKey.Value = key;

                    //ViewState["values"] = new List<int>();
                }
            }
            else Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");


        }

        public void btnSave_OnClick(object sender, EventArgs args)
        {
            try
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                    using (var helper = new DbHelper.Grade())
                    {
                        var rangeOrValue = GradeTypeUc1.SelectedType == 1;
                        var grade = new Academic.DbEntities.Grades.Grade()
                        {
                            Id = GradeId,
                            Description = txtDescription.Text
                            ,
                            Name = txtName.Text
                            ,
                            //Type = (selectedType == 1) //? "Range" : "Values"
                            //,
                            SchoolId = user.SchoolId
                            ,
                            RangeOrValue = rangeOrValue
                        };
                        //grade.RangeOrValue = selectedType == 1;//false;

                        grade.TotalMaxValue = GradeTypeUc1.TotalMaxValue;
                        grade.TotalMinValue = GradeTypeUc1.TotalMinValue;
                        grade.MinimumPassValue = GradeTypeUc1.MinimumPassValue;


                        #region VAlues

                        var listOfValues = GradeTypeUc1.GetGradeValues();
                        if (listOfValues == null)
                        {
                            lblError.Text = "Input Error.";
                            lblError.Visible = true;
                            return;
                        }

                        if (!GradeTypeUc1.IsValid)
                        {
                            lblError.Visible = true;
                            return;
                        }


                        grade.GradeValueIsInPercentOrPostition = GradeTypeUc1.GradeValueIsInPercentOrPostition;
                        var saved = helper.AddOrUpdateGrade(grade, listOfValues);
                        if (saved != null)
                        {
                            Response.Redirect("~/Views/Grade/GradeListing.aspx?edit=1");
                        }
                        else
                        {
                            lblError.Visible = true;
                        }

                        #endregion


                        //if (selectedType == 0)//Range
                        //{

                        //    var saved = helper.AddOrUpdateGrade(grade, null);
                        //    if (saved != null)
                        //    {
                        //        Response.Redirect("~/Views/Grade/GradeListing.aspx?edit=1");
                        //    }
                        //    else
                        //    {
                        //        lblError.Visible = true;
                        //    }
                        //}
                        //else//Values
                        //{
                        //    //grade.RangeOrValue = true;


                        //}
                    }
            }
            catch { }
        }

        public int GradeId
        {
            get { return Convert.ToInt32(hidId.Value); }
            set
            {
                hidId.Value = value.ToString();
                GradeTypeUc1.GradeId = value;
            }
        }


        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Grade/GradeListing.aspx?edit=1");
        }
    }
}