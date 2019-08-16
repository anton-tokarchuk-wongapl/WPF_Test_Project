using System.Collections.ObjectModel;
using DAL.Entities.Enums;

namespace BLL.Models
{
    public class ContentFolderModel : ContentBaseModel
    {
        public ContentFolderModel()
        {
            Children = new ObservableCollection<ContentBaseModel>();
            Type = ContentTypeEnum.Folder;
        }
    }
}
