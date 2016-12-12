using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.Database;
using Academic.DbEntities;
using Academic.DbEntities.AccessPermission;
using Academic.DbEntities.ActivityAndResource;
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

            #region Constructor and Dispose()

            public ActAndRes()
            {
                Context = new AcademicContext();
            }
            public void Dispose()
            {
                Context.Dispose();
            }


            #endregion

            public Restriction AddOrUpdateRestriction(int parentId, Restriction restriction)
            {
                var found = Context.Restriction.Find(restriction.Id);
                if (found == null)
                {
                    #region If restriction doesn't exist

                    var newr = new Restriction()
                    {
                        Id = restriction.Id,
                        MatchMust = restriction.MatchMust,
                        MatchAllAny = restriction.MatchAllAny,
                        Visibility = restriction.Visibility
                    };
                    if (parentId > 0)
                        newr.ParentId = parentId;

                    //restriction.ParentId = parentId;
                    var savedRes = Context.Restriction.Add(newr);
                    Context.SaveChanges();

                    if (restriction.GradeRestrictions != null)
                        restriction.GradeRestrictions.ToList().ForEach(g =>
                        {
                            g.RestrictionId = savedRes.Id;
                            Context.GradeRestriction.Add(g);
                            Context.SaveChanges();
                        });

                    if (restriction.GroupRestrictions != null)
                        restriction.GroupRestrictions.ToList().ForEach(g =>
                        {
                            g.RestrictionId = savedRes.Id;
                            Context.GroupRestriction.Add(g);
                            Context.SaveChanges();
                        });

                    if (restriction.DateRestrictions != null)
                        restriction.DateRestrictions.ToList().ForEach(g =>
                        {
                            g.RestrictionId = savedRes.Id;
                            Context.DateRestriction.Add(g);
                            Context.SaveChanges();
                        });

                    if (restriction.UserProfileRestrictions != null)
                        restriction.UserProfileRestrictions.ToList().ForEach(g =>
                        {
                            g.RestrictionId = savedRes.Id;
                            Context.UserProfileRestriction.Add(g);
                            Context.SaveChanges();
                        });

                    Context.SaveChanges();
                    if (restriction.Restrictions != null)
                        foreach (var model in restriction.Restrictions)
                        {
                            AddOrUpdateRestriction(savedRes.Id, model);
                        }
                    return savedRes;

                    #endregion
                }
                else
                {
                    #region if Restriction exist

                    //delete also here..
                    found.MatchAllAny = restriction.MatchAllAny;
                    found.MatchMust = restriction.MatchMust;
                    found.Visibility = restriction.Visibility;
                    Context.SaveChanges();


                    //int earlierInDb = 0, deleted = 0, added = 0, ;

                    #region Grade

                    var givenGrades = (restriction.GradeRestrictions ?? new List<GradeRestriction>()).Select(x => x.Id);
                    var gradesFromDb = found.GradeRestrictions.Select(x => x.Id).Except(givenGrades).ToList();
                    foreach (var g in gradesFromDb)
                    {
                        var res = Context.GradeRestriction.Find(g);
                        if (res != null)
                        {
                            Context.GradeRestriction.Remove(res);
                        }
                    }

                    if (restriction.GradeRestrictions != null)
                    {
                        restriction.GradeRestrictions.ToList().ForEach(g =>
                        {
                            var fgrade = Context.GradeRestriction.Find(g.Id);
                            if (fgrade == null)
                            {
                                g.RestrictionId = found.Id;
                                Context.GradeRestriction.Add(g);
                                Context.SaveChanges();
                            }
                            else
                            {
                                fgrade.ActivityResourceId = g.ActivityResourceId;
                                fgrade.GreaterThanOrEqualToValue = g.GreaterThanOrEqualToValue;
                                fgrade.MustBeGreaterThanOrEqualTo = g.MustBeGreaterThanOrEqualTo;
                                fgrade.LessThanValue = g.LessThanValue;
                                fgrade.MustBeLessThan = g.MustBeLessThan;
                            }

                        });
                    }

                    #endregion

                    #region Group

                    var given = (restriction.GroupRestrictions ?? new List<GroupRestriction>()).Select(x => x.Id);
                    var grpResDb = found.GroupRestrictions.Select(x => x.Id).Except(given).ToList();
                    foreach (var g in grpResDb)
                    {
                        var res = Context.GroupRestriction.Find(g);
                        if (res != null)
                        {
                            Context.GroupRestriction.Remove(res);
                        }
                    }

                    if (restriction.GroupRestrictions != null)
                    {
                        restriction.GroupRestrictions.ToList().ForEach(g =>
                        {
                            var fgrp = Context.GroupRestriction.Find(g.Id);
                            if (fgrp == null)
                            {
                                g.RestrictionId = found.Id;
                                Context.GroupRestriction.Add(g);
                                Context.SaveChanges();
                            }
                            else
                            {
                                //fgrp.ClassOrGroup = g.ClassOrGroup;
                                fgrp.GroupId = g.GroupId;
                                fgrp.SubjectClassId = g.SubjectClassId;
                            }

                        });
                    }

                    #endregion

                    #region Date

                    var givenDates = (restriction.DateRestrictions ?? new List<DateRestriction>()).Select(x => x.Id);
                    var datesFromDb = found.DateRestrictions.Select(x => x.Id).Except(givenDates).ToList();
                    foreach (var g in datesFromDb)
                    {
                        var res = Context.DateRestriction.Find(g);
                        if (res != null)
                        {
                            Context.DateRestriction.Remove(res);
                        }
                    }

                    if (restriction.DateRestrictions != null)
                        restriction.DateRestrictions.ToList().ForEach(g =>
                        {
                            var fdate = Context.DateRestriction.Find(g.Id);
                            if (fdate == null)
                            {
                                g.RestrictionId = found.Id;
                                Context.DateRestriction.Add(g);
                                Context.SaveChanges();
                            }
                            else
                            {
                                fdate.Constraint = g.Constraint;
                                fdate.Date = g.Date;
                                //fdate.Time = g.Time;
                            }
                        });

                    #endregion

                    #region UserProfile

                    var givenUser = (restriction.UserProfileRestrictions ?? new List<UserProfileRestriction>()).Select(x => x.Id);
                    var userFromDb = found.UserProfileRestrictions.Select(x => x.Id).Except(givenUser).ToList();
                    foreach (var g in userFromDb)
                    {
                        var res = Context.UserProfileRestriction.Find(g);
                        if (res != null)
                        {
                            Context.UserProfileRestriction.Remove(res);
                        }
                    }

                    if (restriction.UserProfileRestrictions != null)
                        restriction.UserProfileRestrictions.ToList().ForEach(g =>
                        {
                            var fuser = Context.UserProfileRestriction.Find(g.Id);
                            if (fuser == null)
                            {
                                g.RestrictionId = found.Id;
                                Context.UserProfileRestriction.Add(g);
                                Context.SaveChanges();
                            }
                            else
                            {
                                fuser.Value = g.Value;
                                fuser.Constraint = g.Constraint;
                                fuser.FieldName = g.FieldName;
                            }
                        });

                    #endregion

                    Context.SaveChanges();

                    if ((found.ParentId ?? 0) > 0)
                    {
                        var cntgrade = found.GradeRestrictions.Count;
                        var cntdate = found.DateRestrictions.Count;
                        var cntuser = found.UserProfileRestrictions.Count;
                        var cntgroup = found.GroupRestrictions.Count;

                        if ((cntgrade + cntdate + cntuser + cntgroup) == 0)
                        {
                            if (found.Restrictions.Count == 0)
                                if (restriction.Restrictions != null && restriction.Restrictions.Count == 0)
                                {

                                }
                        }

                    }


                    if (restriction.Restrictions != null)
                        foreach (var model in restriction.Restrictions)
                        {
                            AddOrUpdateRestriction(found.Id, model);
                        }

                    return found;

                    #endregion
                }

            }


            private void SaveActivityResourceTable(bool actOrRes, byte actResType, int actresId
                , int sectionId, string name, Restriction restriction)
            {
                int pos = 0;
                var poslist = Context.ActivityResource.Where(x => x.SubjectSectionId == sectionId);
                if (poslist.Any())
                    pos = poslist.Max(x => x.Position);


                #region Restriction

                var res = AddOrUpdateRestriction(0, restriction);

                #endregion

                #region ActivityResource

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
                                   ,
                                   RestrictionId = res.Id
                                   ,
                                   Name = name,
                               };
                Context.ActivityResource.Add(actRes);
                Context.SaveChanges();

                #endregion


            }

            private bool EvaluateRestriction(Academic.DbEntities.User.Users user, Restriction res)
            {
                string message = "";
                var validation = new List<bool>();

                //grade
                var date = DateTime.Now;

                if (res != null)
                {

                    #region Grade Restriction

                    foreach (var gres in res.GradeRestrictions)
                    {
                        var grade = gres.ActivityResource.ActivityGradings.FirstOrDefault(x => x.UserId == user.Id);
                        if (grade != null)
                        {
                            bool greater = true, lesser = true;
                            if (grade.ObtainedGrade != null)
                            {
                                //grade was choosen from list
                                //percent

                                if ((grade.ObtainedGrade.Grade.GradeValueIsInPercentOrPostition ?? false))
                                {
                                    #region Grade is in percent %

                                    if (gres.MustBeGreaterThanOrEqualTo)
                                    {
                                        if ((grade.ObtainedGrade.EquivalentPercentOrPostition ?? 0) < (gres.GreaterThanOrEqualToValue ?? 0))
                                        {
                                            greater = false;
                                        }
                                    }
                                    if (gres.MustBeLessThan)
                                    {
                                        if ((grade.ObtainedGrade.EquivalentPercentOrPostition ?? 0) >= (gres.GreaterThanOrEqualToValue ?? 0))
                                        {
                                            lesser = false;
                                        }
                                    }

                                    #endregion
                                }
                                else
                                {
                                    #region Grade is in position

                                    var maxPos =
                                                grade.ObtainedGrade.Grade.GradeValues.Max(
                                                    x => x.EquivalentPercentOrPostition);
                                    if (maxPos > 0)
                                    {
                                        var obtPercent = (1.0 * (grade.ObtainedGrade.EquivalentPercentOrPostition ?? 0) /
                                                          maxPos) * 100;
                                        if (gres.MustBeGreaterThanOrEqualTo)
                                        {
                                            if (obtPercent < (gres.GreaterThanOrEqualToValue ?? 0))
                                            {
                                                greater = false;
                                            }
                                        }
                                        if (gres.MustBeLessThan)
                                        {
                                            if (obtPercent >= (gres.GreaterThanOrEqualToValue ?? 0))
                                            {
                                                lesser = false;
                                            }
                                        }
                                    }

                                    #endregion
                                }
                            }
                            else
                            {
                                //values , not range..
                                if (gres.MustBeGreaterThanOrEqualTo)
                                {
                                    if ((grade.ObtainedGradeMarks ?? 0) < (gres.GreaterThanOrEqualToValue ?? 0))
                                    {
                                        greater = false;
                                    }
                                }
                                if (gres.MustBeLessThan)
                                {
                                    if ((grade.ObtainedGradeMarks ?? 0) >= (gres.GreaterThanOrEqualToValue ?? 0))
                                    {
                                        lesser = false;
                                    }
                                }
                            }
                            validation.Add(greater && lesser);
                        }
                        else
                        {
                            validation.Add(false);
                        }
                        //dont copy this.. copyright @companyNeption 
                    }

                    #endregion

                    #region DateRestriction

                    foreach (var dr in res.DateRestrictions)
                    {
                        if (dr.Constraint)
                        {
                            //until
                            validation.Add(date < dr.Date);
                        }
                        else
                        {
                            //from
                            validation.Add(date > dr.Date);
                        }
                    }

                    #endregion


                    #region Class

                    foreach (var cls in res.GroupRestrictions)
                    {
                        var lsd = cls.SubjectClass.ClassUsers.FirstOrDefault(x => x.UserId == user.Id);
                        validation.Add(lsd != null);
                    }

                    #endregion


                    #region UserProfile

                    foreach (var usr in res.UserProfileRestrictions)
                    {
                        switch (usr.FieldName)
                        {
                            case "Username":
                                switch (usr.Constraint)
                                {
                                    case 0:
                                        validation.Add(user.UserName.Equals(usr.Value));
                                        break;
                                    case 1:
                                        validation.Add(user.UserName.Contains(usr.Value));
                                        break;
                                    case 2:
                                        validation.Add(!user.UserName.Contains(usr.Value));
                                        break;
                                    case 3:
                                        validation.Add(user.UserName.StartsWith(usr.Value));
                                        break;
                                    case 4:
                                        validation.Add(user.UserName.EndsWith(usr.Value));
                                        break;
                                }
                                break;
                            case "First name":
                                switch (usr.Constraint)
                                {
                                    case 0:
                                        validation.Add(user.FirstName.Equals(usr.Value));
                                        break;
                                    case 1:
                                        validation.Add(user.FirstName.Contains(usr.Value));
                                        break;
                                    case 2:
                                        validation.Add(!user.FirstName.Contains(usr.Value));
                                        break;
                                    case 3:
                                        validation.Add(user.FirstName.StartsWith(usr.Value));
                                        break;
                                    case 4:
                                        validation.Add(user.FirstName.EndsWith(usr.Value));
                                        break;
                                }
                                break;
                            case "Middle name":
                                switch (usr.Constraint)
                                {
                                    case 0:
                                        validation.Add(user.MiddleName.Equals(usr.Value));
                                        break;
                                    case 1:
                                        validation.Add(user.MiddleName.Contains(usr.Value));
                                        break;
                                    case 2:
                                        validation.Add(!user.MiddleName.Contains(usr.Value));
                                        break;
                                    case 3:
                                        validation.Add(user.MiddleName.StartsWith(usr.Value));
                                        break;
                                    case 4:
                                        validation.Add(user.MiddleName.EndsWith(usr.Value));
                                        break;
                                }
                                break;
                            case "Last name":
                                switch (usr.Constraint)
                                {
                                    case 0:
                                        validation.Add(user.LastName.Equals(usr.Value));
                                        break;
                                    case 1:
                                        validation.Add(user.LastName.Contains(usr.Value));
                                        break;
                                    case 2:
                                        validation.Add(!user.LastName.Contains(usr.Value));
                                        break;
                                    case 3:
                                        validation.Add(user.LastName.StartsWith(usr.Value));
                                        break;
                                    case 4:
                                        validation.Add(user.LastName.EndsWith(usr.Value));
                                        break;
                                }
                                break;
                            case "Email":
                                switch (usr.Constraint)
                                {
                                    case 0:
                                        validation.Add(user.Email.Equals(usr.Value));
                                        break;
                                    case 1:
                                        validation.Add(user.Email.Contains(usr.Value));
                                        break;
                                    case 2:
                                        validation.Add(!user.Email.Contains(usr.Value));
                                        break;
                                    case 3:
                                        validation.Add(user.Email.StartsWith(usr.Value));
                                        break;
                                    case 4:
                                        validation.Add(user.Email.EndsWith(usr.Value));
                                        break;
                                }
                                break;
                        }
                    }

                    #endregion


                    #region Overall

                    if (res.MatchMust)
                    {
                        if (res.MatchAllAny)
                        {
                            //if (validation.Contains(false))
                            //    return false;
                            //else return true;
                            return !validation.Contains(false);
                        }
                        else
                        {
                            //if (validation.Contains(true))
                            //    return true;
                            //else return false;
                            return validation.Contains(true);
                        }
                    }
                    else
                    {
                        if (res.MatchAllAny)
                        {
                            //must not match all.. sabai milnu bhayena
                            //if (validation.Contains(false))
                            //    return true;
                            //else return false;
                            return validation.Contains(false);
                        }
                        else
                        {
                            //must not match any..kunai pani milnu bhayena
                            //if (validation.Contains(true))
                            //    return false;
                            //else return true;
                            return !validation.Contains(true);
                        }
                    }


                    #endregion
                }
                return true;
            }

            public List<ActivityResource> ListActivitiesOfCourse(int courseId)
            {
                using (var helper = new DbHelper.Subject())
                {
                    var course = helper.Find(courseId);
                    if (course != null)
                    {
                        var lst = new List<Academic.DbEntities.ActivityAndResource.ActivityResource>();
                        course.SubjectSections.Where(x => !(x.Void ?? false)).ToList().ForEach(x =>
                        {
                            var activities = x.ActivityResources.Where(n => !(n.Void ?? false) && n.ActivityOrResource)
                                 .OrderBy(o => o.Name).ToList();
                            lst.AddRange(activities);
                        });
                        if (lst.Count > 0)
                            return lst.OrderBy(x=>x.Name).ToList();
                        return new List<ActivityResource>() { new ActivityResource() { Id = 0, Name = "" } };
                        //ddlActivityChoose.DataSource = lst;
                        //ddlActivityChoose.DataBind();
                    }
                }
                return new List<ActivityResource>() { new ActivityResource() { Id = 0, Name = "" } };
            }

            public List<ActivityResourceViewModel> ListActivitiesAndResourcesOfSection(int userId, int sectionId, bool elligible = false)
            {
                var actres = Context.ActivityResource.Where(x => x.SubjectSectionId == sectionId
                                                                 && !(x.Void ?? false)).ToList();
                var list = new List<ActivityResourceViewModel>();
                var user = Context.Users.Find(userId);

                #region Commented

                //var first = actres.FirstOrDefault();
                //var elligible = false;
                //if (first != null)
                //{
                //    var subjectId = first.SubjectSection.Subject.Id;
                //    using (var helper = new DbHelper.Classes())
                //    {
                //        //Context.UserClass.Any(x=>x.subje)
                //        var roles = user.UserRoles.Select(x => x.Role.RoleName).ToList();
                //if (roles.Contains(StaticValues.Roles.CourseEditor.ToString())
                //            || roles.Contains(StaticValues.Roles.Manager.ToString())
                //            || roles.Contains(StaticValues.Roles.Admin))
                //        {
                //            elligible = true;
                //        }
                //        else
                //        {
                //            //teacher
                //            elligible = (helper.IsUserElligibleToViewSubjectSection(subjectId, userId));
                //        }
                //    }
                //}

                #endregion


                if (user != null)
                {
                    foreach (var ar in actres)
                    {
                        var canView = elligible;
                        if (!canView)
                            canView = EvaluateRestriction(user, ar.Restriction);
                        if (canView)//
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
                                //newly added
                                //,
                                //NavigateUrl = value.ViewUrl
                                //,
                                //IconUrl = value.IconPath

                            };

                            if (ar.ActivityOrResource)
                            {
                                //activity

                                switch (ar.ActivityResourceType - 1)
                                {
                                    case (int)Enums.Activities.Assignment: //Assignment
                                        var asg = Context.Assignment.Find(ar.ActivityResourceId);
                                        if (asg != null)
                                        {
                                            var v = ActivityResourceValues.AssignmentActivity();
                                            viewModel.SetOtherValues(asg.Name
                                                , (asg.DispalyDescriptionOnPage ?? false) ? asg.Description : ""
                                                , asg.DispalyDescriptionOnPage ?? false
                                                , v.ViewUrl, v.IconPath, v.CreateUrl);
                                            list.Add(viewModel);
                                        }
                                        break;
                                    case (int)Enums.Activities.Chat: //chat

                                        break;

                                    case (int)Enums.Activities.Forum: //forum
                                        var forum = Context.ForumActivity.Find(ar.ActivityResourceId);
                                        if (forum != null)
                                        {
                                            var v = ActivityResourceValues.ForumActivity();
                                            viewModel.SetOtherValues(forum.Name
                                                , (forum.DisplayDescriptionOnCoursePage ? forum.Description : "")
                                                , forum.DisplayDescriptionOnCoursePage
                                                , v.ViewUrl, v.IconPath, v.CreateUrl);
                                            list.Add(viewModel);
                                        }
                                        break;
                                    case (int)Enums.Activities.Choice:
                                        var choice = Context.ChoiceActivity.Find(ar.ActivityResourceId);
                                        if (choice != null)
                                        {
                                            var v = ActivityResourceValues.ChoiceActivity();
                                            viewModel.SetOtherValues(choice.Name
                                                , (choice.DisplayDescriptionOnCoursePage ? choice.Description : "")
                                                , choice.DisplayDescriptionOnCoursePage
                                                , v.ViewUrl, v.IconPath, v.CreateUrl);
                                            list.Add(viewModel);
                                        }
                                        break;
                                    case (int)Enums.Activities.Lession: //lession

                                        break;
                                    case (int)Enums.Activities.Wiki: //wiki

                                        break;
                                    case (int)Enums.Activities.Workshop: //Workshop

                                        break;
                                }
                            }
                            else
                            {
                                //resource
                                switch ((ar.ActivityResourceType - 1))
                                {

                                    case (int)Enums.Resources.Book: //Book
                                        var book = Context.BookResource.Find(ar.ActivityResourceId);
                                        if (book != null)
                                        {
                                            var v = ActivityResourceValues.BookResource();
                                            viewModel.SetOtherValues(book.Name,
                                                book.DisplayDescriptionOnCourePage ? book.Description : ""
                                                , book.DisplayDescriptionOnCourePage
                                                , v.ViewUrl, v.IconPath, v.CreateUrl);
                                            list.Add(viewModel);
                                        }
                                        break;

                                    case (int)Enums.Resources.File: //file
                                        var file = Context.FileResource.Find(ar.ActivityResourceId);
                                        if (file != null)
                                        {
                                            var mainFile = Context.FileResourceFiles.Find(file.MainFileId);
                                            var v = ActivityResourceValues.FileResource();
                                            viewModel.SetOtherValues(file.Name,
                                                file.ShowDescriptionOnCoursePage ? file.Description : ""
                                                , file.ShowDescriptionOnCoursePage,
                                                v.ViewUrl
                                                , (mainFile == null)
                                                    ? "~/Content/Icons/ActivityResource/File/any_file_icon.png"
                                                    : mainFile.SubFile.IconPath
                                                , v.CreateUrl
                                                );
                                            list.Add(viewModel);
                                            //if (mainFile != null)
                                            //{

                                            //}
                                            //else
                                            //{
                                            //    var v = ActivityResourceValues.FileResource();
                                            //    viewModel.SetOtherValues(file.Name,
                                            //        file.ShowDescriptionOnCoursePage ? file.Description : ""
                                            //        , file.ShowDescriptionOnCoursePage,
                                            //        v.ViewUrl, "", v.CreateUrl
                                            //        );
                                            //    list.Add(viewModel);
                                            //}
                                        }

                                        break;
                                    case (int)Enums.Resources.Folder:

                                        break;

                                    case (int)(Enums.Resources.Label):
                                        var label = Context.LabelResource.Find(ar.ActivityResourceId);
                                        if (label != null)
                                        {
                                            var v = ActivityResourceValues.LabelResource();
                                            viewModel.SetOtherValues(label.Text, ""
                                                , false, "", "", v.CreateUrl, false);
                                            list.Add(viewModel);
                                        }
                                        break;

                                    case (int)(Enums.Resources.Page):
                                        var page = Context.PageResource.Find(ar.ActivityResourceId);
                                        if (page != null)
                                        {
                                            var v = ActivityResourceValues.PageResource();
                                            viewModel.SetOtherValues(page.Name,
                                                page.DisplayDescriptionOnPage ? page.Description : ""
                                                , page.DisplayDescriptionOnPage, v.ViewUrl, v.IconPath, v.CreateUrl);
                                            list.Add(viewModel);
                                        }
                                        break;

                                    case (int)(Enums.Resources.Url):
                                        var url = Context.UrlResource.Find(ar.ActivityResourceId);
                                        if (url != null)
                                        {
                                            var v = ActivityResourceValues.UrlResource();
                                            viewModel.SetOtherValues(url.Name,
                                                url.DisplayDescriptionOnPage ? url.Description : ""
                                                , url.DisplayDescriptionOnPage, v.ViewUrl, v.IconPath, v.CreateUrl);
                                            list.Add(viewModel);
                                        }
                                        break;

                                }
                            }
                        }
                    }
                }
                return list;
            }

            //========================= ACTIVITY===================//

            #region Assignment

            //AddOrUpdate
            public DbEntities.ActivityAndResource.Assignment AddOrUpdateAssignmentActivity(
                DbEntities.ActivityAndResource.Assignment asg,
                int sectionId
                , Restriction restriction)
            {
                using (var scope = new TransactionScope())
                {
                    var ent = Context.Assignment.Find(asg.Id);
                    if (ent == null)
                    {
                        ent = Context.Assignment.Add(asg);
                        Context.SaveChanges();

                        SaveActivityResourceTable(true, (byte)(((int)Enums.Activities.Assignment) + 1), ent.Id, sectionId,
                            asg.Name, restriction);

                        //return ent;
                    }
                    else
                    {
                        //ent.CutOffDate = asg.CutOffDate;
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
                    }
                    var ar =
                        Context.ActivityResource.FirstOrDefault(
                            x => !x.ActivityOrResource && x.ActivityResourceId == ent.Id
                                 && x.ActivityResourceType == (byte)(((int)Enums.Activities.Assignment) + 1));
                    if (ar != null)
                    {
                        ar.Name = asg.Name;
                        Context.SaveChanges();
                    }
                    scope.Complete();

                    return ent;
                }
            }


            public Assignment GetAssignment(int assignmentId)
            {
                return Context.Assignment.Find(assignmentId);
            }



            #endregion


            #region Forum Activity

            public DbEntities.ActivityAndResource.ForumActivity GetForumActivity(int forumId)
            {
                return Context.ForumActivity.Find(forumId);
            }

            public DbEntities.ActivityAndResource.ForumItems.ForumDiscussion GetForumDiscussion(int discussionId)
            {
                return Context.ForumDiscussion.Find(discussionId);
            }

            public DbEntities.ActivityAndResource.ForumActivity AddOrUpdateForumActivity(
                DbEntities.ActivityAndResource.ForumActivity forum, int sectionId, Restriction restriction)
            {
                using (var scope = new TransactionScope())
                {
                    var ent = Context.ForumActivity.Find(forum.Id);
                    if (ent == null)
                    {
                        //get restriction from the ui not auto add
                        //var restriction = new DbEntities.AccessPermission.Restriction()
                        //{
                        //    Visibility = false,
                        //    MatchAllAny = false,
                        //    MatchMust = true,
                        //};

                        //var res = Context.Restriction.Add(restriction);
                        //Context.SaveChanges();

                        //forum.RestrictionId = res.Id;

                        ent = Context.ForumActivity.Add(forum);
                        Context.SaveChanges();

                        SaveActivityResourceTable(true, (byte)(((int)Enums.Activities.Forum) + 1), ent.Id, sectionId, forum.Name, restriction);

                    }
                    else
                    {
                        ent.DisplayDescriptionOnCoursePage = forum.DisplayDescriptionOnCoursePage;
                        ent.DisplayWordCount = forum.DisplayWordCount;
                        ent.MaximumAttachmentSize = forum.MaximumAttachmentSize;
                        ent.MaximumNoOfAttachments = forum.MaximumNoOfAttachments;
                        ent.PostThresholdForBlocking = forum.PostThresholdForBlocking;
                        ent.PostThresholdForWarning = forum.PostThresholdForWarning;
                        ent.ReadTracking = forum.ReadTracking;
                        ent.SubscriptionMode = forum.SubscriptionMode;
                        ent.TimePeriodForBlocking = forum.TimePeriodForBlocking;

                        ent.Description = forum.Description;
                        ent.Name = forum.Name;
                        ent.ForumType = forum.ForumType;
                        ent.SubscriptionMode = forum.SubscriptionMode;

                        Context.SaveChanges();

                        var ar =
                       Context.ActivityResource.FirstOrDefault(
                           x => !x.ActivityOrResource && x.ActivityResourceId == ent.Id
                                && x.ActivityResourceType == (byte)(((int)Enums.Activities.Forum) + 1));
                        if (ar != null)
                        {
                            ar.Name = forum.Name;
                            Context.SaveChanges();
                        }

                    }
                    scope.Complete();
                    return ent;

                }
            }

            public DbEntities.ActivityAndResource.ForumItems.ForumDiscussion
                AddOrUpdateDiscussion
                (int userId, DbEntities.ActivityAndResource.ForumItems.ForumDiscussion disc)
            {
                using (var scope = new TransactionScope())
                {
                    var ent = Context.ForumDiscussion.Find(disc.Id);
                    if (ent == null)
                    {
                        ent = Context.ForumDiscussion.Add(disc);
                        Context.SaveChanges();

                    }
                    else
                    {
                        ent.ParentDiscussionId = disc.ParentDiscussionId;
                        ent.Closed = disc.Closed;
                        ent.Message = disc.Message;
                        ent.Subject = disc.Subject;
                        ent.UpdatedBy = userId;
                        ent.LastUpdateDate = DateTime.Now;

                        Context.SaveChanges();
                    }
                    scope.Complete();
                    return ent;

                }
            }

            public List<DbEntities.ActivityAndResource.ForumItems.ForumDiscussion> ListParentDiscussionsOfForum(int forumId)
            {
                return Context.ForumDiscussion.Where(x => (x.ParentDiscussionId ?? 0) == 0 && x.ForumActivityId == forumId).ToList();
            }


            #endregion


            #region Choice activity


            public DbEntities.ActivityAndResource.ChoiceActivity AddOrUpdateChoiceActivity
                (DbEntities.ActivityAndResource.ChoiceActivity choice
                , List<DbEntities.ActivityAndResource.ChoiceItems.ChoiceOptions> choiceOptions
                , int sectionId
                , Restriction restriction)
            {
                using (var scope = new TransactionScope())
                {
                    var ent = Context.ChoiceActivity.Find(choice.Id);
                    if (ent == null)
                    {
                        //get restriction from the ui not auto add
                        //var restriction = new DbEntities.AccessPermission.Restriction()
                        //{
                        //    Visibility = false,
                        //    MatchAllAny = false,
                        //    MatchMust = true,
                        //};

                        //var res = Context.Restriction.Add(restriction);
                        //Context.SaveChanges();

                        //choice.RestrictionId = res.Id;

                        ent = Context.ChoiceActivity.Add(choice);
                        Context.SaveChanges();

                        SaveActivityResourceTable(true, (byte)(((int)Enums.Activities.Choice) + 1), ent.Id, sectionId, choice.Name, restriction);

                        foreach (var o in choiceOptions)
                        {
                            o.ChoiceActivityId = ent.Id;
                            Context.ChoiceOptions.Add(o);
                            Context.SaveChanges();
                        }

                    }
                    else
                    {
                        ent.Name = choice.Name;
                        ent.Description = choice.Description;
                        ent.DisplayDescriptionOnCoursePage = choice.DisplayDescriptionOnCoursePage;
                        ent.DisplayModeForOptions = choice.DisplayModeForOptions;

                        ent.AllowChoiceTobeUpdated = choice.AllowChoiceTobeUpdated;
                        ent.AllowMoreThanOneChoiceToBeSelected = choice.AllowMoreThanOneChoiceToBeSelected;
                        ent.LimitTheNumberOfResponsesAllowed = choice.LimitTheNumberOfResponsesAllowed;

                        //options

                        ent.RestrictTimePeriod = choice.RestrictTimePeriod;
                        if (choice.RestrictTimePeriod)
                        {
                            ent.OpenDate = choice.OpenDate;
                            ent.UntilDate = choice.UntilDate;
                        }
                        else
                        {
                            ent.OpenDate = null;
                            ent.UntilDate = null;
                        }
                        ent.ShowPreview = choice.ShowPreview;


                        ent.PublishResults = choice.PublishResults;
                        if (ent.PublishResults == 0)
                        {
                            ent.PrivacyOfResults = false;
                            ent.ShowColumnForUnAnswered = false;
                            ent.IncludeResponsesFromInactiveUsers = false;
                        }
                        else
                        {
                            ent.PrivacyOfResults = choice.PrivacyOfResults;
                            ent.ShowColumnForUnAnswered = choice.ShowColumnForUnAnswered;
                            ent.IncludeResponsesFromInactiveUsers = choice.IncludeResponsesFromInactiveUsers;
                        }


                        Context.SaveChanges();
                        var ar =
                       Context.ActivityResource.FirstOrDefault(
                           x => !x.ActivityOrResource && x.ActivityResourceId == ent.Id
                                && x.ActivityResourceType == (byte)(((int)Enums.Activities.Choice) + 1));
                        if (ar != null)
                        {
                            ar.Name = choice.Name;
                            Context.SaveChanges();
                        }

                    }
                    scope.Complete();
                    return ent;
                }

            }

            public DbEntities.ActivityAndResource.ChoiceActivity GetChoiceActivity(int choiceId)
            {
                return Context.ChoiceActivity.Find(choiceId);
            }

            public DbEntities.ActivityAndResource.ChoiceItems.ChoiceOptions GetChoiceOptions(int choiceId)
            {
                return Context.ChoiceOptions.Find(choiceId);
            }

            public bool SaveChoice(List<DbEntities.ActivityAndResource.ChoiceItems.ChoiceUser> selectedChoices
                , List<DbEntities.ActivityAndResource.ChoiceItems.ChoiceUser> removedChoices)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        foreach (var co in selectedChoices)
                        {
                            var opt = Context.ChoiceUser.Find(co.Id);
                            if (opt == null)
                            {
                                Context.ChoiceUser.Add(co);
                                Context.SaveChanges();
                            }
                            else
                            {
                                opt.ChoiceOptionsId = co.ChoiceOptionsId;
                                Context.SaveChanges();
                            }
                        }
                        foreach (var co in removedChoices)
                        {
                            var opt = Context.ChoiceUser.Find(co.Id);
                            if (opt != null)
                            {
                                Context.ChoiceUser.Remove(opt);
                                Context.SaveChanges();
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


            #endregion


            //======================= RESOURCES =================//

            #region Book

            public DbEntities.ActivityAndResource.BookResource AddOrUpdateBook(
               DbEntities.ActivityAndResource.BookResource book, int sectionId, Restriction restriction)
            {

                try
                {
                    using (var scope = new TransactionScope())
                    {
                        var ent = Context.BookResource.Find(book.Id);
                        if (ent == null)
                        {
                            //var restrictionn = new DbEntities.AccessPermission.Restriction()
                            //{
                            //    MatchAllAny = false,
                            //    MatchMust = false,
                            //    Visibility = true

                            //};

                            ////restriction addition is remain
                            //var restric = Context.Restriction.Add(restrictionn);
                            //Context.SaveChanges();

                            //book.RestrictionId = restric.Id;

                            ent = Context.BookResource.Add(book);
                            Context.SaveChanges();

                            SaveActivityResourceTable(false, (byte)(((int)Enums.Resources.Book) + 1), ent.Id, sectionId, book.Name, restriction);

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
                            var ar = Context.ActivityResource.FirstOrDefault(
                               x => !x.ActivityOrResource && x.ActivityResourceId == ent.Id
                                    && x.ActivityResourceType == (byte)(((int)Enums.Resources.Book) + 1));
                            if (ar != null)
                            {
                                ar.Name = book.Name;
                                Context.SaveChanges();
                            }
                            //update restriction also;
                            var res = AddOrUpdateRestriction(0, restriction);
                        }
                        scope.Complete();
                        return ent;
                    }
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
                , List<DbEntities.Subjects.SubjectFile> fileList, int sectionId, Restriction restriction)
            {
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        var ent = Context.FileResource.Find(file.Id);
                        if (ent == null)
                        {
                            //get restriction from the ui not auto add
                            //var restriction = new DbEntities.AccessPermission.Restriction()
                            //{
                            //    Visibility = false,
                            //    MatchAllAny = false,
                            //    MatchMust = true,
                            //};

                            //var res = Context.Restriction.Add(restriction);
                            //Context.SaveChanges();

                            //file.RestrictionId = res.Id;
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
                            SaveActivityResourceTable(false, (byte)(((int)Enums.Resources.File) + 1), ent.Id, sectionId, file.Name, restriction);
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
                        var ar =
                       Context.ActivityResource.FirstOrDefault(
                           x => !x.ActivityOrResource && x.ActivityResourceId == ent.Id
                                && x.ActivityResourceType == (byte)(((int)Enums.Resources.File) + 1));
                        if (ar != null)
                        {
                            ar.Name = file.Name;
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
                DbEntities.ActivityAndResource.UrlResource url, int sectionId, Restriction restriction)
            {
                var ent = Context.UrlResource.Find(url.Id);
                if (ent == null)
                {
                    //get restriction from the ui not auto add
                    //var restriction = new DbEntities.AccessPermission.Restriction()
                    //{
                    //    Visibility = false,
                    //    MatchAllAny = false,
                    //    MatchMust = true,
                    //};

                    //var res = Context.Restriction.Add(restriction);
                    //Context.SaveChanges();

                    //url.RestrictionId = res.Id;
                    ent = Context.UrlResource.Add(url);
                    Context.SaveChanges();

                    SaveActivityResourceTable(false, (byte)(((int)Enums.Resources.Url) + 1), ent.Id, sectionId, url.Name, restriction);

                }
                else
                {
                    ent.Display = url.Display;
                    ent.PopupWidthInPixel = url.PopupWidthInPixel;
                    ent.PopupHeightInPixel = url.PopupHeightInPixel;
                    ent.Name = url.Name;
                    ent.Description = url.Description;
                    ent.DisplayDescriptionOnPage = url.DisplayDescriptionOnPage;
                    ent.Url = url.Url;
                    Context.SaveChanges();

                    var ar =
                        Context.ActivityResource.FirstOrDefault(
                            x => !x.ActivityOrResource && x.ActivityResourceId == ent.Id
                                 && x.ActivityResourceType == (byte)(((int)Enums.Resources.Url) + 1));
                    if (ar != null)
                    {
                        ar.Name = url.Name;
                        Context.SaveChanges();
                    }

                }
                return ent;
            }

            public DbEntities.ActivityAndResource.UrlResource GetUrlResource(int urlId)
            {
                return Context.UrlResource.Find(urlId);
            }
            #endregion


            #region Page resource

            public DbEntities.ActivityAndResource.PageResource AddOrUpdatePageResource(
               DbEntities.ActivityAndResource.PageResource page, int sectionId, Restriction restriction)
            {
                var ent = Context.PageResource.Find(page.Id);
                if (ent == null)
                {
                    //get restriction from the ui not auto add
                    //var restriction = new DbEntities.AccessPermission.Restriction()
                    //{
                    //    Visibility = false,
                    //    MatchAllAny = false,
                    //    MatchMust = true,
                    //};

                    //var res = Context.Restriction.Add(restriction);
                    //Context.SaveChanges();

                    //page.RestrictionId = res.Id;
                    ent = Context.PageResource.Add(page);
                    Context.SaveChanges();

                    SaveActivityResourceTable(false, (byte)(((int)Enums.Resources.Page) + 1), ent.Id, sectionId, page.Name, restriction);

                }
                else
                {
                    ent.DisplayDescriptionOnPage = page.DisplayDescriptionOnPage;
                    ent.DisplayPageDescription = page.DisplayPageDescription;
                    ent.DisplayPageName = page.DisplayPageName;
                    ent.Name = page.Name;
                    ent.Description = page.Description;
                    ent.PageContent = page.PageContent;
                    Context.SaveChanges();

                    var ar =
                       Context.ActivityResource.FirstOrDefault(
                           x => !x.ActivityOrResource && x.ActivityResourceId == ent.Id
                                && x.ActivityResourceType == (byte)(((int)Enums.Resources.Page) + 1));
                    if (ar != null)
                    {
                        ar.Name = page.Name;
                        Context.SaveChanges();
                    }
                }
                return ent;
            }


            public DbEntities.ActivityAndResource.PageResource GetPageResource(int pageId)
            {
                return Context.PageResource.Find(pageId);
            }


            #endregion


            #region Label Resource

            public DbEntities.ActivityAndResource.LabelResource GetLabelResource(int labelId)
            {
                return Context.LabelResource.Find(labelId);
            }

            public DbEntities.ActivityAndResource.LabelResource AddOrUpdateLabelResource(
                DbEntities.ActivityAndResource.LabelResource label, int sectionId, Restriction restriction)
            {
                var ent = Context.LabelResource.Find(label.Id);
                if (ent == null)
                {
                    //get restriction from the ui not auto add
                    //var restriction = new DbEntities.AccessPermission.Restriction()
                    //{
                    //    Visibility = false,
                    //    MatchAllAny = false,
                    //    MatchMust = true,
                    //};

                    //var res = Context.Restriction.Add(restriction);
                    //Context.SaveChanges();

                    //label.RestrictionId = res.Id;
                    ent = Context.LabelResource.Add(label);
                    Context.SaveChanges();

                    SaveActivityResourceTable(false, (byte)(((int)Enums.Resources.Label) + 1), ent.Id, sectionId, "", restriction);

                }
                else
                {
                    ent.Text = label.Text;
                    Context.SaveChanges();

                }
                return ent;
            }

            #endregion


            /// <summary>
            /// 
            /// </summary>
            /// <param name="actOrRes">true/false: T-act, F-res</param>
            /// <param name="actOrResType">one of the many: assignment, book, etc</param>
            /// <param name="actOrResId">id of assignement, book , etc</param>
            public Restriction GetRestriction(bool actOrRes, byte actOrResType, int actOrResId)
            {
                var ar = Context.ActivityResource.FirstOrDefault(x => x.ActivityOrResource == actOrRes
                                                             && x.ActivityResourceType == actOrResType
                                                             && x.ActivityResourceId == actOrResId);
                if (ar != null)
                {
                    return ar.Restriction;
                }
                return null;
            }
            
        }

    }

}
