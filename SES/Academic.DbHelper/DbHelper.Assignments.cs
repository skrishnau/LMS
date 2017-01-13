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





            public AssignmentSubmissions AddOrUpdateAssignmentSubmission(AssignmentSubmissions submission
                ,List<Academic.DbEntities.UserFile> files)
            {
                try
                {
                    var date = DateTime.Now;
                    var ent = Context.AssignmentSubmissions.Find(submission.Id);
                    if (ent == null)
                    {
                        ent = Context.AssignmentSubmissions.Add(submission);
                        Context.SaveChanges();
                        foreach (var f in files.Where(x => !(x.Void ?? false)))
                        {
                            var savedFile = Context.File.Add(f);
                            Context.SaveChanges();

                            var savedFileResFile = Context.AssignmentSubmissionFiles.Add(new AssignmentSubmissionFiles()
                            {
                                AssignmentSubmissionsId = ent.Id
                                ,
                                UserFileId = savedFile.Id
                                ,
                                FileSubmittedDate = date
                                ,
                            });
                            Context.SaveChanges();
                        }
                    }
                    else
                    {
                        ent.ModifiedDate = submission.ModifiedDate;
                        ent.SubmissionText = submission.SubmissionText;
                        Context.SaveChanges();

                        foreach (var f in files)
                        {
                            var earlier = Context.File.Find(f.Id);
                            if (earlier == null)
                            {
                                var savedFile = Context.File.Add(f);
                                Context.SaveChanges();
                               
                                var savedFileResFile = Context.AssignmentSubmissionFiles.Add(new AssignmentSubmissionFiles()
                                {
                                    AssignmentSubmissionsId = ent.Id
                                    ,
                                    UserFileId = savedFile.Id
                                    ,
                                    FileSubmittedDate = date
                                    ,
                                });
                                Context.SaveChanges();
                            }
                            else
                            {
                                earlier.Void = f.Void;
                                if (f.Void ?? false)
                                {
                                    var fnd = Context.AssignmentSubmissionFiles.FirstOrDefault(
                                         x => x.AssignmentSubmissionsId == ent.Id && x.UserFileId == earlier.Id);
                                    if (fnd != null)
                                    {
                                        Context.AssignmentSubmissionFiles.Remove(fnd);
                                        Context.SaveChanges();
                                    }
                                }
                            }
                        }

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
