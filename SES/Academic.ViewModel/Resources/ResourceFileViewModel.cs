using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.Resources
{
    public class ResourceFileViewModel:IFileViewModel
    {

        public System.Web.HttpPostedFileBase File { get; set; }
      
    }
}
