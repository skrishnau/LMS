using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

//using Academic.InitialValues;

namespace One.Views.Structure.Level
{
    public partial class Create : System.Web.UI.Page
    {
        //public event EventHandler<MessageEventArgs> SaveClickedEvent;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            if (!IsPostBack)
            {
                try
                {
                    var levelId = Request.QueryString["levId"];
                    if (levelId != null)
                    {
                        LevelId = Convert.ToInt32(levelId);
                        using (var helper = new DbHelper.Structure())
                        {
                            var level = helper.GetLevel(LevelId);
                            if (level != null)
                            {
                                txtName.Text = level.Name;
                                txtDescription.Text = level.Description;
                            }
                        }
                    }
                }
                catch
                {
                    Response.Redirect("~/Views/Structure/All/Master/List.aspx");
                }
            }
        }



        public int LevelId
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }

        //public int SchoolId
        //{
        //    get { return Convert.ToInt32(hidSchoolId.Value); }
        //    set { hidSchoolId.Value = value.ToString(); }
        //}

        public bool CancelButtonVisible
        {
            get { return btnCancel.Visible; }
            set { btnCancel.Visible = value; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                    using (var helper = new DbHelper.Structure())
                    {
                        var level = new Academic.DbEntities.Structure.Level()
                        {
                            Name = txtName.Text
                            ,
                            Description = txtDescription.Text
                            ,
                            Id = this.LevelId
                            ,
                            SchoolId = user.SchoolId
                        };

                        if (LevelId == 0)
                            level.CreatedDate = DateTime.Now;

                        var saved = helper.AddOrUpdateLevel(level);
                        if (saved != null)
                        {
                            Response.Redirect("~/Views/Structure/All/Master/List.aspx?edit=1");
                        }
                        else
                        {
                            lblError.Visible = true;
                        }
                    }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Structure/All/Master/List.aspx?edit=1");
        }
    }
}