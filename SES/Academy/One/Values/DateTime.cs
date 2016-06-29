using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace One.Values
{
    public static class CustomDateTime
    {
        public static string Type = "Default";
        public static  TimeZone TimeZone { get; set; }
        public static TimeZoneInfo TimeZoneInfo { get; set; }

        public static System.DateTime Now
        {
            get
            {
                System.DateTime date=System.DateTime.Now;
                switch (Type)
                {
                    case "ServerTimeZone":

                    case "UserTimeZone":
                        break;
                    case "Default":
                        date = System.DateTime.Now;
                        break;
                    default:
                        date = System.DateTime.Now;
                        break;
                }

                //switch (TimeZone)
                //{
                    
                //}
                return date;
            }
        }


    }
}