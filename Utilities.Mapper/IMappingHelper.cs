using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Mapper
{
    public interface IMappingHelper
    {
        TDest Map<TDest>(object source);
    }
}
