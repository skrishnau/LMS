using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Database.Seeders
{
    public class SchoolSeeder
    {
        public static readonly string NEC_CODE = "nec";

        private AcademicContext _context;
        public SchoolSeeder(AcademicContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            // SchoolType seeder
            var schoolTypes = new DbEntities.Office.SchoolType[]
            {
               new DbEntities.Office.SchoolType{Name = "Graduate"},
               new DbEntities.Office.SchoolType{Name = "Undergraduate"},
               new DbEntities.Office.SchoolType{Name = "Higher Secondary"},
               new DbEntities.Office.SchoolType{Name = "Secondary"},
            };
            _context.SchoolType.AddOrUpdate(
                p => p.Name,
                schoolTypes
                );
            _context.SaveChanges();

            // School Seeder
            var underGradSchoolType = _context.SchoolType.FirstOrDefault(x => x.Name == "Undergraduate");
            var schools = new DbEntities.Office.School[]
            {
                new DbEntities.Office.School{
                    Name = "Nepal Engineering College",
                    Code = SchoolSeeder.NEC_CODE,
                    Address = "Changunarayan, Bhaktapur, Nepal",
                    IsActive = true,
                    IsDeleted = false,
                    PhoneAfterHours = "",
                    PhoneMain = "",
                    SchoolTypeId = underGradSchoolType.Id,
                    UserId = null,
                    Website = "http://nec.edu.np",
                    CreatedDate = DateTime.Now,
                    Description = "",
                    EmailGeneral = "",
                    EmailMarketing = "",
                    EmailSupport = "",
                    ImageId = 0}
            };
            _context.School.AddOrUpdate(
                p => p.Name,
                schools
                );
            _context.SaveChanges();
        }
    }
}
