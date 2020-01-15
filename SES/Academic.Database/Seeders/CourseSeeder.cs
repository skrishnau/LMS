using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Database.Seeders
{
    public class CourseSeeder
    {
        public const string PROGRAMMING_IN_C_CODE = "CMP-301";
        private AcademicContext _context;
        public CourseSeeder(AcademicContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            var school = _context.School.First(x => x.Code == SchoolSeeder.NEC_CODE);
            var admin = _context.Users.First(x => x.UserRoles.Any(y => y.Role.RoleName == RoleSeeder.ADMIN_ROLE_NAME));

            // Links Resource 
            #region Links Resources Save


            var usefulLinkUrlRes = new DbEntities.ActivityAndResource.UrlResource { Name = "Useful Links", Url = "https://www.google.com/search?source=hp&ei=4ugeXr22MKTdz7sPjveQoAI&q=C+programming&oq=C+programming&gs_l=psy-ab.3...75.1052..1770...0.0..0.0.0.......0....1..gws-wiz.dKDQyd3RRaE&ved=0ahUKEwi9r7qosoXnAhWk7nMBHY47BCQQ4dUDCAY&uact=5", DisplayDescriptionOnPage = false, Display = 0, Description = "", };
            var wikipediaUrlRes = new DbEntities.ActivityAndResource.UrlResource { Name = "Wekipedia", Url = "https://en.wikipedia.org/wiki/C_(programming_language)", DisplayDescriptionOnPage = false, Display = 0, Description = "", };
            var mitUrlRes = new DbEntities.ActivityAndResource.UrlResource { Name = "MIT Course", Url = "https://ocw.mit.edu/courses/electrical-engineering-and-computer-science/6-087-practical-programming-in-c-january-iap-2010/", DisplayDescriptionOnPage = false, Display = 0, Description = "", };
            var projectsUrlRes = new DbEntities.ActivityAndResource.UrlResource { Name = "Projects", Url = "https://ocw.mit.edu/courses/electrical-engineering-and-computer-science/6-087-practical-programming-in-c-january-iap-2010/lecture-notes/", DisplayDescriptionOnPage = false, Display = 0, Description = "", };
            var examplesUrlRes = new DbEntities.ActivityAndResource.UrlResource { Name = "100+ C programming examples", Url = "https://www.studytonight.com/c/programs/", DisplayDescriptionOnPage = true, Display = 0, Description = "100+ C programs with explanation and detailed solution and output for practising and improving your coding skills", };

            _context.UrlResource.AddOrUpdate(
                p=>p.Name,
                usefulLinkUrlRes,
                wikipediaUrlRes,
                mitUrlRes,
                projectsUrlRes,
                examplesUrlRes
                );

            #endregion

            #region Page Resource Save

            var cFunctionsPage = new DbEntities.ActivityAndResource.PageResource { Name = "Function in C", PageContent = "Control flow. Functions and modular programming. Variable scope. Static and global variables.", DisplayPageName = true, DisplayPageDescription = false, DisplayDescriptionOnPage = true, Description = "A function is a block of statements that performs a specific task... ", };
            var loopsPage = new DbEntities.ActivityAndResource.PageResource { Name = "Pointers", PageContent = "Pointers and memory addressing. Arrays and pointer arithmetic. Strings. Searching and sorting algorithms.", DisplayPageName = true, DisplayPageDescription = false, DisplayDescriptionOnPage = true, Description = "For and While loops in C", };
            var recursionPage = new DbEntities.ActivityAndResource.PageResource { Name = "Recursions", PageContent = "", DisplayPageName = true, DisplayPageDescription = false, DisplayDescriptionOnPage = true, Description = "Recursion in C : Fibonacci series", };

            _context.PageResource.AddOrUpdate(
                p=>p.Name,
                cFunctionsPage,
                loopsPage,
                recursionPage);

            #endregion

            #region Book Resource Save

            var beginnersBook = new DbEntities.ActivityAndResource.BookResource
            {
                Name = "Beginners Book",
                ChapterFormatting = 1,
                CustomTitles = false,
                Description = "The expert at anything was once a beginner – Helen Hayes",
                StyleOfNavigation = 0,
                DisplayDescriptionOnCourePage = false,
                Chapters = new List<DbEntities.ActivityAndResource.BookItems.BookChapter>
                {
                    new DbEntities.ActivityAndResource.BookItems.BookChapter{Position = 1, Title = "Turbo C++ Installation", Content = "<strong>Install Turbo C++: Step by Step Guide</strong>",},
                    new DbEntities.ActivityAndResource.BookItems.BookChapter{Position = 2, Title = "First C program", Content = "<strong>C Program Structure – First C Program</strong>",},
                }
            };
            _context.BookResource.AddOrUpdate(p=>p.Name, beginnersBook);
            #endregion

            // save all before
            _context.SaveChanges();

            // Course Categories with all the required course and course resources in one go
            var courseCategories = new Academic.DbEntities.Subjects.SubjectCategory[]
            {
                new DbEntities.Subjects.SubjectCategory{
                    Name = "Computer",
                    Code = "COMP",
                    CreatedDate = DateTime.Now,
                    Description = "",
                    IsActive = true,
                    IsVoid = false,
                    ParentId = null,
                    SchoolId = school.Id,
                    Subjects = new List<DbEntities.Subjects.Subject>
                    {
                        new DbEntities.Subjects.Subject{Code = PROGRAMMING_IN_C_CODE, FullName = "Programming in C", ShortName = "C", Credit = 3, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false,
                            SubjectSections  = new List<DbEntities.Subjects.SubjectSection>
                            {
                                new DbEntities.Subjects.SubjectSection{Name = "Introduction", Position = 1, ShowSummary = true, Summary = GetProgrammingInCSummary(), Void = false},
                                new DbEntities.Subjects.SubjectSection{Name = "Background information", Position = 2, ShowSummary = false, Summary = "", Void = false,
                                    ActivityResources = new List<DbEntities.ActivityAndResource.ActivityResource>
                                    {
                                        new DbEntities.ActivityAndResource.ActivityResource{Name="Useful Links", ActivityResourceId = usefulLinkUrlRes.Id, ActivityOrResource = false, ActivityResourceType = ((int)Enums.Resources.Url)+1, Position = 1, Void = false, },
                                        new DbEntities.ActivityAndResource.ActivityResource{Name="Wikipedia", ActivityResourceId = wikipediaUrlRes.Id, ActivityOrResource = false, ActivityResourceType = ((int)Enums.Resources.Url)+1, Position = 1, Void = false, },
                                        new DbEntities.ActivityAndResource.ActivityResource{Name="MIT Courses", ActivityResourceId = mitUrlRes.Id, ActivityOrResource = false, ActivityResourceType = ((int)Enums.Resources.Url)+1, Position = 1, Void = false, },
                                    }
                                },
                                new DbEntities.Subjects.SubjectSection{Name = "Understanding Basics", Position = 3, ShowSummary = false, Summary = "", Void = false,
                                    ActivityResources = new List<DbEntities.ActivityAndResource.ActivityResource>
                                    {
                                        new DbEntities.ActivityAndResource.ActivityResource{Name="Beginners Book", ActivityResourceId = beginnersBook.Id, ActivityOrResource = false, ActivityResourceType = ((int)Enums.Resources.Book)+1, Position = 1, Void = false, },
                                        new DbEntities.ActivityAndResource.ActivityResource{Name="Functions", ActivityResourceId = cFunctionsPage.Id, ActivityOrResource = false, ActivityResourceType = ((int)Enums.Resources.Page)+1, Position = 2, Void = false, },
                                        new DbEntities.ActivityAndResource.ActivityResource{Name="Pointers", ActivityResourceId = loopsPage.Id, ActivityOrResource = false, ActivityResourceType = ((int)Enums.Resources.Page)+1, Position = 3, Void = false, },
                                        new DbEntities.ActivityAndResource.ActivityResource{Name="Recursion", ActivityResourceId = recursionPage.Id, ActivityOrResource = false, ActivityResourceType = ((int)Enums.Resources.Page)+1, Position = 4, Void = false, },
                                    }
                                },
                                new DbEntities.Subjects.SubjectSection{Name = "Project examples", Position = 3, ShowSummary = false, Summary = "", Void = false,
                                    ActivityResources = new List<DbEntities.ActivityAndResource.ActivityResource>
                                    {
                                        new DbEntities.ActivityAndResource.ActivityResource{Name="C Programming Examples", ActivityResourceId = examplesUrlRes.Id, ActivityOrResource = false, ActivityResourceType = ((int)Enums.Resources.Url)+1, Position = 1, Void = false, },
                                        new DbEntities.ActivityAndResource.ActivityResource{Name="Projects", ActivityResourceId = projectsUrlRes.Id, ActivityOrResource = false, ActivityResourceType = ((int)Enums.Resources.Url)+1, Position = 2, Void = false, },
                                    }
                                },
                            }
                        },
                        //new DbEntities.Subjects.Subject{Code = "CMP-302", FullName = "Object Oriented Programming in C++", ShortName = "C++", Credit = 3, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false},
                        //new DbEntities.Subjects.Subject{Code = "CMP-303", FullName = "Data Structure and Algorithms", ShortName = "DSA", Credit = 3, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false},
                        //new DbEntities.Subjects.Subject{Code = "CMP-306", FullName = "Compiler Design", ShortName = "Compiler", Credit = 2, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false},
                        //new DbEntities.Subjects.Subject{Code = "CMP-307", FullName = "Image Processing and Pattern Recognition", ShortName = "IPPR", Credit = 3, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false},
                        //new DbEntities.Subjects.Subject{Code = "CMP-309", FullName = "Data Mining", ShortName = "DMine", Credit = 1, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false},
                        //new DbEntities.Subjects.Subject{Code = "CMP-310", FullName = "Simulation", ShortName = "SIM", Credit = 3, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false},
                    }
                },
                new DbEntities.Subjects.SubjectCategory{
                    Name = "Electronics",
                    Code = "ELX",
                    CreatedDate = DateTime.Now,
                    Description = "",
                    IsActive = true,
                    IsVoid = false,
                    ParentId = null,
                    SchoolId = school.Id,
                    Subjects = new List<DbEntities.Subjects.Subject>
                    {
                        new DbEntities.Subjects.Subject{Code = "ELX-201", FullName = "Logic Circuits", ShortName = "LC", Credit = 3, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false},
                        //new DbEntities.Subjects.Subject{Code = "ELX-202", FullName = "Microprocessors ", ShortName = "Microprocessors", Credit = 3, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false},
                        //new DbEntities.Subjects.Subject{Code = "ELX-203", FullName = "Microcontrollers and Embeded Systems", ShortName = "Microcontrollers", Credit = 3, CreatedById = admin.Id, CreatedDate = DateTime.Now, Summary = "", Void = false},
                    }
                },

            };
            _context.SubjectCategory.AddOrUpdate(
                p => p.Name,
                courseCategories
                );
            _context.SaveChanges();
        }

        private string GetProgrammingInCSummary()
        {
            return "C (/siː/, as in the letter c) is a general-purpose, procedural computer programming language supporting structured programming, lexical variable scope, and recursion, while a static type system prevents unintended operations. By design, C provides constructs that map efficiently to typical machine instructions and has found lasting use in applications previously coded in assembly language. Such applications include operating systems and various application software for computers, from supercomputers to embedded systems.";
        }
    }
}
