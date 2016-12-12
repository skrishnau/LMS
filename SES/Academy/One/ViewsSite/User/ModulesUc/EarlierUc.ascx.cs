using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.ViewsSite.User.ModulesUc
{
    public partial class EarlierUc : System.Web.UI.UserControl
    {
        public event EventHandler<EventArgs> EmptyData;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var helper = new DbHelper.Subject())
            {
                var subClss = helper.ListEarlierSubjectClasses(UserId);
                var againCurrent = subClss.Where(x => !(x.SessionComplete ?? false)).ToList();

                var againCurrentSubs = againCurrent.Where(x => x.IsRegular).Select(x => x.SubjectStructure.Subject).Distinct()
                    .Select(x=>x.Id).ToList();
                //var reg =
                var run = subClss.Where(x => x.IsRegular && (x.SessionComplete ?? false)).GroupBy(x => x.RunningClass).ToList();
                foreach (var r in run)
                {
                    var nodeuc =
                        (EarlierUc_NodesUc)Page.LoadControl("~/ViewsSite/User/ModulesUc/EarlierUc_NodesUc.ascx");
                    //key is used to display year/subyear
                    var subjects = r.Select(x => x.SubjectStructure.Subject)
                        .Distinct()
                        .Where(x=>!againCurrentSubs.Contains(x.Id))
                        .Distinct().OrderBy(x=>x.FullName).ToList();
                    nodeuc.SetStructureData(r.Key.Year, r.Key.SubYear, subjects);
                    pnlRegularCourses.Controls.Add(nodeuc);
                }
                againCurrentSubs = againCurrent.Where(x => !x.IsRegular).Select(x => x.Subject).Distinct()
                    .Select(x => x.Id).ToList();
                var irrRun = subClss.Where(x => !x.IsRegular && (x.SessionComplete ?? false))
                        .Select(x => x.Subject).Distinct().Where(x => !againCurrentSubs.Contains(x.Id))
                        .Distinct().OrderBy(x=>x.FullName).ToList();

                if (irrRun.Any())
                {
                    divNonRegular.Visible = true;
                    dListNonRegularSubjects.DataSource = irrRun;
                    dListNonRegularSubjects.DataBind();
                }
                else
                {
                    if (!run.Any())
                    {
                        if (EmptyData != null)
                        {
                            EmptyData(this,new EventArgs());
                        }
                    }
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

        public string GetName(object yearName, object subyeaName)
        {
            if (yearName != null)
            {
                if (subyeaName != null)
                {
                    if (!string.IsNullOrEmpty(subyeaName.ToString()))
                    {
                        return subyeaName.ToString();
                    }
                    else
                    {
                        return yearName.ToString();
                    }
                }
            }
            return "";

            //if (string.IsNullOrEmpty(y.Name))
            //    return "";
            //return y.Name;
        }

        public string GetId(object yearId, object subyeaId)
        {
            if (yearId != null)
            {
                if (subyeaId != null)
                {
                    var s = subyeaId.ToString();
                    if (!string.IsNullOrEmpty(s)&& s!="" && s!="0")
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

            //if (string.IsNullOrEmpty(y.Name))
            //    return "";
            //return y.Name;
        }
    }
}