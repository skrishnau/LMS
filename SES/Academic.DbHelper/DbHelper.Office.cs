using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
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

            //=======================================================================//

            //For WebForm controls
            /*
            //not needed
            public DbEntities.Office.Institution GetInstitution(int id)
            {
                return Context.Institution.Find(id);

            }

            public DbEntities.Office.Institution AddOrUpdateInstitution(DbEntities.Office.Institution entity, System.Web.HttpPostedFile httpPostedFile)
            {
                try
                {
                    var model = Context.Institution.Find(entity.Id);
                    byte[] imgBytes = null;
                    using (var filehelper = new DbHelper.WorkingWithFiles())
                    {
                        if (httpPostedFile != null)
                        {
                            imgBytes = filehelper.ConvertToBytes(httpPostedFile);
                            entity.Logo = imgBytes;
                            entity.LogoImageType = httpPostedFile.ContentType;
                        }
                    }
                    if (model == null)
                    {
                        //add
                        var inst = Context.Institution.Add(entity);
                        Context.SaveChanges();
                        return inst;
                    }

                    else
                    {
                        //update
                        model.Name = entity.Name;
                        model.Country = entity.Country;
                        model.City = entity.City;
                        model.Category = entity.Category;
                        model.Street = entity.Street;
                        model.Logo = (httpPostedFile == null) ? model.Logo : imgBytes;
                        model.LogoImageType = (httpPostedFile == null)
                            ? model.LogoImageType
                            : httpPostedFile.ContentType;
                        model.Email = entity.Email;
                        model.Website = entity.Website;
                        model.Moto = entity.Moto;
                        model.PanNo = entity.PanNo;
                        model.PostalCode = entity.PostalCode;
                        model.UserId = entity.UserId;
                        Context.SaveChanges();
                        return model;
                    }
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            public DbEntities.Office.Institution RemoveInstitution(int id)
            {
                try
                {
                    var inst = Context.Institution.Find(id);
                    if (inst == null)
                    {
                        return null;
                    }
                    var removed = Context.Institution.Remove(inst);
                    Context.SaveChanges();
                    return removed;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            public List<Institution> GetAllInstitution()
            {
                return Context.Institution.ToList();
            }

            */


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

            public DbEntities.Office.School AddOrUpdateSchool(DbEntities.Office.School school, System.Web.HttpPostedFile httpPostedFile)
            {
                try
                {
                    int earlierSchoolId = school.Id;
                    var ent = Context.School.Find(school.Id);

                    byte[] imgBytes = null;
                    using (var filehelper = new DbHelper.WorkingWithFiles())
                    {
                        if (httpPostedFile != null)
                        {
                            imgBytes = filehelper.ConvertToBytes(httpPostedFile);
                            school.Image = imgBytes;
                            school.ImageType = httpPostedFile.ContentType;
                        }
                    }

                    if (ent == null)
                    {
                        var saved = Context.School.Add(school);
                        Context.SaveChanges();

                        //if this is newly created school (by the user) then add schoolId to the user
                        if (earlierSchoolId <= 0 && school.UserId > 0)
                        {
                            var user = Context.Users.Find(school.UserId);
                            if (user != null)
                            {
                                user.SchoolId = saved.Id;
                                Context.SaveChanges();

                            }
                        }

                        return saved;
                    }
                    else
                    {
                        //update later
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
                        ent.Image = school.Image;
                        ent.ImageType = school.ImageType;
                        ent.IsActive = school.IsActive;
                        ent.IsDeleted = school.IsDeleted;
                        Context.SaveChanges();
                        return ent;

                        return null;
                    }

                }
                catch (Exception)
                {
                    return null;
                }
            }

            //int instId
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
                    if ((user.SchoolId ?? 0) > 0)
                    {
                        return user.School;
                    }
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
        }
    }
}
