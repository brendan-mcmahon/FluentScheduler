using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemporalExpressions;

namespace ExpressionsTests.SimpleRules
{
    [TestClass]
    public class EveryNthDay : RuleTestsBase
    {
        [TestMethod]
        public void ShouldOccur_EveryDay()
        {
            Recurrence.AddRule(Occur.OnEvery(TimeUnit.Days).StartingOn(StartDate));

            ShouldBeTrue(StartDate);
            ShouldBeTrue(StartDate.AddDays(1));
            ShouldBeTrue(StartDate.AddDays(2));
            ShouldBeTrue(StartDate.AddDays(3));
            ShouldBeTrue(StartDate.AddDays(4));
            ShouldBeTrue(StartDate.AddDays(5));
            ShouldBeTrue(StartDate.AddDays(6));
            ShouldBeTrue(StartDate.AddDays(7));
            ShouldBeTrue(StartDate.AddDays(8));
            ShouldBeTrue(StartDate.AddDays(9));
            ShouldBeTrue(StartDate.AddDays(10));
        }

        [TestMethod]
        public void ShouldOccur_EveryOtherDay()
        {
            Recurrence.AddRule(Occur.OnEvery(2, TimeUnit.Days).StartingOn(StartDate));

                ShouldBeTrue(StartDate);
                ShouldBeFalse(StartDate.AddDays(1));
                ShouldBeTrue(StartDate.AddDays(2));
                ShouldBeFalse(StartDate.AddDays(3));
                ShouldBeTrue(StartDate.AddDays(4));
                ShouldBeFalse(StartDate.AddDays(5));
                ShouldBeTrue(StartDate.AddDays(6));
                ShouldBeFalse(StartDate.AddDays(7));
                ShouldBeTrue(StartDate.AddDays(8));
                ShouldBeFalse(StartDate.AddDays(9));
                ShouldBeTrue(StartDate.AddDays(10));
        }

        [TestMethod]
        public void ShouldOccur_EveryThirdDay()
        {
            Recurrence.AddRule(Occur.OnEvery(3, TimeUnit.Days).StartingOn(StartDate));

            ShouldBeTrue(StartDate);
            ShouldBeFalse(StartDate.AddDays(1));
            ShouldBeFalse(StartDate.AddDays(2));
            ShouldBeTrue(StartDate.AddDays(3));
            ShouldBeFalse(StartDate.AddDays(4));
            ShouldBeFalse(StartDate.AddDays(5));
            ShouldBeTrue(StartDate.AddDays(6));
            ShouldBeFalse(StartDate.AddDays(7));
            ShouldBeFalse(StartDate.AddDays(8));
            ShouldBeTrue(StartDate.AddDays(9));
            ShouldBeFalse(StartDate.AddDays(10));
        }
    }
}
