using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Student.Batch
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    //lnkEdit.NavigateUrl = "~/Views/Student/Batch/Create/BatchCreate.aspx?Id=" + BatchId;
            //}


            if (!IsPostBack)
            {
                try
                {
                    //here id is BatchId
                    var id = Request.QueryString["Id"];
                    if (id != null)
                    {
                        int idInt = 0;
                        var success = Int32.TryParse(id, out idInt);
                        if (success)
                        {
                            //DetailUc.BatchId = idInt;
                            BatchId = idInt;

                            //DetailUc.LoadData(idInt);
                            //.BatchId = Convert.ToInt32(id.ToString());                            
                        }
                        else
                        {
                            Response.Redirect("~/Views/Student/");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/Student/");
                    }
                    LoadData();
                }
                catch { }

            }
        }

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { hidBatchId.Value = value.ToString(); }
        }

        public void LoadData()
        {
            //BatchId = Convert.ToInt32(id);
            using (var helper = new DbHelper.Batch())
            {
                var batch = helper.GetBatch(BatchId);
                if (batch != null)
                {
                    lblBatchName.Text = batch.Name;
                    lblSummary.Text = batch.Description;

                }
                var programs = helper.GetProgramBatchList(BatchId);
                foreach (var prog in programs)
                {
                    var no = prog.StudentBatches.Count(x => !(x.Void ?? false));
                    var item = (Batch.BatchDetail.DetailItemUc)Page.LoadControl("~/Views/Student/Batch/BatchDetail/DetailItemUc.ascx");
                    item.LoadData(prog.Id, prog.BatchId, prog.NameFromBatch, prog.ProgramId
                        , prog.Program.Name, prog.StartedStudying, prog.StudyCompleted, prog.Void,no);
                    //if (prog.CurrentYear != null)
                    //{
                    //    item.CurrentYear = prog.CurrentYear.Name;
                    //}
                    //if (prog.CurrentSubYear != null)
                    //{
                    //    item.CurrentSubYear = prog.CurrentSubYear.Name;
                    //}

                    item.Enabled = !(prog.Void ?? false);
                    pnlProgramsInTheBatch.Controls.Add(item);
                }
            }
        }


    }
}