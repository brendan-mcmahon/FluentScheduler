using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using TemporalExpressions;
using TemporalExpressions.Rules;

namespace TemporalDeserializer
{
    internal static class RuleConverter
    {
        internal static ICollection<IRule> ToIRules(this ICollection<RuleInfo> collection) =>
            collection.ResolveToNewList(Resolve);

        private static IRule Resolve(RuleInfo rule)
        {
            var typeResolver = new Dictionary<RecurrenceType, Func<RuleInfo, IRule>>{
                { RecurrenceType.On, r => r.MapInfoToRule(Occur.On(r.Date.Value)) },
                { RecurrenceType.OnEvery, DecideAndAddOnEveryRule },
                { RecurrenceType.OnThe, r => r.MapInfoToRule(Occur.OnThe(r.Ordinal, r.DayOfWeek.Value)) },
                { RecurrenceType.Not, r => r.MapInfoToRule(Occur.Not(r.Rules.ToIRules().FirstOrDefault())) }
            };

            return typeResolver[rule.RecurrenceType](rule);
        }

        private static IRule MapInfoToRule(this RuleInfo rule, IRule newRule)
        {
            newRule.Rules = rule.Rules.ToIRules();
            newRule.StartingOn(rule.StartDate);
            newRule.EndingOn(rule.EndDate);

            return newRule;
        }

        private static IRule DecideAndAddOnEveryRule(RuleInfo rule)
        {
            IRule newRule;
            if (rule.DayOfWeek.HasValue)
                newRule = Occur.OnEvery(rule.Ordinal, rule.DayOfWeek.Value);

            else if (rule.DayOfMonth.HasValue && !rule.Month.HasValue)
                newRule = Occur.OnEvery(rule.DayOfMonth.Value);

            else if (rule.DayOfMonth.HasValue && rule.Month.HasValue)
                newRule = Occur.OnEvery(rule.DayOfMonth.Value, rule.Month.Value);

            else if (rule.TimeUnit.HasValue)
                newRule = Occur.OnEvery(rule.Ordinal, rule.TimeUnit.Value);

            else
                throw new NotSupportedException($"The Recurrence type is {nameof(rule.RecurrenceType)} but is missing one or more valid parameter.");

            return rule.MapInfoToRule(newRule);
        }
    }
}
