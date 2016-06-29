using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Student.StudentGroup.Listing
{
    public partial class ListUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            LoadGroups();
        }



        #region Properties



        #endregion

        #region Load Functions

        private void LoadGroups()
        {
            using (var helper = new DbHelper.Student())
            {
                var groups = helper.GetStudentGroupList(Values.Session.GetSchool(Session),false);

            }
        }

        #endregion

    }
}