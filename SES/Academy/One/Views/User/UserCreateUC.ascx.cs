using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.InitialValues;
using One.Values.MemberShip;
using System.IO;

namespace One.Views.User
{
    public partial class UserCreateUC : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            string editMode = "";

            if (!IsPostBack)
            {
                DbHelper.ComboLoader.LoadGender(ref cmbGender);
                DateChooser1.Validate = false;
                cmbEmailDisplay.DataSource = Values.Enums.GetDisplayModes();
                cmbEmailDisplay.DataBind();
                cmbEmailDisplay.SelectedIndex = 1;

                if (Values.Session.GetUser(Session) == 0)
                {
                    editMode = "New";
                }
                else
                {
                    if (
                        Values.Session.GetUserCapability(Session)
                            .Contains(Values.Enums.UserCapabilities.UserCreate.ToString()))
                    {

                        //check for update not done
                        editMode = EditMode;
                    }
                    else
                    {
                        switch (EditMode)
                        {
                            case "ProfileEdit":
                                editMode = EditMode;
                                break;
                            case "Update":
                                editMode = EditMode;
                                break;
                        }
                    }
                }
                switch (editMode)
                {
                    case "New":
                        DbHelper.ComboLoader.LoadRole(ref cmbRole, Values.Session.GetSchool(Session), "Admin");
                        cmbRole.Enabled = false;
                        break;
                    case "Create":
                        DbHelper.ComboLoader.LoadRole(ref cmbRole, Values.Session.GetSchool(Session), "");

                        break;
                    case "ProfileEdit":
                        // DbHelper.ComboLoader.LoadRole(ref cmbRole,Values.Session.GetSchool(Session),Values.Session.GetUserRole());

                        cmbRole.Enabled = false;
                        break;
                    case "Update":
                        //have logic here (if already user is active don't give to update role)
                        break;
                }

            }
        }


        #region Properties

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        public int RoleId
        {
            get
            {
                if (cmbRole.Items.Count == 0)
                {
                    DbHelper.ComboLoader.LoadRole(ref cmbRole, Values.Session.GetSchool(Session), "");
                }
                return Convert.ToInt32((String.IsNullOrEmpty(cmbRole.SelectedValue)) ? "0" : cmbRole.SelectedValue);
            }
            set
            {
                if (cmbRole.Items.Count == 0)
                {
                    DbHelper.ComboLoader.LoadRole(ref cmbRole, Values.Session.GetSchool(Session), value);
                }
                else
                {
                    cmbRole.SelectedValue = value.ToString();
                }
            }
        }

        public string RoleName
        {
            get
            {
                if (cmbRole.Items.Count == 0)
                {
                    DbHelper.ComboLoader.LoadRole(ref cmbRole, Values.Session.GetSchool(Session), "");
                }
                return cmbRole.SelectedItem.Text;
                //Convert.ToInt32(String.IsNullOrEmpty(cmbRole.SelectedValue) ? "0" : cmbRole.SelectedValue);
            }
            set
            {
                if (cmbRole.Items.Count == 0)
                {
                    DbHelper.ComboLoader.LoadRole(ref cmbRole, Values.Session.GetSchool(Session), value);
                }
                else
                {
                    var item = cmbRole.Items.FindByText(value);
                    if (item != null)
                    {
                        cmbRole.SelectedValue = item.Value;
                    }
                }
            }
        }

        public string EditMode
        {
            get { return this.hidEditMode.Value; }
            set { this.hidEditMode.Value = value; }
        }

        #endregion




        #region Functions

        protected Page GetParentPage(Control control)
        {
            if (control.Parent is Page)
                return (Page)control.Parent;

            return GetParentPage(control.Parent);
        }

        private void ResetTextAndCombos()
        {
            txtMidName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtStreet.Text = "";
            txtEmail.Text = "";
            //txtJobTitle.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtPhone1.Text = "";
            //cmbSchool.SelectedValue = "0";
            //cmbGender.SelectedValue = "0";

            DateChooser1.ResetDate();
            txtCountry.Text = "";
            txtCity.Text = "";
            txtStreet.Text = "";

        }

        #endregion

        #region Events save, etc.

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //bool isValid = (RequiredFieldValidator3.IsValid
            //                && RequiredFieldValidator6.IsValid
            //                && RequiredFieldValidator7.IsValid);
            //if()

            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (Page.IsValid)
                {
                    //List<int> DivisonsAssigned = new List<int>();
                    //using (var helper = new DbHelper.Student())
                    //{
                    //    //helper.
                    //}
                    int role = (cmbRole.SelectedValue == "") ? 0 : Convert.ToInt32(cmbRole.SelectedValue.ToString());
                    var dob = DateTime.MinValue;
                    try
                    {
                        if (DateChooser1.SelectedDate != DateTime.MinValue)
                            dob = (DateChooser1.SelectedDate).Date;
                    }
                    catch { }
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
                        Description = txtDescription.Text
                        ,
                        EmailDisplay = cmbEmailDisplay.SelectedValue
                    };
                    if (!(cmbGender.SelectedValue == "0" || cmbGender.SelectedValue != ""))
                    {
                        createdUser.GenderId = Convert.ToInt32(cmbGender.SelectedValue);
                    }
                    if (dob != DateTime.MinValue)
                        createdUser.DOB = dob;
                    //var SchoolId = Values.Session.GetSchool(Session); // Convert.ToInt32(cmbSchool.SelectedValue);
                    //if (SchoolId > 0)
                    //{
                    //    createdUser.SchoolId = SchoolId;
                    //}
                    //foreach (ListItem divisions in CheckBoxList1.Items)
                    //{
                    //    if (divisions.Selected)
                    //    {
                    //        DivisonsAssigned.Add(Convert.ToInt32(divisions.Value));
                    //    }
                    //}
                    using (var helper = new DbHelper.User())
                    {
                        var savedUser = helper.AddOrUpdateUser(createdUser, cmbRole.SelectedValue, FileUpload1.PostedFile);

                        if (savedUser != null)
                        {
                            //public bool UploadToFolder(HttpPostedFileBase file)
                            //{
                            //    var filename = Path.GetFileName(file.FileName);
                            //    var path = Path.Combine(Server.MapPath("~/Content/Upload"), filename);
                            //    file.SaveAs(path);
                            //    return true;
                            //}

                            //save image
                            //first entry to database : table File --its image
                            if (FileUpload1.HasFile)
                            {
                                var imageFile = FileUpload1.PostedFile;


                                var image = new Academic.DbEntities.UserFile()
                                {
                                    CreatedBy = user.Id
                                    ,
                                    CreatedDate = DateTime.Now
                                    ,
                                    DisplayName = Path.GetFileName(imageFile.FileName)
                                    ,
                                    FileDirectory = StaticValue.UserImageDirectory
                                    ,
                                    FileName = Guid.NewGuid().ToString() + GetExtension(imageFile.FileName, imageFile.ContentType)
                                    ,
                                    FileSizeInBytes = imageFile.ContentLength
                                    ,
                                    FileType = imageFile.ContentType
                                    ,
                                };
                                using (var fhelper = new DbHelper.WorkingWithFiles())
                                {
                                    GetNewGuid(fhelper, image);
                                    //TrimFirstLetterFromImageFileName(image);
                                    if (trimLoop > 9 || guidLoop > 9)
                                    {
                                        //cancel all save
                                    }
                                    else
                                    {
                                        var savedFile = fhelper.AddOrUpdateFile(image);

                                        if (savedFile != null)
                                        {
                                            //save the image with this name
                                            //var filename = Path.GetFileName(file.FileName);
                                            var path = Path.Combine(Server.MapPath(StaticValue.UserImageDirectory),
                                                image.FileName);
                                            imageFile.SaveAs(path);

                                            //add the image Id to user 
                                            helper.UpdateUsersImage(savedUser.Id, savedFile.Id);


                                            //    return true;
                                        }

                                    }

                                }

                            }
                        }

                        //Label label = (Label)this.Page.FindControl("lblBodyMessage");
                        //if (label != null)
                        {
                            if (savedUser != null)
                            {
                                //label.Text = "Save Successful.";
                                Page.Response.Redirect("List.aspx");
                                ResetTextAndCombos();
                            }
                            //else
                            //    label.Text = "Error while saving.";
                        }
                    }

                    //lblSaveStatus.Text = ("Save Successful.");
                    //lblSaveStatus.Visible = true;

                }


        }

        public string GetExtension(string fileName, string contentType)
        {
            //var ent = Context.File.Find(imageId);

            int dotpos = 0;
            int slashPos = 0;
            try
            {
                dotpos = fileName.LastIndexOf(".");
            }
            catch
            {
                try
                {
                    slashPos = contentType.IndexOf("/");
                }
                catch
                {
                    return "";
                }
            }
            if (dotpos != 0)
            {
                var extension = fileName.Substring(dotpos + 1);
                return "." + extension;
            }
            else if (slashPos != 0)
            {
                var extension = contentType.Substring(slashPos + 1);
                return "." + extension;
            }
            return "";

        }


        private int guidLoop = 0;
        int trimLoop = 0;

        private void GetNewGuid(DbHelper.WorkingWithFiles fhelper, Academic.DbEntities.UserFile image)
        {
            //var existingFile = Context.File.FirstOrDefault(x => x.FileName == image.FileName);

            if (guidLoop < 10)
            {
                if (fhelper.DoesFileExists(image.FileName))
                {
                    image.FileName = Guid.NewGuid().ToString() + GetExtension(image.DisplayName, image.FileType);//.GetHashCode().ToString();
                    GetNewGuid(fhelper, image);
                    TrimFirstLetterFromImageFileName(fhelper, image);
                }
                guidLoop++;
            }

        }



        private void TrimFirstLetterFromImageFileName(DbHelper.WorkingWithFiles fhelper, Academic.DbEntities.UserFile image)
        {
            if (trimLoop < 10)
            {
                if (!char.IsLetterOrDigit(image.FileName[0]))
                {
                    image.FileName = image.FileName.Substring(1);
                    TrimFirstLetterFromImageFileName(fhelper, image);
                    GetNewGuid(fhelper, image);
                }
                trimLoop++;
            }

        }


        #endregion


       


        protected void txtInterest_TextChanged(object sender, EventArgs e)
        {
            //if(e.)
        }


    }
}