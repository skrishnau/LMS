using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class CoursesUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (TopLevelRole == "manager" || TopLevelRole == "course-editor")
            //    {
            //        //turn on add button in course 
            //    }
            //}

            LoadData();

        } //Earlier 
        /*var regularincomplete = subSession.Where(x => x.IsRegular)
            .Select(x => x.SubjectStructure.Subject).ToList();
        var notregularincomplete = subSession.Where(x => !x.IsRegular)
            .Select(x => x.Subject).ToList();
        regularincomplete.AddRange(notregularincomplete);*/
        private void LoadData()
        {
            using (var helper = new DbHelper.Subject())
            {
                var subClss = helper.ListCurrentSubjectClasses(UserId);
                var run = subClss.Where(x => x.IsRegular).GroupBy(x => x.RunningClass);
                foreach (var r in run)
                {
                    var nodeuc =
                        (EarlierUc_NodesUc)Page.LoadControl("~/ViewsSite/User/ModulesUc/EarlierUc_NodesUc.ascx");
                    //key is used to display year/subyear
                    var subjects = r.Select(x => x.SubjectStructure.Subject).Distinct().OrderBy(x=>x.Name).ToList();
                    nodeuc.SetStructureData(r.Key.Year, r.Key.SubYear, subjects);
                    pnlRegularCourses.Controls.Add(nodeuc);

                    lbltitle.ToolTip = r.Key.ProgramBatch.NameFromBatch;

                }
                var irrRun = subClss.Where(x => !x.IsRegular)
                        .Select(x => x.Subject).Distinct().OrderBy(x=>x.Name).ToList();

                if (irrRun.Any())
                {
                    divNonRegular.Visible = true;
                    dListNonRegularSubjects.DataSource = irrRun;
                    dListNonRegularSubjects.DataBind();
                }
                else
                {
                    divNonRegular.Visible = false;
                    dListNonRegularSubjects.DataSource = null;
                    dListNonRegularSubjects.DataBind();
                }
            }
        }
        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }

        public string TopLevelRole
        {
            get { return hidTopLevelRole.Value; }
            set { hidTopLevelRole.Value = value; }
        }
        public string GetId(object yearId, object subyeaId)
        {
            if (yearId != null)
            {
                if (subyeaId != null)
                {
                    var s = subyeaId.ToString();
                    if (!string.IsNullOrEmpty(s) && s != "" && s != "0")
                    {
                        return subyeaId.ToString();
                    }
                    else
                    {
                        return yearId.ToString();
                    }
                }
            }
            return "";
        }
        public string GetType(object name)
        {
            if (name != null)
            {
                if (string.IsNullOrEmpty(name.ToString()))
                    return "year";
                else return "subyear";
            }
            return "";
        }
    }
}