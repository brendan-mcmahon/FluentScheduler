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
            var dictionary = new Dictionary<RecurrenceType, Func<RuleInfo, IRule>>{
                { RecurrenceType.On, r => r.MapToNewRule(Occur.On(r.Date.Value)) },
                { RecurrenceType.OnEvery, DecideAndAddOnEveryRule },
                { RecurrenceType.OnThe, r => r.MapToNewRule(Occur.OnThe(r.Ordinal, r.DayOfWeek.Value)) },
                { RecurrenceType.Not, r => r.MapToNewRule(Occur.Not(r.Rules.ToIRules().FirstOrDefault())) }
            };

            return dictionary[rule.RecurrenceType].Invoke(rule);
        }

        private static IRule MapToNewRule(this RuleInfo rule, IRule newRule)
        {
            newRule.Rules = rule.Rules.ToIRules();
            newRule.StartingOn(rule.StartDate);
            newRule.EndingOn(rule.EndDate);

            return newRule;
        }

        //private static IRule DecideAndAddOnEveryRule(RuleInfo rule)
        //{
        //    var newRule =
        //        (rule.DayOfWeek.HasValue) ?
        //            Occur.OnEvery(rule.Ordinal, rule.DayOfWeek.Value) :

        //        (rule.DayOfMonth.HasValue && !rule.Month.HasValue) ?
        //            Occur.OnEvery(rule.DayOfMonth.Value) :

        //        (rule.DayOfMonth.HasValue && rule.Month.HasValue) ?
        //            Occur.OnEvery(rule.DayOfMonth.Value, rule.Month.Value) :

        //        (rule.TimeUnit.HasValue) ?
        //            Occur.OnEvery(rule.Ordinal, rule.TimeUnit.Value) :
        //        null;

        //    return rule.MapToNewRule(newRule);
        //}

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

            return rule.MapToNewRule(newRule);
        }
    }
}
