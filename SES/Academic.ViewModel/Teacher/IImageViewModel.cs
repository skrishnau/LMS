using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Academic.ViewModel.Teachers
{
    public interface  IImageViewModel
    {
        HttpPostedFileBase Image { get; set; }
    }
}
