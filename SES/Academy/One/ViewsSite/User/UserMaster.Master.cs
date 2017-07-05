using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;
using One.ViewsSite.User.ModulesUc;

namespace One.ViewsSite.User
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                var user = Page.User as CustomPrincipal;
                var loginUrl = "ViewsSite/Account/Login.aspx";
                if (user != null)
                {
                    //EarlierUc.EmptyData += EarlierUc_EmptyData;
                    //check for school
                    UserId = user.Id;
                    SchoolId = user.SchoolId;
                    lnkLoginName.Text = user.FirstName;//.UserName;

                    if (!IsPostBack)
                    {
                        CoursesMenuUc1.UserId = user.Id;
                        //using(var fileHelper = new DbHelper.WorkingWithFiles())
                        //CoursesUc.UserId = user.Id;
                        //EarlierUc.UserId = user.Id;
                        try
                        {
                            var editMode = Session["editMode"] as string;
                            if (editMode == null)
                            {
                                //turn on edit mode
                                //TurnOffEditMode();
                                Session["editMode"] = "0";
                                lblEditMode.Text = "Turn on edit mode";
                            }
                            else
                            {
                                if (editMode == "1")
                                {
                                    //turn off edit mode
                                    //TurnOnEditMode();
                                    lblEditMode.Text = "Turn off edit mode";
                                }
                                else
                                {
                                    //turn on edit mode
                                    //TurnOffEditMode();
                                    lblEditMode.Text = "Turn on edit mode";
                                }
                            }
                        }
                        catch
                        {
                            //turn on edit mode
                            //TurnOffEditMode();
                            Session["editMode"] = "0";
                            lblEditMode.Text = "Turn on edit mode";
                        }

                        using (var usrHelper = new DbHelper.User())
                        using (var helper = new DbHelper.Office())
                        {

                            #region Student Info

                            var usr = usrHelper.GetUser(user.Id);
                            var student = usr.Student;

                            if (student.Any())
                            {
                                var std = student.FirstOrDefault();
                                if (std != null)
                                {
                                    var stdBatch = std.StudentBatch.FirstOrDefault();
                                    if (stdBatch != null)
                                    {
                                        lblUserInfo.Text = "(" + stdBatch.ProgramBatch.NameFromBatch;
                                        try
                                        {
                                            //if (user.AcademicYearId > 0)
                                            {
                                                var rc = usr.Classes.Select(x => x.SubjectClass)
                                                    .Where(x => x.RunningClassId != null && !(x.Void ?? false))
                                                    .Select(x => x.RunningClass)
                                                    .FirstOrDefault(x => (x.IsActive ?? false) && !(x.Void ?? false));
                                                if (rc != null)
                                                {
                                                    lblUserInfo.Text += "&nbsp;&nbsp;" + rc.GetYearAndSubYearName;
                                                }
                                            }
                                        }
                                        catch { }
                                        lblUserInfo.Text += ")";
                                    }
                                }
                            }

                            #endregion


                            var school = helper.GetSchoolOfUser(user.Id);
                            if (school != null)
                            {

                                //imgSchool.ImageUrl = "~/Content/Images/"
                                lblSchoolName.Text = school.Name;
                                SchoolId = user.SchoolId;
                                var f = helper.GetSchoolImage(school.ImageId);
                                if (f != null)
                                    imgSchool.ImageUrl = f.FileDirectory + f.FileName;

                                if (Request.Url.AbsolutePath.ToLower().StartsWith("/default.aspx"))
                                {
                                    //noticeboarduc,eventsuc, onlineusersuc
                                    //pnlBody.CssClass = "body-grey";
                                    middlePanel.Style.Add("border-right", "1px solid darkgrey");
                                    middlePanel.Style.Add("border-left", "1px solid darkgrey");

                                    //var eventsUc = (ModulesUc.EventsUc)
                                    //    Page.LoadControl("~/ViewsSite/User/ModulesUc/EventsUc.ascx");
                                    //eventsUc.UserId = user.Id;
                                    //eventsUc.SchoolId = school.Id;
                                    //pnlRight.Controls.Add(eventsUc);

                                    var onlineUsersUc = (ModulesUc.OnlineUsersUc)
                                        Page.LoadControl("~/ViewsSite/User/ModulesUc/OnlineUsersUc.ascx");
                                    onlineUsersUc.UserId = user.Id;
                                    onlineUsersUc.SchoolId = school.Id;
                                    pnlRight.Controls.Add(onlineUsersUc);

                                    right_panel.Visible = true;
                                }
                                else
                                {
                                    //pnlBody.CssClass = "body-white";
                                    middlePanel.Style.Add("background-color", "white");
                                }
                            }
                        }

                        //if (Request.Url.AbsolutePath.Contains("BookView")
                        //    || Request.Url.AbsolutePath.Contains("Create")
                        //    || Request.Url.AbsolutePath.Contains("Report"))
                        //{
                        //    right_panel.Visible = false;
                        //}
                    }
                    else
                    {
                        var text = txtSearch.Text;
                        var words = text.Split(new char[] { ' ' });
                        //var lst = words.Select(x => !(string.IsNullOrEmpty(x)));
                        var modifiedText = "";
                        foreach (var w in words.Where(x => !(string.IsNullOrEmpty(x))))
                        {
                            modifiedText += w + "+";
                        }
                        modifiedText = modifiedText.TrimEnd('+');
                        if (!string.IsNullOrEmpty(modifiedText))
                        {
                            Response.Redirect("~/Views/Search/?input=" + modifiedText, false);
                        }
                        else
                        {
                            txtSearch.Text = "";
                        }


                        //string parameter = Request["__EVENTARGUMENT"]; // parameter
                        //var target = Request["__EVENTTARGET"]; // btnSave
                        //if (parameter == "txtSearch")
                        //{
                        //    //var converted = target.Replace(' ', '+');
                        //    Response.Redirect("~/Views/Search/?input=" + modifiedText, false);
                        //}
                    }

                    #region NOtice earlier , now commented

                    //using (var nhelper = new DbHelper.Notice())
                    //{
                    //    var notices = nhelper.GetNotices(user.SchoolId, user.Id);

                    //    foreach (var n in notices)
                    //    {
                    //        var nUc =
                    //            (NoticeItemUc)
                    //                Page.LoadControl("~/ViewsSite/User/ModulesUc/NoticeItemUc.ascx");
                    //        nUc.SetData("~/Views/NoticeBoard/NoticeDetail.aspx?nId=" + n.Id, n.Title
                    //            , "posted on : " + ((n.PublishedDate == null) ? "" : n.PublishedDate.Value.ToShortDateString())
                    //            , n.Void ?? false);
                    //        plHolderNotice.Controls.Add(nUc);
                    //    }
                    //    if (notices.Any())
                    //    {
                    //        lblEmptyNotice.Visible = false;
                    //    }
                    //    //DataList1.DataSource = notices.Take(5).ToList();
                    //    //DataList1.DataBind();

                    //    var unViewed = notices.Where(x => (x.Void ?? false)).ToList();
                    //    if (!unViewed.Any())
                    //    {
                    //        imgNoticeIcon.ImageUrl = "~/Content/Icons/Notice/agt_announcements.png";
                    //        //imgNoticeIndicator.Visible = false;
                    //        //lblNoticeIndication.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        imgNoticeIcon.ImageUrl = "~/Content/Icons/Notice/agt_announcements_excla.png";
                    //        //imgNoticeIndicator.Visible = true;
                    //        //lblNoticeIndication.Text = "&nbsp; " + unViewed.Count + " &nbsp; ";
                    //    }
                    //}

                    #endregion

                    UpdateLoginTime(user.Id);


                    if (user.IsInRole("manager"))
                    {
                        var schoolCreateUrl = "Views/Office/School/Create.aspx";
                        var isSchoolUrl = Request.Url.AbsolutePath.Contains(schoolCreateUrl);
                        if (user.SchoolId <= 0 && !isSchoolUrl)
                        {
                            Response.Redirect("~/" + schoolCreateUrl);
                        }

                        SettingsUc settings =
                            (SettingsUc)Page.LoadControl("~/ViewsSite/User/ModulesUc/SettingsUc.ascx");
                        //settings.UserId = user.Id;
                        pnlSettings.Controls.Add(settings);
                        lnkEditMode.Visible = true;
                        lnkSettingMenu.Visible = true;

                        FileManagementMenuUc1.ShowServerMenu();
                    }
                    else if (user.IsInRole("teacher"))
                    {
                        SettingsTeacher teachersettings =
                           (SettingsTeacher)Page.LoadControl("~/ViewsSite/User/ModulesUc/SettingsTeacher.ascx");
                        //settings.UserId = user.Id;
                        pnlSettings.Controls.Add(teachersettings);
                        lnkEditMode.Visible = true;
                    }
                }
                else if (!Request.Url.AbsolutePath.Contains(loginUrl))
                {
                    //+"?ReturnUrl="+Page.Request.Url.PathAndQuery   
                    Response.Redirect("~/" + loginUrl);//+ "?ReturnUrl=" + Page.Request.Url.PathAndQuery
                }

            }
        }

        //void EarlierUc_EmptyData(object sender, EventArgs e)
        //{
        //    EarlierUc.Visible = false;
        //}

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

        void UpdateLoginTime(int userId)
        {
            using (var helper = new DbHelper.User())
            {
                helper.UpadateUsersLoginTime(userId);
            }
        }

        protected void lnkLoginName_OnClick(object sender, EventArgs e)
        {
            //redirect to profile
            Response.Redirect("~/Views/Profile.aspx");
        }

        protected void lnkEditMode_OnClick(object sender, EventArgs e)
        {
            try
            {
                var editMode = Session["editMode"] as string;
                if (editMode == null)
                {
                    //turn on edit mode
                    TurnOnEditMode();
                }
                else
                {
                    if (editMode == "1")
                    {
                        //turn off edit mode
                        TurnOffEditMode();
                    }
                    else
                    {
                        //turn on edit mode
                        TurnOnEditMode();
                    }
                }
            }
            catch
            {
                //turn on edit mode
                TurnOnEditMode();
            }

        }

        private void TurnOnEditMode()
        {
            Session["editMode"] = "1";
            //lblEditMode.Text = "Turn off edit mode";
            Response.Redirect(Request.Url.PathAndQuery, false);
        }

        private void TurnOffEditMode()
        {
            Session["editMode"] = "0";
            //lblEditMode.Text = "Turn on edit mode";
            Response.Redirect(Request.Url.PathAndQuery, false);
        }
    }
}