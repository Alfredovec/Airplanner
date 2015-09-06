using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToAirplaneTime(this DateTime dateTime)
        {
            string day = dateTime.Day < 10 ? "0" + dateTime.Day.ToString() : dateTime.Day.ToString();
            string month = dateTime.Month < 10 ? "0" + dateTime.Month.ToString() : dateTime.Month.ToString();
            string hour = dateTime.Hour < 10 ? "0" + dateTime.Hour.ToString() : dateTime.Hour.ToString();
            string minute = dateTime.Minute < 10 ? "0" + dateTime.Minute.ToString() : dateTime.Minute.ToString();
            return string.Format("{0}/{1} | {2}:{3}",
                day,
                month,
                hour,
                minute);
        }
    }
}
