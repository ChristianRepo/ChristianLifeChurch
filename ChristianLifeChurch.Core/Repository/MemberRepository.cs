using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristianLifeChurch.Core.DbEntities;

namespace ChristianLifeChurch.Core.Repository
{
    public interface IMemberRepository:IRepository<Member>
    {
        
    }
    public class MemberRepository:MongoRepository<Member>, IMemberRepository
    {
    }
}
