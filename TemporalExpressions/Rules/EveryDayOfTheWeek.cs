using System;
using System.Collections.Generic;

namespace TemporalExpressions.Rules
{
    public class EveryDayOfTheWeek : RuleBase
    {
        public DayOfWeek DayOfWeek { get; set; }

        public EveryDayOfTheWeek(DayOfWeek dayOfTheWeek) : this(1, dayOfTheWeek) { }

        public EveryDayOfTheWeek(int ordinal, DayOfWeek dayOfTheWeek)
        {
            Ordinal = ordinal;
            DayOfWeek = dayOfTheWeek;
        }

        internal override bool InnerEvaluation(DateTime date) =>
            date.DayOfWeek == DayOfWeek && IsDivisibleByOrdinal(date);
        

        private bool IsDivisibleByOrdinal(DateTime date)
        {
            var firstInstance = MostRecentInstanceOfDayOfWeek();
            var daysBetween = (date - firstInstance).Days;
            var result = daysBetween % (Ordinal * 7) == 0;
            return result;
        }

        private DateTime MostRecentInstanceOfDayOfWeek()
        {
            if (DayOfWeek == StartDate.DayOfWeek) return StartDate;

            var difference = Math.Abs(DayOfWeek - (StartDate.DayOfWeek + 7));
            return StartDate.AddDays(-difference);
        }

        private DateTime NextInstanceOfDayOfWeek(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek) return date;

            var difference = Math.Abs(DayOfWeek - (date.DayOfWeek));
            return date.AddDays(difference);
        }

        internal override int CountBetween(DateTime firstDate, DateTime endDate)
        {
            var count = 0;
            var nextInstance = NextInstanceOfDayOfWeek(firstDate);
            if (nextInstance < endDate) count++;
            count += ((endDate - nextInstance).Days / 7);

            return count;
        }

        internal override bool CountEvaluator(DateTime key)
        {
            throw new NotImplementedException();
        }

        public override List<DateTime> InnerCount(DateTime date1, DateTime date2)
        {
            throw new NotImplementedException();
        }
    }
}