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
        public class News : IDisposable
        {
            private AcademicContext Context;

            //public List<DbEntities.News>


            public void Dispose()
            {
                Context.Dispose();
            }
        }

    }
}
