using System.Collections.Generic;
using BLC.Models.ContentModels;

namespace BLC.Interfaces
{
    public interface IContentBaseService
    {
        ContentBaseModel GetContentItemById(int id);

        ICollection<ContentBaseModel> GetFoldersTree();

        void Update(ContentBaseModel item);
    }
}
