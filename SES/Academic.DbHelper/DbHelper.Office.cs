using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.Database;
using Academic.DbEntities;
using Academic.DbEntities.Office;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Office : IDisposable
        {
            AcademicContext Context;
            public Office()
            {
                Context = new AcademicContext();
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public List<IdAndName> GetSchoolForCombo(int instId)
            {
                List<IdAndName> ss = new List<IdAndName>();
                var schools = Context.School.ToList();
                schools.ToList().ForEach(x =>
                {
                    ss.Add(new IdAndName()
                    {
                        Id = x.Id,
                        Name = x.Name
                    });
                });
                return ss;
            }

            public DbEntities.Office.School AddOrUpdateSchool(DbEntities.Office.School school, UserFile image)//System.Web.HttpPostedFile httpPostedFile
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {

                        int earlierSchoolId = school.Id;
                        var ent = Context.School.Find(school.Id);
                        if (ent == null)
                        {
                            var img = Context.File.Add(image);
                            Context.SaveChanges();
                            school.ImageId = img.Id;
                            ent = Context.School.Add(school);
                            Context.SaveChanges();

                            //if this is newly created school (by the user) then add schoolId to the user
                            if (earlierSchoolId <= 0 && school.UserId > 0)
                            {
                                var user = Context.Users.Find(school.UserId);
                                if (user != null)
                                {
                                    user.SchoolId = ent.Id;
                                    Context.SaveChanges();
                                }
                            }

                        }
                        else
                        {
                            int imageId = 0;

                            //update later
                            if (ent.ImageId <= 0)
                            {
                                //var cntx = new AcademicContext();
                                var img = Context.File.Add(image);
                                Context.SaveChanges();
                                school.ImageId = img.Id;
                                //school.ImageId = img.Id;
                                
                                //ent.ImageId = img.Id;
                                //Context.Dispose();
                            }
                            else
                            {
                                var img = Context.File.Find(ent.ImageId);
                                if (img != null)
                                {
                                    
                                    img.DisplayName = image.DisplayName;
                                    img.FileName = image.FileName;
                                    img.ModifiedBy = image.ModifiedBy;
                                    img.ModifiedDate = image.ModifiedDate;
                                    img.FileDirectory = image.FileDirectory;

                                    img.FileSizeInBytes = image.FileSizeInBytes;
                                    img.FileType = image.FileType;
                                    img.IconPath = image.IconPath;
                                    img.Void = image.Void;
                                    //Context.SaveChanges();
                                }
                            }

                            ent.ImageId = school.ImageId;
                            ent.Name = school.Name;
                            ent.Email = school.Email;
                            ent.Fax = school.Fax;
                            ent.Phone = school.Phone;
                            ent.RegNo = school.RegNo;
                            ent.Street = school.Street;
                            ent.Website = school.Website;
                            ent.City = school.City;
                            ent.Code = school.Code;
                            ent.Country = school.Country;

                            //ent.Image = school.Image;
                            //ent.ImageType = school.ImageType;

                            ent.IsActive = school.IsActive;
                            ent.IsDeleted = school.IsDeleted;
                            Context.SaveChanges();
                        }
                        scope.Complete();
                        return ent;
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    throw ex;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public IEnumerable<SchoolType> GetSchoolTypes()
            {
                var schTypes = Context.SchoolType.AsEnumerable();
                //.Where(x => x.InstitutionId == instId
                //        || x.InstitutionId == null).AsEnumerable();
                List<SchoolType> list = new List<SchoolType>();
                foreach (var schoolType in schTypes)
                {
                    list.Add(new SchoolType()
                    {
                        Id = schoolType.Id,
                        //InstitutionId = schoolType.InstitutionId ?? 0,
                        Name = schoolType.Name
                    });
                }
                return list;
            }

            public SchoolType AddOrUpdateSchoolType(SchoolType schTyp)
            {
                try
                {
                    var sch = Context.SchoolType.Find(schTyp.Id);
                    if (sch == null)
                    {
                        var tp = Context.SchoolType.Add(schTyp);
                        Context.SaveChanges();
                        return tp;
                    }
                    else
                    {
                        sch.Name = schTyp.Name;
                        //if ((schTyp.InstitutionId ?? 0) != 0)
                        //{
                        //    sch.InstitutionId = schTyp.InstitutionId;
                        //}
                        Context.SaveChanges();
                        return sch;
                    }
                }
                catch (Exception)
                {
                    return null;
                }

            }

            public School GetSchoolOfUser(int userId)
            {
                var user = Context.Users.Include(x => x.School).FirstOrDefault(x => x.Id == userId);
                if (user != null)
                {
                    //if ((user.SchoolId ?? 0) > 0 )
                    //{
                    return user.School;
                    //}
                    //if (((int)(user.SchoolId )) > 0)
                    //{
                    //    return user.School;
                    //}
                    return null;
                    //else
                    //{
                    //    var sch = Context.School.FirstOrDefault(x => x.UserId == userId);
                    //    return sch;
                    //}
                }
                return null;
            }

            public UserFile GetSchoolImage(int fileId)
            {
                return Context.File.Find(fileId);
            }
        }
    }
}
