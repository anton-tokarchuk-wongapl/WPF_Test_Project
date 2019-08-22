using System.Windows.Input;
using BusinessLogicLayer.Services;
using BusinessLogicContracts.Interfaces;
using WPFProject.Helpers.Commands;

namespace WPFProject.ViewModels
{
    /// <summary>
    /// Class contains all ViewModels and commands for working with them.
    /// </summary>
    public class MainViewModel
    {
        private readonly IContentBaseService contentBaseService;

        public TreeViewModel TreeViewModel { get; }

        public ListViewModel ListViewModel { get; }

        public TextBlockViewModel TextBlockViewModel { get; }

        public MainViewModel()
        {
            contentBaseService = new ContentBaseService();

            TreeViewModel = new TreeViewModel(contentBaseService);
            TreeViewModel.CreateFoldersList();
           
            ListViewModel = new ListViewModel(contentBaseService);
            TextBlockViewModel = new TextBlockViewModel();
        }

        public ICommand SaveItem
        {
            get
            {
                return new DelegateCommand(obj =>
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
                });
            }
        }

        public ICommand EditItem
        {
            get
            {
                return new DelegateCommand(obj =>
                {
                    var content = ListViewModel.SelectedItem;

                    if (content != null)
                    {
                        TextBlockViewModel.Name = content.Name;
                        TextBlockViewModel.Description = content.Description;

                        TextBlockViewModel.EditableItem = content;
                    }
                });
            }
        }
    }
}