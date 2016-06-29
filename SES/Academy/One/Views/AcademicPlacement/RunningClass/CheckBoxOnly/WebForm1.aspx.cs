using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.AcademicPlacement.RunningClass.CheckBoxOnly
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

               TreeViewUC1.SchoolId = Values.Session.GetSchool(Session);

                //using (var helper = new DbHelper.AcademicPlacement())
                //{
                //    var sturcList = helper.GetClassStructureInTreeView(Values.Session.GetSchool(Session), 0, 0);
                //    foreach (var str in sturcList)
                //    {
                //        TreeViewUC1.
                //    }
                //}
            }
            else
            {
               /* string passedArgument = Request.Params.Get("__EVENTARGUMENT");
                string x = Request.Params.Get("hidX");

                string controlName = Request.Params.Get("__EVENTTARGET");
                string[] values = passedArgument.Split(new char[] { ',' });
                if (values.Length == 2 && controlName == "imgStdGrp")
                {
                    //hidX.Value = values[0];
                    //hidY.Value = values[1];
                    //lnlbtn123_Click(this, new EventArgs());
                }*/
            }
        }
    }
}