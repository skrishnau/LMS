using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Activity.Teach
{
    public partial class Create : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DbHelper.ComboLoader.LoadSession(ref cmbSession, Values.Session.GetAcademicYear( Session));
                DbHelper.ComboLoader.LoadTeacher(ref cmbTeacher, Values.Session.GetSchool(Session));
                DbHelper.ComboLoader.LoadSubject(ref cmbSubject, Values.Session.GetSchool(Session));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if ((cmbSession.SelectedValue == "" || cmbSession.SelectedValue == ""))
            {
                RequiredFieldValidator1.IsValid = false;
            }
            if ((cmbTeacher.SelectedValue == "" || cmbTeacher.SelectedValue == ""))
            {
                RequiredFieldValidator2.IsValid = false;
            }
            if ((cmbSubject.SelectedValue == "" || cmbSubject.SelectedValue == ""))
            {
                RequiredFieldValidator3.IsValid = false;
            }

            if (Page.IsValid)
            {
                DateTime date  = DateTime.Now;
                
                var teach = new Academic.DbEntities.Activities.Teach()
                {
                    Id = Convert.ToInt32(hidId.Value)
                    ,AcademicYearId = Values.Session.GetAcademicYear(Session)
                    ,AssignedDate = date
                    ,StartDate = DateChooser.SelectedDate
                    ,
                    SessionId = Convert.ToInt32(cmbSession.SelectedValue)
                    ,SubjectId = Convert.ToInt32(cmbSubject.SelectedValue)
                    ,TeacherId = Convert.ToInt32(cmbTeacher.SelectedValue)
                    ,Remarks = txtRemarks.Text

                };
                if (!String.IsNullOrEmpty(txtEstimated.Text))
                {
                    teach.EstimatedCompletionHours = Convert.ToInt32(txtEstimated.Text);
                }
                using (var helper = new DbHelper.Activity())
                {
                    var saved = helper.AddOrUpdateTeach(teach);
                    if (saved != null)
                    {
                        Response.Redirect("~/Views/Activity/List.aspx");
                    }
                    else
                    {
                        
                    }
                }
            }
        }

    }
}