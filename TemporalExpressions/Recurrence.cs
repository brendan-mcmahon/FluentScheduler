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
            rules = new List<IRule>();
        }

        private ICollection<IRule> rules;

        public Recurrence AddRule(IRule rule)
        {
            rules.Add(rule);

            return this;
        }

        public Recurrence And(IRule rule)
        {
            AddRule(rule);

            return this;
        }

        public bool Evaluate(DateTime date)
        {
            if (rules.Where(r => r.OverrideIfEvaluationFails).Any(r => !r.Evaluate(date)))
                return false;

            if (rules.Where(r => !r.OverrideIfEvaluationFails).Any(r => r.Evaluate(date)))
                return true;

            return false;
        }
    }
}