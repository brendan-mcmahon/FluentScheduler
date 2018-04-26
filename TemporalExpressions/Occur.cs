using System;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    public static class Occur
    {
        public static IRule On(DateTime date) => 
            new OnDate(date);

        public static IRule OnEvery(DayOfWeek dayOfWeek) => 
            OnEvery(1, dayOfWeek);

        public static IRule OnThe(int ordinal, DayOfWeek dayOfWeek) => 
            new OnTheNthDayOfTheWeek(ordinal, dayOfWeek);

        public static IRule OnEvery(int ordinal, DayOfWeek dayOfWeek) => 
            new EveryDayOfTheWeek(ordinal, dayOfWeek);

        public static IRule OnEvery(int dayOfMonth) => 
            OnEvery(1, dayOfMonth);

        public static IRule OnEvery(int dayOfMonth, Month month) => 
            new EveryDayOfTheYear(1, dayOfMonth, month);

        public static IRule OnEvery(int ordinal, int dayOfMonth) => 
            new EveryDayOfTheMonth(dayOfMonth);

        public static IRule OnEvery(TimeUnit unit) => 
            OnEvery(1, unit);

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
