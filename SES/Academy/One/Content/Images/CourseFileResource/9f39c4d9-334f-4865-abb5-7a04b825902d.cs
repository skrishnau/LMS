using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm
{
    public partial class Form1 : Form
    {
        //list
        List<CustomTime> TimeList = new List<CustomTime>()
        {
            new CustomTime(){Days = 0, Hours = 0, Minutes = 0 , Seconds = 0},
            new CustomTime(){Days = 0, Hours = 0, Minutes = 0 , Seconds = 0},
            new CustomTime(){Days = 0, Hours = 0, Minutes = 0 , Seconds = 0},
        };
        List<string> TimerName = new List<string>()
        {
            "Timer1","Timer2","Timer3"
        };

        public Form1()
        {
            InitializeComponent();


            LoadControls();
           
        }

        private void LoadControls()
        {
            timer1.Interval = 100;
            timer2.Interval = 100;
            timer3.Interval = 100;
            timer1.Tick += timer1_Tick;
            timer2.Tick += timer2_Tick;
            timer3.Tick += timer3_Tick;


            EnableInterval(rdBtnInterval1);
            EnableInterval(rdBtnInterval2);
            EnableInterval(rdBtnInterval3);


        }

        public void EnableInterval(RadioButton rdBtn)
        {
            var name = rdBtn.Name;
            switch (name)
            {
                case "rdBtnInterval1":
                    pnlInterval1.Enabled = true;
                    pnlTime1.Enabled = false;
                    break;
                case "rdBtnInterval2":
                    pnlInterval2.Enabled = true;
                    pnlTime2.Enabled = false;
                    break;
                case "rdBtnInterval3":
                    pnlInterval3.Enabled = true;
                    pnlTime3.Enabled = false;
                    break;
            }
        }
        public void EnableDatePicker(RadioButton rdBtn)
        {
            var name = rdBtn.Name;
            switch (name)
            {
                case "dateTimePicker1":
                    pnlInterval1.Enabled = false;
                    pnlTime1.Enabled = true;
                    break;
                case "dateTimePicker2":
                    pnlInterval2.Enabled = false;
                    pnlTime2.Enabled = true;
                    break;
                case "dateTimePicker3":
                    pnlInterval3.Enabled = false;
                    pnlTime3.Enabled = true;
                    break;
            }
        }


        //Tick
        void timer1_Tick(object sender, EventArgs e)
        {
            DecrementTime(TimeList[0], 0);
        }
        void timer2_Tick(object sender, EventArgs e)
        {
            DecrementTime(TimeList[1], 1);
        }
        void timer3_Tick(object sender, EventArgs e)
        {
            DecrementTime(TimeList[2], 2);
        }
        //==============tick end=============

        private void btnSet1_Click(object sender, EventArgs e)
        {
            #region Text Retrive

            if (rdBtnInterval1.Checked)
            {
                int hour = 0, minute = 0, second = 0;
                var parsedH = int.TryParse(txtHour1.Text, out hour);
                var parsedM = int.TryParse(txtMinute1.Text, out minute);
                var parsedS = int.TryParse(txtSecond1.Text, out second);
                TimeList[0].Hours = hour;
                TimeList[0].Minutes = minute;
                TimeList[0].Seconds = second;
                timer1.Interval = 1000;
                timer1.Start();
            }
            else
            {

            }

            #endregion
        }

        public void DecrementTime(CustomTime time, int whichTimer)
        {

            time.Seconds--;
            if (time.Seconds < 0)
            {
                time.Seconds = 0;
                time.Minutes--;
                if (time.Minutes < 0)
                {
                    time.Minutes = 0;
                    time.Hours--;
                    if (time.Hours < 0)
                    {
                        time.Hours = 0;
                        time.Days--;
                        if (time.Days < 0)
                        {
                            time.Days = 0;
                            //give alarm;
                            // UpdateUi(whichTimer);
                            if (time.Days == 0 && time.Hours == 0 && time.Minutes == 0 && time.Seconds == 0)
                            {
                                string msg = "Your " + TimerName[whichTimer] + " timer has been completed.";

                                switch (whichTimer)
                                {
                                    case 0:
                                        timer1.Stop();

                                        break;
                                    case 1:
                                        timer2.Stop();

                                        break;
                                    case 2:
                                        timer3.Stop();
                                        break;
                                }
                                MessageBox.Show(msg, "Time Complete", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            time.Hours = 23;
                        }
                    }
                    else
                    {
                        time.Minutes = 59;
                    }
                }
                else //minutes not zero so reset second to 60
                {
                    time.Seconds = 59;
                }
            }
        }

        public void UpdateUi(int whichTimer)
        {
            var timer = TimeList[whichTimer];
            switch (whichTimer)
            {
                //ui update codes here
                case 0:
                    lblTimeRemain1.Text = timer.Hours + ":" + timer.Minutes + ":" + timer.Seconds;
                    break;
                case 1:
                    lblTimeRemain2.Text = timer.Hours + ":" + timer.Minutes + ":" + timer.Seconds;
                    break;
                case 2:
                    lblTimeRemain3.Text = timer.Hours + ":" + timer.Minutes + ":" + timer.Seconds;
                    break;
            }
            if (timer.Days == 0 && timer.Hours == 0 && timer.Minutes == 0 && timer.Seconds == 0)
            {
                switch (whichTimer)
                {
                    case 0:
                        timer1.Stop();
                        break;
                    case 1:
                        timer2.Stop();

                        break;
                    case 2:
                        timer3.Stop();
                        break;
                }
                string msg = "Your " + TimerName[whichTimer] + " timer has been completed.";

                MessageBox.Show(msg, "Time Complete", MessageBoxButtons.OK);
            }
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {
            // text boxes clear

        }

        private void btnStop1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void lblTimeRemain2_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class CustomTime
    {
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }
}
