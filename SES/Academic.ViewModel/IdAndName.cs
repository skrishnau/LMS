using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel
{
    public class IdAndName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class IdAndNameEventArgs:EventArgs
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RefIdInt { get; set; }
        public string RefIdString { get; set; }
    }
}
