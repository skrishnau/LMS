using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.Database;

namespace One.Course
{
    public partial class Index : System.Web.UI.Page
    {
        Academic.Database.AcademicContext context = new AcademicContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
            
        }

        private void BindGrid()
        {
            var subjects = context.Subject.ToList();
            subjectFV.DataSource = subjects;
            subjectFV.DataBind();
        }

        protected void subjectFV_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            subjectFV.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void subjectFV_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            subjectFV.ChangeMode(e.NewMode);
            BindGrid();
            if (e.NewMode == FormViewMode.Edit)
            {
                subjectFV.AllowPaging = false;
            }
            else
            {
                subjectFV.AllowPaging = true;
            }
        }

        protected void subjectFV_ItemDeleting(object sender, FormViewDeleteEventArgs e)
        {
            var entity = context.Subject.Find(subjectFV.DataKey.Value);
            if(entity!=null)
             context.Subject.Remove(entity);
            BindGrid();
        }

        protected void subjectFV_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            var key = subjectFV.DataKey;

            var txtName =(TextBox)subjectFV.FindControl("txtName");
            var ent = context.Subject.Find(key.Value);
            if(ent!=null)
            {
                ent.FullName = txtName.Text;
            }
            BindGrid();

        }

        
    }
}