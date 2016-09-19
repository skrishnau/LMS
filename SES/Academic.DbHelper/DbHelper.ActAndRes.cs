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
        public class ActAndRes : IDisposable
        {
            Academic.Database.AcademicContext Context;

            public ActAndRes()
            {
                Context = new AcademicContext();
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public DbEntities.ActivityAndResource.Assignment AddOrUpdateAssignment(DbEntities.ActivityAndResource.Assignment asg)
            {
                var ent = Context.Assignment.Find(asg.Id);
                if (ent == null)
                {
                    var saved = Context.Assignment.Add(asg);

                    Context.SaveChanges();
                    return saved;
                }
                //else
                //{
                //    ent.CutOffDate = asg.CutOffDate;
                //    ent.Description = asg.Description;
                //    ent.DispalyDescriptionOnPage = asg.DispalyDescriptionOnPage;
                //    ent.DueDate = asg.DueDate;
                //    ent.GradeToPass = asg.GradeToPass;
                //    ent.GradeType = asg.GradeType;
                //    ent.MaximumGrade = asg.MaximumGrade;
                //    ent.MaximumNoOfUploadedFiles = asg.MaximumNoOfUploadedFiles;
                //    ent.MaximumSubmissionSize = asg.MaximumSubmissionSize;
                //    ent.ModifiedBy = asg.ModifiedBy;
                //    ent.ModifiedDate = asg.ModifiedDate;
                //    ent.SubmissionFrom = asg.SubmissionFrom;
                //   // ent.SubmissionType = asg.SubmissionType;
                //    ent.Name = asg.Name;
                //    ent.WordLimit = asg.WordLimit;
                //    Context.SaveChanges();
                //    return ent;
                //}
                return null;
            }
        }
    }
}
