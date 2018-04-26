using System;

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

        public override bool InnerEvaluation(DateTime date) =>
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
    }
}