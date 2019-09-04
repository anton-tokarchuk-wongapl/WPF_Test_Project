using System.Collections.Generic;
using ReactiveUI;
using BusinessLogicContracts.Models.ContentModels;
using System.ComponentModel;
using System;

namespace WPFProject.ViewModels
{
    public abstract class ContentBaseViewModel : ReactiveObject, IDataErrorInfo
    {
        protected readonly ContentBaseViewModel ParentItem;

        protected IEnumerable<ContentBaseViewModel> _children;

        protected string _name;

        protected string _description;

        protected string _lastChangedDateShort;

        public ContentBaseViewModel(ContentBaseModel Model, ContentBaseViewModel ParentItem = null)
        {
            this.ParentItem = ParentItem;
            this.Model = Model;
            _name = Model.Name;
            _description = Model.Description;
            _lastChangedDateShort = Model.LastChangedDate.ToShortDateString();
        }

        public ContentBaseModel Model { get; protected set; }

        public string Error => null; 

        public int Id => Model.Id;

        public string Name
        {
            get => _name;
            set
            {
                this.RaiseAndSetIfChanged(ref _name, value);
                Model.Name = _name;
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                this.RaiseAndSetIfChanged(ref _description, value);
                Model.Description = _description;
            }
        }

        public string LastChangedDateShort => _lastChangedDateShort;

        public IEnumerable<ContentBaseViewModel> Children => _children;

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                switch (columnName)
                {
                    case "Name":
                        error = ValidateStringProperty(Name);
                        break;
                    case "Description":
                        error = ValidateStringProperty(Description);
                        break;
                }

                return error;
            }
        }

        protected string ValidateStringProperty(string property)
        {
            string result = string.Empty;

            if (string.IsNullOrWhiteSpace(property))
            {
                result = "Field cannot be empty";
            }
            else if (property.Length > 100)
            {
                result = "Field cannot be more 100 symbols";
            }
            else if (property.Length < 3)
            {
                result = "Field cannot be less of 3 symbols";
            }

            return result;
        }
    }
}
