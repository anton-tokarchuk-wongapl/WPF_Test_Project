using System.Collections.Generic;
using BusinessLogicContracts.Models.ContentModels;
using ReactiveUI;
using WPFProject.Helpers.Factories;

namespace WPFProject.ViewModels
{
    public class ContentFolderViewModel : ContentBaseViewModel
    {
        private readonly ContentBaseViewModelFactory viewModelFactory;

        private string editableName;

        public ContentFolderViewModel(ContentBaseModel Model, ContentBaseViewModel parent) : base(Model, parent)
        {
            editableName = Name;
            viewModelFactory = new ContentBaseViewModelFactory();

            var list = viewModelFactory.GetViewModels(this.Model.Children, this);
            _children = new List<ContentBaseViewModel>(list);
        }

        public string EditableName
        {
            get => editableName;
            set => this.RaiseAndSetIfChanged(ref editableName, value);
        }
    }
}
