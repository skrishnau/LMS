using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.ActivityAndResource.ActResChoose
{
    public partial class ActResChooseUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadActivities();
            LoadResources();
        }

        private void LoadActivities()
        {
            var acts = One.Values.Enums.GetActivities();
            dlistActivities.DataSource = acts;
            dlistActivities.DataBind();
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }

        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

        private void LoadResources()
        {
            var ress = One.Values.Enums.GetResources();
            dlistResources.DataSource = ress;
            dlistResources.DataBind();
            
        }

        public string GetUrl(object o)
        {
            string url = o.ToString();
            if (!string.IsNullOrEmpty(url))
            {
                url += "?SubId=" + SubjectId+"&SecId="+SectionId;
            }
            return url;
        }
    }
}