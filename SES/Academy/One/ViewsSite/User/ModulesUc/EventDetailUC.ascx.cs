using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class EventDetailUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(string time, string title, string description, string location)
        {
            lblTime.Text = time;
            lblTitle.Text = title;
            lblDescription.Text = description;
            lblLocation.Text = location;

        }
    }
}