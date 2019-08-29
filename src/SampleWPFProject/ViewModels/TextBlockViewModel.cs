using System;
using System.Reactive.Linq;
using BusinessLogicContracts.Interfaces;
using ReactiveUI;

namespace WPFProject.ViewModels
{
    public class TextBlockViewModel : ReactiveObject
    {
        private readonly IContentBaseService contentBaseService;

        private ContentBaseViewModel editableItem;

        private string name;

        private string description;

        public TextBlockViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
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

        public void UpdateProp()
        {
            if (string.Equals(name, EditableItem.Name) || string.Equals(description, EditableItem.Description))
            {
                return;
            }

            EditableItem.Name = name;
            EditableItem.Description = description;
            contentBaseService.Update(EditableItem.Model);

            Clear();
        }

        public void Clear()
        {
            Name = string.Empty;
            Description = string.Empty;
            EditableItem = null;
        }

        private void BindProp()
        {
            Name = EditableItem.Name;
            Description = EditableItem.Description;
        }
    }
}
