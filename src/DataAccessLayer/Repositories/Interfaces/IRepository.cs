using System;
using System.Collections.Generic;
using DataAccessLayer.Entities.ContentEntities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRepository : IDisposable
    {
        ICollection<ContentBaseEntity> GetContentItemsList();

        ContentBaseEntity GetContentItemById(int id);

        void Update(ContentBaseEntity item);
    }
}
