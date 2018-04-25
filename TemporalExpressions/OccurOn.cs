using System;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    public static class Occur
    {
        public static IRule On(DateTime date)
        {
            return new OnDate(date);
        }

        public static IRule NotOn(DateTime date)
        {
            return new NotOnDate(date);
        }

        public static IRule OnEvery(DayOfWeek dayOfWeek)
        {
            return OnEvery(1, dayOfWeek);
        }

        internal static IRule OnThe(int ordinal, DayOfWeek dayOfWeek)
        {
            return new OnTheNthDayOfTheWeek(ordinal, dayOfWeek);
        }

        public static IRule OnEvery(int ordinal, DayOfWeek dayOfWeek)
        {
            return new EveryDayOfTheWeek(ordinal, dayOfWeek);
        }

        public static IRule OnEvery(int dayOfMonth)
        {
            return OnEvery(1, dayOfMonth);
        }

        public static IRule OnEvery(int ordinal, int dayOfMonth)
        {
            return new EveryDayOfTheMonth(dayOfMonth);
        }

        public static IRule OnEvery(TimeUnit unit)
        {
            return OnEvery(1, unit);
        }

        public static IRule OnEvery(int ordinal, TimeUnit unit)
        {
            switch (unit)
            {
                case TimeUnit.Days:
                    return new EveryNthDay(ordinal);
                case TimeUnit.Months:
                    return new EveryNthMonth(ordinal);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
