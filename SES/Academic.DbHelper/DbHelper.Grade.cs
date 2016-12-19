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

            //
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
                            ent.RangeOrValue = grade.RangeOrValue;
                            if (!grade.RangeOrValue)//range
                            {
                                ent.MinimumPassValue = grade.MinimumPassValue;
                                ent.TotalMaxValue = grade.TotalMaxValue;
                                ent.TotalMinValue = grade.TotalMinValue;

                                Context.SaveChanges();
                            }
                            else//values
                            {
                                ent.GradeValueIsInPercentOrPostition = grade.GradeValueIsInPercentOrPostition;
                                ent.MinimumPassValue = grade.MinimumPassValue;
                                ent.TotalMaxValue = grade.TotalMaxValue;
                                ent.TotalMinValue = grade.TotalMinValue;

                                //var olderlist = Context.GradeValue.Where(x => x.GradeId == ent.Id).ToList();

                                //for (int i = 0; i < olderlist.Count; i++)
                                //{
                                //    Context.GradeValue.Remove(olderlist[i]);
                                //}
                                //Context.SaveChanges();

                                if (gradeValuesList != null)
                                {
                                    foreach (var gv in gradeValuesList)
                                    {
                                        var gvDb = Context.GradeValue.Find(gv.Id);
                                        if (gvDb == null)
                                        {
                                            gv.GradeId = ent.Id;
                                            Context.GradeValue.Add(gv);
                                            Context.SaveChanges();
                                        }
                                        else
                                        {
                                            gvDb.Void = gv.Void;
                                            gvDb.Value = gv.Value;
                                            gvDb.EquivalentPercentOrPostition = gv.EquivalentPercentOrPostition;
                                            gvDb.IsFailGrade = gv.IsFailGrade;
                                            Context.SaveChanges();
                                        }
                                    }
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
                return Context.Grade.Where(x => !(x.Void ?? false) && ((x.SchoolId ?? 0) == schoolId || (x.SchoolId ?? 0) == 0))
                    .OrderBy(x => x.Name)
                    .ToList();
            }

            public DbEntities.Grades.Grade GetGrade(int gradeTypeId)
            {
                return Context.Grade.Find(gradeTypeId);
            }

            public List<DbEntities.Grades.GradeValue> ListGradeValues(int gradeTypeId)
            {
                return Context.GradeValue.Where(x => x.GradeId == gradeTypeId && !(x.Void ?? false))
                    .OrderByDescending(x => x.EquivalentPercentOrPostition)
                    .ToList();
            }

            public bool GradeDelete(int gradeId)
            {
                try
                {
                    var grade = Context.Grade.Find(gradeId);
                    if (grade != null)
                    {
                        grade.Void = true;
                        Context.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
