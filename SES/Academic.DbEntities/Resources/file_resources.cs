using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Resources
{
    public class file_resources //many to many realation
    {
        public int FileId { get; set; }
        public int ResourcesId { get; set; }
    }
}
