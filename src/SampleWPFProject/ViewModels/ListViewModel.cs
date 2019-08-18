using System.Collections.ObjectModel;
using BLL.Models;
using BLL.Services.Interfaces;

namespace WPFProject.ViewModels
{
    public class ListViewModel : NotifyPropertyChanged
    {
        private readonly IContentBaseService contentBaseService;

        private ContentFolderModel selectedFolder;

        private ObservableCollection<ContentBaseModel> contentList;

        private ContentBaseModel selectedItem;

        public ListViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
        }

        public ContentBaseModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ObservableCollection<ContentBaseModel> ContentList
        {
            get { return contentList; }
            set
            {
                contentList = value;
                OnPropertyChanged("ContentList");
            }
        }

        public ContentFolderModel SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                selectedFolder = value;

                if (selectedFolder != null)
                {
                    var item = contentBaseService.GetContentItemById(selectedFolder.Id);
                    ContentList = new ObservableCollection<ContentBaseModel>(item.Children);
                }

                OnPropertyChanged("SelectedFolder");
            }
        }
    }
}
