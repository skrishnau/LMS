using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Database.Seeders
{
    public class RoleSeeder
    {
        public const string MANAGER_ROLE_NAME = "manager";
        public const string ADMIN_ROLE_NAME = "admin";
        public const string TEACHER_ROLE_NAME = "teacher";
        public const string STUDENT_ROLE_NAME = "student";
        public const string COURSE_EDITOR_ROLE_NAME = "course-editor";
        public const string GUEST_ROLE_NAME = "guest";
        public const string PARENT_ROLE_NAME = "parent";
        public const string NOTIFIER_ROLE_NAME = "notifier";
        public const string ORGANIZER_ROLE_NAME = "organizer";
        public const string ADMITTER_ROLE_NAME = "admitter";

        private AcademicContext _context;
        public RoleSeeder(AcademicContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            var roles = new DbEntities.User.Role[]
            {
                new DbEntities.User.Role { RoleName = ADMIN_ROLE_NAME, DisplayName = "Admin", Description = "", SchoolId = null, Void = null},
                new DbEntities.User.Role { RoleName = MANAGER_ROLE_NAME, DisplayName = "Manager", Description = "", SchoolId = null, Void = null},
                new DbEntities.User.Role { RoleName = TEACHER_ROLE_NAME, DisplayName = "Teacher", Description = "", SchoolId = null, Void = null},
                new DbEntities.User.Role { RoleName = STUDENT_ROLE_NAME, DisplayName = "Student", Description = "", SchoolId = null, Void = null},
                new DbEntities.User.Role { RoleName = COURSE_EDITOR_ROLE_NAME, DisplayName = "Course Editor", Description = "", SchoolId = null, Void = null},
                new DbEntities.User.Role { RoleName = GUEST_ROLE_NAME, DisplayName = "Guest", Description = "", SchoolId = null, Void = null},
                new DbEntities.User.Role { RoleName = PARENT_ROLE_NAME, DisplayName = "Parent", Description = "", SchoolId = null, Void = null},
                new DbEntities.User.Role { RoleName = NOTIFIER_ROLE_NAME, DisplayName = "Notifier", Description = "", SchoolId = null, Void = null},
                new DbEntities.User.Role { RoleName = ORGANIZER_ROLE_NAME, DisplayName = "Organizer", Description = "", SchoolId = null, Void = null},
                new DbEntities.User.Role { RoleName = ADMITTER_ROLE_NAME, DisplayName = "Admitter", Description = "Admitter is one who (can) admits users. Admitter is responsible to insert new students/teachers in the system", SchoolId = null, Void = null},

            };
            _context.Role.AddOrUpdate(
                p => p.RoleName,
                roles
                );
            _context.SaveChanges();

        }
    }
}
