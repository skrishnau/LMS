using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;
using One.Values.MemberShip;

namespace One.Views.Course.Category
{
    public partial class Create : System.Web.UI.UserControl
    {

        //public event EventHandler<MessageEventArgs> SaveClicked;
        //public event EventHandler<MessageEventArgs> CancelClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!IsPostBack)
            {
                txtName.Focus();
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    //DbHelper.ComboLoader.LoadSubjectCategory(ref cmbCategory,user.SchoolId, true, false);                    
                    DbHelper.ComboLoader.LoadSubjectCategory(ref cmbCategory, SchoolId, true, false);
                }
                
                LoadData();
            }
        }

        private void LoadData()
        {
            var catId = Request.QueryString["catId"];
            if (catId != null)
            {
                var categoryId= Convert.ToInt32(catId);
                using (var helper = new DbHelper.Subject())
                {
                    var category = helper.GetCategory(categoryId);
                    if (category != null)
                    {
                        CategoryId = categoryId;
                        txtName.Text = category.Name;
                        txtDescription.Text = category.Description;
                        ParentCategoryId = category.ParentId ?? 0;
                        
                    }
                }

            }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }
        public int ParentCategoryId
        {
            get { return Convert.ToInt32(hidParentCategoryId.Value); }
            set { hidParentCategoryId.Value = value.ToString(); }
        }

        public int CategoryId
        {
            get { return Convert.ToInt32(hidCategoryId.Value); }
            set { hidCategoryId.Value = value.ToString(); }
        }

        //public String ReturnUrl
        //{
        //    set
        //    {
        //        btnCancel.Visible = true;
        //        hidRetUrl.Value = value;
        //    }
        //}



        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var cat = new Academic.DbEntities.Subjects.SubjectCategory()
            {
                Id = CategoryId
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
                        Response.Redirect("~/Views/Course/?catId="+save.Id);
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Course/?catId=" +CategoryId);
        }

    }
}