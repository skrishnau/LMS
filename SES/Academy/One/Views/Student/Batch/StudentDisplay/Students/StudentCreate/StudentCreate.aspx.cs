using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Student.Batch.StudentDisplay.Students.StudentCreate
{
    public partial class StudentCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var programBatchId = Context.Items["ProgramBatchId"];
                if (programBatchId != null)
                {
                    hidProgramBatchId.Value = programBatchId.ToString();
                    var pbId = Convert.ToInt32(programBatchId.ToString());
                    using (var helper = new DbHelper.Batch())
                    {
                        var pb = helper.GetProgramBatch(pbId);
                        lblProgramBatchName.Text = pb.NameFromBatch;
                    }
                    StudentCreateUc.ProgramBatchId = pbId;
                    //StudentCreateUc.SchoolId = Values.Session.GetSchool(Session);
                }
            }
            StudentCreateUc.CloseClicked += StudentCreateUc_CloseClicked;
        }

        void StudentCreateUc_CloseClicked(object sender, Values.MessageEventArgs e)
        {
            Response.Redirect("~/Views/Student/Batch/StudentDisplay/Students/ListOfStudents.aspx"+"?Id="+hidProgramBatchId.Value);
        }
    }
}