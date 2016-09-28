using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Structure.All.UserControls.CourseLinkage
{
    public partial class EachSelectedCourseUC : System.Web.UI.UserControl
    {
        public event EventHandler<SubjectEventArgs> RemoveClicked;
        public event EventHandler<SubjectEventArgs> UndoRemoveClicked;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set { hidSubjectId.Value = value.ToString(); }
        }
        public int SubjectStructureId
        {
            get { return Convert.ToInt32(hidSubjectStructureId.Value); }
            set { hidSubjectStructureId.Value = value.ToString(); }
        }

        public void SetName(int id, string name, int subStructureId=0)
        {
            hidSubjectId.Value = id.ToString();
            divEachSelectedCourse.ID = divEachSelectedCourse.ID + id;
            lblSubjectName.Text = name;
            hidSubjectStructureId.Value = subStructureId.ToString();
        }

        public void SetUndoDeleteImage()
        {
            this.imgbtn.ImageUrl = "~/Content/Icons/delete/undo_delete.png";
            imgbtn.Visible = true;
            btnRemove.Visible = false;
        }

        public void ClearUndoDeleteImage()
        {
            this.imgbtn.Visible = false;
            btnRemove.Visible = true;
        }

        protected void btnRemove_Click(object sender, ImageClickEventArgs e)
        {
            if (RemoveClicked != null)
            {
                if (ID.Contains("save"))
                {
                    imgbtn.Visible = true;
                    lblSubjectName.BackColor = Color.LightSlateGray;
                    btnRemove.Visible = false;
                }
                RemoveClicked(this, new SubjectEventArgs()
                {
                    Id = SubjectId
                    ,
                    Name = lblSubjectName.Text
                });
            }
        }

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            lblSubjectName.BackColor = Color.AliceBlue;
            ClearUndoDeleteImage();
            if (UndoRemoveClicked != null)
            {
                UndoRemoveClicked(this, new SubjectEventArgs()
                {
                    Id = SubjectId
                    ,
                    Name = lblSubjectName.Text
                    ,Checked = false
                });
            }
        }
    }
}