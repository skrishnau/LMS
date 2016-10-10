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
        public event EventHandler<SubjectSectionEventArgs> AddActResClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSectionDetail();
            //LoadActivityResource();
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

        //public bool ActivityPanelVisible
        //{
        //    get { return pnlActAndRes.Visible; }
        //    set { pnlActAndRes.Visible = value; }
        //}

        public List<string> List { get; set; }

        public string SectionName
        {
            get { return hidSectionName.Value; }
            set
            {
                hidSectionName.Value = value;
                //section_.Attributes.Add("name","section_"+SectionId);
                //section_.ID = "section_" + SectionId;
            }
        }

        #endregion


        #region Functions

        void LoadSectionDetail()
        {
            using(var ahelper = new DbHelper.ActAndRes())
            using (var helper = new DbHelper.SubjectSection())
            {
                var section = helper.Find(SectionId);
                if (section != null)
                {
                    lnkAddActOrRes.ID = "lnkAddActOrRes_" + SubjectId + "_" + SectionId;
                    lnkAddActOrRes.Attributes.Add("name", SectionName);
                    lblTitle.Text = section.Name;
                    lblSummary.Text = section.Summary;


                    var ars = ahelper.ListActivitiesAndResourcesOfSection(SectionId);
                    foreach (var ar in ars)
                    {
                        var arUc =
                            (ActivityAndResourceUc)
                                Page.LoadControl("~/Views/Course/Section/ActivityAndResourceUc.ascx");
                       
                        arUc.SetData(ar.ActivityOrResource,ar.Name,ar.Description
                            ,ar.ActivityResourceId,ar.ActivityResourceType.ToString(),ar.IconUrl,ar.NavigateUrl
                            ,SectionId,EditEnabled,SubjectId, ar.Enable);

                       pnlActAndRes.Controls.Add(arUc);
                    }
                    //var actAndRess = section.SubjectActivityAndResource;

                    //foreach (var sar in actAndRess)
                    //{
                    //    ActivityAndResourceUc uc =
                    //                (ActivityAndResourceUc)Page.LoadControl("~/Views/Course/Section/ActivityAndResourceUc.ascx");
                    //    uc.Title = sar.Title;
                    //    uc.ActivityAndResourceId = sar.Id;
                    //    if (sar.ShowDesctiptionOnPage)
                    //        uc.Summary = sar.Description;
                    //    uc.Type = sar.Type;

                    //    pnlActAndRes.Controls.Add(uc);
                    //}

                    //foreach (var sar in section.Assignments)
                    //{
                    //    ActivityAndResourceUc uc =
                    //                (ActivityAndResourceUc)Page.LoadControl("~/Views/Course/Section/ActivityAndResourceUc.ascx");
                    //    uc.Title = sar.Name;
                    //    uc.ActivityAndResourceId = sar.Id;
                    //    if (sar.DispalyDescriptionOnPage??false)
                    //        uc.Summary = sar.Description;
                    //    uc.ImageUrl = Enums.ActivityImagePath[(int) Enums.Activities.Assignment];
                    //    uc.Type = "Assignment";

                    //    pnlActAndRes.Controls.Add(uc);
                    //}
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
            //string url = "~/Views/Course/ActivityAndResource/ActResChoose/ActResChoose.aspx"
            //    + "?SecId=" + SectionId
            //    + "&SubId=" + SubjectId;

            //Response.Redirect(url);

            if (AddActResClicked != null)
            {
                AddActResClicked(this, new SubjectSectionEventArgs()
                {
                    SectionId = SectionId
                    ,
                    SubjectId = SubjectId
                    ,
                    SectionName = SectionName
                });
            }
        }

        public bool EditEnabled
        {
            set
            {
                lnkEdit.Visible = value;
                lnkEdit.Enabled = value;
                lnkAddActOrRes.Enabled = value;
                lnkAddActOrRes.Visible = value;
            }
            get { return lnkEdit.Visible; }
        }
    }
}