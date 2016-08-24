using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.User;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Class.Enrollment
{
    public partial class UserEnrollUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["enrolledList"] = new List<Academic.DbEntities.User.Users>();
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    using (var classHelper = new DbHelper.Classes())
                    using (var helper = new DbHelper.User())
                    {
                        //ListView1.DataSource = helper.ListAllUsers(user.SchoolId, 100, 1);
                        //ListView1.DataBind();
                        var list = helper.ListAllUsers(user.SchoolId, 100, 1);
                        grdNotEnrolled.DataSource = list;
                        grdNotEnrolled.DataBind();
                        list.RemoveRange(0, 4);

                        //var enrolledList =classHelper.ListUsersOfSubjectSession()

                        grdEnrolled.DataSource = list;
                        grdEnrolled.DataBind();
                    }
                }
            }

        }

        private void GetEnrolledList()
        {
            var enrolledList = Session["enrolledList"] as List<Academic.DbEntities.User.Users>;
            if (enrolledList != null)
            {

            }
        }

        private void AddToEnrolledList(int id, string name)
        {
            var enrolledList = Session["enrolledList"] as List<Academic.DbEntities.User.Users>;
            if (enrolledList != null)
            {
                enrolledList.Add(new Users()
                {
                    Id = id
                    ,
                    FirstName = name
                });
            }
        }

        void RemoveFromEnrolledList(int id)
        {
            var enrolledList = Session["enrolledList"] as List<Academic.DbEntities.User.Users>;
            if (enrolledList != null)
            {
                var found = enrolledList.Find(x => x.Id == id);
                if (found != null)
                {
                    enrolledList.Remove(found);
                }
            }
        }

        public string GetName(object first, object mid, object last, object email)
        {
            string name = "";
            if (first != null)
            {
                name += first.ToString();
                if (mid != null)
                {
                    name += " " + mid.ToString();
                }
                if (last != null)
                {
                    name += " " + last.ToString();
                }
                if (email != null)
                {
                    name += " (" + email + ")";
                }
            }
            return name;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in grdNotEnrolled.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    //r.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';" +
                    //                              "this.style.backgroundColor='red';";
                    //r.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='white';";

                    r.ToolTip = "Click to select row";
                    r.Attributes["onclick"] =// "this.style.backgroundColor='blue';" +
                        this.Page.ClientScript.GetPostBackClientHyperlink(this.grdNotEnrolled, "Select$" + r.RowIndex, true);

                }
            }

            foreach (GridViewRow r in grdEnrolled.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    //r.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';" +
                    //                              "this.style.backgroundColor='red';";
                    //r.Attributes["onmouseout"] = "this.style.textDecoration='none';this.style.backgroundColor='white';";

                    r.ToolTip = "Click to select row";
                    r.Attributes["onclick"] =// "this.style.backgroundColor='blue';" +
                        this.Page.ClientScript.GetPostBackClientHyperlink(this.grdEnrolled, "Select$" + r.RowIndex, true);

                }
            }

            base.Render(writer);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // Get the list of customers from the session 
                //List<Customer> customerList =
                //         Session["Customers"] as List<Customer>;

                //Debug.WriteLine(customerList[Convert.ToInt32(e.CommandArgument)].LastName);
            }
        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            var grdView = sender as GridView;
            if (grdView != null)
                if (e.CommandName == "Select" && e.CommandArgument.ToString() != "")
                {
                    grdView.SelectedIndex = Convert.ToInt32(e.CommandArgument);
                }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}