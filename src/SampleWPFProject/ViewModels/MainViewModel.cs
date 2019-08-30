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

        public TreeViewModel TreeViewModel { get; }

        public ListViewModel ListViewModel { get; }

        public TextBlockViewModel TextBlockViewModel { get; }

        public MainViewModel()
        {
            contentBaseService = new ContentBaseService();

            TreeViewModel = new TreeViewModel(contentBaseService);
            ListViewModel = new ListViewModel(contentBaseService);
            TextBlockViewModel = new TextBlockViewModel(contentBaseService);

            this.WhenAnyValue(x => x.TreeViewModel.SelectedFolder)
                .Subscribe(_ => BindSelectedFolderInListView());

            this.WhenAnyValue(x => x.ListViewModel.SelectedListViewItem)
                .Subscribe(_ => BindSelectedItemInTextBlock());

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

        private void BindSelectedFolderInListView()
        {
            ListViewModel.SelectedTreeViewItem = TreeViewModel.SelectedFolder;
            ListViewModel.SelectedListViewItem = TreeViewModel.SelectedFolder;
        }

        private void BindSelectedItemInTextBlock()
        {
            TextBlockViewModel.EditableItem = ListViewModel.SelectedListViewItem;
        }

        private void SaveItem()
        {
            TextBlockViewModel.UpdateItem();
            TreeViewModel.UpdateFoldersTree = true;
        }
    }
}