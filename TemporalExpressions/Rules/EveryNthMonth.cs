using System;
using System.Collections.Generic;
using System.Linq;
using static TemporalExpressions.DateExtensions;

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

            var count = TotalMonthsBetween(firstInstance, endDate) / Ordinal;
            if (firstInstance <= endDate) count++;

            return count;
        }

        private int MonthsSinceLastInstance(DateTime date) =>
            (TotalMonthsBetween(StartDate, date)) % Ordinal;


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
            TotalMonthsBetween(StartDate, date);

        public override List<DateTime> InnerCount(DateTime date1, DateTime date2)
        {
            var list = new List<DateTime>();
            var currentDate = FindFirstInstance(date1);
            while (currentDate < date2)
            {
                list.AddRange(DatesInMonth(currentDate));
                currentDate.AddMonths(Ordinal);
                currentDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            }

            return list;
        }

        private static List<DateTime> DatesInMonth(DateTime date) => Enumerable.Range(date.Day, DateTime.DaysInMonth(date.Year, date.Month))
                             .Select(day => new DateTime(date.Year, date.Month, day))
                             .ToList();

        private DateTime FindFirstInstance(DateTime date1)
        {
            var difference = TotalMonthsBetween(date1, StartDate);
            return StartDate.AddMonths(difference + (difference % Ordinal));
        }

        internal override bool CountEvaluator(DateTime date)
        {
            return InnerEvaluation(date);
        }
    }
}