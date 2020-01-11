using AutoMapper;
using Utilities.Mapper;


namespace MealPlanner.Mappings
{
    public class MealPlannerDomainMappingConfigurationProvider : IMappingConfigurationProvider
    {
        public MapperConfiguration GetConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MealMappingProfile>();
                cfg.AddProfile<MealPlanMappingProfile>();
                cfg.AddProfile<MealPlanDetailedMappingProfile>();
                cfg.AddProfile<ScheduledMealMappingProfile>();
            });
            return config;
        }
    }
}
