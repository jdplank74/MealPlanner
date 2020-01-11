using AutoMapper;
using Domain = MealPlanner.Business.Domain;
using Model = MealPlanner.Web.Model;

using System;


namespace MealPlanner.Web.Mappings
{
    public class ScheduledMealMappingProfile : Profile
    {
        public ScheduledMealMappingProfile()
        {
            // Map Meal Domain Model to Meal View Model
            CreateMap<Domain.ScheduledMeal, Model.ScheduledMeal>();

            // Map Meal View Model to Meal Domain Model
            CreateMap<Model.ScheduledMeal, Domain.ScheduledMeal>()
                .ForMember(d => d.MealPlan, opt => opt.MapFrom<MealPlanFromIdResolver>());
        }
    }

    public class MealPlanFromIdResolver : IValueResolver<Model.ScheduledMeal, Domain.ScheduledMeal, Domain.MealPlan>
    {
        public Domain.MealPlan Resolve(Model.ScheduledMeal source, Domain.ScheduledMeal destination, Domain.MealPlan destMember, ResolutionContext context)
        {
            return new Domain.MealPlan()
            {
                Id = source.MealPlanId
            };
        }
    }
}
