using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class CustomAccount:IDisposable
        {
            private AcademicContext Context;

            public CustomAccount()
            {
                Context = new AcademicContext();
            }

            public bool CheckUser(string username, string password)
            {
                try
                {
                    var user = Context.Users.FirstOrDefault(x => x.UserName.Trim() == username.Trim() && x.Password.Trim() == password.Trim());
                    if (user != null)
                    {
                        //valid user
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public List<string> GetUserRoles(string username)
            {
                try
                {
                    var roles = Context.UserRole.Where(x => x.User.UserName == username);
                    return roles.Select(x => x.Role.Name).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public bool Register(DbEntities.User.Users  user)
            {
                try
                {
                    Context.Users.Add(user);
                    Context.SaveChanges();


                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }


            public void Dispose()
            {
                Context.Dispose();
            }
        }
    }
}
