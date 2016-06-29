using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel.Functions
{
    public class DateHelper
    {
        public static IEnumerable<int> YearList;
        public static IEnumerable<MonthClass> MonthList;
        public static IEnumerable<byte> DayList;

       


        public static DateTime GetDate(int year, int month, int day)
        {
            return new DateTime(year, month, day);
        }

        public static IEnumerable<int> GetYearList()
        {
            
            if (YearList == null)
            {
                var yearList = new List<int>();
                var date = DateTime.Now;
                for (int i = date.Year - 70; i < date.Year + 3; i++)
                {
                    yearList.Add(i);
                }
                YearList = yearList;
            }
            return YearList;
        }

        public static IEnumerable<MonthClass> GetMonthList()
        {
            if (MonthList == null)
            {
                var monthList = new List<MonthClass>();
                for (int i = 0; i < 12; i++)
                {
                    monthList.Add(new MonthClass() { Name = Enum.GetName(typeof(Month), i), Id = i });
                }
                MonthList = monthList;
            }
            return MonthList;
        }

        public static IEnumerable<byte> GetDayList()
        {
            if (DayList == null)
            {
                var dayList = new List<byte>();
                for (byte i = 1; i < 32; i++)
                {
                    dayList.Add(i);
                }
                DayList = dayList;
            }
            return DayList;

        }
    }
}
