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
        //public event EventHandler<BatchEventArgs> CheckedChange;

        protected void Page_Load(object sender, EventArgs e)
        {

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
            get { return chkBox.Checked; }
            set { chkBox.Checked = value; }
        }

        public void SetName(int structureId, string structureName, int programBatchId)
        {

            chkBox.Text = " "+structureName;
            hidStructureId.Value = structureId.ToString();
            hidProgramBatchId.Value = programBatchId.ToString();

        }

        //public void SetName( int structureId, string structureName
        //   , int programBatchId, List<int> treeLinkImages, int noOfPaddingsInLeft)
        //{

        //    chkBox.Text = structureName;
        //    hidStructureId.Value = structureId.ToString();
        //    //hidStructureType.Value = structureType;
        //    hidProgramBatchId.Value = programBatchId.ToString();

        //    if (treeLinkImages != null)
        //    {
        //        foreach (var i in treeLinkImages)
        //        {
        //            if (i == 0)
        //            {
        //                PlaceHolder1.Controls.Add(new Label() { Width = 50 });
        //            }
        //            else
        //            {
        //                PlaceHolder1.Controls.Add(new Label() { Width = 32 });
        //                PlaceHolder1.Controls.Add(new Image()
        //                {
        //                    Width = 18,
        //                    ImageUrl = DbHelper.StaticValues.TreeLinkImage[i]
        //                });
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (var i = 0; i < noOfPaddingsInLeft; i++)
        //        {
        //            PlaceHolder1.Controls.Add(new Label() { Width = 50 });
        //        }
        //    }

        //    //paddings
        //    //Table t = new Table();
        //    //TableRow row = new TableRow();
        //    //for (int i = 0; i < noOfPaddingInLeft; i++)
        //    //{
        //    //    row.Cells.Add(new TableCell() { Width = 20 });
        //    //}
        //    //Table1.Rows.Add(row);

        //}
    }
}