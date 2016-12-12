using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.Section
{
    public partial class CreateSection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            var subId = Request.QueryString["SubId"];
            var secId = Request.QueryString["SecId"];
            if (!IsPostBack)
            {
                if (secId != null)
                {
                    try
                    {
                        var sectionId = Convert.ToInt32(secId);
                        SectionId = sectionId;
                        using (var helper = new DbHelper.SubjectSection())
                        {
                            var section = helper.GetSection(sectionId);
                            if (section != null)
                            {
                                SubjectId = section.SubjectId;
                                //btnDelete.Visible = true;
                                txtName.Text = section.Name;
                                txtDesc.Text = section.Summary;
                                chkShow.Checked = section.ShowSummary ?? false;
                                //after assigning section datatype , all is taken care in restrictionUC
                                RestrictionUC1.SectionId = sectionId;
                            }
                        }
                    }
                    catch
                    {
                        Response.Redirect("~/");                        
                    }
                    
                }
                else if (subId != null)
                {
                    try
                    {
                        var subjectId = Convert.ToInt32(subId);
                        SubjectId = subjectId;
                        using (var helper = new DbHelper.Subject())
                        {
                            var sub = helper.GetCourse(subjectId);
                            if (sub != null)
                            {
                                lblHeading.Text = "New section in : '"+sub.FullName+"'";

                            }
                            else
                            {
                                Response.Redirect("~/");
                            }
                        }
                    }
                    catch
                    {
                    Response.Redirect("~/");
                        
                    }
                    
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set
            {
                hidSubjectId.Value = value.ToString();
                RestrictionUC1.SubjectId = value;
            }
        }

        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.SubjectSection())
            {
                var restriction = RestrictionUC1.GetRestriction();
                if (!RestrictionUC1.IsValid)
                {
                    lblError.Visible = true;
                    return;
                }
                var sec = new Academic.DbEntities.Subjects.SubjectSection()
                {
                    Id = SectionId
                   ,
                    Name = txtName.Text
                    ,
                    Summary = txtDesc.Text
                    ,
                    ShowSummary = chkShow.Checked
                   ,
                    SubjectId = SubjectId
                };
                var saved = helper.AddOrUpdateSection(sec,restriction);


                if (saved!=null)
                {
                    Response.Redirect("~/Views/Course/Section/?SubId=" + SubjectId + "&edit=1" + "#section_"+saved.Id);
                }
                else
                {
                    lblError.Visible = true;
                }
            }
        }

     

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Course/Section/?SubId="+SubjectId+"&edit=1"+"#section_"+SectionId);
           
        }
    }
}