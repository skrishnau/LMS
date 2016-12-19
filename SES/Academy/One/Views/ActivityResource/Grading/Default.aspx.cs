using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.Grading
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var actResId = Request.QueryString["actresId"];
                var subId = Request.QueryString["SubId"];
                var secId = Request.QueryString["secId"];

                if (subId != null && actResId != null && secId != null)
                {
                    SubjectId = Convert.ToInt32(subId);
                    SectionId = Convert.ToInt32(secId);
                    var arId = Convert.ToInt32(actResId);
                    ActivityResourceId = arId;
                    LoadActivityResource(arId);
                }
                else { Response.Redirect("~/"); }

            }

        }

        private void LoadActivityResource(int arId)
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var actRes = helper.GetActivityResource(arId);
                if (actRes != null)
                {
                    foreach (var aCls in actRes.ActivityClasses)
                    {
                        var subCls = aCls.SubjectClass;
                        //get a uc , initialize uc
                        var classUc = (ClassGradeDisplayUc)
                            Page.LoadControl("~/Views/ActivityResource/Grading/ClassGradeDisplayUc.ascx");
                        classUc.SetData(subCls.IsRegular ? subCls.GetName : subCls.Name);
                        var any = false;
                        foreach (var clsUser in subCls.ClassUsers)
                        {
                            //initialize another uc
                            if (clsUser.Role.RoleName == "student"
                               && !(clsUser.Void ?? false))
                            {
                                var userUc = (UserGradeDisplayUc)
                                Page.LoadControl("~/Views/ActivityResource/Grading/UserGradeDisplayUc.ascx");
                                userUc.SetData(clsUser,actRes.Id,actRes.ActivityResourceId,actRes.ActivityResourceType);
                                classUc.AddControls(userUc);
                                any = true;
                            }
                        }
                        if (!any)
                        {
                            classUc.AddControlsInsideTable(new Literal()
                            {
                                Text = "<tr>" +
                                       "<td>" +
                                       "No students found." +
                                       "</td>" +
                                       "</tr>"
                            }, false);
                            pnlGradeList.Controls.Add(new Literal() { Text = "<br />" });

                        }
                        pnlGradeList.Controls.Add(classUc);
                        pnlGradeList.Controls.Add(new Literal() { Text = "<br />" });
                        pnlGradeList.Controls.Add(new Literal() { Text = "<br />" });

                    }
                }
            }
        }

        #region Properties

        public int ActivityResourceId
        {
            get { return Convert.ToInt32(hidActivityResourceId.Value); }
            set { hidActivityResourceId.Value = value.ToString(); }
        }

        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }

        #endregion

    }
}