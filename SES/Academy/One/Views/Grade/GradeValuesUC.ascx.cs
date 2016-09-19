using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.Grade
{
    public partial class GradeValuesUC : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> RemoveClicked;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int GradeValueId
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }

        public float EquivalentValue
        {
            get { return Convert.ToInt32(string.IsNullOrEmpty(txtEquivalent.Text)?"0":txtEquivalent.Text); }
            set { txtEquivalent.Text = value.ToString(); }
        }

        public TextBoxMode TextMode
        {
            get { return txtEquivalent.TextMode; }
            set { txtEquivalent.TextMode = value; }
        }

        public string Value
        {
            get { return txtValue.Text; }
            set { txtValue.Text = value; }
        }

        public bool Fail
        {
            get { return chkFail.Checked; }
            set { chkFail.Checked = value; }
        }

        public int LocalId 
        {
            get { return Convert.ToInt32(hidLocalId.Value); }
            set { hidLocalId.Value = value.ToString(); }
        }

        protected void btnClose_Click(object sender, ImageClickEventArgs e)
        {
            if (RemoveClicked != null)
            {
                RemoveClicked(this, new IdAndNameEventArgs()
                {
                    Id = LocalId
                });
            }
        }
    }
}