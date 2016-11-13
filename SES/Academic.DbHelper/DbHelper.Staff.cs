using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.DbEntities.User;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Staff:IDisposable
        {
            AcademicContext Context;

            public Staff()
            {
                    Context = new AcademicContext();

            }

            public void Dispose()
            {
                Context.Dispose();
            }

            //public List<Users> GetEmployeesOfExamDivisionForCombo(int schoolId)
            //{
            //    try
            //    {
            //        List<Users> users = new List<Users>();

            //        var examDivision = Context.Division.Include(x => x.UserDivisions).FirstOrDefault(y => y.Name == "Exam" && y.SchoolId == schoolId);
            //        if (examDivision != null)
            //            foreach (var division in examDivision.UserDivisions)
            //            {
            //                users.Add(division.Users);
            //            }
            //        return users;
            //    }
            //    catch 
            //    {
            //        return new List<Users>();
            //    }
            //}
        }
    }
}
