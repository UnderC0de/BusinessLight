using System;

namespace BusinessLight.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToTimeZone(this DateTime date, TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.ConvertTime(new DateTime(date.Ticks, DateTimeKind.Utc), timeZone);
        }
    }
}
