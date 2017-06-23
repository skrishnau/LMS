using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Academy
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblError.Visible = false;
            //lblError.Text = "Error while saving";
            //lblError.ForeColor = Color.Red;
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {

                    var aId = Request.QueryString["aId"];
                    if (aId != null)
                    {
                        try
                        {
                            AcademicYearId = Convert.ToInt32(aId);
                            if ((user.IsInRole("manager") || user.IsInRole("admitter") || user.IsInRole("admin")))
                            {
                                var edt = Session["editMode"] as string;//Request.QueryString["edit"];
                                if (edt != null)
                                {
                                    var edit = edt == "1";
                                    Edit = edit;
                            //        if (edit)
                            //        {
                            //            //lnkEdit.NavigateUrl = "~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId="
                            //            //                            + aId + "&edit=0";
                            //            //lblEdit.Text = "Exit edit";
                            //            MakeEditable(true);
                            //        }
                            //        else
                            //        {
                            //            //lnkEdit.NavigateUrl =
                            //            //    "~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + aId + "&edit=1";
                            //            //lblEdit.Text = "Edit";
                            //            MakeEditable(false);
                            //        }
                                }
                            }
                            //else
                            //{
                            //    //lnkEdit.Visible = false;
                            //    MakeEditable(false);
                            //}
                            ////lnknewSession.NavigateUrl = "~/Views/Academy/Session/Create.aspx?aId=" + aId;
                            ////lnkAddClasses.NavigateUrl = "~/Views/Academy/ClassAssign/ClassAssignCreate.aspx?aId=" + aId;
                        }
                        catch
                        {
                            Response.Redirect("~/Views/Academy/");
                        }
                    }
                    else Response.Redirect("~/Views/Academy/");
                }
            }
            LoadData();
        }

        public bool Edit
        {
            get { return Convert.ToBoolean(hidEditable.Value); }
            set { hidEditable.Value = value.ToString(); }
        }

        //public void MakeEditable(bool edit)
        //{
        //    if (edit)
        //    {
        //        lnknewSession.Visible = true;
        //    }
        //    else
        //    {
        //        lnknewSession.Visible = false;
        //    }
        //}

        public int AcademicYearId
        {
            get { return Convert.ToInt32(hidAcademicYear.Value); }
            set { hidAcademicYear.Value = value.ToString(); }
        }


        public void LoadData()
        {
            //var edit = Edit;

            using (var shelper = new DbHelper.Batch())
            //using (var helper = new DbHelper.AcademicYear())
            {
                var batch = shelper.GetBatchByAcademicYearId(AcademicYearId);
                if (batch != null)
                {
                    lnkBatch.Text = batch.Name + " (click to view programs)";
                    lnkBatch.NavigateUrl = "~/Views/Student/Batch/?Id=" + batch.Id;
                    var academic = batch.AcademicYear;
                    //var academic = helper.GetAcademicYear(AcademicYearId);
                    if (academic != null)
                    {

                        if (SiteMap.CurrentNode != null)
                        {
                            var list = new List<IdAndName>()
                            {
                                new IdAndName()
                                {
                                    Name = SiteMap.RootNode.Title
                                    ,
                                    Value = SiteMap.RootNode.Url
                                    ,
                                    Void = true
                                },
                                new IdAndName()
                                {
                                    Name = SiteMap.CurrentNode.ParentNode.Title
                                    ,
                                    Value = SiteMap.CurrentNode.ParentNode.Url + "?edit=" + (Edit ? "1" : "0")
                                    ,
                                    Void = true
                                },
                                new IdAndName()
                                {
                                    Name = academic.Name
                                }
                            };
                            SiteMapUc.SetData(list);
                        }
                        lblPageTitle.Text = academic.Name;
                        lblEndDate.Text = academic.EndDate.ToString("D");
                        lblStartDate.Text = academic.StartDate.ToString("D");
                        //string name = "";

                        var sessions = academic.Sessions.Where(x => !(x.Void ?? false)).ToList();


                        if (sessions.Any(x => x.IsActive))
                        {
                            imgActive.ImageUrl = "~/Content/Icons/Start/active_icon_10px.png";
                            imgActive.Visible = true;
                        }
                        else if (sessions.All(x => (x.Completed ?? false)))
                        {
                            imgActive.ImageUrl = "~/Content/Icons/Stop/Stop_10px.png";
                            imgActive.Visible = true;
                        }



                        //if (academic.Completed ?? false)
                        //{
                        //    name = " (Complete)";

                        //    //lnknewSession.Visible = false;
                        //}
                        //else if (academic.IsActive)
                        //{
                        //    name = " (Active)";
                        //    //btnActivate.Visible = false;
                        //}
                        //else
                        //{
                        //    //btnMarkComplete.Visible = false;
                        //}

                        lblAcademicYearName.Text = academic.Name;// + name;

                        foreach (var sess in academic.Sessions.Where(x => !(x.Void ?? false)).ToList())
                        {
                            var sessUc = (Academy.UserControls.SessionsListingInAYDetailUC)
                                Page.LoadControl("~/Views/Academy/UserControls/SessionsListingInAYDetailUC.ascx");
                            sessUc.LoadSessionData(academic.Id, sess.Id, sess.Name
                                , sess.StartDate, sess.EndDate
                                , sess.IsActive, sess.Completed ?? false, Edit, false);
                            pnlSessions.Controls.Add(sessUc);
                        }

                    }
                    else
                        Response.Redirect("~/Views/Academy/");
                }

            }

            //using (var helper = new DbHelper.AcademicPlacement())
            //{
            //    var classes = helper.ListRunningRunningClasses(AcademicYearId, 0);//.OrderBy(p=>p.ProgramBatch.Program.Name);

            //    if (classes.Any())
            //        pnlSessionPrograms.Visible = true;

            //    ListView1.DataSource = classes;
            //    ListView1.DataBind();
            //}
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Academy/Activation/Activate.aspx?aId=" + AcademicYearId + "&task=activate");
            //using (var helper = new DbHelper.AcademicYear())
            //{
            //    var error = helper.ActivateAcademicYearSession(AcademicYearId);
            //    if (error != "success")
            //    {
            //        lblError.Visible = true;
            //    }
            //    else
            //    {
            //        lblError.Visible = true;
            //        lblError.Text = "Now activate Session";
            //        lblError.ForeColor = Color.Black;
            //    }
            //}
        }
        protected void btnMarkComplete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Academy/Activation/Activate.aspx?aId=" + AcademicYearId + "&task=completed");
        }


        public string GetName(object programBatch)
        {
            var p = programBatch as Academic.DbEntities.Batches.ProgramBatch;
            if (p != null)
            {
                return p.NameFromBatch;
            }
            return "";
        }

        public string GetCurrent(object year, object subyear)
        {
            string ret = "";
            var y = year as Academic.DbEntities.Structure.Year;
            var s = (subyear == null) ? null : subyear as Academic.DbEntities.Structure.SubYear;
            if (y != null)
            {
                ret = y.Name;

            }
            if (s != null)
            {
                ret += " , " + s.Name;
            }
            return ret;
        }
    }
}