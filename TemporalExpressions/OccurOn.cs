using System;

namespace TemporalExpressions
{
    public static class OccurOn
    {
        public static IRule Every(DayOfWeek dayOfWeek)
        {
            return Every(1, dayOfWeek);
        }

        public static IRule Every(int ordinal, DayOfWeek dayOfWeek)
        {
            return new EveryDayOfTheWeek(ordinal, dayOfWeek);
        }

        public static IRule Every(int dayOfMonth)
        {
            return Every(1, dayOfMonth);
        }

        public static IRule Every(int ordinal, int dayOfMonth)
        {
            return new EveryDayOfTheMonth(dayOfMonth);
        }

        public static IRule Every(TimeUnit unit)
        {
            return Every(1, unit);
        }

        public static IRule Every(int ordinal, TimeUnit unit)
        {
            return new EveryNthUnit(ordinal, unit);
        }
    }
}
