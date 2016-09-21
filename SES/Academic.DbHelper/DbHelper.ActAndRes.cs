using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.ViewModel.ActivityResource;

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

            public List<ActivityResourceViewModel> ListActivitiesAndResourcesOfSection(int sectionId)
            {
                var actres = Context.ActivityResource.Where(x => x.SubjectSectionId == sectionId 
                    && !(x.Void??false)).ToList();
                var list = new List<ActivityResourceViewModel>();
                foreach (var ar in actres)
                {
                    if (ar.ActivityOrResource)
                    {
                        //activity
                        switch (ar.ActivityOrResourceType)
                        {
                            case 1://Assignment
                                var asg = Context.Assignment.Find(ar.ActivityOrResourceId);
                                if (asg != null)
                                {
                                    //var imageurl = StaticValues.ActivityImages[ar.ActivityOrResourceType];
                                    //var url = "~/Views/ActivityResource/Assignments/AssignmentView.aspx";
                                    var m = new ActivityResourceViewModel()
                                    {
                                        ActivityOrResource = ar.ActivityOrResource
                                        ,ActivityResourceType = ar.ActivityOrResourceType
                                        ,ActivityResourceId = ar.ActivityOrResourceId
                                        ,Description = asg.Description
                                        ,Name = asg.Name
                                        ,SubjectSectionId = ar.SubjectSectionId
                                        ,Position = ar.Position
                                        ,
                                        NavigateUrl = "~/Views/ActivityResource/Assignments/AssignmentView.aspx"
                                        ,
                                        IconUrl =StaticValues.ActivityImages[ar.ActivityOrResourceType]
                                    };
                                    list.Add(m);
                                }
                               
                                break;

                        }
                    }
                    else
                    {
                       //resource

                    }
                }
                return list;
            }

            public DbEntities.ActivityAndResource.Assignment AddOrUpdateAssignment(DbEntities.ActivityAndResource.Assignment asg,
                int sectionId)
            {
                var ent = Context.Assignment.Find(asg.Id);
                if (ent == null)
                {
                    ent = Context.Assignment.Add(asg);
                    Context.SaveChanges();
                    int pos = 0;
                    var poslist = Context.ActivityResource.Where(x => x.SubjectSectionId == sectionId);
                    if (poslist.Any())
                        pos = poslist.Max(x => x.Position);
                    var actRes = new DbEntities.ActivityAndResource.ActivityResource()
                    {
                        ActivityOrResource = true,
                        ActivityOrResourceId = ent.Id
                        ,
                        ActivityOrResourceType = 1
                        ,
                        Position = pos + 1
                        ,
                        SubjectSectionId = sectionId
                    };
                    Context.ActivityResource.Add(actRes);
                    Context.SaveChanges();

                    //restriction

                    return ent;
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
