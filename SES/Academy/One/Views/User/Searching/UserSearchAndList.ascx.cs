using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.User.Searching
{
    public partial class UserSearchAndList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    hidSchoolId.Value = user.SchoolId.ToString();
                    using (var helper = new DbHelper.User())
                    {
                        ListView1.DataSource = helper.ListAllUsers(user.SchoolId, 20, 1);
                        ListView1.DataBind();
                    }
                }
            }
        }

        protected void btnFilterShow_Click(object sender, EventArgs e)
        {
            pnlFilter.Visible = !pnlFilter.Visible;
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (btnShow.Text.Contains("More"))
            {
                pnlMoreFilter.Visible = true;
                btnShow.Text = "Show Less";
            }
            else
            {
                pnlMoreFilter.Visible = false;
                btnShow.Text = "Show More";
            }
        }

        public string GetName(object first, object mid, object last)
        {
            string name = "";
            if (first != null)
            {
                name += first.ToString();
                if (mid != null)
                {
                    name += mid.ToString();
                }
                if (last != null)
                {
                    name += last.ToString();
                }
            }
            return name;
        }

        public string GetImageUrl(object imageId)
        {
            if (imageId != null)
            {
                var id = Convert.ToInt32(imageId.ToString());
                using (var helper = new DbHelper.WorkingWithFiles())
                {
                    return helper.GetImageUrl(id);
                }
            }
            return "";
        }

        public string GetLastOnline(object onlineDate)
        {
            if (onlineDate != null)
            {
                try
                {
                    var date = Convert.ToDateTime(onlineDate.ToString());
                    var difference = DateTime.Now.Subtract(date);// - date;

                    var days = (difference.Days > 0) ?
                        (difference.Days == 1) ? "a Day " : difference.Days + " Days " : "";
                    if (days != "")
                    {
                        return days + "ago";
                    }

                    var hours = (difference.Hours != 0) ? (difference
                        .Hours == 1) ? "an Hour " : difference.Hours + " Hours " : "";
                    if (hours != "")
                    {
                        return hours + "ago";
                    }
                    var minutes = (difference.Minutes > 0) ?
                        (difference.Minutes == 1) ? "a Minute " : difference.Minutes + " Minutes " : "";
                    if (minutes != "")
                        return minutes;

                    var seconds = (difference.Seconds <= 5) ?
                        "5 Seconds " : difference.Seconds + " Seconds ";
                    return seconds + "ago";
                }
                catch
                {

                    return "Never Online";
                }

            }
            return "Never Online";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        public void select()
        {
            
        }
    }
}