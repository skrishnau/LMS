using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.All_Resusable_Codes.Dialog
{
    public partial class Dialog1 : System.Web.UI.Page
    {
        public event EventHandler<IdAndNameEventArgs> ItemClick;

        public event EventHandler<EventArgs> SaveClick;
        public event EventHandler<IdAndNameEventArgs> OkClick;
        public event EventHandler<IdAndNameEventArgs> CancelClick;


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
                dataList.DataSource = lst;
                dataList.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            dialogdiv.Visible = true;
        }

        public string GetClickMode()
        {
            return hidItemClickMode.Value;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            dialogdiv.Visible = false;
        }

        public void SetValues(string title,List<IdAndName> items,string itemClickMode, params string[] buttons)
        {
            lblHeading.Text = title;

            hidItemClickMode.Value = itemClickMode;

            dataList.DataSource = items;
            dataList.DataBind();

            if (buttons != null)
                if (buttons.Any())
                {
                    foreach (var b in buttons)
                    {
                        switch (b.ToLower())
                        {
                            case "save":
                                btnSave.Visible = true;
                                break;
                            case "ok":
                                btnOk.Visible = true;
                                break;
                            case "cancel":
                                btnCancel.Visible = true;
                                break;
                        }

                    }
                }
                else buttonsDiv.Visible = false;
            else buttonsDiv.Visible = false;
        }

        public void OpenDialog()
        {
            dialogdiv.Visible = true;
        }
        public void CloseDialog()
        {
            dialogdiv.Visible = false;
        }    

        protected void dataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            var arg = e.CommandArgument;
            if (arg != null)
            {
                if (ItemClick != null)
                {
                    var split = arg.ToString().Split(new char[] { ',' });
                    if (split.Count() == 2)
                    {

                        ItemClick(this, new IdAndNameEventArgs()
                        {
                            Id = Convert.ToInt32(split[0])
                            ,
                            Name = split[1]
                            ,
                            //RefIdString = RestrictionId
                        });
                    }

                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            dialogdiv.Visible = false;
        }

    }
}