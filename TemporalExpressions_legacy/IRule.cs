using System;
using System.Collections.Generic;

namespace TemporalExpressions
{
    public interface IRule
    {
        ICollection<IRule> Rules { get; set; }
        int Ordinal { get; set; }
        DateTime StartDate { get; set; }
        DateTime? EndDate { get; set; }

        IRule StartingOn(DateTime date);
        IRule EndingOn(DateTime date);

        IRule OnThe(DayOfWeek dayOfWeek);
        IRule OnThe(int ordinal, DayOfWeek dayOfWeek);
        IRule OnThe(int dayOfMonth);

        bool Evaluate(DateTime date);
    }

    public abstract class RuleBase : IRule
    {
        public ICollection<IRule> Rules { get; set; }
        public int Ordinal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public RuleBase() : this(DateTime.Today) { }

        public RuleBase(DateTime startDate)
        {
            StartDate = startDate;
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
            Rules.Add(OccurOn.Every(dayOfWeek));
            return this;
        }

        public IRule OnThe(int ordinal, DayOfWeek dayOfWeek)
        {
            Rules.Add(OccurOn.Every(ordinal, dayOfWeek));
            return this;
        }

        public IRule OnThe(int dayOfMonth)
        {
            Rules.Add(OccurOn.Every(dayOfMonth));
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

        public abstract bool Evaluate(DateTime date);
    }

    public class EveryDayOfTheWeek: RuleBase
    {
        public DayOfWeek DayOfWeek { get; set; }

        public EveryDayOfTheWeek(DayOfWeek dayOfTheWeek) : this(1, dayOfTheWeek) { }

        public EveryDayOfTheWeek(int ordinal, DayOfWeek dayOfTheWeek)
        {
            Ordinal = ordinal;
            DayOfWeek = dayOfTheWeek;
        }

        public override bool Evaluate(DateTime date)
        {
            EvaluateChain(date);

            if (date.DayOfWeek != DayOfWeek) return false;

            return true;
        }
    }

    public class EveryDayOfTheMonth : RuleBase
    {
        public int Day { get; set; }

        public EveryDayOfTheMonth(int dayOfTheMonth) : this(1, dayOfTheMonth) { }

        public EveryDayOfTheMonth(int ordinal, int dayOfTheMonth)
        {
            Ordinal = ordinal;
            Day = dayOfTheMonth;
            //Validate();
        }

        public override bool Evaluate(DateTime date)
        {
            EvaluateChain(date);

            if (date.Day != Day) return false;

            return true;
        }

        //private void Validate()
        //{
        //    switch (Month)
        //    {
        //        case Month.February:
        //            if (DayOfTheMonth > 29)
        //                throw new DateOutOfRangeException(DayOfTheMonth, Month);
        //            break;

        //        case Month.April:
        //        case Month.June:
        //        case Month.September:
        //        case Month.November:
        //            if (DayOfTheMonth > 30)
        //                throw new DateOutOfRangeException(DayOfTheMonth, Month);
        //            break;

        //        default:
        //            if (DayOfTheMonth > 31)
        //                throw new DateOutOfRangeException(DayOfTheMonth, Month);
        //            break;

        //    }
        //}
    }

    public class EveryNthDay : RuleBase
    {
        public override bool Evaluate(DateTime date)
        {
            EvaluateChain(date);

            var days = (EndDate - StartDate).Value.Days;
            return (days % Ordinal == 0);
        }
    }

    public class EveryNthMonth : RuleBase
    {
        public override bool Evaluate(DateTime date)
        {
            EvaluateChain(date);

            var days = GetMonthsBetweenDates(date);

            return (days % Ordinal == 0);
        }

        private int GetMonthsBetweenDates(DateTime date)
        {
            var endMonths = (date.Month + (date.Year * 12));
            var startMonths = (StartDate.Month + (StartDate.Year * 12));

            return (startMonths - endMonths);
        }
    }

    /*Other class ideas:
     * The Last X of Y
     * 
     */
}