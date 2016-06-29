using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Student.Batch.BatchDetail
{
    public partial class AddPrograms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var id = Request.QueryString["Id"];
                    if (id != null)
                    {
                        int batchId = 0;
                        var success = Int32.TryParse(id, out batchId);
                        if (success)
                        {
                            using (var helper = new DbHelper.Batch())
                            {
                                var batch= helper.GetBatch(batchId);
                                if (batch != null)
                                {
                                    lblBatchName.Text = batch.Name;
                                }
                            }
                            TreeViewUc.BatchId = batchId;//Convert.ToInt32(id.ToString());
                            TreeViewUc.SchoolId = Values.Session.GetSchool(Session);
                            //TreeViewUc.LoadTree(idInt);//.LoadData(idInt);
                            //.BatchId = Convert.ToInt32(id.ToString());    
                            //AddProgramsUc.BatchId = Convert.ToInt32(batchId.ToString());
                            var schoolId = Values.Session.GetSchool(Session);
                            //AddProgramsUc.LoadData(schoolId, batchId);

                        }
                        else
                        {
                            Response.Redirect("~/Views/Student/Batch/BatchDetail/Detail.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/Student/Batch/BatchDetail/Detail.aspx");
                    }
                }
                catch { }
            }
        }
    }
}