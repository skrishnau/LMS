using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.AccessPermission;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.RestrictionAccess
{
    public partial class GradeRestrictionUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            //populate activity list in ddlActivity..
            //using (var helper = new DbHelper.Subject())
            //{
            //    var course = helper.Find(SubjectId);
            //    if (course != null)
            //    {
            //        var lst = new List<Academic.DbEntities.ActivityAndResource.ActivityResource>();
            //        course.SubjectSections.Where(x => !(x.Void ?? false)).ToList().ForEach(x =>
            //        {
            //            var activities = x.ActivityResources.Where(n => !(n.Void ?? false) && n.ActivityOrResource)
            //                 .OrderBy(o=>o.Name).ToList();
            //            lst.AddRange(activities);
            //        });
            //        ddlActivityChoose.DataSource = lst;
            //        ddlActivityChoose.DataBind();
            //    }
            //}
        }

        public int GradeRestrictionId
        {
            get { return Convert.ToInt32(hidGradeRestrictionId.Value); }
            set { hidGradeRestrictionId.Value = value.ToString(); }
        }

        public int RestrictionId
        {
            get { return Convert.ToInt32(hidRestrictionId.Value); }
            set { hidRestrictionId.Value = value.ToString(); }
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

        public void SetIds(string parentId, string absoluteId, string relativeId, string type, int subjectId)
        {
            ParentId = parentId;
            AbsoluteId = absoluteId;
            RelativeId = relativeId;
            Type = type;
            SubjectId = subjectId;
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }



        //public void SetData(GradeRestriction res)
        //{
        //    if (res != null)
        //    {
        //        GradeRestrictionId = res.Id;
        //        ddlActivityChoose.SelectedValue = res.ActivityResourceId.ToString();
        //        RestrictionId = res.RestrictionId;
        //        chkLessThan.Checked = res.MustBeLessThan;

        //        if (res.MustBeGreaterThanOrEqualTo)
        //        {
        //            chkGreaterThanOrEqualTo.Checked = res.MustBeGreaterThanOrEqualTo;
        //            txtGreaterThanOrEqualTo.Text = res.GreaterThanOrEqualToValue == null
        //                ? "0"
        //                : res.GreaterThanOrEqualToValue.ToString();
        //        }
        //        if (res.MustBeLessThan)
        //        {
        //            chkLessThan.Checked = res.MustBeLessThan;
        //            txtLessThan.Text = res.LessThanValue == null ? "0" : res.LessThanValue.ToString();
        //        }
        //    }
        //}

        public bool IsValid = true;
        //used

        public Academic.DbEntities.AccessPermission.GradeRestriction GetGradeRestriction()
        {
            if (ddlActivityChoose.SelectedValue == "0")
            {
                lblError.Visible = true;
                IsValid = false;
                return new GradeRestriction();
            }
            var gr = new GradeRestriction()
            {
                Id = GradeRestrictionId
                ,
                ActivityResourceId = Convert.ToInt32(ddlActivityChoose.SelectedValue)
                ,
                RestrictionId = RestrictionId
                ,
            };
            if (chkGreaterThanOrEqualTo.Checked)
            {
                gr.MustBeGreaterThanOrEqualTo = true;
                gr.GreaterThanOrEqualToValue = (float)Convert.ToDecimal(txtGreaterThanOrEqualTo.Text);
            }
            else
            {
                gr.MustBeGreaterThanOrEqualTo = false;
                gr.GreaterThanOrEqualToValue = null;
            }


            if (chkLessThan.Checked)
            {
                gr.MustBeLessThan = true;
                gr.LessThanValue = (float)Convert.ToDecimal(txtLessThan.Text);
            }
            else
            {
                gr.MustBeLessThan = false;
                gr.LessThanValue = null;
            }

            return gr;
        }

        protected void chkGreaterThanOrEqualTo_CheckedChanged(object sender, EventArgs e)
        {
            txtGreaterThanOrEqualTo.Enabled = chkGreaterThanOrEqualTo.Checked;
        }

        protected void chkLessThan_CheckedChanged(object sender, EventArgs e)
        {
            txtLessThan.Enabled = chkLessThan.Checked;
        }

        /// <summary>
        /// [0]- activityId i.e. ActivityResource table id, 
        /// [1]- Must be Greater than (T/F)
        /// [2]- Greater than value
        /// [3]- Must be less than (T/F)
        /// [4]- Less than value
        /// </summary>
        /// <param name="constraint"></param>
        public void SetValues(params object[] constraint)
        {
            if (constraint != null)
                try
                {
                    if (constraint.Length == 5)
                    {
                        ddlActivityChoose.SelectedValue = constraint[0].ToString();
                        chkGreaterThanOrEqualTo.Checked = Convert.ToBoolean(constraint[1].ToString());
                        txtGreaterThanOrEqualTo.Enabled = chkGreaterThanOrEqualTo.Checked;
                        if (chkGreaterThanOrEqualTo.Checked)
                        {
                            txtGreaterThanOrEqualTo.Text = constraint[2].ToString();
                        }

                        chkLessThan.Checked = Convert.ToBoolean(constraint[3].ToString());
                        txtLessThan.Enabled = chkLessThan.Checked;
                        if (chkLessThan.Checked)
                        {
                            txtLessThan.Text = constraint[4].ToString();
                        }

                    }
                }
                catch
                {
                    lblError.Visible = true;
                }
        }
    }
}