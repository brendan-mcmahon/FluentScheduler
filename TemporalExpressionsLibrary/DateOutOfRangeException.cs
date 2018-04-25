using System;
using System.Runtime.Serialization;

namespace TemporalExpressions
{
    [Serializable]
    internal class DateOutOfRangeException : Exception
    {
        private int dayOfTheMonth;
        private Month month;

        public DateOutOfRangeException(string message) : base(message)
        {
        }

        public DateOutOfRangeException(int dayOfTheMonth, Month month) : base($"There is no such day as {month} {dayOfTheMonth}")
        {
            this.dayOfTheMonth = dayOfTheMonth;
            this.month = month;
        }

        public DateOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DateOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}