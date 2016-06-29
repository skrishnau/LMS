using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Course.Category
{
    public partial class Create : System.Web.UI.UserControl
    {

        public event EventHandler<MessageEventArgs> SaveClicked;
        public event EventHandler<MessageEventArgs> CancelClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DbHelper.ComboLoader.LoadSubjectCategory(ref cmbCategory, Values.Session.GetSchool(Session), true, false);
                if (!String.IsNullOrEmpty(hidRetUrl.Value) || CancelClicked != null)
                {
                    btnCancel.Visible = true;
                }
            }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        public String ReturnUrl
        {
            set
            {
                btnCancel.Visible = true;
                hidRetUrl.Value = value;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var cat = new Academic.DbEntities.Subjects.SubjectCategory()
            {
                Id = Convert.ToInt32(hidId.Value)
                ,
                SchoolId = SchoolId
                ,
                CreatedDate = DateTime.Now.Date
                ,
                Description = txtDescription.Text
                ,
                IsActive = chkIsActive.Checked
                ,
                Name = txtName.Text


            };
                if (!(cmbCategory.SelectedValue == "" || cmbCategory.SelectedValue == "0" || cmbCategory.SelectedValue == "-1"))
                    cat.ParentId = Convert.ToInt32(cmbCategory.SelectedValue);

                using (var helper = new DbHelper.Subject())
                {
                    var save = helper.AddOrUpdateSubjectCategory(cat);
                    if (save != null)
                    {
                        ResetControls();
                        if (SaveClicked != null)
                        {
                            var args = StaticValues.SuccessSaveMessageEventArgs;
                            args.SavedId = save.Id;
                            args.SavedName = save.Name;
                            SaveClicked(this, args);
                        }
                        else if (!String.IsNullOrEmpty(hidRetUrl.Value))
                        {
                            Response.Redirect(hidRetUrl.Value);
                        }

                    }
                    else
                    {
                        if (SaveClicked != null)
                        {
                            SaveClicked(this, StaticValues.ErrorSaveMessageEventArgs);
                        }
                    }
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelClicked != null)
            {
                ResetControls();
                CancelClicked(this, StaticValues.CancelClickedMessageEventArgs);
            }
            else if (!String.IsNullOrEmpty(hidRetUrl.Value))
            {
                ResetControls();
                Response.Redirect(hidRetUrl.Value);
            }
        }

        public void ResetControls()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            cmbCategory.ClearSelection();
        }
    }
}