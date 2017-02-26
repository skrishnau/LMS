using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Academic.Database;
using Academic.DbEntities;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class WorkingWithFiles : IDisposable
        {
            private AcademicContext Context;

            public WorkingWithFiles()
            {
                Context = new AcademicContext();
            }


            public void Dispose()
            {
                Context.Dispose();
            }


            #region List Files

            public List<UserFile> ListAllFiles()
            {
                return Context.File.ToList();
            }

            public List<UserFile> ListUserFiles(int userId, int folderId, bool isServerFile)
            {
                return Context.File.Where(x => x.CreatedBy == userId && !(x.Void ?? false) 
                                                && (x.FolderId ?? 0) == folderId
                                                && x.IsServerFile==isServerFile
                                            )
                                            .OrderBy(x=>x.DisplayName)
                                            .ToList();
            }

            public UserFile GetFolderOfFilesList(int userId, int folderId, bool isServerFile)
            {
                return Context.File.FirstOrDefault(x => x.CreatedBy == userId
                                                          && !(x.Void ?? false)
                                                          && (x.Id) == folderId
                                                          && x.IsFolder
                                                          &&x.IsServerFile==isServerFile
                                                          );
            }

            #endregion


            #region ImageSaveToDatabase


            //public int UploadImageToDB(HttpPostedFileBase file)
            //{
            //    if (file == null) return 0;
            //    DbEntities.UserImage image = new DbEntities.UserImage();
            //    image.Extension = file.ContentType;
            //    //image.Name = file.FileName;
            //    image.Bytes = ConvertToBytes(file);

            //    var im = Context.UserImage.Add(image);
            //    Context.SaveChanges();
            //    return im.Id;
            //}



            private byte[] ConvertToBytes(HttpPostedFileBase file)
            {
                Byte[] imageBytes = null;
                BinaryReader reader = new BinaryReader(file.InputStream);
                imageBytes = reader.ReadBytes((int)file.ContentLength);
                return imageBytes;
            }

            //public DbEntities.UserImage GetUserImage(int id)
            //{
            //    return Context.UserImage.Find(id);
            //}

            ///// <summary>
            ///// HttpPostedFile Type
            ///// </summary>
            ///// <param name="file"></param>
            ///// <returns></returns>
            //public int UploadImageToDB(HttpPostedFile file)
            //{
            //    if (file == null) return 0;
            //    var image = new DbEntities.UserImage();
            //    image.Extension = file.ContentType;
            //    //image.Name = file.FileName;
            //    image.Bytes = ConvertToBytes(file);

            //    var im = Context.UserImage.Add(image);
            //    Context.SaveChanges();
            //    return im.Id;
            //}

            public byte[] ConvertToBytes(HttpPostedFile file)
            {
                Byte[] imageBytes = null;
                BinaryReader reader = new BinaryReader(file.InputStream);
                imageBytes = reader.ReadBytes((int)file.ContentLength);
                return imageBytes;
            }

            #endregion

            #region Get file information

            public bool DoesFileExists(string fileName)
            {
                var file = Context.File.FirstOrDefault(x => x.FileName == fileName);
                return (file != null);
            }

            #endregion

            public DbEntities.UserFile AddOrUpdateFolder(DbEntities.UserFile folder)
            {
                try
                {
                    var ent = Context.File.Find(folder.Id);
                    if (ent == null)
                    {
                        var saved = Context.File.Add(folder);
                        Context.SaveChanges();
                        return saved;
                    }
                    ent.DisplayName = folder.DisplayName;
                    ent.ModifiedBy = folder.ModifiedBy;
                    ent.ModifiedDate = folder.ModifiedDate;
                    ent.Void = folder.Void;
                    Context.SaveChanges();
                    return ent;
                }
                catch
                {
                    return null;
                }
            }

            public object DeleteFile(int fileId)
            {
                try
                {
                    var ent = Context.File.Find(fileId);
                    if (ent != null)
                    {
                        ent.Void = true;
                        Context.SaveChanges();
                    }
                    return ent;
                }
                catch
                {
                    return null;
                }
            }

            public DbEntities.UserFile AddOrUpdateFile(DbEntities.UserFile image)
            {
                try
                {
                    var ent = Context.File.Find(image.Id);
                    if (ent == null)
                    {
                        var saved = Context.File.Add(image);
                        Context.SaveChanges();
                        return saved;
                    }
                    ent.DisplayName = image.DisplayName;
                    ent.ModifiedBy = image.ModifiedBy;
                    ent.ModifiedDate = image.ModifiedDate;
                    ent.Void = image.Void;
                    Context.SaveChanges();
                    return ent;
                }
                catch
                {
                    return null;
                }
            }

            public string GetImageUrl(int imageId)
            {
                var ent = Context.File.Find(imageId);
                if (ent != null)
                {
                    return ent.FileDirectory + ent.FileName; //+ "." + extension;
                }
                else
                {

                }
                return "";
            }

            public object ListFilesOfNoticeFolder()
            {
                throw new NotImplementedException();
            }


        }
    }
}
