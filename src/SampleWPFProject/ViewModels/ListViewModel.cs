using BusinessLogicContracts.Interfaces;
using WPFProject.Helpers.Factories;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace WPFProject.ViewModels
{
    public class ListViewModel : ReactiveObject
    {
        private readonly IContentBaseService contentBaseService;

        private readonly ContentBaseViewModelFactory viewModelFactory;

        private ContentFolderViewModel selectedFolder = null;

        private ContentBaseViewModel selectedItem;

        private readonly ObservableAsPropertyHelper<IEnumerable<ContentBaseViewModel>> _contentList;

        public ListViewModel(IContentBaseService contentBaseService)
        {
            this.contentBaseService = contentBaseService;
            viewModelFactory = new ContentBaseViewModelFactory();

            _contentList = this
                .WhenAnyValue(x => x.SelectedFolder)
                .Where(o => !IsNull(o))
                .Select(t => GetContent(t.Id))
                .ToProperty(this, x => x.ContentList);
        }

        public IEnumerable<ContentBaseViewModel> ContentList => _contentList.Value;

        public ContentBaseViewModel SelectedItem
        {
            get => selectedItem;
            set => this.RaiseAndSetIfChanged(ref selectedItem, value);
        }

        public ContentFolderViewModel SelectedFolder
        {
            get => selectedFolder;
            set => this.RaiseAndSetIfChanged(ref selectedFolder, value);
        }

        private IEnumerable<ContentBaseViewModel> GetContent(int id)
        {
            var item = contentBaseService.GetContentItemById(id);
            var list = viewModelFactory.GetViewModels(item.Children, selectedFolder);

            return new List<ContentBaseViewModel>(list);
        }

        private bool IsNull(object obj)
        {
            if (obj == null)
                return true;
            else
                return false;
        }
    }
}
