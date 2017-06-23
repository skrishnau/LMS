using Academic.DbHelper;
using Academic.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values.MemberShip;

namespace One.Views.Student.Batch.Student
{
    public partial class StudentCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //StudentCreateUc1.CloseClicked += StudentCreateUc1_CloseClicked;
            //StudentCreateUc1.SaveClicked += StudentCreateUc1_CloseClicked;
            lblSaveError.Text = "Couldn't save";
            lblSaveError.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    var pbId = Request.QueryString["pbId"];
                    //var bId = Request.QueryString["bId"];
                    if (pbId != null)
                    {
                        var pbatchId = Convert.ToInt32(pbId);
                        //BatchId = Convert.ToInt32(bId);
                        ProgramBatchId = pbatchId;
                        //StudentCreateUc1.ProgramBatchId = pbatchId;

                        #region Get program batch name from database and populate sitemap

                        using (var helper = new DbHelper.Batch())
                        {
                            var editQuery = Request.QueryString["edit"];
                            var edit = (editQuery ?? "0").ToString();
                            var pbatch = helper.GetProgramBatch(pbatchId);
                            if (pbatch != null)
                            {
                                if (SiteMap.CurrentNode != null)
                                {
                                    var list = new List<IdAndName>()
                                            {
                                               new IdAndName(){
                                                            Name=SiteMap.RootNode.Title
                                                            ,Value =  SiteMap.RootNode.Url
                                                            ,Void=true
                                                        },
                                                          new IdAndName(){
                                                    Name = SiteMap.CurrentNode.ParentNode.ParentNode.ParentNode.ParentNode.Title
                                                    ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.ParentNode.ParentNode.Url
                                                    ,Void=true
                                                },
                                                new IdAndName(){
                                                    Name = pbatch.Batch.AcademicYear.Name
                                                    ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.ParentNode.Url+"?aId="+pbatch.Batch.AcademicYear.Id+"&edit="+edit
                                                    ,Void=true
                                                }
                                                , new IdAndName()
                                                {
                                                    Name = pbatch.Batch.Name
                                                    ,Value=SiteMap.CurrentNode.ParentNode.ParentNode.Url+"?Id="+pbatch.BatchId+"&edit="+edit
                                                    ,Void=true
                                                }
                                                , new IdAndName()
                                                {
                                                    Name = pbatch.Program.Name
                                                    ,Value=SiteMap.CurrentNode.ParentNode.Url+"?pbId="+pbatch.Id+"&edit="+edit                                                
                                                    ,Void = true
                                                }
                                                ,new IdAndName(){Name = "Student edit"}
                                            };
                                    SiteMapUc.SetData(list);
                                }
                            }
                        }

                        #endregion

                    }
                    else
                    {
                        Response.Redirect("~/Views/Student/");
                    }
                }
                catch
                {
                    Response.Redirect("~/Views/Student/");
                }

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.Student())
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    if (helper.DoesUserNameExist(user.SchoolId, txtUserName.Text))
                    {
                        valiUserName.ErrorMessage = "Username already exits";
                        valiUserName.IsValid = false;
                    }
                    if (Page.IsValid)
                    {
                        var createdUser = new Academic.DbEntities.User.Users()
                        {
                            CreatedDate = DateTime.Now
                            ,
                            Email = txtEmail.Text
                            ,
                            FirstName = txtFirstName.Text
                            ,
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
                            Phone = txtPhone1.Text
                            ,
                            MiddleName = txtMiddleName.Text
                        };
                        var student = new Academic.DbEntities.Students.Student()
                        {
                            CRN = txtCRN.Text,
                        };

                        createdUser.SchoolId = user.SchoolId;

                        var saved = helper.AddOrUpdateStudent(createdUser, student, ProgramBatchId);

                        if (saved != null)
                        {
                            //file save
                            SaveFile(user.Id, user.SchoolId, saved);

                            Button btn = (Button)sender;
                            if (btn.ID == "btnSaveNAddMore")
                            {
                                //lblSaveStatus.Visible = true;
                                ResetTextAndCombos();
                                //if (SaveClicked != null)
                                //{

                                //    SaveClicked(this, new MessageEventArgs());
                                //}
                            }
                            else if (btn.ID == "btnCancel")
                            {
                                GoBackToProgramBatch();
                                //if (CloseClicked != null)
                                //{
                                //    CloseClicked(this, DbHelper.StaticValues.CancelClickedMessageEventArgs);
                                //}
                            }
                            else
                            {
                                GoBackToProgramBatch();
                                //if (SaveClicked != null)
                                //{
                                //    SaveClicked(this, new MessageEventArgs() { Message = "close" });
                                //}
                            }
                        }
                        else
                        {
                            lblSaveError.Visible = true;
                            lblSaveError.Text = "Couldn't Save.";
                        }
                    }
                }


            }
        }

        private void SaveFile(int userId, int schoolId, Academic.DbEntities.User.Users savedUser)
        {
            using (var helper = new DbHelper.User())
            using (var fileHelper = new DbHelper.WorkingWithFiles())
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

                    var userPhotoFolder = fileHelper.GetUserPhotoFolder(schoolId);
                    if (userPhotoFolder != null)
                    {
                        var image = new Academic.DbEntities.UserFile()
                        {
                            CreatedBy = userId
                            ,
                            CreatedDate = DateTime.Now
                            ,
                            DisplayName = Path.GetFileName(imageFile.FileName)
                            ,
                            FileDirectory = DbHelper.StaticValues.UserImageDirectory
                            ,
                            FileName =
                                Guid.NewGuid().ToString() + GetExtension(imageFile.FileName, imageFile.ContentType)
                            ,
                            FileSizeInBytes = imageFile.ContentLength
                            ,
                            FileType = imageFile.ContentType
                            ,
                            IsServerFile = true
                            ,
                            SchoolId = schoolId
                            ,
                            FolderId = userPhotoFolder.Id
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
                                    var path = Path.Combine(Server.MapPath(DbHelper.StaticValues.UserImageDirectory),
                                        image.FileName);
                                    imageFile.SaveAs(path);

                                    //add the image Id to user 
                                    helper.UpdateUsersImage(savedUser.Id, savedFile.Id);
                                }
                            }
                        }
                    }
                    else
                    {

                        lblSaveError.Visible = true;
                        lblSaveError.Text = "'User Photos' directory not found.";

                    }
                    if (savedUser != null)
                    {
                        ResetTextAndCombos();
                    }
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

        private void GoBackToProgramBatch()
        {
            var editQuery = Request.QueryString["edit"];
            var edit = (editQuery ?? "0").ToString();
            Response.Redirect("~/Views/Student/Batch/Student/?pbId=" + ProgramBatchId + "&edit=" + edit);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GoBackToProgramBatch();
            //if (CloseClicked != null)
            //    CloseClicked(this, DbHelper.StaticValues.CancelClickedMessageEventArgs);
        }
        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { hidProgramBatchId.Value = value.ToString(); }
        }
        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { hidBatchId.Value = value.ToString(); }
        }
    }
}