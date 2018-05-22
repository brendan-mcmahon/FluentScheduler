using System;
using System.Collections.Generic;
using System.Linq;
using static TemporalExpressions.DateExtensions;

namespace TemporalExpressions.Rules
{
    public class EveryDayOfTheMonth : RuleBase
    {
        public int Day { get; set; }

        public EveryDayOfTheMonth(int dayOfTheMonth)
        {
            Day = dayOfTheMonth;
            Ordinal = 1;
        }

        internal override bool InnerEvaluation(DateTime date) =>
            DateOverflowsToNextMonth(date) && date.Day == 1 ||
            date.Day == Day;

        private bool DateOverflowsToNextMonth(DateTime date) =>
                (date.MonthFollowsMonthWithLessThan31Days() && Day > 30) ||
                (date.MonthIsMarch() && date.IsLeapYear() && Day > 29) ||
                (date.MonthIsMarch() && Day > 28);

        internal override int CountBetween(DateTime firstDate, DateTime endDate)
        {
            var totalMonths = TotalMonthsBetween(firstDate, endDate);
            if (firstDate.Day > Day)
                totalMonths--;
            if (endDate.Day >= Day)
                totalMonths++;

            return totalMonths;
        }

        public override List<DateTime> InnerCount(DateTime date1, DateTime date2)
        {
            var list = new List<DateTime>();
            var currentDate = FindFirstInstance(date1);
            while (currentDate < date2)
            {
                list.Add(currentDate);
                currentDate.AddMonths(1);
            }

            return list;
        }

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