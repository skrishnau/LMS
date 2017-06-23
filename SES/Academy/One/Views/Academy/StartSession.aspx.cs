using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;
using Academic.ViewModel;

namespace One.Views.Academy
{
    public partial class StartSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            LoadData();
            LoadSiteMap();
        }

        private void LoadSiteMap()
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
                                    Value = SiteMap.CurrentNode.ParentNode.Url
                                    ,
                                    Void = true
                                },
                                new IdAndName()
                                {
                                    Name = "Start New Session"
                                }
                            };
                SiteMapUc.SetData(list);
            }
        }


        private void LoadData()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                using (var helper = new Academic.DbHelper.DbHelper.AcademicYear())
                {
                    int sessionPosition = LoadTextBoxes(helper, user);

                    if (sessionPosition == 0)
                    {
                        return;
                    }
                    LoadClasses(helper, user, sessionPosition);
                }
        }

        private void LoadClasses(Academic.DbHelper.DbHelper.AcademicYear helper, CustomPrincipal user, int sessionPosition)
        {
            var dict = helper.ListClassesForNextSession(user.SchoolId, sessionPosition);
            if (dict != null)
            {
                foreach (var program in dict.Keys)
                {
                    var pLabel = new Label()
                    {
                        Font = { Bold = true },
                        Text = program.Name + "<br/>"
                    };
                    pnlListing.Controls.Add(pLabel);
                    foreach (var rc in dict[program])
                    {
                        var rcLabel = new Label()
                        {
                            //Font = { Size = 14, Bold = false },
                            Text = "&nbsp;&nbsp;" + rc.ProgramBatch.Batch.Name + " -- " +
                                   rc.Year.Name + " " + (rc.SubYear == null ? "" : rc.SubYear.Name) +
                                   "<br/>"
                        };
                        pnlListing.Controls.Add(rcLabel);
                    }
                }
            }
        }


        private int LoadTextBoxes(Academic.DbHelper.DbHelper.AcademicYear helper, CustomPrincipal user)
        {
            int sessionPosition = 1;

            Academic.DbEntities.Session currentlyActiveSession = null;// = new Academic.DbEntities.Session();
            Academic.DbEntities.Session nextToActivateSession = null;// = new Academic.DbEntities.Session();
            var academicYear = helper.GetNextSessionToActivate(user.SchoolId, ref currentlyActiveSession, ref nextToActivateSession);

            if (academicYear == null)
            {
                //we don't have any new academic year
                //then redirect to academic create page
                Response.Redirect("~/Views/Academy/Create.aspx?from=startSession", false);
                return 0;
            }


            //populate data
            var sessions = academicYear.Sessions.OrderBy(x => x.Position).ToList();

            lblAcademicYear.Text = academicYear.Name;
            lblSemester1.Text = sessions[0].Name;
            lblSemester2.Text = sessions[1].Name;
            lblUpcomingSessionName.Text = " (Session : " + nextToActivateSession.Name + ")";

            hidAcademicYearId.Value = academicYear.Id.ToString();
            hidNextActivatingSessionId.Value = nextToActivateSession.Id.ToString();

            if (currentlyActiveSession != null)
            {
                hidCurrentlyActiveSessionId.Value = currentlyActiveSession.Id.ToString();
                lblCurrentSession.Text = currentlyActiveSession.AcademicYear.Name + " - " + currentlyActiveSession.Name;
                imgCurrentSession.Visible = true;
            }

            if (nextToActivateSession.Id == sessions[0].Id)
            {
                imgSem1.Visible = true;
                sessionPosition = 1;
            }
            else if (nextToActivateSession.Id == sessions[1].Id)
            {
                imgSem2.Visible = true;
                sessionPosition = 2;
            }
            return sessionPosition;


            #region Unused and commented

            //var isAcademicYearAlreadyPresent = academicYear.Id > 0;


            //txtAcademicyear.Text = academicYear.Name;
            //txtSemester1.Text = sessions[0].Name;
            //txtSemester2.Text = sessions[1].Name;

            //lblAcademicYear.Visible = isAcademicYearAlreadyPresent;
            //lblSemester1.Visible = isAcademicYearAlreadyPresent;
            //lblSemester2.Visible = isAcademicYearAlreadyPresent;

            //txtAcademicyear.Visible = !isAcademicYearAlreadyPresent;
            //txtSemester1.Visible = !isAcademicYearAlreadyPresent;
            //txtSemester2.Visible = !isAcademicYearAlreadyPresent;

            //reqValiAcademicyear.Enabled = !isAcademicYearAlreadyPresent;
            //reqValiSem1.Enabled = !isAcademicYearAlreadyPresent;
            //reqValiSem2.Enabled = !isAcademicYearAlreadyPresent;

            //if (isAcademicYearAlreadyPresent)
            //{


            //}
            //else
            //{

            //}
            //else
            //{
            //    txtAcademicyear.Text = academicYear.Name;
            //    txtSemester1.Text = sessions[0].Name;
            //    txtSemester2.Text = sessions[1].Name;
            //}


            #endregion

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            //activate the session (as well as academic year)
            // mark complete the previous active session
            //      or mark complete the previous academic year and its session
            //      mark all running classes of previous session as complete
            //  create new running class and mark them active

            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                //var date = DateTime.Now;
                var aId = Convert.ToInt32(hidAcademicYearId.Value);
                var currActiveSessionId = Convert.ToInt32(hidCurrentlyActiveSessionId.Value);
                var nextActivatingSessionId = Convert.ToInt32(hidNextActivatingSessionId.Value);

                using (var helper = new DbHelper.AcademicYear())
                {
                    var saved = helper.CreateNextActiveSession(user.SchoolId, aId, currActiveSessionId
                        , nextActivatingSessionId, user.Id);
                    if (saved)
                    {
                        Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + aId);
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Couldn't save.";
                    }

                }
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            var aId = Convert.ToInt32(hidAcademicYearId.Value);
            Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + aId);
        }
    }
}