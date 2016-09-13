using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Academic.Database;
using Academic.DbEntities.AcacemicPlacements;
using Academic.DbEntities.Activities;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class Activity:IDisposable
        {
            AcademicContext Context;

            public Activity()
            {
                Context = new AcademicContext();
            }

            public void Dispose()
            {
                Context.Dispose();
            }

            //public Teach AddOrUpdateTeach(DbEntities.Activities.Teach teach)
            //{
            //    try
            //    {
            //        var tea = Context.Teach.Find(teach.Id);
            //        if (tea == null)
            //        {
            //          var t=  Context.Teach.Add(teach);
            //            Context.SaveChanges();
            //            return t;
            //        }
            //        else
            //        {
            //            tea.AcademicYearId = teach.AcademicYearId;
            //            tea.StartDate = teach.StartDate;
            //            tea.SessionId = teach.SessionId;
            //            tea.Void = teach.Void;
            //            tea.EstimatedCompletionHours = teach.EstimatedCompletionHours;
            //            tea.SubjectId = teach.SubjectId;
            //            tea.TeacherId = teach.TeacherId;
            //            tea.Remarks = teach.Remarks;

            //            Context.SaveChanges();
            //            return tea;
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        return null;
            //    }
            //}

        
        }
    }
}
