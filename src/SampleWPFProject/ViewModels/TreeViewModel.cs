using SampleWPFProject.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SampleWPFProject.ViewModels
{
    public class TreeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Folder> FoldersList;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
 