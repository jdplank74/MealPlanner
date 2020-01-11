using System;

namespace MealPlanner.Utilities
{
    public interface IDateTimeAdapter
    {
        DateTime Now();
        DateTime UtcNow();
    }
}
