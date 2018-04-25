using System;

namespace TemporalExpressions.Rules
{
    public class EveryNthMonth : RuleBase
    {
        public EveryNthMonth(int ordinal)
        {
            Ordinal = ordinal;
        }

        public override bool Evaluate(DateTime date)
        {
            if (EvaluateChain(date))
            {
                if (!IsWithinRange(date)) return false;

                var months = GetMonthsBetweenDates(date);
                return (months % Ordinal == 0);
            }

            return false;
        }

        private int GetMonthsBetweenDates(DateTime date)
        {
            var endMonths = (date.Month + (date.Year * 12));
            var startMonths = (StartDate.Month + (StartDate.Year * 12));

            return (startMonths - endMonths);
        }
    }
}