using System;
using System.Collections.Generic;

namespace TemporalExpressions.Rules
{
    public class OnDate : RuleBase
    {
        private readonly DateTime _date;

        public OnDate(DateTime date) => 
            _date = date;

        public override List<DateTime> InnerCount(DateTime date1, DateTime date2)
        {
            throw new NotImplementedException();
        }

        internal override int CountBetween(DateTime firstDate, DateTime endDate) =>
            (_date.IsBetween(firstDate, endDate)) ? 1 : 0;

        internal override bool CountEvaluator(DateTime key)
        {
            throw new NotImplementedException();
        }

        internal override bool InnerEvaluation(DateTime date) =>
            date == _date;
    }
}