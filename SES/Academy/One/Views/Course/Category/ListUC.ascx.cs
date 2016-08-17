using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.Course.Category
{
    public partial class ListUC : System.Web.UI.UserControl
    {
        public event EventHandler<DataEventArgs> NameClicked ;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int CategoryId
        {
            get { return Convert.ToInt32(this.hidCategoryId.Value); }
            set { this.hidCategoryId.Value = value.ToString(); }
        }

        public string CategoryName
        {
            get { return this.lblName.Text; }
            set { this.lblName.Text = value; }
        }

        public void Select()
        {
            pnlName.BackColor=Color.LightBlue;
                //.CssClass = "selected";
        }

        public void Deselect()
        {
            pnlName.BackColor= Color.White;
        }

        public void SetNameAndIdOfCategory(int id, string name)
        {
            this.hidCategoryId.Value = id.ToString();
            this.lblName.Text = name;
        }

        public void AddSubCategories(ListUC uc)
        {
            this.pnlSubCategories.Controls.Add(uc);
        }

        protected void lblName_Click(object sender, EventArgs e)
        {
            if (NameClicked != null)
            {

                NameClicked(this,new DataEventArgs()
                {
                    Id = Convert.ToInt32(hidCategoryId.Value)
                    ,Name=lblName.Text
                });
                Select();
            }
        }
    }
}