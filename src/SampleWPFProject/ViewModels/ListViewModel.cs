using SampleWPFProject.DBContext;
using SampleWPFProject.Models;
using System.Collections.ObjectModel;

namespace SampleWPFProject.ViewModels
{
    public class ListViewModel : NotifyPropertyChanged
    {
        private readonly DataBase db;

        private ContentFolder selectedFolder;

        private ObservableCollection<ContentBase> contentList;

        private ContentBase selectedItem;

        public ListViewModel()
        {
            db = DataBase.GetInstance();
        }

        public ContentBase SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public ObservableCollection<ContentBase> ContentList
        {
            get { return contentList; }
            set
            {
                contentList = value;
                OnPropertyChanged("ContentList");
            }
        }

        public ContentFolder SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                selectedFolder = value;

                if (selectedFolder != null)
                {
                    ContentList = db.GetContentByFolder(selectedFolder);
                }

                OnPropertyChanged("SelectedFolder");
            }
        }
    }
}
