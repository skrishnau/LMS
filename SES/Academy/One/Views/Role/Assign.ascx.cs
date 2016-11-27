using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Role
{
    public partial class Assign : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                if (!IsPostBack)
                {
                    if (!user.IsInRole("manager"))
                    {
                        Response.Redirect("~/");
                    }
                    DbHelper.ComboLoader.LoadRole(ref cmbRole, user.SchoolId, "");
                    //LoadUnAssignedList();

                    if (cmbRole.SelectedValue == "0")
                    {
                        lblRoleName.Text = "Choose role...";
                    }
                    else
                    {
                        lblRoleName.ForeColor = Color.Black;
                        lblRoleName.Text = "Assign role '" + cmbRole.SelectedItem.Text + "'";
                    }


                }

            }
        }

        void LoadUsersList()
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                using (var helper = new DbHelper.User())
                {
                    var roleId = Convert.ToInt32(cmbRole.SelectedValue);
                    var inRole = helper.ListUsersInRole(user.SchoolId, roleId, user.Id);
                    lstAsg.DataSource = inRole;
                    lstAsg.DataBind();

                    lstUnAsg.DataSource = helper.ListUsersNotInRole(user.SchoolId, roleId, user.Id, inRole);
                    lstUnAsg.DataBind();
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
            //var unasgTotalItems = lstUnAsg.Items.Count;

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

        //private void LoadUnAssignedList()
        //{
        //    using (var helper = new DbHelper.Student())
        //    {
        //        List<int> assIds = new List<int>();
        //        foreach (ListItem item in lstAsg.Items)
        //        {
        //            assIds.Add(Convert.ToInt32(item.Value));
        //        }
        //        lstUnAsg.Items.Clear();
        //        var stds = helper.GetUsersWithNoRoles(Values.Session.GetSchool(Session));
        //        stds.RemoveAll(x => assIds.Contains(x.Id));
        //        stds.ForEach(x =>
        //        {
        //            lstUnAsg.Items.Add(
        //                    new ListItem(x.FullName, x.Id.ToString())
        //                );
        //        });
        //    }
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedIndex == 0)
            {
                valiRole.IsValid = false;
            }
            //if (lstAsg.Items.Count <= 0)
            //{
            //    valiAsgCount.IsValid = false;
            //}
            if (Page.IsValid)
            {
                List<int> list = new List<int>();
                foreach (ListItem item in lstAsg.Items)
                {
                    list.Add(Convert.ToInt32(item.Value));
                }

                List<int> removedList = new List<int>();
                foreach (ListItem item in lstUnAsg.Items)
                {
                    removedList.Add(Convert.ToInt32(item.Value));
                }

                var roleId = Convert.ToInt32(cmbRole.SelectedValue);
                using (var helper = new DbHelper.User())
                {
                    var saved = helper.SaveUsersRole(list, roleId,removedList);
                    if (saved)
                    {
                        //lstUnAsg.Items.Clear();
                        lstAsg.Items.Clear();
                        //go to roles list
                        Response.Redirect("~/Views/User/List.aspx");
                    }
                }
            }
        }

        protected void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedValue != "0")
            {
                pnlRoleAsg.Visible = true;
                lblRoleName.Text = "Assign role '" + cmbRole.SelectedItem.Text + "'";
                LoadUsersList();
            }
            else
            {
                pnlRoleAsg.Visible = false;
            }

        }
    }
}