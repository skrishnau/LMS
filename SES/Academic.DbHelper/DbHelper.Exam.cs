using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.DbEntities.Exams;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Exam : IDisposable
        {
            AcademicContext Context;

            public Exam()
            {
                Context = new AcademicContext();
            }
            public void Dispose()
            {
                Context.Dispose();
            }

            public List<ExamType> GetExamTypeForCombo(int schoolId)
            {
                try
                {
                    var tp = Context.ExamType.Where(x => x.SchoolId == schoolId && !(x.Void ?? false)).ToList();
                    return tp;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            public DbEntities.Exams.Exam AddOrUpdateExam(DbEntities.Exams.Exam exam)
            {
                try
                {
                    var model = Context.Exam.Find(exam.Id);
                    if (model == null)
                    {
                        var ent = Context.Exam.Add(exam);

                        Context.SaveChanges();
                        return ent;
                    }
                    else
                    {
                        model.Name = exam.Name;
                        model.Notice = exam.Notice;
                        model.ResultDate = exam.ResultDate;
                        model.StartDate = exam.StartDate;
                        model.Weight = exam.Weight;
                        model.ExamTypeId = exam.ExamTypeId;
                        model.UpdatedDate = DateTime.Now;
                        model.ExamCoordinatorId = exam.ExamCoordinatorId;

                        Context.SaveChanges();
                        return model;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            public List<DbEntities.Exams.Exam> GetExamList(int schoolId, int academicYearId, int sessionId = 0)
            {
                if (sessionId == 0)
                {
                    return
                        Context.Exam.Where(x => 
                            x.SchoolId == schoolId 
                            && x.AcademicYearId == academicYearId)
                        .OrderByDescending(x => x.Id)                        
                        .ToList();
                }
                else
                {
                    return Context.Exam.Where(x => 
                        x.SchoolId == schoolId 
                        && x.AcademicYearId == academicYearId
                        && x.SessionId == sessionId)
                        .OrderByDescending(x=>x.Id)
                        .ToList();
                }
            }

            //Used
            public DbEntities.Exams.Exam FindExam(int id)
            {
                try
                {
                    return Context.Exam.Include(x => x.AcademicYear).Include(y => y.Session).FirstOrDefault(x => x.Id == id);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            //Used
            public ExamType AddOrUpdateExamType(ExamType eType)
            {
                var ent = Context.ExamType.Find(eType.Id);
                if (ent == null)
                {
                    ent = Context.ExamType.Add(eType);
                }
                else
                {
                    //ent.WeightMarks = eType.WeightMarks;
                    ent.Weight = eType.Weight;
                    ent.IsPercent = eType.IsPercent;
                    ent.Name = eType.Name;
                    ent.Description = eType.Description;
                    ent.Void = eType.Void;
                }
                Context.SaveChanges();
                return ent;
            }

            //used
            public List<ExamType> ListExamTypes(int schoolId)
            {
                return Context.ExamType.Where(x => x.SchoolId == schoolId && !(x.Void ?? false)).ToList();
            }

            //used
            public List<DbEntities.Exams.Exam> ListExams(int schoolId, int academicYearId, int sessionId = 0)
            {
                if (sessionId == 0)
                {
                    return
                        Context.Exam.Where(x =>
                            x.SchoolId == schoolId
                            && x.AcademicYearId == academicYearId
                            && !(x.Void ?? false))
                        .OrderByDescending(o => o.StartDate)
                        .ToList();
                }
                else
                {
                    return
                        Context.Exam
                            .Where(x =>
                                x.SchoolId == schoolId
                                && x.AcademicYearId == academicYearId
                                && x.SessionId == sessionId
                                && !(x.Void ?? false))
                            .OrderByDescending(o => o.StartDate)
                            .ToList();
                }
            }

            public DbEntities.Exams.Exam GetExam(int examId)
            {
                return Context.Exam.Find(examId);
            }
        }
    }
}
