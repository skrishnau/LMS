using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.Notices
{
    public class Notice
    {
        public int Id { get; set; }
        public string Headiing { get; set; }
        public string Description { get; set; }

        public int CreatedById { get; set; }
        public virtual User.Users CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// It means that this notice is to be viewed only by those listed in NoticeTo table
        /// </summary>
        public bool? ViewerLimited { get; set; }

        public bool? Void { get; set; }
    }
}
