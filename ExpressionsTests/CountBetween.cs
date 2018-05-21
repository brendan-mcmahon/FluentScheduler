using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TemporalExpressions;

namespace ExpressionsTests
{
    [TestClass]
    public class CountBetween : RuleTestsBase
    {

        DateTime firstDate = new DateTime(2018, 5, 14);

        [TestMethod]
        public void OnEveryDayInMonth()
        {
            Recurrence.AddRule(Occur.OnEvery(15).StartingOn(StartDate).EndingOn(EndDate));

            ShouldBeTrue(2018, 6, 15);
            ShouldBeFalse(2018, 6, 14);
            Count(firstDate, new DateTime(2018, 6, 14)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 6, 15)).ShouldEqual(2);
            Count(firstDate, new DateTime(2018, 7, 18)).ShouldEqual(3);
            Count(firstDate, new DateTime(2018, 8, 18)).ShouldEqual(3);
        }


        [TestMethod]
        public void OnEveryDayOfTheWeek()
        {
            Recurrence.AddRule(Occur.OnEvery(DayOfWeek.Tuesday).StartingOn(StartDate));

            ShouldBeTrue(2018, 4, 10);
            ShouldBeFalse(2018, 4, 16);
            ShouldBeTrue(2018, 4, 17);

            Count(firstDate, new DateTime(2018, 5, 21)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 5, 28)).ShouldEqual(2);
            Count(firstDate, new DateTime(2018, 5, 29)).ShouldEqual(3);
        }

        [TestMethod]
        public void OnEveryDayOfTheYear()
        {
            Recurrence.AddRule(Occur.OnEvery(28, Month.May).StartingOn(StartDate));

            ShouldBeTrue(2018, 5, 28);
            ShouldBeFalse(2019, 4, 28);
            ShouldBeTrue(2019, 5, 28);

            Count(firstDate, new DateTime(2018, 5, 21)).ShouldEqual(0);
            Count(firstDate, new DateTime(2018, 5, 28)).ShouldEqual(1);
            Count(firstDate, new DateTime(2019, 5, 21)).ShouldEqual(1);
            Count(firstDate, new DateTime(2019, 5, 30)).ShouldEqual(2);
        }

        [TestMethod]
        public void OnEvery3Days()
        {
            Recurrence.AddRule(Occur.OnEvery(3, TimeUnit.Days).StartingOn(StartDate));

            ShouldBeTrue(2018, 5, 16);
            ShouldBeTrue(2018, 5, 19);
            ShouldBeTrue(2018, 5, 22);
            ShouldBeFalse(2018, 5, 23);
            ShouldBeTrue(2018, 6, 3);

            Count(firstDate, new DateTime(2018, 5, 14)).ShouldEqual(0);
            Count(firstDate, new DateTime(2018, 5, 16)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 5, 18)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 5, 23)).ShouldEqual(3);
            Count(firstDate, new DateTime(2018, 6, 3)).ShouldEqual(7);
            Count(firstDate, new DateTime(2018, 6, 4)).ShouldEqual(7);
            Count(firstDate, new DateTime(2018, 6, 5)).ShouldEqual(7);
            Count(firstDate, new DateTime(2018, 6, 6)).ShouldEqual(8);
            Count(firstDate, new DateTime(2018, 6, 7)).ShouldEqual(8);
            Count(firstDate, new DateTime(2018, 6, 8)).ShouldEqual(8);
        }

        [TestMethod]
        public void OnEvery8Days()
        {
            Recurrence.AddRule(Occur.OnEvery(8, TimeUnit.Days).StartingOn(StartDate));

            ShouldBeTrue(2018, 5, 19);
            ShouldBeTrue(2018, 5, 27);
            ShouldBeTrue(2018, 6, 4);
            ShouldBeFalse(2018, 6, 10);
            ShouldBeTrue(2018, 6, 12);

            Count(firstDate, new DateTime(2018, 5, 14)).ShouldEqual(0);
            Count(firstDate, new DateTime(2018, 5, 16)).ShouldEqual(0);
            Count(firstDate, new DateTime(2018, 5, 19)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 5, 20)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 5, 31)).ShouldEqual(2);
        }

        //[TestMethod]
        //public void OnEvery3Weeks()
        //{
        //    Recurrence.AddRule(Occur.OnEvery(3, TimeUnit.Weeks).StartingOn(StartDate));

        //    ShouldBeTrue(2018, 4, 1);
        //    ShouldBeFalse(2018, 4, 8);
        //    ShouldBeFalse(2018, 4, 15);
        //    ShouldBeTrue(2018, 4, 22);
        //    ShouldBeFalse(2018, 4, 25);
        //    ShouldBeTrue(2018, 5, 13);

        //    //Count(firstDate, new DateTime(2018, 5, 21)).ShouldEqual(1);
        //    //Count(firstDate, new DateTime(2018, 5, 28)).ShouldEqual(2);
        //    //Count(firstDate, new DateTime(2018, 5, 29)).ShouldEqual(3);
        //}

        [TestMethod]
        public void OnEvery3Months()
        {
            Recurrence.AddRule(Occur.OnEvery(3, TimeUnit.Months).OnThe(1).StartingOn(StartDate));

            ShouldBeTrue(2018, 4, 1);
            ShouldBeTrue(2018, 7, 1);
            ShouldBeTrue(2018, 10, 1);
            ShouldBeFalse(2018, 5, 1);
            ShouldBeFalse(2018, 5, 15);

            Count(firstDate, new DateTime(2018, 6, 14)).ShouldEqual(0);
            Count(firstDate, new DateTime(2018, 7, 14)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 7, 30)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 8, 14)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 9, 14)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 10, 1)).ShouldEqual(2);
            Count(firstDate, new DateTime(2018, 11, 14)).ShouldEqual(2);
        }

        [TestMethod]
        public void OnEvery8Months()
        {
            Recurrence.AddRule(Occur.OnEvery(8, TimeUnit.Months).OnThe(1).StartingOn(StartDate));

            ShouldBeTrue(2018, 4, 1);
            ShouldBeFalse(2018, 4, 15);
            ShouldBeTrue(2018, 12, 1);
            ShouldBeTrue(2019, 8, 1);
            ShouldBeTrue(2020, 4, 1);
            ShouldBeFalse(2018, 5, 1);

            Count(firstDate, new DateTime(2018, 5, 14)).ShouldEqual(0);
            Count(firstDate, new DateTime(2018, 5, 16)).ShouldEqual(0);
            Count(firstDate, new DateTime(2018, 5, 19)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 5, 20)).ShouldEqual(1);
            Count(firstDate, new DateTime(2018, 5, 31)).ShouldEqual(2);
        }

        [TestMethod]
        public void Thanksgiving()
        {
            Recurrence.AddRule(Occur
                .OnEvery(12, TimeUnit.Months)
                    .OnThe(3, DayOfWeek.Thursday)
                .StartingOn(new DateTime(2017, 11, 1)));

            ShouldBeTrue(2017, 11, 16);
            ShouldBeFalse(2017, 11, 23);
            ShouldBeTrue(2018, 11, 15);

            var months = Recurrence.CountBetween(new DateTime(2017, 10, 1), new DateTime(2017, 12, 1));
            var weeks = 1;
        }
    }
}
