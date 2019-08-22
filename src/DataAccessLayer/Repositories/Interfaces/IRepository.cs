using System;
using System.Collections.Generic;
using DAL.Entities.ContentEntities;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository : IDisposable
    {
        ICollection<ContentBaseEntity> GetContentItemsList();

        ContentBaseEntity GetContentItemById(int id);

        void Update(ContentBaseEntity item);
    }
}
