using System;
using System.Collections.Generic;
using System.Linq;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    public class Recurrence
    {
        private object r;

        public Recurrence()
        {
            Rules = new List<IRule>();
        }

        public ICollection<IRule> Rules { get; set; }

        public bool Evaluate(DateTime date)
        {
            if (Rules.Any(r => r.OverrideIfEvaluationFails && !r.Evaluate(date)))
                return false;

            if (Rules.Any(r => r.Evaluate(date)))
                return true;

            return false;
        }
    }
}