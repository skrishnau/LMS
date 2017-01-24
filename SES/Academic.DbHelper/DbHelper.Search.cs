using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Search : IDisposable
        {
            private AcademicContext Context;
            public Search()
            {
                Context = new AcademicContext();
            }

            public List<IdAndName> SearchCourse(string[] searchWords, int schoolId)
            {
                var courses = Context.Subject.Where(x => (x.SubjectCategory.SchoolId == schoolId)).OrderBy(x=>x.FullName);

                var lst = new List<IdAndName>();

                var count = 0;
                foreach (var c in courses)
                {
                    if (count >= 20)
                        break;
                    var fullname = c.FullName.ToLower();
                    var shortname = c.ShortName.ToLower();
                    foreach (var w in searchWords)
                    {
                        var word = w.ToLower();
                        if (fullname.Contains(word))
                        {
                            lst.Add(new IdAndName()
                            {
                                Name = c.FullName
                                ,
                                IdInString = "/Views/Course/Section/?SubId=" + c.Id
                                ,
                                Value = c.Summary
                            });
                            count++;
                            break;
                        }
                        else if (shortname.Contains(word))
                        {
                            lst.Add(new IdAndName()
                            {
                                Name = c.FullName
                                ,
                                IdInString = "/Views/Course/Section/?SubId=" + c.Id
                                ,
                                Value = c.Summary
                            });
                            count++;
                            break;
                        }
                    }
                }
                return lst;
                //    courses.Select(x => new IdAndName()
                //{
                //    Name = x.FullName
                //    ,
                //    IdInString = "/Views/Course/Section/?SubId=" + x.Id
                //    ,
                //    Value = x.Summary
                //}).ToList();
            }


            public void Dispose()
            {
                Context.Dispose();
            }
        }
    }
}
