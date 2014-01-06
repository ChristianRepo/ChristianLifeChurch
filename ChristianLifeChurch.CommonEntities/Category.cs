using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristianLifeChurch.CommonEntities
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

    }
}
