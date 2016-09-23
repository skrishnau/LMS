using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Course.ActivityAndResource.ActResChoose
{
    /// <summary>
    /// Used
    /// </summary>
    public partial class ActResChooseUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadActivities();
            LoadResources();
        }

        //public int SubjectId
        //{
        //    get { return Convert.ToInt32(hidSubjectId.Value); }
        //    set { hidSubjectId.Value = value.ToString(); }
        //}

        //public int SectionId
        //{
        //    get { return Convert.ToInt32(hidSectionId.Value); }
        //    set { hidSectionId.Value = value.ToString(); }
        //} 

        private void LoadActivities()
        {
            var acts = One.Values.Enums.GetActivities();
            dlistActivities.DataSource = acts;
            dlistActivities.DataBind();
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
                //uncomment
                //url += "?SubId=" + SubjectId+"&SecId="+SectionId;
            }
            return url;
        }

        public void SetIds(int subjectId, int sectionId, string subjectName, string sectionName)
        {
            dlistResources.DataSource = null;
            dlistActivities.DataSource = null;

            //SectionId = sectionId;
            //SubjectId = subjectId;

            //LoadActivities();
            //LoadResources();

            //SectionName = sectionName;
        }

        protected void dlistActivities_ItemCommand(object source, DataListCommandEventArgs e)
        {
            var url = e.CommandArgument;
            if (url != null && e.CommandName == "Click")
            {
                if (!string.IsNullOrEmpty(url.ToString()))
                {
                    var sectionId = Session["SectionId"];
                    var subjectId = Session["SubjectId"];

                    if (sectionId != null && subjectId != null)
                    {
                        Response.Redirect(url.ToString() + "?SubId=" + subjectId.ToString() + "&SecId=" +
                                          sectionId.ToString());
                    }
                }
               

            }
        }

        protected void dlistResources_ItemCommand(object source, DataListCommandEventArgs e)
        {
            var url = e.CommandArgument;
            if (url != null && e.CommandName == "Click")
            {
                if (!string.IsNullOrEmpty(url.ToString()))
                {
                    var sectionId = Session["SectionId"];
                    var subjectId = Session["SubjectId"];

                    if (sectionId != null && subjectId != null)
                    {
                        Response.Redirect(url.ToString() + "?SubId=" + subjectId.ToString() + "&SecId=" +
                                          sectionId.ToString());
                    }
                }


            }
        }
    }
}