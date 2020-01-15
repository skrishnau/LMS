using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

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

                        using (var strhelper = new DbHelper.Structure())
                        using (var helper = new DbHelper.SubjectSection())
                        {
                            var section = helper.GetSection(sectionId);
                            if (section != null)
                            {
                                LoadSitemap(strhelper, section.Subject);
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
                        using (var strhelper = new DbHelper.Structure())
                        using (var helper = new DbHelper.Subject())
                        {
                            var sub = helper.GetCourse(subjectId);
                            if (sub != null)
                            {
                                LoadSitemap(strhelper, sub);
                                lblHeading.Text = "New section in : '" + sub.FullName + "'";

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

        void LoadSitemap(DbHelper.Structure strHelper, Academic.DbEntities.Subjects.Subject sub)
        {
            var fromCls = Request.QueryString["from"];
            var yId = Request.QueryString["yId"];
            var sId = Request.QueryString["sId"];
            if (SiteMap.CurrentNode != null)
            {
                var list = new List<IdAndName>()
                        {
                           new IdAndName(){
                                        Name=SiteMap.RootNode.Title
                                        ,Value =  SiteMap.RootNode.Url
                                        ,Void=true
                                    },
                        };
                if (sId != null && yId != null)
                {
                    //lnkEdit.NavigateUrl += "&yId=" + yId + "&sId=" + sId;
                    list.Add(new IdAndName()
                    {
                        Name = "Manage Programs"
                        ,
                        Value = "~/Views/Structure/"
                        ,
                        Void = true
                    });
                    list.Add(new IdAndName()
                    {
                        Name = strHelper.GetSructureDirectory(Convert.ToInt32(yId), Convert.ToInt32(sId))
                        ,
                        Value = "~/Views/Structure/CourseListing.aspx?yId=" + yId + "&sId=" + sId
                        ,
                        Void = true
                    });
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName,
                         Value = "~/Views/Course/Section/default.aspx?SubId="+sub.Id
                        ,Void = true,
                    });
                }
                else if (fromCls != null)
                {
                    //lnkEdit.NavigateUrl += "&frmDetailView=" + fromCls;
                    list.Add(new IdAndName()
                    {
                        Name = SiteMap.CurrentNode.ParentNode.ParentNode.Title
                        ,
                        Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url
                        ,
                        Void = true
                    });
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName
                        ,
                        Value = "~/Views/Course/CourseDetail.aspx?cId=" + sub.Id
                        ,
                        Void = true
                    });
                    list.Add(new IdAndName() { Name = "View" });
                }
                else
                {
                    list.Add(new IdAndName()
                    {
                        Name = sub.FullName
                        ,
                        Value = "~/Views/Course/Section/default.aspx?SubId="+sub.Id
                        ,Void = true,
                        //Value = "~/Views/Course/CourseDetail.aspx?cId=" + sub.Id
                        //,
                        //Void = true
                    });
                }
                list.Add(new IdAndName()
                {
                    Name = "Section edit"
                });
                SiteMapUc.SetData(list);
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
                var saved = helper.AddOrUpdateSection(sec, restriction);


                if (saved != null)
                {
                    Response.Redirect("~/Views/Course/Section/?SubId=" + SubjectId + "&edit=1" + "#section_" + saved.Id);
                }
                else
                {
                    lblError.Visible = true;
                }
            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Course/Section/?SubId=" + SubjectId + "&edit=1" + "#section_" + SectionId);

        }
    }
}