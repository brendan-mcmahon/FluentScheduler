using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemporalExpressions;

namespace DeserializerTests
{
    [TestClass]
    public class Integration : RuleTestsBase
    {
        [TestMethod]
        public void CreatesFourRules()
        {
            Json = TestFiles.MainTest;
            Deserialize();

            Assert.IsTrue(Recurrence.Rules.Count == 4);

            ShouldEvaluateTrue(2018, 4, 28);
            ShouldEvaluateTrue(2018, 5, 8);
            ShouldEvaluateFalse(2018, 5, 13);
            ShouldEvaluateTrue(2018, 5, 15);
            ShouldEvaluateTrue(2018, 5, 22);
            ShouldEvaluateTrue(2018, 5, 15);
            ShouldEvaluateTrue(2018, 7, 15);
        }

        [TestMethod]
        public void CreatesEveryTuesday()
        {
            Json = TestFiles.EveryTuesday;
            Deserialize();

            ShouldEvaluateTrue(2018, 5, 8);
            ShouldEvaluateFalse(2018, 5, 11);
            ShouldEvaluateTrue(2018, 5, 15);
            ShouldEvaluateFalse(2018, 5, 16);
            ShouldEvaluateTrue(2018, 5, 22);
            ShouldEvaluateFalse(2018, 5, 31);
        }

        [TestMethod]
        public void CreatesEveryOtherMonthOnTheFifteenth()
        {
            Json = TestFiles.EveryOtherMonth15th;
            Deserialize();

            ShouldEvaluateFalse(2018, 5, 8);
            ShouldEvaluateTrue(2018, 5, 15);
            ShouldEvaluateFalse(2018, 6, 15);
            ShouldEvaluateTrue(2018, 7, 15);
        }

        [TestMethod]
        public void CreatesEveryThirdMonthOnTheSecondTuesday()
        {
            Json = TestFiles.Every3rdMonth2ndTuesday;
            Deserialize();

            ShouldEvaluateTrue(2018, 5, 8);
            ShouldEvaluateFalse(2018, 5, 15);
            ShouldEvaluateFalse(2018, 6, 11);
            ShouldEvaluateFalse(2018, 7, 10);
            ShouldEvaluateTrue(2018, 8, 14);
        }
    }
}
