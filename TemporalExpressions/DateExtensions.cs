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

        public static string ToOrdinal(this int n)
        {
            if (n == 1 || n == 0) return "";
            else if (n == 2) return "other";
            else if (n == 3) return "3rd";
            else return $"{n}th";
        }
    }
}
