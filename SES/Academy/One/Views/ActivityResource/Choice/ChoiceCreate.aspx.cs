using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using Academic.DbEntities.ActivityAndResource.ChoiceItems;
using Academic.DbHelper;
using Academic.ViewModel;


namespace One.Views.ActivityResource.Choice
{
    public partial class ChoiceCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                var cId = Request.QueryString["cId"];
                var edit = Request.QueryString["edit"];
                try
                {
                    var guid = Guid.NewGuid();
                    hidPageKey.Value = guid.ToString();

                    if (subId != null && secId != null)
                    {
                        SectionId = Convert.ToInt32(secId);
                        SubjectId = Convert.ToInt32(subId);
                    }
                    if (cId != null && edit != null)
                    {
                        if (edit == "1")
                            SetChoiceValues(Convert.ToInt32(cId));
                        else ViewState["Options" + hidPageKey.Value] = GetInitialBlankOptions();
                    }
                    else
                    {
                        ViewState["Options" + hidPageKey.Value] =
                            GetInitialBlankOptions();
                    }



                    //ViewState["Options" + hidPageKey.Value] =
                    //    new List<Academic.DbEntities.ActivityAndResource.ChoiceItems.ChoiceOptions>();
                }
                catch
                {
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }
            }

            PopulateOptions();
        }

        #region Functions

        private void PopulateOptions()
        {
            var count = Convert.ToInt32(hidCountOfOptions.Value);

            var options = ViewState["Options" + hidPageKey.Value] as
                List<ChoiceViewModel>;
            //var count = pnlOptions.Controls.Count;

            if (options != null)
            {
                int i = 1;
                foreach (var o in options)
                {
                    var uc = (ChoiceOptionsCreate)Page.LoadControl
                    ("~/Views/ActivityResource/Choice/ChoiceOptionsCreate.ascx");
                    //uc.SetValues("Option" + i, "Limit" + i, ddlLimitTheNumberOfResponses.SelectedIndex == 1);
                    uc.SetValues(ChoiceId, o.Id, o.OptionName, o.LimitName, o.Option, o.Limit ?? 0
                        , ddlLimitTheNumberOfResponses.SelectedIndex == 1);
                    uc.ID = "optionuc" + o.Id;
                    uc.Position = o.Position;
                    uc.Visible = o.Visible;
                    uc.RemoveClicked += uc_RemoveClicked;
                    if (i < 3)
                        uc.RemoveButtonVisibility = false;
                    uc.PageKey = hidPageKey.Value;
                    pnlOptions.Controls.Add(uc);
                    i++;
                }
            }
        }

        private List<ChoiceViewModel> GetInitialBlankOptions()
        {
            return new List<ChoiceViewModel>()
            {
                new ChoiceViewModel()
                {
                    Option = "",Limit = 0,Id = -1,Position=1
                    ,OptionName = "Option1", LimitName = "Limit1"
                    ,Visible=true
                }
                ,
                new ChoiceViewModel()
                {
                    Option = "",Limit = 0,Id = -2,Position=2 
                    ,OptionName = "Option2", LimitName = "Limit2" 
                    ,Visible=true
                }
            };
        }

        private void SetChoiceValues(int choiceId)
        {
            using (var helper = new Academic.DbHelper.DbHelper.ActAndRes())
            {
                var choice = helper.GetChoiceActivity(choiceId);
                if (choice != null)
                {
                    ChoiceId = choiceId;
                    txtName.Text = choice.Name;
                    txtDescription.Text = choice.Description;

                    chkDisplayDescription.Checked = choice.DisplayDescriptionOnCoursePage;
                    chkShowPreview.Checked = choice.ShowPreview;

                    ddlPrivacyOfResults.SelectedIndex = (choice.PublishResults == 0) ? 0 : 1;
                    ddlPublishResults.SelectedIndex = choice.PublishResults;
                    ddlAllowChoiceToBeUpdated.SelectedIndex = choice.AllowChoiceTobeUpdated ? 1 : 0;
                    ddlAllowMoreChoiceToBeSelected.SelectedIndex = choice.AllowMoreThanOneChoiceToBeSelected ? 1 : 0;
                    ddlDisplayModeForOptions.SelectedIndex = choice.DisplayModeForOptions ? 1 : 0;
                    ddlIncludeResponsesFromInactiveUsers.SelectedIndex = choice.IncludeResponsesFromInactiveUsers ? 1 : 0;
                    ddlLimitTheNumberOfResponses.SelectedIndex = choice.LimitTheNumberOfResponsesAllowed ? 1 : 0;
                    ddlShowColumnsForUnanswered.SelectedIndex = choice.ShowColumnForUnAnswered ? 1 : 0;

                    //DataList

                    chkRestrictAnsweringTime.Checked = choice.RestrictTimePeriod;
                    if (choice.RestrictTimePeriod)
                    {
                        if (choice.OpenDate != null)
                            txtOpenDate.Text = choice.OpenDate.Value.ToShortDateString();
                        if (choice.UntilDate != null)
                            txtUntilDate.Text = choice.UntilDate.Value.ToShortDateString();
                    }

                    var lst = new List<ChoiceViewModel>();
                    var choiceOptions = choice.ChoiceOptions.OrderBy(m => m.Position).ToList();
                    int i = 1;
                    foreach (var co in choiceOptions)
                    {
                        lst.Add(new ChoiceViewModel()
                        {
                            Id = co.Id
                            ,
                            ChoiceActivityId = co.ChoiceActivityId
                            ,
                            Option = co.Option
                            ,
                            Limit = co.Limit
                            ,
                            LimitName = "Limit" + i
                            ,
                            OptionName = "Option" + i
                        });
                        i++;
                    }
                    ViewState["Options" + hidPageKey.Value] = lst;
                }
            }
        }

        #endregion

        #region Properties

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

        public int ChoiceId
        {
            get { return Convert.ToInt32(hidChoiceId.Value); }
            set { hidChoiceId.Value = value.ToString(); }
        }

        #endregion

        #region Events callback

        protected void ddlPublishResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            // the below are commented beacuse these features are not used
            if (ddlPublishResults.SelectedIndex == 0)
            {
                //ddlPrivacyOfResults.Enabled = false;
                //ddlShowColumnsForUnanswered.Enabled = false;
                //ddlIncludeResponsesFromInactiveUsers.Enabled = false;
            }
            else
            {
                //ddlPrivacyOfResults.Enabled = true;
                //ddlShowColumnsForUnanswered.Enabled = true;
                //ddlIncludeResponsesFromInactiveUsers.Enabled = true;
            }
        }

        protected void chkRestrictAnsweringTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRestrictAnsweringTime.Checked)
            {
                txtOpenDate.Enabled = true;
                txtUntilDate.Enabled = true;
            }
            else
            {
                txtOpenDate.Enabled = false;
                txtUntilDate.Enabled = false;
            }
        }

        protected void ddlLimitTheNumberOfResponses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(ddlLimitTheNumberOfResponses.SelectedIndex==0)
            //disable limit in options
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var list = new List<Academic.DbEntities.ActivityAndResource.ChoiceItems.ChoiceOptions>();

                var limitResponses = ddlLimitTheNumberOfResponses.SelectedIndex == 1;
                var choiceId = ChoiceId;

                var choice = new Academic.DbEntities.ActivityAndResource.ChoiceActivity()
                {
                    Id = choiceId,
                    Name = txtName.Text
                    ,
                    Description = txtDescription.Text
                    ,
                    DisplayDescriptionOnCoursePage = chkDisplayDescription.Checked
                    ,
                    DisplayModeForOptions = ddlDisplayModeForOptions.SelectedIndex == 1
                    ,
                    AllowChoiceTobeUpdated = ddlAllowChoiceToBeUpdated.SelectedIndex == 1
                    ,
                    AllowMoreThanOneChoiceToBeSelected = ddlAllowMoreChoiceToBeSelected.SelectedIndex == 1
                    ,
                    LimitTheNumberOfResponsesAllowed = limitResponses
                    ,
                    RestrictTimePeriod = chkRestrictAnsweringTime.Checked
                    ,
                    IncludeResponsesFromInactiveUsers = ddlIncludeResponsesFromInactiveUsers.SelectedIndex == 1
                    ,
                    PublishResults = (byte)ddlPublishResults.SelectedIndex
                    ,
                    //PrivacyOfResults = ddlPrivacyOfResults.SelectedIndex == 1
                    //,
                    ShowColumnForUnAnswered = ddlShowColumnsForUnanswered.SelectedIndex == 1
                    ,
                    ShowPreview = chkShowPreview.Checked
                    ,

                };
                if (chkRestrictAnsweringTime.Checked)
                {
                    choice.OpenDate = Convert.ToDateTime(txtOpenDate.Text);
                    choice.UntilDate = Convert.ToDateTime(txtUntilDate.Text);
                }
                else
                {
                    choice.OpenDate = null;
                    choice.UntilDate = null;
                }

                if (ddlPublishResults.SelectedIndex == 0)
                {
                    choice.PrivacyOfResults = false;
                }
                else
                {
                    choice.PrivacyOfResults = ddlPrivacyOfResults.SelectedIndex == 1;
                }


                //choice options
                foreach (var c in pnlOptions.Controls)
                {
                    var uc = c as ChoiceOptionsCreate;
                    if (uc != null)
                    {
                        if (uc.Visible)
                        {

                            list.Add(new ChoiceOptions()
                            {
                                Id = uc.OptionId
                                ,
                                Position = uc.Position
                                ,
                                Limit = (limitResponses) ? uc.LimitValue : 0
                                ,
                                Option = uc.OptionValue
                                ,
                                ChoiceActivityId = choiceId
                            });
                        }
                    }
                }

                var restriction = new Academic.DbEntities.AccessPermission.Restriction()
                {

                };

                using (var helper = new Academic.DbHelper.DbHelper.ActAndRes())
                {
                    var saved = helper.AddOrUpdateChoiceActivity(choice, list, SectionId,restriction);
                    if (saved != null)
                    {
                        Response.Redirect("~/Views/ActivityResource/Choice/ChoiceView.aspx" + "?SubId="
                                          + SubjectId + "&arId=" + saved.Id + "&secId=" + SectionId);//+ "&edit=" + (edit ? 1 : 0););
                    }
                }
            }
        }

        protected void lnkAddMoreOptions_Click(object sender, EventArgs e)
        {

            var options = ViewState["Options" + hidPageKey.Value] as
                List<ChoiceViewModel>;
            if (options != null)
            {
                var min = -3;
                var pos = 0;
                try
                {
                    min = options.Min(x => x.Id);
                    if (min >= 0)
                        min = -1;
                }

                catch { }
                try
                {
                    pos = options.Max(x => x.Position);
                }
                catch { }

                var count = Convert.ToInt32(hidCountOfOptions.Value);
                //count;
                //var uc = (ChoiceOptionsCreate)Page.LoadControl
                //    ("~/Views/ActivityResource/Choice/ChoiceOptionsCreate.ascx");
                //uc.SetValues("Option" + count, "Limit" + count, ddlLimitTheNumberOfResponses.SelectedIndex == 1);
                //uc.SetValues(ChoiceId, min - 1, "Option" + count, "Limit" + count, "", 0, ddlLimitTheNumberOfResponses.SelectedIndex == 1);



                //uc.SetValues("Option","Limit",true);

                //uc.RemoveClicked += uc_RemoveClicked;
                hidCountOfOptions.Value = (count + 1).ToString();

                //Option = "",Limit = 0,Id = -2,Position=2 
                //    ,OptionName = "Option2", LimitName = "Limit2" 
                //    ,Visible=true
                var o = new ChoiceViewModel()
                {
                    //ChoiceActivityId = ChoiceId
                    //,
                    Limit = 0
                    ,
                    Option = ""
                    ,
                    Id = min - 1
                    ,
                    LimitName = "Limit" + (count + 1)
                    ,
                    OptionName = "Option" + (count + 1)
                    ,
                    Position = pos + 1
                    ,
                    Visible = true
                };
                options.Add(o);

                var uc = (ChoiceOptionsCreate)Page.LoadControl
                    ("~/Views/ActivityResource/Choice/ChoiceOptionsCreate.ascx");
                //uc.SetValues("Option" + i, "Limit" + i, ddlLimitTheNumberOfResponses.SelectedIndex == 1);
                uc.SetValues(ChoiceId, o.Id, o.OptionName, o.LimitName, o.Option, o.Limit ?? 0
                    , ddlLimitTheNumberOfResponses.SelectedIndex == 1);
                uc.ID = "optionuc" + o.Id;
                uc.Position = o.Position;
                uc.Visible = o.Visible;
                uc.RemoveClicked += uc_RemoveClicked;
                uc.RemoveButtonVisibility = true;
                uc.PageKey = hidPageKey.Value;
                pnlOptions.Controls.Add(uc);

                //uc.SetValues(o.ChoiceActivityId, o.optionId, o.OptionName + (count + 1)
                //    , "Limit" + (count + 1), "", 0
                //    , ddlLimitTheNumberOfResponses.SelectedIndex == 1);
            }
        }

        public void uc_RemoveClicked(object sender, Academic.ViewModel.IdAndNameEventArgs e)
        {
            var send = sender as ChoiceOptionsCreate;
            if (send != null)
            {

                var options = ViewState["Options" + hidPageKey.Value] as
                List<ChoiceViewModel>;
                if (options != null)
                {
                    var opt = options.Find(x => x.Id == send.OptionId);
                    if (opt != null)
                    {
                        var count = Convert.ToInt32(hidCountOfOptions.Value);
                        //pnlOptions.Controls.Remove(send);
                        send.Visible = false;
                        //hidCountOfOptions.Value = (count - 1).ToString();
                        opt.Visible = false;
                    }
                }
            }
        }

        #endregion

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(DbHelper.StaticValues.WebPagePath.CourseDetailPage(SubjectId, SectionId));            
        }
    }
}