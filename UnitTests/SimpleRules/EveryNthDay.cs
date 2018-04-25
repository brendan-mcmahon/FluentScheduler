using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemporalExpressions;

namespace UnitTests
{
    [TestClass]
    public class EveryNthDay : RuleTestsBase
    {
        [TestMethod]
        public void ShouldOccur_EveryDay()
        {
            Recurrence.AddRule(Occur.OnEvery(TimeUnit.Days).StartingOn(StartDate));

            Act(StartDate)
                .ShouldBeTrue();

            Act(StartDate.AddDays(1))
                .ShouldBeTrue();

            Act(StartDate.AddDays(2))
                .ShouldBeTrue();

            Act(StartDate.AddDays(3))
                .ShouldBeTrue();

            Act(StartDate.AddDays(4))
                .ShouldBeTrue();

            Act(StartDate.AddDays(5))
                .ShouldBeTrue();

            Act(StartDate.AddDays(6))
                .ShouldBeTrue();

            Act(StartDate.AddDays(7))
                .ShouldBeTrue();

            Act(StartDate.AddDays(8))
                .ShouldBeTrue();

            Act(StartDate.AddDays(9))
                .ShouldBeTrue();

            Act(StartDate.AddDays(10))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldOccur_EveryOtherDay()
        {
            Recurrence.AddRule(Occur.OnEvery(2, TimeUnit.Days).StartingOn(StartDate));

            Act(StartDate)
                .ShouldBeTrue();

            Act(StartDate.AddDays(1))
                .ShouldBeFalse();

            Act(StartDate.AddDays(2))
                .ShouldBeTrue();

            Act(StartDate.AddDays(3))
                .ShouldBeFalse();

            Act(StartDate.AddDays(4))
                .ShouldBeTrue();

            Act(StartDate.AddDays(5))
                .ShouldBeFalse();

            Act(StartDate.AddDays(6))
                .ShouldBeTrue();

            Act(StartDate.AddDays(7))
                .ShouldBeFalse();

            Act(StartDate.AddDays(8))
                .ShouldBeTrue();

            Act(StartDate.AddDays(9))
                .ShouldBeFalse();

            Act(StartDate.AddDays(10))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldOccur_EveryThirdDay()
        {
            Recurrence.AddRule(Occur.OnEvery(3, TimeUnit.Days).StartingOn(StartDate));

            Act(StartDate)
                .ShouldBeTrue();

            Act(StartDate.AddDays(1))
                .ShouldBeFalse();

            Act(StartDate.AddDays(2))
                .ShouldBeFalse();

            Act(StartDate.AddDays(3))
                .ShouldBeTrue();

            Act(StartDate.AddDays(4))
                .ShouldBeFalse();

            Act(StartDate.AddDays(5))
                .ShouldBeFalse();

            Act(StartDate.AddDays(6))
                .ShouldBeTrue();

            Act(StartDate.AddDays(7))
                .ShouldBeFalse();

            Act(StartDate.AddDays(8))
                .ShouldBeFalse();

            Act(StartDate.AddDays(9))
                .ShouldBeTrue();

            Act(StartDate.AddDays(10))
                .ShouldBeFalse();
        }
    }
}
