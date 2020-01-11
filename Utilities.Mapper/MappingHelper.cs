using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;


namespace Utilities.Mapper
{
    public class MappingHelper : IMappingHelper
    {
        private IMapper _mapper;
        public MappingHelper(IMappingConfigurationProvider configProvider)
        {
            _mapper = configProvider.GetConfiguration().CreateMapper();
        }

        public TDest Map<TDest>(object source)
        {
            return _mapper.Map<TDest>(source);
        }
    }
}
