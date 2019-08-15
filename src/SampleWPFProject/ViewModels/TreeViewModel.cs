using SampleWPFProject.Models;
using System.Collections.ObjectModel;

namespace SampleWPFProject.ViewModels
{
    public class TreeViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<ContentFolder> foldersList { get; set; }

        public ObservableCollection<ContentFolder> FoldersList
        {
            get { return foldersList; }
            set
            {
                foldersList = value;
                OnPropertyChanged("FoldersList");
            }
        }
    }
}