using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.DbEntities.Teachers;
using Academic.ViewModel.SystemControl.Office;
using Academic.ViewModel.Teachers;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Teacher : IDisposable
        {
            private AcademicContext Context;

            public Teacher()
            {
                Context = new AcademicContext();
            }

            public static DbEntities.Teachers.Teacher Convert(TeacherViewModel model)
            {
                var entity = new DbEntities.Teachers.Teacher()
                {
                    // BarcodeNo = model.BarcodeNo,
                    // Citizenship = model.Citizenship,
                    // Email = model.Email,
                    // FirstName = model.FirstName,
                    // LastName = model.LastName,
                    // GenderId = model.GenderId,
                    // HomeNo = model.HomeNo,
                    // Hobbies =  model.Hobbies,
                    // Nationality = model.Nationality,
                    // OtherRollName = model.OtherRollName,
                    // OtherRollNo = model.OtherRollNo,
                    // PermanentStreet = model.PermanentStreet,
                    // PermanentCountry = model.PermanentCountry,
                    // PermanentCity = model.PermanentCity,
                    // Religion = model.Religion,
                    // ResearchInterest = model.ResearchInterest,
                    // RoleId = model.RoleId,
                    // Password = model.Password,
                    // MiddleName = model.MiddleName,
                    // MobileNo = model.MobileNo,
                    // TemporaryCountry = model.TemporaryCountry,
                    // TemporaryStreet = model.TemporaryStreet,
                    // TemporaryCity = model.TemporaryCity,
                    // UserName = model.UserName,
                    // IsActive = model.IsActive,
                    // ImageFileId = model.ImageFileId,
                    // SchoolId = model.SchoolId
                    //,TeacherJobTitleId =  model.JobId
                    // ,JobTitle = model.JobTitle
                };
                //entity.DOB = new DateTime((int)(model.DOBYear == 0 ? 1911 : model.DOBYear), (int)model.DOBMonth + 1, (int)model.DOBDay==0?1:model.DOBDay);
                //entity.DOB = entity.DOB.ToLocalTime();
                //entity.AppointedDate = new DateTime((int)model.AppointedYear==0?1911:model.AppointedYear, (int)model.AppointedMonth + 1,
                //    (int) model.AppointedDay==0?1:model.AppointedDay);
                //entity.AppointedDate = entity.AppointedDate.Date.ToLocalTime();
                //entity.MembershipDate = new DateTime((int)model.MembershipYear==0?1911:model.MembershipYear, (int)model.MembershipMonth + 1,
                //    (int) model.MembershipDay==0?1:model.MembershipDay);
                //entity.MembershipDate = entity.MembershipDate.Date.ToLocalTime();

                return entity;
            }

            public static TeacherViewModel Convert(DbEntities.Teachers.Teacher model)
            {
                var entity = new ViewModel.Teachers.TeacherViewModel()
                {

                    // BarcodeNo = model.BarcodeNo,
                    // Citizenship = model.Citizenship,
                    // Email = model.Email,
                    // FirstName = model.FirstName,
                    // LastName = model.LastName,
                    // GenderId = model.GenderId,
                    // HomeNo = model.HomeNo,
                    // Hobbies = model.Hobbies,
                    // Nationality = model.Nationality,
                    // OtherRollName = model.OtherRollName,
                    // OtherRollNo = model.OtherRollNo,
                    // PermanentStreet = model.PermanentStreet,
                    // PermanentCountry = model.PermanentCountry,
                    // PermanentCity = model.PermanentCity,
                    // Religion = model.Religion,
                    // ResearchInterest = model.ResearchInterest,
                    // RoleId = model.RoleId,
                    // Password = model.Password,
                    // MiddleName = model.MiddleName,
                    // MobileNo = model.MobileNo,
                    // TemporaryCountry = model.TemporaryCountry,
                    // TemporaryStreet = model.TemporaryStreet,
                    // TemporaryCity = model.TemporaryCity,
                    // UserName = model.UserName,
                    // IsActive = model.IsActive,
                    // ImageFileId = model.ImageFileId,
                    // SchoolId = model.SchoolId
                    //,
                    // JobId = model.TeacherJobTitleId
                    // ,
                    // JobTitle = model.JobTitle
                };

                //entity.DOB = new DateTime((int)(model.DOBYear == 0 ? 1911 : model.DOBYear), (int)model.DOBMonth + 1, (int)model.DOBDay == 0 ? 1 : model.DOBDay);
                //entity.DOB = entity.DOB.ToLocalTime();
                //entity.AppointedDate = new DateTime((int)model.AppointedYear == 0 ? 1911 : model.AppointedYear, (int)model.AppointedMonth + 1,
                //    (int)model.AppointedDay == 0 ? 1 : model.AppointedDay);
                //entity.AppointedDate = entity.AppointedDate.Date.ToLocalTime();
                //entity.MembershipDate = new DateTime((int)model.MembershipYear == 0 ? 1911 : model.MembershipYear, (int)model.MembershipMonth + 1,
                //    (int)model.MembershipDay == 0 ? 1 : model.MembershipDay);
                //entity.MembershipDate = entity.MembershipDate.Date.ToLocalTime();

                return entity;
            }

            public DbEntities.Teachers.Teacher Add(TeacherVM modelVm)
            {
                TeacherViewModel model = modelVm.Teacher;
                var quali = modelVm.TeacherQualification;
                using (var ctx = new DbHelper.WorkingWithFiles())
                {
                    //var imId = ctx.UploadImageToDB(model.Image);
                    var convert = Convert(model);
                    //convert.ImageFileId = imId;
                    var teach = Context.Teacher.Add(convert);

                    Context.SaveChanges();

                    for (var i = 0; i < quali.Count; i++)
                    {
                        quali[i].TeacherId = teach.Id;
                        Context.TeacherQualification.Add(quali[i]);
                    }
                    Context.SaveChanges();
                    return teach;
                }

            }

            public DbEntities.Teachers.Teacher Find(int id)
            {
                return Context.Teacher.Find(id);
            }
            public void Dispose()
            {
                Context.Dispose();
            }

            public int[] GetInstSchoolIds(int userId)
            {
                //var std = Context.Teacher.Include(x=>x.School).FirstOrDefault(x => x.Id == userId);
                //if (std == null) return new int[] { 0, 0 };
                //var schoolId = std.SchoolId;
                //var instId = std.School.InstitutionId;
                //return new int[] { instId, schoolId };
                return new int[] { };
            }
            /*
                        public ViewModel.SystemControl.Office.InstitutionAndSchool GetInstitutionAndSchool(int userId)
                        {
                            //var teach = Context.Teacher.Include(x => x.School).FirstOrDefault(x => x.Id == userId);
                            //if (teach == null) return null;
                            var model = new InstitutionAndSchool();
                            //model.School = teach.School;
                            //var inst = Context.Institution.Find(teach.School.InstitutionId);
                            //if (inst != null)
                            //    model.Institution = inst;
                            return model;
                        }
                        */
            public List<DbEntities.Teachers.Teacher> GetTeacherList(int schoolId)
            {
                var teacher = Context.Teacher.Where(
                    x => x.User.SchoolId == schoolId
                    && x.User.IsActive == true &&
                   (x.User.IsDeleted ?? false) == false);
                return teacher.ToList();
            }
        }
    }
}
