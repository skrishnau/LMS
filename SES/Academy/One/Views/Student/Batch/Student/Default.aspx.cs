using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Student.Batch.Student
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentCreateUc1.CloseClicked += StudentCreateUc1_CloseClicked;
            StudentCreateUc1.SaveClicked += StudentCreateUc1_SaveClicked;
            //LoadAddStudent();
            //var one = FileUpload1.HasFile;

            var user = Page.User as CustomPrincipal;
            if (user != null)
            {

                if (!IsPostBack)
                {
                    if (user.IsInRole("manager") || user.IsInRole("admitter"))
                    {
                        ddlAddStudent.Visible = true;
                        lblAddMethod.Visible = true;
                    }
                    else
                    {
                        ddlAddStudent.Visible = false;
                        lblAddMethod.Visible = false;
                    }
                    if (user.IsInRole("student"))
                    {
                        Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx", true);
                    }
                    //CustomDialog.SetValues("Add Student",null,"click");
                    try
                    {
                        //here id is programBatchId
                        var programBatchId = Request.QueryString["pbId"];
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
                                    if (pbatch != null)
                                    {
                                        var stname = "N/A";
                                        //int pbId = 0;
                                        var rc =
                                            pbatch.RunningClasses.FirstOrDefault(x => (x.IsActive ?? true)// && x.Session.IsActive
                                                                                        && !(x.Completed ?? false))
                                            ;
                                        if (rc != null)
                                        {
                                            stname = rc.Year.Name;
                                            if (rc.SubYearId != null)
                                            {
                                                stname += " &nbsp; " + rc.SubYear.Name;//.NameFromBatch;
                                                // pbId = pb.ProgramBatchId ?? 0;
                                            }
                                        }
                                        lblCurrentlyIn.Text = stname;
                                        hidBatchId.Value = pbatch.BatchId.ToString();
                                        lblProgramBatchName.Text = pbatch.NameFromBatch;
                                    }
                                }
                                //StudentListUc1.ProgramBatchId = pbatchId;
                                StudentListUC11.ProgramBatchId = pbatchId;

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
                            Response.Redirect("~/Views/Student/");
                        }
                    }
                    catch
                    {
                        Response.Redirect("~/Views/Student/");
                    }
                }
            }
        }

        //void LoadAddStudent()
        //{
        //    if (ddlAddStudent.SelectedIndex == 0)
        //    {
        //        var uc = (Views.Student.Batch.StudentDisplay.Students.StudentList.StudentListUC)
        //            Page.LoadControl(
        //                "~/Views/Student/Batch/StudentDisplay/Students/StudentList/StudentListUC.ascx");
        //        CustomDialog.AddControl(uc);
        //        CustomDialog.SetValues("Student Create", null, "click");
        //    }
        //}

        void StudentCreateUc1_CloseClicked(object sender, MessageEventArgs e)
        {
            ddlAddStudent.SelectedIndex = 0;
            MultiView1.ActiveViewIndex = 0;
        }

        void StudentCreateUc1_SaveClicked(object sender, MessageEventArgs e)
        {
            //ddlAddStudent.SelectedIndex = 0;
            //MultiView1.ActiveViewIndex = 0;
            StudentListUC11.UpdateList();
            if (e.Message == "close")
            {
                ddlAddStudent.SelectedIndex = 0;
                MultiView1.ActiveViewIndex = 0;
            }
        }

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { hidProgramBatchId.Value = value.ToString(); }
        }

        protected void ddlAddStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = ddlAddStudent.SelectedValue.ToString();


            switch (selectedValue)
            {
                case "-1":
                    MultiView1.ActiveViewIndex = 0;
                    break;
                case "0":
                    MultiView1.ActiveViewIndex = 1;
                    break;
                case "1":
                    MultiView1.ActiveViewIndex = 2;
                    break;
                case "2":
                    MultiView1.ActiveViewIndex = 3;
                    break;
            }
        }
    }
}