using System.Collections.ObjectModel;
using BLL.Models;

namespace WPFProject.ViewModels
{
    public class ListViewModel : NotifyPropertyChanged
    {
        //private readonly string connection = @"C:\Users\atokar\Documents\WPF_Test_Project\localdb\localdb.sdf";

        //private readonly IRepository repository;

        private ContentFolderModel selectedFolder;

        private ObservableCollection<ContentBaseModel> contentList;

        private ContentBaseModel selectedItem;

        public ListViewModel()
        {
            //repository = new ContentBaseRepository(connection);
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
                    //ContentList = db.GetContentByFolder(selectedFolder);
                }

                OnPropertyChanged("SelectedFolder");
            }
        }
    }
}
