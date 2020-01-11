using MealPlanner.Web.Mappings;
using Utilities.Mapper;

namespace MealPlanner.Web.Mappings
{
    public class MealPlannerModelMapper
    {
        IMappingHelper _mapper;

        public MealPlannerModelMapper(IMappingConfigurationProvider mappingConfig)
        {
            _mapper = new MappingHelper(mappingConfig);
        }

        public TTarget Map<TTarget>(object mapFrom)
        {
            var mapTo = _mapper.Map<TTarget>(mapFrom);
            return mapTo;
        }
    }
}
