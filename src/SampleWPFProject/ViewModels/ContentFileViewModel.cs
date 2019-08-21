using BLC.Models.ContentModels;
using WPFProject.Helpers.Factories;

namespace WPFProject.ViewModels
{
    public class ContentFileViewModel : ContentBaseViewModel
    {
        public ContentFileViewModel(ContentBaseModel Model) : base(Model)
        {
            if (this.Model.ParentContentItemId != null)
            {
                ParentItem = viewModelFactory.GetViewModel(this.Model.ParentContentItem);
            }
        }
    }
}
