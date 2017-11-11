using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.Academy
{
    public partial class RunningClassForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();

            }
        }

        private void LoadSitemap(Academic.DbEntities.AcacemicPlacements.RunningClass rc)
        {
            #region SiteMap

            var ses = rc.Session;
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
                                            Name = SiteMap.CurrentNode.ParentNode.ParentNode.ParentNode.Title
                                            ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.ParentNode.Url
                                            ,Void=true
                                        },
                                        new IdAndName()
                                        {
                                            Name = ses.AcademicYear.Name
                                            ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url+"?aId="+ses.AcademicYear.Id
                                            ,Void = true
                                        },
                                        new IdAndName()
                                        {
                                            Name = ses.Name,
                                            Value = SiteMap.CurrentNode.ParentNode.Url+"?aId="+ses.AcademicYearId+"&sId="+ses.Id,
                                            Void = true,
                                            //Name = (task == "activate")?"Activate":"Mark Complete"
                                        },
                                        new IdAndName()
                                        {
                                            Name =rc.ProgramBatch.NameFromBatch
                                        }
                                    };
                SiteMapUc.SetData(list);
            }

            #endregion
        }

        private void LoadData()
        {
            var rc = Request.QueryString["rcId"];
            var rcId = Convert.ToInt32(rc ?? "0");

            using (var usrHelper = new DbHelper.User())
            using (var helper = new DbHelper.Classes())
            {
                var rcls = helper.GetRunningClass(rcId);
                if (rcls != null)
                {

                    LoadSitemap(rcls);

                    lblProgramBatchName.Text = rcls.ProgramBatch.NameFromBatch;//+"  "+
                    lblAcademicSessionName.Text =
                        rcls.AcademicYear.Name + " - " + rcls.Session.Name;
                    lblYearSubYearName.Text = rcls.Year.Name + " - " +
                                      rcls.SubYear.Name;

                    lblTitle.Text = rcls.ProgramBatch.NameFromBatch + " : " + lblYearSubYearName.Text;

                    var teacherRoleId = usrHelper.GetRole(Academic.DbHelper.DbHelper.StaticValues.Roles.Teacher)
                                                                       .Id;

                    foreach (var sub in rcls.SubjectClasses.Where(x => !(x.Void ?? false)))
                    {
                        var teacherPresent = sub.ClassUsers.Any(x => x.RoleId == teacherRoleId && !(x.Void ?? false));

                        var link = new HyperLink()
                        {
                            
                            NavigateUrl = "~/Views/Class/CourseClassDetail.aspx?ccId=" + sub.Id,
                            CssClass = "list-group-item"
                        };

                        var lbl = new Label()
                        {
                            Text = sub.GetCourseFullName + "<br />",
                            //CssClass = "link"
                        };
                        link.Controls.Add(lbl);


                        if (!teacherPresent)
                        {
                            var noticeText =
                                   "&nbsp;&nbsp;&nbsp;&nbsp;<img src = '/Content/Icons/Notice/Warning_Shield_16px.png'/> " +
                                   "Teacher is not assigned to this class yet. Please assign teacher(s).<br/>";
                            var literal = new Literal()
                            {
                                Text = noticeText,
                            };
                            link.Controls.Add(literal);
                            //link.Text += noticeText;
                        }


                        //var notice = new Literal()
                        //{
                        //    Text = "&nbsp;&nbsp;&nbsp;&nbsp;<img src = '/Content/Icons/Notice/Warning_Shield_16px.png'/> " +
                        //                "Teacher is not assigned to this class yet. Please assign teacher(s).<br/>",
                        //};


                        //    <asp:Image ID="imgNotice" runat="server" ImageUrl="~/Content/Icons/Notice/Warning_Shield_16px.png" />

                        //Teacher is not assigned to this class yet. Please assign teacher(s).

                        pnlSubjects.Controls.Add(link);
                        //pnlSubjects.Controls.Add(notice);
                        //pnlSubjects.Controls.Add(new Literal()
                        //{
                        //    Text = "<br/>"
                        //});
                    }
                }
            }
        }
    }
}