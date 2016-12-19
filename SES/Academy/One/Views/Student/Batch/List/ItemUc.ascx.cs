using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Student.Batch.List
{
    public partial class ItemUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                lnkName.NavigateUrl = ("~/Views/Student/Batch/" + "?Id=" + BatchId);
        }

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { hidBatchId.Value = value.ToString(); }
        }

        public void LoadData(int id, string name, string description, int noOfPrograms, DateTime? classCommenceDate, bool edit)
        {
            BatchId = id;
            lnkName.Text = "● " + name;

            lnkEdit.Visible = edit;
            lnkDelete.Visible = edit;

            if (classCommenceDate != null)
            {
                lblClassCommenceFrom.Text = classCommenceDate.Value.ToString("D");
            }
            if (edit)
            {
                lnkEdit.NavigateUrl = ("~/Views/Student/Batch/Create/BatchCreate.aspx" + "?bId=" + BatchId);

                var redUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=" +
                                                   DbHelper.StaticValues.Encode("batch") +
                                                   "&batchId=" + id 
                                                   + "&showText="
                                                   + DbHelper.StaticValues.Encode("Are you sure to delete the batch, "
                                                   + name + "?")
                                                   ;
                lnkDelete.NavigateUrl = redUrl;
            }

            //lblCurrentlyIn.Text = batch.
            //lblStartYear.Text = classCommenceDate==null?"":classCommenceDate.Value.ToShortDateString();
            //lblNumberOfPrograms.Text = noOfPrograms.ToString();
        }

        //protected void lblName_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/Student/Batch/BatchDetail/Detail.aspx"+"?Id="+BatchId);
        //}

        //protected void lnkEdit_Click(object sender, EventArgs e)
        //{
        //    //Context.Items["BatchId"] = hidBatchId.Value;

        //    Response.Redirect("~/Views/Student/Batch/Create/BatchCreate.aspx" + "?Id=" + BatchId);
        //}
    }
}