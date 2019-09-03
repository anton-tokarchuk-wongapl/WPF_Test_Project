using System.Collections.Generic;
using BusinessLogicContracts.Models.ContentModels;
using ReactiveUI;
using WPFProject.Helpers.Factories;

namespace WPFProject.ViewModels
{
    public class ContentFolderViewModel : ContentBaseViewModel
    {
        private readonly ContentBaseViewModelFactory viewModelFactory;

        private bool isSelected;

        private bool isExpanded;

        public ContentFolderViewModel(ContentBaseModel Model, ContentBaseViewModel parent) : base(Model, parent)
        {
            viewModelFactory = new ContentBaseViewModelFactory();

            var list = viewModelFactory.GetViewModels(this.Model.Children, this);
            _children = new List<ContentBaseViewModel>(list);
        }

        public bool IsSelected
        {
            get => isSelected;
            set => this.RaiseAndSetIfChanged(ref isSelected, value);
        }

        public bool IsExpanded
        {
            get => isExpanded;
            set => this.RaiseAndSetIfChanged(ref isExpanded, value);
        }
    }
}
