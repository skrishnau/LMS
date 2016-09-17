using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.RestrictionAccess
{
    public partial class DateRestrictionUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

    }
}