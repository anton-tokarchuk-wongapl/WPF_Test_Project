using System.Collections.ObjectModel;
using System.Linq;
using BLL.Models;

namespace WPFProject.ViewModels
{
    public class TreeViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<ContentBaseModel> foldersList { get; set; }

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