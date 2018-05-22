using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TemporalExpressions;

namespace ExpressionsTests
{
    [TestClass]
    public class Count : RuleTestsBase
    {
        [TestMethod]
        public void Count1()
        {
            Recurrence.AddRule(Occur.OnEvery(2, TimeUnit.Months).OnThe(15).StartingOn(new DateTime(2018, 1, 1)));
            var count = Recurrence.CountBetween(new DateTime(2018, 2, 1), new DateTime(2018, 6, 1));

            count.ShouldEqual(2);
        }
    }
}
