using System.Collections.Generic;
using System.Linq;
using BusinessLogicContracts.Interfaces;
using BusinessLogicContracts.Models.ContentModels;
using WPFProject.ViewModels;

namespace WPFProject.Helpers.Factories
{
    public class ContentBaseViewModelFactory
    {
        public IEnumerable<ContentBaseViewModel> GetViewModels(IEnumerable<ContentBaseModel> models, ContentBaseViewModel parent = null)
            => models.Select(i => GetViewModel(i, parent));

        public IEnumerable<ContentFolderViewModel> GetFoldersViewModels(IEnumerable<ContentBaseModel> models, IContentBaseService contentBaseService, ContentBaseViewModel parent = null)
            => models.Select(i => new ContentFolderViewModel(i, parent, contentBaseService));

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
