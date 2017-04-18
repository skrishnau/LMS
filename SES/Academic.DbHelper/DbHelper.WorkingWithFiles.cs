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

            public List<UserFile> ListUserFiles(int userId, int folderId, bool isServerFile, int schoolId)
            {
                //if isServerfile == true then x.IsServerFile must be true so we get all server files in that folder--
                //  --for the given schoolId
                // if isServerFile== false then we need to get the files for the specific user
                //here schoolId must be considered , which is neglected

                return Context.File.Where(x => (//x.CreatedBy == userId && 
                                                (x.FolderId ?? 0) == folderId
                                                && (x.IsServerFile == isServerFile)
                                                && ((isServerFile && x.IsServerFile && x.SchoolId == schoolId)//server file magda server file matra line
                                                        || (!isServerFile && x.CreatedBy == userId))
                                                )
                                                && !(x.Void ?? false)
                                            )
                                            .OrderBy(x => x.DisplayName)
                                            .ToList();
            }

            public UserFile GetFolderOfFilesList(int userId, int folderId, bool isServerFile, int schoolId)
            {
                //earleir code
                return Context.File.FirstOrDefault(x => x.CreatedBy == userId
                                                          && !(x.Void ?? false)
                                                          && (x.Id) == folderId
                                                          && x.IsFolder
                    //&& x.IsServerFile == isServerFile
                                                          );

                //return Context.File.FirstOrDefault(x => //x.CreatedBy == userId &&
                //                                        (x.Id) == folderId
                //                                        && x.IsServerFile == isServerFile
                //                                        && !(x.Void ?? false)
                //                                        && ((isServerFile && x.IsServerFile && x.SchoolId == schoolId)//server file magda server file matra line
                //                                        || (!isServerFile && x.CreatedBy == userId))
                //                                        && x.IsFolder
                //                                        );
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

            //public List<> GetFolderFromName(int schoolId, string folderName, bool isServerFile)
            //{
            //    var folders = Context.File.Where(x =>
            //        x.SchoolId == schoolId &&
            //        x.IsServerFile == isServerFile &&
            //        x.DisplayName == folderName
            //        );
            //    return folders.ToList();
            //}

            public UserFile GetUserPhotoFolder(int schoolId)
            {
                try
                {
                    var folder = Context.File.FirstOrDefault(x =>
                                x.SchoolId == schoolId &&
                                x.IsServerFile &&
                                (x.IsConstantAndNotEditable ?? false) &&
                                x.DisplayName == StaticValues.UserPhotoFolderName);
                    if (folder == null)
                    {
                        //create the folder
                        var userFile = new UserFile()
                        {
                            CreatedBy = null
                            ,
                            CreatedDate = DateTime.Now
                            ,
                            DisplayName = StaticValues.UserPhotoFolderName
                            ,
                            FileDirectory = null
                            ,
                            FileName = null
                            ,
                            FileSizeInBytes = 0
                            ,
                            FileType = "Folder"
                            ,
                            IsServerFile = true
                            ,
                            SchoolId = schoolId
                            ,
                            IsFolder = true
                            ,
                            IsConstantAndNotEditable = true
                            ,
                        };
                        var saved = Context.File.Add(userFile);
                        Context.SaveChanges();
                        return saved;
                    }
                    return folder;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


    }
}
