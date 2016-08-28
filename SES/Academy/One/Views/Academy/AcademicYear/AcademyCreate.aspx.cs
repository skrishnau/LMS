using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values.MemberShip;

namespace One.Views.Academy.AcademicYear
{
    public partial class AcademyCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            valiStartDate.ErrorMessage = "Required";
            try
            {
                if (!IsPostBack)
                {
                    var aId = Request.QueryString["aId"];
                    if (aId != null)
                    {
                        using (var helper = new DbHelper.AcademicYear())
                        {
                            var acad = helper.GetAcademicYear(Convert.ToInt32(aId));
                            if (acad != null)
                            {
                                hidId.Value = aId;
                                lblHeading.Text = acad.Name;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (cmbSchool.SelectedValue == "0")
            //{
            //    RequiredFieldValidator2.IsValid = false;
            //}
            //else
            //{
            //    RequiredFieldValidator2.IsValid = true;
            //}
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {

                DateTime start = DateTime.MinValue, end = DateTime.MaxValue;
                try
                {
                    start = Convert.ToDateTime(txtStart.Text);
                }
                catch
                {
                    valiStartDate.ErrorMessage = "Incorrect format.";
                    valiStartDate.IsValid = false;
                }
                try
                {
                    end = Convert.ToDateTime(txtEnd.Text);
                }
                catch
                {
                    valiEndDate.ErrorMessage = "Incorrect format.";
                    valiEndDate.IsValid = false;
                }
                //if (!Page.IsValid)
                //    return;
                if (Page.IsValid)
                {
                    var entity = new Academic.DbEntities.AcademicYear()
                    {
                        Id = Convert.ToInt32(hidId.Value)
                        ,
                        Name = txtName.Text
                        ,
                        EndDate = end
                        ,
                        StartDate = start
                        ,
                        SchoolId = user.SchoolId
                        //,
                        //IsActive = CheckBox1.Checked
                    };
                    using (var helper = new DbHelper.AcademicYear())
                    {

                        var saved = helper.AddOrUpdateAcademicYear(entity);
                        if (saved != null)
                        {
                            var btn = sender as Button;
                            if (btn != null)
                            {
                                if (btn.ID == "btnSaveAndAddSessions")
                                {
                                    Response.Redirect("~/Views/Academy/Session/Create.aspx?aId=" + saved.Id);
                                }
                                else
                                {
                                    Response.Redirect("~/Views/Academy/List.aspx");
                                }
                            }
                            //earlier uncommented
                            //pnlAcademicYear.Enabled = false;

                            //earlier uncommented  
                            //btnSave.Enabled = false;
                            //CreateUC1.ValidationEnabled = true;
                            //CreateUC1.AcademicYear = saved.Id;
                            //pnlAcademicYear.BackColor = Color.Aquamarine;
                            //pnlSession.Visible = true;
                        }
                    }
                }
            }
        }




    }
}