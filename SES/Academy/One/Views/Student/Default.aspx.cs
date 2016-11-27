using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values.MemberShip;

namespace One.Views.Student
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    listUc.SchoolId = user.SchoolId; //Values.Session.GetSchool(Session);
                    var edit = Request.QueryString["edit"];
                    if ((user.IsInRole("manager") || user.IsInRole("admitter")))
                    {
                        if (edit != null)
                        {
                            listUc.Edit = edit;
                            if (edit == "1")
                            {
                                lnkEdit.NavigateUrl = "~/Views/Student/?edit=0";
                                lblEdit.Text = "Exit edit";
                                lnkAdd.Visible = true;
                            }
                            else
                            {
                                lnkEdit.NavigateUrl = "~/Views/Student/?edit=1";
                                lblEdit.Text = "Edit";
                                lnkAdd.Visible = false;
                            }
                        }
                        else
                        {
                            lnkEdit.NavigateUrl = "~/Views/Student/?edit=1";
                            lblEdit.Text = "Edit";
                            lnkAdd.Visible = false;
                        }
                    }
                    else
                    {
                        lnkEdit.Visible = false;
                        lnkAdd.Visible = false;
                    }
                }
            }

        }
    }
}