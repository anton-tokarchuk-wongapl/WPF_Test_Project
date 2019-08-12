using Newtonsoft.Json;
using SampleWPFProject.Models;
using System.Collections.ObjectModel;
using System.IO;
using File = System.IO.File;

namespace SampleWPFProject.Helpers
{
    public class DataManager
    { 
        private readonly string rootFolder;

        private readonly string jsonName = "testData1.json";

        private static int idCounter = 0;

        private int id = ++idCounter;

        public DataManager()
        {
            rootFolder = Directory.GetCurrentDirectory();
        }

        private void GetData()
        {
            var fullPathToJson = Path.Combine(rootFolder, jsonName);
            var json = File.ReadAllText(fullPathToJson);

            var collection = JsonConvert.DeserializeObject<ObservableCollection<ContentBase>>(json);


        }

        public void SaveChanges()
        {
            var data = CreateRandomData();
            var fullPathToJson = Path.Combine(rootFolder, jsonName);

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            File.WriteAllText(fullPathToJson, json);

            // serialize JSON directly to a file
            //using (StreamWriter file = File.CreateText(fullPathToJson))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, data);
            //    serializer.Serialize()
            //}
        }

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
           // var random = new Random();
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
