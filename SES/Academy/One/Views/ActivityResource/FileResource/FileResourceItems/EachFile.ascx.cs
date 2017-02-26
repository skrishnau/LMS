using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.ActivityResource.FileResource.FileResourceItems
{
    public partial class EachFile : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> RemoveClicked;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetData(string iconUrl, string name, int fileId, string localId,bool enabled, string fileUrl)
        {
            img.ImageUrl = iconUrl;
            var wrappedName = (name.Length > 7)?name.Substring(0, 7) + "...": name;

            //if (name.Length > 7)
            //{
            //    wrappedName = name.Substring(0, 7) + "...";
            //}

            lblName.Text = wrappedName;
            hidFileId.Value = fileId.ToString();
            LocalId = localId;
            lnkRemove.Visible = enabled;
            FileUrl = fileUrl;
        }


        public string LocalId
        {
            get { return (hidLocalId.Value); }
            set { hidLocalId.Value = value; }
        }
        public string FileUrl
        {
            get { return (hidFileUrl.Value); }
            set { hidFileUrl.Value = value; }
        }

        public int FileId
        {
            get { return Convert.ToInt32(hidFileId.Value); }
            set { hidFileId.Value = value.ToString(); }
        }

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            if (RemoveClicked != null)
                RemoveClicked(this, new IdAndNameEventArgs()
                {
                    Id = FileId
                    ,RefIdString = LocalId
                });
        }


        protected void lnkImage_OnClick(object sender, EventArgs e)
        {
            var fullPath = FileUrl;//file.SubFile.FileDirectory + file.SubFile.FileName;
            OpenWindow(fullPath);
            //if (subId != null && edit != null && secId != null)
            //{
            //    //Response.Redirect(
            //    //    "~/Views/Course/Section/Master/CourseSectionListing.aspx" +
            //    //    "?SubId" + subId + "&edit=" + edit);
            //}
            //Response.Redirect("~/Views/ActivityResource/FileResource/FileResourceView.aspx");
        }
        protected void OpenWindow(string path)
        {
            var url = @Server.MapPath(path);
            //string url = "Popup.aspx";
            string s = "window.open('" + @url + "', 'popup_window', 'width=500,height=300,left=100,top=100,resizable=yes');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}