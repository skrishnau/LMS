using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class OnlineUsersUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadOnlineUsers();
        }
        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        public void LoadOnlineUsers()
        {
            using (var helper = new DbHelper.User())
            {
                var users = helper.GetOnlineUsers(UserId, SchoolId);
                DataList1.DataSource = users;
                DataList1.DataBind();
                if (users.Any())
                {
                    lblEmptyOnlineUsers.Visible = false;
                }
            }
        }

        public string GetName(object f, object m, object l)
        {
            var name = "";
            if (f != null)
            {
                name += f;
            }
            if (m != null)
            {
                name += (" " + m);
            }
            if (l != null)
            {
                name += (" " + l);
            }
            return name;

        }

    }
}