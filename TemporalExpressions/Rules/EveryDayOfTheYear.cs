using System;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    internal class EveryDayOfTheYear : RuleBase
    {
        public int Day { get; set; }
        public Month Month { get; set; }

        public EveryDayOfTheYear(int dayOfTheMonth, Month month) : this(1, dayOfTheMonth, month) { }

        public EveryDayOfTheYear(int ordinal, int dayOfTheMonth, Month month)
        {
            Ordinal = ordinal;
            Day = dayOfTheMonth;
            Month = month;
        }

        public override bool InnerEvaluation(DateTime date) =>
            date.Day == Day && date.Month == (int) Month ||
            date.Day == 1 && date.Month == (int) Month.March;
    }
}