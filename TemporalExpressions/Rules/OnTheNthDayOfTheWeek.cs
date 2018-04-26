using System;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    internal class OnTheNthDayOfTheWeek : RuleBase
    {
        public DayOfWeek DayOfWeek;

        public OnTheNthDayOfTheWeek(int ordinal)
        {
            Ordinal = ordinal;
            DayOfWeek = StartDate.DayOfWeek;
        }

        public OnTheNthDayOfTheWeek(int ordinal, DayOfWeek dayOfWeek)
        {
            Ordinal = ordinal;
            DayOfWeek = dayOfWeek;
        }

        public override bool InnerEvaluation(DateTime date) =>
            date.DayOfWeek == DayOfWeek &&
            date.Day > (7 * (Ordinal - 1)) &&
            date.Day <= (7 * Ordinal);
    }
}