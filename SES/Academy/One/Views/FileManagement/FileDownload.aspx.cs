using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.FileManagement
{
    public partial class FileDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var fId = Request.QueryString["fId"];
                var fileId = Convert.ToInt32(fId);

                using (var helper = new DbHelper.WorkingWithFiles())
                {
                    var file = helper.GetFile(fileId);
                    if (file != null && file.FileType != "Folder")
                    {
                        Response.ContentType = file.FileType;//"application/octet-stream";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.FileName);
                        //, "attachment; filename=logfile.txt");
                        Response.TransmitFile(Server.MapPath(file.FileDirectory + file.FileName)); //"~/logfile.txt"));
                        Response.End();
                    }
                    Response.End();
                }
            }
        }
    }
}