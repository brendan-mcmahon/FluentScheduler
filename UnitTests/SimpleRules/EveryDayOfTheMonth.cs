using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace UnitTests
{
    [TestClass]
    public class EveryDayOfTheMonth : RuleTestsBase
    {
        [TestMethod]
        public void ShouldOccur_Every16th()
        {
            Recurrence.AddRule(Occur.OnEvery(16).StartingOn(new DateTime(2018, 1, 1)));

            Act(new DateTime(2018, 4, 16))
                .ShouldBeTrue();

            Act(new DateTime(2018, 4, 26))
                .ShouldBeFalse();

            Act(new DateTime(2018, 8, 16))
                .ShouldBeTrue();

            Act(new DateTime(2018, 7, 28))
                .ShouldBeFalse();
        }

        [TestMethod]
        public void ShouldOccur_Every31stAndOverflow()
        {
            Recurrence.AddRule(Occur.OnEvery(31).StartingOn(new DateTime(2018, 1, 1)));

            Act(new DateTime(2018, 1, 31))
                .ShouldBeTrue();

            Act(new DateTime(2018, 3, 1))
                .ShouldBeTrue();

            Act(new DateTime(2018, 3, 31))
                .ShouldBeTrue();

            Act(new DateTime(2018, 5, 1))
                .ShouldBeTrue();

            Act(new DateTime(2018, 5, 31))
                .ShouldBeTrue();

            Act(new DateTime(2018, 7, 1))
                .ShouldBeTrue();

            Act(new DateTime(2018, 7, 31))
                .ShouldBeTrue();

            Act(new DateTime(2018, 8, 31))
                .ShouldBeTrue();

            Act(new DateTime(2018, 10, 1))
                .ShouldBeTrue();

            Act(new DateTime(2018, 10, 31))
                .ShouldBeTrue();

            Act(new DateTime(2018, 12, 1))
                .ShouldBeTrue();

            Act(new DateTime(2018, 12, 31))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldOccur_Every30thAndOverflow()
        {
            Recurrence.AddRule(Occur.OnEvery(30).StartingOn(new DateTime(2018, 1, 1)));

            Act(new DateTime(2018, 1, 30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 3, 1))
                .ShouldBeTrue();

            Act(new DateTime(2018, 3, 30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 4, 30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 5, 30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 6, 30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 7, 30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 8, 30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 9, 30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 10, 30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 12,30))
                .ShouldBeTrue();

            Act(new DateTime(2018, 12, 30))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldOccur_Every29thAndOverflow()
        {
            Recurrence.AddRule(Occur.OnEvery(29).StartingOn(new DateTime(2018, 1, 1)));

            Act(new DateTime(2018, 1, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 3, 1))
                .ShouldBeTrue();

            Act(new DateTime(2018, 3, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 4, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 5, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 6, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 7, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 8, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 9, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 10, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 12, 29))
                .ShouldBeTrue();

            Act(new DateTime(2018, 12, 29))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldOccur_Every29thOnLeapYear()
        {
            Recurrence.AddRule(Occur.OnEvery(29).StartingOn(new DateTime(2018, 1, 1)));

            Act(new DateTime(2020, 1, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 2, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 3, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 4, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 5, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 6, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 7, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 8, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 9, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 10, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 12, 29))
                .ShouldBeTrue();

            Act(new DateTime(2020, 12, 29))
                .ShouldBeTrue();
        }
    }
}
