using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DAL.Repositories.Interfaces;
using DAL.Entities.ContentEntities;

namespace DAL.Repositories
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

        public void Create(ContentBaseEntity item)
        {
            db.Content.Add(item);
            db.SaveChanges();
        }

        public void CreateRange(IEnumerable<ContentBaseEntity> collection)
        {
            db.Content.AddRange(collection);
            db.SaveChanges();
        }

        public IEnumerable<ContentBaseEntity> GetContentItemsList()
            => db.Content
                 .Include(x => x.Children)
                 .ToList();

        public void Update(ContentBaseEntity item)
        {
            var content = db.Content.Find(item.Id);

            content.Name = item.Name;
            content.Description = item.Description;
            content.LastChangedDate = item.LastChangedDate;

            db.SaveChanges();
        }

        public void Save()
            => db.SaveChanges();

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

        public void Remove(ContentBaseEntity item)
            => db.Content.Remove(db.Content.Find(item.Id));
    }
}
