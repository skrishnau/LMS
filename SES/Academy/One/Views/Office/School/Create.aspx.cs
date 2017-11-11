using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.User;
using Academic.DbHelper;
//using Academic.InitialValues;
using One.Values.MemberShip;
using System.IO;
using Academic.DbEntities;
using Academic.ViewModel;

namespace One.Views.Office.School
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            file_upload.Style.Add("visibility", " hidden");
            lblMsg.Visible = false;

            if (!IsPostBack)
            {
                FilesDisplay1.FileType = "Image";
                var guid = Guid.NewGuid();
                hidPageKey.Value = guid.ToString();
                FilesDisplay1.PageKey = hidPageKey.Value;
                FilesDisplay1.FileSaveDirectory = DbHelper.StaticValues.SchoolFileLocation;
                FilesDisplay1.FileAcquireMode = Enums.FileAcquireMode.Single;
                var user = User as CustomPrincipal;
                if (user != null)
                {
                    //PopulateCountry();
                    if (user.SchoolId > 0)
                    {
                        PopulateSchoolInfo(user);
                    }
                    else
                    {
                        hidUserId.Value = user.Id.ToString();
                    }
                    //LoadSchoolType();
                }
            }

            //if (Values.Session.GetUser(Session) > 0)
            //{
            //    hidUserId.Value = Values.Session.GetUser(Session).ToString();
            //}
            //else
            //{
            //    using (var helper = new DbHelper.Office())
            //    {
            //        //var sch = helper.GetSchoolOfUser(Values.Session.GetUser(Session));
            //        //if (sch != null)
            //        //{
            //        //    //Give to update or edit but not add new.
            //        //    Response.Redirect("~/Views/Dashboard.aspx");
            //        //}
            //    }
            //    //redirect to login page.
            //    Response.Redirect("~/Views/Account/Login.aspx");
            //}
        }

        private void PopulateSchoolInfo(CustomPrincipal user)
        {
            using (var helper = new DbHelper.Office())
            {

                var sch = helper.GetSchoolOfUser(user.Id);

                if (sch != null)
                {
                    CKEditor1.Text = sch.Description;
                    hidSchoolId.Value = sch.Id.ToString();
                    txtAddress.Text = sch.Address;
                    txtName.Text = sch.Name;
                    txtEmailGeneral.Text = sch.EmailGeneral;
                    txtEmailMarketing.Text = sch.EmailMarketing;
                    txtEmailSupport.Text = sch.EmailSupport;
                    txtPhoneMain.Text = sch.PhoneMain;
                    txtPhoneAfterHours.Text = sch.PhoneAfterHours;
                    hidImageId.Value = sch.ImageId.ToString();
                    
                    //txtStreet.Text = sch.Street;
                    txtWeb.Text = sch.Website;
                    hidUserId.Value = sch.UserId.ToString();
                    //cmbSchoolType.SelectedValue = sch.SchoolTypeId.ToString();
                    var f = helper.GetSchoolImage(sch.ImageId);
                    if (f != null)
                    {
                        //var fileName = Path.GetFileName(f.FilePath);
                        var image = new FileResourceEventArgs()
                                {
                                    Id = f.Id,
                                    //CreatedBy = user.Id
                                    //,
                                    //CreatedDate = DateTime.Now
                                    //,
                                    FileDisplayName = f.DisplayName //Path.GetFileName(imageFile.FileName)
                                        //,
                                        // FileDirectory = DbHelper.StaticValues.SchoolFileLocation //StaticValue.UserImageDirectory
                                        // ,
                                        //FileName = fileName
                                    ,
                                    FilePath = DbHelper.StaticValues.SchoolFileLocation + f.FileName
                                        //Guid.NewGuid().ToString() + GetExtension(imageFile.FileName, imageFile.ContentType)
                                    ,
                                    FileSizeInBytes = f.FileSizeInBytes //imageFile.ContentLength
                                    ,
                                    FileType = f.FileType //imageFile.ContentType
                                    ,
                                    IconPath = f.IconPath
                                    ,
                                    //SubjectId = SubjectId
                                };
                        FilesDisplay1.SetInitialValues(new List<FileResourceEventArgs>() { image });
                    }
                }
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
                                Name = sch==null?SiteMap.CurrentNode.ParentNode.Title:sch.Name
                                ,Value = SiteMap.CurrentNode.ParentNode.Url
                                ,Void=true
                            },
                            new IdAndName(){Name = "Edit"}
                        };
                    SiteMapUc.SetData(list);
                }
            }
        }

        //private void PopulateCountry()
        //{
        //    List<string> countries = new List<string>();
        //    var getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        //    foreach (var c in getCultureInfo)
        //    {
        //        var getRegionInfo =
        //            new RegionInfo(c.LCID);
        //        var name = getRegionInfo.EnglishName.Split(new char[] { '(' })[0];
        //        if (!countries.Contains(name))
        //        {
        //            countries.Add(name);
        //        }
        //    }
        //    countries.Sort();
        //    var i = 0;
        //    try
        //    {
        //        i = countries.IndexOf("Nepal");
        //    }
        //    catch
        //    {
        //    }
        //    if (i != 0)
        //        countries.Insert(0, "Select");
        //    ddlCountry.DataSource = countries;
        //    ddlCountry.DataBind();
        //    ddlCountry.SelectedIndex = i;
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //if (cmbSchoolType.SelectedValue == "" || cmbSchoolType.SelectedValue == "0")
            //{
            //    valiSchType.IsValid = false;
            //}
            //if (ddlCountry.SelectedIndex == 0)
            //    valiCountry.IsValid = false;

            if (IsValid)
            {
                var user = User as CustomPrincipal;
                if (user == null)
                    return;

                var school = new Academic.DbEntities.Office.School()
                {
                    Id = user.SchoolId,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    EmailGeneral = txtEmailGeneral.Text,
                    EmailMarketing = txtEmailMarketing.Text,
                    EmailSupport = txtEmailSupport.Text,
                    IsActive = chkActive.Checked,
                    PhoneMain = txtPhoneMain.Text,
                    PhoneAfterHours = txtPhoneAfterHours.Text,
                    Description = CKEditor1.Text,
                    //SchoolTypeId = Convert.ToInt32(cmbSchoolType.Text),
                    Website = txtWeb.Text,
                    CreatedDate = DateTime.Now,
                    ImageId = Convert.ToInt32(hidImageId.Value)
                };
                if (user.SchoolId <= 0)
                    school.UserId = user.Id;

                using (var helper = new DbHelper.Office())
                {
                    var files = FilesDisplay1.GetFiles();
                    var image = new UserFile();
                    if (files != null)
                    {
                        if (files.Count >= 1)
                        {
                            var f = files[0];
                            //foreach (var f in files)
                            {
                                var fileName = Path.GetFileName(f.FilePath);
                                image = new Academic.DbEntities.UserFile()
                                {
                                    Id = f.Id,
                                    CreatedBy = user.Id
                                    ,
                                    CreatedDate = DateTime.Now
                                    ,
                                    DisplayName = f.FileDisplayName //Path.GetFileName(imageFile.FileName)
                                    ,
                                    FileDirectory = DbHelper.StaticValues.SchoolFileLocation //StaticValue.UserImageDirectory
                                    ,
                                    FileName = fileName
                                        //Guid.NewGuid().ToString() + GetExtension(imageFile.FileName, imageFile.ContentType)
                                    ,
                                    FileSizeInBytes = f.FileSizeInBytes //imageFile.ContentLength
                                    ,
                                    FileType = f.FileType //imageFile.ContentType
                                    ,
                                    IconPath = f.IconPath
                                    ,
                                    //SubjectId = SubjectId
                                };
                                if (f.Id > 0)
                                {
                                    image.ModifiedBy = user.Id;
                                    image.ModifiedDate = DateTime.Now;
                                }
                            }
                        }
                    }

                    var saved = helper.AddOrUpdateSchool(school, image);//FileUpload1.PostedFile

                    //update cookie -- add school Id to the cookie
                    //Page.User.Identity.Name;
                    if (saved != null)
                    {
                        if (user.SchoolId <= 0)
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
                        else Response.Redirect("~/About.aspx"); //"//~/Views/Office/");
                    }

                    else
                    {
                        lblMsg.Text = "Error while saving.";
                    }
                }
            }
            else
            {
                lblMsg.Text = "Some fields are invalid or not filled.";
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

                        var sess = acaHelper.GetCurrentSession();
                        if (sess != null)
                        {
                            serializeModel.AcademicYearId = sess.AcademicYearId;
                            serializeModel.SessionId = sess.Id;
                        }


                        //var acaId = acaHelper.GetCurrentAcademicYear(user.SchoolId);
                        //if (acaId != null)
                        //{
                        //    serializeModel.AcademicYearId = acaId.Id;
                        //    var sess = acaHelper.GetCurrentSession(acaId.Id);
                        //    if (sess != null)
                        //    {
                        //        serializeModel.SessionId = sess.Id;
                        //    }
                        //    //else
                        //    //{
                        //    //    serializeModel.SessionId = 0;
                        //    //}
                        //}

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

        //void LoadSchoolType(int selectedValue = 0)
        //{
        //    DbHelper.ComboLoader.LoadSchoolType(ref  cmbSchoolType,
        //             selectedValue, false);
        //}
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/About.aspx");
        }
    }
}