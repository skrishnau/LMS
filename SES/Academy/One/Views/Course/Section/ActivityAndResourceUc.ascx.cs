using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.Section
{
    public partial class ActivityAndResourceUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        #region Properties

        public bool ActOrRes
        {
            get { return Convert.ToBoolean(hidActOrRes.Value); }
            set { hidActOrRes.Value = value.ToString(); }
        }

        public string Title { get { return lblTitle.Text; } set { lblTitle.Text = value; } }
        public string Description { get { return lblDescription.Text; } set { lblDescription.Text = value; } }
        public string ImageUrl { get { return imgIcon.ImageUrl; } set { imgIcon.ImageUrl = value; } }

        public int ActResId
        {
            get { return Convert.ToInt32(hidActOrResId.Value); }
            set { hidActOrResId.Value = value.ToString(); }
        }

        public string ActResType
        {
            get { return hidType.Value; }
            set { hidType.Value = value; }
        }

        #endregion


        public void SetData(bool actOrRes, string title, string description, int actResId, string actResType, string imageUrl, string navigateUrl
            , int sectionId, bool edit, int subjectId,string editurl, bool enable = true)
        {
            if (edit)
            {
                pnlHeading.CssClass = "course-act-res-whole-in-edit-mode";
                lnkEdit.Visible = true;
                lnkEdit.NavigateUrl = editurl+ "?SubId=" + subjectId + "&arId=" + actResId + "&secId=" + sectionId + "&edit=" + (edit ? 1 : 0);;
            }
            else
            {
                pnlHeading.CssClass = "course-act-res-whole";
            }

            ActOrRes = actOrRes;
            Title = title;
            Description = description;
            ActResId = actResId;
            ActResType = actResType;

            
            lblTitle.NavigateUrl = navigateUrl + "?SubId=" + subjectId + "&arId=" + actResId + "&secId=" + sectionId + "&edit=" + (edit ? 1 : 0);
            imgIcon.ImageUrl = imageUrl;

            lblTitle.Enabled = enable;
            imgIcon.Visible = enable;
            if (!enable)
            {
                lblTitle.CssClass = "course-act-res-title-of-label";
            }
            if (string.IsNullOrEmpty(description))
            {
                divDescription.Visible = false;
            }
        }


        //edit
        protected void imgEditBtn_Click(object sender, ImageClickEventArgs e)
        {
            //display delete button

        }
    }
}