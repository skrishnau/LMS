using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.Structure.All.UserControls
{
    public partial class ListSubYearUC : System.Web.UI.UserControl
    {
        //public event EventHandler<StructureEventArgs> CourseClicked;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void AddControl(ListUC uc)
        {
            this.pnlSubControls.Controls.Add(uc);
        }

        public int YearId
        {
            get { return Convert.ToInt32(hidYearId.Value); }
            set { hidYearId.Value = value.ToString(); }
        }

        public int SubYearId
        {
            get { return Convert.ToInt32(hidSubYearId.Value); }
            set { this.hidSubYearId.Value = value.ToString(); }
        }


        public void SetName(int yearId,int subyearId, string name, string url)
        {
            //this.hidStructureId.Value = id.ToString();
            YearId = yearId;
            SubYearId = subyearId;
            this.lblName.Text = name;
            this.lblName.NavigateUrl = url;
        }

        protected void lnkCoursesList_Click(object sender, EventArgs e)
        {
            //ViewState["yearId"] = YearId;
            //ViewState["subYearId"] = SubYearId;
            Response.Redirect("~/Views/Structure/All/Master/CoursesList.aspx"+"?yId="+YearId+"&sId="+SubYearId);
            //if (CourseClicked != null)
            //{
            //    CourseClicked(this,new StructureEventArgs()
            //    {
            //        YearId = this.YearId
            //        ,SubYearId = this.SubYearId
            //    });
            //}
        }
    }
}