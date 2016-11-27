using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.Database;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Grade : IDisposable
        {
            private AcademicContext Context;
            public Grade()
            {
                Context = new AcademicContext();
            }

            public DbEntities.Grades.Grade AddOrUpdateGrade(DbEntities.Grades.Grade grade,
                List<DbEntities.Grades.GradeValue> gradeValuesList)
            {
                try
                {

                    using (var scope = new TransactionScope())
                    {
                        var ent = Context.Grade.Find(grade.Id);
                        if (ent == null)
                        {
                            ent = Context.Grade.Add(grade);
                            Context.SaveChanges();
                            if (gradeValuesList != null)
                                for (var i = 0; i < gradeValuesList.Count; i++) // in gradeValuesList)
                                {
                                    gradeValuesList[i].GradeId = ent.Id;
                                    Context.GradeValue.Add(gradeValuesList[i]);
                                    Context.SaveChanges();
                                }
                        }
                        else
                        {
                            ent.Name = grade.Name;
                            ent.Description = grade.Description;
                            ent.GradeValueIsInPercentOrPostition = grade.GradeValueIsInPercentOrPostition;
                            ent.Type = grade.Type;
                            if (grade.Type == "range")
                            {
                                ent.MinimumPassValue = grade.MinimumPassValue;
                                ent.TotalMaxValue = grade.TotalMaxValue;
                                ent.TotalMinValue = grade.TotalMinValue;

                                var lst = Context.GradeValue.Where(x => x.GradeId == ent.Id);
                                foreach (var gv in lst)
                                {
                                    Context.GradeValue.Remove(gv);
                                }
                                Context.SaveChanges();
                            }
                            else
                            {
                                ent.GradeValueIsInPercentOrPostition = grade.GradeValueIsInPercentOrPostition;
                                ent.MinimumPassValue = null;
                                ent.TotalMaxValue = null;
                                ent.TotalMinValue = null;
                                var olderlist = Context.GradeValue.Where(x => x.GradeId == ent.Id).ToList();
                                for (int i = 0; i < olderlist.Count; i++)
                                {
                                    Context.GradeValue.Remove(olderlist[i]);
                                }
                                Context.SaveChanges();
                                if (gradeValuesList != null)
                                {
                                    foreach (var gv in gradeValuesList)
                                    {
                                        Context.GradeValue.Add(gv);
                                    }
                                    Context.SaveChanges();
                                }
                            }
                            Context.SaveChanges();
                        }
                        scope.Complete();
                        return ent;
                    }
                }
                catch
                {
                    return null;
                }
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public List<DbEntities.Grades.Grade> ListGrades(int schoolId)
            {
                return Context.Grade.Where(x => (x.SchoolId ?? 0) == schoolId || (x.SchoolId ?? 0) == 0)
                    .OrderBy(x=>x.Name)
                    .ToList();
            }

            public DbEntities.Grades.Grade GetGrade(int gradeTypeId)
            {
                return Context.Grade.Find(gradeTypeId);
            }

            public List<DbEntities.Grades.GradeValue> ListGradeValues(int gradeTypeId)
            {
                return Context.GradeValue.Where(x => x.GradeId == gradeTypeId)
                    .OrderByDescending(x=>x.EquivalentPercentOrPostition)
                    .ToList();
            }
        }
    }
}
