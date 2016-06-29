using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.ListingMain.CourseMain
{
    public partial class NewGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var programId = Request.QueryString["Id"];
                if (programId!=null)
                {
                    hidProgramId.Value = programId;
                    int pId;
                    var success = Int32.TryParse(programId, out pId);
                    if (success)
                    {
                        GroupUc.LoadData(pId);                        
                    }
                }
            }
        }
        #region Properties

        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgramId.Value); }
            set { hidProgramId.Value = value.ToString(); }
        }


        #endregion
    }
}