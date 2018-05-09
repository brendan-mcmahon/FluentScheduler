using Newtonsoft.Json;
using System.Collections.Generic;
using TemporalExpressions;

namespace TemporalDeserializer
{
    public static class RulesDeserializer
    {
        public static Recurrence Deserialize(string json)
        {
            var jObject = json.DeserializeObject();
            var rules = jObject.ToIRules();
            var recurrence = new Recurrence(rules);
            return recurrence;
            //new Recurrence(json.DeserializeObject().ToIRules());
        }

        internal static ICollection<RuleInfo> DeserializeObject(this string json)
        {
            var collection = JsonConvert.DeserializeObject<ICollection<RuleInfo>>(json);
            return collection;
        }
    }
}
