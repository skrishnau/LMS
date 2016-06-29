using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Course.Section
{
    public partial class SectionUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSectionDetail();
        }

        #region Properties

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }

        public int SectionId
        {
            get { return Convert.ToInt32(hid.Value); }
            set { hid.Value = value.ToString(); }
        }

        public bool SummaryVisible
        {
            get { return lblSummary.Visible; }
            set { lblSummary.Visible = value; }
        }

        public bool ActivityPanelVisible
        {
            get { return pnlActAndRes.Visible; }
            set { pnlActAndRes.Visible = value; }
        }

        public List<string> List { get; set; }

        #endregion


        #region Functions

        void LoadSectionDetail()
        {
            using (var helper = new DbHelper.SubjectSection())
            {
                var section = helper.Find(SectionId);
                if (section != null)
                {
                    lblTitle.Text = section.Name;
                    lblSummary.Text = section.Summary;
                    var actAndRess = section.SubjectActivityAndResource;
                    foreach (var sar in actAndRess)
                    {
                        ActivityAndResourceUc uc =
                                    (ActivityAndResourceUc)Page.LoadControl("~/Views/Course/Section/ActivityAndResourceUc.ascx");
                        uc.Title = sar.Title;
                        uc.ActivityAndResourceId = sar.Id;
                        if (sar.ShowDesctiptionOnPage)
                            uc.Summary = sar.Description;
                        uc.Type = sar.Type;

                        pnlActAndRes.Controls.Add(uc);
                    }

                    foreach (var sar in section.Assignments)
                    {
                        ActivityAndResourceUc uc =
                                    (ActivityAndResourceUc)Page.LoadControl("~/Views/Course/Section/ActivityAndResourceUc.ascx");
                        uc.Title = sar.Name;
                        uc.ActivityAndResourceId = sar.Id;
                        if (sar.DispalyDescriptionOnPage??false)
                            uc.Summary = sar.Description;
                        uc.ImageUrl = Enums.ActivityImagePath[(int) Enums.Activities.Assignment];
                        uc.Type = "Assignment";

                        pnlActAndRes.Controls.Add(uc);
                    }
                }
            }
        }



        //private void LoadActivityAndResources()
        //{
        //    using (var helper = new DbHelper.SubjectSection())
        //    {
        //        var lst = helper.GetActivityAndResourcesOfSection(SectionId);
        //        foreach (var item in lst)
        //        {
        //            ActivityAndResourceUc uc =
        //                (ActivityAndResourceUc) Page.LoadControl("~/Views/Course/Section/ActivityAndResourceUc.ascx");
        //            uc.Type = "";
        //            pnlActAndRes.Controls.Add(uc);
        //        }
        //    }   
        //}

        #endregion

        //Edit section click
        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            var url = "~/Views/Course/Section/CreateSection.aspx" + "?SecId=" + SectionId;
            ////// url += "&ReturnUrl=" + Request.Url.PathAndQuery;
            url += "&ReturnUrl=" + Request.Url.AbsolutePath;
            url += "&SubId=" + this.SubjectId;
            Response.Redirect(url);


            //string url = "~/Views/Course/Section/CreateSection.aspx";
            //string url = "~/Views/Course/Section/Master/test_uc_delete_on_unused.ascx";
            //Server.TransferRequest(url, false);
        }

        //add resource clicked
        protected void lnkAddActOrRes_Click(object sender, EventArgs e)
        {
            //string url = "~/Views/Course/ActivityAndResource/CreteActNRes.aspx" + "?Id=" + SectionId.ToString();
            string url = "~/Views/Course/ActivityAndResource/ActResChoose/ActResChoose.aspx" 
                + "?SecId=" + SectionId
                +"&SubId="+SubjectId;

            Response.Redirect(url);
        }
    }
}