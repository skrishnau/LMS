using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Structure.All.UserControls
{
    public partial class LevelCreate : System.Web.UI.UserControl
    {
        public event EventHandler<MessageEventArgs> SaveClickedEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            AllValidatorVisibility = false;
        }



        public int _id
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        public bool CancelButtonVisible
        {
            get { return btnCancel.Visible; }
            set { btnCancel.Visible = value; }
        }

        public bool AllValidatorVisibility {  set { txtNameVali.Visible = value; } }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //bool isValid = true;
            //if (txtName.Text == "")
            //{
            //    txtNameVali.Visible = true;
            //    isValid = false;
            //}
            //if (isValid)
            //{
            //    using (var helper = new DbHelper.Structure())
            //    {
            //        var level = new Academic.DbEntities.Structure.Level()
            //        {
            //            Name = txtName.Text
            //            ,
            //            Description = txtDescription.Text
            //            ,
            //            Id = this._id
            //            ,
            //            SchoolId = this.SchoolId

            //        };
            //        var saved = helper.AddOrUpdateLevel(level);
            //        if (saved != null)
            //        {
            //            if (SaveClickedEvent != null)
            //            {
            //                SaveClickedEvent(this, DbHelper.StaticValues.SuccessSaveMessageEventArgs);
            //            }
            //            ClearCreateTextBoxes();
            //        }
            //        else
            //        {
            //            if (SaveClickedEvent != null)
            //            {
            //                SaveClickedEvent(this, DbHelper.StaticValues.ErrorSaveMessageEventArgs);
            //            }
            //        }
            //    }
            //}
        }

        void ClearCreateTextBoxes()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (SaveClickedEvent != null)
            {
                SaveClickedEvent(this, DbHelper.StaticValues.EmptyMessageEventArgs);
            }
        }
    }
}