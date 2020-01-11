using System;
using System.Linq;

namespace MealPlanner.Utilities.Enums
{
    public static class EnumUtils
    {
        public static T ToEnum<T>(string nameStr)
        {
            string name = Enum.GetNames(typeof(T))
                .Where(n => n.Equals(nameStr, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();

            return (T)Enum.Parse(typeof(T), name);
    }
    }
}
