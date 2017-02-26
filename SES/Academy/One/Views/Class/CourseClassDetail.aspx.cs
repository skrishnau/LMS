using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.Class
{
    public partial class CourseClassDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var classId = Request.QueryString["ccId"];
                if (classId != null)
                {
                    var clsId = Convert.ToInt32(classId);
                    SubjectClassId = clsId;
                    hidSubjectSessionId.Value = classId;

                    using (var helper = new DbHelper.Classes())
                    {
                        var cls = helper.GetSubjectSession(clsId);
                        if (cls != null)
                        {
                            //lblStartDate.Text =cls.StartDate==null?" - ": cls.StartDate.Value.ToString("D");
                            //lblEndDate.Text = cls.EndDate==null?" - ":cls.EndDate.Value.ToString("D");
                            var clsname = cls.GetName;
                            var coursefullname = cls.GetCourseFullName;
                            lblTitle.Text = clsname;
                            lblEnrollmentMethod.Text = cls.EnrollmentMethod == 0
                                ? "Auto"
                                : (cls.EnrollmentMethod == 1) ? "Manual" : "Self";
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
                                        Name = SiteMap.CurrentNode.ParentNode.ParentNode.Title
                                        ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url
                                        ,Void=true
                                    },
                                    new IdAndName(){
                                        Name = cls.GetCourseFullName
                                        ,Value = SiteMap.CurrentNode.ParentNode.Url+"?cId="+(cls.GetCourseId)
                                        ,Void=true
                                    }
                                    ,
                                    new IdAndName()
                                    {
                                        Name = clsname
                                    }
                                };
                                SiteMapUc.SetData(list);
                            }
                            lnkReport.NavigateUrl = "~/Views/Report/?ccId="+cls.Id;
                            lblClassName.Text = clsname;//cls.IsRegular ? cls.GetName : cls.Name;
                            lblCourseName.Text = coursefullname;//cls.IsRegular
                                //? cls.SubjectStructure.Subject.FullName
                                //: cls.Subject.FullName;

                            
                            lblEndDate.Text = cls.EndDate==null ? " - ":cls.EndDate.Value.ToString("D");
                            lblStartDate.Text = cls.StartDate == null ? " - " : cls.StartDate.Value.ToString("D");


                            //lblEnrollmentMethod.Text = cls.
                            
                            var grp = "No grouping";
                            if (cls.HasGrouping)
                            {
                                grp = "";
                                cls.SubjectClassGrouping.ToList().ForEach(c =>
                                {
                                    grp += cls.Name + ", ";
                                });
                                grp = grp.TrimEnd(new char[]{','});
                            }
                            lblGrouping.Text = grp;
                            ListView1.DataSource = helper.ListSubjectSessionEnrolledUsers(clsId);
                            ListView1.DataBind();
                        }
                        
                    }
                }
            }
        }

        public int SubjectClassId
        {
            get { return Convert.ToInt32(hidSubjectSessionId.Value); }
            set { hidSubjectSessionId.Value = value.ToString(); }
        }

        public string GetImageUrl(object imageId)
        {
            if (imageId != null)
            {
                var id = Convert.ToInt32(imageId.ToString());
                using (var helper = new DbHelper.WorkingWithFiles())
                {
                    return helper.GetImageUrl(id);
                }
            }
            return "";
        }

        public string GetName(object first, object mid, object last)
        {
            string name = "";
            if (first != null)
            {
                name += first.ToString();
                if (mid != null)
                {
                    name += " " + mid.ToString();

                }
                if (last != null)
                {
                    name += " " + last.ToString();
                }
            }
            return name;
        }
        public string GetLastOnline(object onlineDate)
        {
            if (onlineDate != null)
            {
                try
                {
                    var date = Convert.ToDateTime(onlineDate.ToString());
                    var difference = DateTime.Now.Subtract(date);// - date;

                    var days = (difference.Days > 0) ?
                        (difference.Days == 1) ? "a Day " : difference.Days + " Days " : "";
                    if (days != "")
                    {
                        return days + "ago";
                    }

                    var hours = (difference.Hours != 0) ? (difference
                        .Hours == 1) ? "an Hour " : difference.Hours + " Hours " : "";
                    if (hours != "")
                    {
                        return hours + "ago";
                    }
                    var minutes = (difference.Minutes > 0) ?
                        (difference.Minutes == 1) ? "a Minute " : difference.Minutes + " Minutes " : "";
                    if (minutes != "")
                        return minutes;

                    var seconds = (difference.Seconds <= 5) ?
                        "5 Seconds " : difference.Seconds + " Seconds ";
                    return seconds + "ago";
                }
                catch
                {

                    return "Never Online";
                }

            }
            return "Never Online";
        }

        protected void btnEnroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Class/Enrollment/Enrollment.aspx?ccId=" + hidSubjectSessionId.Value);
        }
    }
}