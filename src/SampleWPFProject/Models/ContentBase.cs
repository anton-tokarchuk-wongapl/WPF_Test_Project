using System;
using System.Collections.ObjectModel;

namespace SampleWPFProject.Models
{
    public abstract class ContentBase : NotifyPropertyChanged
    {
        protected int id;

        protected string name;

        protected string description;

        protected DateTime lastChangedDate;

        protected string lastChangedDateShort;

        public ContentBase ParentItem;

        private ObservableCollection<ContentBase> content;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
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

        public ObservableCollection<ContentBase> Children
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Children");
            }
        }
    }
}
