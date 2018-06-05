using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace ExpressionsTests.ScenarioTests
{
    [TestClass]
    public class ToString : RuleTestsBase
    {
        [TestMethod]
        public void Stringtest()
        {
            Recurrence.AddRule(Occur.On(new DateTime(2018, 12, 6)))
                .And(Occur.OnEvery(DayOfWeek.Sunday))
                .And(Occur.OnEvery(2, DayOfWeek.Wednesday))
                .And(Occur.OnEvery(13))
                .And(Occur.OnEvery(21, Month.October))
                .And(Occur.OnEvery(TimeUnit.Days))
                .And(Occur.OnEvery(TimeUnit.Weeks))
                .And(Occur.OnEvery(TimeUnit.Months).OnThe(3, DayOfWeek.Thursday))
                .And(Occur.OnEvery(TimeUnit.Months).OnThe(15))
                .And(Occur.OnEvery(TimeUnit.Years).OnThe(28, Month.May))
                .And(Occur.OnEvery(3, TimeUnit.Days))
                .And(Occur.OnEvery(3, TimeUnit.Weeks))
                .And(Occur.OnEvery(3, TimeUnit.Months).OnThe(3, DayOfWeek.Thursday))
                .And(Occur.OnEvery(3, TimeUnit.Months).OnThe(15))
                .And(Occur.OnEvery(3, TimeUnit.Years).OnThe(28, Month.May));

            Console.WriteLine(Recurrence);
        }
    }
}
