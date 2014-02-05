using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristianLifeChurch.CommonEntities;
using Event = ChristianLifeChurch.Core.DbEntities.Event;

namespace ChristianLifeChurch.Core.Repository
{
    public interface IEventRepository: IRepository<Event>
    {
        
    }
    public class EventRepository : MongoRepository<Event>, IEventRepository
    {
    }
}
