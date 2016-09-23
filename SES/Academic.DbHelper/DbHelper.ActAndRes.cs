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

            /// <summary>
            /// 
            /// </summary>
            /// <param name="actresId"> act/res Id</param>
            /// <param name="sectionId"> sectionId</param>
            private void AddActRes(bool actOrRes, byte actResType, int actresId, int sectionId)
            {
                int pos = 0;
                var poslist = Context.ActivityResource.Where(x => x.SubjectSectionId == sectionId);
                if (poslist.Any())
                    pos = poslist.Max(x => x.Position);
                var actRes = new DbEntities.ActivityAndResource.ActivityResource()
                {
                    ActivityOrResource = actOrRes,
                    ActivityResourceId = actresId
                    ,
                    ActivityResourceType = actResType
                    ,
                    Position = pos + 1
                    ,
                    SubjectSectionId = sectionId
                };
                Context.ActivityResource.Add(actRes);
                Context.SaveChanges();
            }

            public List<ActivityResourceViewModel> ListActivitiesAndResourcesOfSection(int sectionId)
            {
                var actres = Context.ActivityResource.Where(x => x.SubjectSectionId == sectionId
                                                                 && !(x.Void ?? false)).ToList();
                var list = new List<ActivityResourceViewModel>();
                foreach (var ar in actres)
                {
                    if (ar.ActivityOrResource)
                    {
                        //activity
                        switch (ar.ActivityResourceType)
                        {
                            case 1: //Assignment
                                var asg = Context.Assignment.Find(ar.ActivityResourceId);
                                if (asg != null)
                                {
                                    //var imageurl = StaticValues.ActivityImages[ar.ActivityOrResourceType];
                                    //var url = "~/Views/ActivityResource/Assignments/AssignmentView.aspx";
                                    var m = new ActivityResourceViewModel()
                                    {
                                        ActivityOrResource = ar.ActivityOrResource
                                        ,
                                        ActivityResourceType = ar.ActivityResourceType
                                        ,
                                        ActivityResourceId = ar.ActivityResourceId
                                        ,
                                        Description = asg.Description
                                        ,
                                        Name = asg.Name
                                        ,
                                        SubjectSectionId = ar.SubjectSectionId
                                        ,
                                        Position = ar.Position
                                        ,
                                        NavigateUrl = "~/Views/ActivityResource/Assignments/AssignmentView.aspx"
                                        ,
                                        IconUrl = StaticValues.ActivityImages[ar.ActivityResourceType]
                                    };
                                    list.Add(m);
                                }

                                break;

                        }
                    }
                    else
                    {
                        //resource
                        switch (ar.ActivityResourceType)
                        {

                            case 1://Book
                                var book = Context.BookResource.Find(ar.ActivityResourceId);
                                if (book != null)
                                {
                                    var m = new ActivityResourceViewModel()
                                    {
                                        ActivityOrResource = ar.ActivityOrResource
                                        ,
                                        ActivityResourceType = ar.ActivityResourceType
                                        ,
                                        ActivityResourceId = ar.ActivityResourceId
                                        ,
                                        Description = book.Description
                                        ,
                                        Name = book.Name
                                        ,
                                        SubjectSectionId = ar.SubjectSectionId
                                        ,
                                        Position = ar.Position
                                        ,
                                        NavigateUrl = "~/Views/ActivityResource/Book/BookView.aspx"
                                        ,
                                        IconUrl = StaticValues.ResourceImages[ar.ActivityResourceType]
                                    };
                                    list.Add(m);
                                }
                                break;
                            case 41:
                                break;

                        }
                    }
                }
                return list;
            }

            #region Assignment

            public DbEntities.ActivityAndResource.Assignment AddOrUpdateAssignment(
                DbEntities.ActivityAndResource.Assignment asg,
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
                        ActivityResourceId = ent.Id
                        ,
                        ActivityResourceType = 1
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

            #endregion




            #region Book

            public DbEntities.ActivityAndResource.BookResource AddOrUpdateBook(
               DbEntities.ActivityAndResource.BookResource book, int sectionId)
            {
                try
                {
                    var ent = Context.BookResource.Find(book.Id);
                    if (ent == null)
                    {
                        var restrictionn = new DbEntities.AccessPermission.Restriction()
                        {
                            MatchAllAny = false,
                            MatchMust = false,
                            Visibility = true

                        };

                        //restriction addition is remain
                        var restric = Context.Restriction.Add(restrictionn);
                        Context.SaveChanges();

                        book.RestrictionId = restric.Id;

                        ent = Context.BookResource.Add(book);
                        Context.SaveChanges();

                        AddActRes(false, 1, ent.Id, sectionId);

                    }
                    else
                    {
                        ent.ChapterFormatting = book.ChapterFormatting;
                        ent.CustomTitles = book.CustomTitles;
                        ent.Description = book.Description;
                        ent.DisplayDescriptionOnCourePage = book.DisplayDescriptionOnCourePage;
                        ent.Name = book.Name;
                        ent.StyleOfNavigation = book.StyleOfNavigation;

                        Context.SaveChanges();
                        //update restriction also;
                    }
                    return
                        ent;
                }

                catch
                {
                    return null;
                }
            }


            public DbEntities.ActivityAndResource.BookResource GetBook(int bookId)
            {
                return Context.BookResource.Find(bookId);
            }

           

            public List<DbEntities.ActivityAndResource.BookItems.BookChapter> GetTocOfBook(int bookId)
            {
                return Context.BookChapter.Where(x => x.BookId == bookId).ToList();
            }

            #endregion




            public DbEntities.ActivityAndResource.BookItems.BookChapter 
                AddOrUpdateBookChapter(DbEntities.ActivityAndResource.BookItems.BookChapter chapter)
            {
                var chap = Context.BookChapter.Find(chapter.Id);
                if (chap == null)
                {
                    chap = Context.BookChapter.Add(chapter);
                    Context.SaveChanges();
                }
                else
                {
                    chap.Content = chapter.Content;
                    chap.ParentChapterId = chapter.ParentChapterId;
                    chap.Title = chapter.Title;
                    Context.SaveChanges();
                }
                return chap;
            }
        }

    }

}
