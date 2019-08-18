using System.Collections.ObjectModel;

namespace BLL.Models
{
    public class ContentFolderModel : ContentBaseModel
    {
        public ContentFolderModel()
        {
            Children = new ObservableCollection<ContentBaseModel>();
        }
    }
}
