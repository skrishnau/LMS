using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.ViewModel;
using Academic.DbEntities.User;
using Academic.ViewModel.Account;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Account : IDisposable
        {
            AcademicContext Context;
            public Account()
            {
                Context = new AcademicContext();
            }


            public UserInfoModel Login(LoginViewModel model)
            {
                var user = Context.Users.FirstOrDefault(x => x.UserName == model.UserName);
                if (user == null)
                {
                    //check in teacher and student 
                    var teacher = Context.CreatedUser.FirstOrDefault(x => x.UserName == model.UserName);
                    if (teacher == null)
                    {
                        var student = Context.CreatedUser.FirstOrDefault(x => x.UserName == model.UserName);
                        if (student == null) return null;
                        return new UserInfoModel()
                        {
                            FullName = student.FirstName+" "+student.MiddleName[0]+". "+student.LastName,
                             Username = student.UserName,
                             Role = "Student"
                             ,Id = student.Id
                        };
                        return null;
                    }
                    if (teacher.Password == model.Password)
                        return new UserInfoModel()
                        {
                            Role = "Teacher",
                            FullName = (teacher.FirstName??"")+" "+(teacher.MiddleName??"")+". "+(teacher.LastName??"")
                            ,Username = teacher.UserName??""
                            ,Id = teacher.Id
                        };
                }
                // apply encryption of password so here we have to decrypt it.
                if (user.Password == model.Password)
                {
                    var info = new UserInfoModel()
                    {
                        FullName = user.FirstName ?? "" + " " + user.MiddleName ?? "" + " " + user.LastName ?? "",
                        Username = user.UserName,
                        Role = Context.Role.Find(user.RoleId).Name // user.Role.Name
                        ,Id = user.Id
                    };
                    return info;
                }
                return null;
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public UserInfoModel CreateUserAndAccount(string username, string password)
            {
                //encrypt password and check with db
                Users user = Context.Users.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower() && x.Password == password);
                if (user != null) return null;
                var newUser = new Users() { UserName = username, Password = password, RoleId=2 };
                Context.Users.Add(newUser);
                Context.Entry<Users>(newUser).State = System.Data.EntityState.Added;
                Context.SaveChanges();
                var model = new UserInfoModel()
                {

                    Username = user.UserName,
                    FullName = user.FullName

                };
                return model;
            }
        }
    }
}
