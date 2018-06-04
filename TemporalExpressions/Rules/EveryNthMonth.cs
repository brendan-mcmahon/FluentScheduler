using System;

namespace TemporalExpressions.Rules
{
    public class EveryNthMonth : RuleBase
    {
        public EveryNthMonth(int ordinal) => 
            Ordinal = ordinal;

        internal override bool InnerEvaluation(DateTime date) =>
            (MonthsBetweenStartAndDate(date) % Ordinal == 0);

        private int MonthsBetweenStartAndDate(DateTime date)
        {
            var endMonths = (date.Month + (date.Year * 12));
            var startMonths = (StartDate.Month + (StartDate.Year * 12));

            return (startMonths - endMonths);
        }

        public override string ToString() =>
            $"on every {Ordinal.ToOrdinal()} month";
    }
}