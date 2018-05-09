using System;

namespace TemporalExpressions.Rules
{
    public class EveryDayOfTheYear : RuleBase
    {
        public int Day { get; set; }
        public Month Month { get; set; }

        public EveryDayOfTheYear(int dayOfTheMonth, Month month)
        {
            Day = dayOfTheMonth;
            Month = month;
        }

        internal override bool InnerEvaluation(DateTime date) =>
            date.Day == Day && date.Month == (int) Month ||
            date.Day == 1 && date.Month == (int) Month.March;
    }
}