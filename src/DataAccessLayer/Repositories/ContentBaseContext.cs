using System.Data.Entity;
using DAL.Entities.ContentEntities;

namespace DAL.Repositories
{
    public class ContentBaseContext : DbContext
    {
        public DbSet<ContentBaseEntity> Content { get; set; }

        public ContentBaseContext(string connection) : base(connection)
        {
        }
    }
}
