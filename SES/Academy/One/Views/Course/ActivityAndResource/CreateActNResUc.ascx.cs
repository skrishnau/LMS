using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.ActivityAndResource
{
    public partial class CreateActNResUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Properties

        public string Type { get { return hidType.Value; } set { hidType.Value = value; } }

        #endregion
    }
}