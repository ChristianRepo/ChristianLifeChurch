using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristianLifeChurch.CommonEntities;

namespace ChristianLifeChurch.Core.DataBaseContext
{
    public class ChurchContext : DbContext
    {
        public ChurchContext()
            : base("ChurchContext")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
