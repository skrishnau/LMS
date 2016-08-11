using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using Academic.Database;
using Academic.DbEntities;
using Academic.DbEntities.User;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class User : IDisposable
        {
            private AcademicContext Context;

            public User()
            {
                Context = new AcademicContext();
            }
            public void Dispose()
            {
                Context.Dispose();
            }

            public List<Users> Users
            {
                get { return Context.Users.ToList(); }
            }

            //Roles
            public List<Role> GetRole(int schoolId)
            {
                return Context.Role.Where(x => !(x.Void ?? false) && (x.SchoolId == schoolId || x.SchoolId == null)).ToList();
            }

            public List<DbEntities.User.UserType> GetUserTypes(int schoolId)
            {
                var type = Context.UserType.Where(x => !(x.Void ?? false) && (x.SchoolId == schoolId
                    || x.SchoolId == null)).ToList();
                if (type.Count == 0)
                {
                    var stdType = new UserType()
                    {
                        Name = "Student"


                    };
                    var teachType = new UserType()
                    {
                        Name = "Teacher"
                    };
                    Context.UserType.Add(stdType);
                    Context.UserType.Add(teachType);
                    Context.SaveChanges();
                    type = Context.UserType.Where(x => !(x.Void ?? false) && (x.SchoolId == schoolId
                    || x.SchoolId == null)).ToList();
                }
                return type;
            }
            public bool AddOrUpdateRole(Role role)
            {
                try
                {
                    var r = Context.Role.Find(role.Id);
                    if (r == null)
                    {
                        Context.Role.Add(role);

                    }
                    else
                    {
                        r.Name = role.Name;
                        r.Description = role.Description;
                        r.SchoolId = role.SchoolId;
                    }
                    Context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            //working
            public bool SaveUsersRole(List<int> userList, int roleId)
            {
                try
                {
                    var date = DateTime.Now;
                    var role = Context.Role.Find(roleId);
                    if (role != null)
                    {
                        using (var scope = new TransactionScope())
                        {
                            if (role.Name.ToLower() == "teacher")
                            {
                                foreach (var i in userList)
                                {
                                    var ur = new Academic.DbEntities.User.UserRole()
                                    {
                                        UserId = i,
                                        RoleId = roleId,
                                        AssignedDate = DateTime.Now.Date
                                    };
                                    var savedRole = Context.UserRole.Add(ur);
                                    var usr = Context.Users.Find(i);
                                    var name = (usr == null) ? "" : usr.FullName;

                                    var teacher = new DbEntities.Teachers.Teacher()
                                    {
                                        UserId = i
                                        ,
                                        Name = name
                                        ,
                                        AppointedDate = date
                                    };
                                    var savedteacher = Context.Teacher.Add(teacher);
                                    Context.SaveChanges();
                                }
                            }
                            else if (role.Name.ToLower() == "student")
                            {
                                foreach (var i in userList)
                                {
                                    var ur = new Academic.DbEntities.User.UserRole()
                                    {
                                        UserId = i,
                                        RoleId = roleId,
                                        AssignedDate = DateTime.Now.Date
                                    };
                                    var savedRole = Context.UserRole.Add(ur);
                                    var usr = Context.Users.Find(i);
                                    var name = (usr == null) ? "" : usr.FullName;

                                    var std = new DbEntities.Students.Student()
                                    {
                                        UserId = i
                                        ,
                                        Name = name
                                        ,
                                        AssignedDate = date
                                    };
                                    var savedStd = Context.Student.Add(std);
                                    Context.SaveChanges();
                                }
                            }

                            Context.SaveChanges();
                            scope.Complete();
                            return true;
                        }
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }


            //User
            public bool AddOrUpdateUser(DbEntities.User.Users user, string roleId, HttpPostedFile file)
            {
                try
                {
                    var date = DateTime.Now.Date;

                    using (TransactionScope scope = new TransactionScope())
                    {
                        byte[] imgBytes = null;

                        //using (var filehelper = new DbHelper.WorkingWithFiles())
                        //{
                        //    if (file != null)
                        //    {
                        //        imgBytes = filehelper.ConvertToBytes(file);
                        //        user.Image = imgBytes;
                        //        user.ImageType = file.ContentType;
                        //    }
                        //}



                        var ent = Context.Users.Find(user.Id);
                        if (ent == null)
                        {
                            var entity = Context.Users.Add(user);
                            Context.SaveChanges();

                            //save  image
                            //file.SaveAs();
                            if (file != null)
                            {
                                var image = new File()
                                {
                                    CreatedBy = entity.Id
                                    ,
                                    CreatedDate = DateTime.Now
                                    ,
                                    DisplayName = file.FileName
                                    ,
                                    FileDirectory = InitialValues.StaticValue.UserImageDirectory
                                    ,
                                    FileName = Guid.NewGuid().GetHashCode().ToString()
                                    ,
                                    FileSizeInBytes = file.ContentLength
                                    ,
                                    FileType = file.ContentType
                                    ,
                                };
                                GetNewGuid(image);
                                file.SaveAs(image.FileDirectory + image.FileName);

                                var savedImage = Context.File.Add(image);
                                Context.SaveChanges();

                                entity.UserImageId = savedImage.Id;
                            }



                            //new ma matra role Admin hunxa other wise there are many roles for a user
                            if (roleId != "")
                            {
                                int rolei = Convert.ToInt32(roleId);
                                if (rolei > 0)
                                {
                                    SaveUsersRole(new List<int>() { entity.Id }, rolei);
                                    //var role = new UserRole()
                                    //{
                                    //    RoleId = rolei,
                                    //    UserId = entity.Id
                                    //    ,
                                    //    AssignedDate = DateTime.Now.Date

                                    //};
                                    //Context.UserRole.Add(role);
                                    //Context.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            //remained to add other attributes
                            ent.City = user.City;
                            ent.Country = user.Country;
                            ent.DOB = user.DOB;
                            ent.Description = user.Description;
                            ent.Email = user.Email;
                            ent.FirstName = user.FirstName;
                            ent.EmailDisplay = user.EmailDisplay;
                            ent.Email = user.Email;
                            //if (imgBytes != null)
                            //{
                            //    ent.Image = imgBytes;
                            //    ent.ImageType = file.ContentType;
                            //}
                            ent.UserName = user.UserName;
                            // ent.RoleId = user.RoleId;
                            ent.Phone = user.Phone;
                            ent.IsDeleted = user.IsDeleted;
                            ent.IsActive = user.IsActive;
                            ent.Password = user.Password;
                            ent.LastName = user.LastName;
                            Context.SaveChanges();
                        }
                        scope.Complete();
                        return true;
                    }
                }
                catch (Exception)
                {

                    return false;
                }
            }

            private void GetNewGuid(File image)
            {
                var existingFile = Context.File.FirstOrDefault(x => x.FileName == image.FileName);
                if (existingFile != null)
                {
                    image.FileName = Guid.NewGuid().GetHashCode().ToString();
                    GetNewGuid(image);
                }
            }


            private Users GetUser(int userId)
            {
                return Context.Users.Find(userId);
            }

            public void SaveCreatedUser(DbEntities.User.CreatedUser createdUser, List<int> DivisonsAssigned, HttpPostedFile file)
            {
                var date = DateTime.Now.Date;
                using (TransactionScope scope = new TransactionScope())
                {
                    byte[] imgBytes = null;

                    using (var filehelper = new DbHelper.WorkingWithFiles())
                    {
                        if (file != null)
                        {
                            imgBytes = filehelper.ConvertToBytes(file);
                            createdUser.Image = imgBytes;
                            createdUser.ImageType = file.ContentType;
                        }
                    }
                    Context.SaveChanges();
                    //var entity = Context.CreatedUser.Add(createdUser);
                    //if (entity != null)
                    //{
                    //    foreach (var i in DivisonsAssigned)
                    //    {
                    //        var ud = new DbEntities.User.UserDivision()
                    //        {
                    //            AssignDate = date
                    //            ,
                    //            DivisionId = i
                    //            ,
                    //            UsersId = entity.Id
                    //            ,
                    //            Void = false
                    //            ,
                    //        };
                    //        Context.UsersDivision.Add(ud);
                    //    }
                    //    Context.SaveChanges();
                    //}
                    scope.Complete();
                }
            }


            //listing of users
            public List<Users> ListAllUsers(int schoolId, int perPage, int pageNo)
            {
                var list = Context.Users.Where(x => x.SchoolId == schoolId)
                    .OrderBy(y => y.FirstName).ThenBy(t => t.LastName)
                    .Skip(perPage * (pageNo - 1)).Take(perPage);
                return list.ToList();
            }


            //gender
            public List<DbEntities.User.Gender> GetGender()
            {
                var gender = Context.Gender.ToList();
                if (gender.Count == 0)
                {
                    var male = new Gender() { Name = "Male" };
                    var female = new Gender() { Name = "Female" };
                    //var other = new Gender(){Name = "Other"};
                    Context.Gender.Add(male);
                    Context.Gender.Add(female);
                    Context.SaveChanges();
                }
                return Context.Gender.ToList();
            }

            //divisions
            public List<Division> GetDivisionsForCombo(int schoolId)
            {
                List<Division> list = new List<Division>();
                var divs = Context.Division.Include(x => x.ParentDivision).Where(x => x.SchoolId == schoolId).ToList();
                foreach (var division in divs)
                {
                    var div = new Division()
                    {
                        Id = division.Id
                        ,
                        Name = division.Name
                        ,
                        SchoolId = division.SchoolId
                        ,
                    };
                    if (division.ParentDivision != null)
                    {
                        div.Name += " (" + division.ParentDivision.Name + ")";
                    }
                    list.Add(div);
                }
                return list;
            }



        }
    }
}
