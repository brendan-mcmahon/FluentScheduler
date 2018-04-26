using System;
using System.Collections.Generic;
using System.Linq;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    public class Recurrence
    {
        public Recurrence()
        {
            Rules = new List<IRule>();
        }

        public ICollection<IRule> Rules { get; private set; }

        public Recurrence AddRule(IRule rule)
        {
            Rules.Add(rule);

            return this;
        }

        public Recurrence And(IRule rule)
        {
            AddRule(rule);

            return this;
        }

        public bool Evaluate(DateTime date)
        {
            if (Rules.Where(r => r.OverrideIfEvaluationFails).Any(r => !r.Evaluate(date)))
                return false;

            if (Rules.Where(r => !r.OverrideIfEvaluationFails).Any(r => r.Evaluate(date)))
                return true;

            return false;
        }
    }
}