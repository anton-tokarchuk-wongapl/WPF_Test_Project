using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using ReactiveUI;
using BusinessLogicContracts.Interfaces;
using BusinessLogicContracts.Models.ContentModels;
using WPFProject.Helpers.Factories;
using WPFProject.Helpers.Validation;

namespace WPFProject.ViewModels
{
    public class ContentFolderViewModel : ContentBaseViewModel, IDataErrorInfo
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private readonly UserInputValidation userInputValidation;

        private bool isEditing = false;

        private string selectedEditableFolderName;

        public ContentFolderViewModel(ContentBaseModel Model,
                                      ContentBaseViewModel parent = null, 
                                      IContentBaseService contentBaseService = null) : base(Model, parent)
        {
            this.contentBaseService = contentBaseService;
            viewModelFactory = new ContentBaseViewModelFactory();
            userInputValidation = new UserInputValidation();

            var list = viewModelFactory.GetViewModels(this.Model.Children, this);
            _children = new List<ContentBaseViewModel>(list);

            StartEditing = ReactiveCommand.Create(() =>
            {
                SelectedEditableFolderName = Name;
                IsEditing = true;
            });

            ConfirmEditing = ReactiveCommand.Create(() =>
            {
                var canSave = userInputValidation.ValidateStringProperty(SelectedEditableFolderName);

                if (string.IsNullOrEmpty(canSave))
                {
                    Name = SelectedEditableFolderName;
                    this.contentBaseService.Update(Model);
                }

                IsEditing = false;
            });

            CancelEditing = ReactiveCommand.Create(() =>
            {
                IsEditing = false;
            });
        }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;

                if (Equals(columnName, nameof(SelectedEditableFolderName)) && !string.IsNullOrEmpty(SelectedEditableFolderName))
                {
                    error = userInputValidation.ValidateStringProperty(SelectedEditableFolderName);
                }

                return error;
            }
        }

        public ReactiveCommand<Unit, Unit> StartEditing { get; }

        public ReactiveCommand<Unit, Unit> CancelEditing { get; }

        public ReactiveCommand<Unit, Unit> ConfirmEditing { get; }

        public bool IsEditing
        {
            get => isEditing;
            set => this.RaiseAndSetIfChanged(ref isEditing, value);
        }
        
        public string SelectedEditableFolderName
        {
            get => selectedEditableFolderName;
            set => this.RaiseAndSetIfChanged(ref selectedEditableFolderName, value);
        }

        public string Error => null;
    }
}
