using BLC.Models.ContentModels;
using WPFProject.ViewModels;

namespace WPFProject.Helpers.Factories
{
    public class ContentBaseViewModelFactory
    {
        public ContentBaseViewModel GetViewModel(ContentBaseModel model)
        {
            if (model is ContentFileModel)
            {
                return new ContentFileViewModel(model);
            }
            else
            {
                return new ContentFolderViewModel(model);
            }
        }
    }
}
