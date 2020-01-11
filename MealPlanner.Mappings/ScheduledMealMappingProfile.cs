using AutoMapper;
using Model = MealPlanner.Business.Domain;
using Entity = MealPlanner.Database.Entity;

using System;


namespace MealPlanner.Mappings
{
    public class ScheduledMealMappingProfile : Profile
    {
        public ScheduledMealMappingProfile()
        {
            CreateMap<Entity.ScheduledMeal, Model.ScheduledMeal>();
            CreateMap<Model.ScheduledMeal, Entity.ScheduledMeal>();
        }

    }
}
