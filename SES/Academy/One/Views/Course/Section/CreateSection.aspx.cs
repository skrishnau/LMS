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
                                lblHeading.Text = "Section Edit";
                                //btnDelete.Visible = true;
                                txtName.Text = section.Name;
                                txtDesc.Text = section.Summary;
                                chkShow.Checked = section.ShowSummary ?? false;

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
            set { hidSubjectId.Value = value.ToString(); }
        }

        public int SectionId
        {
            get { return (int)(ViewState["SectionId"] ?? 0); }
            set { ViewState["SectionId"] = value; }
        }

        public string RedirectUrl
        {
            get { return (string)(ViewState["RedirectUrl"] ?? ""); }
            set { ViewState["RedirectUrl"] = value; }
        }

        //protected void lnkAccessPermission_Click(object sender, EventArgs e)
        //{
        //    pnlAccessPermission.Visible = !pnlAccessPermission.Visible;
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.SubjectSection())
            {
                var sec = new Academic.DbEntities.Subjects.SubjectSection()
                {
                    Id = SectionId
                   ,
                    Name = txtName.Text
                    ,
                    Summary = txtDesc.Text
                    ,
                    ShowSummary = chkShow.Checked
                        //,Restrictions = 
                   ,
                    SubjectId = SubjectId
                };
                var saved = helper.AddOrUpdateSection(sec);


                if (saved!=null)
                {
                    Response.Redirect("~/Views/Course/Section/?SubId=" + SubjectId + "&edit=1" + "#section_"+saved.Id);
                    //OnSaveEvent(this, DbHelper.StaticValues.SuccessSaveMessageEventArgs);
                }
                else
                {
                    lblError.Visible = true;
                    //OnSaveEvent(this, DbHelper.StaticValues.ErrorSaveMessageEventArgs);
                }

                //else if (!String.IsNullOrEmpty(RedirectUrl))
                //{
                //    ViewState["Saved"] = saved;
                //    string url = RedirectUrl + "?SubId=" + SubjectId;
                //    Response.Redirect(url);
                //}
            }
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    using (var helper = new DbHelper.SubjectSection())
        //    {
        //        bool deleted = helper.MakeSectionVoid(SectionId);
        //        //if (OnSaveEvent != null)
        //        {
        //            if (deleted)
        //            {
        //                //OnSaveEvent(this, DbHelper.StaticValues.SuccessDeleteMessageEventArgs);
        //            }
        //            else
        //            {
        //                //OnSaveEvent(this, DbHelper.StaticValues.ErrorDeleteMessageEventArgs);

        //            }
        //        }
        //        //else if (!String.IsNullOrEmpty(RedirectUrl))
        //        //{
        //        //    ViewState["Saved"] = deleted;
        //        //    string url = RedirectUrl + "?SubId=" + SubjectId;
        //        //    Response.Redirect(url);
        //        //}
        //    }
        //}

        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{

        //}

        //protected void btnClose_Click(object sender, ImageClickEventArgs e)
        //{
        //    txtDesc.Text = "";
        //    txtName.Text = "";
        //    //Restrictions nullify

        //    //if (OnCloseClick != null)
        //    {
        //        //OnCloseClick(this, DbHelper.StaticValues.CancelClickedMessageEventArgs);
        //    }
        //    //else if (!String.IsNullOrEmpty(RedirectUrl))
        //    //{
        //    //    ViewState["Saved"] = true;
        //    //    string url = RedirectUrl + "?SubId=" + SubjectId;
        //    //    Response.Redirect(url);
        //    //}
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Course/Section/?SubId="+SubjectId+"edit=1"+"#last");
            //txtDesc.Text = "";
            //txtName.Text = "";
            //Restrictions nullify

            //if (OnCloseClick != null)
            //{
            //    OnCloseClick(this, DbHelper.StaticValues.CancelClickedMessageEventArgs);
            //}
            //else if (!String.IsNullOrEmpty(RedirectUrl))
            //{
            //    ViewState["Saved"] = true;
            //    string url = RedirectUrl + "?SubId=" + SubjectId;
            //    Response.Redirect(url);
            //}
        }
    }
}