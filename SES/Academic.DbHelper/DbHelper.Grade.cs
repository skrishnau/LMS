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

            public DbEntities.Grades.GradeType AddOrUpdateGrade(DbEntities.Grades.GradeType grade,
                List<DbEntities.Grades.GradeValues> gradeValuesList)
            {
                try
                {

                    using (var scope = new TransactionScope())
                    {
                        var ent = Context.GradeType.Find(grade.Id);
                        if (ent == null)
                        {
                            ent = Context.GradeType.Add(grade);
                            Context.SaveChanges();
                            for (var i = 0; i < gradeValuesList.Count; i++) // in gradeValuesList)
                            {
                                gradeValuesList[i].GradeTypeId = ent.Id;
                                Context.GradeValues.Add(gradeValuesList[i]);
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

                                var lst = Context.GradeValues.Where(x => x.GradeTypeId == ent.Id);
                                foreach (var gv in lst)
                                {
                                    Context.GradeValues.Remove(gv);
                                    Context.SaveChanges();
                                }
                            }
                            else
                            {
                                ent.GradeValueIsInPercentOrPostition = grade.GradeValueIsInPercentOrPostition;
                                ent.MinimumPassValue = null;
                                ent.TotalMaxValue = null;
                                ent.TotalMinValue = null;
                                var olderlist = Context.GradeValues.Where(x => x.GradeTypeId == ent.Id).ToList();
                                for (int i = 0; i < olderlist.Count; i++)
                                {
                                    Context.GradeValues.Remove(olderlist[i]);
                                    Context.SaveChanges();
                                }
                                foreach (var gv in gradeValuesList)
                                {
                                    Context.GradeValues.Add(gv);
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

            public List<DbEntities.Grades.GradeType> ListGrades(int schoolId)
            {
                return Context.GradeType.Where(x => (x.SchoolId ?? 0) == schoolId || (x.SchoolId ?? 0) == 0).ToList();
            }

            public DbEntities.Grades.GradeType GetGrade(int gradeTypeId)
            {
                return Context.GradeType.Find(gradeTypeId);
            }

            public List<DbEntities.Grades.GradeValues> ListGradeValues(int gradeTypeId)
            {
                return Context.GradeValues.Where(x => x.GradeTypeId == gradeTypeId).ToList();
            }
        }
    }
}
