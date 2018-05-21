using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemporalExpressions;

namespace ExpressionsTests.SimpleRules
{
    [TestClass]
    public class EveryNthMonth : RuleTestsBase
    {
        [TestMethod]
        public void ShouldOccur_EveryMonth()
        {
            Recurrence.AddRule(Occur.OnEvery(TimeUnit.Months).OnThe(1).StartingOn(StartDate));

            ShouldBeTrue(StartDate);
            ShouldBeTrue(StartDate.AddMonths(1));
            ShouldBeTrue(StartDate.AddMonths(2));
            ShouldBeTrue(StartDate.AddMonths(3));
            ShouldBeTrue(StartDate.AddMonths(4));
            ShouldBeTrue(StartDate.AddMonths(5));
            ShouldBeTrue(StartDate.AddMonths(6));
            ShouldBeTrue(StartDate.AddMonths(7));
            ShouldBeTrue(StartDate.AddMonths(8));
            ShouldBeTrue(StartDate.AddMonths(9));
            ShouldBeTrue(StartDate.AddMonths(10));
        }

        [TestMethod]
        public void ShouldOccur_EveryOtherMonth()
        {
            Recurrence.AddRule(Occur.OnEvery(2, TimeUnit.Months).OnThe(1).StartingOn(StartDate));

            ShouldBeTrue(StartDate);
            ShouldBeFalse(StartDate.AddMonths(1));
            ShouldBeTrue(StartDate.AddMonths(2));
            ShouldBeFalse(StartDate.AddMonths(3));
            ShouldBeTrue(StartDate.AddMonths(4));
            ShouldBeFalse(StartDate.AddMonths(5));
            ShouldBeTrue(StartDate.AddMonths(6));
            ShouldBeFalse(StartDate.AddMonths(7));
            ShouldBeTrue(StartDate.AddMonths(8));
            ShouldBeFalse(StartDate.AddMonths(9));
            ShouldBeTrue(StartDate.AddMonths(10));
        }

        [TestMethod]
        public void ShouldOccur_EveryThirdMonth()
        {
            Recurrence.AddRule(Occur.OnEvery(3, TimeUnit.Months).OnThe(1).StartingOn(StartDate));

            ShouldBeTrue(StartDate);
            ShouldBeFalse(StartDate.AddMonths(1));
            ShouldBeFalse(StartDate.AddMonths(2));
            ShouldBeTrue(StartDate.AddMonths(3));
            ShouldBeFalse(StartDate.AddMonths(4));
            ShouldBeFalse(StartDate.AddMonths(5));
            ShouldBeTrue(StartDate.AddMonths(6));
            ShouldBeFalse(StartDate.AddMonths(7));
            ShouldBeFalse(StartDate.AddMonths(8));
            ShouldBeTrue(StartDate.AddMonths(9));
            ShouldBeFalse(StartDate.AddMonths(10));
        }
    }
}
