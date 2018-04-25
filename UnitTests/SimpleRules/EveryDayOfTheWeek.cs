using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;
using TemporalExpressions.Rules;

namespace UnitTests
{
    [TestClass]
    public class EveryDayOfTheWeek : RuleTestsBase
    {
        [TestMethod]
        public void ShouldOccur_EveryWednesday()
        {
            Recurrence.AddRule(Occur.OnEvery(DayOfWeek.Wednesday).StartingOn(StartDate));

            Act(new DateTime(2018, 4, 11))
                .ShouldBeTrue();

            Act(new DateTime(2018, 4, 18))
                .ShouldBeTrue();

            Act(new DateTime(2018, 4, 25))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldNotOccur_EveryOtherFriday()
        {
            Recurrence.AddRule(Occur.OnEvery(2, DayOfWeek.Friday).StartingOn(StartDate));

            Act(new DateTime(2018, 4, 6))
                .ShouldBeFalse();

            Act(new DateTime(2018, 4, 13))
                .ShouldBeTrue();

            Act(new DateTime(2018, 4, 20))
                .ShouldBeFalse();

            Act(new DateTime(2018, 4, 27))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldNotOccur_EveryThirdTuesday()
        {
            Recurrence.AddRule(Occur.OnEvery(3, DayOfWeek.Tuesday).StartingOn(StartDate));

            Act(new DateTime(2018, 4, 2))
                .ShouldBeFalse();

            Act(new DateTime(2018, 4, 10))
                .ShouldBeFalse();

            Act(new DateTime(2018, 4, 17))
                .ShouldBeTrue();
        }

    }
}
