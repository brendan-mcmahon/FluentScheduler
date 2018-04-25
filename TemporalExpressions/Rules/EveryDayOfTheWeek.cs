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

        public override bool Evaluate(DateTime date)
        {
            if (EvaluateChain(date))
            {
                if (!IsWithinRange(date)) return false;

                if (date.DayOfWeek == DayOfWeek && IsDivisibleByOrdinal(date)) return true;
            }

            return false;
        }

        private bool IsDivisibleByOrdinal(DateTime date)
        {
            var firstInstance = MostRecentInstanceOfDayOfWeek();
            var daysBetween = (date - firstInstance).Days;
            var result = daysBetween % (Ordinal * 7) == 0;
            return result;
        }

        private DateTime MostRecentInstanceOfDayOfWeek()
        {
            var difference = Math.Abs(DayOfWeek - (StartDate.DayOfWeek + 7));
            return StartDate.AddDays(-difference);
        }
    }
}