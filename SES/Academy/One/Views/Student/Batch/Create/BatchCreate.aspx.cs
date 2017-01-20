using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;
using One.Views.Structure.All.UserControls.StructureView;

namespace One.Views.Student.Batch.Create
{
    public partial class BatchCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCommenceDateError.Visible = false;

            lblError.Visible = false;
            if (!IsPostBack)
            {
                var user = User as CustomPrincipal;
                if (user != null)
                    try
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
                            }
                            ,new IdAndName()
                            {
                                Name = SiteMap.CurrentNode.Title
                            }
                        };
                            SiteMapUc.SetData(list);
                        }
                        var id = Request.QueryString["bId"];
                        if (id != null)
                        {
                            SetDatasForEdit(Convert.ToInt32(id.ToString()));
                        }
                        LoadStructure(user.SchoolId);
                    }
                    catch
                    {
                        //batchlist redirect
                    }

            }
        }


        public void LoadStructure(int schoolId)
        {
            var batchId = BatchId;
            using (var helper = new DbHelper.Structure())
            {
                var programs = helper.ListPrograms(schoolId);
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
        }

        #region Properties



        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set
            {
                hidBatchId.Value = value.ToString();
            }
        }

        #endregion


        protected void btnSaveAndReturnToList_Click(object sender, EventArgs e)
        {
            SaveBatch();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Student/?edit=1");
            //if (BatchId > 0)
            //{
            //    Response.Redirect("~/Views/Student/Batch/");
            //}
            //else
            //{
            //    Response.Redirect("~/Views/Student/?edit=1");
            //}
        }


        private void SaveBatch()
        {
            var batchId = BatchId;
            var user = Page.User as CustomPrincipal;
            if (user != null && Page.IsValid)
            {
                var date = DateTime.Now;
                if (txtCommenceDate.Text != "")
                {
                    try
                    {
                        date = Convert.ToDateTime(txtCommenceDate.Text);
                    }
                    catch
                    {
                        lblCommenceDateError.Visible = true;
                        return;
                    }
                }

                var lst = new List<Academic.DbEntities.Batches.ProgramBatch>();
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
                        lst.Add(pb);
                    }
                }
                using (var helper = new DbHelper.Batch())
                {
                    var batch = new Academic.DbEntities.Batches.Batch()
                    {
                        Id = batchId,

                        Name = txtName.Text
                        ,
                        Description = txtDescription.Text
                        ,
                        SchoolId = user.SchoolId
                        
                        
                    };
                    if (batchId <= 0)
                    {
                        batch.CreatedDate = DateTime.Now;
                    }
                    if (!string.IsNullOrEmpty(txtCommenceDate.Text))
                    {
                        batch.ClassCommenceDate = date;
                    }
                    else
                    {
                        batch.ClassCommenceDate = null;
                    }
                    
                    var saved = helper.AddOrUpdateBatch(batch, lst);
                    if (saved != null)
                    {
                        Response.Redirect("~/Views/Student/?edit=1");
                        //if (batchId > 0)
                        //{
                        //    Response.Redirect("~/Views/Student/?edit=1");
                        //}
                        //else
                        //{
                        //    Response.Redirect("~/Views/Student/Batch/?Id=" + batchId);
                        //}
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }
            }
        }

        public void SetDatasForEdit(int batchId)
        {
            using (var helper = new DbHelper.Batch())
            {
                var batch = helper.GetBatch(batchId);
                if (batch != null)
                {
                    BatchId = batch.Id;
                    txtName.Text = batch.Name;
                    txtDescription.Text = batch.Description;
                    txtCommenceDate.Text = batch.ClassCommenceDate == null ? "" : batch.ClassCommenceDate.Value.ToShortDateString();
                }
                // program batches
            }
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListItem li in CheckBoxList1.Items)
            {
                li.Selected = chkSelectAll.Checked;
            }
        }


    }
}