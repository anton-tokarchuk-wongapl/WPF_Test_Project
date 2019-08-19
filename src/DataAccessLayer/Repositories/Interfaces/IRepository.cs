using DAL.Entities.ContentEntities;
using System;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository : IDisposable
    {
        void Create(ContentBaseEntity item);

        void CreateRange(IEnumerable<ContentBaseEntity> collection);

        IEnumerable<ContentBaseEntity> GetContentItemsList();

        ContentBaseEntity GetContentItemById(int id);

        void Update(ContentBaseEntity item);

        void Remove(ContentBaseEntity item);

        void Save();
    }
}
