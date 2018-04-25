using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace UnitTests.ComplexRules
{
    [TestClass]
    public class Complex : RuleTestsBase
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
            Recurrence.AddRule(Occur.OnEvery(DayOfWeek.Tuesday).StartingOn(StartDate));
            Recurrence.AddRule(Occur.OnEvery(DayOfWeek.Thursday).StartingOn(StartDate));
            Recurrence.AddRule(Occur.NotOn(new DateTime(2018, 4, 12)));

            Act(new DateTime(2018, 4, 3))
                .ShouldBeTrue();

            Act(new DateTime(2018, 4, 5))
                .ShouldBeTrue();

            Act(new DateTime(2018, 4, 10))
                .ShouldBeTrue();

            Act(new DateTime(2018, 4, 12))
                .ShouldBeFalse();
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
    }
}
