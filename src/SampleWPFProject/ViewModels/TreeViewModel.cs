using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;
using BusinessLogicContracts.Interfaces;
using WPFProject.Helpers.Factories;


namespace WPFProject.ViewModels
{
    public class TreeViewModel : ReactiveObject
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private readonly ObservableAsPropertyHelper<IEnumerable<ContentBaseViewModel>> _foldersList;

        private ContentFolderViewModel selectedFolder;

        private bool updateFoldersTree = false;

        public TreeViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
            viewModelFactory = new ContentBaseViewModelFactory();

            _foldersList = this
                .WhenAnyValue(x => x.UpdateFoldersTree)
                .Where(o => o.Equals(true))
                .Select(i => GetFoldersList())
                .ToProperty(this, x => x.FoldersList);

            UpdateFoldersTree = true;
        }

        public bool UpdateFoldersTree
        {
            get => updateFoldersTree;
            set => this.RaiseAndSetIfChanged(ref updateFoldersTree, value);
        }

        public ContentFolderViewModel SelectedFolder
        {
            get => selectedFolder;
            set => this.RaiseAndSetIfChanged(ref selectedFolder, value);
        }

        public IEnumerable<ContentBaseViewModel> FoldersList => _foldersList.Value;

        private IEnumerable<ContentBaseViewModel> GetFoldersList()
        {
            var folders = contentBaseService.GetFoldersTree();
            var collection = viewModelFactory.GetViewModels(folders);
            updateFoldersTree = false;

            return new List<ContentBaseViewModel>(collection);
        }
    }
}