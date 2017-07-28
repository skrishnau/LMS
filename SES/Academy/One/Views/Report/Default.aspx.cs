using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using Academic.ViewModel.ActivityResource;

namespace One.Views.Report
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var clsId = Request.QueryString["ccId"];
                    if (clsId != null)
                    {

                        var classId = Convert.ToInt32(clsId);
                        ClassId = classId;
                        LoadClass();
                    }
                    else Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx");
                }
            }
            catch { Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx"); }

        }

        private void LoadClass()
        {
            var classId = ClassId;
            using (var helper = new DbHelper.Classes())
            {
                List<StudentReportViewModel> reports;
                List<IdAndName> activityHeading;
                var cls = helper.GetSubjectClassReport(classId, out reports, out activityHeading);
                if (cls != null)
                {
                    lblClassName.Text = cls.IsRegular ? cls.GetName : cls.Name;
                    lblCourseName.Text = cls.IsRegular
                        ? cls.SubjectStructure.Subject.FullName
                        : cls.Subject.FullName;


                    if (reports != null && reports.Any())
                    {

                        #region Heading

                        var initRow = new TableRow();
                        if (chkImage.Checked)
                        {
                            initRow.Cells.Add(new TableCell() { Text = "Image", CssClass = "data-value-bold-dark-back" });
                        }
                        if (chkRoll.Checked)
                            initRow.Cells.Add(new TableCell() { Text = "Roll", CssClass = "data-value-bold-dark-back" });
                        if (chkName.Checked)
                            initRow.Cells.Add(new TableCell() { Text = "Name", CssClass = "data-value-bold-dark-back" });

                        //chkActivities.DataSource = activityHeading;
                        //chkActivities.DataBind();

                        foreach (var head in activityHeading)
                        {
                            initRow.Cells.Add(new TableCell() { Text = head.Name + " (Wt.: " + head.Value + ")", CssClass = "data-value-bold-dark-back" });

                            //pnlActivityCheck.Controls.Add(new CheckBox()
                            //{
                            //    Text = head.Name
                            //    ,
                            //    Checked = true
                            //    ,
                            //    ID = "chk_" + head.Id + "_" + head.Name
                            //    ,
                            //    CssClass = "span-padding"
                            //});
                        }
                        if (chkTotal.Checked)
                            initRow.Cells.Add(new TableCell() { Text = "Total", CssClass = "data-value-bold-dark-back" });
                        tblStudents.Rows.Add(initRow);

                        #endregion


                        #region Each data populate



                        foreach (var r in reports)
                        {
                            var newRow = new TableRow();
                            if (chkImage.Checked)
                            {
                                var img = new Image()
                                {
                                    ImageUrl = r.ImageUrl
                                    ,
                                    Height = 20
                                    ,
                                    Width = 20
                                };
                                var cell = new TableCell();

                                cell.Controls.Add(img);
                                newRow.Cells.Add(cell);//new TableCell() { Text = "Image" }

                            }
                            if (chkRoll.Checked)
                                newRow.Cells.Add(new TableCell() { Text = r.CRN });
                            if (chkName.Checked)
                                newRow.Cells.Add(new TableCell() { Text = r.StudentName });
                            foreach (var actvitiy in r.ActivityViewModels)
                            {
                                ////var chkbox = (CheckBox)pnlActivityCheck.FindControl("chk_" + head.Id + "_" + head.Name);
                                //var checkedValue = true;
                                ////if (chkbox != null)
                                //{
                                //    //checkedValue = chkbox.Checked;
                                //}
                                //if (checkedValue)
                                newRow.Cells.Add(new TableCell() { Text = actvitiy.ObtainedMarks });
                            }
                            if (chkTotal.Checked)
                                newRow.Cells.Add(new TableCell() { Text = r.TotalMarks });

                            tblStudents.Rows.Add(newRow);
                        }

                        #endregion
                    }

                    //ListView1.DataSource = helper.ListSubjectSessionEnrolledUsers(classId);
                    //ListView1.DataBind();
                }
            }
        }

        void LoadSitemap(Academic.DbEntities.Class.SubjectClass cls)
        {
            var from = Request.QueryString["from"];
            from = from ?? "";
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
                                        ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url
                                        ,Void=true
                                    },
                                    new IdAndName(){
                                        Name = cls.GetCourseFullName
                                        ,Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url+"?cId="+(cls.GetCourseId)
                                        ,Void=true
                                    }
                                    ,
                                    new IdAndName()
                                    {
                                        Name =cls.GetName
                                        ,Value = "~/Views/Class/CourseClassDetail.aspx?ccId=" +cls.Id+
                                                 "&from="+from,
                                                 Void = true
                                    }
                                    , new IdAndName()
                                    {
                                        Name = "Report"
                                    }
                                };
                SiteMapUc.SetData(list);
            }
        }






        public string GetImageUrl(object imageId)
        {
            if (imageId != null)
            {
                var id = Convert.ToInt32(imageId.ToString());
                using (var helper = new DbHelper.WorkingWithFiles())
                {
                    return helper.GetImageUrl(id);
                }
            }
            return "";
        }

        public string GetName(object first, object mid, object last)
        {
            string name = "";
            if (first != null)
            {
                name += first.ToString();
                if (mid != null)
                {
                    name += " " + mid.ToString();

                }
                if (last != null)
                {
                    name += " " + last.ToString();
                }
            }
            return name;
        }

        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            try
            {
                LoadClass();
                //foreach (TableRow r in tblStudents.Rows)
                //{
                //    var cells = r.Cells;

                //    cells[0].Visible = (chkImage.Checked);
                //    cells[1].Visible = chkRoll.Checked;
                //    cells[2].Visible = chkName.Checked;
                //}
            }
            catch { }

        }

        public int ClassId
        {
            get { return Convert.ToInt32(hidSubjectClassId.Value); }
            set { hidSubjectClassId.Value = value.ToString(); }
        }

        protected void lnkFilter_OnClick(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
                imgFilter.ImageUrl = "~/Content/Icons/Arrow/arrow_down.png";
            else imgFilter.ImageUrl = "~/Content/Icons/Arrow/arrow_right.png";
            pnlFilter.Visible = !pnlFilter.Visible;

        }
    }
}