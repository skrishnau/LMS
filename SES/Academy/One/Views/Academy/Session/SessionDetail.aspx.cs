using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Academy.Session
{
    public partial class SessionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SessionsListingInAYDetailUC.SessionNameVisible = false;
                var aId = Request.QueryString["aId"];
                var sId = Request.QueryString["sId"];
                if (aId != null && sId != null)
                {
                    try
                    {
                        AcademicYearId = Convert.ToInt32(aId);
                        SessionId = Convert.ToInt32(sId);
                        LoadData();
                    }
                    catch
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

        public void LoadData()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                if (user.IsInRole("manager"))
                {
                    btnActivate.Visible = true;
                }
                else
                {
                    btnActivate.Visible = false;
                }
                using (var helper = new DbHelper.AcademicYear())
                {
                    var sId = SessionId;
                    var aId = AcademicYearId;
                    var academic = helper.GetAcademicYear(aId);
                    if (academic != null)
                    {
                        var session = academic.Sessions.FirstOrDefault(x => x.Id == sId);
                        var editQuery = Request.QueryString["edit"];
                        var edit = (editQuery ?? "0").ToString();
                        if (session != null)
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
                                        ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url+"?edit="+(edit)
                                        ,Void=true
                                    },
                                    new IdAndName()
                                    {
                                        Name = academic.Name
                                        ,Value = SiteMap.CurrentNode.ParentNode.Url+"?aId=1&edit="+edit
                                        ,Void = true
                                    },
                                    new IdAndName()
                                    {
                                        Name = session.Name
                                    }
                                };
                                SiteMapUc.SetData(list);
                            }
                            //lblEnd.Text = session.EndDate.ToShortDateString();
                            //lblStart.Text = session.StartDate.ToShortDateString();
                            string name = "";
                            if (session.Completed ?? false)
                            {
                                btnActivate.Visible = false;
                                name = " (Complete)";
                                //lnkAddClasses.Visible = false;
                                //lnknewSession.Visible = false;
                            }
                            else if (session.IsActive)
                            {
                                name = " (Active)";
                                btnActivate.Text = "Mark this as 'Complete'";
                            }
                            else
                            {

                                btnActivate.Text = "Activate this session";
                                //btnMarkComplete.Visible = false;
                            }

                            lblHeading.Text = academic.Name + " > " + session.Name + name;


                            //var sessUc = (Academy.UserControls.SessionsListingInAYDetailUC)
                            //    Page.LoadControl("~/Views/Academy/UserControls/SessionsListingInAYDetailUC.ascx");
                            SessionsListingInAYDetailUC.LoadSessionData(academic.Id, session.Id, session.Name, session.StartDate
                                , session.EndDate, session.IsActive, session.Completed ?? false, Editable);
                            //pnl.Controls.Add(sessUc);
                        }
                    }

                }}

            //using (var helper = new DbHelper.AcademicPlacement())
            //{
            //    var classes = helper.ListRunningRunningClasses(AcademicYearId, 0);//.OrderBy(p=>p.ProgramBatch.Program.Name);

            //    if (classes.Any())
            //        pnlSessionPrograms.Visible = true;

            //    ListView1.DataSource = classes;
            //    ListView1.DataBind();
            //}
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

        public bool Editable
        {
            get { return Convert.ToBoolean(hidEditable.Value); }
            set { hidEditable.Value = value.ToString(); }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            if (btnActivate.Text == "Mark this as 'Complete'")
            {
                Response.Redirect("~/Views/Academy/Activation/Activate.aspx?sId=" + SessionId + "&task=completed");
            }
            else if (btnActivate.Text == "Activate this session")
            {
                Response.Redirect("~/Views/Academy/Activation/Activate.aspx?sId=" + SessionId + "&task=activate");
            }
        }

    }
}