using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                lblConfirmCheck.Visible = false;
                lblPasswordError.Visible = false;
                lblQuestionSaveError.Visible = false;
                lblQuestionError.Visible = false;

                if (!IsPostBack)
                {
                    using (var helper = new DbHelper.User())
                    using(var file = new DbHelper.WorkingWithFiles())
                    {
                        var usr = helper.GetUser(user.Id);
                        if (usr != null)
                        {
                            if (SiteMap.CurrentNode != null)
                            {
                                var list = new List<IdAndName>()
                                {
                                   new IdAndName(){
                                                Name=SiteMap.RootNode.Title
                                                ,Value =  SiteMap.RootNode.Url
                                                ,Void=true
                                            },
                                    new IdAndName(){
                                        Name = SiteMap.CurrentNode.Title
                                        //,Value = SiteMap.CurrentNode.ParentNode.Url
                                        //,Void=true
                                    }
                                };
                                SiteMapUc.SetData(list);
                            }
                            lblName.Text = usr.FullName;
                            lblEmail.Text = usr.Email;
                            lblUsername.Text = usr.UserName;
                            //img.ImageUrl = usr.UserImage == null
                            //    ? ""
                            //    : usr.UserImage.FileDirectory + usr.UserImage.FileName;
                            img.ImageUrl = file.GetImageUrl(usr.UserImageId ?? 0);
                            ddlQuestion.DataSource = DbHelper.StaticValues.SecurityQuestion();
                            ddlQuestion.DataBind();
                        }
                    }
                }
            }

        }

        protected void lnkPassword_OnClick(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void lnkSecurityQuestion_OnClick(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void btnSavePassword_OnClick(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (txtConfirmPassword.Text.Equals(txtNewPassword.Text))
                {
                    using (var helper = new Academic.DbHelper.DbHelper.User())
                    {
                        var changed = helper.ChangePassword(user.Id, txtearlierPassword.Text, txtConfirmPassword.Text);
                        if (changed)
                        {
                            MultiView1.ActiveViewIndex = 0;
                            ResetPasswordControls();
                        }
                        else
                        {
                            lblPasswordError.Visible = true;
                        }
                    }
                }
                else
                {
                    lblConfirmCheck.Visible = true;
                }
        }
        protected void btnSaveQuestion_OnClick(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                if (ddlQuestion.SelectedIndex == 0)
                {
                    lblQuestionError.Visible = true;
                }
                using (var helper = new Academic.DbHelper.DbHelper.User())
                {
                    var changed = helper.ChangeSecurityQuestion(user.Id, txtPassword.Text, ddlQuestion.Text, txtAnswer.Text);
                    if (changed)
                    {
                        MultiView1.ActiveViewIndex = 0;
                        ResetQuestionControls();
                    }
                    else
                    {
                        lblQuestionSaveError.Visible = true;
                    }
                }
}

        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            ResetQuestionControls();
            ResetPasswordControls();
        }

        private void ResetPasswordControls()
        {
            txtearlierPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void ResetQuestionControls()
        {
            ddlQuestion.ClearSelection();
            txtPassword.Text = "";
            txtAnswer.Text = "";
        }
    }
}