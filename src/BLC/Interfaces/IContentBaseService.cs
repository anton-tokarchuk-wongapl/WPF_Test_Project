using System.Collections.Generic;
using BusinessLogicContracts.Models.ContentModels;

namespace BusinessLogicContracts.Interfaces
{
    public interface IContentBaseService
    {
        ContentBaseModel GetContentItemById(int id);

        ICollection<ContentBaseModel> GetFoldersTree();

        void Update(ContentBaseModel item);
    }
}
