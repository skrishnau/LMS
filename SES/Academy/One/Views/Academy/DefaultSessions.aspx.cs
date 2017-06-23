using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Academy
{
    public partial class DefaultSessions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            LoadData();
        }

        private void LoadData()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                var roleAccess = user.IsInRole(DbHelper.StaticValues.Roles.Manager);
                var editMode = Session["editMode"] as string;
                var editM = editMode == "1";//string.IsNullOrEmpty(editMode)?false:editMode == "1";

                var editQuery = Request.QueryString["edit"];
                var editQ = editQuery != null && editQuery == "1";
                var edit = editM && editQ && roleAccess;
                

                txtNameSession1.Enabled = edit;
                txtNameSession2.Enabled = edit;
                pnlSaveDiv.Visible = edit;
                lnkEdit.Visible = editM && !edit && roleAccess;

                using (var helper = new Academic.DbHelper.DbHelper.AcademicYear())
                {
                    var defaultSessions = helper.ListDefaultSessions(user.SchoolId);
                    if (defaultSessions.Count >= 2)
                    {
                        txtNameSession1.Text = defaultSessions[0].Name;
                        Session1Id = defaultSessions[0].Id;
                        txtNameSession2.Text = defaultSessions[1].Name;
                        Session2Id= defaultSessions[1].Id;
                    }
                }
            }
            else
            {
                Response.Redirect("~/Views/Academy/");
            }
        }

        public int Session1Id
        {
            get { return Convert.ToInt32(hidSession1Id.Value); }
            set { hidSession1Id.Value = value.ToString(); }
        }

        public int Session2Id
        {
            get { return Convert.ToInt32(hidSession2Id.Value); }
            set { hidSession2Id.Value = value.ToString(); }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            using (var helper = new Academic.DbHelper.DbHelper.AcademicYear())
            {
                var list = new List<Academic.DbEntities.SessionDefault>();

                list.Add(new Academic.DbEntities.SessionDefault()
                {
                    Id = Session1Id,
                    Name = txtNameSession1.Text,
                    Position = 1
                });

                list.Add(new Academic.DbEntities.SessionDefault()
                {
                    Id =Session2Id,
                    Name = txtNameSession2.Text,
                    Position = 2
                });

                bool saved = helper.AddOrUpdateSessionDefault(list);
                if (saved)
                {
                    Response.Redirect("~/Views/Academy/DefaultSessions.aspx");
                }
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Academy/DefaultSessions.aspx");
        }
    }
}