using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.ActivityResource.Choice
{
    public partial class ChoiceOptionsCreate : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> RemoveClicked;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int ChoiceId
        {
            get { return Convert.ToInt32(hidChoiceId.Value); }
            set { hidChoiceId.Value = value.ToString(); }
        }

        public int OptionId
        {
            get { return Convert.ToInt32(hidOptionId.Value); }
            set { hidOptionId.Value = value.ToString(); }
        }

        public bool LimitEnabled
        {
            set { txtLimit.Enabled = value; }
            get { return txtLimit.Enabled; }
        }

        public string OptionName
        {
            set { lblOption.Text = value; }
        }

        public string LimitName
        {
            set { lblLimit.Text = value; }
        }

        public void SetValues(string optionName, string limitName, bool limitEnabled=false)
        {
            lblOption.Text = optionName;
            lblLimit.Text = limitName;
            LimitEnabled = limitEnabled;
        }


        public void SetValues(int choiceId,int optionId,string optionName, string limitName
            , string option="", long limit = 0, bool limitEnabled = false)
        {
            ChoiceId = choiceId;
            OptionId = optionId;

            lblOption.Text = optionName;
            lblLimit.Text = limitName;

            txtOption.Text = option;
            txtLimit.Text = limit.ToString();

            LimitEnabled = limitEnabled;

        }

        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            if (RemoveClicked != null)
            {
                RemoveClicked(this,new IdAndNameEventArgs()
                {
                    Id = OptionId
                });
            }
        }


        public bool RemoveButtonVisibility
        {
            set
            {
                lnkRemove.Enabled = value;
                lnkRemove.Visible = value;
            }
        }

        public string PageKey
        {
            set { hidPageKey.Value = value; }
        }

        public int Position
        {
            get { return Convert.ToInt32(hidPosition.Value); }
            set { hidPosition.Value = value.ToString(); }
        }

        public long LimitValue
        {
            get { return Convert.ToInt64(txtLimit.Text); }
        }

        public string OptionValue
        {
            get { return txtOption.Text; }
        }
    }
}