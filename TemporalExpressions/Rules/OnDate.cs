using System;

namespace TemporalExpressions.Rules
{
    public class OnDate : RuleBase
    {
        private readonly DateTime _date;

        public OnDate(DateTime date) => 
            _date = date;

        internal override int CountBetween(DateTime firstDate, DateTime endDate) =>
            (_date.IsBetween(firstDate, endDate)) ? 1 : 0;

        internal override bool InnerEvaluation(DateTime date) =>
            date == _date;
    }
}