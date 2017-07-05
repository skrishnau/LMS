using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Structure.All.UserControls
{
    public partial class ListSubYearUC : System.Web.UI.UserControl
    {
        //public event EventHandler<StructureEventArgs> CourseClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        public int YearId
        {
            get { return Convert.ToInt32(hidYearId.Value); }
            set { hidYearId.Value = value.ToString(); }
        }

        public int SubYearId
        {
            get { return Convert.ToInt32(hidSubYearId.Value); }
            set { this.hidSubYearId.Value = value.ToString(); }
        }


        public void SetName(int yearId, int subyearId, string name, string editUrl, int noOfCourses
            , string currentBatch, int programBatchId
            , bool edit = false)
        //, string addUrl = "", string addText = "")
        {
            //this.hidStructureId.Value = id.ToString();
            var firstPart = "~/Views/Structure/";
            string courseListUrl = "CourseListing.aspx" + "?yId=" + yearId + "&sId=" +
                subyearId + "&edit=" + (edit ? "1" : "0");

            YearId = yearId;
            SubYearId = subyearId;
            lnkName.Text = ((subyearId == 0) ? "●" : "♦") + name;
            if (subyearId == 0)
            {
                lblNoOfCourses.Visible = false;
            }
            else
            {
                if (noOfCourses > 0)
                    lblNoOfCourses.Text = "No. of courses : " + noOfCourses.ToString();
                else
                {
                    var link = "<a href='"+courseListUrl+"'>"+"There are no courses. Please add courses"+
                        "</a>";
                    lblNoOfCourses.Text = link;
                    lblNoOfCourses.ForeColor = Color.Red;
                }
            }
            //lnkEdit.Visible = edit;
            //lnkDelete.Visible = edit;


            pnlBody.Style.Add("padding", "5px");
            if (currentBatch == "")
            {
                row_currentBatch.Visible = false;
                //pnlBody.BackColor = //Color.LightGray;
                //Color.FromArgb(225, 225, 225);
            }
            else
            {
                lblCurrentBatch.Text = currentBatch;
                //pnlBody.BackColor =//Color.LightGreen;
                //    Color.FromArgb(193, 252, 193);
                lnkCurrentBatch.NavigateUrl =
                    "~/Views/Student/Batch/StudentDisplay/Students/StudentListInProgramBatch.aspx?pbId=" + programBatchId;
            }

            //earlier before edit and delete were present
            //if (edit)
            //{
            //    lnkEdit.NavigateUrl = editUrl;

            //    var redUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=" +
            //                                    DbHelper.StaticValues.Encode("structure") +
            //                                    "&progId=0"
            //                                    + "&yeaId=" + yearId
            //                                    + "&syeaId=" + subyearId
            //                                    + "&showText="
            //                                    + DbHelper.StaticValues.Encode("Are you sure to delete the sub-year, "
            //                                    + name + "?")
            //                                    ;
            //    lnkDelete.NavigateUrl = redUrl;
            //}
            lnkName.NavigateUrl = firstPart + courseListUrl;
        }

        protected void lnkCoursesList_Click(object sender, EventArgs e)
        {
            //ViewState["yearId"] = YearId;
            //ViewState["subYearId"] = SubYearId;
            Response.Redirect("~~/Views/Structure/CourseListing.aspx" + "?yId=" + YearId + "&sId=" + SubYearId);
            //if (CourseClicked != null)
            //{
            //    CourseClicked(this,new StructureEventArgs()
            //    {
            //        YearId = this.YearId
            //        ,SubYearId = this.SubYearId
            //    });
            //}
        }
    }
}