﻿using System;
using System.Collections.Generic;

namespace TemporalExpressions.Rules
{
    public abstract class RuleBase : IRule
    {
        public ICollection<IRule> Rules { get; set; }
        public int Ordinal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool OverrideIfEvaluationFails { get; set; }

        public RuleBase() : this(DateTime.Today) { }

        public RuleBase(DateTime startDate)
        {
            StartDate = startDate;
            Rules = new List<IRule>();
        }

        public IRule StartingOn(DateTime date)
        {
            StartDate = date;
            return this;
        }

        public IRule EndingOn(DateTime date)
        {
            EndDate = date;
            return this;
        }

        public IRule OnThe(DayOfWeek dayOfWeek)
        {
            Rules.Add(Occur.OnEvery(dayOfWeek));
            return this;
        }

        public IRule OnThe(int ordinal, DayOfWeek dayOfWeek)
        {
            Rules.Add(Occur.OnThe(ordinal, dayOfWeek));
            return this;
        }

        public IRule OnThe(int dayOfMonth)
        {
            Rules.Add(Occur.OnEvery(dayOfMonth));
            return this;
        }

        public bool EvaluateChain(DateTime date)
        {
            foreach (var rule in Rules)
            {
                if (!rule.Evaluate(date)) return false;
            }

            return true;
        }

        public bool IsWithinRange(DateTime date)
        {
            if (EndDate.HasValue)
                return date >= StartDate && date <= EndDate.Value;

            return date >= StartDate;
        }

        public abstract bool Evaluate(DateTime date);
    }

    /*Other class ideas:
     * The Last X of Y
     * 
     */
}