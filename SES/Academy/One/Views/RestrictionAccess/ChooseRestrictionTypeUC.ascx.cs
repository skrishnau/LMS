using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.RestrictionAccess
{
    public partial class ChooseRestrictionTypeUC : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> RestrictionChoosen;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var lst = new List<IdAndName>()
                {
                    new IdAndName() {Id = 0, Name = "Activity completion"},
                    new IdAndName() {Id = 1, Name = "Date"},
                    new IdAndName() {Id = 2, Name = "Grade"},
                    new IdAndName() {Id = 3, Name = "Group"},
                    new IdAndName() {Id = 4, Name = "User profile"},
                    new IdAndName() {Id = 5, Name = "Restriction set"},
                };
                dlistRestrictionChoose.DataSource = lst;
                dlistRestrictionChoose.DataBind();
            }
            try
            {
                //dlistRestrictionChoose.ItemCommand -= dlistRestrictionChoose_ItemCommand;
                //dlistRestrictionChoose.ItemCommand += dlistRestrictionChoose_ItemCommand;
            }
            catch { }
        }

        public string RestrictionId
        {
            get { return hidRestrictionId.Value; }
            set { hidRestrictionId.Value = value; }
        }

        protected void dlistRestrictionChoose_ItemCommand(object source, DataListCommandEventArgs e)
        {
            var arg = e.CommandArgument;
            if (arg != null)
            {
                if (RestrictionChoosen != null)
                {
                    var split = arg.ToString().Split(new char[] { ',' });
                    if (split.Count() == 2)
                    {
                        
                        RestrictionChoosen(this, new IdAndNameEventArgs()
                        {
                            Id = Convert.ToInt32(split[0])
                            ,
                            Name = split[1]
                            ,
                            RefIdString = RestrictionId
                        });
                    }

                }
            }
        }
    }
}