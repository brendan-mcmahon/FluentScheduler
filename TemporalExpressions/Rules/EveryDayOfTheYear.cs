using System;
using System.Collections.Generic;

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

        internal override int CountBetween(DateTime firstDate, DateTime endDate)
        {
            var count = endDate.Year - firstDate.Year;
            if (IsBetween(firstDate, endDate))
                count++;

            return count;
        }

        private bool IsBetween(DateTime firstDate, DateTime endDate) => 
            (firstDate.Day <= Day && (Month)firstDate.Month <= Month) && 
            (endDate.Day >= Day && (Month)endDate.Month <= Month);

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