using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace ExpressionsTests
{
    [TestClass]
    public class RuleTestsBase
    {
        public Recurrence Recurrence;
        public DateTime StartDate = new DateTime(2018, 4, 1);
        public DateTime EndDate = new DateTime(2018, 8, 1);


        [TestInitialize]
        public void Arrange()
        {
            Recurrence = new Recurrence();
        }

        public void ShouldBeTrue(DateTime date)
        {
            Assert.IsTrue(Recurrence.Evaluate(date), $"{date} has evaluated false");
        }

        public void ShouldBeTrue(int year, int month, int date)
        {
            ShouldBeTrue(new DateTime(year, month, date));
        }

        public void ShouldBeFalse(DateTime date)
        {
            Assert.IsFalse(Recurrence.Evaluate(date), $"{date} has evaluated true");
        }

        public void ShouldBeFalse(int year, int month, int date)
        {
            ShouldBeFalse(new DateTime(year, month, date));
        }

        public int Count(DateTime dateTime1, DateTime dateTime2)
        {
            return Recurrence.CountBetween(dateTime1, dateTime2);
        }


    }
}
