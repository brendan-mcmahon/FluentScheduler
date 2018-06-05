using System;

namespace TemporalExpressions
{
    public static class DateExtensions
    {
        public static bool MonthFollowsMonthWithLessThan31Days(this DateTime date) =>
            (date.Month == (int) Month.March ||
             date.Month == (int) Month.May ||
             date.Month == (int) Month.July ||
             date.Month == (int) Month.October ||
             date.Month == (int) Month.December);

        public static bool MonthIsMarch(this DateTime date) =>
            date.Month == (int) Month.March;

        public static bool IsLeapYear(this DateTime date) =>
            date.Year % 4 == 0;

        public static string ToOrdinal(this int n, bool adjustforBrevity = true)
        {
            if (n == 0) return "";

            else if (n == 1 && adjustforBrevity) return "";
            else if (n == 11) return "11th";
            else if ((n % 10 == 1) && !adjustforBrevity) return $"{n}st";

            else if (n == 2 && adjustforBrevity) return "other";
            else if ((n == 2 && !adjustforBrevity)) return $"{n}nd";
            else if (n == 12) return "12th";
            else if (n % 10 == 2) return $"{n}nd";

            else if (n == 13) return "13th";
            else if ((n % 10 == 3)) return $"{n}rd";
            else return $"{n}th";
        }
    }
}
