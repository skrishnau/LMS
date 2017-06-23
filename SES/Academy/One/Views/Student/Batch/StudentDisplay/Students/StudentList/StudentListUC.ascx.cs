using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Student.Batch.StudentDisplay.Students.StudentList
{
    public partial class StudentListUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////if (!IsPostBack)
            //{
            //    //UpdateList();
            //    using (var helper = new DbHelper.Batch())
            //    {
            //        //helper.GetStudentsOfProgramBatch(ProgramBatchId);
            //        //GridView2.DataSource = null;
            //        GridView2.DataSource = helper.GetStudentsOfProgramBatch_AsUser(ProgramBatchId);
            //        GridView2.DataBind();

            //    }
            //}
        }

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { hidProgramBatchId.Value = value.ToString(); }
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

        public void UpdateList()
        {
            using (var helper = new DbHelper.Batch())
            {
                //helper.GetStudentsOfProgramBatch(ProgramBatchId);
                //GridView2.DataSource = null;
                //GridView2.DataBind();
                GridView2.DataSource = helper.GetStudentsOfProgramBatch_AsUser(ProgramBatchId);
                GridView2.DataBind();

            }
        }

        public string GetName(object first, object mid, object last)
        {
            string name = "";
            if (first != null)
            {
                name += first.ToString();
                if (mid != null)
                {
                    name += " "+ mid.ToString();
                    
                }
                if (last != null)
                {
                    name += " "+last.ToString();
                }
            }
            return name;
        }

        public string GetLastOnline(object onlineDate)
        {
            if (onlineDate != null)
            {
                try
                {
                    var date = Convert.ToDateTime(onlineDate.ToString());
                    var difference = DateTime.Now.Subtract(date);// - date;

                    var days = (difference.Days > 0) ?
                        (difference.Days == 1) ? "a Day " : difference.Days + " Days " : "";
                    if (days != "")
                    {
                        return days + "ago";
                    }

                    var hours = (difference.Hours != 0) ? (difference
                        .Hours == 1) ? "an Hour " : difference.Hours + " Hours " : "";
                    if (hours != "")
                    {
                        return hours + "ago";
                    }
                    var minutes = (difference.Minutes > 0) ?
                        (difference.Minutes == 1) ? "a Minute " : difference.Minutes + " Minutes " : "";
                    if (minutes != "")
                        return minutes;

                    var seconds = (difference.Seconds <= 5) ?
                        "5 Seconds " : difference.Seconds + " Seconds ";
                    return seconds + "ago";
                }
                catch
                {

                    return "Never";
                }

            }
            return "Never";
        }

        protected void GridView2_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            e.Cancel = false;
           
        }
    }
}