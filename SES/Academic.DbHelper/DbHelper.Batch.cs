using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.SessionState;
using Academic.Database;
using Academic.DbEntities.Batches;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Batch : IDisposable
        {
            AcademicContext Context;

            public Batch()
            {
                Context = new AcademicContext();
            }


            //-------------------------------------- GET -------------------------//
            #region Get functions --> i.e. all the functions that return single object

            public DbEntities.Batches.Batch GetBatch(int batchId)
            {
                var batch = Context.Batch.Find(batchId);
                if (batch == null)
                {
                    batch = new DbEntities.Batches.Batch()
                    {
                        Id = 0
                        ,
                        Name = ""
                    };
                }
                return batch;
            }

            public ProgramBatch GetProgramBatch(int programBatchId)
            {
                return Context.ProgramBatch.Find(programBatchId);
            }

            public string GetImageUrl(int imageId)
            {
                //if (imageId != null)
                {
                    var id = Convert.ToInt32(imageId.ToString());
                    using (var helper = new DbHelper.WorkingWithFiles())
                    {
                        return helper.GetImageUrl(id);
                    }
                }
            }

            public string GetLastOnline(DateTime? onlineDate)
            {
                if (onlineDate != null)
                {
                    try
                    {
                        var date = Convert.ToDateTime(onlineDate.ToString());
                        var difference = DateTime.Now.Subtract(date);// - date;

                        var days = (difference.Days > 0) ?
                            (difference.Days == 1) ? "a Day " : difference.Days + " Days " : "";
                        if (days != "")
                        {
                            return days + "ago";
                        }

                        var hours = (difference.Hours != 0) ? (difference
                            .Hours == 1) ? "an Hour " : difference.Hours + " Hours " : "";
                        if (hours != "")
                        {
                            return hours + "ago";
                        }
                        var minutes = (difference.Minutes > 0) ?
                            (difference.Minutes == 1) ? "a Minute " : difference.Minutes + " Minutes " : "";
                        if (minutes != "")
                            return minutes;

                        var seconds = (difference.Seconds <= 5) ?
                            "5 Seconds " : difference.Seconds + " Seconds ";
                        return seconds + "ago";
                    }
                    catch
                    {

                        return "Never Online";
                    }

                }
                return "Never Online";
            }

            #endregion


            //---------------------------List ----------------------------//
            #region List functions i.e which return List of objects

            public List<DbEntities.Batches.ProgramBatch> GetProgramBatchList(int batchId)
            {
                var programs = Context.ProgramBatch.Include(i => i.Batch).Include(i => i.Program)
                    .Where(x => x.BatchId == batchId && !(x.Void ?? false)) // && !(x.Void ?? false)
                    .ToList();
                return programs;
            }

            public List<DbEntities.Structure.Program> GetProgramsListOfBatch(int batchId)
            {
                var programs = Context.ProgramBatch.Include(i => i.Batch).Include(i => i.Program)
                    .Where(x => x.BatchId == batchId && !(x.Void ?? false))
                    .Select(y => y.Program)
                    .Distinct().ToList();
                return programs;
            }

            public List<Academic.DbEntities.Batches.Batch> GetBatchList(int schoolId)
            {
                return Context.Batch.Include(i => i.ProgramBatches).Where(x => x.SchoolId == schoolId)
                    .OrderByDescending(y => y.ClassCommenceDate ?? y.CreatedDate).ToList();
            }

            public List<Academic.DbEntities.Batches.Batch> GetBatchList(int schoolId, int numberOfItems, int pageNo)
            {
                return Context.Batch.Include(i => i.ProgramBatches).Where(x => x.SchoolId == schoolId)
                    .OrderByDescending(y => y.ClassCommenceDate ?? y.CreatedDate).Skip(pageNo * numberOfItems)
                    .Take(numberOfItems).ToList();
            }

            public List<ProgramBatch> GetNewProgramBatchList(int programId)
            {
                return Context.ProgramBatch.Where(x => x.ProgramId == programId
                    && !(x.StartedStudying ?? false) && !(x.Void ?? false)).ToList();
            }

            public List<DbEntities.Students.Student> GetStudentsOfProgramBatch(int programBatchId)
            {
                var stdas = Context.StudentBatch.Include(i => i.Student).Include(i => i.Student.User)
                    .Where(x => x.ProgramBatchId == programBatchId)
                    .Select(s => s.Student).Include(i => i.User).Where(m => !(m.Void ?? false)).ToList();
                return stdas;
            }

         
            public List<DbEntities.User.Users> GetStudentsOfProgramBatch_AsUser(int programBatchId)
            {
                var stdas = Context.StudentBatch.Include(i => i.Student).Include(i => i.Student.User)
                    .Where(x => x.ProgramBatchId == programBatchId)
                    .Select(s => s.Student.User).Where(m => !(m.IsDeleted ?? false)).ToList();//Include(i => i.User).
                return stdas;
            }

            //used
            public List<ViewModel.Student.StudentViewModelWithAllParam> ListStudentsOfProgramBatch(int programBatchId)
            {
                var list = new List<ViewModel.Student.StudentViewModelWithAllParam>();
                var stdList = Context.StudentBatch.Include(i => i.Student).Include(i => i.Student.User)
                    .Where(x => x.ProgramBatchId == programBatchId)
                    .Select(x => x.Student).ToList();
                stdList.ForEach(s =>
                {
                    var std = new ViewModel.Student.StudentViewModelWithAllParam()
                    {
                        UserId = s.UserId
                        ,
                        Name = s.Name
                        ,
                        UserName = s.User.UserName
                        ,
                        ImageUrl = GetImageUrl(s.User.UserImageId ?? 0)
                        ,
                        LastOnline = GetLastOnline(s.User.LastOnline)
                        ,
                        Email = s.User.Email
                        ,
                        Phone = s.User.Phone
                        ,
                        CRN = s.CRN
                    };
                    list.Add(std);
                });
                return list;
            }

            //used
            public List<ViewModel.Batch.BatchViewModel> ListUnAssignedBatches(int programId
                , int academicYearId, int sessionId = 0, int batchId = 0)
            {
                //-------------------Compare the commented code ----------------------

                //var rc = Context.RunningClass.Where(x =>
                //    x.AcademicYearId == academicYearId
                //    && (x.SessionId ?? 0) == sessionId
                //    && x.ProgramBatch.ProgramId == programId).Select(x => x.ProgramBatch.BatchId).ToList();
                //var pbatch = Context.ProgramBatch.Where(x =>
                //    x.ProgramId == programId && !(rc.Contains(x.BatchId)))
                //    .ToList();

                //var rc = Context.RunningClass.Where(x =>
                //    x.AcademicYearId == academicYearId
                //    && (x.SessionId ?? 0) == sessionId
                //    && x.ProgramBatch.ProgramId == programId).Select(x => x.ProgramBatch.BatchId).ToList();
                var pbatch = Context.ProgramBatch.Where(x =>
                    x.ProgramId == programId)
                    .ToList();
                var rt = from pb in pbatch
                         select new ViewModel.Batch.BatchViewModel()
                         {
                             BatchId = pb.BatchId
                             ,
                             BatchName = pb.Batch.Name
                             ,
                             ProgramId = pb.ProgramId
                             ,
                             ProgramName = pb.Program.Name
                             ,
                             ProgramBatchId = pb.Id
                             ,
                             ProgramBatchName = pb.NameFromBatch

                         };
                return rt.ToList();

                //return pbatch.Select(x=>x.Batch)
                //    .OrderByDescending(y => y.ClassCommenceDate ?? y.CreatedDate)
                //    .ToList();

                //var rc = Context.RunningClass.Where(x=>x.AcademicYearId==academicYearId
                //    && (x.SessionId??0)==sessionId
                //    &&!(x.Void??false)
                //    &&x.)

                //var pb = Context.ProgramBatch.Where(x => x.ProgramId == programId);
                //var rc = Context.RunningClass.Where(x=>pb.Contains(x.ProgramBatch));
                //Context.RunningClass.Where(x=>x.ProgramBatch.BatchId)
            }

            //used



            #endregion


            //----------------------Add or update- --------------------------//
            #region Add or Update functions

            public Academic.DbEntities.Batches.Batch AddOrUpdateBatch(DbEntities.Batches.Batch batch
                , List<Academic.ViewModel.Batch.BatchViewModel> progBatchList)
            {
                using (var scope = new TransactionScope())
                {
                    var ent = Context.Batch.Find(batch.Id);
                    if (ent == null)
                    {
                        ent = Context.Batch.Add(batch);
                        Context.SaveChanges();
                        //return ent;
                    }

                    //update
                    ent.Name = batch.Name;
                    ent.Description = batch.Description;
                    Context.SaveChanges();

                    //save programbatches
                    var list = new List<Academic.DbEntities.Batches.ProgramBatch>();
                    if (progBatchList != null)
                    {
                        foreach (var bvm in progBatchList)
                        {
                            var found = Context.ProgramBatch.Find(bvm.ProgramBatchId);
                            if (found == null)
                            {
                                Context.ProgramBatch.Add(new ProgramBatch()
                                {
                                    ProgramId = bvm.ProgramId
                                    ,
                                    BatchId = ent.Id

                                });
                                Context.SaveChanges();
                            }
                            else
                            {
                                found.Void = !bvm.Check;
                                Context.SaveChanges();


                            }
                        }
                    }

                    scope.Complete();
                    return ent;
                }

            }


            public bool AddOrUpdateProgramBatch(int schoolId, List<DbEntities.Batches.ProgramBatch> programBatches)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        var date = DateTime.Now;
                        foreach (var programBatch in programBatches)
                        {

                            var pbEnt = Context.ProgramBatch.Find(programBatch.Id);
                            if (pbEnt == null) //add
                            {
                                var pb = Context.ProgramBatch.Add(programBatch);
                                Context.SaveChanges();

                                //update studentGroup table so as to store information of programBatch
                                var stdgrp = new Academic.DbEntities.Students.StudentGroup()
                                {
                                    CreatedDate = date
                                    ,
                                    IsActive = true
                                    ,
                                    Void = programBatch.Void
                                    ,
                                    IsFromBatch = true
                                    ,
                                    ProgramBatchId = pb.Id
                                    ,
                                    SchoolId = schoolId
                                };

                                Context.StudentGroup.Add(stdgrp);
                                Context.SaveChanges();
                            }
                            else //update
                            {
                                pbEnt.Void = programBatch.Void;
                                Context.SaveChanges();

                                var stdGrp = Context.StudentGroup.FirstOrDefault(x => (x.ProgramBatchId ?? 0) == pbEnt.Id);
                                if (stdGrp != null)
                                {
                                    stdGrp.Void = programBatch.Void;
                                    Context.SaveChanges();
                                }

                            }
                        }
                        scope.Complete();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }


            #endregion



            public void Dispose()
            {
                Context.Dispose();
            }








            //public List<ProgramBatch> GetActiveStudentGroupForAProgram(int academicYearId,int sessionId,int programId)// int yearId,  int subYearId
            //{
            //    var p = from aca in Context.AcademicYear 
            //            join ra in Context.RunningClass on aca.Id equals ra.AcademicYearId
            //            join pb in  Context.ProgramBatch
            //        join sg in Context.StudentGroup on pb.Id equals sg.ProgramBatchId
            //        where pb.ProgramId == programId
            //        select sg;

            //}





            //public List<Academic.DbEntities.Batches.Batch> GetBatchesOfProgram(int programId)
            //{
            //    return Context.ProgramBatch.Where(x => x.ProgramId == programId)
            //        .Select(x=>x.Batch)
            //        .OrderByDescending(y => y.ClassCommenceDate ?? y.CreatedDate).ToList();
            //}
        }
    }
}
