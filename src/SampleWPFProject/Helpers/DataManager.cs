using SampleWPFProject.Models;
using System.Collections.ObjectModel;

namespace SampleWPFProject.Helpers
{
    public class DataManager
    { 
        private static int idCounter = 0;

        private int id = ++idCounter;

        public ObservableCollection<ContentBase> CreateRandomData()
        {
            var contentList = new ObservableCollection<ContentBase>();

            var parentFolder1 = new ContentFolder(id, "ParentFolder1", "SomeFolderDescription", CreateFilesList());
            var folder1 = new ContentFolder(id, "Folder1", "SomeFolderDescription", CreateFilesList());

            var parentFolder2 = new ContentFolder(id, "ParentFolder2", "SomeFolderDescription", CreateFilesList());
            var folder2 = new ContentFolder(id, "Folder2", "SomeFolderDescription", CreateFilesList());

            parentFolder1.Children.Add(folder1);
            parentFolder2.Children.Add(folder2);

            contentList.Add(parentFolder1);
            contentList.Add(parentFolder2);

            return contentList;
        }

        private ObservableCollection<ContentBase> CreateFilesList()
        {
            var rndNum = 10;

            var filesList = new ObservableCollection<ContentBase>();

            for (int i = 0; i < rndNum; ++i)
            {
                filesList.Add(new ContentFile(id, "File" + i.ToString(), "SomeFileDescription"));
            }

            return filesList;
        }
    }
}
