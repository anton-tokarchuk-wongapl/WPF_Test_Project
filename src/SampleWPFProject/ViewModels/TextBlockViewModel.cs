using SampleWPFProject.Commands;
using SampleWPFProject.DBContext;
using SampleWPFProject.Models;
using System.Windows.Input;

namespace SampleWPFProject.ViewModels
{
    public class TextBlockViewModel : BaseVM
    {
        private readonly DataBase db;

        public ICommand SaveEditableItem { get; }

        private ContentBase editableItem;

        public TextBlockViewModel()
        {
            db = DataBase.GetInstance();
            SaveEditableItem = new DelegateCommand(obj =>
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
    }
}
