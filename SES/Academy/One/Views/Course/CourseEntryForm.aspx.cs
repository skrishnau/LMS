using Academic.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Subjects;
using Academic.DbHelper;

namespace One.Views.Course
{
    public partial class CourseEntryForm : System.Web.UI.Page
    {
        AcademicContext context = new AcademicContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DbHelper.ComboLoader.LoadSubjectCategory(ref cmbCategory, Values.Session.GetSchool(Session),false,true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue == "" || cmbCategory.SelectedValue == "0" ||cmbCategory.SelectedValue=="-1")
            {
                RequiredFieldValidator1.IsValid = false;
            }
            if (IsValid)
            {
                var credit = txtCredit.Text;
                Subject subject = new Subject()
                {
                    Name = txtName.Text,
                    Code = txtCode.Text,
                    HasTheory = chkListHas.Items[0].Selected,
                    HasLab = chkListHas.Items[1].Selected,
                    HasTutorial = chkListHas.Items[2].Selected,
                    HasProject = chkListHas.Items[3].Selected,
                    //LevelId = Convert.ToInt32(cmbLevel.SelectedValue),
                    //FacultyId = Convert.ToInt32((cmbFaculty.SelectedValue == "") ? "1" : cmbFaculty.SelectedValue),
                    //ProgramId = Convert.ToInt32(prog),
                    //YearId = Convert.ToInt32(yea),

                    IsElective = chkListIs.Items[0].Selected,
                    IsOutOfSyllabus = chkListIs.Items[1].Selected,
                    
                    CreatedDate = DateTime.Now.Date
                    ,IsActive = ckhIsActive.Checked
                    ,SubjectCategoryId = Convert.ToInt32(cmbCategory.SelectedValue)
                };
                if (string.IsNullOrEmpty(txtCredit.Text))
                {
                    subject.Credit = Convert.ToByte(txtCode.Text == "" ? "0" : txtCode.Text);
                }
                if (!String.IsNullOrEmpty(txtFullMarks.Text))
                {
                    subject.FullMarks = Convert.ToInt32(txtFullMarks.Text);
                }
                if (!string.IsNullOrEmpty(txtPassPercent.Text))
                {
                    subject.PassPercentage = Convert.ToByte(txtPassPercent.Text);
                }
                if (!string.IsNullOrEmpty(txtCompletionHours.Text))
                {
                    subject.CompletionHours = Convert.ToInt16(txtCompletionHours.Text);
                }

                using (var helper = new DbHelper.Subject())
                {
                    var saved = helper.AddOrUpdateSubject(subject);
                    if (saved)
                    {
                        Response.Redirect("~/Views/Course/List.aspx");
                    }
                }
                
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
           //RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            SaveControlState();
           Response.Redirect("~/Views/Course/Category/Create.aspx" + "?ReturnUrl=" +HttpUtility.UrlEncode("~/Views/Course/CourseEntryForm.aspx"));
        }

        //protected void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var id = Convert.ToInt32(cmbLevel.SelectedItem.Value);
        //    cmbFaculty.Items.Clear();
        //    var faculties = context.Faculty.Where(x => x.LevelId == id).ToList();
        //    //context.Faculty.Where(x => x.LevelId == ((cmbLevel.SelectedValue!="")? Convert.ToInt32(cmbLevel.SelectedValue):0))
        //    faculties.ForEach(y =>
        //        {
        //            ListItem item = new ListItem()
        //            {
        //                Value = y.Id.ToString(),
        //                Text = y.Name
        //            };
        //            cmbFaculty.Items.Add(item);
        //        });
        //    //cmbLevel.Items.Clear();
        //}

        //protected void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var id = Convert.ToInt32(cmbFaculty.SelectedItem.Value);
        //    cmbProgram.Items.Clear();
        //    var program = context.Program.Where(x => x.FacultyId == id).ToList();
        //    //context.Faculty.Where(x => x.LevelId == ((cmbLevel.SelectedValue!="")? Convert.ToInt32(cmbLevel.SelectedValue):0))
        //    program.ForEach(y =>
        //    {
        //        ListItem item = new ListItem()
        //        {
        //            Value = y.Id.ToString(),
        //            Text = y.Name
        //        };
        //        cmbProgram.Items.Add(item);
        //    });
        //    //cmbLevel.Items.Clear();
        //}
    }
}