using Common;
using System;

namespace TemporalExpressions.Rules
{
    public class EveryNthYear : RuleBase
    {
        public EveryNthYear(int ordinal) => 
            Ordinal = ordinal;

        internal override bool InnerEvaluation(DateTime date) =>
            (YearsBetweenStartAndDate(date) % Ordinal == 0);

        private int YearsBetweenStartAndDate(DateTime date) =>
            (StartDate.Year - date.Year);

        public override string ToString()
        {
            var subRules = Rules.ResolveToNewList(r => r.ToString());
            return $"on every {Ordinal.ToOrdinal()} year {subRules.ListToString()}";
        }
    }
}