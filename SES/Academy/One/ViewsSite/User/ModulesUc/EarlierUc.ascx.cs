using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class EarlierUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }

        public string GetYearName(object year)
        {
            var y = year as Academic.DbEntities.Structure.Year;
            if (string.IsNullOrEmpty(y.Name))
                return "";
            return y.Name;
        }
    }
}