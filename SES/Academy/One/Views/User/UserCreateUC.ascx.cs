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
using Academic.ViewModel;

namespace One.Views.User
{
    public partial class UserCreateUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                
                lblSaveStatus.Visible = false;
                lblSaveStatus.Text = "Couldn't save";
                valiUserName.ErrorMessage = "Required";
                //string editMode = "";
                if (!IsPostBack)
                {
                    if (!user.IsInRole(DbHelper.StaticValues.Roles.Manager))
                    {
                        Response.Redirect("~/");
                        return;
                    }

                    DbHelper.ComboLoader.LoadGender(ref cmbGender);
                    FilesDisplay.FileAcquireMode = Enums.FileAcquireMode.Single;
                    var key = Guid.NewGuid().ToString();
                    FilesDisplay.PageKey = key;
                    PageKey = key;
                    FilesDisplay.FileSaveDirectory = DbHelper.StaticValues.UserImageDirectory;

                    DbHelper.ComboLoader.LoadRoleForUserEnroll(ref ddlRole, user.SchoolId, DbHelper.StaticValues.Roles.Teacher, false);

                    LoadData();
                }
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

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
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
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtPhone1.Text = "";
            txtDOB.Text = "";
            txtCountry.Text = "";
            txtCity.Text = "";
        }

        private void LoadData()
        {
            if (UserId > 0)
                using (var helper = new DbHelper.User())
                {
                    var userId = UserId;
                    var us = helper.GetUser(userId);
                    if (us != null)
                    {
                        //tx.Text = us.FullName;
                        //txtPageTitle.Text = "User Detail";
                        txtCity.Text = us.City;
                        txtCountry.Text = us.Country;
                        txtDOB.Text = us.DOB.HasValue ? us.DOB.Value.ToShortDateString() : "";
                        txtEmail.Text = us.Email;
                        txtFirstName.Text = us.FirstName;

                        if (us.GenderId != null)
                            cmbGender.SelectedValue = us.GenderId.ToString();// != null ? us.Gender.Name : "";

                        txtLastName.Text = us.LastName;
                        txtMidName.Text = us.MiddleName;

                        txtPhone1.Text = us.Phone;
                        txtUserName.Text = us.UserName;
                        //txtStreet.Text = us.;
                        txtPassword.Text = us.Password;


                        var role = us.UserRoles.FirstOrDefault();
                        if (role != null)
                        {
                            ddlRole.SelectedValue = role.RoleId.ToString();
                        }
                        if (us.UserImage != null)
                        {
                            var images = new List<FileResourceEventArgs>()
                            {
                                new FileResourceEventArgs()
                                {
                                    Id = us.UserImageId??0,
                                    Visible = true,
                                    FileDisplayName = us.UserImage.DisplayName,
                                    FilePath = us.UserImage.FileDirectory+us.UserImage.FileName,
                                    FileType = us.UserImage.FileType,
                                    FileSizeInBytes = us.UserImage.FileSizeInBytes,
                                    IconPath = us.UserImage.FileDirectory+us.UserImage.FileName,
                                    IsConstantAndNotEditable = false,
                                    LocalId = "1"
                                }
                            };
                            FilesDisplay.SetInitialValues(images);
                        }

                        //lnkImage.NavigateUrl = us.UserImage != null
                        //    ? us.UserImage.FileDirectory + us.UserImage.FileName
                        //    : "";
                        //imgPhoto.ImageUrl = lnkImage.NavigateUrl != "" ? lnkImage.NavigateUrl :
                        //    "~/Content/Icons/Users/user-male-52px.png";
                        //imgPhoto.AlternateText = "Image not found";
                    }
                }
        }

        #endregion


        #region Events save, etc.

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                using (var fileHelper = new DbHelper.WorkingWithFiles())
                using (var helper = new DbHelper.User())
                {
                    if (helper.DoesUserNameExist(user.SchoolId,UserId, txtUserName.Text))
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
                            SchoolId = user.SchoolId,
                            City = txtCity.Text,
                            Country = txtCountry.Text,
                            CreatedDate = date,
                            Email = txtEmail.Text,
                            FirstName = txtFirstName.Text,
                            MiddleName = txtMidName.Text,
                            LastName = txtLastName.Text,
                            IsActive = true,
                            IsDeleted = false,
                            UserName = txtUserName.Text,
                            Password = txtPassword.Text,
                            Id = UserId,
                            Phone = txtPhone1.Text,
                            //Description = txtDescription.Text,
                        };
                        if (cmbGender.SelectedValue!=""&& cmbGender.SelectedValue!="0")
                        {
                            createdUser.GenderId = Convert.ToInt32(cmbGender.SelectedValue);
                        }
                        if (dob != DateTime.MinValue)
                            createdUser.DOB = dob;

                        var userPhotoDirectory = fileHelper.GetUserPhotoFolder(user.SchoolId);
                        if (userPhotoDirectory != null)
                        {
                            var files = FilesDisplay.GetFiles();
                            UserFile image = null;
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
                                            CreatedBy = user.Id,
                                            CreatedDate = DateTime.Now,
                                            DisplayName = f.FileDisplayName, //Path.GetFileName(imageFile.FileName)
                                            FileDirectory = DbHelper.StaticValues.UserImageDirectory,
                                                //StaticValue.UserImageDirectory
                                            FileName = fileName,
                                                //Guid.NewGuid().ToString() + GetExtension(imageFile.FileName, imageFile.ContentType)
                                            FileSizeInBytes = f.FileSizeInBytes, //imageFile.ContentLength
                                            FileType = f.FileType, //imageFile.ContentType
                                            IconPath = f.IconPath,
                                            SchoolId = user.SchoolId,
                                            IsServerFile = true,
                                            IsConstantAndNotEditable = false,
                                            FolderId = userPhotoDirectory.Id,
                                            //SubjectId = SubjectId,
                                        };
                                        if (f.Id > 0)
                                        {
                                            image.ModifiedBy = user.Id;
                                            image.ModifiedDate = DateTime.Now;
                                        }
                                    }
                                }

                            }

                            //var userRole = new Academic.DbEntities.User.UserRole()
                            //{
                            //    RoleId = Convert.ToInt32(ddlRole.SelectedValue),
                            //    UserId = UserId
                            //};

                            var savedUser = helper.AddOrUpdateUser(createdUser, ddlRole.SelectedValue, image);

                            if (savedUser != null)
                            {
                                if (UserId > 0)
                                {
                                    Response.Redirect("~/Views/User/Detail.aspx?uId=" + UserId);
                                }
                                else
                                {
                                    Response.Redirect("List.aspx");
                                }
                            }
                        }
                        else
                        {
                            //show error of "Folder unable to find"
                            lblSaveStatus.Text = "'User Photos' directory not found.";
                            lblSaveStatus.Visible = true;

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

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            if (UserId > 0)
            {
                Response.Redirect("~/Views/User/Detail.aspx?uId=" + UserId);
            }
            else
            { Response.Redirect("~/Views/User/List.aspx"); }
        }
    }
}