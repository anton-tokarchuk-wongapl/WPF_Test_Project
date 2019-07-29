namespace SampleWPFProject.Models
{
    public class File : ContentBase
    {
        public File(string name, string description)
        {
            base.Name = name;
            base.Description = description;
        }
    }
}
