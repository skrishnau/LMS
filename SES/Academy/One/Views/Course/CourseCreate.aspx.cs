using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;
using Academic.DbEntities.Subjects;
using Academic.ViewModel;

namespace One.Views.Course
{
    public partial class CourseCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CreateUC.SaveClicked += CreateUC_SaveClicked;
            //CreateUC.CancelClicked += CreateUC_SaveClicked;
            lblError.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    this.txtName.Focus();
                    InitialSetup();
                }
                catch
                {
                    Response.Redirect("~/Views/Course/");
                }
            }
        }

        private void InitialSetup()
        {
            var catId = Request.QueryString["catId"];
            var courseId = Request.QueryString["crsId"];
            if (catId != null)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
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
                                Name = SiteMap.CurrentNode.ParentNode.Title
                                ,Value = SiteMap.CurrentNode.ParentNode.Url
                                ,Void=true
                            }
                            ,
                            new IdAndName(){
                                Name = "Course edit"
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    var categoryId = Convert.ToInt32(catId);
                    CategoryId = categoryId;
                    using (var helper = new DbHelper.Subject())
                    {
                        var category = helper.GetCategory(categoryId);

                        if (category != null)
                        {
                            if (category.SchoolId == user.SchoolId)
                            {
                                lblHeading.Text = "Add course in category : " + category.Name;
                                lblPageTitle.Text = "Add course";
                            }
                        }
                        else
                            Response.Redirect("~/Views/Course/");
                    }
                }
            }
            else if (courseId != null)
            {
                var cid = Convert.ToInt32(courseId);
                CourseId = cid;
                lblHeading.Text = "Course edit";
                lblPageTitle.Text = "Course edit";
                PopulateCourseData(cid);
            }
            else
                Response.Redirect("~/Views/Course/");
        }

        private void PopulateCourseData(int courseId)
        {
            using (var helper = new DbHelper.Subject())
            {

                var course = helper.GetCourse(courseId);
                if (course != null)
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
                                Name = SiteMap.CurrentNode.ParentNode.Title
                                ,Value = SiteMap.CurrentNode.ParentNode.Url
                                ,Void=true
                            }
                            ,
                            new IdAndName(){
                                Name = course.FullName
                                ,Value = "~/Views/Course/CourseDetail.aspx?cId="+course.Id
                                ,Void = true
                            }
                            ,new IdAndName()
                            {
                                Name="Edit"
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    txtName.Text = course.FullName;
                    txtShortName.Text = course.ShortName;
                    txtCode.Text = course.Code;
                    txtCredit.Text = course.Credit.ToString();
                    CKEditor1.Text = course.Summary;
                    CategoryId = CategoryId;
                }
            }
        }

        public int CategoryId
        {
            get { return Convert.ToInt32(hidCategoryId.Value); }
            set { hidCategoryId.Value = value.ToString(); }
        }

        public int CourseId
        {
            get { return Convert.ToInt32(hidCourseId.Value); }
            set { hidCourseId.Value = value.ToString(); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (Page.IsValid)
                {
                    Subject subject = new Subject()
                    {
                        Id = CourseId,
                        FullName = txtName.Text,
                        ShortName = txtShortName.Text,
                        Code = txtCode.Text,
                        Credit = Convert.ToInt32(string.IsNullOrEmpty(txtCredit.Text) ? "0" : txtCredit.Text),
                        SubjectCategoryId = CategoryId,
                        Summary = CKEditor1.Text
                    };

                    if (CourseId == 0)
                    {
                        subject.CreatedDate = DateTime.Now.Date;
                        subject.CreatedById = user.Id;
                    }
                    using (var helper = new DbHelper.Subject())
                    {
                        var saved = helper.AddOrUpdateSubject(subject);
                        if (saved)
                        {
                            if (CourseId > 0)
                                Response.Redirect("~/Views/Course/CourseDetail.aspx?cId=" + CourseId);
                            else
                            {
                                Response.Redirect("~/Views/Course/?catId=" + CategoryId);
                            }
                        }
                        else
                            lblError.Visible = true;
                    }
                }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CourseId == 0)
                Response.Redirect("~/Views/Course/?catId=" + CategoryId);
            else
                Response.Redirect("~/Views/Course/CourseDetail.aspx?cId=" + CourseId);
        }
    }


    //================================================== 

}
