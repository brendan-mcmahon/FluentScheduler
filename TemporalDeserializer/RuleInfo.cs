using System;
using System.Collections.Generic;
using TemporalExpressions;

namespace TemporalDeserializer
{
    internal class RuleInfo
    {
        internal RuleInfo()
        {
            Ordinal = 1;
            Rules = new List<RuleInfo>();
        }

        public ICollection<RuleInfo> Rules { get; set; }
        public RecurrenceType RecurrenceType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Ordinal { get; set; }
        public Month? Month { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public int? DayOfMonth { get; set; }
        public DateTime? Date { get; set; }
        public TimeUnit? TimeUnit { get; set; }
    }
}
