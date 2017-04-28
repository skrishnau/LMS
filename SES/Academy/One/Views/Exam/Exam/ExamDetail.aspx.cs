using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Exam.Exam
{
    public partial class ExamDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    var eId = Request.QueryString["eId"];
                    if (eId != null)
                    {
                        using (var helper = new DbHelper.Exam())
                        {
                            hidExamId.Value = eId;
                            var examId = ExamId;
                            var exam = helper.GetExam(examId);

                            if (exam.ExamTypeId != null)
                            {
                                lblName.Text = exam.ExamType.Name;
                                //noticeDiv.InnerText = exam.Notice;
                                lblWeight.Text = exam.ExamType.Weight.ToString() + ((exam.IsPercent ?? false) ? " %" : " Marks");
                                if (exam.NoticeContent == "")
                                    exam.NoticeContent = exam.ExamType.Notice;
                            }
                            else
                            {
                                lblName.Text = exam.Name;
                                lblWeight.Text = exam.Weight.ToString() + ((exam.IsPercent ?? false) ? " %" : " Marks");
                            }
                            //noticeDiv.InnerText = Server.HtmlDecode(exam.Notice);

                            var notice = exam.NoticeContent;

                            notice = notice.Replace("@Start_Date",
                                exam.StartDate == null ? "_ _ _" : exam.StartDate.Value.ToShortDateString());
                            notice = notice.Replace("@Result_Date",
                                exam.ResultDate == null ? "_ _ _" : exam.ResultDate.Value.ToShortDateString());
                            notice = notice.Replace("@Name", exam.Name);
                            notice = notice.Replace("@Weight",
                                exam.Weight == null ? "_ _ _" : exam.Weight + (exam.IsPercent ?? false ? " %" : " Marks"));

                            Literal1.Text = notice;
                            //Label1.Text = exam.Notice;
                            lblResultDate.Text = exam.ResultDate == null
                                ? ""
                                : exam.ResultDate.Value.ToShortDateString();

                            lblStartDate.Text = exam.StartDate == null
                                ? ""
                                : exam.StartDate.Value.ToShortDateString();

                            //exam classes
                            var classes = helper.ListExamClasses(examId);
                            var progs = classes.GroupBy(x => x.RunningClass.Year.Program).OrderBy(y => y.Key.Name);
                            foreach (var p in progs)
                            {
                                var label1 = new Label()
                                {
                                    Text = "<div style=\"text-align: left;\">● " +
                                    p.Key.Name + "</div>"
                                };
                                pnlClasses.Controls.Add(label1);

                                var years = p.GroupBy(x => x.RunningClass.Year).OrderBy(y => y.Key.Position);
                                foreach (var y in years)
                                {
                                    var label2 = new HyperLink()
                                    {
                                        Text = " &nbsp; &nbsp; &nbsp; "+y.Key.Name
                                        ,CssClass = "link"
                                        ,Font = { Underline = false}
                                    };
                                    pnlClasses.Controls.Add(label2);


                                    foreach (var s in y)
                                    {
                                        if (s.RunningClass.SubYearId != null)
                                        {
                                            label2.Text += " , " + s.RunningClass.SubYear.Name;
                                        }

                                        label2.Text += (s.RunningClass == null
                                            ? ""
                                            : "&nbsp;&nbsp; | " + s.RunningClass.ProgramBatch.NameFromBatch)
                                            + "<br/>";

                                        label2.NavigateUrl = "~/Views/Exam/Exam/ExamClass.aspx?eocId="+s.Id;
                                    }
                                }
                            }

                        }
                    }
                }
                catch { }



            }
        }

        public int ExamId
        {
            get { return Convert.ToInt32(hidExamId.Value); }
            set { hidExamId.Value = value.ToString(); }
        }
    }
}