using System;

namespace TemporalExpressions.Rules
{
    public class EveryDayOfTheMonth : RuleBase
    {
        public int Day { get; set; }

        public EveryDayOfTheMonth(int dayOfTheMonth) : this(1, dayOfTheMonth) { }

        public EveryDayOfTheMonth(int ordinal, int dayOfTheMonth)
        {
            Ordinal = ordinal;
            Day = dayOfTheMonth;
        }

        public override bool Evaluate(DateTime date)
        {
            if (EvaluateChain(date))
            {
                if (!IsWithinRange(date)) return false;

                if (DateOverflowsToNextMonth(date) && date.Day == 1) return true;

                if (date.Day == Day) return true;
            }

            return false;
        }

        private bool DateOverflowsToNextMonth(DateTime date) =>
                (date.MonthFollowsMonthWithLessThan31Days() && Day > 30) ||
                (date.MonthIsMarch() && date.IsLeapYear() && Day > 29) ||
                (date.MonthIsMarch() && Day > 28);
    }
}