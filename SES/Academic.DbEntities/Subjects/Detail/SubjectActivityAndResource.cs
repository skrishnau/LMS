using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Subjects.Detail
{
    public class SubjectActivityAndResource
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public bool ShowDesctiptionOnPage { get; set; }

        public bool? Void { get; set; }
        public string Type { get; set; }

        public int SubjectSectionId { get; set; }

        public virtual SubjectSection SubjectSection { get; set; }


    }
}
