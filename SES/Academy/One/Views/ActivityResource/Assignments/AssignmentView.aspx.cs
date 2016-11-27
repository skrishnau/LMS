using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.ActivityResource.Assignments
{
    public partial class AssignmentView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var aId = Request.QueryString["arId"];
                    var subId = Request.QueryString["SubId"];
                    var secId = Request.QueryString["secId"];

                    var edit = Request.QueryString["edit"];

                    if (aId != null)
                    {
                        var assId = Convert.ToInt32(aId);
                        AssignmentId = assId;
                        LoadActivity(assId);
                    }

                    if (subId != null)
                    {
                        SubjectId = Convert.ToInt32(subId);
                        if (secId != null)
                        {
                            SectionId = Convert.ToInt32(secId);
                        }
                    }

                }
                catch { }

            }
        }

        void LoadActivity(int assignmentId)
        {
            var user = Page.User as CustomPrincipal;
            if(user!=null)
            using (var helper = new DbHelper.ActAndRes())
            {
                var ass = helper.GetAssignment(assignmentId);
                if (ass != null)
                {
                    AssignmentId = assignmentId;
                    lblName.Text = ass.Name;
                    lblDescription.Text = ass.Description;

                    if (!(ass.FileSubmission && ass.OnlineText))
                    {
                        btnSubmit.Visible = false;
                    }
                    else
                    {
                        btnSubmit.Visible = true;
                    }

                    if (ass.Submissions.Any(x => x.UserClass.UserId == user.Id))
                    {
                        btnSubmit.Text = "Edit Submission";
                    }
                }
            }
            
        }

        public int AssignmentId
        {
            get { return Convert.ToInt32(hidAssignmentId.Value); }
            set { hidAssignmentId.Value = value.ToString(); }
        }

        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ActivityResource/Assignments/SubmitAssignmentCreate.aspx?arId=" 
                + AssignmentId+"&SubId="+SubjectId+"&secId="+SectionId);
        }
    }
}