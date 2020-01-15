using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Database.Seeders
{
    public class UserFileSeeder
    {
        private AcademicContext _context;
        public UserFileSeeder(AcademicContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            var userFiles = new DbEntities.UserFile[]
            {
                new DbEntities.UserFile{ DisplayName = "User Photos", FileType = "Folder", IsServerFile = true, IsFolder = true, IsConstantAndNotEditable = true, CreatedDate = DateTime.Now, FileName = null, FileDirectory = null, FileSizeInBytes = 0, ModifiedBy= null, ModifiedDate = null, CreatedBy = null, FolderId = null, IconPath = null, SchoolId = null, Void = null, },
            };
            _context.File.AddOrUpdate(
                p => p.DisplayName,
                userFiles
                );
            _context.SaveChanges();

        }
    }
}
