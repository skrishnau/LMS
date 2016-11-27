using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;

namespace One.Views.ActivityResource.Class
{
    public partial class EachClass : System.Web.UI.UserControl
    {
        public event EventHandler<EventArgs> RemoveClicked;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGroup();
        }

        private void LoadGroup()
        {
            using (var helper = new DbHelper.Classes())
            {
                var groups = helper.ListGroupsOfClass(ClassId);
                //if(groups)
            }
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

        public IdAndName GetClass()
        {
            return new IdAndName(){Id = ClassId, Name=ClassName};
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