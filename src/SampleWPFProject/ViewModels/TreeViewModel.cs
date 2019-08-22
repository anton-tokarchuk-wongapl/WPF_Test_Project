using BusinessLogicContracts.Interfaces;
using System.Collections.ObjectModel;
using WPFProject.Helpers.Factories;
using WPFProject.Helpers.NotifyPropertyChanged;

namespace WPFProject.ViewModels
{
    public class TreeViewModel : NotifyPropertyChanged
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private ObservableCollection<ContentBaseViewModel> foldersList { get; set; }

        private ContentFolderViewModel selectedFolder;

        public TreeViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
            viewModelFactory = new ContentBaseViewModelFactory();
        }

        public ContentFolderViewModel SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                selectedFolder = value;
                OnPropertyChanged("SelectedFolder");
            }
        }

        public ObservableCollection<ContentBaseViewModel> FoldersList
        {
            get { return foldersList; }
            set
            {
                foldersList = value;
                
                OnPropertyChanged("FoldersList");
            }
        }

        public void CreateFoldersList()
        {
            var folders = contentBaseService.GetFoldersTree();
            var collection = viewModelFactory.GetViewModels(folders);

            foldersList = new ObservableCollection<ContentBaseViewModel>(collection);
        }
    }
}