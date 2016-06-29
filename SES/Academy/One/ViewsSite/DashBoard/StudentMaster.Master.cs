using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values.MemberShip;

namespace One.ViewsSite.DashBoard.Student
{
    public partial class StudentMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                    hidUserId.Value = user.Id.ToString();
            }
        }

        public bool IsYear(object year)
        {
            var y = year as Academic.DbEntities.Structure.Year;
            if (string.IsNullOrEmpty(y.Name))
                return false;
            return true;
        }

        public string GetYearName(object year)
        {
            var y = year as Academic.DbEntities.Structure.Year;
            if (string.IsNullOrEmpty(y.Name))
                return "";
            return y.Name;
        }

        

        public string GetStructureType(object type)
        {
            return type.ToString();
        }
    }
}