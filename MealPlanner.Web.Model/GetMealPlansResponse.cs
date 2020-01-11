using MealPlanner.Web.Model;
using System;
using System.Collections.Generic;

namespace MealPlanner.Web.Model
{
    public class GetMealPlansResponse
    {
        public IList<MealPlanLight> MealPlans { get; set; }
    }
}
