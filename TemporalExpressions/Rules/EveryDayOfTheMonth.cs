using System;

namespace TemporalExpressions.Rules
{
    public class EveryDayOfTheMonth : RuleBase
    {
        public int Day { get; set; }

        public EveryDayOfTheMonth(int dayOfTheMonth)
        {
            Day = dayOfTheMonth;
        }

        internal override bool InnerEvaluation(DateTime date) =>
            DateOverflowsToNextMonth(date) && date.Day == 1 ||
            date.Day == Day;

        private bool DateOverflowsToNextMonth(DateTime date) =>
                (date.MonthFollowsMonthWithLessThan31Days() && Day > 30) ||
                (date.MonthIsMarch() && date.IsLeapYear() && Day > 29) ||
                (date.MonthIsMarch() && Day > 28);
    }
}