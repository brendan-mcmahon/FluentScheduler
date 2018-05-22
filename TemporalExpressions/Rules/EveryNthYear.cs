using System;
using System.Collections.Generic;

namespace TemporalExpressions.Rules
{
    public class EveryNthYear : RuleBase
    {
        public EveryNthYear(int ordinal)
        {
            Ordinal = ordinal;
        }

        public override List<DateTime> InnerCount(DateTime date1, DateTime date2)
        {
            throw new NotImplementedException();
        }

        internal override int CountBetween(DateTime firstDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        internal override bool CountEvaluator(DateTime key)
        {
            throw new NotImplementedException();
        }

        internal override bool InnerEvaluation(DateTime date) =>
            (YearsBetweenStartAndDate(date) % Ordinal == 0);

        private int YearsBetweenStartAndDate(DateTime date) =>
            (StartDate.Year - date.Year);
    }
}