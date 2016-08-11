using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Subjects;
using Academic.DbHelper;
using One.Values;
using One.Values.MemberShip;

namespace One.Views.Course.Course
{
    public partial class CreateUC : System.Web.UI.UserControl
    {
        public event EventHandler<MessageEventArgs> SaveClicked;
        public event EventHandler<MessageEventArgs> CancelClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    var user = Page.User as CustomPrincipal;
            //    if(user!=null)
            //    DbHelper.ComboLoader.LoadSubjectCategory(
            //        ref cmbCategory, user.SchoolId, false, true);//Values.Session.GetSchool(Session)
            //}
        }

        public int CategoryId
        {
            get { return Convert.ToInt32(hidCategoryId.Value); }
            set { hidCategoryId.Value = value.ToString(); }
        }

        public void SetCategoryIdAndName(string id, string name)
        {
            hidCategoryId.Value = id;
            lblCategoryName.Text = name;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (cmbCategory.SelectedValue == "" || cmbCategory.SelectedValue == "0" || cmbCategory.SelectedValue == "-1")
            //{
            //    RequiredFieldValidator1.IsValid = false;
            //}
            if (Page.IsValid)
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
                    ,
                    IsActive = ckhIsActive.Checked
                    ,
                    //SubjectCategoryId = Convert.ToInt32(cmbCategory.SelectedValue)
                    SubjectCategoryId = CategoryId
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

                    //Response.Redirect("~/Views/Course/List.aspx");
                    if (SaveClicked != null)
                    {
                        if (saved)
                            SaveClicked(this, Values.StaticValues.SuccessSaveMessageEventArgs);
                        else
                            SaveClicked(this, Values.StaticValues.ErrorSaveMessageEventArgs);
                    }
                }
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            SaveControlState();
            Response.Redirect("~/Views/Course/Category/Create.aspx" + "?ReturnUrl=" + HttpUtility.UrlEncode("~/Views/Course/CourseEntryForm.aspx"));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            if (CancelClicked != null)
            {
                CancelClicked(this, Values.StaticValues.CancelClickedMessageEventArgs);
            }
        }

        void ResetControls()
        {
            this.txtName.Text = "";
            this.txtCode.Text = "";
            this.txtCredit.Text = "";
            this.txtCompletionHours.Text = "";
            this.txtFullMarks.Text = "";
            this.txtPassPercent.Text = "";

            var i = 0;
            foreach (ListItem item in chkListHas.Items)
            {
                if (i == 0)
                    item.Selected = true;
                else
                    item.Selected = false;
                i = 1;
            }
            foreach (ListItem listItem in chkListIs.Items)
            {
                listItem.Selected = false;
            }
        }
    }
}