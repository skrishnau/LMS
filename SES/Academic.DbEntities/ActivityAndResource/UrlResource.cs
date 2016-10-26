using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class UrlResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
        public string Description { get; set; }

        public bool DisplayDescriptionOnPage { get; set; }

        //public int RestrictionId { get; set; }
        //public virtual DbEntities.AccessPermission.Restriction Restriction { get; set; }

        //appearance

        /// <summary>
        /// 0-automatic, 1- embed, 2-open, 3-in popup
        /// </summary>
        public byte Display { get; set; }

        public int PopupWidthInPixel { get; set; }
        public int PopupHeightInPixel { get; set; }


        //url variables
    }
}
