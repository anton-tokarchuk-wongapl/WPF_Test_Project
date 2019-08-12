using SampleWPFProject.DBContext;
using SampleWPFProject.Models;
using System.Collections.ObjectModel;

namespace SampleWPFProject.ViewModels
{
    public class ListViewModel : BaseVM
    {
        private readonly DataBase db;

        private ContentFolder selectedFolder;

        private ObservableCollection<ContentBase> contentList;

        public ListViewModel()
        {
            db = DataBase.GetInstance();
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
                    ContentList = db.GetContentByFolderName(selectedFolder);
                }

                OnPropertyChanged("SelectedFolder");
            }
        }
    }
}
