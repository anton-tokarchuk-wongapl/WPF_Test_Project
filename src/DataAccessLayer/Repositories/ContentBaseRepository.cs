using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Entities.ContentEntities;

namespace DataAccessLayer.Repositories
{
    public class ContentBaseRepository : IRepository
    {
        private readonly ContentBaseContext db;

        private bool disposed = false;

        public ContentBaseRepository(string connection)
        {
            db = new ContentBaseContext(connection);
            db.Configuration.LazyLoadingEnabled = false;
        }

        public ContentBaseEntity GetContentItemById(int id)
            => db.Content.Find(id);

        public ICollection<ContentBaseEntity> GetContentItemsList()
            => db.Content
                 .Include(x => x.Children)
                 .ToArray();

        public void Update(ContentBaseEntity item)
        {
            var editableContent = db.Content.Find(item.Id);

            editableContent.Name = item.Name;
            editableContent.Description = item.Description;
            editableContent.LastChangedDate = item.LastChangedDate;

            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
