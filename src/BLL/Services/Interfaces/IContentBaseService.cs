using BLL.Models;
using System.Collections.Generic;

namespace BLL.Services.Interfaces
{
    public interface IContentBaseService
    {
        ContentBaseModel GetContentItemById(int id);

        void Create(ContentBaseModel item);

        void CreateRange(IEnumerable<ContentBaseModel> collection);

        IEnumerable<ContentBaseModel> GetContentItemsList();

        void Update(ContentBaseModel item);

        void Remove(ContentBaseModel item);

        void Save();
    }
}
