using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemporalExpressions;

namespace UnitTests
{
    [TestClass]
    public class EveryNthMonth : RuleTestsBase
    {
        [TestMethod]
        public void ShouldOccur_EveryMonth()
        {
            Recurrence.AddRule(Occur.OnEvery(TimeUnit.Months).StartingOn(StartDate));

            Act(StartDate)
                .ShouldBeTrue();

            Act(StartDate.AddMonths(1))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(2))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(3))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(4))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(5))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(6))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(7))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(8))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(9))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(10))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldOccur_EveryOtherDay()
        {
            Recurrence.AddRule(Occur.OnEvery(2, TimeUnit.Months).StartingOn(StartDate));

            Act(StartDate)
                .ShouldBeTrue();

            Act(StartDate.AddMonths(1))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(2))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(3))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(4))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(5))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(6))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(7))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(8))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(9))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(10))
                .ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldOccur_EveryThirdDay()
        {
            Recurrence.AddRule(Occur.OnEvery(3, TimeUnit.Months).StartingOn(StartDate));

            Act(StartDate)
                .ShouldBeTrue();

            Act(StartDate.AddMonths(1))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(2))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(3))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(4))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(5))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(6))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(7))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(8))
                .ShouldBeFalse();

            Act(StartDate.AddMonths(9))
                .ShouldBeTrue();

            Act(StartDate.AddMonths(10))
                .ShouldBeFalse();
        }
    }
}
