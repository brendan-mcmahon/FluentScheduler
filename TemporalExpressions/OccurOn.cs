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

        public static IRule OnEvery(int dayOfMonth, Month month)
        {
            return new EveryDayOfTheYear(1, dayOfMonth, month);
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
                case TimeUnit.Weeks:
                    return new OnTheNthDayOfTheWeek(ordinal);
                case TimeUnit.Months:
                    return new EveryNthMonth(ordinal);
                case TimeUnit.Years:
                    return new EveryNthYear(ordinal);
                default:
                    throw new NotSupportedException();
            }
        }

        public static IRule Not(IRule rule)
        {
            rule.OverrideIfEvaluationFails = true;
            rule.InvertEvaluation = true;

            return rule;
        }
    }
}
