using Academic.DbHelper;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actOrRes"></param>
        /// <param name="isNew"></param>
        /// <param name="newSubmission"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="actOrResId">ids of assignment , book etc.</param>
        /// <param name="actResId">id of ActivityResource table data</param>
        /// <param name="actResType"></param>
        /// <param name="imageUrl"></param>
        /// <param name="navigateUrl"></param>
        /// <param name="sectionId"></param>
        /// <param name="edit"></param>
        /// <param name="subjectId"></param>
        /// <param name="editurl"></param>
        /// <param name="typeName"></param>
        /// <param name="enable"></param>

        public void SetData(bool actOrRes,bool isNew,bool newSubmission, string title, string description, int actOrResId, int actResId
            , byte actResType, string imageUrl, string navigateUrl
            , int sectionId, bool edit, int subjectId,string editurl, string typeName, bool enable = true)
        {
            if (isNew)
            {
                imgNew.Visible = true;
                imgNew.ImageUrl = "~/Content/Icons/New/new_icon.png";
                imgNew.ToolTip = "New to you";
            }
            if (newSubmission)
            {
                imgNew.Visible = true;
                imgNew.ImageUrl = "~/Content/Icons/New/new_submission_icon.png";
                imgNew.ToolTip = "New submission pending for grade";
            }

            if (edit)
            {
                pnlHeading.CssClass = "course-act-res-whole-in-edit-mode";
                lnkEdit.Visible = true;
                lnkEdit.NavigateUrl = editurl+ "?SubId=" + subjectId + "&arId=" + actOrResId + "&secId=" + sectionId + "&edit=" + (edit ? 1 : 0);;
               
                var redUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=" +
                                                  DbHelper.StaticValues.Encode("actRes") +
                                                  "&crsId=" + subjectId +
                                                  "&secId=" + sectionId
                                                  +"&actResId="+actResId
                                                  //+ "&showText="
                                                  //+ DbHelper.StaticValues.Encode("Are you sure to delete the " 
                                                  //+ typeName.ToLower() +", "
                                                  //+ title + "?")
                                                  ;
                lnkDelete.Visible = true;
                lnkDelete.NavigateUrl = redUrl;
            }
            else
            {
                pnlHeading.CssClass = "course-act-res-whole";
            }

            ActOrRes = actOrRes;
            Title = title;
            Description = description;
            ActResId = actOrResId;
            ActResType = actResType.ToString();

            
            lblTitle.NavigateUrl = navigateUrl + "?SubId=" + subjectId + "&arId=" + actOrResId + "&secId=" + sectionId + "&edit=" + (edit ? 1 : 0);
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