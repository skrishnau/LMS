using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Exam.ExamType
{
    public partial class ExamTypeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Page.User as CustomPrincipal;
            if (user != null)
            {
                using (var helper = new DbHelper.Exam())
                {
                    var list = helper.ListExamTypes(user.SchoolId);
                    DataList1.DataSource = list;
                    DataList1.DataBind();
                    
                }
            }

        }

        public string GetWeight(object isPercent, object weight)
        {
            if (isPercent != null && weight != null)
            {
                var isP = (bool)isPercent;
                return weight.ToString() + ((isP) ? " %" : " Marks");
            }
            return "";
        }
    }
}