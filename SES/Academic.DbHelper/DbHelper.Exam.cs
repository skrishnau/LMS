using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.Database;
using Academic.DbEntities.Exams;
using Academic.ViewModel;

namespace Academic.DbHelper
{

    public partial class DbHelper
    {
        //All used 

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

            public DbEntities.Exams.Exam AddOrUpdateExam(DbEntities.Exams.Exam exam
                , int userId, List<ExamOfClass> eocList, string titleOfNotice)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        var model = Context.Exam.Find(exam.Id);
                        if (model == null)
                        {
                            model = Context.Exam.Add(exam);
                            Context.SaveChanges();
                        }
                        else
                        {
                            model.Name = exam.Name;
                            model.NoticeContent = exam.NoticeContent;
                            model.ResultDate = exam.ResultDate;
                            model.StartDate = exam.StartDate;
                            model.Weight = exam.Weight;
                            model.ExamTypeId = exam.ExamTypeId;
                            model.UpdatedDate = DateTime.Now;
                            model.ExamCoordinatorId = exam.ExamCoordinatorId;
                            model.PublishNoticeToNoticeBoard = exam.PublishNoticeToNoticeBoard;
                            Context.SaveChanges();
                        }

                        //publishing notice to noticeBoard
                        var notice = Context.Notice.Find(model.NoticeId ?? 0);
                        if (notice == null)
                        {
                            var n = new DbEntities.Notices.Notice()
                            {
                                PublishNoticeToNoticeBoard = model.PublishNoticeToNoticeBoard ?? false
                                ,
                                Content = model.NoticeContent
                                ,
                                CreatedBy = userId
                                ,
                                CreatedDate = DateTime.Now
                                ,
                                NoticePublishTo = true
                                ,SchoolId = model.SchoolId
                            };

                            if (model.PublishNoticeToNoticeBoard ?? false)
                            {
                                n.PublishedDate = DateTime.Now;
                                n.Title = titleOfNotice;
                            }
                            else
                            {
                                n.Title = model.ExamTypeId == null ? model.Name : model.ExamType.Name;
                            }

                            var savedNotice = Context.Notice.Add(n);
                            Context.SaveChanges();

                            model.NoticeId = savedNotice.Id;
                            Context.SaveChanges();

                        }
                        else
                        {
                            if (model.PublishNoticeToNoticeBoard ?? false)
                            {
                                notice.Title = titleOfNotice;
                                if (!notice.PublishNoticeToNoticeBoard)
                                    notice.PublishedDate = DateTime.Now;
                            }
                            else
                            {
                                notice.Title = model.ExamTypeId == null ? model.Name : model.ExamType.Name;
                            }
                            notice.PublishNoticeToNoticeBoard = model.PublishNoticeToNoticeBoard ?? false;

                            notice.Content = model.NoticeContent;
                            notice.UpdatedBy = userId;
                            notice.UpdatedDate = DateTime.Now;
                            notice.NoticePublishTo = true;

                            Context.SaveChanges();
                        }

                        if (eocList != null)//&& userId != null
                        {
                            eocList.ForEach(x =>
                            {
                                x.ExamId = model.Id;
                                var eoc = Context.ExamOfClass.Find(x.Id);
                                if (eoc == null)
                                {
                                    eoc = x; //
                                    // eoc.SettingsUsedFromExam = true;
                                    eoc.CreatedBy = userId;
                                    eoc.CreatedDate = DateTime.Now;

                                    var addedClass = Context.ExamOfClass.Add(eoc);
                                    Context.SaveChanges();

                                    //now add all the subjects //needed only here
                                    //while updating the subjects need not be changed
                                    var subjects = Context.SubjectClass.Where(sc =>
                                        sc.RunningClassId == eoc.RunningClassId
                                        && sc.IsRegular
                                        && !(sc.Void ?? false));
                                    foreach (var sc in subjects)
                                    {
                                        Context.ExamSubject.Add(new ExamSubject()
                                        {
                                            ExamOfClassId = addedClass.Id
                                            ,
                                            SubjectClassId = sc.Id
                                            ,
                                            SettingsUsedFromExam = true
                                            ,
                                        });
                                        Context.SaveChanges();
                                    }
                                }
                                else
                                {
                                    eoc.Void = x.Void;
                                    eoc.UpdatedBy = x.UpdatedBy;
                                    eoc.UpdatedDate = x.UpdatedDate;
                                    //eoc.Weight = x.Weight;
                                    //eoc.SettingsUsedFromExam = x.SettingsUsedFromExam;
                                    //eoc.PassMarks = x.PassMarks;
                                    //eoc.IsPercent = x.IsPercent;
                                    //eoc.FullMarks = x.FullMarks;

                                    Context.SaveChanges();
                                }
                            });
                        }
                        scope.Complete();

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
                    var lst =
                        Context.Exam.Where(x =>
                            x.SchoolId == schoolId
                            && x.AcademicYearId == academicYearId)
                        .OrderByDescending(x => x.Id)
                        .ToList();
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].ExamTypeId != null)
                            lst[i].Name = lst[i].ExamType.Name;
                    }
                    return lst;
                }
                else
                {
                    var lst = Context.Exam.Where(x =>
                         x.SchoolId == schoolId
                         && x.AcademicYearId == academicYearId
                         && x.SessionId == sessionId)
                         .OrderByDescending(x => x.Id)
                         .ToList();
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].ExamTypeId != null)
                            lst[i].Name = lst[i].ExamType.Name;
                    }
                    return lst;
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

            public ExamType GetExamType(int examTypeId)
            {
                return Context.ExamType.Find(examTypeId);
            }

            public ExamOfClass GetExamOfClass(int examOfClassId)
            {
                return Context.ExamOfClass.Find(examOfClassId);
            }

            public ExamOfClass GetExamOfClass(int runningClassId, int examId)
            {
                return Context.ExamOfClass.FirstOrDefault(x => x.RunningClassId == runningClassId
                    && x.ExamId == examId);
            }

            public ExamOfClass GetExamOfClassForRunningClass(int runningClassId)
            {
                return Context.ExamOfClass.FirstOrDefault(x => x.RunningClassId == runningClassId
                    );
            }

            public List<ExamOfClass> ListExamClasses(int examId)
            {
                return Context.ExamOfClass.Where(x => x.ExamId == examId && !(x.Void ?? false)).ToList();
            }

            public void ListExamStudents(int examOfClassId)
            {
                //var fromExamStudent = Context.ExamStudent.Where(x=>x.e)
            }
        }
    }
}
