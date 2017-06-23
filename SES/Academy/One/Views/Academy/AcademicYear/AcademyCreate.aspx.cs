using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Batches;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Academy.AcademicYear
{
    public partial class AcademyCreate : System.Web.UI.Page
    {

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            valiStartDate.ErrorMessage = "Required";
            txtName.Focus();
            try
            {
                if (!IsPostBack)
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
                                Name = SiteMap.CurrentNode.ParentNode.Title
                                ,Value = SiteMap.CurrentNode.ParentNode.Url+"?edit=1"
                                ,Void=true
                            },
                            new IdAndName()
                            {
                                Name = SiteMap.CurrentNode.Title
                            }
                        };
                        SiteMapUc.SetData(list);
                    }
                    LoadData();
                }
            }
            catch { }
        }




        #endregion


        #region Properties

        public int AcademicId
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }

        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set
            {
                hidBatchId.Value = value.ToString();
            }
        }

        #endregion


        #region  functions

        private void SetStructure(DbHelper.Structure sHelper, CustomPrincipal user)
        {
            var programs = sHelper.ListPrograms(user.SchoolId);
            programs.ForEach(p =>
            {
                var litem = new ListItem() { Text = " " + p.Name, Value = p.Id.ToString() };
                var pbs = p.ProgramBatches.FirstOrDefault(x => x.BatchId == BatchId);
                if (pbs != null)
                {
                    litem.Value += "_" + pbs.Id;
                    litem.Selected = !(pbs.Void ?? false);
                }
                else
                {
                    litem.Value += "_0";
                    litem.Selected = false;
                }
                CheckBoxList1.Items.Add(litem);
            });
        }

        private void LoadData()
        {
            var user = Page.User as CustomPrincipal;
            var aId = Request.QueryString["aId"];

            if (user != null)
                using (var bHelper = new DbHelper.Batch())
                using (var sHelper = new DbHelper.Structure())
                {
                    if (aId != null)
                    {
                        btnSaveAndAddSessions.Visible = false;
                        var batch = bHelper.GetBatchByAcademicYearId(Convert.ToInt32(aId));

                        if (batch != null)
                        {
                            if (batch.AcademicYear.IsActive || (batch.AcademicYear.Completed ?? false))
                            {
                                txtEnd.Enabled = false;
                                txtStart.Enabled = false;
                                CheckBoxList1.Enabled = false;
                                chkSelectAll.Enabled = false;
                                if (batch.AcademicYear.Completed ?? false)
                                {
                                    txtName.Enabled = false;
                                    txtBatchName.Enabled = false;
                                    btnSave.Enabled = false;
                                }
                            }


                            BatchId = batch.Id;
                            var acad = batch.AcademicYear;
                            if (acad != null)
                            {
                                //=========================Academic year, batch
                                hidId.Value = aId;
                                txtName.Text = acad.Name;
                                txtStart.Text = acad.StartDate.ToShortDateString();
                                txtEnd.Text = acad.EndDate.ToShortDateString();
                                txtBatchName.Text = batch.Name;
                            }
                        }
                    }
                    //============================ Structure
                    SetStructure(sHelper, user);
                }
        }

        //public void LoadStructure(int schoolId)
        //{
        //    var user = Page.User as CustomPrincipal;

        //    if (user != null)
        //        using (var helper = new DbHelper.Structure())
        //        {
        //            var programs = helper.ListPrograms(schoolId);
        //            programs.ForEach(p =>
        //            {
        //                var litem = new ListItem() { Text = " " + p.Name, Value = p.Id.ToString() };
        //                var pbs = p.ProgramBatches.FirstOrDefault(x => x.BatchId == BatchId);
        //                if (pbs != null)
        //                {
        //                    litem.Value += "_" + pbs.Id;
        //                    litem.Selected = !(pbs.Void ?? false);
        //                }
        //                else
        //                {
        //                    litem.Value += "_0";
        //                    litem.Selected = false;
        //                }
        //                CheckBoxList1.Items.Add(litem);
        //            });
        //        }
        //}



        //public void SetDatasForEdit(int batchId)
        //{
        //    using (var helper = new DbHelper.Batch())
        //    {
        //        var batch = helper.GetBatch(batchId);
        //        if (batch != null)
        //        {
        //            BatchId = batch.Id;
        //            //txtName.Text = batch.Name;
        //            //txtDescription.Text = batch.Description;
        //            //ddlAcademicYear.SelectedValue = batch.AcademicYearId.ToString();
        //            //txtCommenceDate.Text = batch.ClassCommenceDate == null ? "" : batch.ClassCommenceDate.Value.ToShortDateString();
        //        }
        //        // program batches
        //    }
        //}


        protected void btnSave_Click(object sender, EventArgs e)
        {

            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                //academic year
                var academicYear = GetAcademicYear(user);
                if (academicYear == null)
                    return;
                //batch
                List<Academic.DbEntities.Batches.ProgramBatch> list = new List<ProgramBatch>();
                var batch = GetBatch(user, ref list);
                if (batch == null)
                    return;

                using (var helper = new DbHelper.AcademicYear())
                {

                    //var saved = helper.AddOrUpdateAcademicYearAndBatch(user.SchoolId, academicYear, batch, list);
                    //if (saved != null)
                    //{
                    //    var btn = sender as Button;
                    //    if (btn != null)
                    //    {
                    //        if (btn.ID == "btnSaveAndAddSessions")
                    //        {
                    //            Response.Redirect("~/Views/Academy/Session/Create.aspx?aId=" + saved.Id);
                    //        }
                    //        else
                    //        {
                    //            Response.Redirect("~/Views/Academy/");
                    //        }
                    //    }
                    //}
                    //else lblError.Visible = true;
                }
            }
        }



        private Academic.DbEntities.AcademicYear GetAcademicYear(CustomPrincipal user)
        {
            DateTime start = DateTime.MinValue, end = DateTime.MaxValue;
            try
            {
                start = Convert.ToDateTime(txtStart.Text);
            }
            catch
            {
                valiStartDate.ErrorMessage = "Incorrect format.";
                valiStartDate.IsValid = false;
            }
            try
            {
                end = Convert.ToDateTime(txtEnd.Text);
            }
            catch
            {
                valiEndDate.ErrorMessage = "Incorrect format.";
                valiEndDate.IsValid = false;
            }

            if (Page.IsValid)
            {
                var entity = new Academic.DbEntities.AcademicYear()
                {
                    Id = Convert.ToInt32(hidId.Value)
                    ,
                    Name = txtName.Text
                    ,
                    EndDate = end
                    ,
                    StartDate = start
                    ,
                    SchoolId = user.SchoolId
                    ,
                    Position = start.Year + start.Month + start.Day,
                };
                return entity;
            }
            return null;
        }

        private Academic.DbEntities.Batches.Batch GetBatch(CustomPrincipal user, ref List<Academic.DbEntities.Batches.ProgramBatch> list)
        {
            var batchId = BatchId;
            if (Page.IsValid)
            {
                //var lst = new List<Academic.DbEntities.Batches.ProgramBatch>();
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    var ids = item.Value.Split(new char[] { '_' });
                    if (ids.Length >= 2)
                    {
                        var pb = new Academic.DbEntities.Batches.ProgramBatch()
                        {
                            Id = Convert.ToInt32(ids[1])
                            ,
                            ProgramId = Convert.ToInt32(ids[0])
                            ,
                            Void = !item.Selected
                            ,
                            BatchId = batchId

                        };
                        list.Add(pb);
                    }
                }
                var batch = new Academic.DbEntities.Batches.Batch()
                {
                    Id = batchId,

                    Name = txtBatchName.Text
                    ,
                    SchoolId = user.SchoolId
                    ,
                    AcademicYearId = Convert.ToInt32(hidId.Value)
                };
                if (batchId <= 0)
                {
                    batch.CreatedDate = DateTime.Now;
                }
                return batch;

            }
            return null;
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListItem li in CheckBoxList1.Items)
            {
                li.Selected = chkSelectAll.Checked;
            }
        }


        #endregion





    }
}