using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.Database;
using Academic.DbHelper;
using Academic.ViewModel;
using WebGrease.Css.Extensions;

namespace One.Views.Resource
{
    public partial class ResourceCreate : System.Web.UI.UserControl
    {
        //public string SelectedResource
        //{
        //    //get { return this.ddResSelected.SelectedValue; }
        //    //set { this.ddResSelected.SelectedValue = value; }
        //}

        public string uploadMessage = "";
        public bool SaveButtonVisibility
        {
            get { return this.pnlSave.Visible; }
            set { this.pnlSave.Visible = value; }
        }

        private Button _clickedByButton = null;
        public Button ClickedByButton
        {
            get { return this._clickedByButton; }
            set
            {
                ViewState["ClickedByButton"] = value;
                this._clickedByButton = value;
            }
        }
        private DropDownList _clickedByDDL = null;
        public DropDownList ClickedByDDL
        {
            get { return this._clickedByDDL; }
            set
            {
                ViewState["ClickedByDDL"] = value;
                this._clickedByDDL = value;
            }
        }
        public string ClickedByDDLName
        {
            get { return this.clkdByDDLName.Value; }
            set { this.clkdByDDLName.Value = value; }
        }

        public string ClickedByName
        {
            get { return this.lblParentBtnName.Text; }
            set { this.lblParentBtnName.Text = value; }
        }

        public bool PanelFormVisibility
        {
            get { return this.pnlForm.Visible; }
            set { this.pnlForm.Visible = value; }
        }

        private IdAndName _resourceJustSaved = null;
        private int _subId = 0;
        public IdAndName ResourceJustSaved
        {
            get
            {

                return _resourceJustSaved;
            }
            set
            {
                var bt = (Button)ViewState["ClickedByButton"];
                DropDownList ddlist = (DropDownList)Page.FindControl(ClickedByDDLName);
                if (value != null && ddlist != null)
                {
                    using (var helper = new DbHelper.Resource())
                    {

                        var access = helper.GetResourcesForCombo(Convert.ToInt32(cmbSubject.SelectedValue));
                        
                        ddlist.DataSource = access;
                        ddlist.DataMember = "Name";
                        ddlist.DataTextField = "Name";
                        ddlist.DataValueField = "Id";
                        ddlist.DataBind();

                        //var datas = (List < IdAndName >) ddlist.DataSource;
                        //datas.Add(value);
                        //ddlist.DataSource = datas; //helper.GetResourcesForCombo(_subId);
                        //ddlist.DataBind();
                        ddlist.SelectedValue = value.Id.ToString();
                    }
                    //ddlist.DataSource = 
                }
                //One.Assignment.Create ctrlB = (One.Assignment.Create)Page.FindControl(ClickedByButton.ID);
                //DropDownList ddl = ctrlB.ControlB_DDL;
                //txtDDLValue.Text = ddl.SelectedValue;

                this._resourceJustSaved = value;
            }
        }

        public string SelectSubject
        {
            get { return this.cmbSubject.SelectedValue; }
            set
            {
                if (value == "0")
                {
                    cmbSubject.DataSource = null;
                    cmbSubject.DataBind();
                }
                else
                {   
                    this.cmbSubject.SelectedValue = value;
                    
                }
                this.cmbSubject.Enabled = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtNameValidator.ForeColor = Color.Black;

            if (!IsPostBack)
            {
                using (var helper = new DbHelper.Subject())
                {
                    var subs =
                        helper.ListAllSubjects(Academic.InitialValues.InitialValues.CustomSession["InstitutionId"]);
                    cmbSubject.DataSource = subs;
                    cmbSubject.DataMember = "Name";
                    cmbSubject.DataTextField = "Name";
                    cmbSubject.DataValueField = "Id";
                    cmbSubject.DataBind();
                }
                using (var per = new DbHelper.Resource())
                {
                    var access = per.GetFileAccessPermissionForCombo();
                    cmbAccessPermission.DataSource = access;
                    cmbAccessPermission.DataMember = "Name";
                    cmbAccessPermission.DataTextField = "Name";
                    cmbAccessPermission.DataValueField = "Id";
                    cmbAccessPermission.DataBind();
                }

                pnlSave.Visible = false;
                pnlForm.Visible = false;
            }
        }

        public void CreateNew()
        {
            btnCreateNew_Click(new object(), new EventArgs());
        }
        protected void btnCreateNew_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = true;
            SaveButtonVisibility = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!PanelFormVisibility)
            {
                txtNameValidator.IsValid = true;
            }
            if (Page.IsValid)
            {

                using (var helper = new DbHelper.Resource())
                {

                    //var files1 = fileUp1.PostedFiles;
                    //var files2 = fileUp2.PostedFiles;
                    //var file3 = fileUp3.PostedFiles;
                    List<HttpPostedFile> Files = new List<HttpPostedFile>();
                    string path = Server.MapPath("~/ResourceFiles/Upload");

                    if (fileUp1.HasFiles)
                        fileUp1.PostedFiles.ForEach(x =>
                        {
                            Files.Add(x);
                        });
                    if (fileUp2.HasFiles)
                        fileUp2.PostedFiles.ForEach(x =>
                        {
                            Files.Add(x);
                        });
                    if (fileUp3.HasFiles)
                        fileUp3.PostedFiles.ForEach(x =>
                        {
                            Files.Add(x);
                        });

                    var links = txtLink.Text.Split(new char[] {',', '\n'});

                    var resource = new Academic.DbEntities.Resources.Resource()
                    {
                        Id = 0
                        ,
                        Name = txtName.Text
                        ,
                        SubjectId = Convert.ToInt32(cmbSubject.SelectedValue)
                        ,
                        Category = txtCategory.Text
                        ,
                        AccessPermissionId = Convert.ToInt32(cmbAccessPermission.SelectedValue)
                        ,
                        CreatedDate = DateTime.Now
                        ,
                        OwnerId = Academic.InitialValues.InitialValues.CustomSession["UserId"]
                        ,
                        ModifiedDate = DateTime.Now
                        ,
                        ModifiedBy = Academic.InitialValues.InitialValues.CustomSession["UserId"]
                        ,
                        Note = txtNote.Text
                        ,
                        //files,links
                    };

                    var saved = helper.SaveResource(resource, Files, path, links);

                    if (saved != null)
                    {
                        _subId = resource.SubjectId;
                        this.ResourceJustSaved = saved;
                        uploadMessage = "Save Successful.";

                        ClearFields();

                        SaveButtonVisibility = false;
                        pnlForm.Visible = false;
                        //this.
                    }
                    else
                    {
                        _subId = resource.SubjectId;
                        this.ResourceJustSaved = null;
                        uploadMessage = "Save Error!";

                    }
                }
            }
            else 
            {
                txtNameValidator.ForeColor = Color.OrangeRed;
            }
           
        }

        private void ClearFields()
        {
            this.txtName.Text = "";
            this.txtCategory.Text = "";
            this.txtLink.Text = "";
            this.txtNote.Text = "";

            this.fileUp1 = new FileUpload();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SaveButtonVisibility = false;
            pnlForm.Visible = false;
            ClearFields();
        }


        //void h(HttpPostedFileBase file)
        //{
        //    try
        //    {
        //        string filename = Path.GetFileName(file.FileName);
        //        file.SaveAs(Server.MapPath("~/") + filename);
        //        StatusLabel.Text = "Upload status: File uploaded!";
        //    }
        //    catch (Exception ex)
        //    {
        //        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        //    }
        //}
    }
}