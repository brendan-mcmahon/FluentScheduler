﻿using System;

namespace TemporalExpressions
{
    public static class HelperExtensions
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
    }
}
