namespace SampleWPFProject.Models
{
    public class ContentFile : ContentBase
    {
        public ContentFile(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
