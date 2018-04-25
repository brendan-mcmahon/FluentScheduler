using System;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    internal class OnTheNthDayOfTheWeek : RuleBase
    {
        public DayOfWeek DayOfWeek;

        public OnTheNthDayOfTheWeek(int ordinal, DayOfWeek dayOfWeek)
        {
            Ordinal = ordinal;
            DayOfWeek = dayOfWeek;
        }

        public override bool Evaluate(DateTime date)
        {
            if (EvaluateChain(date))
            {
                if (!IsWithinRange(date)) return false;

                return date.DayOfWeek == DayOfWeek &&
                date.Day > (7 * (Ordinal - 1)) &&
                (date.Day <= 7 * Ordinal);
            }

            return false;
        }
    }
}