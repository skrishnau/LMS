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
       public class Assignment:IDisposable
       {
           AcademicContext context = new AcademicContext();

           public void ListAssignment_all()
           {
               //context.Assignment.
           }



           public void ListAssignment_forCombo()
           {
               
           }

           public void Dispose()
           {
               context.Dispose();
           }
       }
    }
}
