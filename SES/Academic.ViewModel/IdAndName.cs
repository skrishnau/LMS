using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel
{
    public class IdAndName
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
    }

    public class FileResourceEventArgs : EventArgs
    {
        public long FileSizeInBytes { get; set; }
        /// <summary>
        /// eg. image/jpg . i.e. in the form of slash in middle
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// only name. not in the form of path. only name
        /// </summary>
        public string FileDisplayName { get; set; }

        /// <summary>
        /// Full icon path. Extract icon name later.
        /// </summary>
        public string IconPath { get; set; }
        /// <summary>
        /// full file path. extract name later.
        /// </summary>
        public string FilePath { get; set; }
    }

    public class IdAndNameEventArgs:EventArgs
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RefIdInt { get; set; }
        public string RefIdString { get; set; }

    }

    public class GradeValuesDataType
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Value { get; set; }

        public float Equivalent { get; set; }
        public bool Fail { get; set; }


    }


}
