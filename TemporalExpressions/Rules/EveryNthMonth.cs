using System;
using System.Linq;

namespace TemporalExpressions.Rules
{
    public class EveryNthMonth : RuleBase
    {
        public EveryNthMonth(int ordinal)
        {
            Ordinal = ordinal;
        }

        internal override int CountBetween(DateTime firstDate, DateTime endDate)
        {
            ValidateSubRule();

            var mod = MonthsSinceLastInstance(firstDate);
            var firstInstance = firstDate.AddMonths(Ordinal - mod);

            var count = MonthsBetween(firstInstance, endDate) / Ordinal;
            if (firstInstance <= endDate) count++;

            return count;
        }

        private int MonthsSinceLastInstance(DateTime date) =>
            (MonthsBetween(StartDate, date)) % Ordinal;


        internal override bool InnerEvaluation(DateTime date)
        {
            ValidateSubRule();
            return (MonthsBetweenStartAndDate(date) % Ordinal == 0);
        }

        private void ValidateSubRule()
        {
            if (!Rules.Any(r => r.GetType() == typeof(EveryDayOfTheMonth) || r.GetType() == typeof(OnTheNthDayOfTheWeekInMonth)))
                throw new MissingRuleException("This rule requires a subrule to specify which day of the month to evaluate. Use the extension method OnThe() to be more specific.");
        }

        private int MonthsBetweenStartAndDate(DateTime date) => 
            MonthsBetween(StartDate, date);

        private int MonthsBetween(DateTime dateOne, DateTime dateTwo)
        {
            var startMonths = (dateOne.Month + (dateOne.Year * 12));
            var endMonths = (dateTwo.Month + (dateTwo.Year * 12));

            return Math.Abs(startMonths - endMonths);
        }
    }
}