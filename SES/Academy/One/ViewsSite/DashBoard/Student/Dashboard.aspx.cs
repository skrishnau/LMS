using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.ViewsSite.DashBoard.Student
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LstTree.SchoolId = Values.Session.GetSchool(Session);
                LstTree.UserId = Values.Session.GetUser(Session);
                LstTree.AcademicYearId = Values.Session.GetAcademicYear(Session);
                LstTree.SessionId = Values.Session.GetSession(Session);
                LstTree.UserType = "student";
            }
            //load courses
            //using (var helper = new DbHelper.Activity())
            //{
            //    //helper.
            //}
            //var courses = 

        }


        #region Properties



        #endregion


        #region Loading Functions

        //public void LoadCourses()
        //{


        //}

        #endregion

    }
}