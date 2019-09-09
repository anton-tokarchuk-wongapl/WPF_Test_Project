using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;
using BusinessLogicContracts.Interfaces;
using WPFProject.Helpers.Factories;
using System.Reactive;
using System.Linq;
using WPFProject.Helpers.Validation;
using System.ComponentModel;

namespace WPFProject.ViewModels
{
    public class TreeViewModel : ReactiveObject
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private readonly ObservableAsPropertyHelper<IEnumerable<ContentFolderViewModel>> _foldersList;

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

        public IEnumerable<ContentFolderViewModel> FoldersList => _foldersList.Value;

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

        public string Error => null;

        private IEnumerable<ContentFolderViewModel> GetFoldersList()
        {
            var folders = contentBaseService.GetFoldersTree();
            var collection = viewModelFactory.GetFoldersViewModels(folders, contentBaseService);
            updateFoldersTree = false;

            return new List<ContentFolderViewModel>(collection);
        }
    }
}