using Common;
using System;
using System.Linq;

namespace TemporalExpressions.Rules
{
    public class OnDate : RuleBase
    {
        private readonly DateTime _date;

        public OnDate(DateTime date) =>
            _date = date;

        internal override bool InnerEvaluation(DateTime date) =>
            date == _date;

        public override string ToString() =>
            $"on {_date.ToString("MMMM dd, yyyy")}{SubRulesString()}";
    }
}