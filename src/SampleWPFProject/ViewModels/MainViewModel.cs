using System.Windows.Input;
using SampleWPFProject.Commands;
using SampleWPFProject.DBContext;
using SampleWPFProject.Models;

namespace SampleWPFProject.ViewModels
{
    /// <summary>
    /// Class contains all ViewModels and commands for working with them.
    /// </summary>
    public class MainViewModel : NotifyPropertyChanged
    {
        private readonly DataBase db;

        public TreeViewModel TreeViewModel { get; }

        public ListViewModel ListViewModel { get; }

        public TextBlockViewModel TextBlockViewModel { get; }

        public MainViewModel()
        {
            db = DataBase.GetInstance();

            TreeViewModel = new TreeViewModel();
            TreeViewModel.FoldersList = db.FoldersCollection;
            ListViewModel = new ListViewModel();
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

                        db.EditContent(editableItem);

                        TextBlockViewModel.Name = string.Empty;
                        TextBlockViewModel.Description = string.Empty;
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