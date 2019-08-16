using System.Collections.ObjectModel;
using BLL.Models;

namespace WPFProject.ViewModels
{
    public class TreeViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<ContentFolderModel> foldersList { get; set; }

        public ObservableCollection<ContentFolderModel> FoldersList
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