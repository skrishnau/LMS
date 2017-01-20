using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;
using One.Views.Academy.ProgramSelection;

namespace One.Views.Academy.ClassAssign
{
    public partial class ClassAssignCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = "Error while saving.";
            var aId = Request.QueryString["aId"];
            var sId = Request.QueryString["sId"];
            if (aId != null)
            {
                try
                {
                    AcademicYearId = Convert.ToInt32(aId);
                    if (sId != null)
                    {
                        // then its for session, so display only those years whose subyears are present
                        SessionId = Convert.ToInt32(sId);
                    }
                    var user = Page.User as CustomPrincipal;
                    if (user != null)
                    {
                        LoadData(user.SchoolId);
                        if (!IsPostBack)
                            LoadAcademicInfo();
                    }
                }
                catch
                {
                    //Response.Redirect("../List.aspx");
                }
            }
            //else
            //{
            //    Response.Redirect("../List.aspx");
            //}

            //LoadStructure(user.SchoolId);
        }

        private void LoadAcademicInfo()
        {
            using (var helper = new DbHelper.AcademicYear())
            {
                var aca = helper.GetAcademicYear(AcademicYearId);
                if (aca != null)
                {
                    if (!(aca.Void ?? false))
                    {
                        lblAcademicInfo.Text = "Classes assign in 'Academic year' : <strong>" + aca.Name + "</strong>";
                        var ses = helper.GetSession(SessionId);
                        if (ses != null)
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
                                        Name = SiteMap.CurrentNode.ParentNode.ParentNode.Title
                                        ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url+"?edit=1"
                                        ,Void=true
                                    }
                                    ,new IdAndName()
                                    {
                                        Name = aca.Name
                                        ,Value = SiteMap.CurrentNode.ParentNode.Url+"?aId="+aca.Id+"&edit=1"
                                        ,Void = true
                                    }
                                    ,new IdAndName()
                                    {
                                        Name = "Classes"
                                    }
                                };
                                SiteMapUc.SetData(list);
                            }

                            if (aca.Sessions.Select(x => x.Id).Contains(ses.Id))
                            {
                                lblAcademicInfo.Text += " and 'Session' : " + ses.Name;
                            }
                            else
                            {
                                Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + AcademicYearId);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/Academy/List.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/Academy/List.aspx");
                }
            }
        }

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYearId.Value); }
            set { hidAcademicYearId.Value = value.ToString(); }
        }
        public int SessionId
        {
            get { return Convert.ToInt32(hidSessionId.Value); }
            set { hidSessionId.Value = value.ToString(); }
        }

        private void LoadData(int schoolId)
        {
            var acaId = AcademicYearId;
            var sesId = SessionId;
            //using (var pbHelper = new DbHelper.AcademicPlacement())
            using (var helper = new DbHelper.Structure())
            {
                int sessionId = SessionId;
                int academicYearId = AcademicYearId;
                helper.ListPrograms(schoolId).ForEach(p =>
                {
                    #region PROGRAM Uc init

                    var puc = (UserControls.ProgramItemUc)
                        Page.LoadControl("~/Views/Academy/ClassAssign/UserControls/ProgramItemUc.ascx");
                    puc.SetData(p.Id, p.Name, false, acaId, sesId);
                    puc.ID = "programUc_" + p.Id;

                    #endregion

                    var years = p.Year.Where(x => !(x.Void ?? false)).OrderBy(x => x.Position)
                        .ThenBy(x => x.Id).ToList();
                    if (puc.SetYears(years))
                    {
                        pnlProgramListing.Controls.Add(puc);
                    }
                });
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //get all
            var rcs = GetRunningClasses();
            if (rcs == null)
            {
                lblError.Visible = true;
                lblError.Text = "Wrong input.";
                return;
            }
            using (var helper = new DbHelper.AcademicPlacement())
            {
                var saved = helper.AddOrUpdateRunningClass(rcs);
                if (saved)
                {
                    Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + AcademicYearId
                        + (SessionId > 0 ? ("&sId=" + SessionId) : ""));
                }
                else
                {
                    lblError.Visible = true;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + AcademicYearId
                       + (SessionId > 0 ? ("&sId=" + SessionId) : ""));
        }


        public List<Academic.DbEntities.AcacemicPlacements.RunningClass> GetRunningClasses()
        {
            var lst = new List<Academic.DbEntities.AcacemicPlacements.RunningClass>();
            foreach (var cnt in pnlProgramListing.Controls)
            {
                var yuc = cnt as UserControls.ProgramItemUc;//UserControls.FacultyItemUc;
                if (yuc != null)
                {
                    var rc = yuc.GetRunningClasses();
                    if (rc == null)
                    {
                        return null;
                    }
                    lst.AddRange(rc);
                }
            }
            return lst;
        }
    }
}