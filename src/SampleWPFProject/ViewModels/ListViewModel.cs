using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using ReactiveUI;
using BusinessLogicContracts.Interfaces;
using WPFProject.Helpers.Factories;

namespace WPFProject.ViewModels
{
    public class ListViewModel : ReactiveObject
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private readonly ObservableAsPropertyHelper<IEnumerable<ContentBaseViewModel>> _contentList;

        private ContentFolderViewModel selectedTreeViewItem;

        private ContentBaseViewModel selectedListViewItem;

        public ListViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
            viewModelFactory = new ContentBaseViewModelFactory();

            _contentList = this
                .WhenAnyValue(x => x.SelectedTreeViewItem)
                .Where(o => !Equals(o, null))
                .Select(t => GetContentList(t.Id))
                .ToProperty(this, x => x.ContentList);
        }

        public IEnumerable<ContentBaseViewModel> ContentList => _contentList.Value;

        public ContentBaseViewModel SelectedListViewItem
        {
            get => selectedListViewItem;
            set => this.RaiseAndSetIfChanged(ref selectedListViewItem, value);
        }

        public ContentFolderViewModel SelectedTreeViewItem
        {
            get => selectedTreeViewItem;
            set => this.RaiseAndSetIfChanged(ref selectedTreeViewItem, value);
        }

        private IEnumerable<ContentBaseViewModel> GetContentList(int id)
        {
            var item = contentBaseService.GetContentItemById(id);
            var list = viewModelFactory.GetViewModels(item.Children, selectedTreeViewItem);

            return new List<ContentBaseViewModel>(list);
        }
    }
}
