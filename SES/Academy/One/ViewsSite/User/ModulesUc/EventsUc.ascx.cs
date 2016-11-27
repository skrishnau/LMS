using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class EventsUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Calendar1.SelectedDates.Add(DateTime.Now.AddDays(-3));
            //Calendar1.SelectedDates.Add(DateTime.Now.AddDays(-5));
            //Calendar1.SelectedDates.Add(DateTime.Now.AddDays(3));
            //Calendar1.SelectedDates.Add(DateTime.Now.AddDays(5));
            //Calendar1.SelectedDates.Add(DateTime.Now.AddDays(-10));
            
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
                using (var helper = new DbHelper.Event())
                {
                    var list = helper.ListEventDatesForTheMonth(SchoolId,UserId, Calendar1.SelectedDate);
                    var today = Calendar1.SelectedDate;
                    foreach (var dt in list)
                    {
                        Calendar1.SelectedDates.Add(dt);
                    }


                    if (!list.Contains(DateTime.Now.Date))
                    {
                        Calendar1.SelectedDates.Remove(DateTime.Now.Date);
                    }
                    var ysub = 0;
                    var msub = 1;
                    if (today.Month <= 1)
                    {
                        ysub = 1;
                        msub = 12;
                    }
                    else
                    {
                        msub = today.Month - 1;
                        ysub = 0;
                    }
                    Calendar1.SelectedDates.Add(new DateTime(today.Year - 0, msub, 1));
                }
            }

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
                using (var helper = new DbHelper.Event())
                {
                    var today = Calendar1.SelectedDate;
                    var list = helper.ListEventDatesForTheMonth(SchoolId,UserId,today);
                    foreach (var dt in list)
                    {
                        Calendar1.SelectedDates.Add(dt);
                    }
                    var ysub = 0;
                    var msub = 1;
                    if (today.Month <= 1)
                    {
                        ysub = 1;
                        msub = 12;
                    }
                    else
                    {
                        msub = today.Month - 1;
                        ysub = 0;
                    }
                    Calendar1.SelectedDates.Add(new DateTime(today.Year-0, msub, 1));
                }
            }
        }
        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }
        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }



        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.Event())
            {
                var events = helper.ListEvents(SchoolId,UserId, Calendar1.SelectedDate.Date);
                if (events.Any())
                {
                    var datelabel = new Label() {Text = "<div style='text-align: center;margin-top: -5px;'>" 
                                                            +Calendar1.SelectedDate.Date.ToShortDateString()

                                                            +"</div>"};
                    pnlEvents.Controls.Add(datelabel);
                    foreach (var ev in events)
                    {
                        var eventUcdetail =
                            (EventDetailUC) Page.LoadControl("~/ViewsSite/User/ModulesUc/EventDetailUC.ascx");
                        eventUcdetail.LoadData(ev.Time,ev.Title,ev.Description,ev.Location);
                        //var label3 = new Label() { Text = "<strong style='font-size:1.2em;'><em>" + ev.Time 
                        //    + "</em></strong><hr/>" };
                        //var label1 = new Label() { Text = "<span style='font-size:1.2em;'>" 
                        //    + ev.Title + "</span><br/>", Font = { Bold = true} };
                        //var label2 = new Label() { Text = "<div style='margin-left:4px;'>"+ev.Description };
                        //var label21 = new Label() { Text = "<br /><em><strong>&nbsp;&nbsp;Location:</strong> "
                        //    + ev.Location+"</em><br/></div>" };
                        //pnlEvents.Controls.Add(label3);
                        //pnlEvents.Controls.Add(label1);
                        //pnlEvents.Controls.Add(label2);
                        //pnlEvents.Controls.Add(label21);
                        pnlEvents.Controls.Add(eventUcdetail);

                    }
                    
                    divEventDetail.Visible = true;
                    Calendar1.Visible = false;
                }
                else
                {
                    LoadDates(Calendar1.SelectedDate.Date);
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LoadDates(Calendar1.SelectedDate.Date);
            divEventDetail.Visible = false;
            Calendar1.Visible = true;
        }

        void LoadDates(DateTime selecteddate)
        {
            //Calendar1.SelectedDates.Clear();
            using (var helper = new DbHelper.Event())
            {
                var list = helper.ListEventDatesForTheMonth(SchoolId,UserId, Calendar1.SelectedDate);
                foreach (var dt in list)
                {
                    Calendar1.SelectedDates.Add(dt);
                }
                if (!list.Contains(selecteddate))
                {
                    Calendar1.SelectedDates.Remove(selecteddate);
                }
            }
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            Calendar1.SelectedDates.Clear();
            using (var helper = new DbHelper.Event())
            {
                var list = helper.ListEventDatesForTheMonth(SchoolId,UserId, e.NewDate);
                foreach (var dt in list)
                {
                    Calendar1.SelectedDates.Add(dt);
                }
                var ysub = 0;
                var msub = 1;
                if (e.NewDate.Month <= 1)
                {
                    ysub = 1;
                    msub = 12;
                }
                else
                {
                    msub = e.NewDate.Month - 1;
                    ysub = 0;
                }
                Calendar1.SelectedDates.Add(new DateTime(e.NewDate.Year - 0, msub, 1));
            }
        }
    }
}