using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.ActivityResource.Choice
{
    public partial class ChoiceResponseView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetData(List<Academic.ViewModel.ChoiceResultViewModel> results)
        {
            ListView1.DataSource = results;
            ListView1.DataBind();
        }

    }
}