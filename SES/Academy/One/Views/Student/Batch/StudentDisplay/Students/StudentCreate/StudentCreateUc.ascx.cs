using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;
using One.Values.MemberShip;
using System.IO;
using Academic.InitialValues;

namespace One.Views.Student.Batch.StudentDisplay.Students.StudentCreate
{
    public partial class StudentCreateUc : System.Web.UI.UserControl
    {

        public event EventHandler<MessageEventArgs> CloseClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            //lblSaveStatus.Visible = false;

            //==================== The commented code saves the uploaded file in Session in
            //==================== order to save the uploaded file upon postback
            //=================== The posted file is cleared upon postback.
            /*
            // store the FileUpload object in Session. 
            // "FileUpload1" is the ID of your FileUpload control
            // This condition occurs for first time you upload a file
            if (Session["FileUpload1"] == null && FileUpload1.HasFile)
            {
                Session["FileUpload1"] = FileUpload1;
                Label1.Text = FileUpload1.FileName; // get the name 
            }
            // This condition will occur on next postbacks        
            else if (Session["FileUpload1"] != null && (!FileUpload1.HasFile))
            {
                FileUpload1 = (FileUpload)Session["FileUpload1"];
                Label1.Text = FileUpload1.FileName;
            }
            //  when Session will have File but user want to change the file 
            // i.e. wants to upload a new file using same FileUpload control
            // so update the session to have the newly uploaded file
            else if (FileUpload1.HasFile)
            {
                Session["FileUpload1"] = FileUpload1;
                Label1.Text = FileUpload1.FileName;
            }
            */


            //if (!IsPostBack)
            //{
            //    //LoadDivisions();
            //    //DbHelper.ComboLoader.LoadGender(ref cmbGender);
            //    //DbHelper.ComboLoader.LoadSchool(ref cmbSchool, InitialValues.CustomSession["InstitutionId"]);
            //    // DbHelper.ComboLoader.LoadUserType(ref cmbRole, Values.Session.GetSchool(Session), "Student");
            //}
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var has1 = FileUpload1.HasFile;
            if (Page.IsValid)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    //List<int> DivisonsAssigned = new List<int>();
                    //using (var helper = new DbHelper.Student())
                    //{
                    //helper.
                    //}
                    //int role = (cmbRole.SelectedValue == "") ? 0 : Convert.ToInt32(cmbRole.SelectedValue.ToString());
                    //var dob = new DateTime(1900, 1, 1).Date;
                    //try
                    //{
                    //    if (txtDOB.Text != "")
                    //        dob = DateTime.Parse(txtDOB.Text);
                    //    dob = dob.Date;
                    //}
                    //catch { }

                    //var date = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
                    var createdUser = new Academic.DbEntities.User.Users()
                    {
                        //City = txtCity.Text
                        //,
                        //Country = txtCountry.Text
                        //,
                        CreatedDate = DateTime.Now
                        ,
                        Email = txtEmail.Text
                        ,
                        FirstName = txtFirstName.Text
                        ,
                        LastName = txtLastName.Text
                        ,
                        //GenderId = Convert.ToByte(cmbGender.SelectedValue)
                        //,
                        IsActive = true
                        ,
                        IsDeleted = false
                        ,
                        UserName = txtUserName.Text
                        ,
                        Password = txtPassword.Text
                        ,
                        Phone = txtPhone1.Text
                        ,
                        MiddleName = txtMiddleName.Text
                    };
                    var student = new Academic.DbEntities.Students.Student()
                    {
                        CRN = txtCRN.Text,
                        //CreatedUserId =
                        //ExamRollNoGlobal = txtExamRoll.Text,
                        //GuardianContactNo = txtGuarContact.Text,
                        //GuardianEmail = txtGuarEmail.Text,
                        //GuardianName = txtGuarName.Text

                    };


                    //createdUser.DOB = DateTime.Parse(dob.Date.ToShortDateString());
                    //var SchoolId = Values.Session.GetSchool(Session);
                    createdUser.SchoolId = user.SchoolId;
                    using (var helper = new DbHelper.Student())
                    //using (var batchHelper = new DbHelper.Batch())
                    {
                        var saved = helper.AddOrUpdateStudent(createdUser, student, ProgramBatchId);

                        if (saved != null)
                        {

                            #region file save

                            SaveFile(user.Id, saved);

                            #endregion


                            //lblSaveStatus.Text = ("Save Successful.");
                            Button btn = (Button)sender;
                            if (btn.ID == "btnSaveNAddMore")
                            {
                                //lblSaveStatus.Visible = true;
                                ResetTextAndCombos();
                            }
                            else
                            {
                                if (CloseClicked != null)
                                {
                                    CloseClicked(this, StaticValues.CancelClickedMessageEventArgs);
                                }
                            }
                        }
                        //else
                        //{
                        //    lblSaveStatus.Visible = true;
                        //    lblSaveStatus.Text = "Couldn't Save.";
                        //}
                    }
                }


            }
        }


        private void SaveFile(int userId, Academic.DbEntities.User.Users savedUser)
        {
            using (var helper = new DbHelper.User())
            {
                //var savedUser = helper.AddOrUpdateUser(createdUser, cmbRole.SelectedValue, FileUpload1.PostedFile);

                //if (savedUser != null)
                //{
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
                        CreatedBy = userId
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
                //}

                //Label label = (Label)this.Page.FindControl("lblBodyMessage");
                //if (label != null)
                //{
                if (savedUser != null)
                {
                    //label.Text = "Save Successful.";
                    //Page.Response.Redirect("List.aspx");

                    ResetTextAndCombos();
                }
                //else
                //    label.Text = "Error while saving.";
                //}
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





        private void ResetTextAndCombos()
        {
            //txtMidName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            //txtDOB.Text = "";
            //txtCity.Text = "";
            //txtCountry.Text = "";
            //txtStreet.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtPhone1.Text = "";
            //cmbSchool.SelectedValue = "0";
            //cmbGender.SelectedValue = "0";

        }



        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { hidProgramBatchId.Value = value.ToString(); }
        }
        //public int SchoolId
        //{
        //    get { return Convert.ToInt32(hidSchoolId.Value); }
        //    set { hidSchoolId.Value = value.ToString(); }
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CloseClicked != null)
                CloseClicked(this, StaticValues.CancelClickedMessageEventArgs);
        }
    }
}