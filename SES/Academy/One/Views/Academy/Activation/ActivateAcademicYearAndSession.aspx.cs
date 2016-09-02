using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Academy.Activation
{
    public partial class ActivateAcademicYearAndSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    using (var helper = new DbHelper.AcademicYear())
                    {
                        var nextSession = helper.GetNextSessionToActivate(user.SchoolId);
                        if (nextSession == null)
                        {
                            //link to add new academic year
                            //create new academic year
                            var alink = new HyperLink()
                            {
                                Text = "Create New Academic Year"
                                ,NavigateUrl = "~/Views/Academy/AcademicYear/AcademyCreate.aspx"
                            };
                            pnlOptions.Controls.Add(alink);
                            //var lnk = new HyperLink(){Text = "Create New Session in "+"academic year "+};
                        }
                        else
                        {
                            //option to activate this session
                            if (nextSession.Id == 0)
                            {
                                //active academic year but no more sessions
                                var alink = new HyperLink()
                                {
                                    Text = "Create New Session in Academic Year "+nextSession.AcademicYear.Name 
                                    ,NavigateUrl = "~/Views/Academy/Session/Create.aspx?aId=" 
                                    + nextSession.AcademicYearId//""
                                };
                                pnlOptions.Controls.Add(alink);

                            }
                            else if (nextSession.AcademicYear.IsActive)
                            {
                                //activate --> this is correct
                               
                                var uc = (ActivateUC) Page.LoadControl("~/Views/Academy/Activation/ActivateUC.ascx");
                                uc.SetName(nextSession.AcademicYearId,nextSession.Id,nextSession.Name);
                                
                            }
                            else
                            {
                                  var uc = (ActivateUC) Page.LoadControl("~/Views/Academy/Activation/ActivateUC.ascx");
                                uc.SetName(nextSession.AcademicYearId,0,nextSession.AcademicYear.Name);

                                   var ucs = (ActivateUC) Page.LoadControl("~/Views/Academy/Activation/ActivateUC.ascx");
                                ucs.SetName(nextSession.AcademicYearId,nextSession.Id,nextSession.Name);

                            }
                        }

                        //var nextAcademic = helper.GetNextAcademicYearToActivate(user.SchoolId);
                        //if (nextAcademic == null)
                        //{
                        //    //link to add nex academic year
                        //}
                        //else
                        //{
                        //    //option to activate this academic year
                        //}
                    }
                }

            }
        }
    }
}