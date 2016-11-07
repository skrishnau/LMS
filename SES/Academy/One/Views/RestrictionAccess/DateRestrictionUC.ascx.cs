using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.RestrictionAccess
{
    public partial class DateRestrictionUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            LoadDate();
        }

        /// <summary>
        /// caalled from loading function for one time only...
        /// </summary>
        /// <param name="date"></param>
        //public void LoadInitialValue(DateTime date)
        //{
        //    //var selectedDate = SelectedDate();
        //    InitialDate = date;
        //    string currentMonth = "";
        //    ddlYear.DataSource = DbHelper.SystemDate.GetYears(-10, 5, date);
        //    ddlYear.DataBind();
        //    ddlYear.SelectedValue = date.Year.ToString();

        //    ddlMonth.DataSource = DbHelper.SystemDate.GetMonth("short", date.Month, out currentMonth);
        //    ddlMonth.DataBind();
        //    if (currentMonth != "")
        //    {
        //        ddlMonth.SelectedValue = currentMonth;
        //    }



        //    ddlDay.DataSource = DbHelper.SystemDate.GetDays(date.Date);
        //    ddlDay.DataBind();
        //    ddlDay.SelectedValue = date.Day.ToString();

        //    ddlHour.DataSource = DbHelper.SystemDate.GetHours();
        //    ddlHour.DataBind();

        //    ddlMinute.DataSource = DbHelper.SystemDate.GetMinutes();
        //    ddlMinute.DataBind();

        //}


        private void LoadDate()
        {

            var date = InitialDate;
            //var selectedDate = SelectedDate();
            int currentMonth = 1;
            ddlYear.DataSource = DbHelper.SystemDate.GetYears(-10, 5, date);
            ddlYear.DataBind();
            ddlYear.SelectedValue = date.Year.ToString();


            ddlMonth.DataSource = DbHelper.SystemDate.GetMonth("short", date.Month, out currentMonth);
            ddlMonth.DataBind();
            ddlMonth.SelectedValue = currentMonth.ToString();


            ddlDays.DataSource = DbHelper.SystemDate.GetDays(date.Date);
            ddlDays.DataBind();
            ddlDays.SelectedValue =  date.Day.ToString();

            ddlHour.DataSource = DbHelper.SystemDate.GetHours();
            ddlHour.DataBind();

            ddlMinute.DataSource = DbHelper.SystemDate.GetMinutes();
            ddlMinute.DataBind();
        }

        public DateTime InitialDate
        {
            get
            {
                var date = DateTime.Now;
                var parsed = DateTime.TryParse(hidInitialDate.Value, out date);// Convert.ToDateTime(hidSelectedDate.Value);
                if (parsed)
                    return date;
                return DateTime.Now; ;
            }
            set { hidInitialDate.Value = value.ToShortDateString(); }
        }

        public bool IsValid = true;
        private DateTime SelectedDate()
        {
            try
            {
                var year = Convert.ToInt32(ddlYear.SelectedValue);
                var month = Convert.ToInt32(ddlMonth.SelectedValue);

                var day = Convert.ToInt32(ddlDays.SelectedValue);

                var hour = Convert.ToInt32(ddlHour.SelectedValue);
                var min = Convert.ToInt32(ddlMinute.SelectedValue);

                return new DateTime(year, month, day, hour, min, 0);
            }
            catch
            {
                lblError.Visible = true;
                IsValid = false;
                return DateTime.Now;
            }

        }

        /// <summary>
        /// RelativeId contain ids in the format (1_2_3) where 
        /// preceeding ids are of parent and last id is current Control's id
        /// </summary>
        public string RelativeId
        {
            get { return hidRelativeId.Value; }
            set { hidRelativeId.Value = value; }
        }

        /// <summary>
        /// The specifice id of this control.
        /// </summary>
        public string AbsoluteId
        {
            get { return hidAbsoluteId.Value; }
            set { hidAbsoluteId.Value = value; }
        }

        public string ParentId
        {
            get { return hidParentId.Value; }
            set { hidParentId.Value = value; }
        }

        public string Type
        {
            get { return hidType.Value; }
            set { hidType.Value = value; }
        }

        public event EventHandler<RestrictionEventArgs> CloseClicked;
        protected void imgClose_Click(object sender, ImageClickEventArgs e)
        {
            if (CloseClicked != null)
            {
                var arg = new RestrictionEventArgs()
                {
                    ParentId = ParentId
                    ,
                    Type = Type
                    ,
                    RelativeId = RelativeId
                    ,
                    AbsoluteId = AbsoluteId

                };
                CloseClicked(this, arg);
            }
        }

        public void SetIds(string parentId, string absoluteId, string relativeId, string type)
        {
            ParentId = parentId;
            AbsoluteId = absoluteId;
            RelativeId = relativeId;
            Type = type;
        }

        //protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var date = SelectedDate();
        //    //ddlDay.DataSource = null;
        //    ddlDay.DataSource = DbHelper.SystemDate.GetDays(SelectedDate());
        //    ddlDay.DataBind();
        //    //ddlDay.SelectedValue = date.Day.ToString();
        //}

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val0 = ddlYear.SelectedValue;
            var val = ddlMonth.SelectedValue;
            var val1 = ddlDays.SelectedValue;

            //var date = SelectedDate();
            ////    ddlDay.DataSource = null;
            //ddlDay.DataSource = DbHelper.SystemDate.GetDays(SelectedDate());
            //ddlDay.DataBind();
            //ddlDay.SelectedValue = date.Day.ToString();
        }

        public int DateRestrictionId
        {
            get { return Convert.ToInt32(hidDateRestrictionId.Value); }
            set { hidDateRestrictionId.Value = value.ToString(); }
        }
        public int RestrictionId
        {
            get { return Convert.ToInt32(hidRestrictionId.Value); }
            set { hidRestrictionId.Value = value.ToString(); }
        }

        public new Academic.DbEntities.AccessPermission.DateRestriction GetDateRestriction()
        {
            var res = new Academic.DbEntities.AccessPermission.DateRestriction()
            {
                Id = DateRestrictionId
                ,Date = SelectedDate()
                ,RestrictionId = RestrictionId
                ,Constraint = ddlFromUntil.SelectedIndex==1
            };
            return res;
        }

    }
}