using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Academy.AcademicYear
{
    public partial class AcademyCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            valiStartDate.ErrorMessage = "Required";
            try
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
                                Name = SiteMap.CurrentNode.ParentNode.Title
                                ,Value = SiteMap.CurrentNode.ParentNode.Url+"?edit=1"
                                ,Void=true
                            },
                            new IdAndName()
                            {
                                Name = SiteMap.CurrentNode.Title
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    var aId = Request.QueryString["aId"];
                    if (aId != null)
                    {
                        btnSaveAndAddSessions.Visible = false;
                        using (var helper = new DbHelper.AcademicYear())
                        {
                            var acad = helper.GetAcademicYear(Convert.ToInt32(aId));
                            if (acad != null)
                            {

                                hidId.Value = aId;
                                txtName.Text = acad.Name;
                                txtStart.Text = acad.StartDate.ToShortDateString();
                                txtEnd.Text = acad.EndDate.ToShortDateString();
                                //lblHeading.Text = acad.Name;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {

                DateTime start = DateTime.MinValue, end = DateTime.MaxValue;
                try
                {
                    start = Convert.ToDateTime(txtStart.Text);
                }
                catch
                {
                    valiStartDate.ErrorMessage = "Incorrect format.";
                    valiStartDate.IsValid = false;
                }
                try
                {
                    end = Convert.ToDateTime(txtEnd.Text);
                }
                catch
                {
                    valiEndDate.ErrorMessage = "Incorrect format.";
                    valiEndDate.IsValid = false;
                }
                
                if (Page.IsValid)
                {
                    var entity = new Academic.DbEntities.AcademicYear()
                    {
                        Id = Convert.ToInt32(hidId.Value)
                        ,
                        Name = txtName.Text
                        ,
                        EndDate = end
                        ,
                        StartDate = start
                        ,
                        SchoolId = user.SchoolId
                    };
                    using (var helper = new DbHelper.AcademicYear())
                    {

                        var saved = helper.AddOrUpdateAcademicYear(user.SchoolId, entity);
                        if (saved != null)
                        {
                            var btn = sender as Button;
                            if (btn != null)
                            {
                                if (btn.ID == "btnSaveAndAddSessions")
                                {
                                    Response.Redirect("~/Views/Academy/Session/Create.aspx?aId=" + saved.Id);
                                }
                                else
                                {
                                    Response.Redirect("~/Views/Academy/List.aspx?edit=1");
                                }
                            }
                           
                        }
                        else lblError.Visible = true;
                    }
                }
            }
        }

        public int AcademicId
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }




    }
}