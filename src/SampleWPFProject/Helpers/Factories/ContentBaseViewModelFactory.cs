using System.Collections.Generic;
using System.Linq;
using BusinessLogicContracts.Models.ContentModels;
using WPFProject.ViewModels;

namespace WPFProject.Helpers.Factories
{
    public class ContentBaseViewModelFactory
    {
        public IEnumerable<ContentBaseViewModel> GetViewModels(IEnumerable<ContentBaseModel> models, ContentBaseViewModel parent = null)
            => models.Select(i => GetViewModel(i, parent));

        private ContentBaseViewModel GetViewModel(ContentBaseModel model, ContentBaseViewModel parent)
        {
            if (model is ContentFileModel)
            {
                return new ContentFileViewModel(model, parent);
            }
            else
            {
                return new ContentFolderViewModel(model, parent);
            }
        }
    }
}
