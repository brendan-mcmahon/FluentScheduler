using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace UnitTests
{
    [TestClass]
    public class EveryDayOfTheWeek : RuleTestsBase
    {
        [TestMethod]
        public void ShouldOccur_EveryWednesday()
        {
            Recurrence.AddRule(Occur.OnEvery(DayOfWeek.Wednesday).StartingOn(StartDate));

            ShouldBeTrue(2018, 4, 11);
            ShouldBeTrue(2018, 4, 18);
            ShouldBeTrue(2018, 4, 25);
        }

        [TestMethod]
        public void ShouldNotOccur_EveryOtherFriday()
        {
            Recurrence.AddRule(Occur.OnEvery(2, DayOfWeek.Friday).StartingOn(StartDate));

            ShouldBeFalse(2018, 4, 6);
            ShouldBeTrue(2018, 4, 13);
            ShouldBeFalse(2018, 4, 20);
            ShouldBeTrue(2018, 4, 27);
        }

        [TestMethod]
        public void ShouldNotOccur_EveryThirdTuesday()
        {
            Recurrence.AddRule(Occur.OnEvery(3, DayOfWeek.Tuesday).StartingOn(StartDate));

            ShouldBeFalse(2018, 4, 2);
            ShouldBeFalse(2018, 4, 10);
            ShouldBeTrue(2018, 4, 17);
        }

    }
}
