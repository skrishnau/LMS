using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Structure;
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

            LoadData2();

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

                #region Using Subject Class but its not complete

                var subClss = helper.ListCurrentSubjectClasses(UserId);
                var run = subClss.Where(x => x.IsRegular).GroupBy(x => x.RunningClass);
                foreach (var r in run)
                {
                    var nodeuc = (EarlierUc_NodesUc)
                        Page.LoadControl("~/ViewsSite/User/ModulesUc/EarlierUc_NodesUc.ascx");
                    //key is used to display year/subyear
                    var subjects = r.Select(x => x.SubjectStructure.Subject).Distinct().OrderBy(x => x.FullName).ToList();
                    nodeuc.SetStructureData(r.Key.Year, r.Key.SubYear, subjects);
                    pnlRegularCourses.Controls.Add(nodeuc);

                    //lbltitle.ToolTip = r.Key.ProgramBatch.NameFromBatch;

                }
                var irrRun = subClss.Where(x => !x.IsRegular)
                        .Select(x => x.Subject).Distinct().OrderBy(x => x.FullName).ToList();

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

                #endregion

            }
        }

        private void LoadData2()
        {
            using (var helper = new DbHelper.Subject())
            {
                var userClasses = helper.ListCurrentUserClasses(UserId);

                #region Manager Classes

                var managerClasses = userClasses.Where(x => x.Role.RoleName == "manager" || x.Role.RoleName == "teacher");

                var managerSubjects =
                    managerClasses.GroupBy(
                        x => x.SubjectClass.IsRegular ? x.SubjectClass.SubjectStructure.Subject : x.SubjectClass.Subject);
                foreach (var subjGroup in managerSubjects)
                {
                    //key is subject
                    var mngUc = (Course.ManagerCourseUc)
                        Page.LoadControl("~/ViewsSite/User/ModulesUc/Course/ManagerCourseUc.ascx");
                    mngUc.SetData(subjGroup.Key.Id, subjGroup.Key.ShortName, subjGroup.Key.FullName, subjGroup.ToList());

                    foreach (var uclass in subjGroup)
                    {
                       // var mngUcClass = (Course.ManagerCourseUc)
                       //Page.LoadControl("~/ViewsSite/User/ModulesUc/Course/ManagerCourseUc.ascx");
                       // mngUc.SetData(subjGroup.Key.Id, subjGroup.Key.ShortName, subjGroup.Key.FullName, subjGroup.ToList());
                    }
                    pnlRegularCourses.Controls.Add(mngUc);
                }

                #endregion


                #region Student Classes

                var studentClasses = userClasses.Where(x => x.Role.RoleName == "student");
                var run = studentClasses.Select(x => x.SubjectClass).GroupBy(x => x.RunningClass);
                foreach (var r in run)
                {
                    if (r.Key != null)
                    {
                        var nodeuc =
                            (EarlierUc_NodesUc)Page.LoadControl("~/ViewsSite/User/ModulesUc/EarlierUc_NodesUc.ascx");
                        //key is used to display year/subyear
                        var subjects = r.Select(x => x.IsRegular ? x.SubjectStructure.Subject : x.Subject)
                            .Distinct().OrderBy(x => x.ShortName).ToList();
                        nodeuc.SetStructureData(r.Key.Year, r.Key.SubYear, subjects);
                        //lbltitle.ToolTip = r.Key.ProgramBatch.NameFromBatch;
                        pnlRegularCourses.Controls.Add(nodeuc);
                    }
                    else
                    {
                        //key is used to display year/subyear
                        var nodeuc = (EarlierUc_NodesUc)
                                Page.LoadControl("~/ViewsSite/User/ModulesUc/EarlierUc_NodesUc.ascx");
                        var subjects = r.Select(x => x.IsRegular ? x.SubjectStructure.Subject : x.Subject)
                            .Distinct().OrderBy(x => x.ShortName).ToList();
                        nodeuc.SetStructureData(null, null, subjects);
                        //foreach (var s in r)
                        //{
                        //    var name = s.GetName;
                        //    var nodeuc = (EarlierUc_NodesUc)
                        //        Page.LoadControl("~/ViewsSite/User/ModulesUc/EarlierUc_NodesUc.ascx");
                        //    //nodeuc.SetStructureData(r.Key.Year, r.Key.SubYear, subjects);
                        //    nodeuc.SetStructureData(new Year(){Name=s.GetName}, null, subjects);
                        //    pnlRegularCourses.Controls.Add(nodeuc);
                        //}
                    }
                }

                #endregion

                //var runClass = userClasses.GroupBy(x => x.SubjectClass.RunningClass);

                //var subClss = userClasses.Select(x => x.SubjectClass);//helper.ListCurrentSubjectClasses(UserId);

                //var irrRun = subClss.Where(x => !x.IsRegular)
                //        .Select(x => x.Subject).Distinct().OrderBy(x => x.FullName).ToList();

                //if (irrRun.Any())
                //{
                //    divNonRegular.Visible = true;
                //    dListNonRegularSubjects.DataSource = irrRun;
                //    dListNonRegularSubjects.DataBind();
                //}
                //else
                //{
                //    divNonRegular.Visible = false;
                //    dListNonRegularSubjects.DataSource = null;
                //    dListNonRegularSubjects.DataBind();
                //}
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