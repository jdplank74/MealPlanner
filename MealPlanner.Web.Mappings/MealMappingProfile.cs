using System;
using AutoMapper;
using Domain = MealPlanner.Business.Domain;
using Model = MealPlanner.Web.Model;
using MealPlanner.Utilities.Enums;

namespace MealPlanner.Web.Mappings
{
    public class MealMappingProfile : Profile
    {
        public MealMappingProfile()
        {
            // Meal Domain Model to Meal View Model
            CreateMap<Domain.Meal, Model.Meal>()
                .ForMember(d => d.MealType, opt => opt.MapFrom(s => s.MealType.ToString()));

            // Meal Model to Meal Entity
            CreateMap<Model.Meal, Domain.Meal>()
                .ForMember(d => d.MealType, opt => opt.MapFrom(s => s.MealType));
        }
    }

    public class MealTypeStringToMealTypeEnumValueResolver : IValueResolver<Model.Meal, Domain.Meal, Domain.MealType>
    {
        public Domain.MealType Resolve(Model.Meal source, Domain.Meal destination, Domain.MealType destMember, ResolutionContext context)
        {
            return EnumUtils.ToEnum<Domain.MealType>(source.MealType);
        }
    }

}
