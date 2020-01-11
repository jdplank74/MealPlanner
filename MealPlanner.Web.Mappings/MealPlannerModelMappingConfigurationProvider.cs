using AutoMapper;
using Utilities.Mapper;


namespace MealPlanner.Web.Mappings
{
    public class MealPlannerModelMappingConfigurationProvider : IMappingConfigurationProvider
    {
        public MapperConfiguration GetConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MealMappingProfile>();
                cfg.AddProfile<MealPlanLightMappingProfile>();
                cfg.AddProfile<MealPlanMappingProfile>();
                cfg.AddProfile<ScheduledMealMappingProfile>();
            });
            return config;
        }
    }
}
