using System.Linq;
using System.Collections.ObjectModel;
using BLC.Models.ContentModels;

namespace WPFProject.ViewModels
{
    public class ContentFolderViewModel : ContentBaseViewModel
    {
        public ContentFolderViewModel(ContentBaseModel Model) : base(Model)
        {
            if (this.Model.Children.Count >= 1)
            {
                var list = this.Model.Children.Select(i => viewModelFactory.GetViewModel(i));
                children = new ObservableCollection<ContentBaseViewModel>(list);
            }
        }
    }
}
