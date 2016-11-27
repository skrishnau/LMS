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
    public partial class Activate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    var aId = Request.QueryString["aId"];
                    var sId = Request.QueryString["sId"];
                    var task = Request.QueryString["task"];
                    var user = Page.User as CustomPrincipal;
                    if (user != null)
                        using (var helper = new DbHelper.AcademicYear())
                        {
                            if (aId != null)
                            {
                                var acaId = Convert.ToInt32(aId);
                                AcademicYearId = acaId;
                                var aca = helper.GetAcademicYear(acaId);

                                if (task != null && aca != null)
                                {
                                    if (aca.SchoolId != user.SchoolId)
                                        Response.Redirect("~/Views/Academy/List.aspx");
                                    Task = task;
                                    if (task == "activate")
                                    {

                                        lblPageTitle.Text = "Activate";
                                        lblHeading.Text = "Activate Academic year : " + aca.Name + ((aca.IsActive) ? " (Active)" : "");
                                        if (aca.IsActive)
                                        {
                                            btnOk.Enabled = false;
                                            btnOk.ToolTip = "Already Active.";
                                            lblQue.Text = "Already Active.";
                                        }
                                        else
                                        {
                                            lblQue.Text =
                                                //"Previous academic year will be marked as completed along with all the running " +
                                                //"classes in that academic year. " +
                                            "All the classes in this academic year will be active. " +
                                            "Are you sure to 'activate' the academic year : " + aca.Name
                                            + "?";
                                        }

                                    }
                                    else if (task == "completed")
                                    {
                                        lblQue.Text = "All the running classes in this academic year will be marked as completed. " +
                                                          "This can't be undone. " +
                                                          "Are you sure to mark this academic year : <strong>" + aca.Name + "</strong>" +
                                                          ", as 'completed'? ";
                                        lblPageTitle.Text = "Mark complete";
                                        lblHeading.Text = "Mark Academic year : " + aca.Name + " as 'Complete'";
                                    }
                                    else
                                        Response.Redirect("~/Views/Academy/List.aspx");
                                }
                                else Response.Redirect("~/Views/Academy/List.aspx");
                            }
                            else if (sId != null)
                            {
                                var sessId = Convert.ToInt32(sId);
                                SessionId = sessId;
                                var sess = helper.GetSession(sessId);
                                if (task != null && sess != null)
                                {
                                    if (sess.AcademicYear.SchoolId != user.SchoolId)
                                        Response.Redirect("~/Views/Academy/List.aspx");
                                    Task = task;
                                    if (task == "activate")
                                    {
                                        lblQue.Text =
                                            "Previous session will be marked as completed along with all the running" +
                                            " classes in that session. This task " +
                                            "can't be undone. " +
                                            "Are you sure to 'activate' the session : " + sess.Name
                                            + "?";
                                        lblPageTitle.Text = "Activate";
                                        lblHeading.Text = "Activate Session : " + sess.Name;
                                    }
                                    else if (task == "completed")
                                    {
                                        lblQue.Text = "All the running classes in this session will be marked as completed. " +
                                                         "This can't be undone. " +
                                                         "Are you sure to mark this session '<strong>" + sess.Name +
                                                         "</strong>' as '<em>completed</em>'? ";
                                        lblPageTitle.Text = "Mark complete";
                                        lblHeading.Text = "Mark Session :  <strong>'" + sess.Name + "'</strong> as '<em>Complete</em>'";
                                    }
                                    else
                                        Response.Redirect("~/Views/Academy/List.aspx");
                                }
                                else Response.Redirect("~/Views/Academy/List.aspx");

                            }


                        }
                }
                catch
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

        public string Task
        {
            get { return hidTask.Value; }
            set { hidTask.Value = value; }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.AcademicYear())
            {
                var msg = "";
                var user = Page.User as CustomPrincipal;
                if (user != null && user.IsInRole("manager"))
                {
                    if (Task == "activate")
                    {
                        if (AcademicYearId > 0)
                        {
                            msg = helper.ActivateAcademicYearSession(user.Id, AcademicYearId, 0);
                        }
                        else if (SessionId > 0)
                        {
                            msg = helper.ActivateAcademicYearSession(user.Id, 0, SessionId);
                        }
                    }
                    else if (Task == "completed")
                    {
                        if (AcademicYearId > 0)
                        {
                            msg = helper.MarkCompleteAcademicYearSession(user.Id, AcademicYearId, 0);
                        }
                        else if (SessionId > 0)
                        {
                            msg = helper.MarkCompleteAcademicYearSession(user.Id, 0, SessionId);

                        }
                    }
                    if (msg != "success")
                    {
                        lblError.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + AcademicYearId);
                    }
                }
                else
                    Response.Redirect("~/Views/Academy/List.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Academy/AcademicYear/AcademicYearDetail.aspx?aId=" + AcademicYearId);
        }

    }
}