using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.ActivityResource.Grading
{
    public partial class StudentGradeDispalyUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetData(string status, string grade, string remarks, bool submissionEnabled, bool showGradeToStudents)
        {
            lblStatus.Text = status;
            if (showGradeToStudents)
                lblGrade.Text = grade;
            btnSubmit.Enabled = submissionEnabled;
            lblRemarks.Text = remarks;
            remarksRow.Visible = !string.IsNullOrEmpty(remarks);
            gradeRow.Visible = showGradeToStudents;
        }

        public string RedirectUrl
        {
            get { return hidReturnUrl.Value; }
            set { hidReturnUrl.Value = value; }
        }


        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(RedirectUrl);
        }

        public bool SubmitButtonVisible
        {
            get { return btnSubmit.Visible; }
            set { btnSubmit.Visible = value; }
        }

        public string SubmitButtonText
        {
            get { return btnSubmit.Text; }
            set { btnSubmit.Text = value; }
        }

        //public System.Drawing.Color SubmitButtonBackColor
        //{
        //    set
        //    {
        //        btnSubmit.BackColor = value;
        //        btnSubmit.Font.Underline = true;
        //        btnSubmit.Font.Overline = true;
        //    }
        //}

        public bool SubmitDueIndicator
        {
            set
            {
                if (value)
                {
                    btnSubmit.Font.Strikeout = value;
                    //btnSubmit.ForeColor = System.Drawing.Color.Red;

                }
            }
        }

        //public System.Drawing.Color SubmitButtonForeColor
        //{
        //    set { btnSubmit.ForeColor = value; }
        //}
    }
}