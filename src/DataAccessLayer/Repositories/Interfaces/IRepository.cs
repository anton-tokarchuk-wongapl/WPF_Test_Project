using System;
using System.Collections.Generic;
using DTO.DTOs.ContentBaseDTOs;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository : IDisposable
    {
        ICollection<ContentBaseDTO> GetContentItemsList();

        ContentBaseDTO GetContentItemById(int id);

        void Update(ContentBaseDTO item);
    }
}
