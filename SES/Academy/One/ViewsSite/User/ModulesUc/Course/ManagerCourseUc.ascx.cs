using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.ViewsSite.User.ModulesUc.Course
{
    public partial class ManagerCourseUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void SetData(int courseId, string courseShortName, string courseFullName, List<Academic.DbEntities.Class.UserClass> userClasses)
        {
            lnkCourseName.Text = courseShortName;
            lnkCourseName.NavigateUrl = "/Views/Course/Section/?SubId=" + courseId;
            lnkCourseName.ToolTip = courseFullName;

            var clsList = new List<IdAndName>();
            foreach (var u in userClasses)
            {
                var name = u.SubjectClass.GetName;
                var item = new IdAndName()
                {
                    Name = name
                    ,
                    Value = "~/Views/Class/CourseClassDetail.aspx?ccId=" + u.SubjectClass.Id
                    ,
                    IdInString = "Click to view class"
                };
                clsList.Add(item);
            }

            dListClasses.DataSource = clsList.OrderBy(x => x.Name);
            dListClasses.DataBind();
        }

    }
}