using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.Structure.All.UserControls.StructureView
{
    public partial class LabelOnly : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetName(string structureType,
            int structureId, string structureName
            ,int noOfPaddingsInLeft, List<int> treeLinkImages)
        {
            lblStructureName.Text = structureName;
            hidStructureId.Value = structureId.ToString();
            hidStructureType.Value = structureType;

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
                for (int i = 0; i < noOfPaddingsInLeft; i++)
                {

                    PlaceHolder1.Controls.Add(new Label() { Width = 50 });
                }
            }
        }
    }
}