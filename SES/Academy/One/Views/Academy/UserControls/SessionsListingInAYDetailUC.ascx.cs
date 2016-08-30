using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Academy.UserControls
{
    public partial class SessionsListingInAYDetailUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadSessionData(int sessionId, string name, DateTime start, DateTime end)
        {
            lnkSessionName.Text = name;
            lnkSessionName.NavigateUrl = "~/Views/Academy/Session/SessionDetail.aspx?sId=" + sessionId;
            lblStartDate.Text = start.ToShortDateString();
            lblEndDate.Text = end.ToShortDateString();
            //GetPrograms in these sessions and add to pnlPrograms
        }

        
    }
}