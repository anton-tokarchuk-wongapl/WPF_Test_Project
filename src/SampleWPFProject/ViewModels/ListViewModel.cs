using System.Linq;
using BLC.Interfaces;
using System.Collections.ObjectModel;
using WPFProject.Helpers.NotifyPropertyChanged;
using WPFProject.Helpers.Factories;

namespace WPFProject.ViewModels
{
    public class ListViewModel : NotifyPropertyChanged
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private ContentFolderViewModel selectedFolder;

        private ObservableCollection<ContentBaseViewModel> contentList;

        private ContentBaseViewModel selectedItem;

        public ListViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
            viewModelFactory = new ContentBaseViewModelFactory();
        }

        public ContentBaseViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ObservableCollection<ContentBaseViewModel> ContentList
        {
            get { return contentList; }
            set
            {
                contentList = value;
                OnPropertyChanged("ContentList");
            }
        }

        public ContentFolderViewModel SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                selectedFolder = value;

                if (selectedFolder != null)
                {
                    var item = contentBaseService.GetContentItemById(selectedFolder.Id);
                    var list = item.Children.Select(i => viewModelFactory.GetViewModel(i));
                    ContentList = new ObservableCollection<ContentBaseViewModel>(list);
                }

                OnPropertyChanged("SelectedFolder");
            }
        }
    }
}
