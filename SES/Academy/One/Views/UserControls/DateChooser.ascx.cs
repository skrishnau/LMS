using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.UserControls
{
    public partial class DateChooser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public double Width_
        //{
        //    get { return Unit.Parse(this.pnlDateChooser.Width.Value); }
        //    set { this.pnlDateChooser.Width = Unit.Pixel(); }
        //}
        //public int Height_
        //{
        //    get { return this.Height; }
        //    set { this.Height = value; }
        //}
        public bool CalendarVisible
        {
            set { this.calendar.Visible = value; }
            get { return this.calendar.Visible; }
        }

        public bool Validate
        {
            get
            {
                if (this.validator.Enabled// == ValidateRequestMode.Enabled
                    || this.validator.EnableClientScript)
                {
                    return true;

                }
                else //if (this.validator.ValidateRequestMode == ValidateRequestMode.Disabled)
                {
                    return false;

                }
            }
            set
            {
                if (value)
                {
                    this.validator.Enabled = true;
                    this.validator.EnableClientScript = true;
                }
                else
                {
                    this.validator.Enabled = false;
                    this.validator.EnableClientScript = false;
                }
            }
        }

        public string SelectedDateInString
        {
            get { return this.txtDate.Text; }
            set
            {

                DateTime parsed;
                var success = DateTime.TryParse(value, out parsed);
                if (success)
                {
                    this.calendar.SelectedDate = parsed;
                    this.txtDate.Text = value;
                }
            }
        }

        public DateTime SelectedDate
        {
            get { return this.calendar.SelectedDate; }
            set
            {
                this.calendar.SelectedDate = value;
                this.txtDate.Text = value.ToShortDateString();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (calendar.Visible)
            {
                calendar.Visible = false;
            }
            else
            {
                calendar.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (CheckDateRangeMin)
            {
                if (calendar.SelectedDate < MinDate)
                {
                    validator.Text = MinDateValiationMessage;
                    validator.IsValid = false;
                    return;
                }
            }
            if (CheckDateRangeMax)
            {
                if (calendar.SelectedDate > MaxDate)
                {
                    validator.Text = MaxDateValidationMessage;
                    validator.IsValid = false;
                    return;
                }
            }

            txtDate.Text = calendar.SelectedDate.ToShortDateString();
            calendar.Visible = false;
        }

        public void ResetDate()
        {
            calendar.SelectedDate = DateTime.Now.Date;
            txtDate.Text = "";
        }

        //date range
        //private bool checkDateRangeMin = false;
        //private bool checkDateRangeMax = false;

        //private DateTime minDate = DateTime.MinValue;
        //private DateTime maxDate = DateTime.MaxValue;

        public bool CheckDateRangeMin
        {
            get { return checkDateRangeMin.Checked; }
            set { this.checkDateRangeMin.Checked = value; }
        }
        public bool CheckDateRangeMax
        {
            get { return checkDateRangeMax.Checked; }
            set { this.checkDateRangeMax.Checked = value; }
        }

        public DateTime MinDate
        {
            get
            {
                DateTime result;
                var success = DateTime.TryParse(this.minDate.Text, out result);
                if (success)
                    return result;
                else return DateTime.MinValue;
            }
            set
            {
                this.minDate.Text = value.ToShortDateString();
            }
        }
        public DateTime MaxDate
        {
            get
            {
                DateTime result;
                var success = DateTime.TryParse(this.maxDate.Text, out result);
                if (success)
                    return result;
                else return DateTime.MaxValue;
            }
            set
            {
                this.maxDate.Text = value.ToShortDateString();
            }
        }

        public string MinDateValiationMessage
        {
            get { return this.txtMinDateValiationMessage.Text; }
            set { this.txtMinDateValiationMessage.Text = value; }
        }

        public string MaxDateValidationMessage
        {
            get { return this.txtMaxDateValiationMessage.Text; }
            set { this.txtMaxDateValiationMessage.Text = value; }
        }
    }
}