using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionsTests
{
    public static class Extensions
    {
        public static void ShouldEvaluateTrue(this bool boolean)
        {
            Assert.IsTrue(boolean);
        }

        public static void ShouldEvaluateFalse(this bool boolean)
        {
            Assert.IsFalse(boolean);
        }

        public static void ShouldEqual(this int count, int expected)
        {
            Assert.AreEqual(expected, count);
        }
    }
}
