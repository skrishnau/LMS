using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Grade
{
    public partial class GradeDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrade();
            }
        }

        private void LoadGrade()
        {
            var user = Page.User as CustomPrincipal;
            var gradeId = Request.QueryString["gId"];
            if (user != null)
                if (gradeId != null)
                {
                    using (var helper = new DbHelper.Grade())
                    {
                        var grade = helper.GetGrade(Convert.ToInt32(gradeId));
                        if (grade != null)
                        {
                            if ((grade.SchoolId ?? 0) == 0 || (grade.SchoolId ?? 0) == user.SchoolId)
                            {

                                lblHeading.Text = grade.Name;
                                lblDescription.Text = grade.Description;
                                lblGradeType.Text = grade.RangeOrValue ? "Value" : "Range";
                                if (grade.RangeOrValue) //value
                                {
                                    rowEquivalentPercentOrPosition.Visible = true;
                                    pnlValues.Visible = true;
                                    var isInPercent = (grade.GradeValueIsInPercentOrPostition ?? false);

                                    lblPercentOrPosition.Text = isInPercent
                                        ? " percent (%)"
                                        : " position";

                                    IsInPercentOrPosition = isInPercent;
                                    //grade.GradeValues.Where(x=>x.EquivalentPercentOrPostition)
                                    ListView1.DataSource = grade.GradeValues.Where(x=>!(x.Void??false)).ToList();
                                    ListView1.DataBind();
                                }
                                else //range
                                {
                                    rowMaximumValue.Visible = true;
                                    rowMinimumValue.Visible = true;
                                    rowMinPassValue.Visible = true;

                                    lblMaximumValue.Text = (grade.TotalMaxValue ?? 0).ToString("F");
                                    lblMinimumValue.Text = (grade.TotalMinValue ?? 0).ToString("F");
                                    lblMinPassValue.Text = (grade.MinimumPassValue ?? 0).ToString("F");


                                }
                            }
                            else
                            {
                                Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                }
        }

        /// <summary>
        /// True: percent, False: position
        /// </summary>
        public bool IsInPercentOrPosition
        {
            get { return Convert.ToBoolean(hidPercentOrPosition.Value); }
            set { hidPercentOrPosition.Value = value.ToString(); }
        }


        public string GetEquivalent(object percentOrPosition, object isFailGrade)
        {
            var porp = IsInPercentOrPosition ? " %" : "";
            var fail = " (Fail)";
            if (percentOrPosition != null)
            {
                fail = "";
                if (isFailGrade != null)
                {
                    var isFail = Convert.ToBoolean(isFailGrade);
                    if (isFail)
                    {
                        fail = " (Fail)";
                    }
                    else fail = "";
                }

                return percentOrPosition + porp;
            }else return "0"+porp+fail;
        }
    }
}