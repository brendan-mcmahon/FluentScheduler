using System;

namespace TemporalExpressions.Rules
{
    public class EveryNthDay : RuleBase
    {
        public EveryNthDay(int ordinal)
        {
            Ordinal = ordinal;
        }

        public override bool Evaluate(DateTime date)
        {
            if (EvaluateChain(date)){

                if (!IsWithinRange(date)) return false;

                var days = GetDaysInbetweenDates(date);
                return (days % Ordinal == 0);
            }

            return false;
        }

        private int GetDaysInbetweenDates(DateTime date) =>
            (date - StartDate).Days;
        
    }
}