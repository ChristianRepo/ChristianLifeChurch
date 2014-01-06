using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristianLifeChurch.CommonEntities;

namespace ChristianLifeChurch.Core.Repository
{
    public interface IArticleRepository: IRepository<Article>
    {
        
    }
    public class ArticleRepository : GeneralRepository<Article>, IArticleRepository
    {
    }
}
