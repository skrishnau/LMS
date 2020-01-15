using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Database.Seeders
{
    public class GenderSeeder
    {
        private AcademicContext _context;
        public GenderSeeder(AcademicContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            var genders = new DbEntities.User.Gender[]
            {
                new DbEntities.User.Gender{Name = "Male"},
                new DbEntities.User.Gender{Name = "Female"},
                new DbEntities.User.Gender{Name = "Rather not say"},
            };
            _context.Gender.AddOrUpdate(
                p=>p.Name,
                genders
                );
            _context.SaveChanges();
        }
    }
}
