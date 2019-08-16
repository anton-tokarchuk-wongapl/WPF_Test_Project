using System.Collections.Generic;
using System.Windows.Input;
using BLL.Services.Interfaces;
using BLL.Services;
using BLL.Models;
using WPFProject.Commands;

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

            //TreeViewModel = new TreeViewModel();
            //ListViewModel = new ListViewModel();
            //TextBlockViewModel = new TextBlockViewModel();

            Init();
        }

        private void Init()
        {
            var folder = new ContentFolderModel { Name = "ParentFolder", Description = "DescriptionForParentFolder" };
            var file1 = new ContentFileModel { Name = "ChildFile1", Description = "DescriptionForChildFile1", ParentContentItem = folder };
            var file2 = new ContentFileModel { Name = "ChildFile2", Description = "DescriptionForChildFile2", ParentContentItem = folder };
            var file3 = new ContentFileModel { Name = "ChildFile3", Description = "DescriptionForChildFile3", ParentContentItem = folder };
            var file4 = new ContentFileModel { Name = "ChildFile4", Description = "DescriptionForChildFile4", ParentContentItem = folder };

            var list = new List<ContentBaseModel> { folder, file1, file2, file3, file4 };
            contentBaseService.CreateRange(list);
            contentBaseService.Save();
            //repository.CreateRange(list);
            //repository.Save();
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

                      //  db.EditContent(editableItem);

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