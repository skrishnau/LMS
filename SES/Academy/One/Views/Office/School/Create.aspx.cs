using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.User;
using Academic.DbHelper;
using Academic.InitialValues;
using One.Values.MemberShip;

namespace One.Views.Office.School
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = User as CustomPrincipal;
                if (user != null)
                {
                    if (user.SchoolId > 0)
                    {
                        using (var helper = new DbHelper.Office())
                        {
                            var sch = helper.GetSchoolOfUser(user.Id);
                            if (sch != null)
                            {
                                hidSchoolId.Value = sch.Id.ToString();
                                txtCity.Text = sch.City;
                                txtCode.Text = sch.Code;
                                txtName.Text = sch.Name;
                                txtCountry.Text = sch.Country;
                                txtEmail.Text = sch.Email;
                                txtFax.Text = sch.Fax;
                                txtPhone.Text = sch.Phone;
                                txtRegNo.Text = sch.RegNo;
                                txtStreet.Text = sch.Street;
                                txtWeb.Text = sch.Website;
                                hidUserId.Value = sch.UserId.ToString();
                            }
                        }
                    }
                    else
                    {
                        hidUserId.Value = user.Id.ToString();
                    }
                }
                if (InitialValues.CustomSession["InstitutionId"] <= 0)
                {
                    Response.Redirect("~/Views/Office/Institution/Create.aspx");
                    return;
                }
                LoadSchoolType();
                //pnlSchTyp.Visible = false;
                SchoolTypeUC.SavedId = 0;
                SchoolTypeUC.Visible_ = false;
                SchoolTypeAllButtonsVisible(false);
            }

            if (Values.Session.GetUser(Session) > 0)
            {
                hidUserId.Value = Values.Session.GetUser(Session).ToString();
            }
            else
            {
                using (var helper = new DbHelper.Office())
                {
                    var sch = helper.GetSchoolOfUser(Values.Session.GetUser(Session));
                    if (sch != null)
                    {
                        //Give to update or edit but not add new.
                        Response.Redirect("~/Views/Dashboard.aspx");
                    }
                }
                //redirect to login page.
                Response.Redirect("~/Views/Account/Login.aspx");
            }
            lblMsg.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (cmbSchoolType.SelectedValue == "" || cmbSchoolType.SelectedValue == "0")
            {
                valiSchType.IsValid = false;
                return;
            }
            if (IsValid)
            {
                var user = User as CustomPrincipal;
                if (user == null)
                    return;

                var school = new Academic.DbEntities.Office.School()
                {
                    Id = user.SchoolId,
                    Name = txtName.Text
                    ,
                    City = txtCity.Text
                    ,
                    Code = txtCode.Text
                    ,
                    Country = txtCountry.Text
                    ,
                    Email = txtEmail.Text
                    ,
                    Fax = txtFax.Text
                        //,InstitutionId = InitialValues.CustomSession["InstitutionId"]
                    ,
                    IsActive = chkActive.Checked
                    ,
                    Phone = txtPhone.Text
                    ,
                    RegNo = txtRegNo.Text
                        //next version
                    ,
                    SchoolTypeId = Convert.ToInt32(cmbSchoolType.Text)
                    ,
                    Street = txtStreet.Text
                    ,
                    Website = txtWeb.Text
                    ,
                    CreatedDate = DateTime.Now
                   ,
                };
                if (user.SchoolId <= 0)
                    school.UserId = user.Id;

                using (var helper = new DbHelper.Office())
                {
                    var saved = helper.AddOrUpdateSchool(school, FileUpload1.PostedFile);

                    //update cookie -- add school Id to the cookie
                    //Page.User.Identity.Name;
                    if (user.SchoolId <= 0 && saved != null)
                    {
                        var ok = UpdateSchoolInfoInCookie(user, saved.Id);
                        if (ok)
                        {
                            Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                        }
                        else
                        {
                            lblMsg.Text = "Error while saving.";
                        }

                        //---not needed, since redirect is done above

                        //SchoolTypeUC.SavedId = 0;
                        //lblMsg.Visible = true;
                        //lblMsg.Text = "Save Successful.";
                    }
                    else
                    {
                        lblMsg.Text = "Error while saving.";
                    }
                }
            }
        }




        public bool UpdateSchoolInfoInCookie(CustomPrincipal user, int schoolId)
        {
            try
            {
                using (var acchelper = new DbHelper.CustomAccount())
                {
                    //if (Membership.ValidateUser(viewModel.UserName, viewModel.Password))
                    //if (acchelper.CheckUser(viewModel.UserName, viewModel.Password))
                    //{
                    //Response.Cookies.Remove(FormsAuthentication.FormsCookieName);

                    using (var acaHelper = new DbHelper.AcademicYear())
                    using (var helper = new DbHelper.User())
                    {
                        //var user = helper.Users.First(u => u.UserName == userName);

                        CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                        serializeModel.Id = user.Id;
                        serializeModel.FirstName = user.FirstName;
                        serializeModel.LastName = user.LastName;
                        serializeModel.SchoolId = schoolId;

                        //serializeModel.SchoolId = user.SchoolId??0;
                        var acaId = acaHelper.GetCurrentAcademicYear(user.SchoolId);
                        if (acaId != null)
                        {
                            serializeModel.AcademicYearId = acaId.Id;
                            var sess = acaHelper.GetCurrentSession(acaId.Id);
                            if (sess != null)
                            {
                                serializeModel.SessionId = sess.Id;
                            }
                            //else
                            //{
                            //    serializeModel.SessionId = 0;
                            //}
                        }

                        JavaScriptSerializer serializer = new JavaScriptSerializer();

                        string userData = serializer.Serialize(serializeModel);

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                            //viewModel.Email,
                            user.UserName,
                            DateTime.Now,
                            DateTime.Now.AddMinutes(15),
                            false,
                            userData);

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Set(faCookie);//.Add(faCookie);
                        //Response.Cookies[FormsAuthentication.FormsCookieName]= faCookie;
                        /*    //FormsAuthentication.set
                        //return RedirectToAction("Index", "Home");
                        string returnUrl = Request.QueryString["ReturnUrl"] as string;
                        if (returnUrl != null)
                        {
                            //if (returnUrl.Contains("DashBoard%2fStudent") && roles.Contains("student"))
                            //{

                            //}
                            Response.Redirect(returnUrl);
                        }
                        else
                        {
                            Response.Redirect("~/ViewsSite/Default.aspx");
                        }*/
                    }
                    //}
                }
                return true;
            }
            catch (Exception exee)
            {
                return false;
            }
        }


        protected void cmbSchoolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchoolType.SelectedValue == "-1")
            {
                SchoolTypeUC.InstitutionId = InitialValues.CustomSession["InstitutionId"];
                SchoolTypeAllButtonsVisible(true);

            }
            else
            {
                SchoolTypeAllButtonsVisible(false);
                ResetSchoolTypeUc();
            }
        }

        private void ResetSchoolTypeUc()
        {
            SchoolTypeUC.SavedId = 0;
            SchoolTypeUC.Name = "";
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    SchoolTypeUC.Visible_ = false;
        //}

        void LoadSchoolType(int selectedValue = 0)
        {
            DbHelper.ComboLoader.LoadSchoolType(ref  cmbSchoolType,
                     selectedValue, false);
            SchoolTypeAllButtonsVisible(false);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SchoolTypeUC.Cancel();
            SchoolTypeAllButtonsVisible(false);
        }

        void SchoolTypeAllButtonsVisible(bool value)
        {
            //btnCancel.Visible = value;
            //btnSave.Visible = value;
            pnlSchTypeUc.Visible = value;
            SchoolTypeUC.Visible_ = value;
        }

        protected void btnSave1_Click(object sender, EventArgs e)
        {
            var saved = SchoolTypeUC.Save();
            if (saved)
            {
                LoadSchoolType(SchoolTypeUC.SavedId);
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (!pnlSchTypeUc.Visible)
            {
                SchoolTypeUC.InstitutionId = InitialValues.CustomSession["InstitutionId"];
                SchoolTypeAllButtonsVisible(true);
            }
            else
            {
                SchoolTypeAllButtonsVisible(false);
            }
        }
    }
}