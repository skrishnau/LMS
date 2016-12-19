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

            if (!IsPostBack)
            {
                using (var helper = new DbHelper.Notice())
                {
                    var notices = helper.GetNotices(SchoolId,UserId);

                    DataList1.DataSource = notices.Take(5).ToList();
                    DataList1.DataBind();

                    var unViewed = notices.Where(x => (x.Void ?? false)).ToList();
                    if (!unViewed.Any())
                    {
                        lblNoticeIndication.Visible = false;
                    }
                    else
                    {
                        lblNoticeIndication.Text = "&nbsp; " + unViewed.Count + " &nbsp; ";
                    }
                   
                    //updatedatabase
                    //if (unViewed.Count > 0)
                    //{
                    //    //helper.AddOrUpdateNoticeNotification(unViewed, UserId);
                    //}
                }
            }

        }

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }

        public string GetPublishDate(object publishDate)
        {
            if (publishDate != null)
            {
                return Convert.ToDateTime(publishDate).ToShortDateString();
            }
            return "";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Click")
            {
                try
                {
                    using (var helper = new DbHelper.Notice())
                    {
                        var updaetd = helper.AddOrUpdateNoticeNotification(Convert.ToInt32(e.CommandArgument), UserId);
                        if (updaetd)
                        {
                            var cntrl = e.Item.FindControl("ImageButton1") as ImageButton;
                            if (cntrl != null)
                            {
                                cntrl.Visible = false;
                                try
                                {
                                    var count = Convert.ToInt32(lblNoticeIndication.Text.Replace("&nbsp;", "").Trim());
                                    lblNoticeIndication.Text = "&nbsp; " + (--count) + " &nbsp; ";
                                    if (count <= 0)
                                    {
                                        lblNoticeIndication.Visible = false;
                                    }
                                }
                                catch { }

                            }
                        }
                    }
                }
                catch { }

            }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }
    }
}