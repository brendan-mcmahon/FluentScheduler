using Common;
using System;
using System.Linq;

namespace TemporalExpressions.Rules
{
    public class EveryNthMonth : RuleBase
    {
        public EveryNthMonth(int ordinal) =>
            Ordinal = ordinal;

        internal override bool InnerEvaluation(DateTime date) =>
            (MonthsBetweenStartAndDate(date) % Ordinal == 0);

        private int MonthsBetweenStartAndDate(DateTime date)
        {
            var endMonths = (date.Month + (date.Year * 12));
            var startMonths = (StartDate.Month + (StartDate.Year * 12));

            return (startMonths - endMonths);
        }

        public override string ToString()
        {
            var onTheRule = Rules.SingleOrDefault(r => r.GetType() == typeof(EveryDayOfTheMonth));
            if (onTheRule != null)
            {
                var day = ((EveryDayOfTheMonth)onTheRule).Day.ToOrdinal(false);
                return $"on every {Ordinal.ToOrdinal()} month on the {day}";
            }

            onTheRule = Rules.SingleOrDefault(r => r.GetType() == typeof(OnTheNthDayOfTheWeek));
            if (onTheRule != null)
            {
                var day = ((OnTheNthDayOfTheWeek)onTheRule).DayOfWeek;
                var innerOrdinal = ((OnTheNthDayOfTheWeek)onTheRule).Ordinal;

                return $"on every {Ordinal.ToOrdinal()} month on the {innerOrdinal.ToOrdinal(false)} {day}";
            }

            throw new NotSupportedException();
        }
    }
}