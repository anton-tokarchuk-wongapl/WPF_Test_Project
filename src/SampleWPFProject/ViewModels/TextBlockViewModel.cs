using SampleWPFProject.Commands;
using SampleWPFProject.DBContext;
using SampleWPFProject.Models;
using System.Windows.Input;

namespace SampleWPFProject.ViewModels
{
    public class TextBlockViewModel : BaseVM
    {
        private readonly DataBase db;

        private readonly ICommand saveEditableItem;

        private ContentBase editableItem { get; set; }

        public TextBlockViewModel()
        {
            db = DataBase.GetInstance();
            saveEditableItem = new DelegateCommand(obj =>
            {
                db.EditContent(EditableItem);
            });
        }

        public ContentBase EditableItem
        {
            get { return editableItem; }
            set
            {
                editableItem = value;
                OnPropertyChanged("EditableItem");
            }
        }

        public ICommand SaveEditableItem
        {
            get
            {
                return saveEditableItem;
            }
        }
    }
}
