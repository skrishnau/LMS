using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
//using Academic.InitialValues;
using One.Values.MemberShip;
using System.IO;
using Academic.DbEntities;

namespace One.Views.User
{
    public partial class UserCreateUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            valiUserName.ErrorMessage = "Required";
            //string editMode = "";
            if (!IsPostBack)
            {
                DbHelper.ComboLoader.LoadGender(ref cmbGender);
                FilesDisplay.FileAcquireMode = Enums.FileAcquireMode.Single;
                var key = Guid.NewGuid().ToString();
                FilesDisplay.PageKey = key;
                PageKey = key;
                FilesDisplay.FileSaveDirectory = DbHelper.StaticValues.UserImageDirectory;
            }
        }


        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        public string EditMode
        {
            get { return this.hidEditMode.Value; }
            set { this.hidEditMode.Value = value; }
        }
        public string PageKey
        {
            get { return this.hidPageKey.Value; }
            set { this.hidPageKey.Value = value; }
        }

        #endregion


        #region Functions

        private void ResetTextAndCombos()
        {
            txtMidName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtStreet.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtPhone1.Text = "";
            txtDOB.Text = "";
            txtCountry.Text = "";
            txtCity.Text = "";
            txtStreet.Text = "";

        }

        #endregion


        #region Events save, etc.

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                using (var helper = new DbHelper.User())
                {
                    if (helper.DoesUserNameExist(user.SchoolId, txtUserName.Text))
                    {
                        valiUserName.ErrorMessage = "Username already exists";
                        valiUserName.IsValid = false;
                    }
                    if (Page.IsValid)
                    {
                        var dob = DateTime.MinValue;
                        try
                        {
                            dob = Convert.ToDateTime(txtDOB.Text);
                        }
                        catch
                        {
                        }
                        var date = DateTime.Now.Date;
                        var createdUser = new Academic.DbEntities.User.Users()
                        {
                            SchoolId = user.SchoolId
                            ,
                            City = txtCity.Text
                            ,
                            Country = txtCountry.Text
                            ,
                            CreatedDate = date
                            ,
                            Email = txtEmail.Text
                            ,
                            FirstName = txtFirstName.Text
                            ,
                            MiddleName = txtMidName.Text,
                            LastName = txtLastName.Text
                            ,
                            IsActive = true
                            ,
                            IsDeleted = false
                            ,
                            UserName = txtUserName.Text
                            ,
                            Password = txtPassword.Text
                            ,
                            //Description = txtDescription.Text
                            //,
                        };
                        if (!(cmbGender.SelectedValue == "0" || cmbGender.SelectedValue != ""))
                        {
                            createdUser.GenderId = Convert.ToInt32(cmbGender.SelectedValue);
                        }
                        if (dob != DateTime.MinValue)
                            createdUser.DOB = dob;




                        var files = FilesDisplay.GetFiles();
                        var image = new UserFile();
                        if (files != null)
                        {
                            if (files.Count >= 1)
                            {
                                var f = files[0];
                                //foreach (var f in files)
                                {
                                    var fileName = Path.GetFileName(f.FilePath);
                                    image = new Academic.DbEntities.UserFile()
                                    {
                                        Id = f.Id,
                                        CreatedBy = user.Id
                                        ,
                                        CreatedDate = DateTime.Now
                                        ,
                                        DisplayName = f.FileDisplayName //Path.GetFileName(imageFile.FileName)
                                        ,
                                        FileDirectory = DbHelper.StaticValues.UserImageDirectory //StaticValue.UserImageDirectory
                                        ,
                                        FileName = fileName
                                            //Guid.NewGuid().ToString() + GetExtension(imageFile.FileName, imageFile.ContentType)
                                        ,
                                        FileSizeInBytes = f.FileSizeInBytes //imageFile.ContentLength
                                        ,
                                        FileType = f.FileType //imageFile.ContentType
                                        ,
                                        IconPath = f.IconPath
                                        ,
                                        //SubjectId = SubjectId
                                    };
                                    if (f.Id > 0)
                                    {
                                        image.ModifiedBy = user.Id;
                                        image.ModifiedDate = DateTime.Now;
                                    }
                                }
                            }
                        }

                        var savedUser = helper.AddOrUpdateUser(createdUser, "0", image);

                        if (savedUser != null)
                        {
                            Response.Redirect("List.aspx");
                            //ResetTextAndCombos();
                        }
                    }
                }
            }
        }

        protected void lnkShowOptional_Click(object sender, EventArgs e)
        {
            tableOpt.Visible = !tableOpt.Visible;
        }

        #endregion

    }
}