using System.Collections.Generic;
using BusinessLogicContracts.Models.ContentModels;
using ReactiveUI;
using WPFProject.Helpers.Factories;

namespace WPFProject.ViewModels
{
    public abstract class ContentBaseViewModel : ReactiveObject
    {
        protected readonly ContentBaseViewModelFactory viewModelFactory;

        protected readonly ContentBaseViewModel ParentItem;

        protected readonly IEnumerable<ContentBaseViewModel> _children;

        protected string _name;

        protected string _description;

        protected string _lastChangedDateShort;

        public ContentBaseViewModel(ContentBaseModel Model, ContentBaseViewModel ParentItem = null)
        {
            this.ParentItem = ParentItem;
            this.Model = Model;
            _name = Model.Name;
            _description = Model.Description;
            _lastChangedDateShort = Model.LastChangedDate.ToShortDateString();

            viewModelFactory = new ContentBaseViewModelFactory();

            var list = viewModelFactory.GetViewModels(this.Model.Children, this);
            _children = new List<ContentBaseViewModel>(list);
        }

        public ContentBaseModel Model { get; protected set; }

        public int Id => Model.Id;

        public string Name
        {
            get => _name;
            set
            {
                this.RaiseAndSetIfChanged(ref _name, value);
                Model.Name = _name;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                this.RaiseAndSetIfChanged(ref _description, value);
                Model.Description = _description;
            }
        }

        public string LastChangedDateShort => _lastChangedDateShort;

        public IEnumerable<ContentBaseViewModel> Children => _children;
    }
}
