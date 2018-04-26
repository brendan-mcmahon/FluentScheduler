using System.Collections.Generic;

namespace TemporalExpressions.Rules
{
    internal interface IHaveRules
    {
        ICollection<IRule> Rules { get; set; }
    }
}