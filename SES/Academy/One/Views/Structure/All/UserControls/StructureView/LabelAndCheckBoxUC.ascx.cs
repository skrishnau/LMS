using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
//using One.Values;

namespace One.Views.Structure.All.UserControls.StructureView
{
    public partial class LabelAndCheckBoxUC : System.Web.UI.UserControl
    {
        public event EventHandler<BatchEventArgs> CheckedChange;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgCheckBox_Click(object sender, ImageClickEventArgs e)
        {
            CheckTheCheckBox();
        }

        public int StructureId
        {
            get { return Convert.ToInt32(hidStructureId.Value); }
            set { this.hidStructureId.Value = value.ToString(); }
        }

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { this.hidProgramBatchId.Value = value.ToString(); }
        }


        public bool Check
        {
            get { return hidIsChecked.Value == "1"; }
            set
            {
                if (value)
                {
                    hidIsChecked.Value = "1";
                    imgCheckBox.ImageUrl = "~/Content/Icons/Check/checked_blue_18x18.png";
                }
                else
                {
                    hidIsChecked.Value = "0";
                    imgCheckBox.ImageUrl = "~/Content/Icons/Check/unchecked_grey_18x18.png";
                }
                hidIsChecked.Value = (value) ? "1" : "0";
                imgCheckBox.ImageUrl = (value) ? "~/Content/Icons/Check/checked_blue_18x18.png" : "~/Content/Icons/Check/unchecked_grey_18x18.png";
            }
        }

        void CheckTheCheckBox()
        {
            if (hidIsChecked.Value == "0")
            {
                //change image url
                hidIsChecked.Value = "1";
                imgCheckBox.ImageUrl = "~/Content/Icons/Check/checked_blue_18x18.png";
                if (CheckedChange != null)
                {
                    CheckedChange(this, new BatchEventArgs() { ProgramId = StructureId, ProgramBatchId = ProgramBatchId, Checked = true });
                }
            }
            else
            {
                //change image url
                hidIsChecked.Value = "0";
                imgCheckBox.ImageUrl = "~/Content/Icons/Check/unchecked_grey_18x18.png";
                if (CheckedChange != null)
                {
                    CheckedChange(this, new BatchEventArgs() { ProgramId = StructureId, ProgramBatchId = ProgramBatchId, Checked = false });
                }
            }
        }

        public void SetName(string structureType, int structureId, string structureName
           , int programBatchId, List<int> treeLinkImages, int noOfPaddingsInLeft)
        {
            lblProgramName.Text = structureName;
            hidStructureId.Value = structureId.ToString();
            hidStructureType.Value = structureType;
            hidProgramBatchId.Value = programBatchId.ToString();

            if (treeLinkImages != null)
            {
                foreach (var i in treeLinkImages)
                {
                    if (i == 0)
                    {
                        PlaceHolder1.Controls.Add(new Label() { Width = 50 });
                    }
                    else
                    {
                        PlaceHolder1.Controls.Add(new Label() { Width = 32 });
                        PlaceHolder1.Controls.Add(new Image()
                        {
                            Width = 18,
                            ImageUrl = DbHelper.StaticValues.TreeLinkImage[i]
                        });
                    }
                }
            }
            else
            {
                for (var i = 0; i < noOfPaddingsInLeft; i++)
                {
                    PlaceHolder1.Controls.Add(new Label() { Width = 50 });
                }
            }

            //paddings
            //Table t = new Table();
            //TableRow row = new TableRow();
            //for (int i = 0; i < noOfPaddingInLeft; i++)
            //{
            //    row.Cells.Add(new TableCell() { Width = 20 });
            //}
            //Table1.Rows.Add(row);

        }
    }
}