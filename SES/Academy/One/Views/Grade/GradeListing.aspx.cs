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
    public partial class GradeListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;

            if (user != null)
            {
                if (!IsPostBack)
                {
                    var edit = Request.QueryString["edit"];
                    if (user.IsInRole("manager") || user.IsInRole("grader") || user.IsInRole("course-editor"))
                    {
                        if (edit != null)
                        {
                            if (edit == "1")
                            {
                                Edit = true;
                                hidTask.Value = DbHelper.StaticValues.Encode("grade");
                                lnkEdit.NavigateUrl = "~/Views/Grade/GradeListing.aspx?edit=0";
                                lblEdit.Text = "Exit edit";
                                lnkAddGrade.Visible = true;
                            }
                            else
                            {
                                lnkEdit.NavigateUrl = "~/Views/Grade/GradeListing.aspx?edit=1";
                                lblEdit.Text = "Edit";
                                Edit = false;
                                lnkAddGrade.Visible = false;                        
                            }
                        }
                        else
                        {
                            lnkEdit.NavigateUrl = "~/Views/Grade/GradeListing.aspx?edit=1";
                            lblEdit.Text = "Edit";
                            Edit = false;
                        }
                    }
                    else
                    {
                        lnkEdit.Visible = false;
                    }

                    using (var helper = new DbHelper.Grade())
                    {
                        DataList1.DataSource = helper.ListGrades(user.SchoolId);
                        DataList1.DataBind();
                    }
                }
            }
            else Response.Redirect("~/");
        }

        public bool Edit
        {
            get { return Convert.ToBoolean(hidEdit.Value); }
            set { hidEdit.Value = value.ToString(); }
        }

        public bool IsEditable(object schoolId)
        {
            if (schoolId == null)
            {
                return false;
            }
            return true;
        }
        

    }
}