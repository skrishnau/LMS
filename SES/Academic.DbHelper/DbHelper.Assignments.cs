using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Academic.Database;
using Academic.DbEntities.ActivityAndResource.AssignmentItems;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Assignments:IDisposable
        {
            private Academic.Database.AcademicContext Context;

            public Assignments()
            {
                Context = new AcademicContext();
            }

            public void Dispose()
            {
                Context.Dispose();
            }





            public AssignmentSubmissions AddOrUpdateAssignmentSubmission(AssignmentSubmissions submission)
            {
                try
                {
                    var ent = Context.AssignmentSubmissions.Find(submission.Id);
                    if (ent == null)
                    {
                        ent = Context.AssignmentSubmissions.Add(submission);
                        Context.SaveChanges();
                    }
                    else
                    {
                        ent.ModifiedDate = submission.ModifiedDate;
                        ent.SubmissionText = submission.SubmissionText;
                        Context.SaveChanges();
                    }
                    return ent;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
