using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Class;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.ActivityResource.Class
{
    public partial class ClassesInActivityChoose : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    UserId = user.Id;
                    ViewState["Roles"] = user.GetRoles();

                    ViewState["SelectedClasses"] = new List<IdAndName>();
                    PopulateClassList();
                }
            }
            PopulateClassPanel();
        }

        private void PopulateClassPanel()
        {
            var selected = ViewState["SelectedClasses"] as List<IdAndName>;
            if (selected != null)
            {
                foreach (var item in selected)
                {
                    var uc = (EachClass)Page.LoadControl
                                    ("~/Views/ActivityResource/Class/EachClass.ascx");
                    uc.SetValues(item);
                    uc.RemoveClicked += uc_RemoveClicked;
                    pnlClasses.Controls.Add(uc);
                }
            }
        }

        private void PopulateClassList(List<IdAndName> selectedList = null)
        {
            using (var helper = new DbHelper.Classes())
            {

                if (selectedList != null)
                {
                    var roles = ViewState["Roles"] as List<string>;
                    var list = helper.ListCurrentClassesOfTeacher(SubjectId, UserId, roles, selectedList);
                    list.Insert(0, new SubjectClass() { Name = "", Id = 0 });
                    ddlClass.DataSource = list;
                    ddlClass.DataBind();
                }
                else
                {
                    var selected = ViewState["SelectedClasses"] as List<IdAndName>;
                    var roles = ViewState["Roles"] as List<string>;
                    var list = helper.ListCurrentClassesOfTeacher(SubjectId, UserId, roles, selected);
                    list.Insert(0, new SubjectClass() { Name = "", Id = 0 });
                    ddlClass.DataSource = list;
                    ddlClass.DataBind();
                }

            }
        }

        public int ActivityId { get; set; }

        public int Type { get; set; }

        public int UserId
        {
            get { return Convert.ToInt32(hidUserId.Value); }
            set { hidUserId.Value = value.ToString(); }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = ViewState["SelectedClasses"] as List<IdAndName>;
            if (list != null)
            {
                var sel = ddlClass.SelectedItem;
                if (sel != null)
                {
                    //if (sel.Value == "0")
                    //{
                    //    foreach (ListItem s in ddlClass.Items)
                    //    {
                    //        var item = new IdAndName()
                    //        {
                    //            Id = Convert.ToInt32(s.Value)
                    //            ,
                    //            Name = s.Text
                    //        };
                    //        list.Add(item);
                    //        var uc = (EachClass)Page.LoadControl
                    //            ("~/Views/ActivityResource/Class/EachClass.ascx");
                    //        uc.SetValues(item);
                    //        uc.RemoveClicked += uc_RemoveClicked;
                    //        pnlClasses.Controls.Add(uc);
                    //    }
                    //}
                    //else
                    {
                        var item = new IdAndName()
                        {
                            Id = Convert.ToInt32(sel.Value)
                            ,
                            Name = sel.Text
                        };
                        list.Add(item);
                        var uc = (EachClass)Page.LoadControl
                                ("~/Views/ActivityResource/Class/EachClass.ascx");
                        uc.SetValues(item);
                        uc.RemoveClicked += uc_RemoveClicked;
                        pnlClasses.Controls.Add(uc);
                        ddlClass.Items.Remove(sel);
                    }
                }
            }
            //PopulateClasses(list);
        }

        void uc_RemoveClicked(object sender, EventArgs e)
        {
            var send = sender as EachClass;
            if (send != null)
            {
                var list = ViewState["SelectedClasses"] as List<IdAndName>;
                if (list != null)
                {
                    var found = list.Find(x => x.Id == send.ClassId);
                    if (found != null)
                    {
                        if (list.Remove(found))
                        {
                            send.Visible = false;
                        }

                    }
                }
            }
        }
    }
}