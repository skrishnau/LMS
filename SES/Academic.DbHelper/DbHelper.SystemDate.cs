using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public class SystemDate
        {


            //DateTime Now

            #region GetDateTime for dropdown list

            /// <summary>
            /// Returns list of years from and to the given interval dispalced from current date
            /// </summary>
            /// <param name="from">in displacement</param>
            /// <param name="to">in displacement</param>
            /// <returns></returns>
            public static List<string> GetYears(int from, int to, DateTime date)
            {
                var yearlst = new List<string>();
                for (int i = from; i <= to; i++)
                {
                    yearlst.Add(date.AddYears(i).Year.ToString());
                }
                return yearlst;
            }

            /// <summary>
            /// Return month list
            /// </summary>
            /// <param name="type">"short" - for short month name, e.g. Jan.  "long" for long Month name, e.g. January</param>
            /// <returns></returns>
            public static List<string> GetMonth(string type)
            {
                var lst = new List<string>();
                switch (type)
                {
                    case "short":
                        foreach (var month in Enum.GetValues(typeof(Enums.ShortMonth)))
                        {
                            lst.Add(month.ToString());
                        }
                        break;
                    default:
                        foreach (var month in Enum.GetValues(typeof(Enums.LongMonth)))
                        {
                            lst.Add(month.ToString());
                        }
                        break;
                }
                return lst;
            }
            public static List<IdAndName> GetMonth(string type,int monthValue,out int currentMonth)
            {
                var lst = new List<IdAndName>();
                int i = 1;
                //monthValue--;
                currentMonth = 1;
                switch (type)
                {
                    case "short":
                        foreach (var month in Enum.GetValues(typeof(Enums.ShortMonth)))
                        {
                            lst.Add(new IdAndName()
                            {
                                Name =month.ToString(), 
                                Id = i
                            });
                            if (i == monthValue)
                            {
                                currentMonth = i;
                            }
                            i++;
                            
                        }
                        break;
                    default:
                        foreach (var month in Enum.GetValues(typeof(Enums.LongMonth)))
                        {
                            lst.Add(new IdAndName()
                            {
                                Name = month.ToString(),
                                Id = i
                            });
                            if (i == monthValue)
                            {
                                currentMonth = i;
                            }
                            i++;
                        }
                        break;
                }
                return lst;
            }

            public static List<IdAndName> GetDays(DateTime date)
            {
                //var sp = (new DateTime(date.Year, date.Month+1, 01) - new DateTime(date.Year,date.Month,01));
                var lst = new List<IdAndName>();
                //for (int i = 1; i < 10; i++)
                //{
                //    lst.Add(new IdAndName() { Name = "0" + i, IdInString = "0" + i });
                //}
                for (int i = 1; i <32  ; i++)//sp.Days+1
                {
                    lst.Add(new IdAndName() { Name =  i.ToString(), Id  = i });
                }
                return lst;
            }

            public static List<string> GetHours()
            {
                var lst = new List<string>();
                for (int i = 0; i <= 9; i++)
                {
                    lst.Add("0"+i.ToString());
                }
                for (int i = 10; i < 24; i++)
                {
                    lst.Add(i.ToString());
                }
                return lst;
            }

            public static string GetStringFormOfHourOrMinute(int time)
            {
                if (time >= 0 && time <= 9)
                {
                    return "0" + time;
                }
                else 
                {
                    return time.ToString();
                }
                return "00";
            }

            public static List<string> GetMinutes()
            {
                var lst = new List<string>();
                for (int i = 0; i <= 9; i++)
                {
                    lst.Add("0" + i.ToString());
                }
                for (int i = 10; i < 60; i++)
                {
                    lst.Add(i.ToString());
                }
                return lst;
            }
            #endregion
            
        }
    }
}
