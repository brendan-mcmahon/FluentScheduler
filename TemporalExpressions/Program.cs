using System;
using System.Collections.Generic;

namespace TemporalExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void Test()
        {
            var simpleRecurrence = new Recurrence
            {
                Rules = new List<IRule>
                {
                    OccurOn.Every(3, DayOfWeek.Tuesday).StartingOn(DateTime.Today.AddDays(1))
                }
            };

            var complexRecurrence = new Recurrence
            {
                Rules = new List<IRule>
                {
                    OccurOn.Every(6, TimeUnit.Months).OnThe(3, DayOfWeek.Thursday),
                    OccurOn.Every(2, DayOfWeek.Friday)
                }
            };
        }
    }
}