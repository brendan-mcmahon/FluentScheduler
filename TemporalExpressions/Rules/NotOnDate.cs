using System;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    public class NotOnDate : RuleBase
    {
        public NotOnDate(DateTime date)
        {
            OverrideIfEvaluationFails = true;
            StartDate = date;
        }

        public override bool Evaluate(DateTime date) =>
            date != StartDate;
    }
}