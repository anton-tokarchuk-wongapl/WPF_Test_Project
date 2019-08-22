using System.Data.Entity;
using DataAccessLayer.Entities.ContentEntities;

namespace DataAccessLayer.Repositories
{
    public class ContentBaseContext : DbContext
    {
        public DbSet<ContentBaseEntity> Content { get; set; }

        public ContentBaseContext(string connection) : base(connection)
        {
        }
    }
}
