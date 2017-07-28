using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Views.ActivityResource.FileResource
{
    public partial class FileResourceView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //var SubId=19&arId=2&secId=2&edit=1
                var subId = Request.QueryString["SubId"];
                var arId = Request.QueryString["arId"];
                var secId = Request.QueryString["secId"];
                var edit = Request.QueryString["edit"];
                try
                {
                    if (arId != null)
                    {
                        #region File Resource

                        FileResourceId = Convert.ToInt32(arId);

                        using (var helper = new DbHelper.ActAndRes())
                        {

                            var fileRes = helper.GetFileResource(FileResourceId);
                            if (fileRes != null)
                            {
                                lblHeading.Text = fileRes.Name;
                                lblTitle.Text = fileRes.Name;
                                var file = helper.GetFileOfFileResource(fileRes.MainFileId ?? 0);
                                if (file != null)
                                {
                                    var fullPath = file.SubFile.FileDirectory + file.SubFile.FileName;
                                    if (fullPath == "")
                                    {
                                        pnlError.Visible = true;
                                    }
                                    pnlError.Visible = true;
                                    //ProcessRequest(Context, fullPath);
                                    switch (fileRes.Display)
                                    {
                                        case 0:
                                            frame.Src = fullPath;
                                            break;
                                        case 1: //embed//iframe
                                            frame.Src = fullPath;
                                            break;
                                        case 2: //force donload
                                            ProcessRequest(Context, fullPath);
                                            break;
                                        case 3: //open//only file in same window

                                            break;
                                        case 4: //popup
                                            if (subId != null && edit != null && secId != null)
                                            {
                                                OpenWindow(fullPath);
                                                Response.Redirect(
                                                    "~/Views/Course/Section/Master/CourseSectionListing.aspx" +
                                                    "?SubId" + subId + "&edit=" + edit);
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    pnlError.Visible = true;                                    
                                }
                            }
                            else
                            {
                                pnlError.Visible = true;                                
                            }
                        }

                        #endregion
                    }
                    
                }
                catch { }

            }
        }

        public int FileResourceId
        {
            get { return Convert.ToInt32(hidFileResourceId.Value); }
            set { hidFileResourceId.Value = value.ToString(); }
        }

        public void ProcessRequest(HttpContext context, string path)
        {
            var fileName = Path.GetFileName(path);
            var r = context.Response;
            r.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
            r.ContentType = "text/plain";
            r.WriteFile(context.Server.MapPath(path));
            Response.End();
        }
        public bool IsReusable { get { return false; } }



        protected void OpenWindow(string path)
        {
            var url = @Server.MapPath(path);
            //string url = "Popup.aspx";
            string s = "window.open('" + @url + "', 'popup_window', 'width=500,height=300,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

    }
}