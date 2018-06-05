using Common;
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

        public override string ToString()
        {
            var subRules = Rules.ResolveToNewList(r => r.ToString()).ListToString();
            var plural = Ordinal > 1;
            if (plural)
            {
                return $"every {Ordinal} months {subRules}";
            }
            return $"every month {subRules}";
            //$"on every {(Ordinal > 1 ? Ordinal.ToString() : "")} month{(Ordinal > 1 ? "s" : "")}";
        }
    }
}