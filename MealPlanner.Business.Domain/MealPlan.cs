﻿using System;
using System.Collections.Generic;

namespace MealPlanner.Business.Domain
{
    public class MealPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
