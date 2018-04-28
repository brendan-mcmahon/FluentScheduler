using System;

namespace TemporalExpressions.Rules
{
    public class EveryNthDay : RuleBase
    {
        public EveryNthDay(int ordinal)
        {
            Ordinal = ordinal;
        }

        internal override bool InnerEvaluation(DateTime date) =>
            DaysBetweenStartAndDate(date) % Ordinal == 0;

        private int DaysBetweenStartAndDate(DateTime date) =>
            (date - StartDate).Days;
        
    }
}