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

namespace One.Views.RestrictionAccess
{
    public partial class GroupRestrictionUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //var user = Page.User as CustomPrincipal;
                //if (user != null)
                //{
                //    UserId = user.Id;
                //    //ViewState["Roles"] = user.GetRoles();

                //    //ViewState["SelectedClasses"] = new List<IdAndName>();
                //PopulateClassList();
                //}
            }
        }


        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClass.SelectedIndex == 0)
            {
                //get groups
                //using (var helper = new DbHelper.Classes())
                //{
                //    //helper.ListGroupsInClass()
                //}
                pnlGroup.Visible = false;
                //populate group from class
            }
            else
            {
                pnlGroup.Visible = true;
            }
        }

        public string Roles
        {
            get { return hidRoles.Value; }
            set { hidRoles.Value = value; }
        }

        //public void PopulateClassList(List<IdAndName> selectedList = null)
        //{
        //    //using (var helper = new DbHelper.Classes())
        //    //{
        //    //    //var list = helper.ListCurrentClassesOfTeacher(SubjectId, UserId, Roles);
        //    //    //list.Insert(0, new SubjectClass() { Name = "", Id = 0 });
        //    //    //ddlClass.DataSource = list;
        //    //    //ddlClass.DataBind();
        //    //}
        //}

        public int ActivityId { get; set; }

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


        /// <summary>
        /// RelativeId contain ids in the format (1_2_3) where 
        /// preceeding ids are of parent and last id is current Control's id
        /// </summary>
        public string RelativeId
        {
            get { return hidRelativeId.Value; }
            set { hidRelativeId.Value = value; }
        }

        /// <summary>
        /// The specifice id of this control.
        /// </summary>
        public string AbsoluteId
        {
            get { return hidAbsoluteId.Value; }
            set { hidAbsoluteId.Value = value; }
        }

        public string ParentId
        {
            get { return hidParentId.Value; }
            set { hidParentId.Value = value; }
        }

        public string Type
        {
            get { return hidType.Value; }
            set { hidType.Value = value; }
        }

        public event EventHandler<RestrictionEventArgs> CloseClicked;
        protected void imgClose_Click(object sender, ImageClickEventArgs e)
        {
            if (CloseClicked != null)
            {
                var arg = new RestrictionEventArgs()
                {
                    ParentId = ParentId
                    ,
                    Type = Type
                    ,
                    RelativeId = RelativeId
                    ,
                    AbsoluteId = AbsoluteId

                };
                CloseClicked(this, arg);
            }
        }

        public void SetIds(string parentId, string absoluteId, string relativeId, string type
            , int subjectId)
        {
            ParentId = parentId;
            AbsoluteId = absoluteId;
            RelativeId = relativeId;
            Type = type;
            SubjectId = subjectId;
        }



    }
}