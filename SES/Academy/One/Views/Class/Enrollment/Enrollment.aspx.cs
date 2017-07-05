using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.Class.Enrollment
{
    public partial class Enrollment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var classId = Request.QueryString["ccId"];
                if (classId != null)
                {
                    try
                    {
                        hidCourseClassId.Value = classId;
                        var clsId = Convert.ToInt32(classId);
                        CourseClassId = clsId;
                        using (var helper = new DbHelper.Classes())
                        {
                            UserEnrollUC_ListDisplay1.SubjectSessionId = Convert.ToInt32(classId);
                            var cls = helper.GetSubjectSession(clsId);
                            if (cls != null)
                            {
                                var clsname = cls.GetName;
                                //var coursefullname = cls.GetCourseFullName;
                                lblClassName.Text = clsname;
                                lblCourseName.Text = cls.GetCourseFullName;
                                if (SiteMap.CurrentNode != null)
                                {
                                    var list = new List<IdAndName>()
                                    {
                                        new IdAndName()
                                        {
                                            Name = SiteMap.RootNode.Title
                                            ,
                                            Value = SiteMap.RootNode.Url
                                            ,
                                            Void = true
                                        },
                                        new IdAndName()
                                        {
                                            Name = SiteMap.CurrentNode.ParentNode.ParentNode.ParentNode.Title
                                            ,
                                            Value = SiteMap.CurrentNode.ParentNode.ParentNode.ParentNode.Url
                                            ,
                                            Void = true
                                        },
                                        new IdAndName()
                                        {
                                            Name = cls.GetCourseFullName
                                            ,
                                            Value = SiteMap.CurrentNode.ParentNode.ParentNode.Url + "?cId=" + (cls.GetCourseId)
                                            ,
                                            Void = true
                                        }
                                        ,
                                        new IdAndName()
                                        {
                                            Name = clsname
                                            ,Value = SiteMap.CurrentNode.ParentNode.Url+"?ccId="+classId
                                            ,Void = true
                                        }
                                        ,new IdAndName(){Name = "Users enroll"}
                                    };
                                    SiteMapUc.SetData(list);
                                }
                            }
                        }
                    }
                    catch
                    {
                        Response.Redirect("~/ViewsSite/User/Dashboard/Dashboard.aspx");
                    }
                }
            }
        }

        public int CourseClassId
        {
            get { return Convert.ToInt32(hidCourseClassId.Value); }
            set { hidCourseClassId.Value = value.ToString(); }
        }
    }
}