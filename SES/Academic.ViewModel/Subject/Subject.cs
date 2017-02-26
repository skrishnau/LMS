using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.Subject
{
    [Serializable]
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }
        public bool Checked { get; set; }
        public int SubjectStructureId { get; set; }

        public bool IsElective { get; set; }
        public int Credit { get; set; }
    }
}
