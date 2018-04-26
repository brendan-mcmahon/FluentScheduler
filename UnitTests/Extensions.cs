using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemporalExpressions;
using TemporalExpressions.Rules;

namespace UnitTests
{
    public static class Extensions
    {
        public static void ShouldBeTrue(this bool boolean)
        {
            Assert.IsTrue(boolean);
        }

        public static void ShouldBeFalse(this bool boolean)
        {
            Assert.IsFalse(boolean);
        }
    }
}
