using AutoMapper;
using Domain = MealPlanner.Business.Domain;
using Model = MealPlanner.Web.Model;
using System;

namespace MealPlanner.Web.Mappings
{
    public class MealPlanLightMappingProfile : Profile
    {
        public MealPlanLightMappingProfile()
        {
            // Map MealPlan Domain Model to MealPlan View Model
            CreateMap<Domain.MealPlan, Model.MealPlanLight>();
            // Map MealPlan View Model to MealPlan Domain Model
            CreateMap<Model.MealPlanLight, Domain.MealPlan>();
        }
    }
}
