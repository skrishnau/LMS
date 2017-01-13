using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Configuration.Mapping;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using System.Transactions;
using System.Web.UI.WebControls;
using Academic.Database;
using Academic.DbEntities.AcacemicPlacements;
//using Academic.DbEntities.Activities;
using Academic.DbEntities.User;
using Academic.ViewModel.AcademicPlacement;
//using One.Values;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class AcademicPlacement : IDisposable
        {
            private AcademicContext Context;

            public AcademicPlacement()
            {
                Context = new AcademicContext();
            }


            //----------------START------------------//
            #region Running Classes Functions

            //Used ::: by latest--> after github
            public bool AddOrUpdateRunningClass(List<DbEntities.AcacemicPlacements.RunningClass> rcList)
            {
                try
                {
                    var date = DateTime.Now;
                    using (var helper = new DbHelper.Student())
                    using (var roleHelper = new DbHelper.User())
                    using (var scope = new TransactionScope())
                    {
                        var role = roleHelper.GetRole("student");
                        if (role == null)
                        {
                            role = Context.Role.Add(new Role()
                            {
                                DisplayName = "Student"
                                ,
                                RoleName = "student"
                            });
                            Context.SaveChanges();
                        }


                        //each running class
                        foreach (var rc in rcList)
                        {
                            var ent = Context.RunningClass.Find(rc.Id);
                            if (ent == null)
                            {
                                #region if(ent==null)

                                var savedRC = Context.RunningClass.Add(rc);
                                Context.SaveChanges();

                                //add subjects in subjectClass 
                                var subStrList = Context.SubjectStructure
                                    .Where(x => x.YearId == savedRC.YearId
                                        && x.SubYearId == savedRC.SubYearId
                                        && !(x.Obsolete ?? false) && !(x.Void ?? false)).ToList();
                                subStrList.ForEach(subS =>
                                {
                                    var subjectClass = new DbEntities.Class.SubjectClass()
                                    {
                                        //CreatedBy = User.Id
                                        CreatedDate = date.Date
                                        ,
                                        //CreatedTime = date.Hour + ":" + date.Minute + ":" + date.Second
                                        //,
                                        IsRegular = true
                                        ,
                                        RunningClassId = savedRC.Id
                                        ,
                                        SubjectStructureId = subS.Id
                                        ,
                                        //UseDefaultGrouping = true
                                    };
                                    var savedSubjectClass = Context.SubjectClass.Add(subjectClass);
                                    Context.SaveChanges();

                                    //add students to userClass
                                    if ((rc.ProgramBatchId ?? 0) != 0)
                                    {
                                        var stds = helper.ListStudentBatchesOfProgramBatch(rc.ProgramBatchId ?? 0);

                                        foreach (var std in stds.Select(x => x.Student.User))
                                        {
                                            var uc = new DbEntities.Class.UserClass()
                                            {
                                                CreatedDate = DateTime.Now
                                                ,
                                                EnrollmentDuration = 0
                                                ,
                                                RoleId = role.Id
                                                ,
                                                SubjectClassId = savedSubjectClass.Id
                                                ,
                                                UserId = std.Id
                                            };
                                            Context.UserClass.Add(uc);
                                            Context.SaveChanges();
                                        }

                                    }
                                    //end

                                });


                                #endregion

                            }
                            else
                            {
                                //first update userclass (students)
                                //incase if programBatchId changes then all the users in that programBatch
                                //must be deleted
                                if (ent.ProgramBatchId != rc.ProgramBatchId)
                                {
                                    var ucs = Context.SubjectClass.Where(x => x.RunningClassId == ent.Id)
                                        .Select(x => x.ClassUsers);
                                    foreach (var uc in ucs)
                                    {
                                        foreach (var u in uc)
                                        {
                                            Context.UserClass.Remove(u);
                                            Context.SaveChanges();
                                        }
                                    }
                                }
                                //end




                                ent.ProgramBatchId = rc.ProgramBatchId;
                                ent.Void = rc.Void;
                                ent.Completed = rc.Completed;
                                ent.IsActive = rc.IsActive;
                                Context.SaveChanges();

                                //if subjectStructure has been voided then when updating RunningClass
                                //we should check those voided and also void the consecutive subjectclass
                                //and then we have to add those subjectStructure (remaining i.e. new )
                                //in the subject class
                                //update the subjectclass list (i.e. Subjects already saved ) for this running class
                                var lst = Context.SubjectClass.Where(x => x.RunningClassId == ent.Id
                                                                          && !(x.Void ?? false)
                                                                          && x.IsRegular);

                                var voidedSubjectClassList = new List<int>();
                                foreach (var sc in lst)
                                {
                                    if (sc.SubjectStructure.Void ?? false)
                                    {
                                        sc.Void = true;
                                        Context.SaveChanges();
                                        voidedSubjectClassList.Add(sc.Id);
                                    }
                                    if (sc.SubjectStructure.Subject.Void ?? false)
                                    {
                                        sc.Void = true;
                                        Context.SaveChanges();
                                        voidedSubjectClassList.Add(sc.Id);
                                    }
                                }



                                var remainSubStrList = lst.Where(x => !voidedSubjectClassList.Contains(x.Id))
                                    .Select(s => s.SubjectStructure.Id).ToList();
                                //add remaining subjects in subjectClass 
                                var subStrList = Context.SubjectStructure
                                    .Where(x => x.YearId == ent.YearId
                                        && x.SubYearId == ent.SubYearId
                                        && !(x.Obsolete ?? false) && !(x.Void ?? false)
                                        && !remainSubStrList.Contains(x.Id)
                                        ).ToList();
                                subStrList.ForEach(subS =>
                                {
                                    var subjectClass = new DbEntities.Class.SubjectClass()
                                    {
                                        //CreatedBy = User.Id
                                        CreatedDate = date.Date
                                    ,
                                        //CreatedTime = date.Hour + ":" + date.Minute + ":" + date.Second
                                    //,
                                        IsRegular = true
                                    ,
                                        RunningClassId = ent.Id
                                    ,
                                        SubjectStructureId = subS.Id
                                    ,
                                        //UseDefaultGrouping = true
                                    };
                                    var savedSubjectClass = Context.SubjectClass.Add(subjectClass);
                                    Context.SaveChanges();

                                    //add userClass for this subjectClass
                                    //add all students in this programbatch to the userclass
                                    var curUc = rc;
                                    if ((rc.ProgramBatchId ?? 0) != 0)
                                    {
                                        var stds = helper.ListStudentBatchesOfProgramBatch(curUc.ProgramBatchId ?? 0);

                                        foreach (var std in stds.Select(x => x.Student.User))
                                        {
                                            var uc = new DbEntities.Class.UserClass()
                                            {
                                                CreatedDate = DateTime.Now
                                                ,
                                                EnrollmentDuration = 0
                                                ,
                                                RoleId = role.Id
                                                ,
                                                SubjectClassId = savedSubjectClass.Id
                                                ,
                                                UserId = std.Id
                                            };
                                            Context.UserClass.Add(uc);
                                            Context.SaveChanges();
                                        }

                                    }
                                    //end
                                });
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

            //public bool AddOrUpdateRunningClass(List<DbEntities.AcacemicPlacements.RunningClass> classes)
            //{
            //    try
            //    {
            //        using (var scope = new TransactionScope())
            //        using (var helper = new DbHelper.AcademicYear())
            //        {
            //            var isThisActiveAcademicYearSession =
            //                helper.IsThisActiveAcademicYearSession(classes.First().AcademicYearId,
            //                    classes.First().SessionId);
            //            foreach (var cls in classes)
            //            {
            //                var ent = Context.RunningClass.Find(cls.Id);
            //                if (ent == null)
            //                {
            //                    if (!cls.Void ?? false)
            //                    {
            //                        Context.RunningClass.Add(cls);
            //                        Context.SaveChanges();
            //                        //ent.ProgramBatchId = cls.ProgramBatchId;
            //                        if ((cls.ProgramBatchId ?? 0) != 0)
            //                        {
            //                            var pb = Context.ProgramBatch.Find(cls.ProgramBatchId);
            //                            if (pb != null && isThisActiveAcademicYearSession)
            //                            {
            //                                pb.CurrentYearId = cls.YearId;
            //                                if ((cls.SubYearId ?? 0) != 0)
            //                                    pb.CurrentSubYearId = cls.SubYearId;
            //                                Context.SaveChanges();
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                {

            //                    //ent.AcademicYearId = cls.AcademicYearId;
            //                    //if (cls.SessionId != null)
            //                    //{
            //                    //    ent.SessionId = cls.SessionId;
            //                    //}
            //                    if (cls.Completed != null)
            //                        ent.Completed = cls.Completed;
            //                    if (cls.IsActive != null)
            //                        ent.IsActive = cls.IsActive;
            //                    //ent.ProgramBatchId = cls.ProgramBatchId;
            //                    //yedi check gareko xa bhane
            //                    if (cls.Void != null)
            //                    {
            //                        ent.Void = cls.Void;
            //                        //yedi Void false i.e. uncheck gareko xa bhane(pahile nai check 
            //                        //garera save gareko but aile chai uncheck gareko --Void false hunxa

            //                        //yedi void false xa bhane current year and subyear update garne.
            //                        if (!cls.Void ?? false)
            //                        {
            //                            //student group select gareko xa bhane
            //                            if ((cls.ProgramBatchId ?? 0) != 0)
            //                            {
            //                                ent.ProgramBatchId = cls.ProgramBatchId;
            //                                var pb = Context.ProgramBatch.Find(cls.ProgramBatchId);
            //                                if (pb != null && isThisActiveAcademicYearSession)
            //                                {
            //                                    pb.CurrentYearId = cls.YearId;
            //                                    if ((cls.SubYearId ?? 0) != 0)
            //                                        pb.CurrentSubYearId = cls.SubYearId;
            //                                }
            //                            }
            //                            //student group select gareko xaina bhane.
            //                            else
            //                            {
            //                                //pahile nai save gareko tara aile chai group hatako case;
            //                                //pahile ko group line ra tyo programbatch ma current year, subyear null garne
            //                                ent.ProgramBatchId = null;
            //                                var pb = Context.ProgramBatch.Find(ent.ProgramBatchId);
            //                                if (pb != null && isThisActiveAcademicYearSession)
            //                                {
            //                                    pb.CurrentYearId = null;
            //                                    pb.CurrentSubYearId = null;
            //                                }
            //                            }
            //                        }
            //                        //yedi void true xa bhane... current year subyear null garne.
            //                        else
            //                        {
            //                            ent.ProgramBatchId = null;
            //                            var pb = Context.ProgramBatch.Find(ent.ProgramBatchId);
            //                            if (pb != null && isThisActiveAcademicYearSession)
            //                            {
            //                                pb.CurrentYearId = null;
            //                                pb.CurrentSubYearId = null;
            //                            }
            //                        }
            //                    }


            //                    //if (cls.SubYearId != null)
            //                    //    ent.SubYearId = cls.SubYearId;


            //                    //ent.YearId = cls.YearId;

            //                    Context.SaveChanges();
            //                }
            //            }
            //            //Context.SaveChanges();
            //            scope.Complete();
            //            return true;
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        return false;
            //    }
            //    return false;
            //}

            public List<DbEntities.AcacemicPlacements.RunningClass> GetClassesOfAcademicYear
                (int academicYearId, int sessionId = 0)
            {
                List<DbEntities.AcacemicPlacements.RunningClass> list;
                if (sessionId <= 0)
                {
                    list = Context.RunningClass
                        .Where(x => x.AcademicYearId == academicYearId && (x.IsActive ?? true)).ToList();//&& !(x.Void ?? false)
                }
                else //if (sessionId > 0)
                {
                    list = Context.RunningClass
                        .Where(x => x.SessionId == sessionId && (x.IsActive ?? true)).ToList();//&& !(x.Void ?? false)
                }
                return list;
            }


            //public object GetClassStructureInTreeView(int schoolId, int academicYearId, int sessionId = 0)
            //{
            //    //var levels = Context.Level.Include(m => m.Faculty).Where(x => x.SchoolId == schoolId
            //    //                                                              && !(x.Void ?? false));
            //    var runningClasses = GetClassesOfAcademicYear(academicYearId, sessionId);

            //    List<TreeNode> nodeList = new List<TreeNode>();
            //    //levels already occured for this academic year
            //    //var savedLevels = runningClasses.Select(x => x.Year.Program.Faculty.Level.Id);
            //    //var savedFaculties = runningClasses.Select(x => x.Year.Program.Faculty.Id);
            //    var savedPrograms = runningClasses.Select(x => x.Year.Program.Id);
            //    var savedYears = runningClasses.Select(x => x.Year.Id);
            //    var savedsubyears = runningClasses.Select(x => x.SubYear).Where(y => (y.ParentId ?? 0) == 0).Select(m => m.Id);
            //    //var savedPhases = runningClasses.Select(x => x.SubYear).Where(y => (y.ParentId ?? 0) != 0).Select(m => m.Id);
            //    foreach (var program in Context.Program.Where(x => x.SchoolId==schoolId && !(x.Void ?? false)))
            //    {
            //        var progNode = new MyTreeNode(program.Name, program.Id.ToString());
            //        if (savedPrograms.Contains(program.Id))
            //            progNode.Checked = true;
            //        progNode.Type = "program";
            //        facNode.ChildNodes.Add(progNode);


            //        foreach (var year in program.Year.Where(x => !(x.Void ?? false)))
            //        {
            //            var yearNode = new MyTreeNode(year.Name, year.Id.ToString());
            //            if (savedYears.Contains(year.Id))
            //            {
            //                yearNode.Checked = true;
            //                var rcId = runningClasses
            //                    .First(x => x.AcademicYearId == academicYearId
            //                                && (x.SessionId ?? 0) == sessionId
            //                                && (x.IsActive ?? true)
            //                                && !(x.Void ?? false)
            //                                && x.YearId == year.Id
            //                                && (x.SubYearId ?? 0) == 0).Id;
            //                //if (rcId != null)
            //                yearNode.RunningClassId = rcId;
            //            }
            //            yearNode.Type = "year";
            //            progNode.ChildNodes.Add(yearNode);

            //            foreach (var subyear in year.SubYears.Where(x => x.ParentId == null
            //                                                             && !(x.Void ?? false)
            //                                                             ))
            //            {
            //                var subyearNode = new MyTreeNode(subyear.Name, subyear.Id.ToString());
            //                if (savedsubyears.Contains(subyear.Id))
            //                {
            //                    subyearNode.Checked = true;
            //                    var rcId = runningClasses
            //                    .First(x => x.AcademicYearId == academicYearId
            //                                && (x.SessionId ?? 0) == sessionId
            //                                && (x.IsActive ?? true)
            //                                && !(x.Void ?? false)
            //                                && x.YearId == year.Id
            //                                && (x.SubYearId ?? 0) != 0).Id;
            //                    //if (rcId != null)
            //                    subyearNode.RunningClassId = rcId;
            //                }
            //                subyearNode.yearId = year.Id;
            //                subyearNode.Type = "subyear";
            //                yearNode.ChildNodes.Add(subyearNode);

            //                //foreach (var phase in year.SubYears.Where(x => x.ParentId == subyear.Id
            //                //                                               && !(x.Void ?? false) &&
            //                //                                               (x.IsActive ?? true)))
            //                //{
            //                //    var phaseNode = new MyTreeNode(phase.Name, phase.Id.ToString());
            //                //    if (savedPhases.Contains(phase.Id))
            //                //        phaseNode.Checked = true;
            //                //    phaseNode.Type = "phase";
            //                //    subyearNode.ChildNodes.Add(phaseNode);
            //                //}
            //            }
            //        }
            //    }


            //    foreach (var level in levels)
            //    {
            //        var levelNode = new MyTreeNode(level.Name, level.Id.ToString());
            //        if (savedLevels.Contains(level.Id))
            //            levelNode.Checked = true;
            //        levelNode.Type = "level";
            //        levelNode.SelectAction = TreeNodeSelectAction.Select;
            //        levelNode.ExpandAll(); // = true;
            //        nodeList.Add(levelNode);
            //        //treeView.Nodes.Add(levelNode);



            //        foreach (var faculty in level.Faculty.Where(x => !(x.Void ?? false) ))
            //        {
            //            var facNode = new MyTreeNode(faculty.Name, faculty.Id.ToString());
            //            if (savedFaculties.Contains(faculty.Id))
            //                facNode.Checked = true;
            //            facNode.Type = "faculty";
            //            levelNode.ChildNodes.Add(facNode);

                      
            //        }
            //    }
            //    return nodeList;
            //}

            //public object GetClassStructureInTreeView(int schoolId, ref TreeView treeView, int academicYearId, int sessionId = 0)
            //{
            //    var levels = Context.Level.Include(m => m.Faculty).Where(x => x.SchoolId == schoolId
            //                                                                  && !(x.Void ?? false));
            //    var runningClasses = GetClassesOfAcademicYear(academicYearId, sessionId);

            //    List<TreeNode> nodeList = new List<TreeNode>();
            //    //levels already occured for this academic year
            //    var savedLevels = runningClasses.Select(x => x.Year.Program.Faculty.Level.Id);
            //    var savedFaculties = runningClasses.Select(x => x.Year.Program.Faculty.Id);
            //    var savedPrograms = runningClasses.Select(x => x.Year.Program.Id);
            //    var savedYears = runningClasses.Select(x => x.Year.Id);
            //    var savedsubyears = runningClasses.Select(x => x.SubYear).Where(y => (y.ParentId ?? 0) == 0).Select(m => m.Id);
            //    //var savedPhases = runningClasses.Select(x => x.SubYear).Where(y => (y.ParentId ?? 0) != 0).Select(m => m.Id);

            //    foreach (var level in levels)
            //    {
            //        var levelNode = new MyTreeNode(level.Name, level.Id.ToString());
            //        if (savedLevels.Contains(level.Id))
            //            levelNode.Checked = true;
            //        levelNode.Type = "level";
            //        levelNode.SelectAction = TreeNodeSelectAction.Select;
            //        levelNode.ExpandAll(); // = true;
            //        nodeList.Add(levelNode);
            //        treeView.Nodes.Add(levelNode);



            //        foreach (var faculty in level.Faculty.Where(x => !(x.Void ?? false) ))
            //        {
            //            var facNode = new MyTreeNode(faculty.Name, faculty.Id.ToString());
            //            if (savedFaculties.Contains(faculty.Id))
            //                facNode.Checked = true;
            //            facNode.Type = "faculty";
            //            levelNode.ChildNodes.Add(facNode);

            //            foreach (var program in faculty.Programs.Where(x => !(x.Void ?? false) ))
            //            {
            //                var progNode = new MyTreeNode(program.Name, program.Id.ToString());
            //                if (savedPrograms.Contains(program.Id))
            //                    progNode.Checked = true;
            //                progNode.Type = "program";
            //                facNode.ChildNodes.Add(progNode);


            //                foreach (var year in program.Year.Where(x => !(x.Void ?? false) ))
            //                {
            //                    var yearNode = new MyTreeNode(year.Name, year.Id.ToString());
            //                    if (savedYears.Contains(year.Id))
            //                    {
            //                        yearNode.Checked = true;
            //                        var rcId = runningClasses
            //                            .First(x => x.AcademicYearId == academicYearId
            //                                        && (x.SessionId ?? 0) == sessionId
            //                                        && (x.IsActive ?? true)
            //                                        && !(x.Void ?? false)
            //                                        && x.YearId == year.Id
            //                                        && (x.SubYearId ?? 0) == 0).Id;
            //                        //if (rcId != null)
            //                        yearNode.RunningClassId = rcId;
            //                    }
            //                    yearNode.Type = "year";
            //                    progNode.ChildNodes.Add(yearNode);

            //                    foreach (var subyear in year.SubYears.Where(x => x.ParentId == null
            //                                                                     && !(x.Void ?? false) 
            //                                                                     ))
            //                    {
            //                        var subyearNode = new MyTreeNode(subyear.Name, subyear.Id.ToString());
            //                        if (savedsubyears.Contains(subyear.Id))
            //                        {
            //                            subyearNode.Checked = true;
            //                            var rcId = runningClasses
            //                            .First(x => x.AcademicYearId == academicYearId
            //                                        && (x.SessionId ?? 0) == sessionId
            //                                        && (x.IsActive ?? true)
            //                                        && !(x.Void ?? false)
            //                                        && x.YearId == year.Id
            //                                        && (x.SubYearId ?? 0) != 0).Id;
            //                            //if (rcId != null)
            //                            subyearNode.RunningClassId = rcId;
            //                        }
            //                        subyearNode.yearId = year.Id;
            //                        subyearNode.Type = "subyear";
            //                        yearNode.ChildNodes.Add(subyearNode);

            //                        //foreach (var phase in year.SubYears.Where(x => x.ParentId == subyear.Id
            //                        //                                               && !(x.Void ?? false) &&
            //                        //                                               (x.IsActive ?? true)))
            //                        //{
            //                        //    var phaseNode = new MyTreeNode(phase.Name, phase.Id.ToString());
            //                        //    if (savedPhases.Contains(phase.Id))
            //                        //        phaseNode.Checked = true;
            //                        //    phaseNode.Type = "phase";
            //                        //    subyearNode.ChildNodes.Add(phaseNode);
            //                        //}
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    return nodeList;
            //}

            /*     public List<Structure> GetClassStrucuteForMyTreeView(int schoolId, int academicYearId, int sessionId = 0)
                 {
                     var levels = Context.Level.Include(m => m.Faculty).Where(x => x.SchoolId == schoolId
                                                                                   && (x.IsActive ?? true)
                                                                                   && !(x.Void ?? false));
                     var runningClasses = GetClassesOfAcademicYear(academicYearId, sessionId);

                     List<TreeNode> nodeList = new List<TreeNode>();
                     //levels already occured for this academic year
                     var savedLevels = runningClasses.Select(x => x.Year.Program.Faculty.Level.Id);
                     var savedFaculties = runningClasses.Select(x => x.Year.Program.Faculty.Id);
                     var savedPrograms = runningClasses.Select(x => x.Year.Program.Id);
                     var savedYears = runningClasses.Select(x => x.Year.Id);
                     var savedsubyears = runningClasses.Select(x => x.SubYear).Where(y => (y.ParentId ?? 0) == 0).Select(m => m.Id);
                     //var savedPhases = runningClasses.Select(x => x.SubYear).Where(y => (y.ParentId ?? 0) != 0).Select(m => m.Id);

                     foreach (var level in levels)
                     {
                         var levelNode = new MyTreeNode(level.Name, level.Id.ToString());
                         if (savedLevels.Contains(level.Id))
                             levelNode.Checked = true;
                         levelNode.Type = "level";
                         levelNode.SelectAction = TreeNodeSelectAction.Select;
                         levelNode.ExpandAll(); // = true;
                         nodeList.Add(levelNode);
                         //treeView.Nodes.Add(levelNode);



                         foreach (var faculty in level.Faculty.Where(x => !(x.Void ?? false) && (x.IsActive ?? true)))
                         {
                             var facNode = new MyTreeNode(faculty.Name, faculty.Id.ToString());
                             if (savedFaculties.Contains(faculty.Id))
                                 facNode.Checked = true;
                             facNode.Type = "faculty";
                             levelNode.ChildNodes.Add(facNode);

                             foreach (var program in faculty.Programs.Where(x => !(x.Void ?? false) && (x.IsActive ?? true)))
                             {
                                 var progNode = new MyTreeNode(program.Name, program.Id.ToString());
                                 if (savedPrograms.Contains(program.Id))
                                     progNode.Checked = true;
                                 progNode.Type = "program";
                                 facNode.ChildNodes.Add(progNode);


                                 foreach (var year in program.Year.Where(x => !(x.Void ?? false) && (x.IsActive ?? true)))
                                 {
                                     var yearNode = new MyTreeNode(year.Name, year.Id.ToString());
                                     if (savedYears.Contains(year.Id))
                                     {
                                         yearNode.Checked = true;
                                         var rcId = runningClasses
                                             .First(x => x.AcademicYearId == academicYearId
                                                         && (x.SessionId ?? 0) == sessionId
                                                         && (x.IsActive ?? true)
                                                         && !(x.Void ?? false)
                                                         && x.YearId == year.Id
                                                         && (x.SubYearId ?? 0) == 0).Id;
                                         //if (rcId != null)
                                         yearNode.RunningClassId = rcId;
                                     }
                                     yearNode.Type = "year";
                                     progNode.ChildNodes.Add(yearNode);

                                     foreach (var subyear in year.SubYears.Where(x => x.ParentId == null
                                                                                      && !(x.Void ?? false) &&
                                                                                      (x.IsActive ?? true)))
                                     {
                                         var subyearNode = new MyTreeNode(subyear.Name, subyear.Id.ToString());
                                         if (savedsubyears.Contains(subyear.Id))
                                         {
                                             subyearNode.Checked = true;
                                             var rcId = runningClasses
                                             .First(x => x.AcademicYearId == academicYearId
                                                         && (x.SessionId ?? 0) == sessionId
                                                         && (x.IsActive ?? true)
                                                         && !(x.Void ?? false)
                                                         && x.YearId == year.Id
                                                         && (x.SubYearId ?? 0) != 0).Id;
                                             //if (rcId != null)
                                             subyearNode.RunningClassId = rcId;
                                         }
                                         subyearNode.yearId = year.Id;
                                         subyearNode.Type = "subyear";
                                         yearNode.ChildNodes.Add(subyearNode);

                                         //foreach (var phase in year.SubYears.Where(x => x.ParentId == subyear.Id
                                         //                                               && !(x.Void ?? false) &&
                                         //                                               (x.IsActive ?? true)))
                                         //{
                                         //    var phaseNode = new MyTreeNode(phase.Name, phase.Id.ToString());
                                         //    if (savedPhases.Contains(phase.Id))
                                         //        phaseNode.Checked = true;
                                         //    phaseNode.Type = "phase";
                                         //    subyearNode.ChildNodes.Add(phaseNode);
                                         //}
                                     }
                                 }
                             }
                         }
                     }
                     return nodeList;
                 } */

            private MyTreeNode parentNode;
            void CheckForYear(MyTreeNode node)
            {

                if (node.Type == "Year")
                    return;// node;
                MyTreeNode[] array = new MyTreeNode[2];
                try
                {
                    node.ChildNodes.CopyTo(array, 0);
                    if (array.Any())
                    {
                        parentNode = node;
                        CheckForYear(array[0]);
                    }
                    //return;// parentNode;
                }
                catch
                {
                    // return; //;null;
                }
            }

            #endregion
            //------------------END----------------------//


            public void Dispose()
            {
                Context.Dispose();
            }


            /// <summary>
            /// Both for teacher and student
            /// </summary>
            /// <param name="schoolId"></param>
            /// <param name="academicYearId"></param>
            /// <param name="sessionId"></param>
            /// <param name="userId"></param>
            /// <param name="userType">Types: teacher, student</param>
            /// <returns></returns>
            public List<ViewModel.AcademicPlacement.StudentSubjectModel> GetClassesOfUser(int schoolId
                , int academicYearId, int sessionId, int userId, string userType)
            {

                //uncomment this alll
                /*  List<ViewModel.AcademicPlacement.StudentSubjectModel> list = new List<StudentSubjectModel>();

                  if (userType == "student")
                  {
                      var all = from stdc in Context.StudentClass.Where(x => x.StudentId == userId)
                                join runc in Context.RunningClass on stdc.RunningClassId equals runc.Id
                                join subc in Context.SubjectClass on runc.Id equals subc.RunningClassId
                                where runc.AcademicYearId == academicYearId && (runc.SessionId ?? 0) == sessionId
                                select new { stdc, runc, subc };
                      foreach (var a in all)
                      {
                          var subscription =
                              Context.SubjectSubscription.FirstOrDefault(
                                  x => x.StudentClassId == a.stdc.Id && x.SubjectClassId == a.subc.Id);
                          bool subscribed = false;
                          bool permitted = true;
                          //bool notsubscribale = false;
                          bool suspended = false;
                          bool active = false;
                          if (subscription != null)
                          {
                              subscribed = true;
                              permitted = subscription.Permitted ?? true;
                              //notsubscribale = // subscription.NotSubscribale ?? false;
                              suspended = subscription.Suspended ?? false;
                              active = subscription.Active ?? false;
                          }
                          var teachers =
                              Context.TeacherClass.Where(x => x.SubjectClassId == a.subc.Id).Select(y => y.Teacher).ToList();


                          var model = new StudentSubjectModel()
                          {
                              AcademicYearId = academicYearId
                              ,
                              Year = a.runc.Year.Name
                              ,
                              StudentId = userId
                              ,
                              UserClassId = a.stdc.Id
                              ,
                              SubjectClassId = a.subc.Id
                              ,
                              SubjectSubscriptionId = subscription == null ? 0 : subscription.Id
                              ,
                              Subscribed = subscribed
                              ,
                              SubscriptionPermissionRequired = a.subc.SubscriptionPermissionRequired ?? false
                              ,
                              NotSubscribable = a.subc.NotSubscribale ?? false
                              ,
                              Complete = a.runc.Completed ?? false
                              ,
                              SubYear = a.runc.SubYear == null ? "" : a.runc.SubYear.Name
                              ,
                              Permitted = permitted
                              ,
                              SubjectName = a.subc.Subject.Name
                              ,
                              SubjectGroupName = a.subc.SubjectGroup == null ? "" : a.subc.SubjectGroup.Name
                              ,
                              Suspended = suspended
                              ,
                              SubjectId = a.subc.SubjectId
                              ,
                              SubscriptionOptional = a.subc.SubscriptionOptional ?? false
                              ,
                              Void = (a.subc.Void ?? false) || (a.runc.Void ?? false) || (a.stdc.Void ?? false)
                              ,
                              Active = active
                              ,
                              Teachers = teachers
                          };
                          list.Add(model);
                      }
                      return list;
                  }
                  else if (userType == "teacher")
                  {
                      var all = from teac in Context.TeacherClass.Where(x => x.TeacherId == userId)
                                join subc in Context.SubjectClass on teac.SubjectClassId equals subc.Id
                                join runc in Context.RunningClass on subc.RunningClassId equals runc.Id
                                where runc.AcademicYearId == academicYearId && (runc.SessionId ?? 0) == sessionId
                                select new { teac, runc, subc };
                      foreach (var a in all)
                      {
                          //var subscription =
                          //    Context.SubjectSubscription.FirstOrDefault(
                          //        x => x.StudentClassId == a.teac.Id && x.SubjectClassId == a.subc.Id);
                          bool subscribed = false;
                          bool permitted = true;
                          //bool notsubscribale = false;
                          bool suspended = false;
                          bool active = false;
                          //if (subscription != null)
                          //{
                          //    subscribed = true;
                          //    permitted = subscription.Permitted ?? true;
                          //    //notsubscribale = // subscription.NotSubscribale ?? false;
                          //    suspended = subscription.Suspended ?? false;
                          //    active = subscription.Active ?? false;
                          //}
                          var teachers =
                              Context.TeacherClass.Where(x => x.SubjectClassId == a.subc.Id).Select(y => y.Teacher).ToList();


                          var model = new StudentSubjectModel()
                          {
                              AcademicYearId = academicYearId
                              ,
                              Year = a.runc.Year.Name
                              ,
                              StudentId = userId
                              ,
                              UserClassId = a.teac.Id
                              ,
                              SubjectClassId = a.subc.Id
                                  //,
                                  //SubjectSubscriptionId = subscription == null ? 0 : subscription.Id
                              ,
                              Subscribed = subscribed
                              ,
                              SubscriptionPermissionRequired = a.subc.SubscriptionPermissionRequired ?? false
                              ,
                              NotSubscribable = a.subc.NotSubscribale ?? false
                              ,
                              Complete = a.runc.Completed ?? false
                              ,
                              SubYear = a.runc.SubYear == null ? "" : a.runc.SubYear.Name
                              ,
                              Permitted = permitted
                              ,
                              SubjectName = a.subc.Subject.Name
                              ,
                              SubjectGroupName = a.subc.SubjectGroup == null ? "" : a.subc.SubjectGroup.Name
                              ,
                              Suspended = suspended
                              ,
                              SubjectId = a.subc.SubjectId
                              ,
                              SubscriptionOptional = a.subc.SubscriptionOptional ?? false
                              ,
                              Void = (a.subc.Void ?? false) || (a.runc.Void ?? false) || (a.teac.Void ?? false)
                              ,
                              Active = a.teac.IsActive ?? false
                              ,
                              Teachers = teachers
                          };
                          list.Add(model);
                      }
                      return list;
                  }*/
                return new List<StudentSubjectModel>() { new StudentSubjectModel() { } };
            }




            //public bool Subscribe(SubjectSubscription subsc)
            //{
            //    try
            //    {
            //        Context.SubjectSubscription.Add(subsc);
            //        Context.SaveChanges();
            //        return true;
            //    }
            //    catch (Exception)
            //    {
            //        return false;
            //    }
            //}

            //public bool WithdrawFromCourse(int id)
            //{
            //    try
            //    {
            //        var ent = Context.SubjectSubscription.Find(id);
            //        if (ent != null)
            //        {
            //            ent.Active = false;
            //            Context.SaveChanges();
            //            return true;
            //        }
            //        return false;
            //    }
            //    catch (Exception)
            //    {
            //        return false;
            //    }
            //}

            //public List<DbEntities.Students.StudentGroup> GetStudentGroupListStudying(int academicYearId, int sessionId = 0, int programId = 0)
            //{
            //    var grp = (from r in Context.RunningClass
            //               join s in Context.StudentClass on r.Id equals s.RunningClassId
            //               where r.AcademicYearId == academicYearId
            //                     && (r.SessionId ?? 0) == sessionId
            //               select s.StudentGroup).Distinct().ToList(); //new {s.StudentGroup, r})
            //    return grp;
            //}

            public List<DbEntities.Batches.ProgramBatch> GetProgramBatchListStudying(int academicYearId, int sessionId = 0, int programId = 0)
            {
                var grp = (from r in Context.RunningClass
                           where r.AcademicYearId == academicYearId
                                 && (r.SessionId ?? 0) == sessionId
                           select r.ProgramBatch).Distinct().ToList(); //new {s.StudentGroup, r})
                return grp;
            }

            public List<DbEntities.Batches.ProgramBatch> GetActiveProgramBatchListInAcademicYear(int academicYearId, int sessionId = 0, int programId = 0)
            {
                var grp = (from r in Context.RunningClass
                           where r.AcademicYearId == academicYearId
                                 && (r.SessionId ?? 0) == sessionId
                           select r.ProgramBatch).Distinct().ToList(); //new {s.StudentGroup, r})
                return grp;
            }

            //public List<DbEntities.Students.StudentGroup> GetStudentGroupStudyingInYearOrSubYearInAcademicYear
            //    (int academicYearId, int yearId, int sessionId = 0, int subYearId = 0)
            //{
            //    var running = (from r in Context.RunningClass
            //                   join s in Context.StudentClass on r.Id equals s.RunningClassId
            //                   where r.AcademicYearId == academicYearId
            //                         && r.YearId == yearId
            //                         && (r.SubYearId ?? 0) == subYearId
            //                         && (r.SessionId ?? 0) == sessionId
            //                   select s.StudentGroup).ToList();
            //    ;
            //    return running;
            //}

            //works
            //public List<DbEntities.Students.StudentGroup> GetActiveStudentGroupForAProgram
            // (int academicYearId, int programId, int sessionId = 0)
            //{
            //    var running = (from r in Context.RunningClass
            //                   join s in Context.StudentClass on r.Id equals s.RunningClassId
            //                   where r.AcademicYearId == academicYearId
            //                         && r.Year.ProgramId == programId
            //                       //&& (r.SubYearId ?? 0) == subYearId
            //                         && (r.SessionId ?? 0) == sessionId
            //                   select s.StudentGroup).ToList();
            //    ;
            //    return running;
            //}

            public DbEntities.Structure.SubYear GetEarlierSubYear(int yearId, int subyearId = 0)
            {
                if (subyearId > 0)
                {
                    var subyear = Context.SubYear.Find(subyearId);
                    if (subyear != null)
                    {
                        var min = subyear.Year.SubYears.Where(x =>  !(x.Void ?? false)
                                                                && x.Position < subyear.Position)
                            .OrderByDescending(x => x.Position);
                        var mn = min.First();
                        if (mn != null)
                        {
                            return mn;
                        }
                        else
                        {

                            var prevyear = subyear.Year.Program.Year.Where(x =>  !(x.Void ?? false)
                                                               && x.Position < subyear.Year.Position)
                                                               .OrderByDescending(x => x.Position);
                            var minYear = prevyear.First();
                            if (minYear != null)
                            {
                                var maxSubYear = minYear.SubYears.Where(x => !(x.Void ?? false))
                                    .OrderByDescending(x => x.Position).First();
                                if (maxSubYear != null)
                                {
                                    return maxSubYear;
                                }

                            }
                        }
                    }

                }
                return null;
            }

            //need to work out on this
            //public object GetEarlierYearSubYear(int yearId, int subyearId=0)
            //{
            //    if (subyearId > 0)
            //    {
            //        var subyear = Context.SubYear.Find(subyearId);
            //        if (subyear != null)
            //        {
            //            var min = subyear.Year.SubYears.Where(x => (x.IsActive ?? true)
            //                                                    && !(x.Void ?? false)
            //                                                    && x.Position < subyear.Position)
            //                .OrderByDescending(x => x.Position);
            //            var mn = min.First();
            //            if (mn != null)
            //            {
            //                return mn;
            //            }
            //            else
            //            {

            //                var prevyear = subyear.Year.Program.Year.Where(x => (x.IsActive ?? true) && !(x.Void ?? false)
            //                                                   && x.Position < subyear.Year.Position)
            //                                                   .OrderByDescending(x => x.Position);
            //                var minYear = prevyear.First();
            //                if (minYear != null)
            //                {
            //                    var maxSubYear = minYear.SubYears.Where(x => (x.IsActive ?? true)
            //                                                                 && !(x.Void ?? false))
            //                        .OrderByDescending(x => x.Position).First();
            //                    if (maxSubYear != null)
            //                    {
            //                        return maxSubYear;
            //                    }

            //                }
            //                return minYear;
            //            }
            //        }

            //    }
            //    else
            //    {
            //        var year = Context.Year.Find(yearId);
            //        if (year != null)
            //        {
            //            var min = year.Program.Year.Where(x => (x.IsActive ?? true) && !(x.Void ?? false)
            //                                                   && x.Position < year.Position)
            //                                                   .OrderByDescending(x=>x.Position);
            //            var mn = min.First();
            //            if (mn != null)
            //            {
            //                return mn;
            //            }
            //        }
            //    }
            //    return null;
            //}

            //public List<DbEntities.Students.StudentGroup> GetStudentGroup(
            //    int presentAcademicYearId)
            //{

            //}



            public Academic.DbEntities.Batches.ProgramBatch GetProgramBatchInAcademicYear
               (int academicYearId, int yearId, int sessionId = 0, int subYearId = 0)
            {
                var pb = (from r in Context.RunningClass
                          // join s in Context.StudentClass on r.Id equals s.RunningClassId
                          where r.AcademicYearId == academicYearId
                                && r.YearId == yearId
                                && (r.SubYearId ?? 0) == subYearId
                                && (r.SessionId ?? 0) == sessionId
                          select r.ProgramBatch).ToList();
                return pb.FirstOrDefault();
            }

            //Used --> after github
            public Academic.DbEntities.AcacemicPlacements.RunningClass GetRunningClassInAcademicYear
             (int academicYearId, int yearId, int sessionId = 0, int subYearId = 0)
            {
                var rc = (from r in Context.RunningClass
                          // join s in Context.StudentClass on r.Id equals s.RunningClassId
                          where r.AcademicYearId == academicYearId
                                && r.YearId == yearId
                                && (r.SubYearId ?? 0) == subYearId
                                && (r.SessionId ?? 0) == sessionId
                          select r).OrderByDescending(o => o.ProgramBatchId).FirstOrDefault();
                return rc;
            }

            //used
            public List<RunningClass> ListRunningRunningClasses(int academicYearId, int sessionId)
            {
                var rc = Context.RunningClass.Where(x =>
                    x.AcademicYearId == academicYearId && (x.SessionId ?? 0) == sessionId
                    && !(x.Void ?? false)
                    && (x.ProgramBatchId ?? 0) > 0
                    ).ToList();
                return rc;
            }

            //used -- after github
            public List<RunningClass> ListRunningClasses(int academicYearId, int sessionId)
            {
                var rc = Context.RunningClass.Where(x =>
                    x.AcademicYearId == academicYearId && (x.SessionId ?? 0) == sessionId
                    //&& !(x.Void ?? false)
                    //&& (x.ProgramBatchId ?? 0) > 0
                    ).ToList();
                return rc;
            }

            public List<RunningClass>[] GetCompleteAndIncompleteRunningClass(int programbatchId)
            {
                var rc = Context.RunningClass.Where(x => x.ProgramBatchId == programbatchId && !(x.Void ?? false)).ToList();
                var completelist = new List<RunningClass>();
                var notcompletelist = new List<RunningClass>();
                foreach (var r in rc)
                {
                    if (r.Completed ?? false)
                        completelist.Add(r);
                    else
                        notcompletelist.Add(r);
                }
                for(var i=0;i<notcompletelist.Count;i++)
                //foreach (var r in notcompletelist)
                {
                    var r = notcompletelist[i];
                    var incompletelist = r.SubjectClasses.Where(x => (x.SessionComplete ==false || x.SessionComplete==null) && !(x.Void??false))
                        .ToList();
                    if (!incompletelist.Any())
                    {
                        completelist.Add(r);
                        notcompletelist.RemoveAt(i);
                        i--;
                    }
                    // Context.SubjectClass.Where(x => x.RunningClassId == r.Id && !(x.Void??false));
                }

                return  new List<RunningClass>[]{completelist,notcompletelist};
                //var rcs = Context.RunningClass.Where(x =>
                //           (x.AcademicYear.Completed ?? false)
                //           && x.ProgramBatchId == stdbatch.ProgramBatchId
                //           && !(x.Void ?? false) && !(stdbatch.ProgramBatch.Void ?? false));

            }
        }




    }
}
