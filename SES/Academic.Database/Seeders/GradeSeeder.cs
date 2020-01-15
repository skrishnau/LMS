using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace Academic.Database.Seeders
{
    public class GradeSeeder
    {
        private AcademicContext _context;
        public GradeSeeder(AcademicContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            // Grade seed
            var grades = new DbEntities.Grades.Grade[]
            {
                new DbEntities.Grades.Grade{Name = "Range", Description = "", GradeValueIsInPercentOrPostition = false,TotalMaxValue = 100, TotalMinValue = 0, MinimumPassValue = 40, SchoolId = null, RangeOrValue = false, Void = null, },
                new DbEntities.Grades.Grade{Name = "Letter Grading", Description = "", GradeValueIsInPercentOrPostition = false,TotalMaxValue = 100, TotalMinValue = 0, MinimumPassValue = 40, SchoolId = null, RangeOrValue = true, Void = null,
                GradeValues = new List<DbEntities.Grades.GradeValue>{
                    new DbEntities.Grades.GradeValue{Value = "F", IsFailGrade = false, EquivalentPercentOrPostition = 0, Void = null, },
                    new DbEntities.Grades.GradeValue{Value = "C-", IsFailGrade = false, EquivalentPercentOrPostition = 2.7f, Void = null, },
                    new DbEntities.Grades.GradeValue{Value = "C", IsFailGrade = false, EquivalentPercentOrPostition = 2f, Void = null, },
                    new DbEntities.Grades.GradeValue{Value = "C+", IsFailGrade = false, EquivalentPercentOrPostition = 2.3f, Void = null, },
                    new DbEntities.Grades.GradeValue{Value = "B-", IsFailGrade = false, EquivalentPercentOrPostition = 2.7f, Void = null, },
                    new DbEntities.Grades.GradeValue{Value = "B", IsFailGrade = false, EquivalentPercentOrPostition = 3, Void = null, },
                    new DbEntities.Grades.GradeValue{Value = "B+", IsFailGrade = false, EquivalentPercentOrPostition = 3.3f, Void = null, },
                    new DbEntities.Grades.GradeValue{Value = "A-", IsFailGrade = false, EquivalentPercentOrPostition = 3.7f, Void = null, },
                    new DbEntities.Grades.GradeValue{Value = "A", IsFailGrade = false, EquivalentPercentOrPostition = 4, Void = null, },
                    //new DbEntities.Grades.GradeValue{Value = "A+", IsFailGrade = false, EquivalentPercentOrPostition = 0, Void = null, },
                    }
                },
            };
            _context.Grade.AddOrUpdate(
                p => p.Name,
                grades
             );
            _context.SaveChanges();

        }
    }
}
