using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Database.Seeders
{
    public class AcademicYearSeeder
    {
        private AcademicContext _context;
        public AcademicYearSeeder(AcademicContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            var school = _context.School.First(x => x.Code == SchoolSeeder.NEC_CODE);
            var computerProgram = _context.Program.First(x => x.Name == ProgramSeeder.COMPUTER_PROGRAM_NAME);

            var academicYears = new DbEntities.AcademicYear[]
            {
                new DbEntities.AcademicYear
                {
                    StartDate = new DateTime(DateTime.Now.Year, 1, 1),
                    EndDate = new DateTime(DateTime.Now.Year, 12, 31),
                    IsActive = true,
                    Name = DateTime.Now.Year.ToString(),
                    SchoolId = school.Id,
                    Sessions = new List<DbEntities.Session>
                    {
                        new DbEntities.Session{Name = "Fall", StartDate = new DateTime(DateTime.Now.Year, 1,1), Position = 1, EndDate = new DateTime(DateTime.Now.Year, 6, 15)},
                        new DbEntities.Session{Name = "Spring", StartDate = new DateTime(DateTime.Now.Year, 6,16), Position = 1, EndDate = new DateTime(DateTime.Now.Year, 12, 31)},
                    },
                    Batches = new List<Academic.DbEntities.Batches.Batch>
                    {
                        new DbEntities.Batches.Batch
                        {
                            Name = DateTime.Now.Year.ToString().Substring(1),
                            CreatedDate = DateTime.Now,
                            Description = "",
                            SchoolId = school.Id,
                            ProgramBatches = new List<DbEntities.Batches.ProgramBatch>
                            {
                                new DbEntities.Batches.ProgramBatch{ProgramId = computerProgram.Id, }
                            }
                        },
                    },
                    Position = 1,
                }
            };
            _context.AcademicYear.AddOrUpdate(
                p => p.Name,
                academicYears
                );
            _context.SaveChanges();

        }
    }
}
