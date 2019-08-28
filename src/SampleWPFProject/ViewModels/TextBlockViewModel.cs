using ReactiveUI;

namespace WPFProject.ViewModels
{
    public class TextBlockViewModel : ReactiveObject
    {
        private string name;

        private string description;

        public ContentBaseViewModel EditableItem { get; set; }

        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }
    }
}
