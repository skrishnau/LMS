using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class CoursesUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (TopLevelRole == "manager" || TopLevelRole == "course-editor")
                {
                    //turn on add button in course 
                }
            }
        }

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }

        public string TopLevelRole
        {
            get { return hidTopLevelRole.Value; }
            set { hidTopLevelRole.Value = value; }
        }
    }
}