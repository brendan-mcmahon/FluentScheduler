﻿using System;
using System.Collections.Generic;
using System.Linq;
using TemporalDeserializer;

namespace TemporalExpressions.Rules
{

    public abstract class RuleBase : IRule
    {
        #region Properties
        /// <summary> Rules that are evaluated before this rule. </summary>
        public ICollection<IRule> Rules { get; set; }
        /// <summary> The Ordinal which can be applied as the Nth of any given rule. </summary>
        public int Ordinal { get; set; }
        /// <summary> Evaluation will yield false if the date is before the StartDate. Defaults to DateTime.Today </summary>
        public DateTime StartDate { get; set; }
        /// <summary> Evaluation will yield false if the date is after the EndDate. Defaults to null </summary>
        public DateTime? EndDate { get; set; }
        /// <summary> When set to true, this rule will be evaluated before rules set to false. If the evaluation fails, the evaluation short-circuits and returns false.</summary>
        public bool OverrideIfEvaluationFails { get; set; }
        /// <summary> When set to true, this rule's evaluation result will be inverted. (ie. if the date evaluates true, the result will be false, and vice versa) </summary>
        public bool InvertEvaluation { get; set; }

        #endregion

        #region Constructors
        protected RuleBase() : this(DateTime.Today) { }

        protected RuleBase(DateTime startDate)
        {
            StartDate = startDate;
            Rules = new List<IRule>();
        }

        #endregion

        #region Modifiers

        /// <summary> Sets the StartDate on this rule, as well as any subrules. </summary>
        /// <param name="date">The date to set the StartDate to. </param>
        /// <returns> This IRule </returns>
        public IRule StartingOn(DateTime date)
        {
            StartDate = date;
            Rules.ForEach(r => r.StartingOn(date));
            return this;
        }

        /// <summary> Sets the EndDate on this rule, as well as any subrules. </summary>
        /// <param name="date">The date to set the EndDate to. </param>
        /// <returns> This IRule </returns>
        public IRule EndingOn(DateTime? date)
        {
            EndDate = date;
            Rules.ForEach(r => r.EndingOn(date));
            return this;
        }

        /// <summary> Adds a sub-rule to this rule which will evaluate to true on the Nth instance of given DayOfWeek within a month. </summary>
        /// <summary> (Passes through to Occur.OnThe(ordinal, dayOfWeek)</summary>
        /// <param name="ordinal"> The ordinal value for the expression (eg. the Nth Tuesday where N is ordinal) </param>
        /// <param name="dayOfWeek"> The day of the week for the Reccurence to occur on </param>
        /// <returns> This IRule </returns>
        public IRule OnThe(int ordinal, DayOfWeek dayOfWeek)
        {
            AddRule(Occur.OnThe(ordinal, dayOfWeek));
            return this;
        }

        /// <summary> Adds a sub-rule to this rule which evaluates to true on the Nth of a month. </summary>
        /// <summary> (Passes through to Occur.OnEvery(dayOfMonth)</summary>
        /// <param name="dayOfMonth"> The day of the month for the Reccurence to occur on </param>
        /// <returns> This IRule </returns>
        public IRule OnThe(int dayOfMonth)
        {
            AddRule(Occur.OnEvery(dayOfMonth));
            return this;
        }

        /// <summary> Adds a sub-rule to this rule which evaluates to true on every Nth day of the given month every year. </summary>
        /// <summary> (Passes through to Occur.OnEvery(dayOfMonth, month)</summary>
        /// <param name="dayOfMonth"> The day of the month for the Reccurence to occur on </param>
        /// <param name="month"> The month for the Reccurence to occur on </param>
        /// <returns> This IRule </returns>
        public IRule OnThe(int dayOfMonth, Month month)
        {
            AddRule(Occur.OnEvery(dayOfMonth, month));
            return this;
        }

        /// <summary>
        /// Adds a sub-rule to the Rule. </summary>
        /// <param name="rule"> The rule to be added to the rules collection. </param>
        /// <returns>This Rule with the new sub-rule. </returns>
        public void AddRule(IRule rule) =>
            Rules.Add(rule);
        #endregion

        #region Evaluation

        /// <summary> Evaluates whether a given date occurs according to the collection of rules, the range, and whether or not the evaluation is inverted or not. </summary>
        /// <param name="date"> The date to evaluate. </param>
        /// <returns> True if the date occurs according to the rules, otherwise false. </returns>
        public bool Evaluate(DateTime date) =>
            InvertEvaluation ? !FullEvaluation(date) : FullEvaluation(date);

        internal abstract bool InnerEvaluation(DateTime date);

        private bool EvaluateChain(DateTime date) =>
            Rules.All(r => r.Evaluate(date));

        private bool IsWithinRange(DateTime date)
        {
            if (EndDate.HasValue)
                return date >= StartDate && date <= EndDate.Value;

            return date >= StartDate;
        }

        private bool FullEvaluation(DateTime date) =>
            (EvaluateChain(date) && IsWithinRange(date)) && InnerEvaluation(date);

        #endregion

        #region Count

        public int TotalCountBetween(DateTime firstDate, DateTime endDate)
        {
            var totalCount = CountBetween(firstDate, endDate) - CountOutOfRange(firstDate, endDate);

            return totalCount;
        }

        private int CountOutOfRange(DateTime firstDate, DateTime endDate)
        {
            var count = 0;
            if (firstDate < StartDate) count += CountBetween(firstDate, StartDate);
            if (EndDate.HasValue && endDate > EndDate.Value) count += CountBetween(EndDate.Value, endDate);
            return count;
        }

        internal abstract int CountBetween(DateTime firstDate, DateTime endDate);

        internal int CountBetween(DateTime endDate) =>
            CountBetween(DateTime.Today, endDate);

        #endregion

        #region NewCount

        public IEnumerable<DateTime> CountAll(DateTime date1, DateTime date2)
        {
            var lists = new List<List<DateTime>>();
            Rules.ForEach(r => lists.Add(r.CountAll(date1, date2).ToList()));

            lists.Add(InnerCount(date1, date2));

            return lists
                .SelectMany(l => l)         //flattens list
                .GroupBy(g => g)            //groups by date
                //.Where(g => g.Count() > 1)  //cuts down to only duplicated dates
                .Where(g => InnerEvaluation(g.Key))
                .Select(d => d.Key);        //selects one instance of each date
        }

        internal abstract bool CountEvaluator(DateTime key);
        public abstract List<DateTime> InnerCount(DateTime date1, DateTime date2);

        #endregion
    }
}