using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Exam.Exam.Master
{
    public partial class CreateExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               var examId= Context.Items["ExamId"];
                if (examId != null)
                {
                    CreateExamUc.ExamId = Convert.ToInt32(examId);
                }
            }
        }
    }
}