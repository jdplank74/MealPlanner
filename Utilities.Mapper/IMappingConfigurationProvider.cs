using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Mapper
{
    public interface IMappingConfigurationProvider
    {
        MapperConfiguration GetConfiguration();
    }
}
