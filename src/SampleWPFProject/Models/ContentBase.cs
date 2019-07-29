using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleWPFProject.Models
{
    public abstract class ContentBase : INotifyPropertyChanged
    {
        private ObservableCollection<ContentBase> content;

        public ObservableCollection<ContentBase> Children
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Children");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected string name;

        protected string description;

        protected DateTime lastChangedDate;

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

        public DateTime LastChangedDate
        {
            get { return lastChangedDate; }
            set
            {
                lastChangedDate = value;
                OnPropertyChanged("LastChangedDate");
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
