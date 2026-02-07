using System;



namespace AVcontrol
{
    /// <summary>
    /// Storing time in 4 bytes (UInt32) as MINUTES passed since the start date 01.01.2025 00:00 UTC.
    /// </summary>
    public class DateTime4b
    {
        // Constants
        private const UInt32 UnixTimestamp2025 = 1735689600; // 01.01.2025 in Unix Time (seconds)
        private const UInt32 SecondsInMinute   = 60;
        private const UInt32 MinutesInHour     = 60;
        private const UInt32 MinutesInDay      = 1440; // 24 * 60
        private const UInt32 MinutesInYear     = 525_600; // 365 * 24 * 60
        private static readonly UInt32[] DaysPerMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];


        private readonly UInt32 _minutesFromBase;



        private Byte CalculateMonth(UInt32 year)
        {
            UInt32 days = (_minutesFromBase % MinutesInYear) / MinutesInDay;

            for (Byte month = 1; month < 12; month++)
            {
                UInt32 daysInMonth = (month == 2 && IsLeapYear(year)) ? 29 : DaysPerMonth[month - 1];

                if (days < daysInMonth)
                    return month;

                days -= daysInMonth;
            }

            return 12;
        }
        private UInt32 CalculateDayInMonth()
        {
            UInt32 year = CurrentYear;
            Byte month = CalculateMonth(year);
            UInt32 days = (_minutesFromBase % MinutesInYear) / MinutesInDay;

            for (Byte m = 1; m < month; m++)
            {
                days -= (m == 2 && IsLeapYear(year) ? 29 : DaysPerMonth[m - 1]);
            }

            return days + 1;
        }
        private static bool IsLeapYear(UInt32 year) => (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);





        public DateTime4b(UInt32 curMinute, UInt32 curHour,
            UInt32 curDay, UInt32 curMonth, UInt32 curYear)
        {
            if (curYear   < 2025 ||
                curMonth  < 1    || curMonth > 12 ||
                curDay    < 0    || curDay > 31 ||
                curHour   > 23   ||
                curMinute > 59) throw new ArgumentException("Invalid date or time components provided.");

            //  Do not do curMonth -= 1 because it is already "done" in the loop logic
            curYear -= 2025;
            curDay  -= 1;


            UInt32 daysInPassedMonths = 0;
            for (Int32 month = 1; month < curMonth; month++)
            {
                daysInPassedMonths += (month == 2 && IsLeapYear(curYear + 2025))
                    ? 29 : DaysPerMonth[month - 1];
            }

            _minutesFromBase = curMinute +
                               (curHour * MinutesInHour) +
                              ((curDay  + daysInPassedMonths) * MinutesInDay) +
                               (curYear * MinutesInYear);
        }
        public DateTime4b(UInt32 minutesFromBase, UInt32 hoursFromBase, UInt32 daysFromBase, UInt32 yearsFromBase)
        {
            _minutesFromBase = minutesFromBase +
                               (hoursFromBase  * MinutesInHour) +
                               (daysFromBase   * MinutesInDay) +
                               (yearsFromBase  * MinutesInYear);
        }
        public DateTime4b(UInt32 minutesFromBase, UInt32 hoursFromBase, UInt32 daysFromBase)
        {
            _minutesFromBase = minutesFromBase +
                               (hoursFromBase  * MinutesInHour) +
                               (daysFromBase   * MinutesInDay);
        }
        public DateTime4b(UInt32 minutesFromBase, UInt32 hoursFromBase)
        {
            _minutesFromBase = minutesFromBase +
                               (hoursFromBase  * MinutesInHour);
        }
        public DateTime4b(UInt32 minutesFromBase) => _minutesFromBase = minutesFromBase;
        public DateTime4b(DateTime dateTime)
        {
            Int64 timestamp = new DateTimeOffset(dateTime).ToUnixTimeSeconds();

            // Ensure the date is not before 01.01.2025
            if (timestamp < UnixTimestamp2025)
                throw new ArgumentOutOfRangeException(nameof(dateTime), "Date cannot be before 01.01.2025.");

            _minutesFromBase = (UInt32)((timestamp - UnixTimestamp2025) / SecondsInMinute);
        }



        public static DateTime4b FromDateTime(DateTime dateTime)
        {
            Int64 timestamp = new DateTimeOffset(dateTime).ToUnixTimeSeconds();

            if (timestamp < UnixTimestamp2025)
                throw new ArgumentOutOfRangeException(nameof(dateTime), "Date cannot be before 01.01.2025.");

            UInt32 minutes = (UInt32)((timestamp - UnixTimestamp2025) / SecondsInMinute);

            return new DateTime4b(minutes);
        }
        public static DateTime4b Now => FromDateTime(DateTime.UtcNow);
        public DateTime ToDateTime()
        {
            ulong totalSeconds = UnixTimestamp2025 + (_minutesFromBase * SecondsInMinute);
            return DateTimeOffset.FromUnixTimeSeconds((Int64)totalSeconds).UtcDateTime;
        }





        // Raw data access
        public UInt32 PassedTotalYears   => _minutesFromBase / MinutesInYear;
        public UInt32 PassedTotalMonths  => _minutesFromBase / MinutesInYear * 12 + CurrentMonth - 1;
        public UInt32 PassedTotalDays    => _minutesFromBase / MinutesInDay;
        public UInt32 PassedTotalHours   => _minutesFromBase / MinutesInHour;
        public UInt32 PassedTotalMinutes => _minutesFromBase;



        // Date components
        public UInt32 PassedYears   => PassedTotalYears;
        public UInt32 PassedMonths  => CurrentMonth - 1;
        public UInt32 PassedDays    => CurrentDay - 1;
        public UInt32 PassedHours   => CurrentHour;
        public UInt32 PassedMinutes => CurrentMinute;


        public UInt32 CurrentYear   => PassedTotalYears + 2025;
        public UInt32 CurrentMonth  => CalculateMonth(CurrentYear);
        public UInt32 CurrentDay    => CalculateDayInMonth();
        public UInt32 CurrentHour   => (_minutesFromBase % MinutesInDay) / MinutesInHour;
        public UInt32 CurrentMinute => _minutesFromBase % MinutesInHour;



        public string ToStringFull()
        {
            UInt32 year = CurrentYear;
            UInt32 month = CalculateMonth(year);
            UInt32 day = CalculateDayInMonth();

            return $"{day:00}.{month:00}.{year:0000} {CurrentHour:00}:{CurrentMinute:00}";
        }
        public string ToStringDate()
        {
            UInt32 year  = CurrentYear;
            UInt32 month = CalculateMonth(year);
            UInt32 day   = CalculateDayInMonth();

            return $"{day:00}.{month:00}.{year:0000}";
        }
        public string ToStringTime()
            => $"{CurrentHour:00}:{CurrentMinute:00}";
    }
}