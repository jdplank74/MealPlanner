using AutoMapper;
using Model = MealPlanner.Business.Domain;
using Entity = MealPlanner.Database.Entity;
using System;

namespace MealPlanner.Mappings
{
    public class MealPlanMappingProfile : Profile
    {
        public MealPlanMappingProfile()
        {
            CreateMap<Entity.MealPlan, Model.MealPlan>()
                .ForMember(d => d.OwnerId, opt => opt.MapFrom<UserToUniqueIdResolver>());

            CreateMap<Model.MealPlan, Entity.MealPlan>()
                .ForMember(d => d.OwnerId, opt => opt.Ignore())
                .ForMember(d => d.Owner, opt => opt.MapFrom<UniqueIdToUserResolver>())
                .ForMember(d => d.Meals, opt => opt.Ignore());
        }

        public class UserToUniqueIdResolver : IValueResolver<Entity.MealPlan, Model.MealPlan, Guid>
        {
            public Guid Resolve(Entity.MealPlan source, Model.MealPlan destination, Guid destMember, ResolutionContext context)
            {
                return source.Owner.UniqueId;
            }
        }

        public class UniqueIdToUserResolver : IValueResolver<Model.MealPlan, Entity.MealPlan, Entity.User>
        {
            public Entity.User Resolve(Model.MealPlan source, Entity.MealPlan destination, Entity.User destMember, ResolutionContext context)
            {
                return new Entity.User()
                {
                    UniqueId = source.OwnerId
                };
            }
        }
    }
}
