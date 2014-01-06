using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristianLifeChurch.CommonEntities
{
    public class Article
    {
        public long ArticleId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string VideoTag { get; set; }
        public string ImageTag { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Category Category { get; set; }
    }
}
