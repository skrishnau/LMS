using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;
using Academic.ViewModel;

namespace One.Views.Grade
{
    public partial class GradeListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;

            if (user != null)
            {
                if (!IsPostBack)
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
                    var edit = Session["editMode"] ?? "0";//Request.QueryString["edit"];
                    if (user.IsInRole("manager") || user.IsInRole("grader") || user.IsInRole("course-editor"))
                    {
                        if (edit == "1")
                        {
                            Edit = true;
                            hidTask.Value = DbHelper.StaticValues.Encode("grade");
                            //lnkEdit.NavigateUrl = "~/Views/Grade/GradeListing.aspx?edit=0";
                            //lblEdit.Text = "Exit edit";
                            lnkAddGrade.Visible = true;
                        }
                        else
                        {
                            //lnkEdit.NavigateUrl = "~/Views/Grade/GradeListing.aspx?edit=1";
                            //lblEdit.Text = "Edit";
                            Edit = false;
                            lnkAddGrade.Visible = false;
                        }

                    }

                    using (var helper = new DbHelper.Grade())
                    {
                        DataList1.DataSource = helper.ListGrades(user.SchoolId);
                        DataList1.DataBind();
                    }
                }
            }
            else Response.Redirect("~/");
        }

        public bool Edit
        {
            get { return Convert.ToBoolean(hidEdit.Value); }
            set { hidEdit.Value = value.ToString(); }
        }

        public bool IsEditable(object schoolId)
        {
            if (schoolId == null)
            {
                return false;
            }
            return true;
        }


    }
}