using BusinessLogicContracts.Interfaces;
using ReactiveUI;
using System.Collections.Generic;
using WPFProject.Helpers.Factories;

namespace WPFProject.ViewModels
{
    public class TreeViewModel : ReactiveObject
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private IEnumerable<ContentBaseViewModel> foldersList;

        private ContentFolderViewModel selectedFolder;

        public TreeViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
            viewModelFactory = new ContentBaseViewModelFactory();
        }

        public ContentFolderViewModel SelectedFolder
        {
            get => selectedFolder;
            set => this.RaiseAndSetIfChanged(ref selectedFolder, value);
        }

        public IEnumerable<ContentBaseViewModel> FoldersList
        {
            get => foldersList;
            set => this.RaiseAndSetIfChanged(ref foldersList, value);
        }

        public void CreateFoldersList()
        {
            var folders = contentBaseService.GetFoldersTree();
            var collection = viewModelFactory.GetViewModels(folders);

            foldersList = new List<ContentBaseViewModel>(collection);
        }
    }
}