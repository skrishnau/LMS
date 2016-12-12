using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.AccessPermission;
using Academic.ViewModel;

namespace One.Views.RestrictionAccess
{
    public partial class UserProfileRestriction : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static List<string> ListUserFields()
        {
            return new List<string>()
                {
                    "Username"
                    ,"First name"
                    ,"Middle name"
                    ,"Last name"
                    ,"Email"
                };
        }

        public List<IdAndName> ListUserFieldConstraints()
        {
            return new List<IdAndName>()
            {
                new IdAndName(){Id=0,Name = "equals to"},
                new IdAndName(){Id=1,Name = "contains"},
                new IdAndName(){Id=2,Name = "does not contain"},
                new IdAndName(){Id=3,Name = "starts with"},
                new IdAndName(){Id=4,Name = "ends with"},
            };
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

        public void SetIds(string parentId, string absoluteId, string relativeId, string type)
        {
            ParentId = parentId;
            AbsoluteId = absoluteId;
            RelativeId = relativeId;
            Type = type;
        }

        /// <summary>
        /// [0]- fieldName
        /// [1]- field-constraint, e.g. equal to, contains etc.
        /// [2]- value
        /// </summary>
        /// <param name="constraints"></param>
        public void SetConstraints(params object[] constraints)
        {
            if (constraints != null)
                if (constraints.Length == 3)
                {
                    ddlField.SelectedValue = constraints[0].ToString();
                    ddlConstraint.SelectedValue = constraints[1].ToString();
                    txtValue.Text = constraints[2].ToString();
                }
        }




        public Academic.DbEntities.AccessPermission.UserProfileRestriction GetUserProfileRestriction()
        {
            return new Academic.DbEntities.AccessPermission.UserProfileRestriction()
            {
                Id = UserProfileRestrictionId,
                RestrictionId = RestrictionId,
                Constraint = (byte)Convert.ToInt32(ddlConstraint.SelectedValue),
                FieldName = ddlField.SelectedValue,
                Value = txtValue.Text,
            };
        }

        public int UserProfileRestrictionId
        {
            get { return Convert.ToInt32(hidUserProfileRestrictionId.Value); }
            set { hidUserProfileRestrictionId.Value = value.ToString(); }
        }
        public int RestrictionId
        {
            get { return Convert.ToInt32(hidRestrictionId.Value); }
            set { hidRestrictionId.Value = value.ToString(); }
        }

        public bool IsValid = true;
    }
}