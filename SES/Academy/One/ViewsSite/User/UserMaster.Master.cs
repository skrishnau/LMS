using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
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
                var loginUrl = "Home.aspx";//"ViewsSite/Account/Login.aspx";


                if (user != null)
                {
                    LoadActivityResourceSitemap();
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

                    using (var helper = new DbHelper.Notifications())
                    {
                        if (user.IsInRole(DbHelper.StaticValues.Roles.Manager))
                        {
                            var due = helper.GetDueClassesNotification(user.SchoolId);
                            if (due.Any())
                            {
                                lblEmptyNotice.Visible = false;
                                imgNotificationIcon.ImageUrl = "~/Content/Icons/Notice/Info-urgent-light-26px.png";
                                var hlink = new HyperLink()
                                {
                                    Text = "Due classes, Mark completion (" + due.Count + ")",
                                    NavigateUrl = "~/Views/Class/DueClasses.aspx"
                                };
                                plHolderNotice.Controls.Add(hlink);
                            }

                            var noTeacher = helper.GetNoTeacherInClassNotification(user.SchoolId);
                            if (noTeacher.Any())
                            {
                                lblEmptyNotice.Visible = false;
                                imgNotificationIcon.ImageUrl = "~/Content/Icons/Notice/Info-urgent-light-26px.png";

                                var hlink = new HyperLink()
                                {
                                    //<span style='background-color:red;color:white;padding:-2px;'></span>"
                                    Text = "Teacher not assigned to class (" + noTeacher.Count + ")",
                                    NavigateUrl = "~/Views/Class/TeacherNotAssignedClasses.aspx"
                                };
                                plHolderNotice.Controls.Add(hlink);
                            }
                        }
                    }

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
                else
                {
                    var path = Request.Url.AbsolutePath;//.Contains(loginUrl);
                    if (!path.Contains(loginUrl))
                    {
                        var home = path.ToLower().Contains("home.aspx");
                        var about = path.ToLower().Contains("about.aspx");
                        var contact = path.ToLower().Contains("contact.aspx");
                        if (!(home || about || contact))
                        {

                            Response.Redirect("~/" + loginUrl);
                        }
                        else
                        {
                            left_panel.Visible = false;
                            right_panel.Visible = true;
                            menubar_right_text_all.Visible = false;
                        }
                        //if (path.Contains("Home.aspx"))
                        //{
                        //    Response.Redirect("~/Home.aspx");
                        //}
                        //else if (path.Contains("About.aspx"))
                        //{
                        //    Response.Redirect("~/About.aspx");
                        //}
                        //else if (path.Contains("Contact.aspx"))
                        //{
                        //    Response.Redirect("~/Contact.aspx");
                        //}
                        //else
                        //{
                        //      Response.Redirect("~/" + loginUrl);
                        //}
                    }
                    return;
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

        #region Sitemap of Activity Resource

        private void LoadActivityResourceSitemap()
        {
            try
            {
                var index = Request.Path.IndexOf("ActivityResource", StringComparison.CurrentCultureIgnoreCase);
                if (index > 0)
                {
                    var remainingPath = Request.Path.Substring(index);
                    var list = GetCourse();
                    list.AddRange(GetActivityResource(remainingPath));

                    var siteMapUc = (One.Views.All_Resusable_Codes.SiteMaps.SiteMapUc)
                            Page.LoadControl("~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx");
                    siteMapUc.SetData(list);
                    SiteMapPlace.Controls.Add(siteMapUc);

                }
            }
            catch { }
        }

        List<IdAndName> GetActivityResource(string remainingPath)
        {
            try
            {
                using (var helper = new DbHelper.ActAndRes())
                {
                    var split = remainingPath.Split(new[] { '/', '?' });
                    if (split.Length > 0)
                    {
                        //[0] has "ActivityResource"
                        switch (split[1])
                        {
                            case "Assignments":
                                return GetAssignment(helper, split[2]);
                                break;
                            case "Book":
                                return GetBook(helper, split[2]);
                                break;
                            case "Choice":
                                return GetChoice(helper, split[2]);
                                break;
                            case "FileResource":
                                return GetFileResource(helper, split[2]);
                                break;
                            case "Folder":
                                return GetFolder(helper, split[2]);
                                break;
                            case "Forum":
                                return GetForum(helper, split[2]);
                                break;
                            case "Label":
                                return GetLabel(helper, split[2]);
                                break;
                            case "Page":
                                return GetPage(helper, split[2]);
                                break;
                            case "Url":
                                return GetUrl(helper, split[2]);
                                break;

                        }
                    }
                }
                return new List<IdAndName>();
            }
            catch { return new List<IdAndName>(); }
        }




        List<IdAndName> GetAssignment(DbHelper.ActAndRes helper, string fileName)
        {
            var list = new List<IdAndName>();
            switch (fileName)
            {
                case "AssignmentCheckCreate.aspx":
                    var actId = Request.QueryString["actId"];
                    var subId = Request.QueryString["SubId"];
                    var secId = Request.QueryString["secId"];
                    var ucId = Request.QueryString["ucId"];
                    var assignment = helper.GetAssignment(Convert.ToInt32(actId));
                    list.Add(new IdAndName()
                    {
                        Name = assignment.Name,
                        Value = "~/Views/ActivityResource/Assignments/AssignmentView.aspx?SubId=" + subId +
                                "&arId=" + actId +
                                "&secId=" + secId,
                        Void = true,
                    });
                    using (var clsHelper = new DbHelper.Classes())
                    {
                        var userClass = clsHelper.GetUserClass(Convert.ToInt32(ucId));
                        list.Add(new IdAndName()
                        {
                            Name = "Submission from '" + userClass.User.FirstName + "'"
                        });
                    }
                    break;
                case "AssignmentCreate.aspx":
                    list.Add(new IdAndName()
                    {
                        Name = "Assignment edit"
                    });
                    break;
                case "AssignmentView.aspx":
                    var assId = Request.QueryString["arId"];
                    var ass = helper.GetAssignment(Convert.ToInt32(assId));
                    list.Add(new IdAndName()
                    {
                        Name = ass.Name,
                    });

                    break;
                case "SubmitAssignmentCreate.aspx":
                    var arId = Request.QueryString["arId"];
                    var sub = Request.QueryString["SubId"];
                    var sec = Request.QueryString["secId"];
                    var assign = helper.GetAssignment(Convert.ToInt32(arId));
                    list.Add(new IdAndName()
                    {
                        Name = assign.Name,
                        Value = "~/Views/ActivityResource/Assignments/AssignmentView.aspx?SubId=" + sub +
                                "&arId=" + arId +
                                "&secId=" + sec,
                        Void = true,
                    });
                    if (fileName == "SubmitAssignmentCreate.aspx")
                    {
                        list.Add(new IdAndName()
                        {
                            Name = "Submission"
                        });
                    }
                    break;
            }

            return list;

        }

        List<IdAndName> GetBook(DbHelper.ActAndRes helper, string fileName)
        {
            var list = new List<IdAndName>();
            switch (fileName)
            {
                case "BookCreate.aspx":
                    list.Add(new IdAndName()
                    {
                        Name = "Book edit"
                    });
                    break;
                case "BookView.aspx":
                    var bookId = Request.QueryString["arId"];
                    var book = helper.GetBook(Convert.ToInt32(bookId));
                    list.Add(new IdAndName()
                    {
                        Name = book.Name,
                    });
                    break;
                case "ChapterCreate.aspx":
                    var bId = Request.QueryString["bId"];
                    var subId = Request.QueryString["SubId"];
                    var secId = Request.QueryString["secId"];
                    var bk = helper.GetBook(Convert.ToInt32(bId));
                    list.Add(new IdAndName()
                    {
                        Name = bk.Name,
                        Value = "~/Views/ActivityResource/Book/BookView.aspx" +
                                "?SubId=" + subId +
                                "&arId=" + bId +
                                "&secId=" + secId,
                        Void = true,
                    });
                    list.Add(new IdAndName()
                       {
                           Name = "Chapter edit"
                       });
                    break;
            }

            return list;

        }

        List<IdAndName> GetChoice(DbHelper.ActAndRes helper, string fileName)
        {
            var list = new List<IdAndName>();

            switch (fileName)
            {
                case "ChoiceCreate.aspx":
                    list.Add(new IdAndName()
                    {
                        Name = "Choice edit"
                    });
                    break;
                case "ChoiceView.aspx":
                    var choiceId = Request.QueryString["arId"];
                    var choice = helper.GetChoiceActivity(Convert.ToInt32(choiceId));
                    if (choice != null)
                    {
                        list.Add(new IdAndName()
                        {
                            Name = choice.Name,
                        });
                    }
                    break;
            }
            return list;
        }

        List<IdAndName> GetFileResource(DbHelper.ActAndRes helper, string fileName)
        {
            var list = new List<IdAndName>();
            switch (fileName)
            {
                case "DownloadingPage.aspx":
                    break;
                case "FileResourceCreate.aspx":
                    list.Add(new IdAndName()
                    {
                        Name = "File-Resource edit"
                    });
                    break;
                case "FileResourceView.aspx":
                    var fileId = Request.QueryString["arId"];
                    var file = helper.GetFileResource(Convert.ToInt32(fileId));
                    list.Add(new IdAndName()
                    {
                        Name = file.Name
                    });
                    break;
            }

            return list;

        }

        List<IdAndName> GetFolder(DbHelper.ActAndRes helper, string fileName)
        {
            var list = new List<IdAndName>();
            switch (fileName)
            {
                case "":
                    break;
            }

            return list;

        }

        List<IdAndName> GetForum(DbHelper.ActAndRes helper, string fileName)
        {
            var list = new List<IdAndName>();
            switch (fileName)
            {
                case "DiscussionCreate.aspx":
                    var fId = Request.QueryString["fId"];
                    var subId = Request.QueryString["SubId"];
                    var secId = Request.QueryString["secId"];
                    var frum = helper.GetForumActivity(Convert.ToInt32(fId));
                    list.Add(new IdAndName()
                    {
                        Name = frum.Name,
                        Value = "~/Views/ActivityResource/Forum/ForumView.aspx?SubId=" + subId +
                                    "&arId=" + fId +
                                    "&secId=" + secId,
                        Void = true,
                    });
                    list.Add(new IdAndName()
                    {
                        Name = "Discussion edit",
                    });
                    break;
                case "DiscussionView.aspx":
                    var disId = Request.QueryString["disId"];
                    var discussion = helper.GetForumDiscussion(Convert.ToInt32(disId));
                    if (discussion != null)
                    {
                        var actres = helper.GetActivityResource(true, (byte)Enums.Activities.Forum + 1, discussion.ForumActivityId);
                        list.Add(new IdAndName()
                        {
                            Name = discussion.ForumActivity.Name,
                            Value = "~/Views/ActivityResource/Forum/ForumView.aspx?SubId=" +
                                            actres.SubjectSection.SubjectId +
                                        "&arId=" + discussion.ForumActivityId +
                                        "&secId=" + actres.SubjectSectionId,
                            Void = true,
                        });
                        list.Add(new IdAndName()
                        {
                            Name = discussion.Subject,
                        });
                    }
                    break;
                case "ForumCreate.aspx":
                    list.Add(new IdAndName()
                    {
                        Name = "Forum edit"
                    });
                    break;
                case "ForumView.aspx":
                    var forumId = Request.QueryString["arId"];
                    var forum = helper.GetForumActivity(Convert.ToInt32(forumId));
                    if (forum != null)
                    {
                        list.Add(new IdAndName()
                        {
                            Name = forum.Name,
                        });
                    }
                    break;
            }
            return list;
        }

        List<IdAndName> GetLabel(DbHelper.ActAndRes helper, string fileName)
        {
            var list = new List<IdAndName>();
            switch (fileName)
            {
                case "LabelCreate.aspx":
                    list.Add(new IdAndName()
                    {
                        Name = "Label edit"
                    });
                    break;
                case "LabelView.aspx":
                    var labelId = Request.QueryString["arId"];
                    var label = helper.GetLabelResource(Convert.ToInt32(labelId));
                    list.Add(new IdAndName()
                    {
                        Name = "Label view"
                    });
                    break;
            }

            return list;

        }

        List<IdAndName> GetPage(DbHelper.ActAndRes helper, string fileName)
        {
            var list = new List<IdAndName>();
            switch (fileName)
            {
                case "PageCreate.aspx":
                    list.Add(new IdAndName()
                    {
                        Name = "Page edit"
                    });
                    break;
                case "PageView.aspx":
                    var pageId = Request.QueryString["arId"];
                    var page = helper.GetPageResource(Convert.ToInt32(pageId));
                    list.Add(new IdAndName()
                    {
                        Name = page.Name
                    });
                    break;
            }

            return list;

        }

        List<IdAndName> GetUrl(DbHelper.ActAndRes helper, string fileName)
        {
            var list = new List<IdAndName>();
            switch (fileName)
            {
                case "UrlCreate.aspx":
                    list.Add(new IdAndName()
                    {
                        Name = "Url edit"
                    });
                    break;
                case "UrlView.aspx":
                    var urlId = Request.QueryString["arId"];
                    var url = helper.GetUrlResource(Convert.ToInt32(urlId));
                    list.Add(new IdAndName()
                    {
                        Name = url.Name
                    });
                    break;
            }

            return list;

        }



        List<IdAndName> GetCourse()
        {
            var subId = Request.QueryString["SubId"];
            var fromCls = Request.QueryString["from"];
            var yId = Request.QueryString["yId"];
            var sId = Request.QueryString["sId"];
            using (var helper = new DbHelper.Subject())
            {
                var list = new List<IdAndName>();
                var sub = helper.Find(Convert.ToInt32(subId));

                // if (SiteMap.CurrentNode != null)
                // {
                list.Add(new IdAndName()
                {
                    Name = "Home",//SiteMap.RootNode.Title,
                    Value = "~/",//SiteMap.RootNode.Url,
                    Void = true
                });
                if (sId != null && yId != null)
                {
                    //lnkEdit.NavigateUrl += "&yId=" + yId + "&sId=" + sId;
                    list.Add(new IdAndName()
                    {
                        Name = "Manage Programs",
                        Value = "~/Views/Structure/",
                        Void = true
                    });
                    using (var strHelper = new DbHelper.Structure())
                    {
                        list.Add(new IdAndName()
                        {
                            Name = strHelper.GetSructureDirectory(Convert.ToInt32(yId), Convert.ToInt32(sId)),
                            Value = "~/Views/Structure/CourseListing.aspx?yId=" + yId + "&sId=" + sId,
                            Void = true
                        });
                    }

                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName
                    });
                }
                else if (fromCls != null)
                {
                    //lnkEdit.NavigateUrl += "&frmDetailView=" + fromCls;
                    list.Add(new IdAndName()
                    {
                        Name = "Courses",//SiteMap.CurrentNode.ParentNode.Title,
                        Value = "~/Views/Course/Default.aspx",//SiteMap.CurrentNode.ParentNode.Url,
                        Void = true
                    });
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName,
                        Value = "~/Views/Course/CourseDetail.aspx?cId=" + sub.Id,
                        Void = true
                    });
                    list.Add(new IdAndName() { Name = "View" });
                }
                else
                {
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName,
                        Value = "~/Views/Course/Section/?SubId=" + subId,
                        //"~/Views/Course/CourseDetail.aspx?cId=" + sub.Id
                        Void = true
                    });
                }


                //}
                return list;
            }
        }


        #endregion


    }
}