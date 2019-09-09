using System;
using System.ComponentModel;
using System.Reactive.Linq;
using ReactiveUI;
using BusinessLogicContracts.Interfaces;
using WPFProject.Helpers.Validation;

namespace WPFProject.ViewModels
{
    public class TextBlockViewModel : ReactiveObject, IDataErrorInfo
    {
        private readonly IContentBaseService contentBaseService;

        private readonly UserInputValidation userInputValidation;

        private ContentBaseViewModel editableItem;

        private string name;

        private string description;

        public TextBlockViewModel(IContentBaseService contentBaseService)
        {
            userInputValidation = new UserInputValidation();
            this.contentBaseService = contentBaseService;
            this.WhenAnyValue(x => x.EditableItem)
                .Where(i => !Equals(i, null))
                .Subscribe(y => 
                {
                    Name = EditableItem.Name;
                    Description = EditableItem.Description;
                });
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

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                if (!Equals(editableItem, null))
                {
                    if (Equals(columnName, nameof(Name)))
                    {
                        error = userInputValidation.ValidateStringProperty(Name);
                    }
                    else if (Equals(columnName, nameof(Description)))
                    {
                        error = userInputValidation.ValidateStringProperty(Description);
                    }
                }

                return error;
            }
        }

        public string Error => throw new NotImplementedException();

        public void UpdateItem()
        {
            if (Equals(EditableItem, null))
            {
                return;
            }

            if (!string.Equals(name, EditableItem.Name) && string.Equals(description, EditableItem.Description))
            {
                var canSaveName = userInputValidation.ValidateStringProperty(Name);
                var canSaveDescription = userInputValidation.ValidateStringProperty(Description);

                if (string.IsNullOrEmpty(canSaveName) && string.IsNullOrEmpty(canSaveDescription))
                {
                    EditableItem.Name = name;
                    EditableItem.Description = description;
                    contentBaseService.Update(EditableItem.Model);

                    Clear();
                }
            }
        }

        public void Clear()
        {
            EditableItem = null;
            Name = null;
            Description = null;
        }
    }
}
