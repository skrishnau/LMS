using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Student.Batch.Student
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //StudentCreateUc1.CloseClicked += StudentCreateUc1_CloseClicked;
            //StudentCreateUc1.SaveClicked += StudentCreateUc1_SaveClicked;
            CustomDialog1.ItemClick += CustomDialog1_ItemClick;
            //LoadAddStudent();
            //var one = FileUpload1.HasFile;

            var user = Page.User as CustomPrincipal;
            if (user != null)
            {

                if (!IsPostBack)
                {
                    if (user.IsInRole("manager") || user.IsInRole("admitter"))
                    {
                        var edit = (Session["editMode"] as string) ?? "0";

                        lnkAddStudent.Visible = edit == "1";
                        //lblAddMethod.Visible = true;
                        // <asp:ListItem Text="Choose..." Value="-1"></asp:ListItem>
                        //<asp:ListItem Text="Create Student" Value="0"></asp:ListItem>
                        //<asp:ListItem Text="Improt From System" Value="1"></asp:ListItem>
                        //<asp:ListItem Text="Import From File" Value="2"></asp:ListItem>
                        var addTypes = new List<IdAndName>()
                        {
                            new IdAndName(){Id=0, Name = "Create"}
                            ,new IdAndName(){Id=1, Name = "Improt From System" }
                            ,new IdAndName(){Id=2, Name = "Import From File"}
                        };
                        CustomDialog1.SetValues("Chooose method", addTypes, "", "cancel");
                    }
                    else
                    {
                        lnkAddStudent.Visible = false;
                        //lblAddMethod.Visible = false;
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
                            var editQuery = Request.QueryString["edit"];
                            var edit = (editQuery ?? "0").ToString();
                            int pbatchId = Convert.ToInt32(programBatchId);
                            //var success = Int32.TryParse(programBatchId, out pbatchId);
                            //if (success)
                            //{
                            //ProgramBatchId = pbatchId;

                            hidProgramBatchId.Value = programBatchId;
                            using (var helper = new DbHelper.Batch())
                            {
                                var pbatch = helper.GetProgramBatch(pbatchId);
                                if (pbatch != null)
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
                                                    Name = SiteMap.CurrentNode.ParentNode.ParentNode.ParentNode.Title
                                                    ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.ParentNode.Url
                                                    ,Void=true
                                                },
                                                new IdAndName(){
                                                    Name = pbatch.Batch.AcademicYear.Name
                                                    ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url+"?aId="+pbatch.Batch.AcademicYear.Id
                                                    ,Void=true
                                                }
                                                , new IdAndName(){
                                                    Name = pbatch.Batch.Name
                                                    ,Value=SiteMap.CurrentNode.ParentNode.Url+"?Id="+pbatch.BatchId+"&edit="+edit
                                                    ,Void=true
                                                }
                                                , new IdAndName(){Name = pbatch.Program.Name}
                                            };
                                        SiteMapUc.SetData(list);
                                        //SiteMap.CurrentNode.ReadOnly = false;
                                        //SiteMap.CurrentNode.Title = batch.Name;
                                    }
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
                                    var pbName = pbatch.NameFromBatch;
                                    lblProgramBatchName.Text = pbName;
                                    lblTitle.Text = pbName;

                                }
                            }
                            //StudentListUc1.ProgramBatchId = pbatchId;
                            StudentListUC11.ProgramBatchId = pbatchId;

                            //StudentCreateUc1.ProgramBatchId = pbatchId;

                            //TreeViewUc.BatchId = batchId;//Convert.ToInt32(id.ToString());
                            //TreeViewUc.SchoolId = Values.Session.GetSchool(Session);
                            //TreeViewUc.LoadTree(idInt);//.LoadData(idInt);
                            //.BatchId = Convert.ToInt32(id.ToString());    
                            //AddProgramsUc.BatchId = Convert.ToInt32(batchId.ToString());
                            //AddProgramsUc.LoadData(schoolId, batchId);

                            //}
                            //else
                            //{

                            //    Response.Redirect("~/Views/Student/Batch/BatchDetail/Detail.aspx" + "?Id=" + hidBatchId.Value);
                            //}
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

        void CustomDialog1_ItemClick(object sender, Academic.ViewModel.IdAndNameEventArgs e)
        {
            //var selectedValue = ddlAddStudent.SelectedValue.ToString();
            switch (e.Id)
            {
                case -1:
                    //MultiView1.ActiveViewIndex = 0;
                    break;
                case 0:
                    //create student
                    Response.Redirect("~/Views/Student/Batch/Student/StudentCreate.aspx?pbId=" + ProgramBatchId);
                    //MultiView1.ActiveViewIndex = 1;
                    break;
                case 1:

                    //MultiView1.ActiveViewIndex = 2;
                    break;
                case 2:
                    //import from file
                    Response.Redirect("~/Views/Student/Batch/Student/ImportStudentFromFile.aspx?pbId=" + ProgramBatchId);
                    //MultiView1.ActiveViewIndex = 3;
                    break;
            }
            CustomDialog1.CloseDialog();
        }
        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { hidProgramBatchId.Value = value.ToString(); }
        }
        protected void lnkAddStudent_OnClick(object sender, EventArgs e)
        {
            CustomDialog1.OpenDialog();
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

        //void StudentCreateUc1_CloseClicked(object sender, MessageEventArgs e)
        //{
        //    //lnkAddStudent.SelectedIndex = 0;
        //    MultiView1.ActiveViewIndex = 0;
        //}

        //void StudentCreateUc1_SaveClicked(object sender, MessageEventArgs e)
        //{
        //    //ddlAddStudent.SelectedIndex = 0;
        //    //MultiView1.ActiveViewIndex = 0;
        //    StudentListUC11.UpdateList();
        //    if (e.Message == "close")
        //    {
        //        //ddlAddStudent.SelectedIndex = 0;
        //        MultiView1.ActiveViewIndex = 0;
        //    }
        //}



        //protected void ddlAddStudent_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //var selectedValue = ddlAddStudent.SelectedValue.ToString();


        //    //switch (selectedValue)
        //    //{
        //    //    case "-1":
        //    //        MultiView1.ActiveViewIndex = 0;
        //    //        break;
        //    //    case "0":
        //    //        MultiView1.ActiveViewIndex = 1;
        //    //        break;
        //    //    case "1":
        //    //        MultiView1.ActiveViewIndex = 2;
        //    //        break;
        //    //    case "2":
        //    //        MultiView1.ActiveViewIndex = 3;
        //    //        break;
        //    //}
        //}


    }
}