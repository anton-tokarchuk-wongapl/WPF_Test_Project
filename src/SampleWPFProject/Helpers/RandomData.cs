using SampleWPFProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWPFProject.Helpers
{
    class RandomData
    {
        private int elements;

        private int nodes;

        private string folder = "folder";

        private string file = "file";

        public RandomData(int elements, int nodes)
        {
            this.elements = elements;
            this.nodes = nodes;
        }

        public ObservableCollection<ContentBase> CreateRandomData()
        {
            var foldersList = new ObservableCollection<ContentBase>();
            for (int i = 0; i < nodes; ++i)
            {
                foldersList.Add(new Folder(folder + i.ToString(), "SomeFolderDescription", CreateFilesList()));
            }

            return foldersList;
        }

        private ObservableCollection<ContentBase> CreateFilesList()
        {
            var random = new Random();
            var rndNum = random.Next(1, elements);

            var filesList = new ObservableCollection<ContentBase>();

            for (int i = 0; i < rndNum; ++i)
            {
                filesList.Add(new File(file + i.ToString(), "SomeFileDescription"));
            }

            return filesList;
        }
    }
}
