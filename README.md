# FluentScheduler
The goal of the FluentScheduler is to provide a fluent way to write out simple, complex, or compound scheduled events, which can then evaluate a date to determine if it falls into that schedule.

For example - say you and a friend pooled your tickets at Chuck E. Cheese to purchase a Tomagachi. Since your friend had more tickets than you, you get the short straw when it comes time to decide custody. The end result is:
Every other weekend and every Wednesday. You also get Christmas Eve, but not Christmas. This would be written with FluentScheduler like so:

```c#
  var TomagachiCustody = new Recurrence();
  TomagachiCustody.AddRule(
                  Occur.OnEvery(2, DayOfWeek.Saturday))
                  .And(Occur.OnEvery(2, DayOfWeek.Sunday))
                  .And(Occur.OnEvery(DayOfWeek.Wednesday))
                  .And(Occur.OnEvery(1, TimeUnit.Years).OnThe(24, Month.December))
                  .And(Occur.Not(Occur.OnEvery(1, TimeUnit.Years).OnThe(25, Month.December)));
```

Then, when you need to check whether you have custody on any given date, pass it into the Recurrences Evaluate method:

```c#
  TomagachiCustody.Evaluate(new DateTime(2018, 4, 25)); // Returns true since it is a Wednesday
  
  TomagachiCustody.Evaluate(new DateTime(2018, 12, 25)); // Returns false since it is Christmas
```
  

###### Note that the granularity of the scheduled events right now is at a minimum 'Day.' This will likely change in the future, but for my purposes right now, this is the smallest I need.

## Creating a Rule
The entry point for this library is on the Recurrence. Once you have a Recurrence, you can start adding rules to it using the 'Occur' static class.  Browsing the class should give you an idea about what's available, but for quick reference, here are the different rules that can be generated:

###### More rule types will be added as it becomes apparent they are useful or needed. These are also very much open to extension if you have other ideas for implementation.

### Occur.On(date)
Returns a rule that will evaluate true only on the provided date.

Ex: On April 25, 2018

### Occur.OnEvery(dayOfWeek)
Returns a rule that will evaluate true on every instance of the given day of week

Ex: Every Sunday

### Occur.OnEvery(int (n), dayOfWeek)
Returns a rule that will evaluate true every nth instance of the given day of week, regardless of where it falls in the month/year.

Ex: Every 2nd Sunday

Ex: Every 3 weeks on Wednesday

### Occur.OnEvery(int (dayOfMonth))
Returns a rule that will evaluate true on the same date each month.

Ex: The 15th of each month

*Note: Right now the default behavior for months with fewer days is to overflow to the first of the following month

Ex: The 31st of every month will evaluate true on May 1st rather than April 31st.

Ex: The 29th of every month will evaluate true on March 1st rather than February 29th, unless it is a leap year.

### Occur.OnEvery(int (n), int (dayOfMonth))
Returns a rule that will evaluate true on the same date every n months.

Ex: Every other month on the 15th.

Ex: Every 6 Months on the 30th.

### Occur.OnEvery(int (dayOfMonth), Month)
Returns a rule that will evaluate true every year on the same date. Month is a public enum containing the names of all the months.

Ex: Every December 25th

### Occur.OnEvery(int (n), TimeUnit)
Returns a rule that will evaluate true every n units. TimeUnit is a public enum containing the following units:
* Days
* Weeks
* Months
* Years

Ex: Every 4 days

Ex: Every 2 Weeks (Note that this is the same functionality as OnEvery(dayOfWeek) without the ability to specify which dayOfWeek

### Occur.OnThe(int (n), dayOfWeek)
Returns a rule that will evaluate true on the nth instance of the given day of week *within* a month.

Ex: On the 1st Thursday of every month

### Occur.Not(IRule)
This returns whatever rule you pass in, after modifying it to reverse its evaluation and cancel out any other positive rule evaluations given this evaluates false.

Ex: Every Wednesday, but not April 25th. This will supercede the 'every Wednesday' rule and evaluate false on that date.
