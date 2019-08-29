using System.Collections.Generic;
using BusinessLogicContracts.Models.ContentModels;
using WPFProject.Helpers.Factories;

namespace WPFProject.ViewModels
{
    public class ContentFolderViewModel : ContentBaseViewModel
    {
        private readonly ContentBaseViewModelFactory viewModelFactory;

        public ContentFolderViewModel(ContentBaseModel Model, ContentBaseViewModel parent) : base(Model, parent)
        {
            viewModelFactory = new ContentBaseViewModelFactory();

            var list = viewModelFactory.GetViewModels(this.Model.Children, this);
            _children = new List<ContentBaseViewModel>(list);
        }
    }
}
