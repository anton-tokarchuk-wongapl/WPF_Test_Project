using System.Collections.Generic;
using ReactiveUI;
using BusinessLogicContracts.Models.ContentModels;

namespace WPFProject.ViewModels
{
    public abstract class ContentBaseViewModel : ReactiveObject
    {
        protected readonly ContentBaseViewModel ParentItem;

        protected IEnumerable<ContentBaseViewModel> _children;

        protected string _name;

        protected string _description;

        protected string _lastChangedDateShort;

        public ContentBaseViewModel(ContentBaseModel Model,
                                    ContentBaseViewModel ParentItem = null)
        {
            this.ParentItem = ParentItem;
            this.Model = Model;
            _name = Model.Name;
            _description = Model.Description;
            _lastChangedDateShort = Model.LastChangedDate.ToShortDateString();
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
