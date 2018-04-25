using System;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    public class OnDate : RuleBase
    {
        public OnDate(DateTime date)
        {
            StartDate = date;
        }

        public override bool Evaluate(DateTime date) =>
            date == StartDate;
    }
}