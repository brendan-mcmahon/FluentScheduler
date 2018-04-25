using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace UnitTests
{
    [TestClass]
    public class RuleTestsBase
    {
        public Recurrence Recurrence;
        public DateTime StartDate = new DateTime(2018, 4, 1);

        [TestInitialize]
        public void Arrange()
        {
            Recurrence = new Recurrence();
        }

        public bool Act(DateTime date)
        {
            return Recurrence.Evaluate(date);
        }
    }
}
