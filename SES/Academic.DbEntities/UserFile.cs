using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities
{
    public class UserFile
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }
        public string FileDirectory { get; set; }
        public long FileSizeInBytes { get; set; }
        public string FileType { get; set; }//Extension

        //for default folders the createdBy will be null
        public int? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool? Void { get; set; }
        //icon path
        public string IconPath { get; set; }

        /// <summary>
        /// if false then the file is private to the user only, 
        /// if true then the file is server file and appear in 'server file' list
        /// </summary>
        public bool IsServerFile { get; set; }

        /// <summary>
        /// true: this is a folder so, filesize=0, filedirectory= "" , filetype="folder"
        /// and icon path = 'folder icon' path
        /// </summary>
        public bool IsFolder { get; set; }

        public int? FolderId { get; set; }
        //default folders are not editable
        public bool? IsConstantAndNotEditable { get; set; }

        public virtual UserFile Folder { get; set; }

        public virtual ICollection<UserFile> FilesInThisFolder { get; set; }


        public int? SchoolId { get; set; }
    }
}
