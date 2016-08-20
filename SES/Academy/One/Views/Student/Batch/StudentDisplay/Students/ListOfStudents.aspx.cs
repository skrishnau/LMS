using Academic.DbHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace One.Views.Student.Batch.StudentDisplay.Students
{
    public partial class ListOfStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            StudentCreateUc1.CloseClicked += StudentCreateUc1_CloseClicked;
            //var has1 = FileUpload1.HasFile;
            //var has2 = FileUpload2.HasFile;
            //var has3 = FileUpload3.HasFile;
            
            if (!IsPostBack)
            {
                try
                {
                    //here id is programBatchId
                    var programBatchId = Request.QueryString["Id"];
                    if (programBatchId != null)
                    {
                        int pbatchId = 0;
                        var success = Int32.TryParse(programBatchId, out pbatchId);
                        if (success)
                        {
                            //ProgramBatchId = pbatchId;
                            hidProgramBatchId.Value = programBatchId;
                            using (var helper = new DbHelper.Batch())
                            {
                                var pbatch = helper.GetProgramBatch(pbatchId);
                                hidBatchId.Value = pbatch.BatchId.ToString();
                                if (pbatch != null)
                                {
                                    lblProgramBatchName.Text = pbatch.NameFromBatch;
                                }
                            }
                            StudentListUc.ProgramBatchId = pbatchId;

                            StudentCreateUc1.ProgramBatchId = pbatchId;





                            //TreeViewUc.BatchId = batchId;//Convert.ToInt32(id.ToString());
                            //TreeViewUc.SchoolId = Values.Session.GetSchool(Session);
                            //TreeViewUc.LoadTree(idInt);//.LoadData(idInt);
                            //.BatchId = Convert.ToInt32(id.ToString());    
                            //AddProgramsUc.BatchId = Convert.ToInt32(batchId.ToString());
                            //AddProgramsUc.LoadData(schoolId, batchId);

                        }
                        else
                        {

                            Response.Redirect("~/Views/Student/Batch/BatchDetail/Detail.aspx" + "?Id=" + hidBatchId.Value);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/Student/Batch/ListBatch.aspx");
                    }
                }
                catch
                {
                    Response.Redirect("~/Views/Student/Batch/ListBatch.aspx");
                }
            }
        }

        void StudentCreateUc1_CloseClicked(object sender, Values.MessageEventArgs e)
        {
            ddlAddStudent.SelectedIndex = 0;
            MultiView1.ActiveViewIndex = 0;
        }

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { hidProgramBatchId.Value = value.ToString(); }
        }

        protected void ddlAddStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = ddlAddStudent.SelectedValue.ToString();
            //ddlAddStudent.SelectedIndexChanged -= ddlAddStudent_SelectedIndexChanged;
            //try
            //{
            //    ddlAddStudent.SelectedValue = "-1";
            //    ddlAddStudent.SelectedIndexChanged += ddlAddStudent_SelectedIndexChanged;
            //}
            //catch (Exception)
            //{
            //    ddlAddStudent.SelectedIndexChanged += ddlAddStudent_SelectedIndexChanged;
            //}

            switch (selectedValue)
            {
                case "-1":
                    MultiView1.ActiveViewIndex = 0;
                    break;
                case "0":
                    MultiView1.ActiveViewIndex = 1;
                    //Context.Items.Add("ProgramBatchId", ProgramBatchId);
                    //Server.Transfer("~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/StudentCreate.aspx");
                    //Response.Redirect("~/Views/Student/Create/Student.aspx"+"?RedirectUrl="+Request.Url.PathAndQuery);
                    break;
                case "1":
                    MultiView1.ActiveViewIndex = 2;
                    //Response.Redirect("");
                    break;
                case "2":
                    MultiView1.ActiveViewIndex = 3;
                    //Response.Redirect("");
                    break;
            }
        }
    }
}