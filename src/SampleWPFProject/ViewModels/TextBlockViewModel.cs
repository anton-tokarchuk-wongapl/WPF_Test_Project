using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace WPFProject.ViewModels
{
    public class TextBlockViewModel : ReactiveObject
    {
        private string name;

        private string description;

        private ContentBaseViewModel editableItem;

        public TextBlockViewModel()
        {
            this.WhenAnyValue(x => x.EditableItem)
                .Where(i => !Equals(i, null))
                .Subscribe(_ => BindProp());
        }

        public ContentBaseViewModel EditableItem
        {
            get => editableItem;
            set => this.RaiseAndSetIfChanged(ref editableItem, value);
        }


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

        public void Clear()
        {
            Name = string.Empty;
            Description = string.Empty;
            EditableItem = null;
        }

        public void UpdateProp()
        {
            if (!CanSaveItem())
            {
                return;
            }

            EditableItem.Name = name;
            EditableItem.Description = description;
        }

        private void BindProp()
        {
            Name = EditableItem.Name;
            Description = EditableItem.Description;
        }

        private bool CanSaveItem()
        {
            bool result = false;

            if (!string.Equals(name, EditableItem.Name) || !string.Equals(description, EditableItem.Description))
            {
                result = true;
            }

            return result;
        }
    }
}
