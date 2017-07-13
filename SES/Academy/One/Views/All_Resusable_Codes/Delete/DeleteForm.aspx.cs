using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.All_Resusable_Codes.Delete
{
    public partial class DeleteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    var encTask = Request.QueryString["task"];
                    if (encTask != null)
                    {
                        hidTask.Value = DbHelper.StaticValues.Decode(encTask);
                        var text = Request.QueryString["showText"];
                        if (text != null)
                        {
                            lblInfoText.Text = DbHelper.StaticValues.Decode(text);
                        }
                        else
                        {
                            LoadCustomText();

                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                    }


                }
            }
            catch { Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx"); }
        }

        private void LoadCustomText()
        {
            try
            {
                #region Activity Resource

                var actResId = Request.QueryString["actResId"];
                //var actOrRes = Request.QueryString["actOrRes"];
                //var actOrResId = Request.QueryString["actOrResId"];
                //var actResType = Request.QueryString["actResType"];
                if (actResId != null)//actOrRes != null && actOrResId != null && actResType != null)
                {
                    var displayType = "";
                    //var type = Convert.ToByte(actResType);
                    //var aOrRId = Convert.ToInt32(actOrResId);
                    using (var helper = new DbHelper.ActAndRes())
                    {
                        var actRes = helper.GetActivityResource(Convert.ToInt32(actResId));
                        if (actRes != null)
                        {

                            if (Convert.ToBoolean(actRes.ActivityOrResource)) //activity
                            {
                                switch (actRes.ActivityResourceType - 1)
                                {
                                    case (int)Enums.Activities.Assignment: //Assignment
                                        displayType = Enums.Activities.Assignment.ToString().ToLower();
                                        break;
                                    case (int)Enums.Activities.Chat: //chat
                                        displayType = Enums.Activities.Chat.ToString().ToLower();
                                        break;
                                    case (int)Enums.Activities.Forum: //forum
                                        displayType = Enums.Activities.Forum.ToString().ToLower();
                                        break;
                                    case (int)Enums.Activities.Choice:
                                        displayType = Enums.Activities.Choice.ToString().ToLower();
                                        break;
                                    case (int)Enums.Activities.Lession: //lession
                                        displayType = Enums.Activities.Lession.ToString().ToLower();
                                        break;
                                    case (int)Enums.Activities.Wiki: //wiki
                                        displayType = Enums.Activities.Wiki.ToString().ToLower();
                                        break;
                                    case (int)Enums.Activities.Workshop: //Workshop
                                        displayType = Enums.Activities.Workshop.ToString().ToLower();
                                        break;
                                }
                            }
                            else //resource
                            {
                                switch (actRes.ActivityResourceType - 1)
                                {
                                    case (int)Enums.Resources.Book: //Book
                                        displayType = Enums.Resources.Book.ToString().ToLower();
                                        break;
                                    case (int)Enums.Resources.File: //file
                                        displayType = Enums.Resources.File.ToString().ToLower();
                                        break;
                                    case (int)Enums.Resources.Folder:
                                        displayType = Enums.Resources.Folder.ToString().ToLower();
                                        break;
                                    case (int)(Enums.Resources.Label):
                                        displayType = Enums.Resources.Label.ToString().ToLower();
                                        break;
                                    case (int)(Enums.Resources.Page):
                                        displayType = Enums.Resources.Page.ToString().ToLower();
                                        break;
                                    case (int)(Enums.Resources.Url):
                                        displayType = Enums.Resources.Url.ToString().ToLower();
                                        break;
                                }
                            }
                            lblInfoText.Text = ("Are you sure to delete the " + displayType
                                                                                    + ", " + actRes.Name + "?");
                            //DbHelper.StaticValues.Decode
                        }

                    }
                    return;
                }


                #endregion

                #region Grade

                var gradeId = Request.QueryString["grdId"];
                if (gradeId != null)
                    using (var helper = new DbHelper.Grade())
                    {
                        var grade = helper.GetGrade(Convert.ToInt32(gradeId));
                        if (grade != null)
                        {
                            lblInfoText.Text = "Are you sure to delete the grade, " + grade.Name + "?";

                        }
                        return;
                    }

                #endregion

                #region Notice

                var noticeId = Request.QueryString["nId"];
                if (noticeId != null)
                {
                    using (var helper = new DbHelper.Notice())
                    {
                        var notice = helper.GetNotice(Convert.ToInt32(noticeId));
                        if (notice != null)
                        {
                            lblInfoText.Text = "Are you sure to delete the notice, " + notice.Title + "?";
                        }
                    }
                    return;
                }

                #endregion

                #region Academic year and SEssion

                var acaId = Request.QueryString["acaId"];
                if (acaId != null)
                    using (var helper = new DbHelper.AcademicYear())
                    {
                        var academic = helper.GetAcademicYear(Convert.ToInt32(acaId));
                        if (academic != null)
                        {
                            lblInfoText.Text = "Are you sure to delete the academic year, " + academic.Name + "?";
                        }
                        return;
                    }
                var sessId = Request.QueryString["sessId"];
                if (sessId != null)
                    using (var helper = new DbHelper.AcademicYear())
                    {
                        var session = helper.GetSession(Convert.ToInt32(sessId));
                        if (session != null)
                        {
                            lblInfoText.Text = "Are you sure to delete the session, " + session.Name + "?";
                        }
                        return;
                    }
                #endregion

                #region SubjectClass

                var subclsId = Request.QueryString["subclsId"];
                if (subclsId != null)
                {
                    using (var helper = new DbHelper.Classes())
                    {
                        var cls = helper.GetSubjectSession(Convert.ToInt32(subclsId));
                        if (cls != null)
                            lblInfoText.Text = "Are you sure to delete the class, " + (cls.IsRegular ? cls.GetName : cls.Name) + "?";
                    }
                    return;
                }

                #endregion

                #region Course and Category

                var catId = Request.QueryString["catId"];
                var crsId = Request.QueryString["crsId"];
                //crsId should be null so it means that its category only
                if (catId != null && crsId == null)
                {
                    using (var helper = new DbHelper.Subject())
                    {
                        var category = helper.GetCategory(Convert.ToInt32(catId));
                        if (category != null)
                            lblInfoText.Text = "Are you sure to delete the category, " + category.Name + "?";
                    }
                    return;
                }

                #endregion
            }
            catch { }
        }


        #region Course, category , section delete


        private void CourseDelete()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (user.IsInRole("manager") || user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor))
                {
                    var courseId = Request.QueryString["crsId"];
                    var categoryId = Request.QueryString["catId"];
                    if (courseId != null && categoryId != null)
                    {
                        var cId = Convert.ToInt32(courseId);
                        using (var courseHelper = new DbHelper.Subject())
                        {
                            var deleted = courseHelper.DeleteCourse(cId);
                            if (deleted)
                            {
                                Response.Redirect("~/Views/Course/?catId=" + categoryId, false);
                            }
                            else
                            {
                                lblError.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx?error=" +
                        DbHelper.StaticValues.GetEncodedError(1)
                        );
                }
        }

        private void CourseSectionDelete()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (user.IsInRole("manager")
                    || user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor)
                    || user.IsInRole("teacher"))
                {
                    var courseId = Request.QueryString["crsId"];
                    var sectionId = Request.QueryString["secId"];
                    if (courseId != null && sectionId != null)
                    {
                        var secId = Convert.ToInt32(sectionId);
                        using (var courseHelper = new DbHelper.Subject())
                        {
                            var deleted = courseHelper.DeleteSection(secId);
                            if (deleted)
                            {
                                Response.Redirect("~/Views/Course/Section/default.aspx?SubId=" + courseId
                                                    + "&edit=1", false);
                            }
                            else
                            {
                                lblError.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx?error=" +
                        DbHelper.StaticValues.GetEncodedError(1)
                        );
                }
        }

        private void ActivityResourceDelete()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (user.IsInRole("manager")
                    || user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor)
                    || user.IsInRole("teacher"))
                {
                    var courseId = Request.QueryString["crsId"];
                    var sectionId = Request.QueryString["secId"];
                    var actResId = Request.QueryString["actResId"];

                    if (courseId != null && sectionId != null && actResId != null)
                    {
                        var secId = Convert.ToInt32(sectionId);
                        var arId = Convert.ToInt32(actResId);
                        using (var actResHelper = new DbHelper.ActAndRes())
                        {
                            var deleted = actResHelper.DeleteActivityResource(arId);
                            if (deleted)
                            {
                                Response.Redirect("~/Views/Course/Section/default.aspx?SubId=" + courseId
                                                    + "&edit=1", false);
                            }
                            else
                            {
                                lblError.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx?error=" +
                        DbHelper.StaticValues.GetEncodedError(1)
                        );
                }
        }

        private void CourseCategoryDelete()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (user.IsInRole("manager") || user.IsInRole(DbHelper.StaticValues.Roles.CourseEditor))
                {
                    //var courseId = Request.QueryString["crsId"];
                    var categoryId = Request.QueryString["catId"];
                    if (categoryId != null)
                    {
                        var catId = Convert.ToInt32(categoryId);
                        using (var courseHelper = new DbHelper.Subject())
                        {
                            var deleted = courseHelper.DeleteCategory(catId);
                            if (deleted)
                            {
                                Response.Redirect("~/Views/Course/", false);
                            }
                            else
                            {
                                lblError.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx?error=" +
                        DbHelper.StaticValues.GetEncodedError(1)
                        );
                }
        }

        #endregion


        #region Batch

        private void BatchDelete()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (user.IsInRole("manager")
                    || user.IsInRole(DbHelper.StaticValues.Roles.Admitter))
                {
                    var batchId = Request.QueryString["batchId"];
                    if (batchId != null)
                    {
                        using (var helper = new DbHelper.Batch())
                        {
                            var deleted = helper.DeleteBatch(Convert.ToInt32(batchId));
                            if (deleted)
                            {
                                Response.Redirect("~/Views/Student/?edit=1", false);
                            }
                            else
                            {
                                lblError.Visible = true;
                            }
                        }
                    }
                }

        }

        #endregion

        #region Structure


        private void StructureDelete()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (user.IsInRole("manager")
                    || user.IsInRole(DbHelper.StaticValues.Roles.Admitter))
                {
                    var progId = Request.QueryString["progId"];
                    var yeaId = Request.QueryString["yeaId"];
                    var syeaId = Request.QueryString["syeaId"];


                    if (progId != null)
                    {
                        if (yeaId != null) //only year or subyear so check if year or sub-year
                        {
                            if (syeaId != null) //only subyear
                            {
                                DeleteSubYear(Convert.ToInt32(syeaId));
                            }
                            else //only year
                            {
                                DeleteYear(Convert.ToInt32(yeaId));
                            }
                        }
                        else //then only program so delete program
                        {
                            DeleteProgram(Convert.ToInt32(progId));
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                    }

                }

        }

        private void DeleteProgram(int programId)
        {
            using (var helper = new DbHelper.Structure())
            {
                var deleted = helper.DeleteProgram(programId);
                if (deleted)
                {
                    Response.Redirect("~/Views/Structure/?edit=1", false);
                }
                else
                {
                    lblError.Visible = true;
                }

            }
        }

        private void DeleteYear(int yearId)
        {
            using (var helper = new DbHelper.Structure())
            {
                var deleted = helper.DeleteYear(yearId);
                if (deleted)
                {
                    Response.Redirect("~/Views/Structure/?edit=1", false);
                }
                else
                {
                    lblError.Visible = true;
                }

            }
        }

        private void DeleteSubYear(int subYearId)
        {
            using (var helper = new DbHelper.Structure())
            {
                var deleted = helper.DeleteSubYear(subYearId);
                if (deleted)
                {
                    Response.Redirect("~/Views/Structure/?edit=1", false);
                }
                else
                {
                    lblError.Visible = true;
                }

            }
        }

        #endregion

        #region Grade

        private void GradeDelete()
        {
            using (var helper = new DbHelper.Grade())
            {
                var gradeId = Request.QueryString["grdId"];
                var deleted = helper.GradeDelete(Convert.ToInt32(gradeId));
                if (deleted)
                    Response.Redirect("~/Views/Grade/GradeListing.aspx?edit=1", false);
                else lblError.Visible = true;
            }
        }

        #endregion

        #region Notice

        private void NoiceDelete()
        {
            var noticeId = Request.QueryString["nId"];
            using (var helper = new DbHelper.Notice())
            {
                var deleted = helper.DeleteNotice(Convert.ToInt32(noticeId));
                if (deleted)
                    Response.Redirect("~/Views/NoticeBoard/NoticeListing.aspx", false);
                else lblError.Visible = true;
            }
        }

        #endregion

        #region Academic year and Session


        private void AcademicYearDelete()
        {
            var acaId = Request.QueryString["acaId"];
            using (var helper = new DbHelper.AcademicYear())
            {
                var deleted = helper.DeleteAcademicYear(Convert.ToInt32(acaId));
                if (deleted)
                    Response.Redirect("~/Views/Academy/", false);
                else lblError.Visible = true;
            }
        }
        //private void SessionDelete()
        //{
        //    var sessId = Request.QueryString["sessId"];
        //    var acaId = Request.QueryString["acaId"];
        //    using (var helper = new DbHelper.AcademicYear())
        //    {
        //        var deleted = helper.DeleteSession(Convert.ToInt32(sessId));
        //        if (deleted)
        //            Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" +
        //                              acaId + "&edit=1", false);
        //        else lblError.Visible = true;
        //    }
        //}
        #endregion


        #region SubjectClass

        private void SubjectClassDelete()
        {
            var subclsId = Request.QueryString["subclsId"];
            using (var helper = new DbHelper.Classes())
            {
                int subjectId = 0;
                var deleted = helper.DeleteSubjectClass(Convert.ToInt32(subclsId), ref subjectId);
                if (deleted)
                    Response.Redirect("~/Views/Course/CourseDetail.aspx?cId=" + subjectId, false);
                else lblError.Visible = true;
            }
        }

        #endregion

        protected void btnOk_OnClick(object sender, EventArgs e)
        {
            try
            {
                switch (hidTask.Value)
                {
                    case "courseCategory": //category delete
                        CourseCategoryDelete();
                        return;
                        break;

                    case "course": //course delete
                        CourseDelete();
                        return;
                        break;
                    case "courseSection": //section delete
                        CourseSectionDelete();
                        return;
                        break;
                    case "actRes":
                        ActivityResourceDelete();
                        return;
                        break;
                    case "batch":
                        BatchDelete();
                        return;
                        break;
                    case "structure":
                        StructureDelete();
                        return;
                        break;
                    case "grade":
                        GradeDelete();
                        return;
                        break;
                    case "notice":
                        NoiceDelete();
                        return;
                        break;
                    case "academicYear":
                        AcademicYearDelete();
                        return;
                        break;
                    case "session":
                        lblError.Text = "Session can't be deleted. ";
                        lblError.Visible = true;
                        //SessionDelete();
                        return;
                        break;
                    case "subjectClass":
                        SubjectClassDelete();
                        return;
                        break;
                }
            }
            catch
            {
                Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            try
            {
                switch (hidTask.Value)
                {
                    case "courseCategory": //category delete
                        var categoryId = Request.QueryString["catId"];
                        Response.Redirect("~/Views/Course/?catId=" + categoryId, false);
                        return;
                        break;

                    case "course": //course delete
                        var crsId = Request.QueryString["crsId"];
                        Response.Redirect("~/Views/Course/CourseDetail.aspx?cId=" + crsId, false);
                        return;
                        break;
                    case "courseSection": //section delete
                        var courseId = Request.QueryString["crsId"];
                        Response.Redirect("~/Views/Course/Section/default.aspx?SubId=" + courseId
                                                    + "&edit=1", false);
                        return;
                        break;
                    case "actRes":
                        var courseId1 = Request.QueryString["crsId"];
                        var red = "~/Views/Course/Section/default.aspx?SubId=" + courseId1
                                  + "&edit=1";
                        Response.Redirect(red, false);
                        return;
                        break;
                    case "batch":
                        Response.Redirect("~/Views/Student/?edit=1", false);
                        return;
                        break;

                    case "structure":
                        Response.Redirect("~/Views/Structure/?edit=1", false);
                        return;
                        break;
                    case "grade":
                        Response.Redirect("~/Views/Grade/GradeListing.aspx?edit=1", false);
                        return;
                        break;
                    case "notice":
                        var noticeId = Request.QueryString["nId"];
                        Response.Redirect("~/Views/NoticeBoard/NoticeDetail.aspx?nId=" + noticeId, false);
                        return;
                        break;
                    case "academicYear":
                        Response.Redirect("~/Views/Academy/?edit=1", false);
                        return;
                        break;
                    case "session":
                        var acaId = Request.QueryString["acaId"];
                        Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" +
                                     acaId + "&edit=1", false);
                        return;
                        break;
                    case "subjectClass":
                        var subclsId = Request.QueryString["subclsId"];
                        if (subclsId != null)
                        {
                            using (var helper = new DbHelper.Classes())
                            {
                                var cls = helper.GetSubjectSession(Convert.ToInt32(subclsId));
                                if (cls != null)
                                    Response.Redirect("~/Views/Course/CourseDetail.aspx?cId=" + (cls.IsRegular ? cls.SubjectStructure.SubjectId : cls.SubjectId), false);
                            }
                        }
                        return;
                        break;
                }
            }
            catch (Exception exe)
            {
                Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
            }
        }
    }
}