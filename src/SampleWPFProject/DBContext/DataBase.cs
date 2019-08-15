using SampleWPFProject.Helpers;
using SampleWPFProject.Models;
using System.Collections.ObjectModel;

namespace SampleWPFProject.DBContext
{
    /// <summary>
    /// Contains all method for wokring with targed of Data.
    /// </summary>
    public class DataBase
    {
        private static DataBase instance;

        public static DataBase GetInstance()
        {
            if (instance == null)
            {
                instance = new DataBase();
            }

            return instance;
        }

        private readonly DataManager dataManager;

        private readonly ObservableCollection<ContentBase> defaultCollection;

        public ObservableCollection<ContentBase> FullContentCollection { get; set; }

        public ObservableCollection<ContentFolder> FoldersCollection { get; set; }

        private DataBase()
        {
            dataManager = new DataManager();

            defaultCollection = dataManager.CreateRandomData();
            FullContentCollection = dataManager.CreateRandomData();
            FoldersCollection = CreateFoldersCollection(FullContentCollection);
        }

        public ObservableCollection<ContentBase> GetContentByFolder(ContentFolder folder)
            => GetContentByFolderRecursive(folder, FullContentCollection);

        public void EditContent(ContentBase content)
            => EditItemByObjectRecursive(content, FullContentCollection);

        private void EditItemByObjectRecursive(ContentBase item, ObservableCollection<ContentBase> collection)
        {
            for (int i = 0; i < collection?.Count; ++i)
            {
                if (collection[i].Id == item.Id)
                {
                    ContentBase newItem;

                    if (collection[i] is ContentFolder)
                    {
                        newItem = new ContentFolder(item.Id, item.Name, item.Description, item.Children);
                    }
                    else
                    {
                        newItem = new ContentFile(item.Id, item.Name, item.Description);
                    }

                    collection[i] = newItem;
                    break;
                }
                else
                {
                    EditItemByObjectRecursive(item, collection[i].Children);
                }
            }
        }

        private ObservableCollection<ContentBase> GetContentByFolderRecursive(ContentFolder folder, ObservableCollection<ContentBase> collection)
        {
            var fullContentFolder = new ObservableCollection<ContentBase>();

            for (int i = 0; i < collection?.Count; ++i)
            {
                if (string.Equals(collection[i].Name, folder.Name))
                {
                    fullContentFolder = collection[i].Children;
                    break;
                }
                else
                {
                    fullContentFolder = GetContentByFolderRecursive(folder, collection[i].Children);
                }
            }

            return fullContentFolder;
        }

        private ObservableCollection<ContentFolder> CreateFoldersCollection(ObservableCollection<ContentBase> collection)
        {
            var folders = new ObservableCollection<ContentFolder>();

            for (int i = 0; i < collection.Count; ++i)
            {
                if (collection[i] is ContentFolder)
                {
                    var folder = SortContentByFolder((ContentFolder)collection[i]);
                    folders.Add(folder);
                }
            }

            FullContentCollection = defaultCollection;

            return folders;
        }

        private ContentFolder SortContentByFolder(ContentFolder folder)
        {
            var newCollection = new ObservableCollection<ContentBase>();

            for (int i = 0; i < folder.Children.Count; ++i)
            {
                if (folder.Children[i] is ContentFolder)
                {
                    newCollection.Add(SortContentByFolder((ContentFolder)folder.Children[i]));
                }
            }

            var newFolder = folder;
            newFolder.Children = newCollection;

            return newFolder;
        }
    }
}
