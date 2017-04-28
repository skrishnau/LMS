using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;
using Academic.ViewModel;

namespace One.Views.ActivityResource.Assignments
{
    public partial class AssignmentCheckCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblGradeError.Visible = false;
            lblError.Visible = false;
            var user = Page.User as CustomPrincipal;
            using (var ahelper = new DbHelper.ActAndRes())
                if (user != null)
                {
                    if (!IsPostBack)
                        try
                        {
                            FilesDisplay1.Enabled = false;
                            var actResId = Request.QueryString["actResId"];
                            var aId = Request.QueryString["actId"];
                            var subId = Request.QueryString["SubId"];
                            var secId = Request.QueryString["secId"];
                            var ucId = Request.QueryString["ucId"];//userclassId
                            var grdId = Request.QueryString["actGrdId"];

                            if (subId != null && secId != null && aId != null && ucId != null
                                && actResId != null && grdId != null)
                            {
                                SubjectId = Convert.ToInt32(subId);
                                SectionId = Convert.ToInt32(secId);
                                UserClassId = Convert.ToInt32(ucId);
                                ActivityResourceId = Convert.ToInt32(actResId);
                                ActivityGradingId = Convert.ToInt32(grdId);
                                var assId = Convert.ToInt32(aId);
                                ActivityId = assId;
                                LoadSubmission();
                                //PopulateClasses(ahelper, user);
                            }
                            else { Response.Redirect("~/"); }

                        }
                        catch { Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx"); }
                }
        }

        private void LoadSubmission()
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var userClassId = UserClassId;
                var actres = helper.GetActivityResource(ActivityResourceId);
                if (actres != null)
                {
                    var grd = (actres.ActivityGradings.FirstOrDefault(x => x.UserClassId == userClassId));
                    var ass = helper.GetAssignment(ActivityId);
                    if (ass != null)
                    {
                        var sub = ass.Submissions.FirstOrDefault(x => x.UserClassId == userClassId);
                        lblName.Text = ass.Name;
                        lblDescription.Text = ass.Description;


                        if (sub != null)
                        {

                            if (ass.FileSubmission)
                            {
                                var files = new List<FileResourceEventArgs>();
                                FilesDisplay1.NumberOfFilesToUpload = ass.MaximumNoOfUploadedFiles ?? 0;
                                var i = 1;
                                foreach (var f in sub.AssignmentSubmissionFiles)
                                {
                                    files.Add(new FileResourceEventArgs()
                                    {
                                        Id = f.UserFileId,
                                        Visible = true,
                                        FileType = f.UserFile.FileType,
                                        IconPath = f.UserFile.IconPath,
                                        FilePath = f.UserFile.FileDirectory + "/" + f.UserFile.FileName,
                                        FileDisplayName = f.UserFile.DisplayName,
                                        FileSizeInBytes = f.UserFile.FileSizeInBytes
                                        ,
                                        LocalId = i.ToString()
                                    });
                                    i++;
                                }
                                FilesDisplay1.SetInitialValues(files);
                            }
                            if (grd != null)
                            {
                                var user = grd.UserClass.User;
                                lblStudentName.Text = user.FirstName
                                                      + (string.IsNullOrEmpty(user.MiddleName)? "": " " + user.MiddleName)
                                                      + (string.IsNullOrEmpty(user.LastName) ? "" : " " + user.LastName);
                                lblEmail.Text = user.Email;
                                lblClassName.Text = grd.UserClass.SubjectClass.GetName;
                                var std = user.Student.FirstOrDefault();
                                if (std != null)
                                    lblRoll.Text = std.CRN;
                                txtRemarks.Text = grd.Remarks;
                            }
                            else
                            {
                                using (var clsHelper = new DbHelper.Classes())
                                {
                                    var uc= clsHelper.GetUserClass(userClassId);
                                    if (uc != null)
                                    {
                                        var user = uc.User;
                                        lblStudentName.Text = user.FirstName
                                                              + (string.IsNullOrEmpty(user.MiddleName) ? "" : " " + user.MiddleName)
                                                              + (string.IsNullOrEmpty(user.LastName) ? "" : " " + user.LastName);
                                        lblEmail.Text = user.Email;
                                        lblClassName.Text = uc.SubjectClass.GetName;
                                        var std = user.Student.FirstOrDefault();
                                        if (std != null)
                                            lblRoll.Text = std.CRN;
                                    }
                                    else
                                    {
                                        Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                                    }
                                }
                            }
                            if (ass.OnlineText)
                            {
                                pnlText.Visible = true;
                                txtSubmittedText.Text = sub.SubmissionText;
                                lblWordLimit.Text = "(Word limit : " + (ass.WordLimit ?? 0)
                                    + " words)";
                            }

                            if (ass.FileSubmission)
                            {
                                pnlFileSubmit.Visible = true;
                                lblFileLimit.Text = "(Maximum No. of files allowed : " + (ass.MaximumNoOfUploadedFiles ?? 0)
                                    + ",  Maximum file size : " + (ass.MaximumSubmissionSize ?? 0)
                                    + "KB)";

                                //each file load
                            }

                            if (ass.GradeType.RangeOrValue) //value
                            {
                                var values = ass.GradeType.GradeValues.ToList();
                                ddlGrade.Visible = true;
                                var lst = new List<Academic.DbEntities.Grades.GradeValue>();

                                var maxid = 0;
                                try
                                {
                                    maxid = Convert.ToInt32(ass.MaximumGrade);
                                }
                                catch { }
                                var max = values.FirstOrDefault(x => x.Id == maxid);
                                if (max != null)
                                {
                                    lblMaximumGrade.Text = max.Value;
                                    foreach (var gv in ass.GradeType.GradeValues)
                                    {
                                        if ((gv.EquivalentPercentOrPostition ?? 0).CompareTo(
                                            (max.EquivalentPercentOrPostition ?? 0)) <= 0)
                                        {
                                            lst.Add(gv);
                                        }

                                    }
                                }
                                var minid = 0;
                                try
                                {
                                    minid = Convert.ToInt32(ass.GradeToPass);
                                }
                                catch { }
                                var min = values.FirstOrDefault(x => x.Id == minid);
                                if (min != null)
                                {
                                    lblMinimumGradeToPass.Text = min.Value;
                                }

                                ddlGrade.DataSource = lst;
                                ddlGrade.DataBind();
                                if (grd != null)
                                {
                                    try
                                    {
                                        if ((grd.ObtainedGradeId ?? 0) > 0)
                                            ddlGrade.SelectedValue = (grd.ObtainedGradeId ?? 0).ToString();
                                    }
                                    catch { }
                                }
                            }
                            else//range
                            {
                                txtGrade.Visible = true;
                                lblMaximumGrade.Text = ass.MaximumGrade;
                                lblMinimumGradeToPass.Text = ass.GradeToPass;
                                if (grd != null)
                                {
                                    txtGrade.Text = (grd.ObtainedGradeMarks ?? 0).ToString("F");
                                }
                            }

                        }
                    }
                }
            }
        }

        public int ActivityId
        {
            get { return Convert.ToInt32(hidActivityId.Value); }
            set { hidActivityId.Value = value.ToString(); }
        }

        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }
        public int UserClassId
        {
            get { return Convert.ToInt32(hidUserClassId.Value); }
            set { hidUserClassId.Value = value.ToString(); }
        }
        public int ActivityResourceId
        {
            get { return Convert.ToInt32(hidActivityResourceId.Value); }
            set { hidActivityResourceId.Value = value.ToString(); }
        }
        public int ActivityGradingId
        {
            get { return Convert.ToInt32(hidActivityGradingId.Value); }
            set { hidActivityGradingId.Value = value.ToString(); }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            var user = Page.User as CustomPrincipal;



            if (user != null)
                using (var helper = new DbHelper.ActAndRes())
                {
                    var actGrading = new Academic.DbEntities.ActivityAndResource.ActivityGrading()
                    {
                        Id = ActivityGradingId
                        ,
                        ActivityResourceId = ActivityResourceId
                        ,
                        UserClassId = UserClassId
                        ,
                        Remarks = txtRemarks.Text
                    };
                    //grade value obtain
                    //check if textbox is visible or dropdown list is visible
                    var grade = "";
                    try
                    {
                        if (txtGrade.Visible)
                        {
                            //range
                            actGrading.ObtainedGradeMarks = (float)Convert.ToDecimal(txtGrade.Text);
                            var max = (float)Convert.ToDecimal(lblMaximumGrade.Text);
                            var min = (float)Convert.ToDecimal(lblMinimumGradeToPass.Text);
                            if (max.CompareTo(actGrading.ObtainedGradeMarks.Value) <= 0)
                            {
                                lblGradeError.Visible = true;
                            }
                            actGrading.ObtainedGradeId = null;
                            //if (actGrading.ObtainedGradeMarks.Value.CompareTo(min) <= 0)
                            //{
                            //    lblGradeError.Visible = true;
                            //}
                        }
                        else if (ddlGrade.Visible)
                        {
                            //values
                            actGrading.ObtainedGradeMarks = null;
                            actGrading.ObtainedGradeId = Convert.ToInt32(ddlGrade.SelectedValue);
                        }

                        if (ActivityGradingId > 0)
                        {
                            actGrading.ModifiedDate = date;
                            actGrading.ModifiedById = user.Id;
                        }
                        else
                        {
                            actGrading.GradedById = user.Id;
                            actGrading.GradedDate = date;
                        }

                    }
                    catch
                    {
                        lblGradeError.Visible = true;
                    }
                    var saved = helper.AddOrUpdateActivityGrading(actGrading);
                    if (saved != null)
                    {
                        //Return 
                        Response.Redirect("~/Views/ActivityResource/Assignments/AssignmentView.aspx" +
                                          "?SubId=" + SubjectId +
                                          "&arId=" + ActivityId +
                                          "&secId=" + SectionId +
                                          "&edit=0");
                    }
                    else
                    {
                        lblError.Visible = true;
                    }

                }

        }
    }
}