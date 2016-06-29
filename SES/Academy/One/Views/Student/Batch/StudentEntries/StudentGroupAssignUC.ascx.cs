using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Academic.Database.Migrations;
using Academic.DbHelper;

namespace One.Views.Student.Batch.StudentEntries
{
    public partial class StudentGroupAssignUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DbHelper.ComboLoader.LoadStudentGroup(ref cmbGroup, Values.Session.GetSchool(Session), true, GroupId);
            }
            DateChooser1.Validate = false;
        }

        public bool GroupComboEnabled
        {
            get { return cmbGroup.Enabled; }
            set { cmbGroup.Enabled = value; }
        }

        public int GroupId
        {
            get { return Convert.ToInt32((txtGroupId.Text == "") ? "0" : txtGroupId.Text); }
            set
            {
                DbHelper.ComboLoader.LoadStudentGroup(ref cmbGroup, Values.Session.GetSchool(Session), true, GroupId);
                cmbGroup.Enabled = false;
                this.txtGroupId.Text = value.ToString();
            }
        }

        protected void btnAsg_Click(object sender, EventArgs e)
        {
            var item = lstUnAsg.SelectedItem;

            //var asgTotalItems = lstAsg.Items.Count;
            var unasgTotalItems = lstUnAsg.Items.Count;

            int asgSelectedIndex = lstAsg.SelectedIndex;
            int unasgSelectedIndex = lstUnAsg.SelectedIndex;

            lstUnAsg.ClearSelection();
            lstAsg.ClearSelection();
            if (item != null)
            {
                lstAsg.Items.Insert(asgSelectedIndex + 1, new ListItem(item.Text, item.Value, true));
                lstUnAsg.Items.RemoveAt(unasgSelectedIndex);
                var selectionNew = (unasgSelectedIndex > 0) ? (unasgSelectedIndex - 1) : ((unasgTotalItems > 1) ? 0 : -1);

                if (selectionNew != -1)
                    lstUnAsg.SelectedIndex = unasgSelectedIndex - 1;
                lstAsg.SelectedIndex = asgSelectedIndex + 1;

            }

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var item = lstAsg.SelectedItem;

            var asgTotalItems = lstAsg.Items.Count;
            var unasgTotalItems = lstUnAsg.Items.Count;

            int asgSelectedIndex = lstAsg.SelectedIndex;
            int unasgSelectedIndex = lstUnAsg.SelectedIndex;

            lstUnAsg.ClearSelection();
            lstAsg.ClearSelection();

            if (item != null)
            {
                lstAsg.Items.RemoveAt(asgSelectedIndex);
                lstUnAsg.Items.Insert(unasgSelectedIndex + 1, new ListItem(item.Text, item.Value));

                var selectionNew = (asgSelectedIndex > 0) ? (asgSelectedIndex - 1) : ((asgTotalItems > 1) ? 0 : -1);
                if (selectionNew != -1)
                    lstAsg.SelectedIndex = asgSelectedIndex - 1;
                lstUnAsg.SelectedIndex = unasgSelectedIndex + 1;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedValue == "" || cmbGroup.SelectedValue == "0")
            {
                RequiredFieldValidator1.IsValid = false;
            }

            if (lstAsg.Items.Count <= 0)
            {
                RequiredFieldValidator2.IsValid = false;
            }
            //save
            if (Page.IsValid)
            {
                var grpId = Convert.ToInt32(cmbGroup.SelectedValue);
                List<int> stdList = new List<int>();
                foreach (ListItem item in lstAsg.Items)
                {
                    stdList.Add(Convert.ToInt32(item.Value));
                }
                if (stdList.Count > 0)
                {
                    using (var helper = new DbHelper.Student())
                    {
                        var s = helper.AssignStudentToGroup(stdList, grpId, Values.Session.GetUser(Session));
                        if (s)
                        {
                            Response.Redirect("~/Views/Student/StudentGroup/List.aspx");
                        }
                    }
                }
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.Student())
            {
                List<int> assIds = new List<int>();
                foreach (ListItem item in lstAsg.Items)
                {
                    assIds.Add(Convert.ToInt32(item.Value));
                }
                lstUnAsg.ClearSelection();
                lstUnAsg.Items.Clear();
                var stds = helper.GetUnAssignedStudents(Values.Session.GetSchool(Session),txtNameSearch.Text,
                    txtRollSearch.Text, DateChooser1.SelectedDate);
                stds.RemoveAll(x => assIds.Contains(x.Id));
                stds.ForEach(x =>
                {
                    var crn = "";
                    if (!string.IsNullOrEmpty(x.CRN))
                    {
                        crn = "(" + x.CRN + ") ";
                    }
                    lstUnAsg.Items.Add(
                        new ListItem(crn + x.User.FullName, x.Id.ToString()));
                });
                DateChooser1.CalendarVisible = false;
            }
        }

        protected void lstUnAsg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}