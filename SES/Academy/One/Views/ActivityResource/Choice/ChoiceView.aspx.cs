using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.ActivityAndResource.ChoiceItems;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.ActivityResource.Choice
{
    public partial class ChoiceView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["SecId"];
                var arId = Request.QueryString["arId"];
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
                    if (arId != null)
                    {
                        ChoiceId = Convert.ToInt32(arId);
                        //PopulateOptions();
                    }
                }
                catch
                {
                    Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                }
            }

            PopulateOptions();
        }

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

        public bool AllowMoreThanOneChoiceToBeUpdated
        {
            get { return Convert.ToBoolean(hidAllowMoreChoiceToBeSelected.Value); }
            set { hidAllowMoreChoiceToBeSelected.Value = value.ToString(); }
        }

        #endregion

        void PopulateOptions()
        {

            var user = Page.User as CustomPrincipal;
            if (user != null)
                using (var helper = new DbHelper.ActAndRes())
                using (var shelper = new DbHelper.Subject())
                {
                    //need to work out
                    //var enrolled = shelper.IsUserEnrolledToCourse(user.Id,SubjectId);

                    var choice = helper.GetChoiceActivity(ChoiceId);
                    ChoiceResponseView1.Visible = false;

                    if (choice != null)
                    {
                        var message = "";
                        //bool? showPreview = null;
                        var enabled = true;
                        var visible = true;
                        var choiceUsers = choice.ChoiceUsers.Where(x => x.UserId == user.Id).ToList();
                        var userAlreadySelected = choiceUsers.Any();

                        lblTitle.Text = choice.Name;
                        lblDescription.Text = choice.Description;

                        if (!userAlreadySelected)
                        {
                            if (choice.RestrictTimePeriod)
                            {
                                //can't be choosen till open date or after until date
                                var date = DateTime.Now.Date;
                                if (date < choice.OpenDate)
                                {
                                    message = "The response time has not started yet.<br/>";
                                    btnSave.Visible = false;
                                    enabled = false;
                                    //showPreview = choice.ShowPreview;
                                    visible = choice.ShowPreview;
                                }
                                else if (date > choice.UntilDate)
                                {
                                    message = "The response time has finished.<br/>";
                                    btnSave.Visible = false;
                                    enabled = false;
                                    visible = false;
                                    //showPreview = choice.ShowPreview;
                                }
                            }
                        }
                        else if (!choice.AllowChoiceTobeUpdated)
                        {
                            enabled = false;
                            btnSave.Visible = false;
                        }

                        //can be choosen -- if showPreview is true then the timelimit has crossed
                        // but still we have to show the choices, bt they shouldn't be selectable
                        //showpreview == null means that no date restriction is true

                        //user le select garisakyo ra update garna nadine , ho bhane dispaly garnu hudaina

                        #region show options for selections


                        if (visible)
                        {
                            if (choice.AllowMoreThanOneChoiceToBeSelected)
                            {
                                foreach (var c in choice.ChoiceOptions)
                                {
                                    var optionEnabled = enabled;
                                    var tooltip = false;
                                    if (choice.LimitTheNumberOfResponsesAllowed)
                                    {
                                        if (c.Limit <= c.ChoiceUsers.Count)
                                        {
                                            optionEnabled = false;
                                            tooltip = true;
                                        }
                                    }

                                    var choosen = c.ChoiceUsers.FirstOrDefault(x => x.UserId == user.Id
                                        && x.ChoiceOptionsId == c.Id);
                                    pnlOptions.Controls.Add(new CheckBox()
                                    {
                                        Text = c.Option
                                            //chk_optonId_choiceUserId
                                        ,
                                        ID = "chk_" + c.Id + "_" + ((choosen == null) ? 0 : choosen.Id)
                                        ,
                                        Checked = choosen != null
                                        ,
                                        Enabled = optionEnabled
                                        ,
                                        ToolTip = tooltip ? "Limit exceed. If you want to select this, then you better not answer." : ""

                                    });
                                    pnlOptions.Controls.Add(new Literal()
                                    {
                                        Text = (choice.DisplayModeForOptions) ? "<br />" : "&nbsp;"
                                    });

                                }
                            }
                            else
                            {

                                foreach (var c in choice.ChoiceOptions)
                                {
                                    var optionEnabled = enabled;
                                    var tooltip = false;
                                    if (choice.LimitTheNumberOfResponsesAllowed)
                                    {
                                        if (c.Limit >= c.ChoiceUsers.Count)
                                        {
                                            optionEnabled = false;
                                            tooltip = true;
                                        }
                                    }

                                    var choosen = c.ChoiceUsers.FirstOrDefault(x => x.UserId == user.Id);
                                    pnlOptions.Controls.Add(new RadioButton()
                                    {
                                        Text = c.Option
                                            //chk_optonId_choiceUserId
                                        ,
                                        ID = "chk_" + c.Id + "_" + ((choosen == null) ? 0 : choosen.Id)
                                        ,
                                        Checked = choosen != null
                                        ,
                                        GroupName = "choice"
                                        ,
                                        Enabled = optionEnabled
                                        ,
                                        ToolTip = tooltip ? "Limit exceed. If you want to select this, then you better not answer." : ""
                                    });
                                    pnlOptions.Controls.Add(new Literal()
                                    {
                                        Text = (choice.DisplayModeForOptions) ? "<br />" : "&nbsp;"
                                    });
                                }
                            }
                        }


                        #endregion


                        pnlOptions.Controls.Add(new Literal()
                        {
                            Text = "<br/><div style='text-align:center; color:red; font-weight:600;'>"
                            +
                            message
                            + "</div>"
                        });

                        SetPrivacyOfResults(choice, user.Id, userAlreadySelected);
                    }
                }
        }



        private void SetPrivacyOfResults(
            Academic.DbEntities.ActivityAndResource.ChoiceActivity choice, int userId, bool userAlreadySelected)
        {
            string message = "";
            //var selected = choice.ChoiceUsers.Where(x => x.UserId == userId).ToList();
            //var any = false;
            //try
            //{
            //    any = selected.Any();

            //}
            //catch { }

            switch (choice.PublishResults)
            {
                case 0:
                    if (userAlreadySelected)
                    {
                        message = "The results are not currently available";
                        lblMessage.Text = message;
                    }
                    ChoiceResponseView1.Visible = false;
                    break;
                case 1:
                    if (userAlreadySelected)
                    {
                        ShowResult(choice);
                    }
                    else
                    {
                        ChoiceResponseView1.Visible = false;
                        //message = "The results are not currently available";
                        //lblMessage.Text = message;
                    }
                    break;
                case 2:
                    if ((choice.UntilDate ?? DateTime.MaxValue) < DateTime.Now)
                    {
                        //show result
                        ShowResult(choice);
                    }
                    else
                    {
                        ChoiceResponseView1.Visible = false;
                        if (userAlreadySelected)
                        {
                            message = "The results are not currently available";
                            lblMessage.Text = message;
                        }
                    }
                    break;
                case 3:
                    //always show
                    ShowResult(choice);
                    break;
            }
        }

        void ShowResult(Academic.DbEntities.ActivityAndResource.ChoiceActivity choice)
        {
            var lst = new List<Academic.ViewModel.ChoiceResultViewModel>();
            var totalCount = choice.ChoiceUsers.Count;
            foreach (var c in choice.ChoiceOptions)
            {
                var usersCount = c.ChoiceUsers.Count;
                var percent = (0.00);
                if (totalCount != 0)
                    percent = (((1.0 * usersCount) / totalCount * 100));
                lst.Add(new ChoiceResultViewModel()
                {
                    Id = c.Id
                    ,
                    ChoiceOption = c.Option
                    ,
                    NumberOfResponses = usersCount
                    ,
                    PercentageOfResponses = percent.ToString("N")

                });
            }
            ChoiceResponseView1.Visible = true;
            ChoiceResponseView1.SetData(lst);
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var user = Page.User as CustomPrincipal;

                if (user != null)
                {
                    var addedlist = new List<ChoiceUser>();
                    var removedlist = new List<ChoiceUser>();
                    var choiceId = ChoiceId;
                    foreach (var o in pnlOptions.Controls)
                    {
                        var choose = o as CheckBox;
                        if (choose != null)
                        {
                            var ids = choose.ID.Split(new char[] { '_' });
                            var id = Convert.ToInt32(ids[2]);
                            if (choose.Checked)
                            {
                                addedlist.Add(new ChoiceUser()
                                {
                                    Id = Convert.ToInt32(ids[2])
                                    ,
                                    ChoiceActivityId = choiceId
                                    ,
                                    ChoiceOptionsId = Convert.ToInt32(ids[1])
                                    ,
                                    UserId = user.Id
                                    ,
                                });
                            }
                            else if (id > 0)
                            {
                                removedlist.Add(new ChoiceUser()
                                {
                                    Id = Convert.ToInt32(ids[2])
                                    ,
                                    ChoiceActivityId = choiceId
                                    ,
                                    ChoiceOptionsId = Convert.ToInt32(ids[1])
                                    ,
                                    UserId = user.Id
                                    ,
                                });
                            }
                        }
                    }
                    var saved = helper.SaveChoice(addedlist, removedlist);
                    if (saved)
                    {
                        Response.Redirect(Page.Request.Url.PathAndQuery);
                    }
                }


            }
        }
    }
}