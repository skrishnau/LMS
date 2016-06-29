using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Student.Batch.BatchDetail
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                            DetailUc.BatchId = idInt;
                            //DetailUc.LoadData(idInt);
                                //.BatchId = Convert.ToInt32(id.ToString());                            
                        }
                        else
                        {
                            Response.Redirect("~/Views/Student/Batch/ListBatch.aspx");                            
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/Student/Batch/ListBatch.aspx");
                    }
                }
                catch { }

            }
        }
    }
}