using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.ActivityResource.Label
{
    public partial class LabelCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                var lId = Request.QueryString["lId"];
                var edit = Request.QueryString["edit"];
                try
                {
                    if (subId != null && secId != null)
                    {
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = Convert.ToInt32(subId);
                    }
                    if (lId != null && edit != null)
                    {
                        if (edit == "1")
                            SetPageValues(Convert.ToInt32(lId));
                    }
                }
                catch
                {
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }

                var guid = Guid.NewGuid();
                hidPageKey.Value = guid.ToString();

                //FilesDisplay1.PageKey = guid.ToString();
            }
        }

        private void SetPageValues(int labelId)
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var label = helper.GetLabelResource(labelId);
                if (label != null)
                {
                    hidLabelId.Value = label.Id.ToString();

                }
            }
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

        public string PageKey
        {
            get { return hidPageKey.Value; }
        }
        public int LabelId
        {
            get { return Convert.ToInt32(hidLabelId.Value); }
            set { hidLabelId.Value = value.ToString(); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var label = new Academic.DbEntities.ActivityAndResource.LabelResource()
            {
                Id = LabelId,
                Text = txtLabelText.Text
            };

            if (SectionId > 0)
            {
                var restriction = new Academic.DbEntities.AccessPermission.Restriction()
                {

                };
                using (var helper = new DbHelper.ActAndRes())
                {
                    var saved = helper.AddOrUpdateLabelResource(label, SectionId,restriction);
                    if (saved != null)
                    {
                        Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId, SectionId));
                        //Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
                    }
                }
            }
        }


    }
}