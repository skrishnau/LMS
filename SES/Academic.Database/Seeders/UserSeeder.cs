using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Database.Seeders
{
    public class UserSeeder
    {
        private AcademicContext _context;

        public UserSeeder(AcademicContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            var gender = _context.Gender.First(x => x.Name == "Rather not say");
            var school = _context.School.First(x => x.Code == SchoolSeeder.NEC_CODE);
            var adminRole = _context.Role.First(x => x.RoleName == RoleSeeder.ADMIN_ROLE_NAME);
            var managerRole = _context.Role.First(x => x.RoleName == RoleSeeder.MANAGER_ROLE_NAME);
            var teacherRole = _context.Role.First(x => x.RoleName == RoleSeeder.TEACHER_ROLE_NAME);
            var studentRole = _context.Role.First(x => x.RoleName == RoleSeeder.STUDENT_ROLE_NAME);
            // var school = _context.School.FirstOrDefault(x => x.Code == SchoolSeeder.NEC_CODE);

            var users = new DbEntities.User.Users[]
            {

                new DbEntities.User.Users()
                {
                    UserName = "manager",
                    Password = "password",
                    FirstName = "Manager",
                    MiddleName = "",
                    LastName = "",
                    SchoolId = school?.Id,//null,
                    GenderId = gender.Id,
                    Email = "",
                    DOB = null,
                    IsActive = true,
                    IsDeleted = false,
                    Description = "",
                    CreatedDate = DateTime.Now,
                    Country = "Nepal",
                    EmailDisplay = "",
                    Phone = "",
                    City = "",
                    SecurityQuestion = "",
                    SecurityAnswer = "",
                    UserRoles = new List<DbEntities.User.UserRole>
                    {
                        new DbEntities.User.UserRole{AssignedDate = DateTime.Now, RoleId = managerRole.Id},
                        new DbEntities.User.UserRole{AssignedDate = DateTime.Now, RoleId = adminRole.Id},
                    },
                    UserImageId = null,
                    LastOnline = null,
                },

                 new DbEntities.User.Users()
                {
                    UserName = "teacher",
                    Password = "password",
                    FirstName = "Teacher",
                    MiddleName = "",
                    LastName = "",
                    SchoolId = school?.Id,//null,
                    GenderId = gender.Id,
                    Email = "",
                    DOB = null,
                    IsActive = true,
                    IsDeleted = false,
                    Description = "",
                    CreatedDate = DateTime.Now,
                    Country = "Nepal",
                    EmailDisplay = "",
                    Phone = "",
                    City = "",
                    SecurityQuestion = "",
                    SecurityAnswer = "",
                    UserRoles = new List<DbEntities.User.UserRole>
                    {
                        new DbEntities.User.UserRole{AssignedDate = DateTime.Now, RoleId = teacherRole.Id},
                    },
                    UserImageId = null,
                    LastOnline = null,
                },

                  new DbEntities.User.Users()
                {
                    UserName = "student",
                    Password = "password",
                    FirstName = "Student",
                    MiddleName = "",
                    LastName = "",
                    SchoolId = school?.Id,//null,
                    GenderId = gender.Id,
                    Email = "",
                    DOB = null,
                    IsActive = true,
                    IsDeleted = false,
                    Description = "",
                    CreatedDate = DateTime.Now,
                    Country = "Nepal",
                    EmailDisplay = "",
                    Phone = "",
                    City = "",
                    SecurityQuestion = "",
                    SecurityAnswer = "",
                    UserRoles = new List<DbEntities.User.UserRole>
                    {
                        new DbEntities.User.UserRole{AssignedDate = DateTime.Now, RoleId = studentRole.Id},
                    },
                    UserImageId = null,
                    LastOnline = null,
                },
            };

            _context.Users.AddOrUpdate(
                p => p.UserName,
                users
            );
            _context.SaveChanges();

        }

    }
}
