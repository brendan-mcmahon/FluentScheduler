using System;
using System.Collections.Generic;

namespace TemporalExpressions
{
    public class Recurrence
    {
        public IEnumerable<IRule> Rules { get; set; }

        public bool Evaluate(DateTime date)
        {
            foreach(var rule in Rules)
            {
                if (!rule.Evaluate(date))
                    return false;
            }

            return true;
        }
    }
}