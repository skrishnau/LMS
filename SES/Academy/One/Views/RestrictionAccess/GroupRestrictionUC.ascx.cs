using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.AccessPermission;
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
            lblError.Visible = false;
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
                pnlGroup.Visible = false;
            }
            else
            {
                using (var helper = new DbHelper.Classes())
                {
                    var grps = helper.ListGroupsOfClass(Convert.ToInt32(ddlClass.SelectedValue));
                    ddlGroupValue.DataSource = grps;
                    ddlGroupValue.DataBind();
                    pnlGroup.Visible = grps != null;
                }
            }
        }

        public string Roles
        {
            get { return hidRoles.Value; }
            set { hidRoles.Value = value; }
        }

        //public void PopulateClassList(List<IdAndName> selectedList = null)
        //{
        //    using (var helper = new DbHelper.Classes())
        //    {
        //        var list = helper.ListCurrentClassesOfTeacher(SubjectId, UserId, Roles.Split(new char[] { ',' }).ToList());
        //        //var list = helper.ListCurrentClassesOfTeacherForCombo(SubjectId, UserId, Roles);

        //        list.Insert(0, new SubjectClass() { Name = "", Id = 0 });
        //        ddlClass.DataSource = list;
        //        ddlClass.DataBind();
        //    }
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

        public int GroupRestrictionId
        {
            get { return Convert.ToInt32(hidGroupRestrictionId.Value); }
            set { hidGroupRestrictionId.Value = value.ToString(); }
        }

        public int RestrictionId
        {
            get { return Convert.ToInt32(hidRestrictionId.Value); }
            set { hidRestrictionId.Value = value.ToString(); }
        }

        public void SetRestriction(GroupRestriction res)
        {
            RestrictionId = res.RestrictionId;
            GroupRestrictionId = res.Id;
            ddlClass.SelectedValue = (res.SubjectClassId ?? 0).ToString();
            ddlClass_SelectedIndexChanged(new object(), new EventArgs());
            try
            {
                ddlGroupValue.SelectedValue = (res.GroupId ?? 0).ToString();
            }
            catch { }
        }

        public Academic.DbEntities.AccessPermission.GroupRestriction GetGroupRestriction()
        {
            try
            {

                var subjectclassId = Convert.ToInt32(ddlClass.SelectedValue);
                if (subjectclassId <= 0)
                {
                    lblError.Visible = true;
                    IsValid = false;
                    return new GroupRestriction();
                }
                var grpres = new GroupRestriction()
                {
                    Id = GroupRestrictionId
                    ,
                    RestrictionId = RestrictionId,
                    SubjectClassId = subjectclassId

                };

                if (pnlGroup.Visible)
                {
                    var grp = Convert.ToInt32(ddlGroupValue.SelectedValue);
                    if (grp > 0)
                    {
                        grpres.GroupId = grp;
                    }
                    else
                    {
                        grpres.GroupId = null;
                    }
                }
                else
                {
                    grpres.GroupId = null;
                }
                return grpres;
            }
            catch
            {
                lblError.Visible = true;
                IsValid = false;
                return new GroupRestriction();
            }
        }

        public bool IsValid = true;

        /// <summary>
        /// [0]--> parentrestrictionId, [1]--> groupRestrictionId, [2]-->ClassId, [3]-->groupId
        /// </summary>
        /// <param name="constraints"></param>
        public void SetValues(params object[] constraints)
        {
            if (constraints != null)
                try
                {
                    RestrictionId = Convert.ToInt32(constraints[0]);  //res.RestrictionId;
                    GroupRestrictionId = Convert.ToInt32(constraints[1]);// res.Id;
                    ddlClass.SelectedValue = (constraints[2]).ToString();// (res.SubjectClassId ?? 0).ToString();
                    ddlClass_SelectedIndexChanged(new object(), new EventArgs());


                    ddlGroupValue.SelectedValue = constraints[3].ToString(); // (res.GroupId ?? 0).ToString();
                }
                catch { }
        }
    }
}