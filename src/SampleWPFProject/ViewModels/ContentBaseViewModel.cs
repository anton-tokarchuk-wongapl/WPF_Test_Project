using BLC.Models.ContentModels;
using System.Collections.ObjectModel;
using WPFProject.Helpers.Factories;
using WPFProject.Helpers.NotifyPropertyChanged;

namespace WPFProject.ViewModels
{
    public abstract class ContentBaseViewModel : NotifyPropertyChanged
    {
        protected readonly ContentBaseViewModelFactory viewModelFactory;

        protected ContentBaseViewModel ParentItem;

        protected ObservableCollection<ContentBaseViewModel> children;

        public ContentBaseModel Model { get; protected set; }

        public ContentBaseViewModel(ContentBaseModel Model)
        {
            this.Model = Model;
            viewModelFactory = new ContentBaseViewModelFactory();

            if (this.Model.ParentContentItemId != null)
            {
                ParentItem = viewModelFactory.GetViewModel(this.Model.ParentContentItem);
            }
        }

        public int Id
        {
            get { return Model.Id; }
        }

        public string Name
        {
            get { return Model.Name; }
            set
            {
                Model.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return Model.Description; }
            set
            {
                Model.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public string LastChangedDateShort
            => Model.LastChangedDate.ToShortDateString();

        public ObservableCollection<ContentBaseViewModel> Children
        {
            get { return children; }
            set
            {
                children = value;
                OnPropertyChanged("Children");
            }
        }
    }
}
