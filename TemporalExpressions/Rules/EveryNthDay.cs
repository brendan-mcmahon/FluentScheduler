using System;
using System.Collections.Generic;

namespace TemporalExpressions.Rules
{
    public class EveryNthDay : RuleBase
    {
        public EveryNthDay(int ordinal)
        {
            Ordinal = ordinal;
        }

        public override List<DateTime> InnerCount(DateTime date1, DateTime date2)
        {
            throw new NotImplementedException();
        }

        internal override int CountBetween(DateTime firstDate, DateTime endDate)
        {
            var mod = DaysSinceLastInstance(firstDate);
            var firstInstance = firstDate.AddDays(Ordinal - mod);

            var count = (endDate - firstInstance).Days / Ordinal;
            if (firstInstance <= endDate) count++;
            
            return count;
        }

        internal override bool CountEvaluator(DateTime key)
        {
            throw new NotImplementedException();
        }

        internal override bool InnerEvaluation(DateTime date) =>
            DaysSinceLastInstance(date) == 0;

        private int DaysSinceLastInstance(DateTime date) => 
            ((date - StartDate).Days) % Ordinal;

    }
}