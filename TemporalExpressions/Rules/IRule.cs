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
        bool InvertEvaluation { get; set; }

        IRule StartingOn(DateTime date);
        IRule EndingOn(DateTime? date);

        IRule OnThe(int ordinal, DayOfWeek dayOfWeek);
        IRule OnThe(int dayOfMonth);
        IRule OnThe(int dayOfMonth, Month month);

        bool Evaluate(DateTime date);
        int Count(DateTime date1, DateTime date2);
    }
}