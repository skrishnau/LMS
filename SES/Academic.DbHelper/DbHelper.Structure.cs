using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Academic.Database;
using Academic.DbEntities.Structure;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Structure : IDisposable
        {
            private AcademicContext Context;

            public Structure()
            {
                Context = new AcademicContext();
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            #region Add or Update Functions

            public DbEntities.Structure.Year AddOrUpdateYear(DbEntities.Structure.Year year)
            {

                try
                {
                    var ent = Context.Year.Find(year.Id);
                    if (ent == null)
                    {
                        var saved = Context.Year.Add(year);
                        Context.SaveChanges();
                        return saved;
                    }
                    else
                    {
                        ent.Name = year.Name;
                        ent.ProgramId = year.ProgramId;
                        ent.Description = year.Description;
                        ent.Position = year.Position;

                        Context.SaveChanges();
                        return ent;
                    }
                }
                catch
                {
                    return null;
                }

            }

            public DbEntities.Structure.SubYear AddOrUpdateSubYear(DbEntities.Structure.SubYear subYear)
            {
                try
                {
                    var ent = Context.SubYear.Find(subYear.Id);
                    if (ent == null)
                    {
                        var saved = Context.SubYear.Add(subYear);
                        Context.SaveChanges();
                        return saved;
                    }

                    else
                    {
                        ent.Name = subYear.Name;
                        ent.YearId = subYear.YearId;
                        ent.Description = subYear.Description;
                        ent.Position = subYear.Position;
                        ent.YearId = subYear.YearId;

                        if (subYear.ParentId != null)
                        {
                            ent.ParentId = subYear.ParentId;
                        }
                        Context.SaveChanges();
                        return ent;
                    }
                }
                catch
                {
                    return null;
                }
            }

            //public DbEntities.Structure.Level AddOrUpdateLevel(DbEntities.Structure.Level level)
            //{
            //    try
            //    {
            //        var ent = Context.Level.Find(level.Id);
            //        if (ent == null)
            //        {
            //            var l = Context.Level.Add(level);
            //            Context.SaveChanges();
            //            return l;
            //        }
            //        else
            //        {
            //            ent.Name = level.Name;
            //            ent.SchoolId = level.SchoolId;
            //            ent.Description = level.Description;

            //            Context.SaveChanges();
            //            return ent;
            //        }
            //    }
            //    catch
            //    {
            //        return null;
            //    }
            //}

            #endregion


            #region List Fucntions

            //public List<TreeNode> ListStructure(int schoolId)
            //{
            //    List<TreeNode> list = new List<TreeNode>();
            //    //TreeNode node = new TreeNode("main", "main");

            //    if (schoolId > 0)
            //    {
            //        GetLevels(schoolId).ForEach(x =>
            //        {
            //            var lnode = new TreeNode(x.Name, x.Id.ToString());
            //            list.Add(lnode);
            //            //node.ChildNodes.Add(lnode);

            //            GetFaculties(x.Id).ForEach(f =>
            //            {
            //                var fnode = new TreeNode(f.Name, f.Id.ToString());
            //                lnode.ChildNodes.Add(fnode);

            //                GetPrograms(f.Id).ForEach(p =>
            //                {
            //                    var pnode = new TreeNode(p.Name, p.Id.ToString());
            //                    fnode.ChildNodes.Add(pnode);

            //                    GetYears(p.Id).ForEach(y =>
            //                    {
            //                        var ynode = new TreeNode(y.Name, y.Id.ToString());
            //                        pnode.ChildNodes.Add(ynode);

            //                        GetSubYears(y.Id).ForEach(s =>
            //                       {
            //                           var snode = new TreeNode(s.Name, s.Id.ToString());
            //                           ynode.ChildNodes.Add(snode);
            //                       });
            //                    });
            //                });
            //            });
            //        });
            //        return list;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}

            #endregion

            #region Get Functions

            //public List<Academic.ViewModel.IdAndName> GetLevels(int schoolId)
            //{
            //    //schoolId = 1;
            //    var s = Context.Level.Where(x => x.SchoolId == schoolId);
            //    if (s != null)
            //    {
            //        var sa = s.Select(x => new ViewModel.IdAndName() { Id = x.Id, Name = x.Name }).ToList();
            //        return sa;
            //    }
            //    return new List<IdAndName>() { new IdAndName() { Name = "", Id = 0 } };
            //}


            //public List<ViewModel.IdAndName> GetFaculties(int levelId)
            //{
            //    return Context.Faculty.Where(x => x.LevelId == levelId)
            //        .Select(x => new IdAndName() { Id = x.Id, Name = x.Name })
            //        .ToList();
            //}

            public List<ViewModel.IdAndName> GetPrograms(int schoolId)
            {
                return
                    Context.Program.Where(x => x.SchoolId == schoolId && !(x.Void??false))
                        .Select(x => new IdAndName() { Id = x.Id, Name = x.Name })
                        .ToList();

            }

            public List<Year> GetYears(int programId)
            {
                return Context.Year.Where(x => x.ProgramId == programId && !(x.Void ?? false)).ToList();
                //.Select(x => new IdAndName() { Id = x.Id, Name = x.Name })
            }

            public List<SubYear> GetSubYears(int yearId, bool onlyTopLevelLoad = false, int? parentId = null)
            {
                if (onlyTopLevelLoad)
                    return Context.SubYear.Where(x => x.YearId == yearId && x.ParentId == null).ToList();
                //.Select(x => new IdAndName() { Id = x.Id, Name = x.Name })
                if (parentId == null)
                    return Context.SubYear.Where(x => x.YearId == yearId && x.ParentId == null).ToList();
                //.Select(x => new IdAndName() { Id = x.Id, Name = x.Name })
                else
                {
                    return Context.SubYear.Where(x => x.ParentId == parentId).ToList();
                    //.Select(x => new IdAndName() { Id = x.Id, Name = x.Name })
                }
            }

            public List<DbEntities.Structure.SubYear> ListSubYears(int yearId, bool onlyTopLevelLoad = false,
                int? parentId = null)
            {
                if (onlyTopLevelLoad)
                    return Context.SubYear.Where(x => x.YearId == yearId && x.ParentId == null)
                        .ToList();
                if (parentId == null)
                    return Context.SubYear.Where(x => x.YearId == yearId && x.ParentId == null)
                        .ToList();
                else
                {
                    return Context.SubYear.Where(x => x.ParentId == parentId)
                        .ToList();
                }
            }

            public List<ViewModel.IdAndName> GetPhase(int parentId)
            {
                return Context.SubYear.Where(x => x.ParentId == parentId)
                    .Select(x => new IdAndName() { Id = x.Id, Name = x.Name }).ToList();
            }


            public List<DbEntities.Structure.SubYear> ListSubYears(int yearId, bool onlyTopLevelLoad,
                bool includeTopField)
            {
                List<SubYear> list;
                if (onlyTopLevelLoad)
                    list = Context.SubYear.Where(x => x.YearId == yearId && x.ParentId == null)
                        .OrderBy(x => x.Position).ToList();
                else
                    list = Context.SubYear.Where(x => x.YearId == yearId).OrderBy(x => x.Position).ToList();
                if (includeTopField)
                {
                    list.Insert(0, new SubYear() { Id = 0, Name = "Top" });
                }
                return list;
            }


            #endregion

            //public DbEntities.Structure.Faculty AddOrUpdateFaculty(DbEntities.Structure.Faculty faculty)
            //{
            //    try
            //    {
            //        var ent = Context.Faculty.Find(faculty.Id);
            //        if (ent == null)
            //        {
            //            var l = Context.Faculty.Add(faculty);
            //            Context.SaveChanges();
            //            return l;
            //        }
            //        else
            //        {
            //            ent.Name = faculty.Name;
            //            ent.Description = faculty.Description;
            //            ent.LevelId = faculty.LevelId;
            //            Context.SaveChanges();
            //            return ent;
            //        }
            //    }
            //    catch
            //    {
            //        return null;
            //    }
            //}

            public DbEntities.Structure.Program AddOrUpdateProgram(DbEntities.Structure.Program program)
            {
                try
                {
                    var ent = Context.Program.Find(program.Id);
                    if (ent == null)
                    {
                        var l = Context.Program.Add(program);
                        Context.SaveChanges();
                        return l;
                    }
                    else
                    {
                        ent.Name = program.Name;
                        ent.Description = program.Description;
                        //ent.FacultyId = program.FacultyId;
                        Context.SaveChanges();
                        return ent;
                    }
                }
                catch
                {
                    return null;
                }
            }

            /// <summary>
            /// Provide only one value at a time
            /// </summary>
            /// <param name="schoolId"></param>
            /// <param name="levelId"></param>
            /// <param name="facultyId"></param>
            /// <param name="programId"></param>
            /// <param name="yearId"></param>
            /// <returns></returns>
            public int GetMaximumNoOfSubyears(int schoolId = 0, int programId = 0,
                int yearId = 0)
            {
                int cnt = 0;
                if (yearId != 0)
                {
                    cnt = Context.Year.Select(x => x.SubYears.Count(m => m.ParentId == null)).Max();
                }

                else if (programId != 0)
                {
                    var years = Context.Year.Where(y => y.ProgramId == programId);

                    cnt = years.Select(x => x.SubYears.Count(m => m.ParentId == null)).Max();
                }
                //else if (facultyId != 0)
                //{
                //    var years = from p in Context.Program
                //                join y in Context.Year on p.Id equals y.ProgramId
                //                //where p.FacultyId == facultyId
                //                select y;
                //    cnt = years.Select(x => x.SubYears.Count(m => m.ParentId == null)).Max();
                //}
                //else if (levelId != 0)
                //{
                //    var years = from f in Context.Faculty
                //                //join p in Context.Program on f.Id equals p.FacultyId
                //                //join y in Context.Year on p.Id equals y.ProgramId
                //                where f.LevelId == levelId
                //                select y;
                //    cnt = years.Select(x => x.SubYears.Count(m => m.ParentId == null)).Max();
                //}
                else if (schoolId != 0)
                {
                    var years = from //l in Context.Level
                                    //join f in Context.Faculty //on l.Id equals f.LevelId
                                 p in Context.Program //on f.Id equals p.FacultyId
                                join y in Context.Year on p.Id equals y.ProgramId
                                where p.SchoolId == schoolId
                                select y;
                    cnt = years.Select(x => x.SubYears.Count(m => m.ParentId == null)).Max();
                }
                return cnt;
            }


            //public List<Level> GetLevelsWithAllIncluded(int schoolId)
            //{
            //    return Context.Level.Include(m => m.Faculty).Where(x => x.SchoolId == schoolId
            //                                                               && !(x.Void ?? false)).ToList();
            //}


            #region Earlier Levels, Faculties, Programs,Years, subYears and phase

            public object GetEarlierYearSubYear(int yearId, int subyearId = 0)
            {

                if (subyearId > 0)
                {
                    var prevsubYear = GetEarlierSubYear(yearId, subyearId);
                    //if (Context.RunningClass.Any(x => (x.SubYearId ?? 0) == subyearId))
                    {
                        return prevsubYear;
                    }

                }
                else
                {
                    var prevYear = GetEarlierYear(yearId);
                    //if (Context.RunningClass.Any(x => x.YearId == yearId))
                    {
                        return prevYear;
                    }

                }
                return null;
            }

            public DbEntities.Structure.Year GetEarlierYear(int yearId)
            {
                var year = Context.Year.Find(yearId);
                if (year != null)
                {
                    var min = year.Program.Year.Where(x => !(x.Void ?? false)
                                                           && x.Position < year.Position)
                        .OrderByDescending(x => x.Position);
                    var mn = min.First();
                    if (mn != null)
                    {
                        return mn;
                    }
                }
                return null;

            }

            public DbEntities.Structure.SubYear GetEarlierSubYear(int yearId, int subyearId = 0)
            {
                if (subyearId > 0)
                {
                    var subyear = Context.SubYear.Find(subyearId);
                    if (subyear != null)
                    {
                        var min = subyear.Year.SubYears.Where(x => !(x.Void ?? false)
                                                                && x.Position < subyear.Position)
                            .OrderByDescending(x => x.Position);
                        var mn = min.First();
                        if (mn != null)
                        {
                            return mn;
                        }
                        else
                        {

                            var prevyear = subyear.Year.Program.Year.Where(x => !(x.Void ?? false)
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

            #endregion

            //public DbEntities.Structure.Program GetProgram(int programId)
            //{
            //    var prog =
            //        Context.Program.Include(x => x.Faculty)
            //            .Include(x => x.Faculty.Level)
            //            .Include(x => x.Faculty.Level.School)
            //            .FirstOrDefault(x => x.Id == programId);
            //    return prog;
            //}



            public string GetSructureDirectory(int yearId, int subyearId = 0)
            {
                string dir = "";
                if (subyearId != 0)
                {
                    var sub = Context.SubYear.Find(subyearId);
                    if (sub != null)
                    {
                        dir = //sub.Year.Program.Faculty.Level.Name + ">"
                            //+ sub.Year.Program.Faculty.Name + ">"
                               sub.Year.Program.Name + " / "
                              + sub.Year.Name + " / "
                              + sub.Name;
                    }
                }
                else
                {
                    var year = Context.Year.Find(yearId);
                    if (year != null)
                    {
                        dir = //year.Program.Faculty.Level.Name + ">"
                            //      + year.Program.Faculty.Name + ">"
                               year.Program.Name + ">"
                              + year.Name;
                    }
                }
                return dir;
            }


            //Used... latest..
            #region Get Functions i.e. which return single object not list

            //public Level GetLevel(int levelId)
            //{
            //    return Context.Level.Find(levelId);
            //}

            //public Faculty GetFaculty(int facultyId)
            //{
            //    return Context.Faculty.Find(facultyId);
            //}

            public Program GetProgram(int programId)
            {
                return Context.Program.Find(programId);
            }

            public Year GetYear(int yearId)
            {
                return Context.Year.Find(yearId);
            }

            public SubYear GetSubYear(int subyearId)
            {
                return Context.SubYear.Find(subyearId);
            }

            #endregion

            #region List functions

            public List<Program> ListPrograms(int schoolId)
            {
                return Context.Program.Where(x => x.SchoolId == schoolId && !(x.Void ?? false)).ToList();
            }

            #endregion

            public bool DeleteProgram(int programId)
            {
                try
                {
                    var program = Context.Program.Find(programId);
                    if (program != null)
                    {
                        program.Void = true;
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

            public bool DeleteYear(int yearId)
            {
                try
                {
                    var year = Context.Year.Find(yearId);
                    if (year != null)
                    {
                        year.Void = true;
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

            public bool DeleteSubYear(int subyearId)
            {
                try
                {
                    var subYear = Context.SubYear.Find(subyearId);
                    if (subYear != null)
                    {
                        subYear.Void = true;
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

            public bool CopyYearsAndSubyears(int fromProgram, int toProgram)
            {
                try
                {
                    var fp = GetProgram(fromProgram);
                    var tp = GetProgram(toProgram);
                    if (fp != null && tp != null)
                    {
                        foreach (var yea in fp.Year.Where(x => !(x.Void ?? false)))
                        {
                            var newYear = new Year()
                            {
                                ProgramId = toProgram
                                ,
                                Name = yea.Name
                                ,
                                Position = yea.Position
                                ,
                            };
                            var savedYear = Context.Year.Add(newYear);
                            Context.SaveChanges();
                            foreach (var syea in yea.SubYears.Where(x => !(x.Void ?? false)))
                            {
                                var newSubYear = new SubYear()
                                {
                                    YearId = savedYear.Id
                                    ,
                                    Name = syea.Name
                                    ,
                                    Position = syea.Position
                                    ,
                                };
                                var savedSubYear = Context.SubYear.Add(newSubYear);
                                Context.SaveChanges();
                            }
                        }
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
