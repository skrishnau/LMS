using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

            public Academic.DbEntities.Batches.Batch AddOrUpdateBatch(DbEntities.Batches.Batch batch)
            {
                var ent = Context.Batch.Find(batch.Id);
                if (ent == null)
                {
                    var added = Context.Batch.Add(batch);
                    Context.SaveChanges();
                    return added;
                }

                //update
                ent.Name = batch.Name;
                ent.Description = batch.Description;
                Context.SaveChanges();
                return ent;

            }



            public void Dispose()
            {
                Context.Dispose();
            }

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


            public List<DbEntities.Batches.ProgramBatch> GetProgramBatchList(int batchId)
            {
                var programs = Context.ProgramBatch.Include(i => i.Batch).Include(i => i.Program)
                    .Where(x => x.BatchId == batchId) // && !(x.Void ?? false)
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

            public List<Academic.DbEntities.Batches.Batch> GetBatchList(int schoolId, int numberOfItems, int pageNo)
            {
                return Context.Batch.Include(i => i.ProgramBatches).Where(x => x.SchoolId == schoolId)
                    .OrderByDescending(y => y.ClassCommenceDate ?? y.CreatedDate).Skip(pageNo * numberOfItems)
                    .Take(numberOfItems).ToList();
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


            //public List<ProgramBatch> GetActiveStudentGroupForAProgram(int academicYearId,int sessionId,int programId)// int yearId,  int subYearId
            //{
            //    var p = from aca in Context.AcademicYear 
            //            join ra in Context.RunningClass on aca.Id equals ra.AcademicYearId
            //            join pb in  Context.ProgramBatch
            //        join sg in Context.StudentGroup on pb.Id equals sg.ProgramBatchId
            //        where pb.ProgramId == programId
            //        select sg;

            //}

            public List<ProgramBatch> GetNewProgramBatchList(int programId)
            {
                return Context.ProgramBatch.Where(x =>x.ProgramId==programId && !(x.StartedStudying ?? false) && !(x.Void ?? false)).ToList();
            }


            public ProgramBatch GetProgramBatch(int programBatchId)
            {
                return Context.ProgramBatch.Find(programBatchId);
            }

            public List<DbEntities.Students.Student> GetStudentsOfProgramBatch(int programBatchId)
            {
                var stdas = Context.StudentBatch.Include(i => i.Student).Include(i=>i.Student.User)
                    .Where(x => x.ProgramBatchId == programBatchId)
                    .Select(s=>s.Student).Include(i=>i.User).Where(m=>!(m.Void??false)).ToList();
                return stdas;
            }
        }
    }
}
