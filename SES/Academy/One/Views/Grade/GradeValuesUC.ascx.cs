using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Academic.Database.Migrations;
using Academic.ViewModel;

namespace One.Views.Grade
{
    public partial class GradeValuesUC : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> RemoveClicked;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEquivalent.BackColor = Color.White;
            lblError.Visible = false;
        }

        public int GradeValueId
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }

        public float? EquivalentValue
        {
            get
            {
                if (string.IsNullOrEmpty(txtEquivalent.Text))
                {
                    txtEquivalent.BackColor = Color.LightPink;
                    lblError.Visible = true;
                    return null;
                }
                try
                {
                    var val = (float)Convert.ToDecimal(txtEquivalent.Text);
                    return val;
                }
                catch
                {
                    txtEquivalent.BackColor = Color.LightPink;
                    lblError.Visible = true;
                    return null;
                }
                //return Convert.ToInt32(string.IsNullOrEmpty(txtEquivalent.Text)?"0":txtEquivalent.Text);
            }
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

        public void SetValues(int localId, string value, float equivalent, bool fail)
        {
            LocalId = localId;
            Value = value;
            EquivalentValue = equivalent;
            Fail = fail;
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