using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristianLifeChurch.Core.Repository;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace ChristianLifeChurch.Core.StructureMap
{
    public class CoreRegistry:Registry
    {
        public CoreRegistry()
        {
            For<IEventRepository>().Use<EventRepository>();
        }
    }
}
