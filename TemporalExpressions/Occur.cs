using System;
using System.Collections.Generic;
using TemporalExpressions.Rules;

namespace TemporalExpressions
{
    /// <summary>
    /// Factory for IRule objects.
    /// </summary>
    public static class Occur
    {
        /// <summary>
        /// Evaluates to true on given date.</summary>
        /// <param name="date"> The single date for the Reccurence to occur on </param>
        /// <returns>IRule evaluating true on the given date.</returns>
        public static IRule On(DateTime date) => 
            new OnDate(date);

        /// <summary>
        /// Evaluates to true on every instance of given DayOfWeek.</summary>
        /// <param name="dayOfWeek"> The day of the week for the Reccurence to occur on </param>
        /// <returns>IRule evaluating true on every instance of given DayOfWeek.</returns>
        public static IRule OnEvery(DayOfWeek dayOfWeek) => 
            OnEvery(1, dayOfWeek);

        /// <summary>
        /// Evaluates to true on the Nth instance of given DayOfWeek within a month. </summary>
        /// <param name="ordinal"> The ordinal value for the expression (eg. the Nth Tuesday where N is ordinal) </param>
        /// <param name="dayOfWeek"> The day of the week for the Reccurence to occur on </param>
        /// <returns>IRule evaluating true on the Nth instance of given DayOfWeek within a month.</returns>
        public static IRule OnThe(int ordinal, DayOfWeek dayOfWeek) => 
            new OnTheNthDayOfTheWeekInMonth(ordinal, dayOfWeek);

        /// <summary>
        /// Evaluates to true on every Nth instance of given DayOfWeek.</summary>
        /// <param name="ordinal"> The ordinal value for the expression (eg. the Nth Tuesday where N is ordinal) </param>
        /// <param name="dayOfWeek"> The day of the week for the Reccurence to occur on </param>
        /// <returns>IRule evaluating true on every Nth instance of given DayOfWeek.</returns>
        public static IRule OnEvery(int ordinal, DayOfWeek dayOfWeek) => 
            new EveryDayOfTheWeek(ordinal, dayOfWeek);

        /// <summary>
        /// Evaluates to true on every Nth day each month.</summary>
        /// <param name="dayOfMonth"> The day of the month for the Reccurence to occur on </param>
        /// <returns>IRule evaluating true on the Nth every month.</returns>
        public static IRule OnEvery(int dayOfMonth) => 
            new EveryDayOfTheMonth(dayOfMonth);

        /// <summary>
        /// Evaluates to true on every Nth day of the given month every year.</summary>
        /// <param name="dayOfMonth"> The day of the month (eg. the Nth day of the given month every year, where N is the day of the month). </param>
        /// <param name="month"> The month for the Reccurence to occur on. </param>
        /// <returns>IRule evaluating true on the Nth every month every X Years.</returns>
        public static IRule OnEvery(int dayOfMonth, Month month) =>
            new EveryDayOfTheYear(dayOfMonth, month);

        /// <summary>
        /// Evaluates to true on every given unit of time.</summary>
        /// <param name="unit"> The unit of time to reccur on. (eg. Days, Weeks, Months, Years) </param>
        /// <returns>IRule evaluating true on every given unit of time.</returns>
        public static IRule OnEvery(TimeUnit unit) => 
            OnEvery(1, unit);

        /// <summary>
        /// Evaluates to true on every Nth number of the given unit of time.</summary>
        /// <param name="ordinal"> The ordinal value for the expression (eg. the Nth number of the given unit, where N is ordinal). </param>
        /// <param name="unit"> The unit of time to reccur on. (eg. Days, Weeks, Months, Years) </param>
        /// <returns>IRule evaluating true on every Nth number of the given unit of time.</returns>
        public static IRule OnEvery(int ordinal, TimeUnit unit)
        {
            var dictionary = new Dictionary<TimeUnit, Func<IRule>>
            {
                {TimeUnit.Days, () => new EveryNthDay(ordinal) },
                {TimeUnit.Weeks, () => new OnTheNthDayOfTheWeekInMonth(ordinal) },
                {TimeUnit.Months, () => new EveryNthMonth(ordinal) },
                {TimeUnit.Years, () => new EveryNthYear(ordinal) }
            };

            if (dictionary.ContainsKey(unit)) return dictionary[unit].Invoke();

            throw new NotSupportedException($"Rules for 'Every {ordinal} {unit}' is not currently supported.");
        }

        /// <summary>
        /// Modifies a rule so that it flips the normal evaluation and, when evaluating false, supercedes any other rules that evaluate true</summary>
        /// <param name="rule"> The rule expression to be modified. </param>
        /// <returns>The IRule that was passed in after having been modified.</returns>
        public static IRule Not(IRule rule)
        {
            rule.OverrideIfEvaluationFails = true;
            rule.InvertEvaluation = true;

            return rule;
        }
    }
}
