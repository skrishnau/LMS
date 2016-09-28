using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Academic.Database;
using Academic.DbEntities.Resources;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        /*
        public class Resource : IDisposable
        {
            private AcademicContext Context;

            public Resource()
            {
                Context = new AcademicContext();
            }

            public int AddResource(DbEntities.Resources.Resource res)
            {
                var x = Context.Resource.Add(res);
                Context.SaveChanges();
                return x.Id;
            }


            public void Dispose()
            {
                Context.Dispose();
            }



            public IdAndName SaveResource(DbEntities.Resources.Resource resource,
                List<System.Web.HttpPostedFile> Files,
                string path,
                string[] links)
            {
                try
                {
                    List<ResourceFile> resourceFiles = new List<ResourceFile>();

                    Files.ForEach(file =>
                    {
                        var fileName = Guid.NewGuid().ToString();
                        var displayName = Path.GetFileName(file.FileName);
                        var ext = displayName.Split(new char[] { '.' });
                        var pa = Path.Combine(path, fileName + ((ext.Length > 1) ? "." + ext[ext.Length - 1] : ""));
                        file.SaveAs(pa);
                        var rf = new DbEntities.Resources.ResourceFile()
                        {

                            DisplayName = displayName
                            ,
                            FileName = fileName
                            ,
                            FileDirectory = path

                            ,
                            CreatedDate = resource.CreatedDate
                            ,
                            ModifiedDate = resource.ModifiedDate

                            ,
                            CreatedBy = resource.OwnerId
                            ,
                            ModifiedBy = resource.ModifiedBy
                            ,
                            OwnerId = resource.OwnerId
                            ,
                            SubjectId = resource.SubjectId
                        };
                        var resEntity = Context.ResourceFile.Add(rf);
                        Context.SaveChanges();
                        resourceFiles.Add(resEntity);
                    });
                    resource.Files = resourceFiles;
                    var rEntity = Context.Resource.Add(resource);
                    Context.SaveChanges();
                    foreach (var link in links)
                    {
                        var lEntity = new DbEntities.Resources.Links()
                        {
                            Url = link,
                            Remarks = "",
                            ResourceId = rEntity.Id
                        };
                        Context.Links.Add(lEntity);
                    }
                    Context.SaveChanges();
                    return new IdAndName() { Id = rEntity.Id, Name = rEntity.Name };
                }
                catch{return null;}
            }

            public List<IdAndName> GetFileAccessPermissionForCombo()
            {
                var fileap = Enum.GetValues(typeof(FileAccessPermission)).Cast<FileAccessPermission>().Select(x => x.ToString()).ToList();
                var a = Context.AccessPermission.Where(x => fileap.Contains(x.Name)).Select(y => new IdAndName()
                {
                    Name = y.Name
                    ,
                    Id = y.Id
                });
                return a.ToList();
            }

            public List<IdAndName> GetResourcesForCombo(int subId)
            {
                return Context.Resource.
                    Where(x => x.SubjectId == subId).Select(y => new IdAndName()
                {
                    Id = y.Id,
                    Name = y.Name
                }).ToList();
            }
            public enum FileAccessPermission
            {
                Global,
                Public,
                Private,
                Assignable,
                Searchable,
            }
        }

        */
    }
}
