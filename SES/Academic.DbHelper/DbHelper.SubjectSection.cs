using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.DbEntities.Subjects.Detail;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class SubjectSection:IDisposable
        {
            private AcademicContext Context;

            public SubjectSection()
            {
                Context = new AcademicContext();
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            public List<SubjectActivityAndResource> GetActivityAndResourcesOfSection(int sectionId)
            {
                var ress = Context.SubjectActivityAndResource.Where(x => x.SubjectSectionId == sectionId).ToList();
                return ress;
            }

            public DbEntities.Subjects.Detail.SubjectSection Find(int SectionId)
            {
                return
                    Context.SubjectSection.Include(x => x.SubjectActivityAndResource)
                        .FirstOrDefault(y => y.Id == SectionId);
            }

            public bool AddOrUpdateSection(DbEntities.Subjects.Detail.SubjectSection sec)
            {
                try
                {
                    var ent = Context.SubjectSection.Find(sec.Id);
                    if (ent == null)
                    {

                        Context.SubjectSection.Add(sec);
                        Context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        ent.Name = sec.Name;
                        ent.Summary = sec.Summary;
                        ent.ShowSummary = sec.ShowSummary;
                        
                        ent.SubjectActivityAndResource = sec.SubjectActivityAndResource;
                        Context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public DbEntities.Subjects.Detail.SubjectSection GetSection(int sec)
            {
                try
                {
                    return Context.SubjectSection.Find(sec);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public bool MakeSectionVoid(int SectionId)
            {
                try
                {
                    var ent = Context.SubjectSection.Find(SectionId);
                    if (ent != null)
                    {
                        ent.Void = true;
                        Context.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
