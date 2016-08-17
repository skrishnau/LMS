using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.Structure.All.UserControls.CourseLinkage
{
    public partial class CourseListItemUC : System.Web.UI.UserControl
    {

        public event EventHandler<SubjectEventArgs> CourseChecked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public int SubjectId
        {
            get { return Convert.ToInt32(hidCourseId.Value); }
            set { hidCourseId.Value = value.ToString(); }
        }

        public string SubjectName
        {
            get { return chkbox.Text; }
            set {chkbox.Text = value; }
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            RaiseCheckEvent();
        }

        protected void lblName_Click(object sender, EventArgs e)
        {
            chkbox.Checked = true;
            RaiseCheckEvent();
        }

        private void RaiseCheckEvent()
        {
            if (CourseChecked != null)
            {
                CourseChecked(this,new SubjectEventArgs()
                {
                    Id = SubjectId,
                    Name = SubjectName
                    ,Checked = chkbox.Checked
                });
            }
        }

        public void SetCourse(int id, string name, string code,bool selected=false,bool saved=false)
        {
            hidCourseId.Value = id.ToString();
            chkbox.Text = name ;
            //lblName.Text = name;
            lblCode.Text = " "+code;


             chkbox.Checked = selected;
            chkbox.Enabled = !saved;
        }

        public void SetCheckBoxId(string chkboxId)
        {
            chkbox.ID = chkboxId;
        }

        /// <summary>
        /// Gets or Sets the checkbox checked property to indicate that this course is selected by user already.
        /// </summary>
        public bool SetChecked
        {
            get { return chkbox.Checked; }
            set { chkbox.Checked = value; }
        }

        /// <summary>
        /// Enables or Disables the checkbox. This disables the checkbox to indicate that its already saved.
        /// The course can be removed from Saved courses section.
        /// </summary>
        public bool SetSaved
        {
            set
            {

                chkbox.Enabled = !value;
                if (value)
                    chkbox.BackColor = Color.LightSlateGray;
                else
                    chkbox.BackColor = Color.LightCoral;
            }

        }
    }
}