using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.Database;
using Academic.DbEntities;
using Academic.DbEntities.ActivityAndResource.FileItems;
using Academic.ViewModel;
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
            private void SaveActivityResourceTable(bool actOrRes, byte actResType, int actresId, int sectionId)
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

                    var viewModel = new ActivityResourceViewModel()
                    {
                        ActivityOrResource = ar.ActivityOrResource
                        ,
                        ActivityResourceType = ar.ActivityResourceType
                        ,
                        ActivityResourceId = ar.ActivityResourceId
                        ,
                        SubjectSectionId = ar.SubjectSectionId
                        ,
                        Position = ar.Position
                        ,
                    };

                    if (ar.ActivityOrResource)
                    {
                        //activity

                        switch (ar.ActivityResourceType)
                        {
                            case 1: //Assignment
                                var asg = Context.Assignment.Find(ar.ActivityResourceId);
                                if (asg != null)
                                {
                                    viewModel.SetOtherValues(asg.Name, asg.Description
                                        , asg.DispalyDescriptionOnPage ?? false
                                        , "~/Views/ActivityResource/Assignments/AssignmentView.aspx"
                                        , StaticValues.ActivityImages[ar.ActivityResourceType]
                                        );
                                    list.Add(viewModel);
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
                                    viewModel.SetOtherValues(book.Name, book.Description
                                        , book.DisplayDescriptionOnCourePage
                                        , "~/Views/ActivityResource/Book/BookView.aspx"
                                        , StaticValues.ResourceImages[ar.ActivityResourceType]);
                                    list.Add(viewModel);
                                }
                                break;
                            case 2://file
                                var file = Context.FileResource.Find(ar.ActivityResourceId);
                                if (file != null)
                                {
                                    var mainFile = Context.FileResourceFiles.Find(file.MainFileId);
                                    if (mainFile != null)
                                    {
                                        viewModel.SetOtherValues(file.Name, file.Description
                                            , file.ShowDescriptionOnCoursePage
                                            , "~/Views/ActivityResource/FileResource/FileResourceView.aspx"
                                            , mainFile.SubFile.IconPath);
                                        list.Add(viewModel);
                                    }
                                }

                                break;
                            case (int)(StaticValues.Resources.Url + 1):
                                var url = Context.UrlResource.Find(ar.ActivityResourceId);
                                if (url != null)
                                {
                                    viewModel.SetOtherValues(url.Name, url.Description
                                        , url.DisplayDescriptionOnPage
                                        , "~/Views/ActivityResource/FileResource/FileResourceView.aspx"
                                        , StaticValues.ResourceImages[ar.ActivityResourceType]);
                                    list.Add(viewModel);
                                }
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

                        SaveActivityResourceTable(false, 1, ent.Id, sectionId);

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

            public List<DbEntities.ActivityAndResource.BookItems.BookChapter> GetChaptersOfBook(int bookId)
            {
                return Context.BookChapter.Where(x => x.BookId == bookId).OrderBy(x => x.Position).ToList();
            }

            public DbEntities.ActivityAndResource.BookItems.BookChapter
                      AddOrUpdateBookChapter(DbEntities.ActivityAndResource.BookItems.BookChapter chapter)
            {
                var chap = Context.BookChapter.Find(chapter.Id);
                if (chap == null)
                {
                    if (chapter.Position <= 0)
                    {
                        int pos = 0;

                        try
                        {
                            pos = Context.BookChapter.Where(x => x.BookId == chapter.BookId
                                                                 &&
                                                                 (x.ParentChapterId ?? 0) ==
                                                                 (chapter.ParentChapterId ?? 0))
                                .Max(x => x.Position);
                        }
                        catch
                        {
                        }
                        chapter.Position = pos + 1;
                        chap = Context.BookChapter.Add(chapter);
                        Context.SaveChanges();
                    }
                    else
                    {
                        chapter.Position = chapter.Position + 1;
                        chap = Context.BookChapter.Add(chapter);
                        Context.SaveChanges();

                    }

                }
                else
                {
                    chap.Content = chapter.Content;
                    chap.ParentChapterId = chapter.ParentChapterId;
                    chap.Title = chapter.Title;
                    chap.Position = chapter.Position;
                    Context.SaveChanges();
                }
                return chap;
            }

            public DbEntities.ActivityAndResource.BookItems.BookChapter GetChapter(int chapterId)
            {
                return Context.BookChapter.Find(chapterId);
            }

            public bool UpdateChapter(string action, int chapterId, int bookId)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        var chapter = Context.BookChapter.Find(chapterId);
                        if (chapter != null)
                        {
                            switch (action)
                            {
                                case "in":
                                    var upchapter = Context.BookChapter.FirstOrDefault(x =>
                                        x.Position == chapter.Position - 1
                                        && (x.ParentChapterId ?? 0) == (chapter.ParentChapterId ?? 0)
                                        && x.BookId == bookId);
                                    var pos = chapter.Position;
                                    var parChap = chapter.ParentChapterId ?? 0;

                                    var others = Context.BookChapter
                                        .Where(x => x.Position > pos
                                                    && x.BookId == bookId &&
                                                    (x.ParentChapterId ?? 0) == parChap);
                                    foreach (var bcn in others)
                                    {
                                        bcn.Position = bcn.Position - 1;
                                        Context.SaveChanges();
                                    }

                                    if (upchapter != null)
                                    {
                                        var po = 0;
                                        try
                                        {
                                            po = chapter.Position = Context.BookChapter.Where(x =>
                                                                                  (x.ParentChapterId ?? 0) == (upchapter.Id)
                                                                                     && x.BookId == bookId)
                                                                                 .Max(x => x.Position);

                                        }
                                        catch { }

                                        chapter.ParentChapterId = upchapter.Id;
                                        chapter.Position = po + 1;
                                        Context.SaveChanges();


                                    }
                                    break;
                                case "out":
                                    if (chapter.ParentChapter != null)
                                    {

                                        var newPos = chapter.ParentChapter.Position;
                                        //positions
                                        var innnerBelow = Context.BookChapter.Where(x => x.BookId == bookId
                                                                                         &&
                                                                                         (x.ParentChapterId ?? 0) ==
                                                                                         (chapter.ParentChapterId ?? 0)
                                                                                         && x.Position > chapter.Position);
                                        foreach (var bc in innnerBelow)
                                        {
                                            bc.Position = bc.Position - 1;
                                            Context.SaveChanges();
                                        }

                                        var outerBelow = Context.BookChapter.Where(x => x.BookId == bookId
                                                                                        && (x.ParentChapterId ?? 0) ==
                                                                                        (chapter.ParentChapter.ParentChapterId ?? 0)
                                                                                        && x.Position > chapter.ParentChapter.Position);
                                        foreach (var ob in outerBelow)
                                        {
                                            ob.Position = ob.Position + 1;
                                            Context.SaveChanges();
                                        }

                                        chapter.Position = newPos + 1;
                                        chapter.ParentChapterId = chapter.ParentChapter.ParentChapterId;
                                        Context.SaveChanges();


                                        //if (chapter.ParentChapter.ParentChapter != null)
                                        //{
                                        //    var other = Context.BookChapter.Where(x => x.BookId == bookId
                                        //                                               &&
                                        //                                               x.ParentChapterId ==
                                        //                                               chapter.ParentChapter.ParentChapterId
                                        //                                               &&
                                        //                                               x.Position >
                                        //                                               chapter.ParentChapter.Position);
                                        //    int currentPos = chapter.ParentChapter.Position;
                                        //    foreach (var o in other)
                                        //    {
                                        //        o.Position = o.Position + 1;
                                        //        Context.SaveChanges();
                                        //    }
                                        //    chapter.Position = currentPos + 1;
                                        //    chapter.ParentChapterId = chapter.ParentChapter.ParentChapterId;
                                        //    Context.SaveChanges();
                                        //}
                                        //Context.SaveChanges();
                                    }
                                    break;
                                case "move-up":
                                    if (chapter.Position > 1)
                                    {
                                        var justabove =
                                           Context.BookChapter.FirstOrDefault(
                                               x =>
                                                   x.BookId == bookId &&
                                                   (x.ParentChapterId ?? 0) == (chapter.ParentChapterId ?? 0)
                                                   && x.Position == chapter.Position - 1);

                                        if (justabove != null)
                                        {
                                            justabove.Position = chapter.Position;
                                            Context.SaveChanges();
                                        }
                                        chapter.Position = chapter.Position - 1;
                                        Context.SaveChanges();
                                    }
                                    break;
                                case "move-down":
                                    try
                                    {
                                        var all =
                                            Context.BookChapter.Where(
                                                x =>
                                                    x.BookId == bookId &&
                                                    (x.ParentChapterId ?? 0) == (chapter.ParentChapterId ?? 0));
                                        var max = all.Max(x => x.Position);
                                        if (max > chapter.Position)
                                        {
                                            var justbelow = all.FirstOrDefault(x => x.Position == chapter.Position + 1);
                                            if (justbelow != null)
                                            {
                                                justbelow.Position = chapter.Position;
                                                Context.SaveChanges();
                                            }
                                            chapter.Position = chapter.Position + 1;
                                            Context.SaveChanges();
                                        }
                                    }
                                    catch { }

                                    break;
                            }
                        }
                        scope.Complete();
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }

            public void UpdateBelowChapters(int bookId, int chapId, int parentId, int position)
            {
                {
                    //var cntx = new Academic.Database.AcademicContext();
                    var outerBelow = Context.BookChapter.Where(x => x.BookId == bookId
                                                                && (x.ParentChapterId ?? 0) ==
                                                                (parentId)
                                                                && x.Position >= position && x.Id != chapId).ToList();
                    foreach (var ob in outerBelow)
                    {
                        ob.Position = ob.Position + 1;
                        Context.SaveChanges();
                    }
                    Context.Dispose();
                }
            }


            #endregion


            #region File Resource

            public DbEntities.ActivityAndResource.FileResource
                AddOrUpdateFileResource(DbEntities.ActivityAndResource.FileResource file
                , List<DbEntities.Subjects.SubjectFile> fileList, int sectionId)
            {
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        var ent = Context.FileResource.Find(file.Id);
                        if (ent == null)
                        {
                            //get restriction from the ui not auto add
                            var restriction = new DbEntities.AccessPermission.Restriction()
                            {
                                Visibility = false,
                                MatchAllAny = false,
                                MatchMust = true,
                            };

                            var res = Context.Restriction.Add(restriction);
                            Context.SaveChanges();

                            file.RestrictionId = res.Id;
                            ent = Context.FileResource.Add(file);
                            Context.SaveChanges();

                            //files add
                            int i = 0;
                            foreach (var f in fileList)
                            {
                                var savedFile = Context.File.Add(f);
                                Context.SaveChanges();


                                var savedFileResFile = Context.FileResourceFiles.Add(new FileResourceFiles()
                                {
                                    FileResourceId = ent.Id
                                    ,
                                    SubFileId = savedFile.Id
                                    ,
                                });
                                Context.SaveChanges();

                                if (i == 0)
                                {
                                    ent.MainFileId = savedFileResFile.Id;
                                    Context.SaveChanges();
                                }

                                i++;
                            }
                            SaveActivityResourceTable(false, 2, ent.Id, sectionId);
                        }
                        else
                        {
                            ent.Name = file.Name;
                            ent.Description = file.Description;
                            ent.Display = file.Display;
                            ent.ShowUploadModifiedDate = file.ShowUploadModifiedDate;
                            ent.ShowDescriptionOnCoursePage = file.ShowDescriptionOnCoursePage;
                            ent.ShowSize = file.ShowSize;
                            ent.ShowType = file.ShowType;
                            ent.MainFileId = file.MainFileId;

                            //modify restriction here
                            Context.SaveChanges();

                        }
                        scope.Complete();
                        return ent;

                    }
                    catch
                    {
                        return null;
                    }

                }

            }

            public DbEntities.ActivityAndResource.FileResource GetFileResource(int fileResourceId)
            {
                return Context.FileResource.Find(fileResourceId);
            }

            public DbEntities.ActivityAndResource.FileItems.FileResourceFiles GetFileOfFileResource(int fileresourceFileId)
            {
                return Context.FileResourceFiles.Find(fileresourceFileId);
            }


            #endregion



            #region Url resource

            public DbEntities.ActivityAndResource.UrlResource AddOrUpdateUrlResource(
                DbEntities.ActivityAndResource.UrlResource url, int sectionId)
            {
                var ent = Context.UrlResource.Find(url.Id);
                if (ent == null)
                {
                    //get restriction from the ui not auto add
                    var restriction = new DbEntities.AccessPermission.Restriction()
                    {
                        Visibility = false,
                        MatchAllAny = false,
                        MatchMust = true,
                    };

                    var res = Context.Restriction.Add(restriction);
                    Context.SaveChanges();

                    url.RestrictionId = res.Id;
                    ent = Context.UrlResource.Add(url);
                    Context.SaveChanges();

                    SaveActivityResourceTable(false, (byte)(((int)StaticValues.Resources.Url) + 1), ent.Id, sectionId);

                }
                else
                {
                    ent.Display = url.Display;
                    ent.PopupWidthInPixel = url.PopupWidthInPixel;
                    ent.PopupHeightInPixel = url.PopupHeightInPixel;
                    ent.Name = url.Name;
                    ent.Description = url.Description;
                    ent.Url = url.Url;
                    Context.SaveChanges();

                }
                return ent;
            }

            #endregion


            public DbEntities.ActivityAndResource.UrlResource GetUrlResource(int urlId)
            {
                return Context.UrlResource.Find(urlId);
            }

        }

    }

}
