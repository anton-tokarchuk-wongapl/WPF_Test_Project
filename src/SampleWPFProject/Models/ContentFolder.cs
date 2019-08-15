using System;
using System.Collections.ObjectModel;

namespace SampleWPFProject.Models
{
    public class ContentFolder : ContentBase
    {
        public ContentFolder(int id, string name, string description, ObservableCollection<ContentBase> contentList)
        {
            Id = id;
            Name = name;
            Description = description;
            Children = contentList;
            LastChangedDate = DateTime.Now;
        }
    }
}
