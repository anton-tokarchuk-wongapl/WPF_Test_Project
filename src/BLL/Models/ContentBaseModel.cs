using System;
using System.Collections.ObjectModel;

namespace BLL.Models
{
    public abstract class ContentBaseModel : NotifyPropertyChanged
    {
        protected string name;

        protected string description;

        protected DateTime lastChangedDate;

        protected string lastChangedDateShort;

        protected ObservableCollection<ContentBaseModel> children;

        public int Id { get; set; }

        public int? ParentContentItemId { get; set; }

        public ContentBaseModel ParentContentItem { get; set; }

        public ContentBaseModel()
        {
            LastChangedDate = DateTime.Now;
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string LastChangedDateShort
            => lastChangedDate.ToShortDateString();

        public DateTime LastChangedDate
        {
            get { return lastChangedDate; }
            set
            {
                lastChangedDate = value;
                OnPropertyChanged("LastChangedDate");
            }
        }

        public ObservableCollection<ContentBaseModel> Children
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
