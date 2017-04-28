using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.NoticeBoard
{
    public partial class NoticeListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var user = User as CustomPrincipal;
                if (user != null)
                {
                    if (SiteMap.CurrentNode != null)
                    {
                        var list = new List<IdAndName>()
                        {
                           new IdAndName(){
                                        Name=SiteMap.RootNode.Title
                                        ,Value =  SiteMap.RootNode.Url
                                        ,Void=true
                                    },
                            new IdAndName(){
                                Name = SiteMap.CurrentNode.Title
                                //,Value = SiteMap.CurrentNode.Url
                                //,Void=true
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    lnkAddNotice.NavigateUrl = "~/Views/NoticeBoard/NoticeCreate.aspx";
                    hidSchoolId.Value = user.SchoolId.ToString();
                    if (user.IsInRole("manager") || user.IsInRole("notifier"))
                    {
                        hidDisplayAll.Value = "True";
                        lnkAddNotice.Visible = true;
                    }
                    else
                    {
                        lnkAddNotice.Visible = false;
                    }

                    //var edit = Request.QueryString["edit"];
                    //if ((user.IsInRole("manager") || user.IsInRole("notifier")))
                    //{
                    //    hidDisplayAll.Value = "True";
                    //    if (edit != null)
                    //    {
                    //        //Edit = edit;
                    //        if (edit == "1")
                    //        {
                    //            lnkEdit.NavigateUrl = "~/Views/NoticeBoard/NoticeListing.aspx?edit=0";
                    //            lblEdit.Text = "Exit edit";
                    //            lnkAddNotice.Visible = true;
                    //        }
                    //        else
                    //        {
                    //            lnkEdit.NavigateUrl = "~/Views/NoticeBoard/NoticeListing.aspx?edit=1";
                    //            lblEdit.Text = "Edit";
                    //            lnkAddNotice.Visible = false;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lnkEdit.NavigateUrl = "~/Views/NoticeBoard/NoticeListing.aspx?edit=1";
                    //        lblEdit.Text = "Edit";
                    //        lnkAddNotice.Visible = false;
                    //    }
                    //}
                    //else
                    //{
                    //    lnkEdit.Visible = false;
                    //    lnkAddNotice.Visible = false;
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
    }
}