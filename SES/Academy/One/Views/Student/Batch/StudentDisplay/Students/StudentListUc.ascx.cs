using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Student.Batch.StudentDisplay.Students
{
    public partial class StudentListUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { hidProgramBatchId.Value = value.ToString(); }
        }

        private List<Academic.DbEntities.Students.Student> StudentList()
        {
            using (var helper = new DbHelper.Batch())
            {
                return helper.GetStudentsOfProgramBatch(ProgramBatchId);
            }
        }

        public string GetEmail(object o)
        {
            var user = o as Academic.DbEntities.User.Users;
            if (user == null)
                return "";
            return user.Email;
        }
        public string GetPhone(object o)
        {
            var user = o as Academic.DbEntities.User.Users;
            if (user == null)
                return "";
            return user.Phone;
        }
    }
}