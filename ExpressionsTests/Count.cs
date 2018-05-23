using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace ExpressionsTests
{
    [TestClass]
    public class Count : RuleTestsBase
    {
        [TestMethod]
        public void ShouldOccur3Times()
        {
            Recurrence.AddRule(Occur.OnEvery(31).StartingOn(new DateTime(2018, 1, 1)));
            var count = Recurrence.Count(new DateTime(2018, 1, 5), new DateTime(2018, 4, 1));
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void ShouldOccur4Times()
        {
            Recurrence.AddRule(Occur.OnEvery(31).StartingOn(new DateTime(2018, 1, 1)));
            var count = Recurrence.Count(new DateTime(2018, 1, 5), new DateTime(2018, 5, 1));
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void ShouldOccur12Times()
        {
            Recurrence.AddRule(Occur.OnEvery(31).StartingOn(new DateTime(2018, 1, 1)));
            var count = Recurrence.Count(new DateTime(2018, 1, 5), new DateTime(2019, 1, 5));
            Assert.AreEqual(count, 12);
        }

        [TestMethod]
        public void ShouldOccur1Times()
        {
            Recurrence.AddRule(Occur.OnEvery(31).StartingOn(new DateTime(2018, 1, 1)));
            var count = Recurrence.Count(new DateTime(2018, 1, 5), new DateTime(2018, 1, 31));
            Assert.AreEqual(count, 1);
        }

        [TestMethod]
        public void ShouldOccur2Times()
        {
            Recurrence.AddRule(Occur.OnEvery(31).StartingOn(new DateTime(2018, 1, 1)));
            var count = Recurrence.Count(new DateTime(2018, 12, 5), new DateTime(2019, 2, 28));
            Assert.AreEqual(count, 2);
        }

        [TestMethod]
        public void ShouldOccurXTimes()
        {
            Recurrence.AddRule(
                Occur.OnEvery(6, TimeUnit.Months)
                     .OnThe(2, DayOfWeek.Monday)
                     .StartingOn(new DateTime(2018, 1, 1)));

            var count = Recurrence.Count(new DateTime(2018, 1, 1), new DateTime(2018, 7, 28));
            Assert.AreEqual(2, count);

            count = Recurrence.Count(new DateTime(2018, 1, 1), new DateTime(2019, 1, 1));
            Assert.AreEqual(2, count);

            count = Recurrence.Count(new DateTime(2018, 1, 1), new DateTime(2020, 1, 1));
            Assert.AreEqual(4, count);
        }
    }
}
