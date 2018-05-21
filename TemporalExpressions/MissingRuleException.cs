using System;
using System.Runtime.Serialization;

namespace TemporalExpressions
{
    [Serializable]
    internal class MissingRuleException : Exception
    {
        public MissingRuleException()
        {
        }

        public MissingRuleException(string message) : base(message)
        {
        }

        public MissingRuleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingRuleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}