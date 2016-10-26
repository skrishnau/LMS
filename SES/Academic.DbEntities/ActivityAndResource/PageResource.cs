using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class PageResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PageContent { get; set; }
        public string Description { get; set; }

        public bool DisplayDescriptionOnPage { get; set; }

        //public int RestrictionId { get; set; }
        //public virtual DbEntities.AccessPermission.Restriction Restriction { get; set; }

        //appearance


        public bool DisplayPageName { get; set; }
        public bool DisplayPageDescription { get; set; }

    }
}
