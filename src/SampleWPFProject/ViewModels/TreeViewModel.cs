using System.Collections.Generic;
using System.Reactive.Linq;
using ReactiveUI;
using BusinessLogicContracts.Interfaces;
using WPFProject.Helpers.Factories;
using System.Reactive;
using System.Linq;

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

            StartEditing = ReactiveCommand.Create<int>(x => StartEditingById(x));
            ConfirmEditing = ReactiveCommand.Create(() => 
            {
                var item = (ContentFolderViewModel)FoldersList.FirstOrDefault(x => x.IsEditing == true);
                item.Name = item.EditableName;
                contentBaseService.Update(item.Model);

                DisableEditing();
            });

            CancelEditing = ReactiveCommand.Create(() => 
            {
                DisableEditing();
            });

            UpdateFoldersTree = true;
        }

        public IEnumerable<ContentBaseViewModel> FoldersList => _foldersList.Value;

        public ReactiveCommand<int, Unit> StartEditing { get; }

        public ReactiveCommand<Unit, Unit> CancelEditing { get; }

        public ReactiveCommand<Unit, Unit> ConfirmEditing { get; }

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

        private IEnumerable<ContentBaseViewModel> GetFoldersList()
        {
            var folders = contentBaseService.GetFoldersTree();
            var collection = viewModelFactory.GetViewModels(folders);
            updateFoldersTree = false;

            return new List<ContentBaseViewModel>(collection);
        }

        private void StartEditingById(int id)
        {
            if (Equals(id, null))
            {
                return;
            }

            FoldersList.Where(x => x.Id == id).ToList().ForEach(s => s.IsEditing = true);
        }

        private void DisableEditing()
            => FoldersList.Where(x => x.IsEditing == true).ToList().ForEach(s => s.IsEditing = false);
    }
}