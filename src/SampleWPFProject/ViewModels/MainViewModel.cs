using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using BusinessLogicLayer.Services;
using BusinessLogicContracts.Interfaces;

namespace WPFProject.ViewModels
{
    /// <summary>
    /// Class contains all ViewModels and commands for working with them.
    /// </summary>
    public class MainViewModel : ReactiveObject
    {
        private readonly IContentBaseService contentBaseService;

        public ListViewModel ListViewModel { get; }

        public TextBlockViewModel TextBlockViewModel { get; }

        public TreeViewModel TreeViewModel { get; }

        public MainViewModel()
        {
            contentBaseService = new ContentBaseService();

            TreeViewModel = new TreeViewModel(contentBaseService);
            ListViewModel = new ListViewModel(contentBaseService);
            TextBlockViewModel = new TextBlockViewModel();

            this.WhenAnyValue(x => x.TreeViewModel.SelectedFolder)
                .Subscribe(_ => BindSelectedFolder());

            this.WhenAnyValue(x => x.ListViewModel.SelectedItem)
                .Subscribe(_ => BindSelectedItem());

            SaveItemCommand = ReactiveCommand.Create(() =>
            {
                SaveItem();
            });
            ClearCommand = ReactiveCommand.Create(() => 
            {
                TextBlockViewModel.Clear();
            });
        }

        public ReactiveCommand<Unit, Unit> SaveItemCommand { get; }

        public ReactiveCommand<Unit, Unit> ClearCommand { get; }

        private void BindSelectedFolder()
        {
            ListViewModel.SelectedFolder = TreeViewModel.SelectedFolder;
            ListViewModel.SelectedItem = TreeViewModel.SelectedFolder;
        }

        private void SaveItem()
        {
            var name = TextBlockViewModel.Name;
            var description = TextBlockViewModel.Description;
            var editableItem = TextBlockViewModel.EditableItem;

            if (!string.Equals(name, editableItem.Name) || !string.Equals(description, editableItem.Description))
            {
                editableItem.Name = name;
                editableItem.Description = description;

                var model = editableItem.Model;
                contentBaseService.Update(model);

                TextBlockViewModel.Name = string.Empty;
                TextBlockViewModel.Description = string.Empty;

                TreeViewModel.UpdateFoldersTree = true;
            }
        }

        private void BindSelectedItem()
        {
            if (ListViewModel.SelectedItem != null)
            {
                var selectedItem = ListViewModel.SelectedItem;

                TextBlockViewModel.Name = selectedItem.Name;
                TextBlockViewModel.Description = selectedItem.Description;
                TextBlockViewModel.EditableItem = selectedItem;
            }
        }
    }
}