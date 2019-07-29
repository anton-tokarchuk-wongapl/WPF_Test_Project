using SampleWPFProject.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleWPFProject.ViewModels
{
    public class ContentViewModel : INotifyPropertyChanged
    {
        private ContentBase selectedItem;

        public ObservableCollection<ContentBase> Content { get; set; }

        public ContentBase SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ContentViewModel()
        {
            var helper = new Helpers.RandomData(10, 10);
            Content = helper.CreateRandomData();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

            // 
        }
    }
}
