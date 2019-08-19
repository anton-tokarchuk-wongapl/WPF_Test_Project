using BLL.Models;
using System.Collections.Generic;

namespace BLL.Services.Interfaces
{
    public interface IContentBaseService
    {
        void Create(ContentBaseModel item);

        void CreateRange(IEnumerable<ContentBaseModel> collection);

        ContentBaseModel GetContentItemById(int id);

        IEnumerable<ContentBaseModel> GetContentItemsList();

        void Update(ContentBaseModel item);

        void Remove(ContentBaseModel item);

        void Save();
    }
}
