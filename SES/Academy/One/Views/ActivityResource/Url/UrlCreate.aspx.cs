using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Url
{
    public partial class UrlCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                var uId = Request.QueryString["uId"];
                var edit = Request.QueryString["edit"];
                try
                {
                    if (subId != null && secId != null)
                    {
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = Convert.ToInt32(subId);
                    }
                    if (uId != null && edit != null)
                    {
                        if(edit=="1")
                            SetFileValues(Convert.ToInt32(uId));
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

        private void SetFileValues(int urlId)
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var url = helper.GetUrlResource(urlId);
                if (url != null)
                {
                    hidUrlId.Value = url.Id.ToString();
                    txtName.Text = url.Name;
                    CKEditor1.Text = url.Description;
                    txtExternalUrl.Text = url.Url;
                    ddlDisplay.SelectedIndex = url.Display;
                    if (url.Display == 3)
                    {
                        txtPopupHeightInPixel.Enabled = true;
                        txtPopupHeightInPixel.Text = url.PopupHeightInPixel.ToString();
                        txtPopupWidthInPixel.Enabled = true;
                        txtPopupWidthInPixel.Text = url.PopupWidthInPixel.ToString();
                    }
                    chkDisplayDescription.Checked = url.DisplayDescriptionOnPage;
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
        public int UrlResourceId
        {
            get { return Convert.ToInt32(hidUrlId.Value); }
            set { hidUrlId.Value = value.ToString(); }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var url = new Academic.DbEntities.ActivityAndResource.UrlResource()
            {
                Id = UrlResourceId,
                Name = txtName.Text
                ,Description = CKEditor1.Text
                ,DisplayDescriptionOnPage =  chkDisplayDescription.Checked
                ,Display = (byte) ddlDisplay.SelectedIndex
                ,Url = txtExternalUrl.Text
            };
            if (!string.IsNullOrEmpty(txtPopupHeightInPixel.Text) 
                &&!string.IsNullOrEmpty(txtPopupWidthInPixel.Text)
                &&ddlDisplay.SelectedIndex==3)
            {
                url.PopupHeightInPixel = Convert.ToInt32(txtPopupHeightInPixel.Text);
                url.PopupWidthInPixel = Convert.ToInt32(txtPopupWidthInPixel.Text);
            }
            using (var helper = new DbHelper.ActAndRes())
            {
                var saved = helper.AddOrUpdateUrlResource(url,SectionId);
                if (saved != null)
                {
                    Response.Redirect("~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId=" + SubjectId + "&edit=1#section_" + SectionId);
                }
            }
        }

        protected void ddlDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isPopup = ddlDisplay.SelectedIndex == 3;
            txtPopupWidthInPixel.Enabled = isPopup;
            txtPopupHeightInPixel.Enabled = isPopup;
        }


    }
}