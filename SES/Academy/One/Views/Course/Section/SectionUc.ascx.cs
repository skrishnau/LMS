using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;
using One.Values.MemberShip;

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
            var user = Page.User as CustomPrincipal;
            if (user != null)
                using (var ahelper = new DbHelper.ActAndRes())
                using (var helper = new DbHelper.SubjectSection())
                {
                    var elligible = ElligibleToView;
                    var section = helper.Find(SectionId);
                    if (section != null)
                    {
                        if (EditEnabled)
                        {
                            pnlMain.CssClass = "hover-background-change-slight";
                        }
                    

                        lnkAddActOrRes.ID = "lnkAddActOrRes_" + SubjectId + "_" + SectionId;
                        lnkAddActOrRes.Attributes.Add("name", SectionName);
                        lblTitle.Text = section.Name;
                        lblSummary.Text = section.Summary;

                        var redUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task=" +
                                                   DbHelper.StaticValues.Encode("courseSection") +
                                                   "&crsId=" + SubjectId +
                                                   "&secId=" + SectionId
                                                   + "&showText="
                                                   + DbHelper.StaticValues.Encode("Are you sure to delete the section, " 
                                                   + section.Name + "?")
                                                   ;
                        lnkDelete.NavigateUrl = redUrl;


                        var editUrl = "~/Views/Course/Section/CreateSection.aspx" + "?SecId=" + SectionId+
                                         "&ReturnUrl=" + Request.Url.AbsolutePath+
                                         "&SubId=" + this.SubjectId;
                        lnkEdit.NavigateUrl = editUrl;



                        var ars = ahelper.ListActivitiesAndResourcesOfSection(UserId, SectionId, elligible);
                        foreach (var ar in ars)
                        {
                            //foreach(var cls in ar.)
                            var arUc =
                                (ActivityAndResourceUc)
                                    Page.LoadControl("~/Views/Course/Section/ActivityAndResourceUc.ascx");

                            arUc.SetData(ar.ActivityOrResource,ar.New,ar.NewSubmission, ar.Name, ar.Description
                                , ar.ActivityResourceId,ar.Id, ar.ActivityResourceType, ar.IconUrl, ar.NavigateUrl
                                , SectionId, EditEnabled, SubjectId, ar.CreateUrl,ar.ActivityResourceTypeName, ar.Enable);

                            pnlActAndRes.Controls.Add(arUc);
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
        protected void lnkDelete_Click(object sender, EventArgs e)
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

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }
        public bool ElligibleToView
        {
            get { return Convert.ToBoolean(hidElligibleToView.Value); }
            set { hidElligibleToView.Value = value.ToString(); }
        }

        public bool EditEnabled
        {
            set
            {
                lnkEdit.Visible = value;
                lnkEdit.Enabled = value;
                lnkDelete.Visible = value;
                lnkDelete.Enabled = value;
                lnkAddActOrRes.Enabled = value;
                lnkAddActOrRes.Visible = value;
            }
            get { return lnkEdit.Visible; }
        }

        public void SetData(bool editEnabled, bool showSummary, int subjectId, int subjectSectionId
            , string subjectSectionName, int userId, bool elligibleToView)
        {
            EditEnabled = editEnabled;
            SummaryVisible = showSummary;
            SubjectId = subjectId;
            SectionId = subjectSectionId;
            SectionName = subjectSectionName;
            UserId = userId;
            ElligibleToView = elligibleToView;
        }
    }
}