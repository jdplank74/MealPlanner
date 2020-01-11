using AutoMapper;
using Domain = MealPlanner.Business.Domain;
using Model = MealPlanner.Web.Model;
using System;

namespace MealPlanner.Web.Mappings
{
    public class MealPlanMappingProfile : Profile
    {
        public MealPlanMappingProfile()
        {
            //  Map MealPlanDetailed Domain Model to MealPlan Model
            CreateMap<Domain.MealPlanDetailed, Model.MealPlan>();
            //  Map MealPlan Model to MealPlanDetailed Domain Model
            CreateMap<Model.MealPlan, Domain.MealPlanDetailed>();
                
        }
    }
}
