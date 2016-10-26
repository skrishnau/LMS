using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.ActivityResource.Class
{
    public partial class EachClass : System.Web.UI.UserControl
    {
        public event EventHandler<EventArgs> RemoveClicked;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetValues(Academic.ViewModel.IdAndName item)
        {
            lblClassName.Text = item.Name;
            hidClassId.Value = item.Id.ToString();
        }

        public int ClassId
        {
            get { return Convert.ToInt32(hidClassId.Value); }
            set { hidClassId.Value = value.ToString(); }
        }

        public string ClassName
        {
            get { return lblClassName.Text; }
            set { lblClassName.Text = value; }
        }


        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            if (RemoveClicked != null)
            {
                RemoveClicked(this,new EventArgs());
            }
        }
    }
}