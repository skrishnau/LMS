using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.User
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var user = User as CustomPrincipal;
                if (user != null)
                {
                    if (SiteMap.CurrentNode != null)
                    {
                        var list = new List<IdAndName>()
                        {
                           new IdAndName(){
                                        Name=SiteMap.RootNode.Title
                                        ,Value =  SiteMap.RootNode.Url
                                        ,Void=true
                                    },
                            new IdAndName(){
                                Name = SiteMap.CurrentNode.Title
                                //,Value = SiteMap.CurrentNode.ParentNode.Url
                                //,Void=true
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    var edit = (Session["editMode"] as string) ?? "0";
                    if (user.IsInRole("manager"))
                    {
                        var editable = edit == "1";
                        lnkAddNewUser.Visible = editable;
                        lnkAssignRole.Visible = editable;
                    }
                    else
                    {
                        lnkAddNewUser.Visible = false;
                        lnkAssignRole.Visible = false;
                    }





                    hidSchoolId.Value = user.SchoolId.ToString();
                }
            }
        }

        public string GetName(object first, object mid, object last)
        {
            var s = "";
            if (first != null)
            {
                s = first.ToString();
            }
            if (mid != null)
            {
                s += " " + mid;
            }
            if (last != null)
            {
                s += " " + last;
            }
            return s;
        }

        public string GetImageUrl(object imageId)
        {
            if (imageId != null)
            {
                var id = Convert.ToInt32(imageId.ToString());
                using (var helper = new DbHelper.WorkingWithFiles())
                {
                    return helper.GetImageUrl(id);
                }
            }
            return "";
        }

        public string GetLastOnline(object onlineDate)
        {
            if (onlineDate != null)
            {
                try
                {
                    var date = Convert.ToDateTime(onlineDate.ToString());
                    var difference = DateTime.Now.Subtract(date);// - date;

                    var days = (difference.Days > 0) ?
                        (difference.Days == 1) ? "a Day " : difference.Days + " Days " : "";
                    if (days != "")
                    {
                        return days + "ago";
                    }

                    var hours = (difference.Hours != 0) ? (difference
                        .Hours == 1) ? "an Hour " : difference.Hours + " Hours " : "";
                    if (hours != "")
                    {
                        return hours + "ago";
                    }
                    var minutes = (difference.Minutes > 0) ?
                        (difference.Minutes == 1) ? "a Minute " : difference.Minutes + " Minutes " : "";
                    if (minutes != "")
                        return minutes;

                    var seconds = (difference.Seconds <= 5) ?
                        "5 Seconds " : difference.Seconds + " Seconds ";
                    return seconds + "ago";
                }
                catch
                {

                    return "Never";
                }

            }
            return "Never";
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/User/Create.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Role/Assign.aspx");
        }

        protected void btnFilter_OnClick(object sender, EventArgs e)
        {
            //var name = txtNameFilter.Text;
            //var email = txtEmailFilter.Text;
            //var username = txtUsernameFilter.Text;
            //var user = Page.User as CustomPrincipal;
            //if(user!=null)
            //using (var helper = new DbHelper.User())
            //{
            //    var users = helper.ListAllUsers(user.SchoolId,100,1,name,username,email);
            //    GridView1.DataSource = users;
            //    GridView1.DataBind();
            //}
        }

        protected void lnkFilterPanel_OnClick(object sender, EventArgs e)
        {
            pnlFilter.Visible = !pnlFilter.Visible;
            if (pnlFilter.Visible)
            {
                imgFilter.ImageUrl = "~/Content/Icons/Sort/sort-down-20px.png";
            }
            else
            {
                imgFilter.ImageUrl = "~/Content/Icons/Sort/sort-right-20px.png";
            }
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex % 2 == 0)
                {
                    e.Row.CssClass = "highlight-row-even";
                }
                else
                    e.Row.CssClass = "highlight-row-odd";
            }
        }
    }
}