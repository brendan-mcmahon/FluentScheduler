using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    /// <summary>
    /// Object containing the rules for recurring as well as the functionality to evaluate any given date.
    /// </summary>
    public class Recurrence
    {
        public Recurrence() : this(new List<IRule>()) { }
        public Recurrence(ICollection<IRule> rules) => 
            Rules = rules;

        public ICollection<IRule> Rules { get; set; }

        /// <summary>
        /// Adds a rule to the Recurrence. </summary>
        /// <param name="rule"> The rule to be added to the rules collection. </param>
        /// <returns>This Recurrence with the new rule. </returns>
        public Recurrence AddRule(IRule rule)
        {
            Rules.Add(rule);

            return this;
        }

        /// <summary>
        /// Adds a rule to the Recurrence. (Falls through to Recurrence.AddRule())</summary>
        /// <param name="rule"> The rule to be added to the rules collection. </param>
        /// <returns>This Recurrence with the new rule. </returns>
        public Recurrence And(IRule rule)
        {
            AddRule(rule);

            return this;
        }

        /// <summary>
        /// Evaluates whether or not a date occurs according to the rules of Recurrence. </summary>
        /// <param name="date"> The date to be evaluated. </param>
        /// <returns> True if the date occurs, false otherwise. </returns>
        public bool Evaluate(DateTime date)
        {
            if (Rules.Where(r => r.OverrideIfEvaluationFails).Any(r => !r.Evaluate(date)))
                return false;

            if (Rules.Where(r => !r.OverrideIfEvaluationFails).Any(r => r.Evaluate(date)))
                return true;

            return false;
        }

        public int Count(DateTime date1, DateTime date2)
        {
            var count = 0;
            foreach(var rule in Rules)
            {
                count += rule.Count(date1, date2);
            }
            return count;
        }

        public override string ToString()
        {
            var allStrings = Rules.ResolveToNewList(r =>
                (r.InvertEvaluation) ? "not " + r.ToString() : r.ToString());

            var pretty = String.Join(", ", allStrings).Prettify();

            return Char.ToLowerInvariant(pretty[0]) + pretty.Substring(1);
        }
    }
}