using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.Section
{
    public partial class CreateSection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var sectionId = Request.QueryString["SecId"];
                var retUrl = Request.QueryString["ReturnUrl"];
                var subjectId = Request.QueryString["SubId"];

                if (!string.IsNullOrEmpty(sectionId) && !string.IsNullOrEmpty(subjectId) && !string.IsNullOrEmpty(retUrl))
                {
                    int sub = 0, sec = 0;
                    CreateSectionUc1.RedirectUrl = retUrl;

                    if (Int32.TryParse(subjectId, out sub))
                    {
                        CreateSectionUc1.SubjectId = sub;
                    }

                    if (Int32.TryParse(sectionId, out sec))
                    {
                        CreateSectionUc1.SectionId = sec;
                    }

                   
                }
            }
        }
    }
}