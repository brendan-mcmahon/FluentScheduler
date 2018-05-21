using System;

namespace TemporalExpressions.Rules
{
    public class OnTheNthDayOfTheWeekInMonth : RuleBase
    {
        private DayOfWeek? dayOfWeek;
        public DayOfWeek DayOfWeek
        {
            get => dayOfWeek?? StartDate.DayOfWeek;
            set => dayOfWeek = value;
        }

        public OnTheNthDayOfTheWeekInMonth(int ordinal)
        {
            Ordinal = ordinal;
        }

        public OnTheNthDayOfTheWeekInMonth(int ordinal, DayOfWeek dayOfWeek)
        {
            Ordinal = ordinal;
            DayOfWeek = dayOfWeek;
        }


        internal override int CountBetween(DateTime firstDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        internal override bool InnerEvaluation(DateTime date) =>
            date.DayOfWeek == DayOfWeek &&
            date.Day > (7 * (Ordinal - 1)) &&
            date.Day <= (7 * Ordinal);
    }
}