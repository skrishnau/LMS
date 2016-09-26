using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.ActivityResource.FileResource
{
    public partial class FileResourceCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //FilesDisplay1.FileChoosen += FilesDisplay1_FileChoosen;
            if (!IsPostBack)
            {
                var guid = Guid.NewGuid();
                hidPageKey.Value = guid.ToString();
                FilesDisplay1.PageKey = guid.ToString();
            }
            AsyncFileUpload1.Style.Add("visibility", " hidden");
        }



        public string PageKey
        {
            get { return hidPageKey.Value; }
        }

        //keep it for now
        protected void file_upload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
           
        }

    }
}