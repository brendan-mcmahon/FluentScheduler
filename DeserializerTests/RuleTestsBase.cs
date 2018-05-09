using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TemporalDeserializer;
using TemporalExpressions;

namespace DeserializerTests
{
    [TestClass]
    public class RuleTestsBase
    {
        public Recurrence Recurrence;
        public string Json;

        public void Deserialize() =>
            Recurrence = RulesDeserializer.Deserialize(File.ReadAllText(Json));

        public void ShouldBeTrue(DateTime date)
        {
            Assert.IsTrue(Recurrence.Evaluate(date), $"{date} has evaluated false");
        }

        public void ShouldEvaluateTrue(int year, int month, int date)
        {
            ShouldBeTrue(new DateTime(year, month, date));
        }

        public void ShouldBeFalse(DateTime date)
        {
            Assert.IsFalse(Recurrence.Evaluate(date), $"{date} has evaluated true");
        }

        public void ShouldEvaluateFalse(int year, int month, int date)
        {
            ShouldBeFalse(new DateTime(year, month, date));
        }

    }
}
