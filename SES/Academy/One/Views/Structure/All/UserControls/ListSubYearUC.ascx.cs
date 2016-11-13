using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.Structure.All.UserControls
{
    public partial class ListSubYearUC : System.Web.UI.UserControl
    {
        //public event EventHandler<StructureEventArgs> CourseClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void AddControl(ListUC uc)
        {
            this.pnlSubControls.Controls.Add(uc);
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
            ,string currentBatch ,int programBatchId
            ,bool edit = false
            ,string addUrl = "", string addText = "")
        {
            //this.hidStructureId.Value = id.ToString();
            YearId = yearId;
            SubYearId = subyearId;
            lblName.Text = name;
            lnkEdit.Visible = edit;
            lnkAdd.Visible = edit && addUrl != "";

            lblNoOfCourses.Text = noOfCourses.ToString();
            if (currentBatch == "")
            {
                row_currentBatch.Visible = false;
                pnlBody.BackColor = //Color.LightGray;
                Color.FromArgb(225, 225, 225);
            }
            else
            {
                lblCurrentBatch.Text = currentBatch;  
                pnlBody.BackColor=//Color.LightGreen;
                    Color.FromArgb(193, 252, 193);
                lnkCurrentBatch.NavigateUrl =
                    "~/Views/Student/Batch/StudentDisplay/Students/StudentListInProgramBatch.aspx?pbId="+programBatchId;
            }

            if (edit)
            {
                lnkEdit.NavigateUrl = editUrl;
                lnkAdd.NavigateUrl = addUrl;
                lblAddText.Text = addText;

                lnkAdd.ToolTip = addText + " in " + name.Replace("♦", "").Replace("●", ""); ;
            }
        }

        protected void lnkCoursesList_Click(object sender, EventArgs e)
        {
            //ViewState["yearId"] = YearId;
            //ViewState["subYearId"] = SubYearId;
            Response.Redirect("~/Views/Structure/All/Master/CoursesList.aspx" + "?yId=" + YearId + "&sId=" + SubYearId);
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