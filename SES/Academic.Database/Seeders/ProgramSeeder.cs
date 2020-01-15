using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Database.Seeders
{
    public class ProgramSeeder
    {
        public const string COMPUTER_PROGRAM_NAME = "Computer";
        private AcademicContext _context;
        public ProgramSeeder(AcademicContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            var school = _context.School.First(x => x.Code == SchoolSeeder.NEC_CODE);
            var managerRole = _context.Role.First(x => x.RoleName == RoleSeeder.MANAGER_ROLE_NAME);
            var manager = _context.Users.First(x => x.UserRoles.Any(y => y.RoleId == managerRole.Id));
            var programmingInCSubject = _context.Subject.First(x => x.Code == CourseSeeder.PROGRAMMING_IN_C_CODE);

            var programs = new DbEntities.Structure.Program[]
            {
                new DbEntities.Structure.Program{
                    Name = COMPUTER_PROGRAM_NAME,
                    SchoolId = school.Id,
                    Description = "",
                    CreatedDate = DateTime.Now,
                    Year = new List<DbEntities.Structure.Year>
                    {
                        new DbEntities.Structure.Year{
                            Name = "Year 1",
                            Description = "",
                            CreatedDate = DateTime.Now,
                            Position = 1,
                           // SubjectStructures = new List<DbEntities.Subjects.SubjectStructure>(),
                            SubYears = new List<DbEntities.Structure.SubYear>
                            {
                                new DbEntities.Structure.SubYear{
                                    Position = 1,
                                    Name = "Sem I",
                                    Description = "", CreatedDate = DateTime.Now,
                                },
                                new DbEntities.Structure.SubYear{Position = 2, Name = "Sem II", Description = "", CreatedDate = DateTime.Now,},
                            },
                        },
                        new DbEntities.Structure.Year{
                            Name = "Year 2",
                            Description = "",
                            CreatedDate = DateTime.Now,
                            Position = 2,
                           // SubjectStructures = new List<DbEntities.Subjects.SubjectStructure>(),
                            SubYears = new List<DbEntities.Structure.SubYear>
                            {
                                new DbEntities.Structure.SubYear{Position = 1, Name = "Sem III", Description = "", CreatedDate = DateTime.Now,},
                                new DbEntities.Structure.SubYear{Position = 2, Name = "Sem IV", Description = "", CreatedDate = DateTime.Now,},
                            }
                        },
                        new DbEntities.Structure.Year{
                            Name = "Year 3",
                            Description = "",
                            CreatedDate = DateTime.Now,
                            Position = 3,
                           // SubjectStructures = new List<DbEntities.Subjects.SubjectStructure>(),
                            SubYears = new List<DbEntities.Structure.SubYear>
                            {
                                new DbEntities.Structure.SubYear{Position = 1, Name = "Sem V", Description = "", CreatedDate = DateTime.Now,},
                                new DbEntities.Structure.SubYear{Position = 2, Name = "Sem VI", Description = "", CreatedDate = DateTime.Now,},
                            }
                        },
                        new DbEntities.Structure.Year{
                            Name = "Year 4",
                            Description = "",
                            CreatedDate = DateTime.Now,
                            Position = 4,
                          //  SubjectStructures = new List<DbEntities.Subjects.SubjectStructure>(),
                            SubYears = new List<DbEntities.Structure.SubYear>
                            {
                                new DbEntities.Structure.SubYear{Position = 1, Name = "Sem VII", Description = "", CreatedDate = DateTime.Now,},
                                new DbEntities.Structure.SubYear{Position = 2, Name = "Sem VIII", Description = "", CreatedDate = DateTime.Now,},
                            }
                        },

                    }
                },
            };
            _context.Program.AddOrUpdate(
                prop => prop.Name,
                programs
             );
            _context.SaveChanges();

            // subject Structure
            /*
            SubjectStructures = new List<DbEntities.Subjects.SubjectStructure>
                                    {
                                        new DbEntities.Subjects.SubjectStructure{ Year =  SubjectId = programmingInCSubject.Id, Credit = 3, CreatedDate = DateTime.Now, IsElective = false, CreatedBy = manager.Id}
                                    },
                                    */

        }
    }
}
