using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Academy
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                var edt = Session["editMode"] as string;//Request.QueryString["edit"];
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
                    if ((user.IsInRole("manager") || user.IsInRole("admitter") || user.IsInRole("admin")))
                    {
                        if (edt != null)
                        {
                            var edit = edt == "1";
                            Edit = edit;
                            if (edit)
                            {
                                //lnkEdit.NavigateUrl = "~/Views/Academy/List.aspx?edit=0";
                                //lblEdit.Text = "Exit edit";
                                //lnkAdd.Visible = true;
                                pnlOtherEdits.Visible = true;
                            }
                            else
                            {
                                //lnkEdit.NavigateUrl = "~/Views/Academy/List.aspx?edit=1";
                                //lblEdit.Text = "Edit";
                                //lnkAdd.Visible = false;
                                pnlOtherEdits.Visible = false;
                            }
                        }
                        else
                        {
                            //lnkEdit.NavigateUrl = "~/Views/Academy/List.aspx?edit=1";
                            //lblEdit.Text = "Edit";
                            pnlOtherEdits.Visible = false;
                        }
                    }
                    else
                    {
                        //lnkEdit.Visible = false;
                        pnlOtherEdits.Visible = false;
                    }
                    BindGrid(user);
                }
                

            }
        }

        public bool Edit
        {
            get { return Convert.ToBoolean(hidEdit.Value); }
            set { hidEdit.Value = value.ToString(); }
        }
        private void BindGrid(CustomPrincipal user)
        {
            var edit = Edit;
            if (user.IsInRole("manager") || user.IsInRole("teacher"))
                using (var helper = new DbHelper.AcademicYear())
                {
                    var aca = helper.GetAcademicYearListForSchool(
                        user.SchoolId);
                    foreach (var ay in aca)
                    {
                        var uc =
                            (UserControls.AcademicYearListUC)
                                Page.LoadControl("~/Views/Academy/UserControls/AcademicYearListUC.ascx");
                        uc.LoadAcademicYear(
                            ay.Id, ay.Name, ay.StartDate, ay.EndDate
                            , ay.IsActive, ay.Sessions.ToList(), ay.Completed ?? false, edit);
                        pnlAcademicYearListing.Controls.Add(uc);
                    }
                }
        }

        public string GetDatePartOnly(object date)
        {
            if (date != null)
            {
                return Convert.ToDateTime(date.ToString()).ToShortDateString();
            }
            return "";
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //GridView1.Columns[1].Visible = false;
        }

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/Academy/AcademicYear/Create.aspx");
        //}

        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Views/Academy/Session/Create.aspx");
        //}

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.)
            //{

            //}
        }

        protected void btnAutoUpdate_Click(object sender, EventArgs e)
        {
            //using (var helper = new DbHelper.AcademicYear())
            //{
            //    //helper.AutoUpdateAcademicYear();
            //}
        }

    }
}