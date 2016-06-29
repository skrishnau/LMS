using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Student.Batch.Create
{
    public partial class BatchCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CreateBatchUc.SchoolId = Values.Session.GetSchool(Session);

                ////For Server.Transfer method
                //var batchId = Context.Items["BatchId"];
                //if (batchId != null)
                //{
                //    CreateBatchUc.SetDatasForEdit(Convert.ToInt32(batchId.ToString()));
                //    Context.Items.Remove("BatchId");
                //}

                try
                {
                    var id = Request.QueryString["Id"];
                    if (id != null)
                    {
                        CreateBatchUc.SetDatasForEdit(Convert.ToInt32(id.ToString()));
                        //CreateBatchUc.LoadData(id);//.BatchId = Convert.ToInt32(id.ToString());
                    }
                }
                catch { }

            }
        }
    }
}