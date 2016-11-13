using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Events
{
    public partial class EventCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    DateRestrictionUC1.LoadCustomDate(0, 5, "short", DateTime.Now);
                    var eId = Request.QueryString["eId"];

                    var manager = user.IsInRole("manager") || user.IsInRole("organizer");
                    if (eId != null)
                    {
                        EventId = Convert.ToInt32(eId);
                        LoadEvent(manager, user.Id);
                    }
                    publishRow.Visible = manager;
                    ////else
                    //{
                    //    if (eId != null)
                    //    {
                    //        EventId = Convert.ToInt32(eId);
                    //        LoadEvent(!manager, user.Id);
                    //    }
                    //    publishRow.Visible = false;
                    //}

                }
            }
        }

        public int EventId
        {
            get { return Convert.ToInt32(hidEventId.Value); }
            set { hidEventId.Value = value.ToString(); }
        }

        private void LoadEvent(bool manager, int userId)
        {
            using (var helper = new DbHelper.Event())
            {
                var evnt = helper.GetEvent(EventId, manager, userId);
                if (evnt != null)
                {
                    txtName.Text = evnt.Title;
                    txtLocation.Text = evnt.Location;
                    var now = DateTime.Now;
                    var yearDiff = now.Year - evnt.Date.Year;
                    DateRestrictionUC1.LoadCustomDate(yearDiff, now.Year + 1, "short", evnt.Date);
                    CKEditorControl1.Text = evnt.Description;
                }
                else
                {
                    Response.Redirect("~/Views/Events/");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                if (Page.IsValid)
                {
                    var publicposting = user.IsInRole("manager") || user.IsInRole("organizer");
                    var dt = DateRestrictionUC1.SelectedDate();
                    if (DateRestrictionUC1.IsValid)
                    {
                        var evnt =
                            new Academic.DbEntities.Events.Event()
                            {
                                Id = EventId,
                                Title = txtName.Text,
                                Date = dt,
                                Time = dt.Hour + ":" + dt.Minute
                                ,
                                Description = CKEditorControl1.Text
                                ,
                                Location = txtLocation.Text
                                ,
                                SchoolId = user.SchoolId
                                ,
                                PostedById = user.Id
                                ,
                                PostToPublic = ddlPublish.SelectedIndex == 1 && publicposting

                            };

                        using (var helper = new DbHelper.Event())
                        {
                            var saved = helper.AddOrUpdateEvent(evnt);
                            if (saved != null)
                            {
                                Response.Redirect("~/Views/Events/");
                            }
                            else
                            {
                                lblError.Visible = true;
                            }
                        }
                    }
                }
            }
        }

    }
}