using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
//using Academic.DbEntities.Subjects.Detail;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class SubjectSection : IDisposable
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

            //public List<SubjectActivityAndResource> GetActivityAndResourcesOfSection(int sectionId)
            //{
            //    var ress = Context.SubjectActivityAndResource.Where(x => x.SubjectSectionId == sectionId).ToList();
            //    return ress;
            //}

            public DbEntities.Subjects.SubjectSection Find(int sectionId)
            {
                return
                    Context.SubjectSection
                        .FirstOrDefault(y => y.Id == sectionId);
            }

            public DbEntities.Subjects.SubjectSection AddOrUpdateSection(DbEntities.Subjects.SubjectSection sec)
            {
                try
                {
                    var ent = Context.SubjectSection.Find(sec.Id);
                    if (ent == null)
                    {
                        ent = Context.SubjectSection.Add(sec);
                    }
                    else
                    {
                        ent.Name = sec.Name;
                        ent.Summary = sec.Summary;
                        ent.ShowSummary = sec.ShowSummary;
                    } 
                    Context.SaveChanges();
                    return ent;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public DbEntities.Subjects.SubjectSection GetSection(int sec)
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
