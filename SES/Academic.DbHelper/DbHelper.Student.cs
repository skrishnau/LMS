using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Internal.Linq;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.Database;
using Academic.DbEntities.Students;
using Academic.DbEntities.User;
using Academic.ViewModel.Student;
using Academic.ViewModel.SystemControl.Office;
using System.Data.EntityModel;
using System.Web.SessionState;
using Academic.DbEntities.Structure;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Student : IDisposable
        {
            AcademicContext Context;

            public Student()
            {
                Context = new AcademicContext();
            }

            //public static DbEntities.Students.Student Convert(StudentViewModel model)
            //{
            //    DbEntities.Students.Student entity = new DbEntities.Students.Student()
            //    {
            //        BarcodeNo = model.BarcodeNo,
            //        CRN = model.CRN,
            //        GenderId = model.GenderId,
            //        HomeNo = model.HomeNo,
            //        GuardianContactNo = model.GuardianContactNo,
            //        GuardianEmail = model.GuardianEmail,
            //        GuardianName = model.GuardianName,
            //        Email = model.Email,
            //        ExamRollNoGlobal = model.ExamRollNoGlobal,
            //        IsActive = model.IsActive,
            //        FirstName = model.FirstName,
            //        LastName = model.LastName,
            //        MiddleName = model.MiddleName,
            //        MobileNo = model.MobileNo,
            //        Nationality = model.Nationality,
            //        OtherRollName = model.OtherRollName,
            //        OtherRollNo = model.OtherRollNo,
            //        PermanentCity = model.PermanentCity,
            //        PermanentCountry = model.PermanentCountry,
            //        PermanentStreet = model.PermanentStreet,
            //        Password =  model.Password,
            //        TemporaryCountry = model.TemporaryCountry,
            //        TemporaryCity = model.TemporaryCity,
            //        TemporaryStreet = model.TemporaryStreet,
            //        RoleId = model.RoleId,
            //        Religion = model.Religion,
            //        UserName = model.UserName,
            //        SchoolId = model.SchoolId,
            //        ImageFileId = model.ImageFileId,


            //    };
            //    entity.DOB = new DateTime((int)model.DOBYear, (int)model.DOBMonth + 1, (int)model.DOBDay);
            //    entity.MembershipDate = new DateTime((int)model.MembershipYear, (int)model.MembershipMonth + 1,
            //        (int)model.MembershipDay);
            //    return entity;
            //}

            //public DbEntities.Students.Student Add(StudentViewModel model)
            //{
            //    using (var iCtx = new DbHelper.WorkingWithFiles())
            //    {
            //        var imageId = iCtx.UploadImageToDB(model.Image);
            //        //if (imageId <= 0) return null;
            //        var entity = Convert(model);
            //        entity.ImageFileId = imageId;
            //        var student = Context.Student.Add(entity);
            //        Context.SaveChanges();
            //        return student;;
            //    }
            //}

            public void Dispose()
            {

                Context.Dispose();
            }

            //public int[] GetInstSchool(int userId)
            //{
            //    var std = Context.Student.FirstOrDefault(x => x.Id == userId);
            //    if (std == null) return new int[]{0,0};
            //    var schoolId = std.SchoolId;
            //    var instId = std.School.InstitutionId;
            //    return new int[]{instId,schoolId};
            //}


            //public ViewModel.SystemControl.Office.InstitutionAndSchool GetInstitutionAndSchool(int userId)
            //{
            //    var teach = Context.Student.Include(x=>x.School).FirstOrDefault(x => x.Id == userId);
            //    if (teach == null) return null;
            //    var model = new InstitutionAndSchool();
            //    model.School = teach.School;
            //    var inst = Context.Institution.Find(teach.School.InstitutionId);
            //    if (inst != null)
            //        model.Institution = inst;
            //    return model;
            //}


            //used 
            public DbEntities.User.Users AddOrUpdateStudent(DbEntities.User.Users user,
                DbEntities.Students.Student student, int programBatchId = 0)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        //byte[] imgBytes = null;

                        //using (var filehelper = new DbHelper.WorkingWithFiles())
                        //{
                        //    //if (file != null)
                        //    //{
                        //    //    //imgBytes = filehelper.ConvertToBytes(file);
                        //    //    //below comented due to changed in database.. now image is saved as file.
                        //    //    //user.Image = imgBytes;
                        //    //    //user.ImageType = file.ContentType;
                        //    //}
                        //}
                        var prev = Context.Users.Find(user.Id);
                        if (prev == null)
                        {
                            user.FirstName = user.FirstName.Trim();
                            user.LastName = user.LastName.Trim();
                            prev = Context.Users.Add(user);
                            Context.SaveChanges();
                            if (prev != null)
                            {
                                student.UserId = prev.Id;
                                student.Name = prev.FullName;
                                var std = Context.Student.Add(student);
                                Context.SaveChanges();
                                if (std != null)
                                {
                                    var role = Context.Role.FirstOrDefault(x => x.RoleName == "student");
                                    if (role != null)
                                    {
                                        var userRole = new UserRole()
                                        {
                                            AssignedDate = DateTime.Now
                                            ,
                                            RoleId = role.Id
                                            ,
                                            UserId = prev.Id
                                        };
                                        Context.UserRole.Add(userRole);
                                        Context.SaveChanges();
                                    }
                                    if (programBatchId > 0)
                                    {
                                        var stdBatch = new DbEntities.Batches.StudentBatch()
                                        {
                                            ProgramBatchId = programBatchId
                                            ,
                                            StudentId = std.Id
                                            ,
                                            AddedDate = DateTime.Now
                                        };
                                        Context.StudentBatch.Add(stdBatch);
                                        Context.SaveChanges();
                                    }
                                }
                            }
                        }
                        else
                        {
                            prev.CreatedDate = user.CreatedDate;
                            prev.DOB = user.DOB;
                            prev.FirstName = user.FirstName;

                            //below two lines commnented due to changes in database: now image saved as file.
                            //prev.Image = user.Image;
                            //prev.ImageType = user.ImageType;

                            //prev.InstitutionId = createdUser.InstitutionId;
                            prev.SchoolId = user.SchoolId;
                            //prev.BarcodeNo = createdUser.BarcodeNo;
                            //prev.Citizenship = createdUser.Citizenship;
                            prev.City = user.City;
                            prev.Country = user.Country;
                            prev.Email = user.Email;
                            prev.UserName = user.UserName;
                            //prev.Street = createdUser.Street;
                            //prev.UserTypeId = createdUser.UserTypeId;
                            //prev.Religion = createdUser.Religion;
                            //prev.Phone2 = createdUser.Phone2;
                            //prev.Phone1 = createdUser.Phone1;
                            prev.Password = user.Password;
                            //prev.Nationality = createdUser.Nationality;
                            //prev.MiddleName = createdUser.MiddleName;
                            prev.LastName = user.LastName;
                            prev.IsActive = user.IsActive;
                            prev.IsDeleted = user.IsDeleted;
                            //prev.Religion = createdUser.Religion;

                            var std = Context.Student.Find(student.Id);
                            if (std == null)
                            {
                                student.UserId = prev.Id;
                                Context.Student.Add(student);
                            }

                            Context.SaveChanges();
                        }

                        scope.Complete();
                        return prev;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public DbEntities.Students.StudentGroup AddOrUpdateStudentGroup(DbEntities.Students.StudentGroup sgroup)
            {
                try
                {
                    var prev = Context.StudentGroup.Find(sgroup.Id);
                    if (prev == null)
                    {
                        var grp = Context.StudentGroup.Add(sgroup);
                        Context.SaveChanges();
                        return grp;
                    }
                    else
                    {
                        prev.Name = sgroup.Name;
                        prev.SchoolId = sgroup.SchoolId;
                        Context.SaveChanges();
                        return prev;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public List<DbEntities.Students.Student> GetStudentList(int schoolId, string Name,
                string CRN, DateTime dateTime)
            {
                try
                {
                    var crn = CRN.ToLower();
                    var name = Name.ToLower();
                    //var lst = from u in Context.Users.AsEnumerable()
                    //          join s in Context.Student.AsEnumerable() on u.Id equals  s.UserId
                    //          where 
                    var lst = Context.Student.Where(x => x.User.SchoolId == schoolId
                        && (x.User.IsDeleted ?? false) == false && x.User.IsActive == true).ToList();
                    if (crn != "")
                    {
                        lst = lst.Where(x => x.CRN.ToLower().StartsWith(crn)).ToList();
                    }
                    if (name != "")
                    {
                        lst = lst.Where(x => x.User.FullName.ToLower().StartsWith(name)).ToList();
                    }

                    lst = lst//.Include(y => y.User)
                       .Where(x =>
                                   (x.User.CreatedDate) >= dateTime).ToList();
                    return lst.ToList();
                }
                catch
                {
                    return new List<DbEntities.Students.Student>();
                }
            }

            public List<DbEntities.Students.Student> GetStudentList(int schoolId, string Name,
               string CRN)
            {
                try
                {
                    var crn = CRN.ToLower();
                    var name = Name.ToLower();
                    //var lst = from u in Context.Users.AsEnumerable()
                    //          join s in Context.Student.AsEnumerable() on u.Id equals  s.UserId
                    //          where 
                    var lst = Context.Student.Where(x => x.User.SchoolId == schoolId
                        && (x.User.IsDeleted ?? false) == false && x.User.IsActive == true).ToList();
                    if (crn != "")
                    {
                        lst = lst.Where(x => x.CRN.ToLower().StartsWith(crn)).ToList();
                    }
                    if (name != "")
                    {
                        lst = lst.Where(x => x.User.FullName.ToLower().StartsWith(name)).ToList();
                    }

                    //lst = lst//.Include(y => y.User)
                    //   .Where(x =>
                    //               (x.User.CreatedDate) >= dateTime).ToList();
                    return lst.ToList();
                }
                catch
                {
                    return new List<DbEntities.Students.Student>();
                }
            }

            /// <summary>
            /// Returns a list of students who are not assigned to any batch.
            /// </summary>
            /// <param name="schoolId"></param>
            /// <param name="Name"></param>
            /// <param name="CRN"></param>
            /// <param name="createdDate"></param>
            /// <returns></returns>
            public List<DbEntities.Students.Student> GetUnAssignedStudents(int schoolId, string Name = "",
               string CRN = "", DateTime? createdDate = null)
            {
                try
                {
                    var crn = CRN.ToLower();
                    var name = Name.ToLower();
                    //var lst = from u in Context.Users.AsEnumerable()
                    //          join s in Context.Student.AsEnumerable() on u.Id equals  s.UserId
                    //          where 
                    var lst = Context.Student.Where(x => x.User.SchoolId == schoolId
                        && (x.User.IsDeleted ?? false) == false && x.User.IsActive == true && !(x.BatchAssigned ?? false)).ToList();
                    if (crn != "")
                    {
                        lst = lst.Where(x => x.CRN.ToLower().StartsWith(crn)).ToList();
                    }
                    if (name != "")
                    {
                        lst = lst.Where(x => x.User.FullName.ToLower().StartsWith(name)).ToList();
                    }

                    if (createdDate != null)
                        lst = lst//.Include(y => y.User)
                           .Where(x =>
                                       (x.User.CreatedDate) >= createdDate).ToList();
                    return lst.ToList();
                }
                catch
                {
                    return new List<DbEntities.Students.Student>();
                }
            }

            public DbEntities.Students.StudentGroup GetStudentGroup(int id)
            {
                return Context.StudentGroup.Find(id);
            }

            public List<Users> GetUsersWithNoRoles(int schoolId)
            {
                var s =
                Context.Users.Include(y => y.UserRoles)
                   .Where(x => x.UserRoles.Count <= 0 && x.SchoolId == schoolId)
                   .OrderBy(o => o.FirstName).ThenBy(t => t.LastName).ThenBy(th => th.CreatedDate).ToList();
                return s;
            }

            public bool AssignStudentToGroup(List<int> stdList, int grpId, int userId)
            {
                var group = Context.StudentGroup.Find(grpId);

                if (group != null)
                {
                    var date = DateTime.Now;
                    try
                    {
                        using (var scope = new TransactionScope())
                        {
                            foreach (var i in stdList)
                            {
                                var stdGroup = new StudentGroupStudent()
                                {
                                    AssignedDate = date
                                    ,
                                    StudentGroupId = grpId
                                    ,
                                    StudentId = i
                                    ,
                                    AssignedBy = userId
                                };
                                Context.StudentGroupStudent.Add(stdGroup);
                            }
                            Context.SaveChanges();
                            scope.Complete();
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                return false;
            }
            public List<StudentGroup> GetStudentGroupList(int schoolId, bool includeSubGroupAlso = false)
            {
                return Context.StudentGroup.Where(x => x.SchoolId == schoolId
                    && x.IsActive == true && (includeSubGroupAlso ? x.ParentId != null : x.ParentId == null)).ToList();
            }

            public List<StudentGroup> GetStudentGroupListForDisplay(int schoolId, bool includeSubgroupAlso = false)
            {
                var group = Context.StudentGroup.Where(x => x.SchoolId == schoolId
                    && x.IsActive == true && (includeSubgroupAlso ? x.ParentId != null : x.ParentId == null)).ToList();

                //var runningClass =
                //    Context.RunningClass.Where(x => x.AcademicYear.IsActive  && x.SessionId == sessionId ?? 0);

                //var studentInClass = Context.StudentClass.Where(x=>x.RunningClassId==)
                //active groups from earlier and this academic year



                return group;
            }

            public List<DbEntities.Students.StudentGroup> GetNewStudentGroups(int schoolId)
            {
                return Context.StudentGroup.Where(x => !(x.StartedStudying ?? false) && !(x.Void ?? false)).ToList();
            }



            /// <summary>
            /// Returns a list of subyears 
            /// in which if subyear.year.Name empty xa bhane tyo year ho other wise tyo subyear ho
            /// </summary>
            /// <param name="userId"></param>
            /// <returns></returns>
            public List<DbEntities.Structure.SubYear> GetEarlierYearsAndSubYearsOfStudent(int userId)
            {
                List<DbEntities.Structure.SubYear> lst = new List<SubYear>();
                var years = from sb in Context.StudentBatch
                            join pb in Context.ProgramBatch on sb.ProgramBatchId equals pb.Id
                            join rc in Context.RunningClass.Include(c => c.Year).Include(c => c.SubYear) on pb.Id equals rc.ProgramBatchId
                            select rc;
                var y = years.OrderBy(x => x.Year.Position).ThenBy(x => (x.SubYear == null) ? x.YearId : x.SubYear.Position).ToList();

                //subyear.year.Name empty xa bhane tyo year ho other wise tyo subyear ho
                foreach (var ym in y.GroupBy(x => x.Year))
                {
                    if (ym.Any() || ym.Any(x => x.SubYear == null))
                    {
                        var ymEmt = new SubYear()
                        {

                            // Id = ym.Key.Id
                            //    ,
                            // Name = ym.Key.Name
                            //,
                            Description = "year"
                            ,
                            YearId = ym.Key.Id
                            ,
                            Year = new Year() { Name = ym.Key.Name }
                        };
                        lst.Add(ymEmt);
                    }
                    foreach (var runningClass in ym)
                    {

                        if (runningClass.SubYear != null)
                        {
                            var subEmt = new SubYear()
                            {
                                Id = runningClass.SubYearId ?? 0
                                ,
                                Name = runningClass.SubYear.Name
                                ,
                                Description = "subyear"
                                 ,
                                YearId = ym.Key.Id
                            ,
                                Year = new Year() { Name = "" }
                            };
                            lst.Add(subEmt);
                        }
                    }
                }
                return lst;
                //return years.GroupBy(x=>x.Year).ToList();
                //return Context.StudentBatch.Where(x=>x.Student.UserId==userId).Select(x=>x.)
            }

            public List<DbEntities.Batches.StudentBatch> ListStudentBatchesOfProgramBatch(int programBatchId)
            {
                var stdBatchs = Context.StudentBatch.Where(x =>
                            x.ProgramBatchId == (programBatchId)
                            && !(x.Void ?? false) 
                            && !(x.Student.Void ?? false) 
                            && !(x.Student.User.IsDeleted ?? false));
                return stdBatchs.ToList();
            }
        }

    }
}
