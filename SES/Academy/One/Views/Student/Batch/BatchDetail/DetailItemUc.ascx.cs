using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Student.Batch.BatchDetail
{
    public partial class DetailItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        #region Properties

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { hidProgramBatchId.Value = value.ToString(); }
        }

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { hidBatchId.Value = value.ToString(); }
        }

        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgramId.Value); }
            set { hidProgramId.Value = value.ToString(); }
        }

        public bool CourseCompleted
        {
            get { return lblCourseCompleted.Visible; }
            set { lblCourseCompleted.Visible = value; }
        }

        public string CurrentYear
        {
            get { return lblCurrentYear.Text; }
            set { lblCurrentYear.Text = value; }
        }
        public string CurrentSubYear
        {
            get { return lblCurrentSubYear.Text; }
            set { lblCurrentSubYear.Text = value; }
        }
        public bool StartedStudying { get; set; }

        public bool Enabled
        {
            get { return pnlBody.Enabled; }
            set
            {
                if (!value)
                {
                    pnlBody.BackColor = Color.LightGray;
                }
                pnlBody.Enabled = value;
            }
        }

        #endregion


        public void LoadData(int id, int batchId, string namefromBatch, int programId, string programName
            , bool? startedStudying, bool? studyCompleted, bool? Void, int noOfStudents)
        {
            lnkProgrameName.Text = programName;
            CourseCompleted = studyCompleted ?? false;
            BatchId = batchId;
            ProgramBatchId = id;
            lnkProgrameName.NavigateUrl = "~/Views/Student/Batch/Student/?pbId=" + id;

            ProgramId = programId;
            lblNoOfStudents.Text = noOfStudents.ToString();
            
        }
    }
}