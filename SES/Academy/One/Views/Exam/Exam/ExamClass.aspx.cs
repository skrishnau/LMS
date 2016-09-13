using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Image = System.Web.UI.WebControls.Image;

namespace One.Views.Exam.Exam
{
    public partial class ExamClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //examOfClass
                var eoc = Request.QueryString["eocId"];
                if (eoc != null)
                {
                    try
                    {
                        hidExamOfClassId.Value = eoc;
                        using (var ehelper = new DbHelper.Exam())
                        using (var shelper = new DbHelper.Subject())
                        using (var bhelper = new DbHelper.Batch())
                        {
                            var examClass = ehelper.GetExamOfClass(ExamOfClassId);

                            if (examClass != null)
                            {
                                //UI title and other controls
                                lblExamName.Text = examClass.Exam.Name;
                                lblClassName.Text = examClass.RunningClass.ProgramBatch.NameFromBatch;

                                //Courses in this exam
                                var lst = shelper.ListExamCourses(examClass.Id);
                                var i = 1;
                                foreach (var es in lst)
                                {
                                    pnlSubjects.Controls.Add(new HyperLink()
                                    {
                                        Text = i + ". " + es.SubjectClass.SubjectStructure.Subject.Name + "<br/>"

                                        ,
                                        CssClass = "margin-top-bottom-little"
                                    });
                                    i++;
                                }

                                //students in the exam
                                i = 1;
                                var stds = bhelper.ListStudentsOfProgramBatch(examClass.RunningClass.ProgramBatch.Id);
                                foreach (var s in stds)
                                {
                                    pnlStudents.Controls.Add(new HiddenField() { Value = s.UserId.ToString() });
                                    pnlStudents.Controls.Add(new Label() { Text = i + ". " });
                                    pnlStudents.Controls.Add(new Image()
                                    {
                                        ImageUrl = s.ImageUrl
                                        ,
                                        Width = 40
                                        ,
                                        Height = 40
                                        ,
                                        BorderColor = Color.LightSlateGray
                                        ,
                                        BorderWidth = 1
                                        ,
                                        BorderStyle = BorderStyle.Solid
                                        ,
                                        //CssClass = "margin-top-bottom-little"
                                    });
                                    pnlStudents.Controls.Add(new HyperLink()
                                    {
                                        Text = "&nbsp;&nbsp; " + s.CRN + "     " + s.Name + "<br/>"
                                        ,
                                        CssClass = "margin-top-bottom-little"
                                    });
                                    i++;
                                }
                            }
                        }
                    }
                    catch { }


                }

            }
        }



        public int ExamOfClassId
        {
            set { hidExamOfClassId.Value = value.ToString(); }
            get { return Convert.ToInt32(hidExamOfClassId.Value); }
        }
    }
}