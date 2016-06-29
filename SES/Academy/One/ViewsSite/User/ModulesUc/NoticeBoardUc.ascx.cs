using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class NoticeBoardUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.Notice())
            {
                var notices = helper.GetNotices(UserId);

                DataList1.DataSource = notices;
                DataList1.DataBind();
                lblNoticeIndication.Text = "&nbsp; "+notices.Count(x => (x.ViewerLimited ?? false)).ToString()+" &nbsp; ";
            }
        }
        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }
    }
}