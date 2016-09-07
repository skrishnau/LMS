using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Exam.ExamType
{
    public partial class ExamTypeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlWeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlWeight.SelectedIndex == 0)
            //{
            //    //regularVali.ValidationExpression = @"^\[0-9][0-9][0-9]+(\.[0-9][0-9])+(\.[%])?$";
            //    valiWeight.Enabled = true;
            //}
            //else
            //{
            //    //regularVali.ValidationExpression = @"^\[0-9]*+(\.[0-9][0-9])";
            //    valiWeight.Enabled = false;
            //}
        }

        public int ExamTypeId
        {
            get { return Convert.ToInt32(hidExamTypeId.Value); }
            set { hidExamTypeId.Value = value.ToString(); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlWeight.SelectedIndex == 0)
            {
                //percent
                var txt1 = txtWeight.Text.TrimEnd(new char[] { '%' });
                try
                {
                    var txt2 = (float)Convert.ToDecimal(txt1);
                    if (txt2 < 0 || txt2 > 100)
                    {
                        valiWeight.ErrorMessage = "0 to 100 only.";
                        valiWeight.IsValid = false;
                    }
                }
                catch
                {
                    valiWeight.ErrorMessage = "Not a number";
                    valiWeight.IsValid = false;
                }

            }
            else
            {
                try
                {
                    var txt2 = (float)Convert.ToDecimal(txtWeight.Text);
                }
                catch
                {
                    valiWeight.ErrorMessage = "Not a number";
                    valiWeight.IsValid = false;
                }
            }

            SaveExamType();
        }

        void SaveExamType()
        {
            if (Page.IsValid)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    try
                    {
                        var ispercent = ddlWeight.SelectedIndex == 0;
                        var eType = new Academic.DbEntities.Exams.ExamType()
                        {
                            Id = ExamTypeId
                            ,
                            Name = txtName.Text
                            ,
                            Description = txtDescription.Text
                            ,
                            IsPercent = ispercent
                            ,
                            SchoolId = user.SchoolId
                            ,
                        };

                        if (txtFullmarks.Text != "")
                            eType.FullMarks = Convert.ToInt32(txtFullmarks.Text);
                        if (txtPassmarks.Text != "")
                            eType.PassMarks = Convert.ToInt32(txtPassmarks.Text);

                        eType.Weight = (float)Convert.ToDecimal(txtWeight.Text);

                        using (var helper = new DbHelper.Exam())
                        {
                            var saved = helper.AddOrUpdateExamType(eType);
                            if (saved != null)
                            {
                                Response.Redirect("~/Views/Exam/ExamType/ExamTypeList.aspx");
                            }
                        }
                    }
                    catch { }
                }
            }
        }
    }
}