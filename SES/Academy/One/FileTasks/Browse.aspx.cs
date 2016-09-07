using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel.Files;

namespace One.FileTasks
{
    public partial class Browse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = new List<Academic.ViewModel.Files.ImageListingViewModel>();
                string url = "~/Content/NoticeFiles/";
                var files = Directory.GetFiles(Server.MapPath(url));
                foreach (var file in files)
                {
                    var name = Path.GetFileName(file);

                    list.Add(new ImageListingViewModel()
                    {
                        Name = name
                        ,
                        Url = url + name
                    });
                }
                lstImages.DataSource = list;
                lstImages.DataBind();
            }
        }

        protected void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lstImages_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

        protected void lstImages_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {

        }

        protected void btnOkay_Click(object sender, EventArgs e)
        {
            //lstImages.SelectedValue
        }
    }
}