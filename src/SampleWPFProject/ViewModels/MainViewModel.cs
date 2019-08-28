using BusinessLogicLayer.Services;
using BusinessLogicContracts.Interfaces;
using ReactiveUI;
using System.Reactive;

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
            TreeViewModel.CreateFoldersList();

            ListViewModel = new ListViewModel(contentBaseService);
            TextBlockViewModel = new TextBlockViewModel();

            SaveItemCommand = ReactiveCommand.Create(() =>
            {
                SaveItem();
            });
            EditItemCommand = ReactiveCommand.Create(() =>
            {
                EditItem();
            });
        }

        public ReactiveCommand<Unit, Unit> SaveItemCommand { get; }

        public ReactiveCommand<Unit, Unit> EditItemCommand { get; }

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

                TreeViewModel.CreateFoldersList();
            }
        }

        private void EditItem()
        {
            var content = ListViewModel.SelectedItem;

            if (content != null)
            {
                TextBlockViewModel.Name = content.Name;
                TextBlockViewModel.Description = content.Description;

                TextBlockViewModel.EditableItem = content;
            }
        }
    }
}