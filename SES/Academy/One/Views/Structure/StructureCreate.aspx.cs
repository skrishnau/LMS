using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Structure
{
    public partial class StructureCreate : System.Web.UI.Page
    {
        //public event EventHandler<MessageEventArgs> SaveClickedEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    var type = Request.QueryString["strTyp"];
                    if (type == null)
                    {
                        Response.Redirect("~/Views/Structure/All/Master/List.aspx", true);
                    }
                    else
                    {
                        StructureType = type;
                        LoadStructureType();
                        var strId = Request.QueryString["strId"];
                        var pId = Request.QueryString["pId"];
                        if (strId != null)
                        {
                            StructureId = Convert.ToInt32(strId);
                            LoadStructure();
                        }
                        else if (pId != null)
                        {
                            ParentId = Convert.ToInt32(pId);
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/Views/Structure/All/Master/List.aspx");
                }
            }
        }

        private void LoadStructureType()
        {
            switch (StructureType)
            {
                //case "lev":
                //    lblHeading.Text = "Level edit";
                //    lblTabHead.Text = "Level edit";
                //    break;
                //case "fac":
                //    lblHeading.Text = "Faculty edit";
                //    lblTabHead.Text = "Faculty edit";
                //    break;
                case "pro":
                    lblHeading.Text = "Program edit";
                    lblTabHead.Text = "Program edit";
                    break;
                case "yr":
                    lblHeading.Text = "Year edit";
                    lblTabHead.Text = "Year edit";
                    position_row.Visible = true;

                    break;
                case "syr":
                    lblHeading.Text = "Sub-year edit";
                    lblTabHead.Text = "Sub-year edit";
                    position_row.Visible = true;
                    break;

            }
        }

        private void LoadStructure()
        {
            using (var helper = new DbHelper.Structure())
            {
                switch (StructureType)
                {
                    //case "lev":
                    //    var level = helper.GetLevel(StructureId);
                    //    if (level != null)
                    //    {
                    //        txtName.Text = level.Name;
                    //        txtDescription.Text = level.Description;
                    //        ParentId = level.SchoolId;
                    //    }
                    //    break;
                    //case "fac":
                    //    //var fac = helper.GetFaculty(StructureId);
                    //    //if (fac != null)
                    //    //{
                    //    //    txtName.Text = fac.Name;
                    //    //    txtDescription.Text = fac.Description;
                    //    //    ParentId = fac.LevelId;
                    //    //}
                    //    break;
                    case "pro":
                        var pro = helper.GetProgram(StructureId);
                        if (pro != null)
                        {
                            txtName.Text = pro.Name;
                            txtDescription.Text = pro.Description;
                            ParentId = pro.SchoolId;
                        }
                        break;
                    case "yr":
                        var year = helper.GetYear(StructureId);
                        if (year != null)
                        {
                            txtName.Text = year.Name;
                            txtDescription.Text = year.Description;
                            ParentId = year.ProgramId;
                            position_row.Visible = true;
                            txtPosition.Text = year.Position.ToString();
                        }
                        break;
                    case "syr":
                        var syear = helper.GetSubYear(StructureId);
                        if (syear != null)
                        {
                            txtName.Text = syear.Name;
                            txtDescription.Text = syear.Description;
                            ParentId = syear.YearId ?? 0;
                            position_row.Visible = true;
                            txtPosition.Text = syear.Position.ToString();
                        }
                        break;

                }


            }
        }

        #region Properties

        /// <summary>
        /// For level - ParentId is the schoolId, for faculty- parentId is levelId, for program- parentId is FacultyId,
        /// for year- parent Id is programid, for subyear - parent id is yearId
        /// </summary>
        public int ParentId
        {
            get { return Convert.ToInt32(hidParentId.Value); }
            set { hidParentId.Value = value.ToString(); }
        }

        public int StructureId
        {
            get { return Convert.ToInt32(hidStructureId.Value); }
            set { hidStructureId.Value = value.ToString(); }
        }

        public string StructureType
        {
            get { return hidStructureType.Value; }
            set { hidStructureType.Value = value; }
        }

        public bool CancelButtonVisible
        {
            get { return btnCancel.Visible; }
            set { btnCancel.Visible = value; }
        }

        #endregion


        #region Save functions

        //bool SaveLevel(int schoolId)
        //{
        //    using (var helper = new DbHelper.Structure())
        //    {
        //        var level = new Academic.DbEntities.Structure.Level()
        //        {
        //            Name = txtName.Text
        //            ,
        //            Description = txtDescription.Text
        //            ,
        //            Id = this.StructureId
        //            ,
        //            SchoolId = schoolId
        //        };

        //        if (StructureId == 0)
        //            level.CreatedDate = DateTime.Now;

        //        var saved = helper.AddOrUpdateLevel(level);
        //        return saved != null;
        //    }
        //}

        //bool SaveFaculty()
        //{
        //    using (var helper = new DbHelper.Structure())
        //    {
        //        var fac = new Academic.DbEntities.Structure.Faculty()
        //        {
        //            Name = txtName.Text
        //            ,
        //            Description = txtDescription.Text
        //            ,
        //            Id = this.StructureId
        //            ,
        //            LevelId = ParentId
        //        };

        //        if (StructureId == 0)
        //            fac.CreatedDate = DateTime.Now;

        //        var saved = helper.AddOrUpdateFaculty(fac);
        //        return saved != null;
        //    }
        //}
        bool SavePogram(int schoolId)
        {
            using (var helper = new DbHelper.Structure())
            {
                var pro = new Academic.DbEntities.Structure.Program()
                {
                    Name = txtName.Text
                    ,
                    Description = txtDescription.Text
                    ,
                    Id = StructureId
                    ,
                    SchoolId = schoolId
                };

                if (StructureId == 0)
                    pro.CreatedDate = DateTime.Now;

                var saved = helper.AddOrUpdateProgram(pro);
                return saved != null;
            }
        }
        bool SaveYear()
        {
            using (var helper = new DbHelper.Structure())
            {
                var year = new Academic.DbEntities.Structure.Year()
                {
                    Name = txtName.Text
                    ,
                    Description = txtDescription.Text
                    ,
                    Id = this.StructureId
                    ,
                    ProgramId = ParentId
                    ,
                    Position = Convert.ToInt32(string.IsNullOrEmpty(txtPosition.Text) ? "0" : txtPosition.Text)
                };

                if (StructureId == 0)
                    year.CreatedDate = DateTime.Now;

                var saved = helper.AddOrUpdateYear(year);
                return saved != null;
            }
        }
        bool SaveSubyear()
        {
            using (var helper = new DbHelper.Structure())
            {
                var subyear = new Academic.DbEntities.Structure.SubYear()
                {
                    Name = txtName.Text
                    ,
                    Description = txtDescription.Text
                    ,
                    Id = this.StructureId
                    ,
                    YearId = ParentId
                    ,
                    Position = Convert.ToInt32(string.IsNullOrEmpty(txtPosition.Text) ? "0" : txtPosition.Text)
                };

                if (StructureId == 0)
                    subyear.CreatedDate = DateTime.Now;

                var saved = helper.AddOrUpdateSubYear(subyear);
                return saved != null;
            }
        }

        #endregion


        #region Events Callback

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    var saved = false;
                    switch (StructureType)
                    {
                        //case "lev":
                        //    saved = SaveLevel(user.SchoolId);
                        //    break;
                        //case "fac":
                        //    saved = SaveFaculty();
                        //    break;
                        case "pro":
                            saved = SavePogram(user.SchoolId);
                            break;
                        case "yr":
                            saved = SaveYear();
                            break;
                        case "syr":
                            saved = SaveSubyear();
                            break;
                    }

                    if (saved)
                    {
                        Response.Redirect("~/Views/Structure/All/Master/List.aspx?edit=1");
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Structure/All/Master/List.aspx?edit=1");
        }

        #endregion

    }
}