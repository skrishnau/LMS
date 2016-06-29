using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.DbEntities.User;

namespace Academic.DbEntities.Office
{
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string PanNo { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Moto { get; set; }
        public string Category { get; set; }//category obtained from government
        public Byte[] Logo { get; set; }
        public string LogoImageType { get; set; }

        public int? UserId { get; set; }
        public virtual Users User { get; set; }
    }
}
