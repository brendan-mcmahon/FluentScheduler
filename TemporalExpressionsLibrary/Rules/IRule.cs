using System;
using System.Collections.Generic;

namespace TemporalExpressions.Rules
{
    public interface IRule
    {
        ICollection<IRule> Rules { get; set; }
        int Ordinal { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }
        bool OverrideIfEvaluationFails { get; set; }

        IRule StartingOn(DateTime date);
        IRule EndingOn(DateTime date);

        IRule OnThe(DayOfWeek dayOfWeek);
        IRule OnThe(int ordinal, DayOfWeek dayOfWeek);
        IRule OnThe(int dayOfMonth);

        bool Evaluate(DateTime date);
    }

    /*Other class ideas:
     * The Last X of Y
     * 
     */
}