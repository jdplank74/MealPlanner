using System;
using AutoMapper;
using Model = MealPlanner.Business.Domain;
using Entity = MealPlanner.Database.Entity;
using MealPlanner.Utilities.Enums;

namespace MealPlanner.Mappings
{
    public class MealMappingProfile : Profile
    {
        public MealMappingProfile()
        {
            // Meal Entity to Meal Model
            CreateMap<Entity.Meal, Model.Meal>()
                .ForMember(d => d.MealType, opt => opt.MapFrom<MealTypeEntityToMealTypeEnumResolver>())
                .ForMember(d => d.OwnerId, opt => opt.MapFrom<UserEntityToGuidEnumResolver>());

            // Meal Model to Meal Entity
            CreateMap<Model.Meal, Entity.Meal>()
                .ForMember(d => d.OwnerId, opt => opt.Ignore())
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Owner, opt => opt.MapFrom<UniqueIdToUserEntityResolver>())
                .ForMember(d => d.MealType, opt => opt.MapFrom<MealTypeModelToMealTypeEntityResolver>());
        }
    }

    public class MealTypeEntityToMealTypeEnumResolver : IValueResolver<Entity.Meal, Model.Meal, Model.MealType>
    {
        public Model.MealType Resolve(Entity.Meal source, Model.Meal destination, Model.MealType destMember, ResolutionContext context)
        {
            return EnumUtils.ToEnum<Model.MealType>(source.MealType.Code);
        }
    }

    public class UserEntityToGuidEnumResolver : IValueResolver<Entity.Meal, Model.Meal, Guid>
    {
        public Guid Resolve(Entity.Meal source, Model.Meal destination, Guid uniqueId, ResolutionContext context)
        {
            return source.Owner != null ? source.Owner.UniqueId : Guid.Empty;
        }
    }

    public class UniqueIdToUserEntityResolver : IValueResolver<Model.Meal, Entity.Meal, Entity.User>
    {
        public Entity.User Resolve(Model.Meal source, Entity.Meal destination, Entity.User destMember, ResolutionContext context)
        {
            return new Entity.User()
            {
                UniqueId = source.OwnerId
            };
        }
    }

    public class MealTypeModelToMealTypeEntityResolver : IValueResolver<Model.Meal, Entity.Meal,Entity.MealType>
    {
        public Entity.MealType Resolve(Model.Meal source, Entity.Meal destination, Entity.MealType destMember, ResolutionContext context)
        {
            return new Entity.MealType()
            {
                Code = source.MealType.ToString()
            };
        }
    }


}
