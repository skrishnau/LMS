using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Student.Batch.List
{
    public partial class ItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { hidBatchId.Value = value.ToString(); }
        }

        public void LoadData(int id, string name, string description,int noOfPrograms, DateTime? classCommenceDate)
        {
            BatchId = id;
            lblName.Text = name;
            //lblCurrentlyIn.Text = batch.
            lblStartYear.Text = classCommenceDate==null?"":classCommenceDate.Value.ToShortDateString();
            lblNumberOfPrograms.Text = noOfPrograms.ToString();
            
        }

        protected void lblName_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Student/Batch/BatchDetail/Detail.aspx"+"?Id="+BatchId);
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            //Context.Items["BatchId"] = hidBatchId.Value;

            Response.Redirect("~/Views/Student/Batch/Create/BatchCreate.aspx" + "?Id=" + BatchId);
        }
    }
}