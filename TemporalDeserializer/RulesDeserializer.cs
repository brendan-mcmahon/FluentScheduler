using Newtonsoft.Json;
using System.Collections.Generic;
using TemporalExpressions;

namespace TemporalDeserializer
{
    public static class RulesDeserializer
    {
        public static Recurrence Deserialize(string json) => 
            new Recurrence(json.DeserializeToRuleInfos().ToIRules());
        

        private static ICollection<RuleInfo> DeserializeToRuleInfos(this string json) =>
            JsonConvert.DeserializeObject<ICollection<RuleInfo>>(json);
    }
}
