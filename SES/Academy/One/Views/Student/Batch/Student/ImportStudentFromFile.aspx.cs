using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using LinqToExcel;
using LinqToExcel.Query;
using One.Values.MemberShip;

namespace One.Views.Student.Batch.Student
{
    public partial class ImportStudentFromFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorLoadingMessage.Visible = false;

            file_upload.Style.Add("visibility", " hidden");
            if (!IsPostBack)
            {
                FilesDisplay1.FileAcquireMode = Enums.FileAcquireMode.Basic;
                LoadData();
                FilesDisplay1.FileSaveDirectory = Academic.DbHelper.DbHelper.StaticValues.PrivateFiesLocation;
                FilesDisplay1.FileExtension = ".xls, .xlsx, .csv";
                SetPageKey();
            }
            FilesDisplay1.FileUploaded += FilesDisplay1_FileUploaded;
        }

        public string PageKey
        {
            get { return hidPageKey.Value.ToString(); }
            set { hidPageKey.Value = value; }
        }

        private void SetPageKey()
        {
            var key = Guid.NewGuid().ToString();
            PageKey = key;
        }

        void FilesDisplay1_FileUploaded(object sender, Academic.ViewModel.IdAndNameEventArgs e)
        {
            //read file
            ReadExcelFile(e.RefIdString);
        }

        void LoadData()
        {
            var programBatchId = Request.QueryString["pbId"];
            if (programBatchId != null)
            {
                int pbatchId = Convert.ToInt32(programBatchId);
                ProgramBatchId = pbatchId;
                using (var helper = new DbHelper.Batch())
                {
                    var pbatch = helper.GetProgramBatch(pbatchId);
                    if (pbatch != null)
                    {
                        var pbName = pbatch.NameFromBatch;
                        lblProgramBatchName.Text = pbName;
                    }
                }
            }
            else
            {
                Response.Redirect("~/Views/Academy/List.aspx");
            }
        }

        protected void file_upload_OnUploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {


        }

        public string FileSaveDirectory
        {
            get { return hidFileSaveDirectory.Value; }
            set { hidFileSaveDirectory.Value = value; }
        }

        void ReadExcelFile(string filePath)
        {
            try
            {
                var excel = new ExcelQueryFactory();
                var path = Server.MapPath(filePath);
                excel.FileName = path;//filePath;

                //try
                //{
                //}
                //catch
                //{
                //    lblErrorLoadingMessage.Text = "'CRN' column not found in the file";
                //    lblErrorLoadingMessage.Visible = true;
                //}

                //try
                //{

                //}
                //catch
                //{
                //    lblErrorLoadingMessage.Text = "'Name' column not found in the file";
                //    lblErrorLoadingMessage.Visible = true;
                //}


                excel.AddMapping<Academic.DbEntities.Students.Student>(x => x.CRN, "CRN");
                excel.AddMapping<Academic.DbEntities.Students.Student>(x => x.Name, "Name");



                var students = from x in excel.Worksheet<Academic.DbEntities.Students.Student>()
                               where !string.IsNullOrEmpty(x.CRN) && !string.IsNullOrEmpty(x.Name)
                               select x;
                //save all the students
                var dts = students.ToList();

                CheckForUniqueUsername(dts);

                GridView1.DataSource = dts;
                GridView1.DataBind();

                pnlSave.Visible = true;

                Session["studentsList" + PageKey] = dts;

                lblGridViewHeader.Visible = true;
            }
            catch
            {
                lblErrorLoadingMessage.Text = "Read error";
            }

        }

        private void CheckForUniqueUsername(List<Academic.DbEntities.Students.Student> dts)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                using (var helper = new Academic.DbHelper.DbHelper.User())
                {
                    foreach (var student in dts)
                    {
                        student.Void = helper.DoesUserNameExist(user.SchoolId, student.CRN);
                    }
                }
        }

        public Color GetColor(object Void)
        {
            if (Convert.ToBoolean(Void ?? "False"))
            {
                return Color.Red;
            }
            return Color.DarkSlateGray;
            //if(Void!=null && Void.ToString()== "False")
            //{
            //    if(Convert)
            //    return Color.Red;
            //}
        }

        private void GoBackToProgramBatch()
        {
            var editQuery = Request.QueryString["edit"];
            var edit = (editQuery ?? "0").ToString();
            Response.Redirect("~/Views/Student/Batch/Student/?pbId=" + ProgramBatchId + "&edit=" + edit);
        }

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { hidProgramBatchId.Value = value.ToString(); }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            SaveStudents();
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            GoBackToProgramBatch();
        }

        protected void SaveStudents()
        {
            using (var helper = new DbHelper.Student())
            {
                var user = Page.User as CustomPrincipal;
                var usersList = new List<Academic.DbEntities.User.Users>();
                var studentsList = new List<Academic.DbEntities.Students.Student>();

                var stds = Session["studentsList" + PageKey] as List<Academic.DbEntities.Students.Student>;

                //GridView1.DataSource as List<Academic.DbEntities.Students.Student>;


                if (user != null)
                {
                    if (stds != null)
                    {
                        var unVoided = stds.Where(x => !(x.Void ?? false)).ToList();
                        if (!unVoided.Any())
                        {
                            lblSaveError.Visible = true;
                            lblSaveError.Text = "The list doesn't contain any unique students";
                            return;
                        }
                        foreach (var std in unVoided)
                        {
                            var usr = new Academic.DbEntities.User.Users()
                            {
                                CreatedDate = DateTime.Now,
                                FirstName = std.Name,
                                IsActive = true,
                                IsDeleted = false,
                                UserName = std.CRN,
                                Password = std.Name,
                                SchoolId = user.SchoolId
                            };
                            var student = new Academic.DbEntities.Students.Student()
                            {
                                CRN = std.CRN,
                            };
                            usersList.Add(usr);
                            studentsList.Add(student);
                        }
                        var saved = helper.AddOrUpdateStudents(usersList, studentsList, ProgramBatchId);
                        if (saved)
                        {
                            GoBackToProgramBatch();
                        }
                        else
                        {
                            lblSaveError.Visible = true;
                            lblSaveError.Text = "Couldn't Save.";
                        }
                    }
                    else
                    {
                        lblSaveError.Visible = true;
                        lblSaveError.Text = "Couldn't Save. Student data is null. Please try again";
                    }
                }
            }
        }

    }
}