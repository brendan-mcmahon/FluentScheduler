using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace UnitTests.ScenarioTests
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

            Act(new DateTime(2018, 10, 1))
                .ShouldBeFalse();

            Act(new DateTime(2018, 10, 8))
                .ShouldBeTrue();

            Act(new DateTime(2018, 10, 15))
                .ShouldBeFalse();

            Act(new DateTime(2018, 10, 22))
                .ShouldBeFalse();

            Act(new DateTime(2018, 10, 29))
                .ShouldBeFalse();

            Act(new DateTime(2018, 11, 8))
                .ShouldBeFalse();

            Act(new DateTime(2019, 4, 8))
                .ShouldBeTrue();
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

            Act(new DateTime(2018, 3, 30))
                .ShouldBeFalse();

            Act(new DateTime(2018, 4, 6))
                .ShouldBeTrue();

            Act(new DateTime(2018, 7, 6))
                .ShouldBeFalse();
        }

        [TestMethod]
        public void ShouldNeverOccur()
        {
            Recurrence.AddRule(Occur.Not(Occur.OnEvery(DayOfWeek.Wednesday)).StartingOn(StartDate));

            ShouldBeFalse(2018, 4, 4);
            ShouldBeFalse(2018, 4, 5);
            ShouldBeFalse(2018, 4, 11);
        }
    }
}
