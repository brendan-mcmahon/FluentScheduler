using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace ExpressionsTests.ScenarioTests
{
    [TestClass]
    public class ScenarioTests : RuleTestsBase
    {
        [TestMethod]
        public void ShouldOccur_OntheSecondMondayEverySixMonths()
        {
            Recurrence.AddRule(
                Occur.OnEvery(6, TimeUnit.Months)
                     .OnThe(2, DayOfWeek.Monday)
                     .StartingOn(StartDate));

            ShouldBeFalse(2018, 10, 1);
            ShouldBeTrue(2018, 10, 8);
            ShouldBeFalse(2018, 10, 15);
            ShouldBeFalse(2018, 10, 22);
            ShouldBeFalse(2018, 10, 29);
            ShouldBeFalse(2018, 11, 8);
            ShouldBeTrue(2019, 4, 8);
        }

        [TestMethod]
        public void ShouldOccur_Onthe15thEveryTwoMonths()
        {
            Recurrence.AddRule(
                Occur.OnEvery(2, TimeUnit.Months)
                     .OnThe(15)
                     .StartingOn(StartDate));

            ShouldBeFalse(2018, 4, 1);
            ShouldBeTrue(2018, 4, 15);
            ShouldBeFalse(2018, 5, 15);
            ShouldBeFalse(2018, 5, 16);
            ShouldBeTrue(2018, 6, 15);
        }

        [TestMethod]
        public void ShouldOccur_EveryTuesdayAndThursday()
        {
            Recurrence.AddRule(
                Occur.OnEvery(DayOfWeek.Tuesday).StartingOn(StartDate))
                .And(Occur.OnEvery(DayOfWeek.Thursday).StartingOn(StartDate))
                .And(Occur.Not(Occur.On(new DateTime(2018, 4, 12)).StartingOn(StartDate)));

            ShouldBeTrue(2018, 4, 3);
            ShouldBeTrue(2018, 4, 5);
            ShouldBeTrue(2018, 4, 10);
            ShouldBeFalse(2018, 4, 12);
        }

        [TestMethod]
        public void ShouldOccur_EveryOtherWeekendAndEveryWednesdayNotChristmasButChristmasEve()
        {
            Recurrence
                .AddRule(Occur.OnEvery(2, DayOfWeek.Saturday).StartingOn(StartDate))
                .And(Occur.OnEvery(2, DayOfWeek.Sunday).StartingOn(StartDate))
                .And(Occur.OnEvery(DayOfWeek.Wednesday).StartingOn(StartDate))
                .And(Occur.OnEvery(1, TimeUnit.Years).OnThe(24, Month.December))
                .And(Occur.Not(Occur.OnEvery(1, TimeUnit.Years).OnThe(25, Month.December)));

            ShouldBeTrue(2018, 4, 4);
            ShouldBeFalse(2018, 4, 7);
            ShouldBeFalse(2018, 4, 8);
            ShouldBeTrue(2018, 4, 11);
            ShouldBeTrue(2018, 4, 14);
            ShouldBeTrue(2018, 4, 15);
            ShouldBeTrue(2018, 4, 18);
            ShouldBeTrue(2018, 12, 24);
            ShouldBeFalse(2018, 12, 25);
            ShouldBeTrue(2025, 12, 24);
            ShouldBeFalse(2025, 12, 25);
        }

        [TestMethod]
        public void ShouldNotOccur_BeforeOrAfterStartDate()
        {
            Recurrence.AddRule(
                Occur.OnEvery(DayOfWeek.Friday)
                     .StartingOn(StartDate)
                     .EndingOn(StartDate.AddMonths(3)));

            ShouldBeFalse(2018, 3, 30);
            ShouldBeTrue(2018, 4, 6);
            ShouldBeFalse(2018, 7, 6);
        }

        [TestMethod]
        public void ShouldNeverOccur()
        {
            Recurrence.AddRule(Occur.Not(Occur.OnEvery(DayOfWeek.Wednesday)).StartingOn(StartDate));

            ShouldBeFalse(2018, 4, 4);
            ShouldBeFalse(2018, 4, 5);
            ShouldBeFalse(2018, 4, 11);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Recurrence
                .AddRule(Occur.OnEvery(2, DayOfWeek.Saturday).StartingOn(StartDate))
                .And(Occur.OnEvery(2, DayOfWeek.Sunday).StartingOn(StartDate))
                .And(Occur.OnEvery(DayOfWeek.Wednesday).StartingOn(StartDate))
                .And(Occur.OnEvery(1, TimeUnit.Years).OnThe(24, Month.December))
                .And(Occur.Not(Occur.OnEvery(1, TimeUnit.Years).OnThe(25, Month.December)))
                .And(Occur.OnEvery(2, TimeUnit.Months).OnThe(3, DayOfWeek.Thursday))
                .And(Occur.On(new DateTime(2018, 5, 14)));

            Console.WriteLine(Recurrence);
        }
    }
}
