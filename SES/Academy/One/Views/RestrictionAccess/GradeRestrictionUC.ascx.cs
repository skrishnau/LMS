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
            //populate activity list in ddlActivity..
            using (var helper = new DbHelper.Subject())
            {
                var course = helper.Find(SubjectId);
                if (course != null)
                {
                    var lst = new List<Academic.DbEntities.ActivityAndResource.ActivityResource>();
                    course.SubjectSections.Where(x => !(x.Void ?? false)).ToList().ForEach(x =>
                    {
                        var activities = x.ActivityResources.Where(n => !(n.Void ?? false) && n.ActivityOrResource)
                             .OrderBy(o=>o.Name).ToList();
                        lst.AddRange(activities);
                    });
                    ddlActivityChoose.DataSource = lst;
                    ddlActivityChoose.DataBind();
                }
            }
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

        public void SetIds(string parentId, string absoluteId, string relativeId, string type)
        {
            ParentId = parentId;
            AbsoluteId = absoluteId;
            RelativeId = relativeId;
            Type = type;
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }



        public void SetData( GradeRestriction res )
        {
          if (res != null)
            {
                GradeRestrictionId = res.Id;
                ddlActivityChoose.SelectedValue = res.ActivityResourceId.ToString();
                RestrictionId = res.RestrictionId;
                chkLessThan.Checked = res.MustBeLessThan;

                if (res.MustBeGreaterThanOrEqualTo)
                {
                    chkGreaterThanOrEqualTo.Checked = res.MustBeGreaterThanOrEqualTo;
                    txtGreaterThanOrEqualTo.Text = res.GreaterThanOrEqualToValue == null
                        ? "0"
                        : res.GreaterThanOrEqualToValue.ToString();
                }
                if (res.MustBeLessThan)
                {
                    chkLessThan.Checked = res.MustBeLessThan;
                    txtLessThan.Text = res.LessThanValue == null ? "0" : res.LessThanValue.ToString();
                }
            }
        }

        //used
        public Academic.DbEntities.AccessPermission.GradeRestriction GetGradeRestriction()
        {
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

    }
}