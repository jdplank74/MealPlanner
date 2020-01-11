using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.Utilities.Date
{
    public class DateTimeAdapter : IDateTimeAdapter
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
