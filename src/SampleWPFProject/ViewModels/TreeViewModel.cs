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
    public class TreeViewModel : ReactiveObject, IDataErrorInfo
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private readonly UserInputValidation userInputValidation;

        private readonly ObservableAsPropertyHelper<IEnumerable<ContentBaseViewModel>> _foldersList;

        private ContentFolderViewModel selectedFolder;

        private string selectedEditableFolderName;

        private bool updateFoldersTree = false;

        public TreeViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
            viewModelFactory = new ContentBaseViewModelFactory();
            userInputValidation = new UserInputValidation();

            _foldersList = this
                .WhenAnyValue(x => x.UpdateFoldersTree)
                .Where(o => o.Equals(true))
                .Select(i => GetFoldersList())
                .ToProperty(this, x => x.FoldersList);

            StartEditing = ReactiveCommand.Create<int>(x => 
            {
                if (!Equals(x, null))
                {
                    FoldersList.Where(i => i.Id == x).ToList().ForEach(s =>
                    {
                        s.IsEditing = true;
                        SelectedEditableFolderName = s.Name;
                    });
                }
            });

            ConfirmEditing = ReactiveCommand.Create(() => 
            {
                var canSave = userInputValidation.ValidateStringProperty(SelectedEditableFolderName);

                if (string.IsNullOrEmpty(canSave))
                {
                    var item = (ContentFolderViewModel)FoldersList.FirstOrDefault(x => x.IsEditing == true);
                    item.Name = SelectedEditableFolderName;
                    contentBaseService.Update(item.Model);
                }
                
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

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                if (Equals(columnName, nameof(SelectedEditableFolderName)))
                {
                    error = userInputValidation.ValidateStringProperty(SelectedEditableFolderName);
                }

                return error;
            }
        }

        public string SelectedEditableFolderName
        {
            get => selectedEditableFolderName;
            set => this.RaiseAndSetIfChanged(ref selectedEditableFolderName, value);
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

        public string Error => null;

        private IEnumerable<ContentBaseViewModel> GetFoldersList()
        {
            var folders = contentBaseService.GetFoldersTree();
            var collection = viewModelFactory.GetViewModels(folders);
            updateFoldersTree = false;

            return new List<ContentBaseViewModel>(collection);
        }

        private void DisableEditing()
            => FoldersList.Where(x => x.IsEditing == true).ToList().ForEach(s => s.IsEditing = false);
    }
}