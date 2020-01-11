using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Mapper;

namespace MealPlanner.Mappings
{
    public class MealPlannerDomainMapper
    {
        IMappingHelper _mapper;

        public MealPlannerDomainMapper(MealPlannerDomainMappingConfigurationProvider mappingConfig)
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
