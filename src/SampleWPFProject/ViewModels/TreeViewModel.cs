using System.Collections.ObjectModel;
using System.Linq;
using BLL.Models;

namespace WPFProject.ViewModels
{
    public class TreeViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<ContentBaseModel> foldersList { get; set; }

        private ContentFolderModel selectedFolder;

        public ContentFolderModel SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                selectedFolder = value;
                OnPropertyChanged("SelectedFolder");
            }
        }

        public ObservableCollection<ContentBaseModel> FoldersList
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