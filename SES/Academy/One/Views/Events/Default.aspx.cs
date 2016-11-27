using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Events
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    //not needed...  self event ko lagi new event rakhnu parxa..
                    //if (user.IsInRole("manger") || user.IsInRole("organizer"))
                    //{
                    //    lnkAddEvent.Visible = 
                    //}
                    lnkAddEvent.Visible = true;
                    //if (user.IsInRole("manager") || user.IsInRole("organizer"))
                    //{
                    //    lnkAddEvent.Visible = true;
                    //}
                    //else
                    //{
                    //    lnkAddEvent.Visible = false;
                    //}
                    using (var helper = new DbHelper.Event())
                    {

                        DataList1.DataSource = helper.ListEvents(user.SchoolId, user.Id);
                        DataList1.DataBind();
                    }
                }
            }
        }

        public string GetDate(object date)
        {
            try
            {
                if (date != null)
                {
                    var dt = Convert.ToDateTime(date.ToString());
                    var d = dt.ToShortDateString() + "  " + dt.Hour + ":" + dt.Minute;
                    return d;
                }
                return "";
            }
            catch
            {
                return "";
            }

        }

        public string GetImageUrl(object postToPublic)
        {
            if (postToPublic != null)
            {
                var pst = Convert.ToBoolean(postToPublic.ToString());
                if (pst)
                    return "~/Content/Icons/Privacy/loudspeaker.png";
                return "~/Content/Icons/Privacy/private.png";
            }
            return "";
        }
    }
}