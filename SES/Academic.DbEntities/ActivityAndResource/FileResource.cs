using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbEntities.ActivityAndResource
{
    public class FileResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public bool ShowDescriptionOnCoursePage { get; set; }


        //Appearance

        // This setting, together with the file type and whether the browser allows embedding, determines how the file is displayed. Options may include:
        /// <summary>
        /// 0-automatic, 1-embed, 2-forcedownload, 3-open,4-in popup, 
        ///Automatic - The best display option for the file type is selected automatically......
        ///Embed - The file is displayed within the page below the navigation bar together with the 
        /// file description and any blocks
        ///Force download - The user is prompted to download the file......
        ///Open - Only the file is displayed in the browser window.....
        ///In pop-up - The file is displayed in a new browser window without menus or an address bar......
        ///In frame - The file is displayed within a frame below the navigation bar and file description......
        ///New window - The file is displayed in a new browser window with menus and an address bar......
        /// </summary>
        public byte Display { get; set; }

        public bool ShowSize { get; set; }
        public bool ShowType { get; set; }
        public bool ShowUploadModifiedDate { get; set; }

        //public int RestrictionId { get; set; }
        //public virtual AccessPermission.Restriction Restriction { get; set; }

        /// <summary>
        /// Id of FileResourceFile table to indicate that this file is set as main file.
        /// </summary>
        public int? MainFileId { get; set; }
    }
}
