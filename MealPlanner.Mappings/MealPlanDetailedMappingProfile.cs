using AutoMapper;
using Model = MealPlanner.Business.Domain;
using Entity = MealPlanner.Database.Entity;
using System;

namespace MealPlanner.Mappings
{
    public class MealPlanDetailedMappingProfile : Profile
    {
        public MealPlanDetailedMappingProfile()
        {
            CreateMap<Entity.MealPlan, Model.MealPlanDetailed>()
                .ForMember(d => d.OwnerId, opt => opt.MapFrom<UserToUniqueIdResolver>());

            CreateMap<Model.MealPlanDetailed, Entity.MealPlan>()
                .ForMember(d => d.OwnerId, opt => opt.Ignore())
                .ForMember(d => d.Owner, opt => opt.MapFrom<UniqueIdToUserResolver>());
        }

        public class UserToUniqueIdResolver : IValueResolver<Entity.MealPlan, Model.MealPlanDetailed, Guid>
        {
            public Guid Resolve(Entity.MealPlan source, Model.MealPlanDetailed destination, Guid destMember, ResolutionContext context)
            {
                return source.Owner.UniqueId;
            }
        }

        public class UniqueIdToUserResolver : IValueResolver<Model.MealPlanDetailed, Entity.MealPlan, Entity.User>
        {
            public Entity.User Resolve(Model.MealPlanDetailed source, Entity.MealPlan destination, Entity.User destMember, ResolutionContext context)
            {
                return new Entity.User()
                {
                    UniqueId = source.OwnerId
                };
            }
        }
    }
}
