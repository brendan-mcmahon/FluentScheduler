using System;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    public class OnDate : RuleBase
    {
        DateTime Date { get; set; }

        public OnDate(DateTime date)
        {
            Date = date;
        }

        internal override bool InnerEvaluation(DateTime date) =>
            date == Date;
    }
}