using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Exam.Exam.ExamList
{
    public partial class ItemsOfListUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region Properties

    public int ExamId { get { return Convert.ToInt32(hidExamId.Value); } set { hidExamId.Value = value.ToString(); }}

        #endregion

        #region Update Function

        public void SetFields(int id,string name, string type, DateTime? resultDate, 
            DateTime? updatedDate, float weight, string notice)
        {
            ExamId = id;
            lblHeading.Text = name;
            lblType.Text = type;
            //lblCreatedDate.Text = createdDate.HasValue?createdDate.Value.ToShortDateString():"";
            lblNotice.Text = notice;
            lblResultDate.Text = resultDate.HasValue? resultDate.Value.ToShortDateString():"";
            lblWeight.Text = weight.ToString();
            //lblUpdatedDate.Text = updatedDate.HasValue? updatedDate.Value.ToShortDateString():"";

        }

        #endregion

        protected void lblHeading_Click(object sender, EventArgs e)
        {
            //particular exam details
            Response.Redirect("#");
        }

        protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            //edit the exam
            Context.Items["ExamId"] = ExamId;
            Server.Transfer("~/Views/Exam/Exam/Master/CreateExam.aspx");
        }

    }
}