using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleWPFProject.Models
{
    public class Folder : ContentBase
    {
        public Folder(string name, string description, ObservableCollection<ContentBase> contentList)
        {
            this.Name = name;
            this.Description = description;
            this.Children = contentList;
        }

    }
}
