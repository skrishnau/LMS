using Academic.DbEntities.Subjects;
using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.Course.CourseCreate
{
    public partial class CourseCreateUc : System.Web.UI.UserControl
    {
        public event EventHandler<MessageEventArgs> NewCategoryButtonClicked;
        public event EventHandler<MessageEventArgs> SaveClicked;
        public event EventHandler<MessageEventArgs> CancelClicked;


        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Visible = false;

            if (!IsPostBack)
            {
                DbHelper.ComboLoader.LoadSubjectCategory(ref cmbCategory, Values.Session.GetSchool(Session), false, true);
            }
        }


        public int SubjectGroupId
        {
            get { return Convert.ToInt32(hidSubjectGroupId.Value); }
            set
            {
                btnCancel.Visible = true;
                hidSubjectGroupId.Value = value.ToString();
            }
        }
        public int YearId
        {
            get { return Convert.ToInt32(hidYearId.Value); }
            set
            {
                btnCancel.Visible = true;
                hidYearId.Value = value.ToString();
            }
        }
        public int SubYearId
        {
            get { return Convert.ToInt32(hidSubYearId.Value); }
            set { hidSubYearId.Value = value.ToString(); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue == "" || cmbCategory.SelectedValue == "0" || cmbCategory.SelectedValue == "-1")
            {
                RequiredFieldValidator1.IsValid = false;
            }
            if (Page.IsValid)
            {
                var credit = txtCredit.Text;
                Subject subject = new Subject()
                {
                    Name = txtName.Text,
                    Code = txtCode.Text,
                    CreatedDate = DateTime.Now.Date
                    ,
                    SubjectCategoryId = Convert.ToInt32(cmbCategory.SelectedValue)
                };
                if (string.IsNullOrEmpty(txtCredit.Text))
                {
                    subject.Credit = Convert.ToByte(txtCode.Text == "" ? "0" : txtCode.Text);
                }

                using (var helper = new DbHelper.Subject())
                {
                    bool saved = false;
                    if (YearId > 0)
                    {
                        saved = helper.AddOrUpdateRegularSubject(subject, YearId, SubYearId);
                    }
                    else
                    {
                         saved = helper.AddOrUpdateSubject(subject, subjectGroupId: SubjectGroupId);
                    }
                    if (saved)
                    {
                        ResetControls();
                        if (SaveClicked != null)
                        {
                            SaveClicked(this, DbHelper.StaticValues.SuccessSaveMessageEventArgs);
                        }
                        else
                        {
                            Response.Redirect("~/Views/Course/List.aspx");
                        }
                    }
                    else
                    {
                        lblMessage.Visible = true;
                    }
                }

            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            if (NewCategoryButtonClicked != null)
            {
                NewCategoryButtonClicked(this, DbHelper.StaticValues.NewCreateMessageEventArgs);
            }
            else
            {
                SaveControlState();
                Response.Redirect("~/Views/Course/Category/Create.aspx" + "?ReturnUrl=" +
                                  HttpUtility.UrlEncode("~/Views/Course/CourseEntryForm.aspx"));
            }
        }

        public void SelectCategory(int categoryId, string categoryName)
        {
            cmbCategory.Items.Clear();
            DbHelper.ComboLoader.LoadSubjectCategory(ref cmbCategory, Values.Session.GetSchool(Session), false, true, categoryId);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
            if (CancelClicked != null)
            {
                CancelClicked(this, DbHelper.StaticValues.CancelClickedMessageEventArgs);
            }
        }

        public void ResetControls()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtCredit.Text = "";
            cmbCategory.ClearSelection();
        }
    }
}