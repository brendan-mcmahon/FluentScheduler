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

        public static int TotalMonths(this DateTime date) =>
            (date.Year * 12) + date.Month;

        public static bool IsBetween(this DateTime date, DateTime dateOne, DateTime dateTwo)
        {
            return (date >= dateOne && date <= dateTwo);
        }
    }
}
