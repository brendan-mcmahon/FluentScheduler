using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpressionsTests
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
