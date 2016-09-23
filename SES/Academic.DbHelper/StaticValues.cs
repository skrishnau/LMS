using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public static class StaticValues
        {
            #region Activity and Resource Image Urls

            public static List<string> ActivityImages = new List<string>()
                {
                    "",
                    "~/Content/Icons/ActivityResource/Assignment/document-icon.png",

                    ""
                };

            public static List<string> ResourceImages = new List<string>()
            {
                "",
                "~/Content/Icons/ActivityResource/Book/book.png",
                ""
            };
            //"~/Content/Icons/ActivityResource/Assignment/assignment_with_yellow_pencil.png",

            #endregion
        }
    }
}
